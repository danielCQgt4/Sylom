(() => {

    function getMode() {
        const uraw = window.location.pathname;
        const rde = uraw.split('/');
        return rde[3] || null;
    }

    (() => {
        const ex = gN('seguridad-dp-select');
        for (var i = 0; i < ex.length; i++) {
            ex[i].addEventListener('click', () => {
                window.location.href = '/seguridad';
            });
        }
       
    })();

    (() => {
        const msg = gI('seguridad-msg');
        const action = gI('btn-action');
        const id = gI('seguridad-form-id');
        const desc = gI('seguridad-form-desc');
        const tableApart = gI('seguridad-table-apart');
        const tableUser = gI('seguridad-table-user');

        switch (getMode()) {
            case 'editar':
                (() => {
                })();
                break;
            case 'crear':
                (() => {

                    (() => {
                        if (id) {
                            id.value = 'Automatico';
                        }
                    })();
                })()
                break;
        }


        if (action) {
            action.addEventListener('click', () => {
                var w = app.o.diagW();
                //Ajax
            });
        }


        (() => {

        })();
    })();
    
})();