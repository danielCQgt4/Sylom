(function () {
    const pathM = window.location.pathname;
    switch (pathM) {
        case '/seguridad':
            (function () {
                var btnAdd = gI('seguridad-btn-add') || null;
                if (btnAdd) {
                    btnAdd.addEventListener('click', () => {
                        window.location.href = "/seguridad/crear";
                    });
                }
            })();
            break;
        default:
            window.location.href = '/seguridad';
    }

    (() => {
        const table = gI('seguridad-table');

        if (table) {
            app.o.pjson('/seguridad/rol/read', null, json => {
                if (json) {
                    if (json.result) {
                        json.result.forEach(obj => {
                            var r = nRRow(obj);
                            table.appendChild(r);
                        });
                    }
                }
            });
        }

        function nRRow(data) {
            var tr = ndom('tr');
            tr.setAttribute('id', data.idRol);
            var td1 = ndom('td');
            td1.appendChild(ntn(data.idRol));
            tr.appendChild(td1);
            var td2 = ndom('td');
            td2.appendChild(ntn(data.descripcion));
            tr.appendChild(td2);
            var td3 = ndom('td');
            if (update) {
                var btn1 = ndom('button');
                btn1.addEventListener('click', () => {
                    window.location.href = '/seguridad/rol/editar/' + data.idPaciente;
                });
                var i = ndom('i');
                i.setAttribute('class', 'fas fa-pencil-alt');
                btn1.appendChild(i);
                btn1.setAttribute('title', 'Modificar');
                btn1.setAttribute('class', 'btn cyc-btn-primary-2 admin-box-body-btn-actions');
                td3.appendChild(btn1);
            }
            if (del) {
                var btn2 = ndom('button');
                btn2.addEventListener('click', () => {
                    var c = app.o.diagC('Esta seguro/a que desea eliminar este dato?', (r) => {
                        if (r) {
                            rmM(c.id);
                            var w = app.o.diagW('Espere un momento');
                            app.o.pjson('/seguridad/rol/delete', { idRol: data.idRol }, json => {
                                if (json) {
                                    if (json.result) {
                                        app.o.sM('El rol ha sido eliminado', gI('seguridad-msg'));
                                        rmM(tr.id);
                                    } else {
                                        app.o.eM('El rol no ha sido eliminado', gI('seguridad-msg'));
                                    }
                                    w.rm();
                                }
                            });
                        } else {
                            rmM(c.id);
                        }
                    });
                });
                btn2.setAttribute('class', 'btn cyc-btn-danger-2 admin-box-body-btn-actions');
                var i = ndom('i');
                i.setAttribute('class', 'fas fa-times');
                btn2.appendChild(i);
                btn2.setAttribute('title', 'Eliminar');
                td3.appendChild(btn2);
            }
            tr.appendChild(td3);
            return tr;
        }
    })();


})();