(() => {
    document.addEventListener("DOMContentLoaded", function (event) {
        const ui = gI('/paciente');
        if (ui) {
            ui.className += ' cyc-nav-item-active';
        }
    });

    var dds = gN('empleado-dp-select');
    var exit = gI('paciente-btn-exit');

    function getMode() {
        var ur = window.location.pathname;
        var r = ur.split('/');
        return r[2];
    }

    //General init
    (() => {
        if (dds) {
            dds.forEach(obj => {
                obj.addEventListener('click', () => {
                    window.location.href = '/paciente';
                });
            });
        }
        if (exit) {
            exit.addEventListener('click', () => {
                window.location.href = '/paciente';
            });
        }
        function initForm() {
            if (getMode() === 'crear') {
                gI('paciente-form-id').setAttribute('placeholder', 'Automatico');
            }
        }
        initForm();
    })();

    //Control
    (() => {
        var paciente;
        const btn = gI('btn-action');
        const provincia = gI('paciente-form-provincia');
        const canton = gI('paciente-form-canton');
        const distrito = gI('paciente-form-distrito');
        const idTipoPaciente = gI('paciente-form-tipopaciente');
        const idInstitucion = gI('paciente-form-institucion');
        const cedula = gI('paciente-form-cedula');
        const nombre = gI('paciente-form-nombre');
        const apellido1 = gI('paciente-form-apellido1');
        const apellido2 = gI('paciente-form-apellido2');
        const direccion2 = gI('paciente-form-direccion');
        const genero = gI('paciente-form-genero');
        const fechaNacimiento = gI('paciente-form-fecha');
        const descPaciente = gI('paciente-form-desc-paciente');
        const descExpediente = gI('paciente-form-desc-expediente');

        //init info
        (() => {

            function llenarProvincias(cb) {
                app.o.pjson('/paciente/lugares/provincia', {}, json => {
                    if (json) {
                        if (json.result) {
                            json.result.forEach((obj) => {
                                var op = ndom('option');
                                op.setAttribute('value', obj.idProvincia);
                                op.appendChild(ntn(obj.nombre));
                                provincia.appendChild(op);
                            });
                            if (typeof cb == 'function') {
                                cb(true);
                            }
                        } else {
                            if (typeof cb == 'function') {
                                cb(false);
                            }
                        }
                    } else {
                        if (typeof cb == 'function') {
                            cb(false);
                        }
                    }
                });
            }

            function llenarCantones(cb) {
                canton.innerHTML = '';
                app.o.pjson('/paciente/lugares/canton', { idProvincia: provincia.value }, json => {
                    if (json) {
                        if (json.result) {
                            json.result.forEach(obj => {
                                var op = ndom('option');
                                op.setAttribute('value', obj.idCanton);
                                op.setAttribute('data-p', obj.idProvincia);
                                op.appendChild(ntn(obj.nombre));
                                canton.appendChild(op);
                            });
                            if (typeof cb == 'function') {
                                cb(true);
                            }
                        } else {
                            if (typeof cb == 'function') {
                                cb(false);
                            }
                        }
                    } else {
                        if (typeof cb == 'function') {
                            cb(false);
                        }
                    }

                });
            }

            function llenarDistritos(cb) {
                const d = {
                    idCanton: canton.value,
                    idProvincia: provincia.value
                };
                distrito.innerHTML = '';
                app.o.pjson('/paciente/lugares/distrito', d, json => {
                    if (json) {
                        if (json.result) {
                            json.result.forEach(obj => {
                                var op = ndom('option');
                                op.setAttribute('value', obj.idDistrito);
                                op.setAttribute('data-p', obj.idProvincia);
                                op.setAttribute('data-c', obj.idCanton);
                                op.appendChild(ntn(obj.nombre));
                                distrito.appendChild(op);
                            }); if (typeof cb == 'function') {
                                cb(true);
                            }
                        } else {
                            if (typeof cb == 'function') {
                                cb(false);
                            }
                        }
                    } else {
                        if (typeof cb == 'function') {
                            cb(false);
                        }
                    }
                });
            }

            function llenarTipoPaciente() {
                idTipoPaciente.innerHTML = '';
                app.o.pjson('/paciente/tipopaciente', {}, json => {
                    if (json) {
                        if (json.result) {
                            json.result.forEach(obj => {
                                var op = ndom('option');
                                op.setAttribute('value', obj.idTipoPaciente);
                                op.appendChild(ntn(obj.descripcion));
                                idTipoPaciente.appendChild(op);
                            });
                        }
                    }
                });
            }

            function llenarInstitucion(cb) {
                idInstitucion.innerHTML = '';
                app.o.pjson('/paciente/institucion', {}, json => {
                    if (json) {
                        if (json.result) {
                            json.result.forEach(obj => {
                                var op = ndom('option');
                                op.setAttribute('value', obj.idInstitucion);
                                op.appendChild(ntn(obj.nombreInstitucion));
                                idInstitucion.appendChild(op);
                            });
                            if (typeof cb == 'function') {
                                cb(true);
                            }
                        } else {
                            if (typeof cb == 'function') {
                                cb(false);
                            }
                        }
                    } else {
                        if (typeof cb == 'function') {
                            cb(false);
                        }
                    }
                });
            }

            (() => {

                function initInfo() {
                    var w = null;
                    if (getMode() != 'editar') {
                        w = app.o.diagW("Espere un momento");
                    }
                    if (provincia) {
                        llenarProvincias((r) => {
                            if (r && canton) {
                                llenarCantones((r) => {
                                    if (r && distrito) {
                                        llenarDistritos(r => {
                                            if (w) {
                                                w.rm();
                                            }
                                        });
                                    }
                                });
                            }
                        });
                    }
                    if (canton) {
                        provincia.addEventListener('change', () => {
                            let w = app.o.diagW("Espere un momento");
                            llenarCantones((r) => {
                                llenarDistritos(r => {
                                    w.rm();
                                    if (!r) {
                                        app.o.diagE('No se pudieron cargar los cantones');
                                    }
                                });
                            });
                        });
                    }
                    if (distrito) {
                        canton.addEventListener('change', () => {
                            let w = app.o.diagW("Espere un momento");
                            llenarDistritos(r => {
                                w.rm();
                                if (!r) {
                                    app.o.diagE('No se pudieron cargar los distritos');
                                }
                            });
                        });
                    }
                    if (idTipoPaciente) {
                        llenarTipoPaciente();
                    }
                    if (idInstitucion) {
                        llenarInstitucion();
                    }
                }

                initInfo();
            })();


            if (getMode() == 'editar') {
                const idPaciente = gI('paciente-form-id');
                const url = window.location.pathname.split('/');
                const id = url[url.length - 1];
                var w = app.o.diagW('Espere un momento');
                app.o.pjson('/paciente/readone', { idPaciente: id }, json => {
                    if (json) {
                        if (json.result) {
                            idPaciente.value = id;
                            paciente = json.result;
                            nombre.value = paciente.nombre;
                            cedula.value = paciente.cedula;
                            apellido1.value = paciente.apellido1;
                            apellido2.value = paciente.apellido2;
                            direccion2.value = paciente.direccion2;
                            genero.value = paciente.genero;
                            fechaNacimiento.value = paciente.fechaNacimiento;
                            descPaciente.value = paciente.descripcionPaciente;
                            descExpediente.value = paciente.descripcionExpediente;
                            llenarProvincias(() => {
                                provincia.value = paciente.provincia;
                                llenarCantones(() => {
                                    canton.value = paciente.canton;
                                    llenarDistritos(() => {
                                        distrito.value = paciente.distrito;
                                        llenarInstitucion(() => {
                                            idInstitucion.value = paciente.idInstitucion;
                                            w.rm();
                                        });
                                    });
                                });
                            });
                        } else {
                            w.rm();
                            var e = app.o.diagE('Error al obtener la informacion', () => {
                                window.location.href = '/paciente';
                            });
                        }
                    } else {
                        w.rm();
                    }
                });
            }



            //Ajax
            (() => {
                const btn = gI('paciente-form-buscar');

                if (btn) {
                    btn.addEventListener('click', () => {
                        var w = app.o.diagW();
                        app.o.pjson('/paciente/api', { cedula: cedula.value }, json => {
                            if (json) {
                                if (json.result) {
                                    const d = json.result[0];
                                    nombre.value = fixCamelCase(d.nombre);
                                    apellido1.value = fixCamelCase(d.apellido1);
                                    apellido2.value = fixCamelCase(d.apellido2);
                                    genero.value = d.genero;
                                    direccion2.value = d.direccion2;
                                    fechaNacimiento.value = d.fechaNaciemiento;
                                    alert(d.fechaNacimiento);
                                    provincia.value = d.provincia;
                                    llenarCantones(() => {
                                        canton.value = d.canton;
                                        llenarDistritos(() => {
                                            w.rm();
                                        });
                                    });
                                } else {
                                    app.o.diagE('No se encontro ninguna persona con esta cedula');
                                }
                            }
                        });
                    });
                }

                function fixCamelCase(val) {
                    val = val.toLowerCase();
                    var change = true;
                    var result = "";
                    for (var i = 0; i < val.length; i++) {
                        if (change) {
                            result += val.charAt(i).toUpperCase();
                            change = false;
                        } else {
                            result += val.charAt(i);
                        }
                        if (val.charAt(i) == " ") {
                            change = true;
                        }
                    }
                    return result;
                }

            })();
        })();


        btn.addEventListener('click', () => {
            aReq(!paciente, paciente);
        });

        //Actions
        function aReq(type, data) {
            //
            var vld = app.o.vld(cedula, nombre, apellido1, apellido2, provincia, canton, direccion2, distrito, genero, fechaNacimiento, descPaciente, idTipoPaciente, idInstitucion, descExpediente);
            if (vld.valid) {
                //TODO corroborar la fecha
                var form = {
                    idPaciente: data ? data.idPaciente : 0,
                    cedula: data ? data.cedula : cedula.value,
                    nombre: nombre.value,
                    apellido1: apellido1.value,
                    apellido2: apellido2.value,
                    direccion2: direccion2.value,
                    provincia: provincia.value,
                    canton: canton.value,
                    distrito: distrito.value,
                    genero: genero.value,
                    fechaNacimiento: fechaNacimiento.value,
                    descripcionPaciente: descPaciente.value,
                    idTipoPaciente: idTipoPaciente.value,
                    idInstitucion: idInstitucion.value,
                    descripcionExpediente: descExpediente.value
                };
                var r = type ? '/paciente/create' : '/paciente/update';
                var w = app.o.diagW('Espere un momento');
                app.o.pjson(r, form, json => {
                    if (json) {
                        if (json.result) {
                            var s = app.o.diagS('Se ' + (type ? 'creo' : 'modifico') + ' el paciente', () => {
                                w.rm();
                                window.location.href = '/paciente';
                                w.rm();
                            });
                        } else {
                            var e = app.o.diagE('No se pudo ' + (type ? 'crear' : 'modificar') + ' el paciente');
                        }
                    } else {
                        var e = app.o.diagE('No se pudo ' + (type ? 'crear' : 'modificar') + ' el paciente');
                        app.o.diagE('No se pudo ' + (type ? 'crear' : 'modificar') + ' el paciente');
                    }
                    w.rm();
                });
            } else {
                console.log(vld.array);
                app.o.iF(true, vld.array);
                vld.array.forEach(obj => {
                    app.o.iF(true, obj);
                });
                app.o.eM('Rellene todos los campos por favor', gI('paciente-form'));
            }
        }
    })();


    window.onbeforeunload = function (e) {
        var e = e || window.event;

        // For IE and Firefox
        if (e) {
            e.returnValue = 'Leaving the page';
        }

        // For Safari
        return 'Leaving the page';
    };

})();
