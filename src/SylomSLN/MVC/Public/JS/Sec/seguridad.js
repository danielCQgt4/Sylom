"use-strict";
//Dg
(function () {

})();

//Funciones principales
(function () {
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
                //newDg();
            });
        }

        for (var i = 0; i < dpOptions.length; i++) {
            const option = dpOptions[i];
            option.addEventListener('click', () => {
                window.location.href = "/seguridad?mode=" + option.dataset.path;
            });
        }
    }

    function getNameByType() {
        switch (getMode()) {
            case 'roles':
                return '';
            case 'asignacion':
                return '';
        }
    }

    function getMode() {
        var rawUrl = window.location.href.split('?');
        if (rawUrl.length == 2) {
            return rawUrl[1].replace("mode=", "");
        }
        return "roles";
    }

    function newRowData() {
        
    }

    function newDg() {
        if (create || update) {
            
        }
    }

    function getData() {
        var table = gI('mante-table');
        if (table) {
            
        }
    }

    init();
    getData();

})();