"use-strict";
(function () {

    var btnAdd = gI('empleado-btn-add');
    var tiposEmpleados = [];

    function init() {
        if (btnAdd) {
            btnAdd.addEventListener('click', () => {
                newDgEmpleado(true);
            });
        }
    }

    function newRowEmpleado(data) {
        var tr = ndom('tr');
        tr.setAttribute('id', 'tr-' + data.idEmpleado);
        var td1 = ndom('td');
        td1.appendChild(ntn(data.idEmpleado));
        tr.appendChild(td1);
        var td2 = ndom('td');
        td2.appendChild(ntn(data.nombre + ' ' + data.apellido1));//+ ' ' + data.apellido2
        tr.appendChild(td2);
        var td3 = ndom('td');
        td3.appendChild(ntn(data.telefono == '' ? 'Sin telefono' : data.telefono));
        //tr.appendChild(td3);
        var td4 = ndom('td');
        td4.appendChild(ntn(data.email == '' ? 'Sin correo' : data.email));
        tr.appendChild(td4);
        var td5 = ndom('td');
        td5.appendChild(ntn(data.descripcion));
        tr.appendChild(td5);
        var td6 = ndom('td');
        if (update) {
            var btn1 = ndom('button');
            btn1.addEventListener('click', () => {
                newDgEmpleado(false, data);
            });
            var i = ndom('i');
            i.setAttribute('class', 'fas fa-pencil-alt');
            btn1.appendChild(i);
            btn1.setAttribute('title','Modificar');
            //btn1.appendChild(ntn(''));// Modificar
            btn1.setAttribute('class', 'btn cyc-btn-primary-2 admin-box-body-btn-actions');
            td6.appendChild(btn1);
        }
        if (del) {
            var btn2 = ndom('button');
            btn2.addEventListener('click', () => {
                var c = app.o.diagC('Esta seguro/a que desea eliminar este dato?', (r) => {
                    if (r) {
                        var m = app.o.diagW("Espere un momento");
                        var d = { idEmpleado: data.idEmpleado };
                        app.o.p('/empleado/delete', app.o.jsonF(d), (json) => {
                            if (json.result) {
                                app.o.sM('El empleado ha sido eliminado', gI('empleado-msg'));
                                rmM(tr.id);
                            } else {
                                app.o.eM('El empleado no ha sido eliminado', gI('empleado-msg'));
                            }
                            m.rM();
                            //rmM(m.id);
                        });
                    }
                    rmM(c.id);
                });
            });
            btn2.setAttribute('class', 'btn cyc-btn-danger-2 admin-box-body-btn-actions');
            var i = ndom('i');
            i.setAttribute('class', 'fas fa-times');
            btn2.appendChild(i);
            btn2.setAttribute('title', 'Eliminar');
            //btn2.appendChild(ntn(''));// Eliminar
            td6.appendChild(btn2);
        }
        var btn3 = ndom('button');
        btn3.setAttribute('class', 'btn cyc-btn-warning admin-box-body-btn-actions');
        var i = ndom('i');
        i.setAttribute('class', 'fas fa-file-medical');
        btn3.appendChild(i);
        btn3.setAttribute('title', 'Ver registros');
        //btn3.appendChild(ntn('')); Registro
        td6.appendChild(btn3);
        tr.appendChild(td6);
        return tr;
    }

    function newDgEmpleado(type, data) {
        var dg = gI('empleado-dg'),
            lblTitle = gI('empleado-dg-title'),
            action = gI('empleado-dg-action'),
            action2 = gI('empleado-dg-action2'),
            idEmpleado = gI('empleado-dg-id'),
            cedula = gI('empleado-dg-cedula'),
            nombre = gI('empleado-dg-nombre'),
            apellido1 = gI('empleado-dg-apellido1'),
            apellido2 = gI('empleado-dg-apellido2'),
            fecha = gI('empleado-dg-fecha'),
            telefono = gI('empleado-dg-telefono'),
            email = gI('empleado-dg-email'),
            salario = gI('empleado-dg-salario'),
            tipo = gI('empleado-dg-tipoempleado'),
            usuario = gI('empleado-dg-usuario'),
            contra = gI('empleado-dg-contra'),
            contraconfirm = gI('empleado-dg-contraconfirm');
        var date = new Date();
        if (dg && action && action2 && lblTitle && idEmpleado && cedula && nombre && apellido1 && apellido2 && telefono && email && salario && tipo && usuario && contra && contraconfirm && fecha) {
            var em = app.o.eM('', gI('empleado-dg-bg'));
            rmM(em.id);
            app.o.reFi(cedula, nombre, apellido1, apellido2, telefono, email, salario, usuario, contra, contraconfirm);
            app.o.iF(false, cedula, nombre, apellido1, apellido2, telefono, email, salario, usuario, contra, contraconfirm);
            if (type) {
                idEmpleado.value = 'Automatico';
                lblTitle.innerHTML = 'Agrega un dato';
                fecha.value = date.toISOString().split('T')[0];
                usuario.setAttribute('placeholder', 'Ingresa un usuario');
                contra.setAttribute('placeholder', 'Ingresa una contrasena');
                contraconfirm.setAttribute('placeholder', 'Repite la contrasena');
            } else {
                lblTitle.innerHTML = 'Modifica un dato';
                if (data) {
                    if (data.fechaNacimiento) {
                        date = new Date(data.fechaNacimiento);
                    }
                    var j = -1;
                    for (var i = 0, l = tiposEmpleados.length; i < l; i++) {
                        if (tiposEmpleados[i].idTipoEmpleado == data.idTipoEmpleado) {
                            j = i;
                            break;
                        }
                    }
                    idEmpleado.value = data.idEmpleado;
                    cedula.value = data.cedula;
                    nombre.value = data.nombre;
                    apellido1.value = data.apellido1;
                    apellido2.value = data.apellido2;
                    fecha.value = date.toISOString().split('T')[0];
                    telefono.value = data.telefono;
                    email.value = data.email;
                    tipo.value = j;
                    salario.value = data.salario;
                    usuario.setAttribute('placeholder', 'Cambia de usuario');
                    contra.setAttribute('placeholder', 'Ingresa la contrasena anterior');
                    contraconfirm.setAttribute('placeholder', 'Ingresa la contrasena nueva');
                }
            }
            (function () {
                usuario.value = '';
                action.innerHTML = '';
                action2.innerHTML = '';
                dg.className = dg.className.replace('d-none', '');
            })();
            var btnCancelar = ndom('button');
            btnCancelar.setAttribute('class', 'cyc-w-100 btn cyc-btn-danger-2');
            btnCancelar.appendChild(ntn('Cancelar'));
            btnCancelar.addEventListener('click', () => {
                dg.className = dg.className.replace('d-none', '');
                dg.className += 'd-none';
            });
            action2.appendChild(btnCancelar);
            var btnAction = ndom('button');
            btnAction.setAttribute('class', 'cyc-w-100 btn cyc-btn-success-2');
            btnAction.appendChild(ntn(type ? 'Agregar' : 'Modificar'));
            btnAction.addEventListener('click', () => {
                app.o.iF(false, cedula, nombre, apellido1, apellido2, telefono, email, salario, usuario, contra, contraconfirm);
                var r = type ? '/empleado/create' : '/empleado/update';
                var d = {
                    salario: salario.value,
                    idTipoEmpleado: tiposEmpleados[tipo.value].idTipoEmpleado,
                    cedula: cedula.value,
                    fecha: fecha.value,
                    email: email.value,
                    telefono: telefono.value,
                    usuario: usuario.value,
                    contra: contra.value,
                    contra2: contraconfirm.value
                };
                if (!type) {
                    d.idEmpleado = data.idEmpleado;
                }
                var m = app.o.diagW('Espere un momento');
                var err = type ? app.o.vld(cedula, fecha, telefono, email, salario, tipo, usuario, contra, contraconfirm) : app.o.vld(cedula, fecha, telefono, email, salario, tipo);
                if (err.valid) {
                    var ac = false, msg = '';
                    if (!!usuario.value && !type) {
                        var t = app.o.vld(usuario, contra, contraconfirm);
                        if (!t.valid) {
                            app.o.iF(true, usuario, contra, contraconfirm);
                        } else {
                            ac = true;
                            if (contra.value == contraconfirm.value) {
                                msg = 'Las contras deben ser distintas';
                                ac = false;
                                app.o.iF(true, contra, contraconfirm);
                            }
                            if (usuario.value.length < 8) {
                                msg = 'La longitud minima es de 8 caracteres';
                                ac = false;
                                app.o.iF(true, usuario);
                            }
                            if (contra.value.length < 8) {
                                msg = 'La longitud minima es de 8 caracteres';
                                ac = false;
                                app.o.iF(true, contra);
                            }
                            if (contraconfirm.value.length < 8) {
                                msg = 'La longitud minima es de 8 caracteres';
                                ac = false;
                                app.o.iF(true, contraconfirm);
                            }
                        }
                        //ac = contra.value != contraconfirm.value && t.valid;
                        //msg = !ac ? 'Las contras deben ser distintas' : null;
                    } else {
                        ac = contra.value == contraconfirm.value;
                        msg = ac ? null : 'Las contras no coinciden';
                    }
                    if (ac) {
                        app.o.p(r, app.o.jsonF(d), (json) => {
                            var ms = type ? 'agregado' : 'modificado';
                            if (json.result) {
                                app.o.sM('El empleado ha sido ' + ms, gI('empleado-msg'));
                                getData();
                                dg.className = dg.className.replace('d-none', '');
                                dg.className += 'd-none';
                            } else {
                                app.o.eM('El empleado no ha sido ' + ms, gI('empleado-dg-bg'));
                            }
                            m.rm();
                            //rmM(m.id);
                        });
                    } else {
                        app.o.eM(msg, gI('empleado-dg-bg'));
                        app.o.iF(true, contra, contraconfirm);
                        //rmM(m.id);
                        m.rm();
                    }
                } else {
                    err.array.forEach(obj => {
                        app.o.iF(true, obj);
                    });
                    app.o.eM('Corrige los campos', gI('empleado-dg-bg'));
                    //rmM(m.id);
                    m.rm();
                }
            });
            action.appendChild(btnAction);
        }
    }

    function getData() {
        var table = gI('empleado-table');
        if (table) {
            app.o.p('/empleado/read', '', (json) => {
                //<th>Telefono</th>
                table.innerHTML = `<tr><th>ID</th><th>Nombre</th><th>Email</th><th>Tipo de empleado</th><th></th></tr>`;
                json.forEach(obj => {
                    var tr = newRowEmpleado(obj);
                    table.appendChild(tr);
                });
            });
        }
        var tipoEmpleado = gI('empleado-dg-tipoempleado');
        if (tipoEmpleado) {
            tipoEmpleado.innerHTML = '';
            app.o.p('/empleado/tipo/read', '', (json) => {
                var i = 0;
                json.forEach(obj => {
                    tiposEmpleados.push(obj);
                    var op = ndom('option');
                    op.setAttribute('value', i);
                    op.appendChild(ntn(obj.descripcion));
                    tipoEmpleado.appendChild(op);
                    i++;
                });
            });
        }
    }

    getData();
    init();

})();