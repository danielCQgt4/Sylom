//(function () {
var dpItems = gI('mante-dp-items');
var dpSelect = gI('mante-dp-select');
var dpContainer = gI('mante-dp-container');
var dpOptions = document.getElementsByName('mante-dp-option');

function init() {
    dpSelect.addEventListener('click', () => {
        app.o.tog(dpItems, 0.5);
    });

    dpContainer.addEventListener('mouseleave', () => {
        if (dpItems.style.display == 'block') {
            app.o.tog(dpItems, 0.5);
        }
    });

    for (var i = 0; i < dpOptions.length; i++) {
        const option = dpOptions[i];
        option.addEventListener('click', () => {
            window.location.href = "/mantenimientos?mode=" + option.dataset.path;
        });
    }
}

function getMode() {
    var rawUrl = window.location.href.split('?');
    if (rawUrl.length == 2) {
        return rawUrl[1].replace("mode=", "");
    }
    return "tipopaciente";
}

function newData(id, desc) {
    var tr = ndom('tr');
    var td = ndom('td');
    td.appendChild(ntn(id));
    tr.appendChild(td);
    var td2 = ndom('td');
    td2.appendChild(ntn(desc));
    tr.appendChild(td2);
    var td3 = ndom('td');
    var btn1 = ndom('button');
    var btn2 = ndom('button');
    btn1.setAttribute('class', 'btn cyc-btn-primary-2 mante-box-body-btn-actions');
    btn1.appendChild(ntn('Modificar'));
    btn2.setAttribute('class', 'btn cyc-btn-danger-2 mante-box-body-btn-actions');
    btn2.appendChild(ntn('Eliminar'));
    if (update) {
        td3.appendChild(btn1);
    }
    if (del) {
        td3.appendChild(btn2);
    }
    tr.appendChild(td3);
    return tr;
}

function getData() {
    var table = gI('mante-table');
    if (table) {
        app.o.p("/mantenimientos/read", "mode=" + getMode(), function (json) {
            console.log(json);
            if (!json.errorBC) {
                var id, desc, data;
                for (var i = 0; i < json.length; i++) {
                    data = json[i];
                    if (data) {
                        switch (getMode()) {
                            case 'tipopaciente':
                                id = data.idTipoPaciente;
                                break;
                            case 'tipoempleado':
                                id = data.idTipoEmpleado;
                                break;
                            case 'medicina':
                                id = data.idMedicina;
                                break;
                        }
                        desc = data.descripcion;
                        table.appendChild(newData(id, desc));
                    }
                }
            }
        });
    }
}

init();
getData();

//})();