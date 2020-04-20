(() => {
    "use-strict";
    document.addEventListener("DOMContentLoaded", function (event) {
        const ui = gI('/mantenimientos');
        if (ui) {
            ui.className += ' cyc-nav-item-active';
        }
    });


    if (atcInd) {
        (() => {
            const dpItems = gI('mante-dp-items');
            //const dpOptions = gN('mante-dp-option');
            const btnAdd = gI('mante-btn-add');
            const manteMsg = gI('mante-msg');

            function getMode() {
                const rawUrl = window.location.href.split('/');
                var mode = rawUrl[rawUrl.length - 1];
                if (mode == 'mantenimientos') {
                    mode = 'tipopaciente';
                }
                return mode;
            }

            //init
            (() => {

                if (btnAdd) {
                    btnAdd.addEventListener('click', () => {
                        window.location.href = app.api.mante.urc + '/' + getMode();
                    });
                }

                if (dpItems) {
                    const childs = dpItems.children;
                    for (var i = 0; i < childs.length; i++) {
                        const option = childs[i];
                        option.setAttribute('class', 'admin-nav-list-item');
                        if (option.dataset.path == getMode()) {
                            option.setAttribute('class', 'admin-nav-list-item-active');
                        }
                        option.addEventListener('click', () => {
                            window.location.href = app.api.mante.u + "/" + option.dataset.path;
                        });
                    }
                }

            })();

            //getData
            (() => {
                const filter = gI('input-filter');
                const btnFilter = gI('btn-filter');
                const data = [];
                var onlyAvaible = false;

                var table = gI('mante-table');
                if (table) {
                    function initData(b) {
                        app.o.pjson(app.api.mante.ur, { mode: getMode() }, json => {
                            if (json) {
                                if (json.result) {
                                    json.result.forEach(obj => {
                                        data.push(obj);
                                    });
                                    b(true);
                                } else {
                                    b(false);
                                }
                            } else {
                                b(false);
                            }
                        });
                    }

                    if (filter) {
                        function initInfo() {
                            initData(r => {
                                if (r) {
                                    fillinfo();
                                } else {
                                    app.o.diagE('Error al cargar la informacion');
                                }
                            });
                        }

                        function fillinfo(d) {
                            table.innerHTML = '';
                            data.forEach(o => {
                                if (o.activo || onlyAvaible) {
                                    if (d) {
                                        const keys = Object.keys(o);
                                        keys.forEach(kv => {
                                            if (String(o[kv]).toLowerCase().includes(d)) {
                                                table.appendChild(newRowData(o, o.asignado));
                                            }
                                        });
                                    } else {
                                        table.appendChild(newRowData(o, o.asignado));
                                    }
                                }
                            });
                        }

                        initInfo();

                        filter.addEventListener('keyup', loadFilter);

                        function loadFilter() {
                            const val = !!filter.value ? filter.value.toLowerCase() : null;
                            fillinfo(val);
                        }

                        if (btnFilter) {
                            btnFilter.addEventListener('click', () => {
                                const dg = ndom();
                                dg.setAttribute('id', 'diag-back');
                                dg.setAttribute('class', 'diag-back');
                                const f = ndom();
                                f.setAttribute('class', 'diag-filter');
                                dg.appendChild(f);
                                const title = ndom('h3');
                                title.appendChild(ntn('Filtros'));
                                f.appendChild(title);
                                f.appendChild(ndom('hr'));
                                const d = ndom();
                                d.setAttribute('class', 'form-group d-flex justify-content-between flex-row');
                                f.appendChild(d);
                                const lbl = ndom('label');
                                lbl.appendChild(ntn('Mostrar deshabilitados'));
                                d.appendChild(lbl);
                                const ch = ndom('input');
                                ch.setAttribute('type', 'checkbox');
                                if (onlyAvaible) {
                                    ch.setAttribute('checked', onlyAvaible);
                                }
                                ch.setAttribute('style', 'margin-right:10px;cursor:pointer;');
                                d.appendChild(ch);
                                const btn = ndom('button');
                                btn.setAttribute('class', 'btn cyc-btn-success-2 cyc-w-100');
                                btn.appendChild(ntn('Aceptar'));
                                btn.addEventListener('click', () => {
                                    onlyAvaible = ch.checked;
                                    close();
                                    loadFilter();
                                });
                                f.appendChild(btn);
                                const btn2 = ndom('button');
                                btn2.setAttribute('class', 'btn cyc-btn-danger-2 cyc-w-100 mt-2');
                                btn2.appendChild(ntn('Cancelar'));
                                btn2.addEventListener('click', close);
                                function close() {
                                    (dg.setAttribute('class', 'diag-back-close'),
                                        setTimeout(() => {
                                            rmM(dg.id);
                                        }, 400)
                                    );
                                }
                                f.appendChild(btn2);
                                gI('body').appendChild(dg);
                            });
                        }
                    }

                    function newRowData(dd, asignado) {
                        var tr = ndom('tr');
                        tr.setAttribute('id', 'tr-' + dd.id);
                        var td = ndom('td');
                        td.appendChild(ntn(dd.id));
                        tr.appendChild(td);
                        var td2 = ndom('td');
                        td2.appendChild(ntn(dd.desc));
                        tr.appendChild(td2);
                        var td3 = ndom('td');
                        var btn1 = ndom('button');
                        var btn2 = ndom('button');
                        btn1.setAttribute('id', 'ksajfh' + dd.id + 'asdfjhs');
                        btn1.setAttribute('class', 'btn cyc-btn-primary-2 admin-box-body-btn-actions');
                        var i = ndom('i');
                        i.setAttribute('class', 'fas fa-pencil-alt');
                        btn1.appendChild(i);
                        btn1.setAttribute('title', 'Modificar');
                        btn2.setAttribute('class', dd.activo ? 'btn cyc-btn-danger-2 admin-box-body-btn-actions'
                            : 'btn cyc-btn-warning admin-box-body-btn-actions');
                        var i = ndom('i');
                        i.setAttribute('class', dd.activo ? 'fas fa-times' : 'fas fa-undo-alt');
                        btn2.appendChild(i);
                        btn2.setAttribute('title', dd.activo ? 'Eliminar' : 'Habilitar');
                        if (update) {
                            if (dd.activo) {
                                td3.appendChild(btn1);
                                btn1.addEventListener('click', () => {
                                    window.location.href = app.api.mante.uru + '/' + getMode() + '/' + dd.id;
                                });
                            }
                        }
                        if (del && !asignado) {
                            td3.appendChild(btn2);
                            btn2.addEventListener('click', () => {
                                function action(c) {
                                    const msg = dd.activo ? 'Se ha eliminado el dato' : 'Se ha restaurado el dato';
                                    const w = app.o.diagW('Espere un momento');
                                    const d = { mode: getMode(), id: dd.id };
                                    const ur = dd.activo ? app.api.mante.ud : app.api.mante.ure;
                                    app.o.pjson(ur, d, json => {
                                        if (json.result) {
                                            app.o.sM(msg, manteMsg);
                                            if (!onlyAvaible) {
                                                rmM(tr.id);
                                                dd.activo = false;

                                                //btn2.setAttribute('class', dd.activo ? 'btn cyc-btn-danger-2 admin-box-body-btn-actions'
                                                //    : 'btn cyc-btn-warning admin-box-body-btn-actions');
                                                //i.setAttribute('class', dd.activo ? 'fas fa-times' : 'fas fa-undo-alt');
                                                //btn2.appendChild(i);
                                                //btn2.setAttribute('title', dd.activo ? 'Eliminar' : 'Habilitar');
                                            } else {
                                                dd.activo = !dd.activo;
                                                //rmM(btn1.id);
                                                //btn2.setAttribute('class', dd.activo ? 'btn cyc-btn-danger-2 admin-box-body-btn-actions'
                                                //    : 'btn cyc-btn-warning admin-box-body-btn-actions');
                                                //i.setAttribute('class', dd.activo ? 'fas fa-times' : 'fas fa-undo-alt');
                                                //btn2.appendChild(i);
                                                //btn2.setAttribute('title', dd.activo ? 'Eliminar' : 'Habilitar');
                                                //if (dd.activo) {
                                                //    rmM(btn2.id);
                                                //    if (update) {
                                                //        td3.appendChild(btn1);
                                                //    }
                                                //    if (del) {
                                                //        td3.appendChild(btn2);
                                                //    }
                                                //}
                                            }
                                            rmM(btn1.id);
                                            btn2.setAttribute('class', dd.activo ? 'btn cyc-btn-danger-2 admin-box-body-btn-actions'
                                                : 'btn cyc-btn-warning admin-box-body-btn-actions');
                                            i.setAttribute('class', dd.activo ? 'fas fa-times' : 'fas fa-undo-alt');
                                            btn2.appendChild(i);
                                            btn2.setAttribute('title', dd.activo ? 'Eliminar' : 'Habilitar');
                                            if (dd.activo) {
                                                rmM(btn2.id);
                                                if (update) {
                                                    td3.appendChild(btn1);
                                                }
                                                if (del) {
                                                    td3.appendChild(btn2);
                                                }
                                            }
                                        } else {
                                            app.o.eM('No se pudo eliminar el dato', manteMsg);
                                        }
                                        w.rm();
                                    });
                                    c();
                                    w.rm();
                                }
                                if (dd.activo) {
                                    const c = app.o.diagC('Esta seguro/a que desea eliminar este dato?', b => {
                                        if (b) {
                                            action(() => {
                                                rmM(c.id);
                                            });
                                        } else {
                                            rmM(c.id);
                                        }
                                    });
                                } else {
                                    action();
                                }
                            });
                        }
                        tr.appendChild(td3);
                        return tr;
                    }

                }
            })();

            //main
            (() => {
                switch (getMode()) {
                    case 'tipopaciente':
                        (() => { })();
                        break;
                    case 'medicina':
                        (() => { })();
                        break;
                    case 'institucion':
                        (() => { })();
                        break;
                    case 'tipoempleado':
                        (() => { })();
                        break;
                }
            })();
        })();
    } else {
        (() => {
            var id = -1;
            const desc = gI('mante-desc');
            const tel = gI('mante-tel');
            const dire = gI('mante-direc');

            function getMode() {
                const rawUrl = window.location.href.split('/');
                var mode;
                if (getActionMode() == '/c') {
                    mode = rawUrl[rawUrl.length - 1];
                } else {
                    mode = rawUrl[rawUrl.length - 2];
                }
                if (mode == 'mantenimientos') {
                    mode = 'tipopaciente';
                }
                return mode;
            }


            function getActionMode() {
                const rawUrl = window.location.pathname.split('/');
                const mode = '/' + rawUrl[2];
                return mode;
            }

            function gIdFromU() {
                const rawUrl = window.location.pathname.split('/');
                const i = rawUrl[rawUrl.length - 1];
                return i;
            }

            (() => {
                const mid = gI('mante-id');
                if (mid) {
                    if (getActionMode() == '/c') {
                        mid.value = 'Automatico';
                    } else {
                        mid.value = gIdFromU();
                        id = gIdFromU();
                        var w = app.o.diagW('Espere un momento');
                        app.o.pjson(app.api.mante.uro, { id, mode: getMode() }, json => {
                            if (json) {
                                if (json.result) {
                                    desc.value = json.result.desc;
                                    if (json.result.tel) {
                                        if (dire) {
                                            dire.value = json.result.tel;
                                        }
                                        if (tel) {
                                            tel.value = json.result.tel;
                                        }
                                    }
                                    w.rm();
                                } else {
                                    w.rm();
                                    app.o.diagE('No se pudo obtener la informacion', () => {
                                        window.location.href = app.api.mante.u;
                                    });
                                }
                            } else {
                                w.rm();
                                app.o.diagE('No se pudo obtener la informacion', () => {
                                    window.location.href = app.api.mante.u;
                                });
                            }
                        });
                    }
                }

                const mtmn = gI('mante-title-mante-nav');
                const marbc = gI('mante-back-arrow');
                const bemt = gI('mante-btn-exit');
                if (mtmn) {
                    mtmn.addEventListener('click', () => {
                        window.location.href = app.api.mante.u;
                    });
                }

                if (marbc) {
                    marbc.addEventListener('click', () => {
                        window.location.href = app.api.mante.u;
                    });
                }
                if (bemt) {
                    bemt.addEventListener('click', () => {
                        window.location.href = app.api.mante.u;
                    });
                }
            })();

            (() => {
                const ac = gI('btn-action');
                var uru, m;
                if (getActionMode() == '/c') {
                    uru = app.api.mante.uc;
                    m = 'Se agrego el dato';
                } else {
                    uru = app.api.mante.uu;
                    m = 'Se actualizo el dato';
                }
                if (ac) {
                    ac.addEventListener('click', () => {
                        const d = {};
                        if (getMode() != 'institucion') {
                            const v = app.o.vld(desc);
                            if (v.valid) {
                                d.id = id;
                                d.desc = desc.value;
                                d.mode = getMode();
                            } else {
                                app.o.iF(0, desc);
                                app.o.eM('Complete todos los campos', gI('mante-bg'));
                                return;
                            }
                        } else {
                            const v = app.o.vld(desc);
                            app.o.iF(true, desc, tel, dire);
                            if (v.valid) {
                                d.id = id;
                                d.desc = desc.value;
                                d.tel = tel.value;
                                d.direccion = dire.value;
                                d.mode = getMode();
                            } else {
                                v.array.forEach(obj => {
                                    app.o.iF(false, obj);
                                });
                                console.log(v.valid);
                                app.o.eM('Complete todos los campos', gI('mante-bg'));
                                return;
                            }
                        }
                        const w = app.o.diagW('Espere un momento');
                        app.o.pjson(uru, d, json => {
                            if (json) {
                                if (json.result) {
                                    w.rm();
                                    app.o.diagS(m, () => {
                                        window.location.href = app.api.mante.u;
                                    });
                                } else {
                                    w.rm();
                                    app.o.diagE('Error al completar la accion');
                                    app.o.eM('Complete todos los campos', gI('mante-bg'));
                                }
                            }
                        });
                    });
                }
            })();

            window.onbeforeunload = function (e) {
                var e = e || window.event;

                // For IE and Firefox
                if (e) {
                    e.returnValue = 'Leaving the page';
                }

                // For Safari
                return 'Leaving the page';
            };
        })();
    }

})();