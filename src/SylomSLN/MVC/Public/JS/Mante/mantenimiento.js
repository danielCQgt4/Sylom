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
                    console.log(childs);
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
                var table = gI('mante-table');
                if (table) {
                    app.o.pjson(app.api.mante.ur, { mode: getMode() }, (json) => {
                        if (json) {
                            if (json.result) {
                                json.result.forEach((obj) => {
                                    const data = {
                                        id: obj.id,
                                        desc: obj.desc
                                    };
                                    table.appendChild(newRowData(data, obj.asignado));
                                });
                            }
                        }
                    });
                }

                function newRowData(data, asignado) {
                    var tr = ndom('tr');
                    tr.setAttribute('id', 'tr-' + data.id);
                    var td = ndom('td');
                    td.appendChild(ntn(data.id));
                    tr.appendChild(td);
                    var td2 = ndom('td');
                    td2.appendChild(ntn(data.desc));
                    tr.appendChild(td2);
                    var td3 = ndom('td');
                    var btn1 = ndom('button');
                    var btn2 = ndom('button');
                    btn1.setAttribute('class', 'btn cyc-btn-primary-2 admin-box-body-btn-actions');
                    var i = ndom('i');
                    i.setAttribute('class', 'fas fa-pencil-alt');
                    btn1.appendChild(i);
                    btn1.setAttribute('title', 'Modificar');
                    btn2.setAttribute('class', 'btn cyc-btn-danger-2 admin-box-body-btn-actions');
                    var i = ndom('i');
                    i.setAttribute('class', 'fas fa-times');
                    btn2.appendChild(i);
                    btn2.setAttribute('title', 'Eliminar');
                    if (update) {
                        td3.appendChild(btn1);
                        btn1.addEventListener('click', () => {
                            window.location.href = app.api.mante.uru + '/' + getMode() + '/' + data.id;
                        });
                    }
                    if (del && !asignado) {
                        td3.appendChild(btn2);
                        btn2.addEventListener('click', () => {
                            var msg = app.o.diagC('Esta seguro/a que desea eliminar este dato?', (b) => {
                                var w = app.o.diagW('Espere un momento');
                                if (b && data.id) {
                                    var d = { mode: getMode(), id: data.id };
                                    app.o.pjson(app.api.mante.ud, d, (json) => {
                                        if (json.result) {
                                            app.o.sM('Se ha eliminado el dato', manteMsg);
                                            rmM(tr.id);
                                        } else {
                                            app.o.eM('No se pudo eliminar el dato', manteMsg);
                                        }
                                        w.rm();
                                    });
                                } else {
                                    w.rm();
                                }
                                rmM(msg.id);
                                w.rm();
                            });
                        });
                    }
                    tr.appendChild(td3);
                    return tr;
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