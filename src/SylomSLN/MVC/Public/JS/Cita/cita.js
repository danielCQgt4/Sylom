(() => {

    const calendarIl = gI('calendar-items');

    document.addEventListener('DOMContentLoaded', function () {
        const pacientes = [];
        const sesiones = [];
        const Calendar = FullCalendar.Calendar;
        const Draggable = FullCalendarInteraction.Draggable;
        var calendar;

        const containerEl = gI('calendar-evt');
        const calendarEl = gI('calendar-con');

        //Init
        (() => {
            (() => {
                var w = app.o.diagW();
                loadPacientes(r => {
                    if (r) {
                        loadSesiones(r => {
                            w.rm();
                            if (!r) {
                                err();
                            } else {
                                if (calendar) {
                                    calendar.addEventSource(sesiones);
                                } else {
                                    app.o.diagE('Error al mostrar la informacion de las citas');
                                }
                            }
                        });
                    } else {
                        w.rm();
                        err();
                    }
                });
                function err() {
                    app.o.diagE('Error al cargar la informacion, sera digirido al inicio', () => {
                        window.location.href = '/';
                    });
                }
            })();

            function loadPacientes(cb) {
                app.o.pjson('/cita/read/pacientes', null, json => {
                    if (json) {
                        if (json.result) {
                            json.result.forEach(o => {
                                pacientes.push(o);
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

            function loadSesiones(cb) {
                app.o.pjson('/cita/read', null, json => {
                    if (json) {
                        if (json.result) {
                            json.result.forEach(o => {
                                sesiones.push({
                                    id: o.idSesion,
                                    title: o.asunto,
                                    start: o.fecha,
                                    end: o.fecha,
                                    color: o.color,
                                    extendedProps: {
                                        hora: o.hora,
                                        idUsuario: o.idUsuario,
                                        idExpediente: o.idExpediente,
                                        notas: o.notas,
                                        sintomas: o.sintomas
                                    }
                                });
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
        })();

        //Eventos externos
        if (containerEl) {
            var paciente = {};
            new Draggable(containerEl, {
                itemSelector: '.fc-event',
                eventData: function (eventEl) {
                    //return {
                    //    id: 50000,
                    //    title: eventEl.innerText,
                    //    temp: 1000
                    //};
                    if (paciente) {
                        return {

                        };
                    } else {
                        app.o.diagE('Debe escoger un paciente primero');
                    }
                }
            });

            //Paciente control
            (() => {
                const btnChoosePaciente = gI('btn-choose-paciente');
                const btnQuitPaciente = gI('btn-quit-paciente');
                const evtPacienteInfo = gI('evt-paciente-info');

                if (btnChoosePaciente) {
                    btnChoosePaciente.addEventListener('click', () => {
                        newDGPaciente(r => {
                            if (r) {
                                if (btnChoosePaciente.style.display != 'none') {
                                    app.o.tog(btnChoosePaciente);
                                }
                                if (btnQuitPaciente.style.display == 'none') {
                                    app.o.tog(btnQuitPaciente);
                                }
                                paciente = r;
                                evtPacienteInfo.className = evtPacienteInfo.className.replace('d-none', '');
                                evtPacienteInfo.innerHTML = `<i class="fas fa-user evt-paciente"></i>
                                    <div class="evt-paciente-info"><div><p><strong>Nombre</strong><br />${paciente.nombre}</p></div></div>`;
                            } else {
                                if (btnChoosePaciente.style.display == 'none') {
                                    app.o.tog(btnChoosePaciente);
                                }
                                if (btnQuitPaciente.style.display != 'none') {
                                    app.o.tog(btnQuitPaciente);
                                }
                                evtPacienteInfo.innerHTML = '';
                                evtPacienteInfo.className = evtPacienteInfo.className.replace('d-none', '');
                                evtPacienteInfo.className += 'd-none';
                                app.o.diagE('Error al escoger el paciente, intenta mas tarde');
                            }
                        });
                    });
                }

                if (btnQuitPaciente) {
                    btnQuitPaciente.addEventListener('click', () => {
                        if (btnChoosePaciente.style.display == 'none') {
                            app.o.tog(btnChoosePaciente);
                        }
                        if (btnQuitPaciente.style.display != 'none') {
                            app.o.tog(btnQuitPaciente);
                        }
                        evtPacienteInfo.innerHTML = '';
                        evtPacienteInfo.className = evtPacienteInfo.className.replace('d-none', '');
                        evtPacienteInfo.className += 'd-none';
                        paciente = null;
                    });
                }

                function newDGPaciente(cb) {
                    var paciente = {};
                    const dg = ndom();
                    dg.setAttribute('id', 'diag-user-back');
                    dg.setAttribute('class', 'diag-back');
                    const user = ndom();
                    user.setAttribute('class', 'diag-user');
                    dg.appendChild(user);
                    //TOP
                    (() => {
                        const top = ndom();
                        const title = ndom('h3');
                        title.appendChild(ntn('Paciente'));
                        top.appendChild(title);
                        top.appendChild(ndom('hr'));
                        user.appendChild(top);
                    })();
                    //FORM
                    const form = ndom();
                    (() => {
                        form.setAttribute('class', 'form-group');
                        user.appendChild(form);
                        const lblEscoge = ndom('label');
                        lblEscoge.setAttribute('class', 'form-check-label');
                        lblEscoge.appendChild(ntn('Escoge un paciente'));
                        form.appendChild(lblEscoge);
                    })();
                    //INPUT ESCOGER
                    (() => {
                        const nombre = newFormGroup('Nombre', true);
                        const expediente = newFormGroup('Expediente', false);
                        /*-----*/
                        const divEscoge = ndom();
                        divEscoge.setAttribute('class', 'dig-user-choose');
                        form.appendChild(divEscoge);
                        const inputEscoge = ndom('input');
                        const divResult = ndom();
                        divResult.setAttribute('style', 'display:none;');
                        inputEscoge.setAttribute('class', 'form-control');
                        inputEscoge.setAttribute('type', 'text');
                        inputEscoge.setAttribute('placeholder', 'Buscar un paciente...');
                        inputEscoge.addEventListener('focus', () => {
                            divResult.innerHTML = '';
                            if (divResult.style.display == 'none') {
                                app.o.tog(divResult);
                                pacientes.forEach(o => {
                                    o.nombre = o.nombre.toLowerCase();
                                    o.apellido1 = o.apellido1.toLowerCase();
                                    o.apellido2 = o.apellido2.toLowerCase();
                                    o.descripcionExpediente = o.descripcionExpediente.toLowerCase();
                                    const v = inputEscoge.value;
                                    if (!!!v) {
                                        fillInfo();
                                    } else if (o.nombre.includes(v) || o.apellido1.includes(v) || o.apellido2.includes(v) || o.idExpediente.includes(v)) {
                                        fillInfo();
                                    }
                                    function fillInfo() {
                                        newResult({
                                            nombre: fixCamelCase(o.nombre + ' ' + o.apellido1 + ' ' + o.apellido2),
                                            idExpediente: o.idExpediente,
                                            idPaciente: o.idPaciente,
                                            descripcionExpediente: o.descripcionExpediente
                                        }, divResult);
                                    }
                                });
                            }
                        });
                        inputEscoge.addEventListener('blur', () => {
                            if (divResult.style.display != 'none') {
                                app.o.tog(divResult);
                            }
                        });
                        inputEscoge.addEventListener('keyup', () => {
                            divResult.innerHTML = '';
                            pacientes.forEach(o => {
                                o.nombre = o.nombre.toLowerCase();
                                o.apellido1 = o.apellido1.toLowerCase();
                                o.apellido2 = o.apellido2.toLowerCase();
                                o.descripcionExpediente = o.descripcionExpediente.toLowerCase();
                                const v = inputEscoge.value;
                                if (!!!v) {
                                    fillInfo();
                                } else if (o.nombre.includes(v) || o.apellido1.includes(v) || o.apellido2.includes(v) || o.descripcionExpediente.includes(v)) {
                                    fillInfo();
                                }
                                function fillInfo() {
                                    newResult({
                                        nombre: fixCamelCase(o.nombre + ' ' + o.apellido1 + ' ' + o.apellido2),
                                        idExpediente: o.idExpediente,
                                        idPaciente: o.idPaciente,
                                        descripcionExpediente: o.descripcionExpediente
                                    }, divResult);
                                }
                            });
                        });
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
                        divEscoge.appendChild(inputEscoge);
                        divResult.setAttribute('class', 'pacientes');
                        divEscoge.appendChild(divResult);
                        function newResult(data, parent) {
                            const div = ndom();
                            const i = ndom('i');
                            i.setAttribute('class', 'fas fa-user');
                            div.appendChild(i);
                            const p = ndom('p');
                            p.appendChild(ntn(data.nombre));
                            div.appendChild(p);
                            parent.appendChild(div);
                            div.addEventListener('click', () => {
                                if (divResult.style.display != 'none') {
                                    console.log(nombre);
                                    paciente = data;
                                    nombre.input.value = data.nombre;
                                    expediente.input.value = data.descripcionExpediente;
                                    app.o.tog(divResult);
                                }
                            });
                        }
                        /*<----->*/

                        // SHOW
                        user.appendChild(nombre.div);
                        user.appendChild(expediente.div);

                        function newFormGroup(lblT, type) {
                            const div = ndom();
                            div.setAttribute('class', 'form-group');
                            const lbl = ndom('lbl');
                            lbl.setAttribute('class', 'form-check-label');
                            lbl.appendChild(ntn(lblT));
                            div.appendChild(lbl);
                            const input = ndom(type ? 'input' : 'textarea');
                            input.setAttribute('class', 'form-control');
                            input.setAttribute('readonly', 'true');
                            if (type) {
                                input.setAttribute('type', 'text');
                            }
                            div.appendChild(input);
                            user.appendChild(div);
                            return {
                                input,
                                div
                            };
                        }

                    })();
                    //ACTIONS
                    (() => {
                        const div = ndom();
                        div.setAttribute('class', 'form-group');
                        const btn1 = ndom('button');
                        btn1.setAttribute('class', 'btn cyc-btn-success-2 cyc-w-100 mb-3');
                        btn1.appendChild(ntn('Escoger'));
                        btn1.addEventListener('click', () => {
                            if (paciente.idExpediente) {
                                cb(paciente);
                                close();
                            } else {
                                app.o.eM('Debes escoger un paciente', user);
                            }
                        });
                        div.appendChild(btn1);
                        const btn2 = ndom('button');
                        btn2.setAttribute('class', 'btn cyc-btn-danger-2 cyc-w-100');
                        btn2.appendChild(ntn('Cancelar'));
                        btn2.addEventListener('click', () => {
                            close();
                        });

                        function close() {
                            (dg.setAttribute('class', 'diag-back-close'),
                                setTimeout(() => {
                                    rmM(dg.id);
                                }, 400)
                            );
                        }
                        div.appendChild(btn2);
                        user.appendChild(div);
                    })();
                    gI('body').appendChild(dg);
                    return dg;
                }

            })();

            //Option control
            (() => {
                const addOption = gI('btn-add-option-sesion');

                if (addOption) {
                    addOption.addEventListener('click', () => {
                        alert('Hola');
                    });
                }
            })();
        }

        //Calendario
        if (calendarEl) {
            calendar = new Calendar(calendarEl, {
                plugins: ['interaction', 'dayGrid', 'timeGrid'],
                header: {
                    left: 'prev,next today',
                    center: 'title',
                    right: 'dayGridMonth'
                },
                locale: 'es',
                editable: false,
                droppable: true,
                drop: function (info) {
                    info.allDay = false;
                },
                eventClick: info => {
                    console.log(info.event);
                    console.log(info.event.extendedProps.temp);
                },
            });

            calendar.render();
        }

    });

})();