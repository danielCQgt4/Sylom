(function () {
    "use-strict";
    var dpItems = gI('mante-dp-items');
    var dpSelect = gI('mante-dp-select');
    var dpContainer = gI('mante-dp-container');
    var dpOptions = document.getElementsByName('mante-dp-option');
    var btnAdd = gI('mante-btn-add') || null;
    var manteMsg = gI('mante-msg') || null;

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
                newDg(true, -1);
            });
        }

        for (var i = 0; i < dpOptions.length; i++) {
            const option = dpOptions[i];
            option.addEventListener('click', () => {
                window.location.href = app.api.mante.u + "?" + app.o.jsonF({ mode: option.dataset.path });
            });
        }
    }

    function getNameByType() {
        switch (getMode()) {
            case 'tipopaciente':
                return 'del tipo de paciente';
            case 'tipoempleado':
                return 'del tipo de empleado';
            case 'medicinas':
                return 'del tipo de medicina';
        }
    }

    function getMode() {
        var rawUrl = window.location.href.split('?');
        if (rawUrl.length == 2) {
            return rawUrl[1].replace("mode=", "");
        }
        return "tipopaciente";
    }

    function newRowData(id, desc, asignado) {
        var tr = ndom('tr');
        tr.setAttribute('id', 'tr-' + id);
        var td = ndom('td');
        td.appendChild(ntn(id));
        tr.appendChild(td);
        var td2 = ndom('td');
        td2.appendChild(ntn(desc));
        tr.appendChild(td2);
        var td3 = ndom('td');
        var btn1 = ndom('button');
        var btn2 = ndom('button');
        btn1.setAttribute('class', 'btn cyc-btn-primary-2 admin-box-body-btn-actions');
        var i = ndom('i');
        i.setAttribute('class', 'fas fa-pencil-alt');
        btn1.appendChild(i);
        btn1.setAttribute('title', 'Modificar');
        //btn1.appendChild(ntn(' Modificar'));
        btn2.setAttribute('class', 'btn cyc-btn-danger-2 admin-box-body-btn-actions');
        var i = ndom('i');
        i.setAttribute('class', 'fas fa-times');
        btn2.appendChild(i);
        btn2.setAttribute('title', 'Eliminar');
        //btn2.appendChild(ntn(' Eliminar'));
        if (update) {
            td3.appendChild(btn1);
            btn1.addEventListener('click', () => {
                newDg(false, id, desc);
            });
        }
        if (del && !asignado) {
            td3.appendChild(btn2);
            btn2.addEventListener('click', () => {
                var w = app.o.diagW('Espere un momento');
                var msg = app.o.diagC('Esta seguro/a que desea eliminar este dato?', (b) => {
                    if (b && id) {
                        var d = { mode: getMode(), id: id, desc: 'none' };
                        app.o.p(app.api.mante.ud, app.o.jsonF(d), (json) => {
                            if (json.result) {
                                app.o.sM('Se ha eliminado el dato', manteMsg);
                                rmM(tr.id);
                            } else {
                                app.o.eM('No se pudo eliminar el dato', manteMsg);
                            }
                            rmM(w.id);
                        });
                    } else {
                        rmM(w.id);
                    }
                    rmM(msg.id);
                });
            });
        }
        tr.appendChild(td3);
        return tr;
    }

    function newDg(tipo, id, desc, asigno) {
        if (create || update) {
            var dg = gI('mante-dg') || null,
                title = gI('mante-dg-title') || null,
                idlbl = gI('mante-dg-idlbl') || null,
                idDg = gI('mante-dg-id'),
                descDg = gI('mante-dg-desc'),
                action = gI('mante-dg-action') || null,
                action2 = gI('mante-dg-action2') || null;
            if (dg && title && idlbl && action && action2 && idDg && descDg) {
                (function () {
                    action.innerHTML = "";
                    action2.innerHTML = "";
                    if (id && desc) {
                        idDg.value = id;
                        descDg.value = desc;
                    } else {
                        id = -1;
                        idDg.value = 'Automatico';
                        descDg.value = '';
                    }
                })();
                descDg.style = "";
                var w = app.o.diagW('Espere un momentoa'), e = app.o.eM('Corrige los campos', gI('mante-dg-bg'));
                rmM(w.id);
                rmM(e.id);
                var btnCancelar = ndom('button');
                btnCancelar.setAttribute('class', 'cyc-w-100 btn cyc-btn-danger-2');
                btnCancelar.appendChild(ntn('Cancelar'));
                btnCancelar.addEventListener('click', () => {
                    dg.className = dg.className.replace('d-none', '');
                    dg.className += 'd-none';
                });
                action2.appendChild(btnCancelar);
                dg.className = dg.className.replace('d-none', '');
                title.innerHTML = (tipo ? 'Agrega' : 'Modifica') + ' un dato';
                idlbl.innerHTML = 'ID ' + getNameByType();
                var btnAction = ndom('button');
                btnAction.setAttribute('class', 'cyc-w-100 btn cyc-btn-success-2');
                btnAction.appendChild(ntn(tipo ? 'Agregar' : 'Modificar'));
                btnAction.addEventListener('click', () => {
                    w = app.o.diagW('Espere un momento');
                    var d = { mode: getMode(), id: id, desc: descDg.value };
                    var r = tipo ? app.api.mante.uc : app.api.mante.uu;
                    var msg = tipo ? 'e ha agregado el dato' : 'e ha modificado el dato';
                    var err = app.o.vld(descDg);
                    if (err.valid) {
                        app.o.p(r, app.o.jsonF(d), (json) => {
                            if (json.result) {
                                app.o.sM('S' + msg, manteMsg);
                                getData();
                                dg.className = dg.className.replace('d-none', '');
                                dg.className += 'd-none';
                            } else {
                                app.o.eM('Error innesperado' + msg, gI('mante-dg-bg'));
                            }
                            rmM(w.id);
                        });
                    } else {
                        e = app.o.eM('Corrige los campos', gI('mante-dg-bg'));
                        err.array.forEach(obj => {
                            app.o.iF(true, obj);
                        });
                        rmM(w.id);
                    }
                });
                action.appendChild(btnAction);
            }
        }
    }

    function getData() {
        var table = gI('mante-table');
        if (table) {
            app.o.p(app.api.mante.ur, app.o.jsonF({ mode: getMode() }), function (json) {
                table.innerHTML = `<tr><th><strong>ID</strong></th><th>${nombreTh}</th><th></th></tr>`;
                if (json) {
                    var id, desc;
                    json.forEach((obj) => {
                        switch (getMode()) {
                            case 'tipopaciente':
                                id = obj.idTipoPaciente;
                                break;
                            case 'tipoempleado':
                                id = obj.idTipoEmpleado;
                                break;
                            case 'medicinas':
                                id = obj.idMedicina;
                                break;
                        }
                        desc = obj.descripcion;
                        table.appendChild(newRowData(id, desc, obj.asignado));
                    });
                }
            });
        }
    }

    init();
    getData();

})();

