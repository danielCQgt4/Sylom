(() => {

    function getMode() {
        const uraw = window.location.pathname;
        const rde = uraw.split('/');
        return rde[2] || null;
    }

    function getEmpleadoId() {
        const uraw = window.location.pathname;
        const rde = uraw.split('/');
        return rde[rde.length - 1];
    }

    (() => {
        const nombre = gI('empleado-form-nombre');
        const tipoEmpleado = gI('empleado-form-tipoempleado');
        const action = gI('btn-action');
        const user = gI('empleado-form-usuario');
        const pass = gI('empleado-form-pass');
        const confirm = gI('empleado-form-confirm');

        //init
        (() => {
            user.value = '';
            pass.value = '';
            confirm.value = '';
            const ex = gN('empleado-dp-select');
            for (var i = 0; i < ex.length; i++) {
                ex[i].addEventListener('click', () => {
                    window.location.href = '/empleado';
                });
            }

            (() => {
                var w = app.o.diagW();
                initTipoEmpleado(r => {
                    if (r) {
                        if (getMode() == 'editar') {
                            initEmpleado(r => {
                                w.rm();
                                if (!r) {
                                    err();
                                }
                            });
                        }
                        w.rm();
                    } else {
                        w.rm();
                        err();
                    }
                });
                function err() {
                    app.o.diagE('Se produjo un error al cargar la informacion. Usted volvera a la pagina anterior', () => {
                        window.location.href = '/empleado';
                    });
                }
            })();

            function initTipoEmpleado(cb) {
                app.o.pjson('/empleado/tipo/read', null, json => {
                    if (json) {
                        if (json.result) {
                            console.log(json.result);
                            json.result.forEach(o => {
                                const op = ndom('option');
                                op.setAttribute('value', o.idTipoEmpleado);
                                op.appendChild(ntn(o.descripcion));
                                tipoEmpleado.appendChild(op);
                            });
                            cb(true);
                        } else {
                            cb(false);
                        }
                    } else {
                        cb(false);
                    }
                });
            }

            function initEmpleado(cb) {
                app.o.pjson('/empleado/readone', { idEmpleado: getEmpleadoId() }, json => {
                    if (json) {
                        if (json.result) {
                            console.log(json.result);
                            cb(true);
                        } else {
                            cb(false);
                        }
                    } else {
                        cb(false);
                    }
                });
            }
        })();

        if (action) {
            action.addEventListener('click', () => {
                var w = app.o.diagW();
                const d = {};
                app.o.pjson('/empleado/create', d, json => {
                    //AJX
                });
            });
        }
    })();

})();