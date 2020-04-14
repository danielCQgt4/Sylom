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
        const idEmpleado = gI('empleado-form-id');
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

            if (getMode() != 'editar') {
                idEmpleado.value = 'Automatico';
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
                var vld = {};
                app.o.iF(false, nombre, pass, confirm);
                if (getMode() != 'editar') {
                    vld = app.o.vld(nombre, pass, confirm);
                } else {
                    vld = app.o.vld(nombre);
                }
                if (vld.valid) {
                    const w = app.o.diagW();
                    if (pass.value == confirm.value) {
                        const d = {
                            nombre: nombre.value,
                            tipoEmpleado: {
                                idTipo: tipoEmpleado.value
                            },
                            usuario: user.value,
                            pass: pass.value
                        };
                        const mm = {};
                        if (getMode() != 'editar') {
                            mm.r = '/empleado/create';
                            mm.t = 'Se agrega la informacion.\nSera redirigido a la pagina principal';
                            mm.e = 'No se pudo agregar la informacion';
                        } else {
                            d.idEmpleado = getEmpleadoId();
                            mm.r = '/empleado/update';
                            mm.t = 'Se modifico la informacion';
                            mm.e = 'No se pudo modificar la informacion';
                        }
                        console.log(d);
                        app.o.pjson(mm.r, d, json => {;
                            if (json) {
                                if (json.result) {
                                    app.o.diagS(mm.t, () => {
                                        window.location.href = '/empleado';
                                    });
                                } else {
                                    w.rm();
                                    app.o.diagE(mm.e);
                                }
                            } else {
                                mm.e = 'Ocurrio un problema';
                                app.o.diagE(mm.e);
                                w.rm();
                            }
                        });
                    } else {
                        app.o.eM('La contraseñas no coinciden', gI('to-msg'));
                        app.o.iF(true, pass, confirm);
                    }
                    w.rm();
                } else {
                    app.o.eM('Completa los campos', gI('to-msg'));
                }
            });
        }
    })();

})();