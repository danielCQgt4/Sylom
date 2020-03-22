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
        const table = gI('paciente-table');

        if (table) {
            app.o.pjson('/paciente/read', {}, json => {
                if (json) {
                    if (json.result) {
                        json.result.forEach(obj => {
                            var r = nPRow(obj);
                            table.appendChild(r);
                        });
                        console.log(json.result);
                    }
                }
            });
        }

        function nPRow(data) {
            var tr = ndom('tr');
            tr.setAttribute('id', data.idPaciente);
            var td1 = ndom('td');
            td1.appendChild(ntn(data.idPaciente));
            tr.appendChild(td1);
            var td2 = ndom('td');
            td2.appendChild(ntn(data.nombre + ' ' + data.apellido1 + ' ' + data.apellido2));
            tr.appendChild(td2);
            var td3 = ndom('td');
            td3.appendChild(ntn(data.cedula));
            tr.appendChild(td3);
            var td4 = ndom('td');
            td4.appendChild(ntn(data.idTipoPaciente));
            tr.appendChild(td4);
            var td6 = ndom('td');
            if (update) {
                var btn1 = ndom('button');
                btn1.addEventListener('click', () => {
                    window.location.href = '/paciente/editar/' + data.idPaciente;
                });
                var i = ndom('i');
                i.setAttribute('class', 'fas fa-pencil-alt');
                btn1.appendChild(i);
                btn1.setAttribute('title', 'Modificar');
                btn1.setAttribute('class', 'btn cyc-btn-primary-2 admin-box-body-btn-actions');
                td6.appendChild(btn1);
            }
            if (del) {
                var btn2 = ndom('button');
                btn2.addEventListener('click', () => {
                    var c = app.o.diagC('Esta seguro/a que desea eliminar este dato?', (r) => {
                        if (r) {
                            rmM(c.id);
                            var w = app.o.diagW('Espere un momento');
                            app.o.pjson('/paciente/delete', { idPaciente: data.idPaciente }, json => {
                                if (json) {
                                    if (json.result) {
                                        app.o.sM('El paciente ha sido eliminado', gI('paciente-msg'));
                                        rmM(tr.id);
                                    } else {
                                        app.o.eM('El paciente no ha sido eliminado', gI('paciente-msg'));
                                    }
                                    rmM(w.id);
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
                //btn2.appendChild(ntn(''));// Eliminar
                td6.appendChild(btn2);
            }
            tr.appendChild(td6);
            return tr;
        }
    })();


})();