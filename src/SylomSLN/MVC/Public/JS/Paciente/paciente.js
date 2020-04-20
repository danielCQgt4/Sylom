(function () {
    const pathM = window.location.pathname;
    switch (pathM) {
        case '/paciente':
            (function () {
                var btnAdd = gI('paciente-btn-add') || null;
                if (btnAdd) {
                    btnAdd.addEventListener('click', () => {
                        window.location.href = "/paciente/crear";
                    });
                }
            })();
            break;
        default:
            window.location.href = '/paciente';
    }

    (() => {
        const filter = gI('input-filter');
        const btnFilter = gI('btn-filter');
        const data = [];
        var onlyAvaible = false;

        const table = gI('paciente-table');
        if (table) {
            function initData(b) {
                app.o.pjson('/paciente/read', {}, json => {
                    if (json) {
                        if (json.result) {
                            json.result.forEach(obj => {
                                data.push(obj);
                            });
                            console.log(json.result);
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
                                        table.appendChild(nPRow(o));
                                    }
                                });
                            } else {
                                table.appendChild(nPRow(o));
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
        }

        function nPRow(dd) {
            var tr = ndom('tr');
            tr.setAttribute('id', dd.idPaciente);
            var td1 = ndom('td');
            td1.appendChild(ntn(dd.idPaciente));
            tr.appendChild(td1);
            var td2 = ndom('td');
            td2.appendChild(ntn(dd.nombre + ' ' + dd.apellido1 + ' ' + dd.apellido2));
            tr.appendChild(td2);
            var td3 = ndom('td');
            td3.appendChild(ntn(dd.cedula));
            tr.appendChild(td3);
            var td4 = ndom('td');
            td4.appendChild(ntn(dd.idTipoPaciente));
            tr.appendChild(td4);
            var td6 = ndom('td');
            if (update) {
                var btn1 = ndom('button');
                btn1.addEventListener('click', () => {
                    window.location.href = '/paciente/editar/' + dd.idPaciente;
                });
                var i = ndom('i');
                i.setAttribute('class', 'fas fa-pencil-alt');
                btn1.appendChild(i);
                btn1.setAttribute('title', 'Modificar');
                btn1.setAttribute('id', 'ksajfh' + dd.idPaciente + 'asdfjhs');
                btn1.setAttribute('class', 'btn cyc-btn-primary-2 admin-box-body-btn-actions');
                if (dd.activo) {
                    td6.appendChild(btn1);
                }
            }
            if (del) {
                var btn2 = ndom('button');
                btn2.addEventListener('click', () => {
                    function action(c) {
                        const msg = dd.activo ? 'El paciente ha sido eliminado' : 'El paciente ha sido habilitado';
                        var w = app.o.diagW('Espere un momento');
                        const ur = dd.activo ? '/paciente/delete' : '/paciente/reactivate';
                        app.o.pjson(ur, { idPaciente: dd.idPaciente }, json => {
                            if (json) {
                                if (json.result) {
                                    if (!onlyAvaible) {
                                        app.o.sM(msg, gI('paciente-msg'));
                                        rmM(tr.id);
                                        dd.activo = false;
                                    } else {
                                        dd.activo = !dd.activo;
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
                                            td6.appendChild(btn1);
                                        }
                                        if (del) {
                                            td6.appendChild(btn2);
                                        }
                                    }
                                    w.rm();
                                } else {
                                    w.rm();
                                    app.o.eM('El paciente no ha sido eliminado', gI('paciente-msg'));
                                }
                            } else {
                                w.rm();
                                app.o.eM('El paciente no ha sido eliminado', gI('paciente-msg'));
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
                btn2.setAttribute('class', 'btn cyc-btn-danger-2 admin-box-body-btn-actions');
                var i = ndom('i');
                i.setAttribute('class', dd.activo ? 'fas fa-times' : 'fas fa-undo-alt');
                btn2.appendChild(i);
                btn2.setAttribute('class', dd.activo ? 'btn cyc-btn-danger-2 admin-box-body-btn-actions'
                    : 'btn cyc-btn-warning admin-box-body-btn-actions');
                btn2.setAttribute('title', dd.activo ? 'Eliminar' : 'Habilitar');
                td6.appendChild(btn2);
            }
            tr.appendChild(td6);
            return tr;
        }
    })();


})();