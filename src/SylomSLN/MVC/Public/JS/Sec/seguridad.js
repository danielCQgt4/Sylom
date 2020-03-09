"use-strict";
//Funciones principales

(function () {
    var dpItems = gI('sec-dp-items');
    var dpSelect = gI('sec-dp-select');
    var dpContainer = gI('sec-dp-container');
    var dpOptions = document.getElementsByName('sec-dp-option');
    var btnAdd = gI('sec-btn-add') || null;
    var manteMsg = gI('sec-msg') || null;

    function init() {
        dpSelect.addEventListener('click', () => {
            app.o.tog(dpItems, 0.5);
        });

        dpContainer.addEventListener('mouseleave', () => {
            if (dpItems.style.display == 'block') {
                app.o.tog(dpItems, 0.5);
            }
        });

        if (btnAdd) {
            btnAdd.addEventListener('click', () => {
                newRolDG(true);
            });
        }

        for (var i = 0; i < dpOptions.length; i++) {
            const option = dpOptions[i];
            option.addEventListener('click', () => {
                window.location.href = "/seguridad?mode=" + option.dataset.path;
            });
        }
    }

    function getMode() {
        var rawUrl = window.location.href.split('?');
        if (rawUrl.length == 2) {
            return rawUrl[1].replace("mode=", "");
        }
        return "roles";
    }

    function newRolDG(type, id, desc) {
        if (create || update) {
            var dg = gI('sec-rol-dg');
            var action = gI('sec-rol-dg-action');
            var action2 = gI('sec-rol-dg-action2');
            var btn1 = ndom('button');
            var btn2 = ndom('button');
            var Fid = gI('sec-rol-id');
            var Fdesc = gI('sec-rol-desc');
            var add = gI('sec-rol-add-apartado');
            var tableApartados = gI('sec-rol-apartado-table');
            const apartados = [];
            const agregados = [];
            const domAgregados = [];
            if (dg && action && action2 && Fid && Fdesc && add && tableApartados) {
                tableApartados.innerHTML = `<tr><th>Apartado</th><th class="cyc-text-center">Crear</th><th class="cyc-text-center">Editar</th><th class="cyc-text-center">Eliminar</th><th class="cyc-text-center">Ver</th><th></th></tr>`;
                function getDataApartados() {
                    app.o.p('/seguridad/rol/read', 'mode=alter', (json) => {
                        json.forEach(obj => {
                            apartados.push(obj);
                        });
                    });
                }
                getDataApartados();
                if (type) {
                    Fid.value = 'Automatico';
                    Fdesc.value = '';
                } else {
                    Fid.value = id;
                    Fdesc.value = desc;

                }
                dg.className = dg.className.replace('d-none', '');
                action.innerHTML = '';
                action2.innerHTML = '';
                btn1.setAttribute('class', 'btn cyc-btn-success-2 cyc-w-100');
                btn1.appendChild(ntn((type) ? 'Agregar' : 'Modificar'));
                btn1.addEventListener('click', () => {
                    if (type) {
                        alert('Agregando');
                    } else {
                        alert('Modificando');
                    }
                })
                action.appendChild(btn1);
                btn2.setAttribute('class', 'btn cyc-btn-danger-2 cyc-w-100');
                btn2.appendChild(ntn('Cancelar'));
                btn2.addEventListener('click', () => {
                    dg.className = dg.className.replace('d-none', '');
                    dg.className += 'd-none';
                });
                action2.appendChild(btn2);
                add.addEventListener('click', () => {
                    const dom = newRolApartadoRow(type, apartados, agregados, domAgregados);
                    domAgregados.push(dom);
                    tableApartados.appendChild(dom.dom);
                    //Actualiza
                });
            }
        }
    }

    function newRolApartadoRow(type, apartados, agregados, arrDom) {
        var idApartado = '';
        var actual;
        var tr = ndom('tr');
        var tdCh = ndom('td');
        var ch = ndom('select');
        var tdCrear = ndom('td');
        var tdEditar = ndom('td');
        var tdEliminar = ndom('td');
        var tdVer = ndom('td');

        ch.setAttribute('class', 'cyc-form-content sec-rol-ch');
        var agrega = true;
        apartados.forEach(obj => {
            for (var i = 0; i < agregados.length; i++) {
                if (obj.idApartado == agregados[i].idApartado) {
                    agrega = false;
                    break;
                }
                agrega = true;
            }
            if (agrega) {
                var op = ndom('option');
                op.setAttribute('value', obj.idApartado);
                op.appendChild(ntn(obj.nombreApartado));
                ch.appendChild(op);
            }
        });

        ch.addEventListener('change', () => {
            idApartado = ch.value;

            agregados.pop(agregados.indexOf(actual));
            apartados.forEach(obj => {
                if (obj.idApartado == idApartado) {
                    //obj.crear = 0;
                    //obj.editar = 0;
                    //obj.eliminar = 0;
                    //obj.leer = 0;
                    agregados.push(obj);
                    actual = obj;
                }
            });

            tdCrear.innerHTML = '';
            var crear = ndom('input');
            if (actual.crear >= 1) {
                crear.setAttribute('type', 'checkbox');
                crear.setAttribute('class', 'd-block cyc-text-center cyc-w-100');
                tdCrear.appendChild(crear);
            }

            tdEditar.innerHTML = '';
            var editar = ndom('input');
            if (actual.editar >= 1) {
                editar.setAttribute('type', 'checkbox');
                editar.setAttribute('class', 'd-block cyc-text-center cyc-w-100');
                tdEditar.appendChild(editar);
            }

            tdEliminar.innerHTML = '';
            var eliminar = ndom('input');
            if (actual.eliminar >= 1) {
                eliminar.setAttribute('type', 'checkbox');
                eliminar.setAttribute('class', 'd-block cyc-text-center cyc-w-100');
                tdEliminar.appendChild(eliminar);
            }

            tdVer.innerHTML = '';
            var ver = ndom('input');
            if (actual.leer >= 1) {
                ver.setAttribute('type', 'checkbox');
                ver.setAttribute('class', 'd-block cyc-text-center cyc-w-100');
                tdVer.appendChild(ver);
            }

            console.log(agregados); console.log(arrDom);
        });
        tdCh.appendChild(ch);
        tr.appendChild(tdCh);

        idApartado = ch.value;
        tr.setAttribute('id', idApartado);
        apartados.forEach(obj => {
            if (obj.idApartado == idApartado) {
                if (type) {
                    agregados.push(obj);
                }
                actual = obj;
            }
        });

        //TODO TErminar, hacer que funcione y que se actualice

        tdCrear.innerHTML = '';
        var crear = ndom('input');
        if (actual.crear >= 1) {
            crear.setAttribute('type', 'checkbox');
            crear.setAttribute('class', 'd-block cyc-text-center cyc-w-100');
            tdCrear.appendChild(crear);
        }
        tr.appendChild(tdCrear);

        tdEditar.innerHTML = '';
        var editar = ndom('input');
        if (actual.editar >= 1) {
            editar.setAttribute('type', 'checkbox');
            editar.setAttribute('class', 'd-block cyc-text-center cyc-w-100');
            tdEditar.appendChild(editar);
        }
        tr.appendChild(tdEditar);

        tdEliminar.innerHTML = '';
        var eliminar = ndom('input');
        if (actual.eliminar >= 1) {
            eliminar.setAttribute('type', 'checkbox');
            eliminar.setAttribute('class', 'd-block cyc-text-center cyc-w-100');
            tdEliminar.appendChild(eliminar);
        }
        tr.appendChild(tdEliminar);

        tdVer.innerHTML = '';
        var ver = ndom('input');
        if (actual.leer >= 1) {
            ver.setAttribute('type', 'checkbox');
            ver.setAttribute('class', 'd-block cyc-text-center cyc-w-100');
            tdVer.appendChild(ver);
        }
        tr.appendChild(tdVer);

        var tdE = ndom('td');
        var del = ndom('i');
        del.setAttribute('class', 'fas fa-times sec-rol-action p-lg-2 w-100');
        del.addEventListener('click', () => {
            agregados.pop(agregados.indexOf(actual));
            arrDom.pop(arrDom.indexOf(tr), 1);
            rmM(tr.id);
            console.log(agregados); console.log(arrDom);
        });
        tdE.appendChild(del);
        tr.appendChild(tdE);

        console.log(agregados); console.log(arrDom);
        //actual.crear = 0;
        //actual.editar = 0;
        //actual.eliminar = 0;
        //actual.leer = 0;
        console.log(agregados); console.log(arrDom);    
        return {
            id: idApartado,
            dom: tr
        };
    }

    function getDataMain() {
        switch (getMode()) {
            case 'roles':
                getDataRol();
                break;
            case 'asignacion':
                break;
        }
    }

    function newRolRow(id, desc) {
        var tr = ndom('tr');
        var tdId = ndom('td');
        tdId.appendChild(ntn(id));
        tr.appendChild(tdId);
        var tdDesc = ndom('td');
        tdDesc.appendChild(ntn(desc));
        tr.appendChild(tdDesc);
        var td3 = ndom('td');
        var btn1 = ndom('button');
        var btn2 = ndom('button');
        btn1.setAttribute('class', 'btn cyc-btn-primary-2 admin-box-body-btn-actions');
        var i = ndom('i');
        i.setAttribute('class', 'fas fa-pencil-alt');
        btn1.appendChild(i);
        btn1.appendChild(ntn(' Modificar'));
        btn2.setAttribute('class', 'btn cyc-btn-danger-2 admin-box-body-btn-actions');
        var i = ndom('i');
        i.setAttribute('class', 'fas fa-times');
        btn2.appendChild(i);
        btn2.appendChild(ntn(' Eliminar'));
        if (update) {
            td3.appendChild(btn1);
            btn1.addEventListener('click', () => {
                newRolDG(false, id, desc);
            });
        }
        if (del) {
            td3.appendChild(btn2);
            btn2.addEventListener('click', () => {
                var m = app.o.diagC('Esta seguro/a que desea eliminar este dato?', (r) => {
                    if (r) {

                    }
                    rmM(m.id);
                });
            });
        }
        tr.appendChild(td3);
        return tr;
    }

    function getDataRol() {
        var table = gI('sec-table');
        if (table) {
            app.o.p('seguridad/rol/read', '', (json) => {
                table.innerHTML = `<tr>
                                    <th>ID</th>
                                    <th>${nombreTh}</th>
                                    <th></th>
                                    </tr>`;
                json.forEach(data => {
                    var tr = newRolRow(data.idRol, data.descripcion);
                    table.appendChild(tr);
                });
            });
        }
    }

    init();
    getDataMain();
})();

/*
var numbers = [45, 4, 9, 16, 25];
var numbers2 = [45, 4, 3];

var esta = false;
numbers.forEach(v1 => {
    for (var i = 0; i < numbers2.length; i++) {
        if (v1 == numbers2[i]) {
            esta = false;
            break;
        }
        esta = true;
    }
    if (esta) {
        console.log(v1);
    }
});*/
