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

    function newRowEmpleado(data) {
        const tr = ndom('tr');
        tr.setAttribute('id', 'tr-' + data.idEmpleado);
        const td1 = ndom('td');
        td1.appendChild(ntn(data.idEmpleado));
        tr.appendChild(td1);
        const td2 = ndom('td');
        td2.appendChild(ntn(data.nombre));
        tr.appendChild(td2);
        const td3 = ndom('td');
        td3.appendChild(ntn(data.descripcion));
        tr.appendChild(td3);
        const td4 = ndom('td');
        if (update) {
            const btn1 = ndom('button');
            btn1.addEventListener('click', () => {
                window.location.href = '/empleado/editar/' + data.idEmpleado;
            });
            const i = ndom('i');
            i.setAttribute('class', 'fas fa-pencil-alt');
            btn1.appendChild(i);
            btn1.setAttribute('title', 'Modificar');
            btn1.setAttribute('class', 'btn cyc-btn-primary-2 admin-box-body-btn-actions');
            td4.appendChild(btn1);
        }
        if (del && data.idEmpleado != idEmpleado) {
            const btn2 = ndom('button');
            btn2.addEventListener('click', () => {
                const c = app.o.diagC('Esta seguro/a que desea eliminar este dato?', (r) => {
                    if (r) {
                        const w = app.o.diagW();
                        const d = { idEmpleado: data.idEmpleado };
                        app.o.pjson('/empleado/delete', d, (json) => {
                            if (json.result) {
                                app.o.sM('El empleado ha sido eliminado', gI('empleado-msg'));
                                rmM(tr.id);
                            } else {
                                app.o.eM('El empleado no ha sido eliminado', gI('empleado-msg'));
                            }
                            w.rm();
                        });
                    }
                    rmM(c.id);
                });
            });
            btn2.setAttribute('class', 'btn cyc-btn-danger-2 admin-box-body-btn-actions');
            const i = ndom('i');
            i.setAttribute('class', 'fas fa-times');
            btn2.appendChild(i);
            btn2.setAttribute('title', 'Eliminar');
            td4.appendChild(btn2);
        }
        const btn3 = ndom('button');
        btn3.setAttribute('class', 'btn cyc-btn-warning admin-box-body-btn-actions');
        const i = ndom('i');
        i.setAttribute('class', 'fas fa-file-medical');
        btn3.appendChild(i);
        btn3.setAttribute('title', 'Ver registros');
        td4.appendChild(btn3);
        tr.appendChild(td4);
        return tr;
    }

    (() => {
        const table = gI('empleado-table');
        if (table) {
            app.o.pjson('/empleado/read', null, json => {
                if (json) {
                    if (json.result) {
                        json.result.forEach(obj => {
                            const tr = newRowEmpleado(obj);
                            table.appendChild(tr);
                        });
                    } else {
                        app.o.diagE('Error al obtener la informacion');
                    }
                } else {
                    app.o.diagE('Error al obtener la informaciones');
                }
            });
        }
    })();

})();