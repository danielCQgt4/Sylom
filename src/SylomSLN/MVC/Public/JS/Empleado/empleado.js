"use-strict";
(function () {

    const btnAdd = gI('empleado-btn-add');

    (() => {
        if (btnAdd) {
            btnAdd.addEventListener('click', () => {
                window.location.href = '/empleado/crear';
            });
        }
    })();


    (() => {
        const filter = gI('input-filter');
        const btnFilter = gI('btn-filter');
        const data = [];
        var onlyAvaible = false;

        const table = gI('empleado-table');
        if (table) {
            function initData(b) {
                app.o.pjson('/empleado/read', null, json => {
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
                                var add = false;
                                keys.forEach(kv => {
                                    if (String(o[kv]).toLowerCase().includes(d) && !add) {
                                        add = true;
                                        table.appendChild(newRowEmpleado(o));
                                    }
                                });
                            } else {
                                table.appendChild(newRowEmpleado(o));
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


            function newRowEmpleado(dd) {
                const tr = ndom('tr');
                tr.setAttribute('id', 'tr-' + dd.idEmpleado);
                const td1 = ndom('td');
                td1.appendChild(ntn(dd.idEmpleado));
                tr.appendChild(td1);
                const td2 = ndom('td');
                td2.appendChild(ntn(dd.nombre));
                tr.appendChild(td2);
                const td3 = ndom('td');
                td3.appendChild(ntn(dd.descripcion));
                tr.appendChild(td3);
                const td4 = ndom('td');
                const btn1 = ndom('button');
                const btn2 = ndom('button');
                const btn3 = ndom('button');
                if (update) {
                    btn1.addEventListener('click', () => {
                        window.location.href = '/empleado/editar/' + dd.idEmpleado;
                    });
                    const i = ndom('i');
                    i.setAttribute('class', 'fas fa-pencil-alt');
                    btn1.appendChild(i);
                    btn1.setAttribute('title', 'Modificar');
                    btn1.setAttribute('id', 'ksajfh' + dd.idEmpleado + 'asdfjhs');
                    btn1.setAttribute('class', 'btn cyc-btn-primary-2 admin-box-body-btn-actions');
                    if (dd.activo) {
                        td4.appendChild(btn1);
                    }
                }
                if (del && dd.idEmpleado != idEmpleado) {
                    btn2.addEventListener('click', () => {
                        function action(c) {
                            const msg = dd.activo ? 'Se ha eliminado el dato' : 'Se ha restaurado el dato';
                            const w = app.o.diagW();
                            const d = { idEmpleado: dd.idEmpleado };
                            const ur = dd.activo ? '/empleado/delete' : '/empleado/reactivate';
                            app.o.pjson(ur, d, (json) => {
                                if (json) {
                                    if (json.result) {
                                        app.o.sM(msg, gI('empleado-msg'));
                                        if (!onlyAvaible) {
                                            rmM(tr.id);
                                            dd.activo = false;
                                        } else {
                                            dd.activo = !dd.activo;
                                        }
                                        rmM(btn3.id);
                                        rmM(btn2.id);
                                        rmM(btn1.id);
                                        btn2.setAttribute('class', dd.activo ? 'btn cyc-btn-danger-2 admin-box-body-btn-actions'
                                            : 'btn cyc-btn-warning admin-box-body-btn-actions');
                                        i.setAttribute('class', dd.activo ? 'fas fa-times' : 'fas fa-undo-alt');
                                        btn2.appendChild(i);
                                        btn2.setAttribute('title', dd.activo ? 'Eliminar' : 'Habilitar');
                                        if (dd.activo) {
                                            rmM(btn2.id);
                                            if (update) {
                                                td4.appendChild(btn1);
                                            }
                                            if (del) {
                                                td4.appendChild(btn2);
                                            }
                                            td4.appendChild(btn3);
                                        }
                                    } else {
                                        app.o.diagE('No se pudo completar la operacion');
                                    }
                                } else {
                                    app.o.diagE('No se pudo completar la operacion');
                                }
                            });
                            if (c) {
                                c();
                            }
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
                    btn2.setAttribute('class', dd.activo ? 'btn cyc-btn-danger-2 admin-box-body-btn-actions'
                        : 'btn cyc-btn-warning admin-box-body-btn-actions');
                    const i = ndom('i');
                    i.setAttribute('class', dd.activo ? 'fas fa-times' : 'fas fa-undo-alt');
                    btn2.appendChild(i);
                    btn2.setAttribute('title', dd.activo ? 'Eliminar' : 'Habilitar');
                    td4.appendChild(btn2);
                }
                btn3.setAttribute('class', 'btn cyc-btn-warning admin-box-body-btn-actions');
                const i = ndom('i');
                i.setAttribute('class', 'fas fa-file-medical');
                btn3.appendChild(i);
                btn3.setAttribute('id', 'sdkjfl' + dd.idEmpleado + 'asdfhkj');
                btn3.setAttribute('title', 'Ver registros');
                if (dd.activo) {
                    td4.appendChild(btn3);
                }
                tr.appendChild(td4);
                return tr;
            }

        }
    })();

})();