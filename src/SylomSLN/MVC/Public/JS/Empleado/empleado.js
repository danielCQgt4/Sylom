"use-strict";
(function () {
    var btnAdd = gI('empleado-btn-add');

    btnAdd.addEventListener('click', () => {
        newDgEmpleado(true);
    });

    function newRowEmpleado(data) {
        var tr = ndom('tr');
        var td1 = ndom('td');
        td1.appendChild(ntn(data.idEmpleado));
        tr.appendChild(td1);
        var td2 = ndom('td');
        td2.appendChild(ntn(data.nombre + ' ' + data.apellido1 + ' ' + data.apellido2));
        tr.appendChild(td2);
        var td3 = ndom('td');
        td3.appendChild(ntn(data.telefono == '' ? 'Sin telefono' : data.telefono));
        tr.appendChild(td3);
        var td4 = ndom('td');
        td4.appendChild(ntn(data.email == '' ? 'Sin correo' : data.email));
        tr.appendChild(td4);
        var td5 = ndom('td');
        td5.appendChild(ntn(data.descripcion));
        tr.appendChild(td5);
        var td6 = ndom('td');
        var btn1 = ndom('button');
        btn1.addEventListener('click', () => {
            newDgEmpleado(false, data);
        });
        btn1.appendChild(ntn('Modificar'));
        btn1.setAttribute('class', 'btn cyc-btn-primary-2 admin-box-body-btn-actions');
        var btn2 = ndom('button');
        btn2.addEventListener('click', () => {
            var c = app.o.diagC('Esta seguro/a que desea eliminar este dato?', (r) => {
                if (r) {

                }
                rmM(c.id);
            });
        });
        btn2.setAttribute('class', 'btn cyc-btn-danger-2 admin-box-body-btn-actions');
        btn2.appendChild(ntn('Eliminar'));
        var btn3 = ndom('button');
        btn3.setAttribute('class', 'btn cyc-btn-warning admin-box-body-btn-actions');
        btn3.appendChild(ntn('Registro'));
        td6.appendChild(btn1);
        td6.appendChild(btn2);
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
            telefono = gI('empleado-dg-telefono'),
            email = gI('empleado-dg-email'),
            salario = gI('empleado-dg-salario'),
            tipo = gI('empleado-dg-tipoempleado'),
            usuario = gI('empleado-dg-usuario'),
            contra = gI('empleado-dg-contra'),
            contraconfirm = gI('empleado-dg-contraconfirm');
        if (dg && action && action2) {
            if (type) {
                idEmpleado.value = 'Automatico';
                lblTitle.innerHTML = 'Agrega un dato';
                cedula.value = '';
                nombre.value = '';
                apellido1.value = '';
                apellido2.value = '';
                telefono.value = '';
                email.value = '';
                salario.value = '0';
                usuario.setAttribute('placeholder', 'Ingresa un usuario');
                contra.setAttribute('placeholder', 'Ingresa una contrasena');
                contraconfirm.setAttribute('placeholder', 'Repite la contrasena');
            } else {
                lblTitle.innerHTML = 'Modifica un dato';
                if (data) {
                    idEmpleado.value = data.idEmpleado;
                    cedula.value = data.cedula;
                    nombre.value = data.nombre;
                    apellido1.value = data.apellido1;
                    apellido2.value = data.apellido2;
                    telefono.value = data.telefono;
                    email.value = data.email;
                    tipo.value = data.idTipoEmpleado;
                    salario.value = data.salario;
                    usuario.setAttribute('placeholder', 'Cambia de usuario');
                    contra.setAttribute('placeholder', 'Ingresa la contrasena anterior');
                    contraconfirm.setAttribute('placeholder', 'Ingresa la contrasena nueva');
                }
            }
            usuario.value = '';
            action.innerHTML = '';
            action2.innerHTML = '';
            dg.className = dg.className.replace('d-none', '');
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
                //
            });
            action.appendChild(btnAction);
        }
    }

    function getData() {
        var table = gI('empleado-table');
        if (table) {
            app.o.p('/empleado/read', '', (json) => {
                console.log(json);
                table.innerHTML = `<tr><th>ID</th><th>Nombre completo</th><th>Telefono</th><th>Email</th><th>Tipo de empleado</th><th></th></tr>`;
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
                json.forEach(obj => {
                    var op = ndom('option');
                    op.setAttribute('value', obj.idTipoEmpleado);
                    op.appendChild(ntn(obj.descripcion));
                    tipoEmpleado.appendChild(op);
                });
            });
        }
    }

    getData();
})();