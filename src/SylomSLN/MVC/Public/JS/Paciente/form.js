(function () {
    var dds = gN('empleado-dp-select');
    var exit = gI('paciente-btn-exit');

    function getMode() {
        var ur = window.location.pathname;
        var r = ur.split('/');
        return r[2];
    }

    (function () {
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

    (function () {
        var paciente;

        (() => {
            if (getMode() == 'editar') {
                const idPaciente = gI('paciente-form-id');
                const url = window.location.pathname.split('/');
                const id = url[url.length - 1];
                var w = app.o.diagW('Espere un momento');
                app.o.pjson('/paciente/readone', { idPaciente: id }, json => {
                    if (json) {
                        if (json.result) {
                            idPaciente.value = id;
                            console.log(json);
                        } else {
                            var e = app.o.diagE('Error al obtener la informacion', () => {
                                window.location.href = '/paciente';
                            });
                        }
                        rmM(w.id);
                    } else {
                        rmM(w.id);
                    }
                });
            }
        })();

        const btn = gI('btn-action');
        const provincia = gI('paciente-form-provincia');
        const canton = gI('paciente-form-canton');
        const distrito = gI('paciente-form-distrito');
        const idTipoPaciente = gI('paciente-form-tipopaciente');
        const idInstitucion = gI('paciente-form-institucion');

        btn.addEventListener('click', () => {
            aReq(true);
        });

        (() => {
            var w;

            if (provincia) {
                w = app.o.diagW('Espere un momento');
                app.o.pjson('/paciente/lugares/provincia', {}, json => {
                    if (json) {
                        if (json.result) {
                            json.result.forEach((obj) => {
                                var op = ndom('option');
                                op.setAttribute('value', obj.idProvincia);
                                op.appendChild(ntn(obj.nombre));
                                provincia.appendChild(op);
                            });
                            llenarCantones(llenarDistritos);
                        }
                    }
                    rmM(w.id);
                });
            }
            if (canton) {
                provincia.addEventListener('change', () => {
                    llenarCantones(llenarDistritos);
                });
            }
            if (distrito) {
                canton.addEventListener('change', () => {
                    llenarDistritos();
                });
            }
            if (idTipoPaciente) {
                llenarTipoPaciente();
            }
            if (idInstitucion) {
                llenarInstitucion();
            }

            function llenarCantones(cb) {
                canton.innerHTML = '';
                rmM(w.id);
                w = app.o.diagW('Espere un momento');
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
                        }
                    }
                    rmM(w.id);
                    cb();
                });
            }

            function llenarDistritos() {
                const d = {
                    idCanton: canton.value,
                    idProvincia: provincia.value
                };
                distrito.innerHTML = '';
                rmM(w.id);
                w = app.o.diagW('Espere un momento');
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
                            });
                        }
                    }
                    rmM(w.id);
                });
            }

            function llenarTipoPaciente() {
                idTipoPaciente.innerHTML = '';
                rmM(w.id);
                w = app.o.diagW('Espere un momento');
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
                    rmM(w.id);
                });
            }

            function llenarInstitucion() {
                idInstitucion.innerHTML = '';
                rmM(w.id);
                w = app.o.diagW('Espere un momento');
                app.o.pjson('/paciente/institucion', {}, json => {
                    if (json) {
                        if (json.result) {
                            json.result.forEach(obj => {
                                var op = ndom('option');
                                op.setAttribute('value', obj.idInstitucion);
                                op.appendChild(ntn(obj.nombreInstitucion));
                                idInstitucion.appendChild(op);
                            });
                        }
                    }
                    rmM(w.id);
                });
            }
        })();

        function aReq(type, data) {
            const cedula = gI('paciente-form-cedula');
            const nombre = gI('paciente-form-nombre');
            const apellido1 = gI('paciente-form-apellido1');
            const apellido2 = gI('paciente-form-apellido2');
            const direccion2 = gI('paciente-form-direccion');
            const genero = gI('paciente-form-genero');
            const fechaNacimiento = gI('paciente-form-fecha');
            const descPaciente = gI('paciente-form-desc-paciente');
            const descExpediente = gI('paciente-form-desc-expediente');
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
                console.log(r);
                app.o.pjson(r, form, json => {
                    if (json) {
                        if (json.result) {
                            rmM(w.id);
                            window.location.href = '/paciente';
                        }
                    } else {
                        app.o.diagE('No se pudo ' + (type ? 'crear' : 'modificar') + ' el paciente');
                    }
                    rmM(w.id);
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

})();