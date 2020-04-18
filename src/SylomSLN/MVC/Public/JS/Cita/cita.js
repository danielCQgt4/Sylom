(() => {

    const calendarIl = gI('calendar-items');

    //const arr = ['Event 1', 'Event 2'];
    //(() => {
    //    if (calendarIl) {
    //        arr.forEach(o => {
    //            const div = ndom();
    //            div.setAttribute('class', 'fc-event');
    //            div.appendChild(ntn(o));
    //            calendarIl.appendChild(div);
    //        });
    //    }
    //})();

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
                            if (!r) {
                                w.rm();
                                err();
                            } else {
                                w.rm();
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
                app.o.pjson('/cita/read/paciente', null, json => {
                    if (json) {
                        if (json.result) {
                            json.result.forEach(o => {
                                pacientes.push(o);
                            });
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



        // initialize the external events
        // -----------------------------------------------------------------

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
                        return paciente;
                    } else {
                        app.o.diagE('Debe escoger un paciente primero');
                    }
                }
            });

            (() => {
                const btnChoosePaciente = gI('btn-choose-paciente');
                const btnQuitPaciente = gI('btn-choose-paciente');
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
                                evtPacienteInfo.innerHTML = `<div><p><strong>Nombre</strong><br />${paciente.nombre}</p></div>`;
                                console.log(r);
                            } else {
                                if (btnChoosePaciente.style.display == 'none') {
                                    app.o.tog(btnChoosePaciente);
                                }
                                if (btnQuitPaciente.style.display != 'none') {
                                    app.o.tog(btnQuitPaciente);
                                }
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
                            if (divResult.style.display == 'none') {
                                app.o.tog(divResult);
                            }
                        });
                        inputEscoge.addEventListener('blur', () => {
                            if (divResult.style.display != 'none') {
                                app.o.tog(divResult);
                            }
                        });
                        inputEscoge.addEventListener('keyup', () => {
                            newResult({ nombre: inputEscoge.value }, divResult);
                        });
                        divEscoge.appendChild(inputEscoge);
                        divResult.setAttribute('class', 'pacientes');
                        divEscoge.appendChild(divResult);
                        function newResult(data, parent) {
                            const div = ndom();
                            const i = ndom('i');
                            i.setAttribute('class', 'fas fa-user');
                            div.appendChild(i);
                            const p = ndom('p');
                            p.appendChild(ntn(data.nombre));//OJOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOO
                            div.appendChild(p);
                            parent.appendChild(div);
                            return data;
                        }
                        /*<----->*/

                        // SHOW
                        user.appendChild(nombre);
                        user.appendChild(expediente);

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
                            return div;
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
                            cb(paciente);
                            close();
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
        }

        // initialize the calendar
        // -----------------------------------------------------------------

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