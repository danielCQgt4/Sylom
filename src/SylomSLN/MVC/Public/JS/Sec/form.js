(() => {

    document.addEventListener("DOMContentLoaded", function (event) {
        const ui = gI('/seguridad');
        if (ui) {
            ui.className += ' cyc-nav-item-active';
        }
    });

    function getMode() {
        const uraw = window.location.pathname;
        const rde = uraw.split('/');
        return rde[3] || null;
    }

    //Init
    (() => {
        const ex = gN('seguridad-dp-select');
        for (var i = 0; i < ex.length; i++) {
            ex[i].addEventListener('click', () => {
                window.location.href = '/seguridad';
            });
        }

    })();

    (() => {
        const apartados = [];
        const usuarios = [];
        const rolApartados = [];
        const rolUsuarios = [];
        const msg = gI('seguridad-msg');
        const ms = gI('to-msg');
        const action = gI('btn-action');
        const id = gI('seguridad-form-id');
        const desc = gI('seguridad-form-desc');
        const tableApart = gI('seguridad-table-apart');
        const tableUser = gI('seguridad-table-user');
        const addApart = gI('seguridad-form-btn-addApart');
        const addUser = gI('seguridad-form-btn-addUser');

        //Init  data
        (() => {
            var w = app.o.diagW();

            (() => {
                initApartados(r => {
                    if (r) {
                        initUsuarios(r => {
                            if (!r) {
                                err();
                            }
                        });
                    } else {
                        err();
                    }
                    w.rm();
                    function err() {
                        app.o.diagE('No se pudo cargar la informacion necesaria.\nSera redirigid@ a la pagina principal', () => {
                            window.location.href = '/seguridad';
                        });
                    }
                });
            })();

            function initApartados(cb) {
                app.o.pjson('/seguridad/apartado/read', null, json => {
                    if (json.result) {
                        json.result.forEach(o => {
                            apartados.push(o);
                        });
                    }
                    cb(json.result);
                });
            }

            function initUsuarios(cb) {
                app.o.pjson('/seguridad/usuario/read', null, json => {
                    if (json.result) {
                        json.result.forEach(o => {
                            usuarios.push(o);
                        });
                    }
                    cb(json.result);
                });
            }

        })();

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
                const vld = app.o.vld(desc);
                app.o.iF(false, desc);
                if (vld.valid) {
                    if (rolApartados.length > 0 && rolUsuarios.length > 0) {
                        var w = app.o.diagW();
                        console.log(rolApartados, rolUsuarios, desc);
                        w.rm();
                    } else {
                        app.o.eM('Agregra un apartado o un usuario', ms);
                    }
                } else {
                    app.o.eM('Completa todos los campos', ms);
                    app.o.iF(true, desc);
                }
            });
        }

        //Apartados
        (() => {
            //Control diag apartados
            (() => {

                function calcNoLoaded() {
                    const arr = [];
                    var add = false;
                    apartados.forEach(o => {
                        add = true;
                        rolApartados.forEach(ob => {
                            if (ob.idApartado == o.idApartado) {
                                add = false;
                            }
                        });
                        if (add) {
                            arr.push(o);
                        }
                    });
                    return arr;
                }

                function newDgApart() {
                    const o = {};
                    const dg = ndom();
                    dg.setAttribute('id', 'diag-apart');
                    dg.setAttribute('class', 'diag-back');
                    const dgApart = ndom();
                    dgApart.setAttribute('class', 'diag-apartado-rol');
                    dg.appendChild(dgApart);
                    (() => {
                        const dTop = ndom();
                        dgApart.appendChild(dTop);
                        const title = ndom('h3');
                        title.appendChild(ntn('Apartados'));
                        dTop.appendChild(title);
                        const hr = ndom('hr');
                        dTop.appendChild(hr);
                    })();
                    (() => {
                        const mid = ndom();
                        mid.setAttribute('class', 'form-group');
                        dgApart.appendChild(mid);
                        const subMid = ndom('h4');
                        subMid.appendChild(ntn('Selecciona un apartado'));
                        subMid.setAttribute('class', 'mb-3');
                        mid.appendChild(subMid);
                        const lblMid = ndom('label');
                        lblMid.setAttribute('class', 'form-check-label mb-2');
                        lblMid.appendChild(ntn('Nombre del rol'));
                        mid.appendChild(lblMid);
                        const aparts = ndom('select');
                        aparts.setAttribute('class', 'form-control');
                        mid.appendChild(aparts);
                        const arr = calcNoLoaded();
                        arr.forEach(obj => {
                            const op = ndom('option');
                            op.setAttribute('value', obj.idApartado);
                            op.appendChild(ntn(obj.nombreApartado));
                            aparts.appendChild(op);
                        });
                        (() => {
                            o.idApartado = aparts.value;
                            for (var i = 0; i < arr.length; i++) {
                                const ob = arr[i];
                                if (ob.idApartado == o.idApartado) {
                                    o.nombreApartado = ob.nombreApartado;
                                    break;
                                }
                            }
                        })();
                        aparts.addEventListener('change', () => {
                            o.idApartado = aparts.value;
                            for (var i = 0; i < arr.length; i++) {
                                const ob = arr[i];
                                if (ob.idApartado == o.idApartado) {
                                    o.nombreApartado = ob.nombreApartado;
                                    break;
                                }
                            }
                        });
                    })();
                    (() => {
                        const mid2 = ndom();
                        dgApart.appendChild(mid2);
                        const h3 = ndom('h3');
                        h3.appendChild(ntn('Permisos'));
                        mid2.appendChild(h3);
                        const hr = ndom('hr');
                        mid2.appendChild(hr);
                    })();
                    const mid3 = ndom();
                    (() => {
                        mid3.setAttribute('class', 'form-group');
                        dgApart.appendChild(mid3);
                        const subMid3 = ndom('h4');
                        subMid3.appendChild(ntn('Selecciona los permisos'));
                        subMid3.setAttribute('class', 'mb-3');
                        mid3.appendChild(subMid3);

                        const permisos = ndom();
                        permisos.setAttribute('class', 'd-flex flex-column p-2');

                        function newRPermisos(text) {
                            const row = ndom();
                            row.setAttribute('class', 'd-flex justify-content-between');
                            permisos.appendChild(row);
                            const createLbl = ndom();
                            row.appendChild(createLbl);
                            const lbl = ndom('p');
                            lbl.appendChild(ntn(text));
                            createLbl.appendChild(lbl);
                            const action = ndom();
                            action.setAttribute('class', 'diag-permiso-no');
                            action.appendChild(ntn('NO'));
                            row.appendChild(action);
                            const sep = ndom('hr');
                            permisos.appendChild(sep);
                            return action;
                        }

                        function toglePermisos(row) {
                            var cls = row.className;
                            row.innerHTML = '';
                            if (cls == 'diag-permiso-no') {
                                row.className = 'diag-permiso-yes';
                                row.appendChild(ntn('SI'));
                            } else {
                                row.className = 'diag-permiso-no';
                                row.appendChild(ntn('NO'));
                            }
                            return cls == 'diag-permiso-no';
                        }
                        (() => {
                            o.create = false;
                            o.read = false;
                            o.update = false;
                            o.del = false;
                        })();

                        //Create
                        var create = newRPermisos('Permiso de escritura:');
                        create.addEventListener('click', () => {
                            var r = toglePermisos(create);
                            o.create = r;
                        });
                        //Read
                        var read = newRPermisos('Permiso de lectura:');
                        read.addEventListener('click', () => {
                            var r = toglePermisos(read);
                            o.read = r;
                        });
                        //Update
                        var update = newRPermisos('Permiso de modificacion:');
                        update.addEventListener('click', () => {
                            var r = toglePermisos(update);
                            o.update = r;
                        });
                        //Delete
                        var del = newRPermisos('Permiso de eliminacion:');
                        del.addEventListener('click', () => {
                            var r = toglePermisos(del);
                            o.del = r;
                        });

                        mid3.appendChild(permisos);
                    })();
                    const br = ndom('br');
                    dgApart.appendChild(br);
                    (() => {
                        const bot = ndom();
                        bot.setAttribute('class', 'd-flex flex-column mb-4');
                        dgApart.appendChild(bot);
                        const accept = ndom('button');
                        accept.setAttribute('class', 'btn btn-block cyc-btn-success-2');
                        accept.appendChild(ntn('Confirmar'));
                        bot.appendChild(accept);
                        accept.addEventListener('click', () => {
                            if (o.create && o.read && o.update && o.del) {
                                (dg.setAttribute('class', 'diag-back-close'),
                                    setTimeout(() => {
                                        rolApartados.push(o);
                                        fillApartados();
                                        rmM(dg.id);
                                    }, 400)
                                );
                            } else {
                                app.o.eM('Selecciona un permiso', mid3);
                            }
                        });

                        const exit = ndom('button');
                        exit.setAttribute('class', 'btn btn-block cyc-btn-danger-2');
                        exit.appendChild(ntn('Salir'));
                        bot.appendChild(exit);

                        exit.addEventListener('click', () => {
                            (dg.setAttribute('class', 'diag-back-close'),
                                setTimeout(() => {
                                    rmM(dg.id);
                                }, 400)
                            );
                        });
                    })();
                    msg.appendChild(dg);
                }

                if (addApart) {
                    addApart.addEventListener('click', () => {
                        newDgApart();
                    });
                }
            })();

            //Control table apartados
            function newRApartados(data) {
                function nC(p, t) {
                    const div = ndom();
                    div.setAttribute('class', t ? 'yes' : 'no');
                    p.appendChild(div);
                }

                const row = ndom('tr');
                row.setAttribute('id', data.idApartado);
                const td1 = ndom('td');
                td1.appendChild(ntn(data.nombreApartado));
                const td2 = ndom('td');
                nC(td2, data.create);
                const td3 = ndom('td');
                nC(td3, data.read);
                const td4 = ndom('td');
                nC(td4, data.update);
                const td5 = ndom('td');
                nC(td5, data.del);
                const td6 = ndom('td');
                const e = ndom('i');
                e.setAttribute('class', 'far fa-times-circle cursor-pointer');
                td6.appendChild(e);
                e.addEventListener('click', () => {
                    rmM(row.id);
                    var temp = rolApartados.filter(obj => {
                        return obj != data;
                    });
                    rolApartados.length = 0;
                    temp.forEach(ob => {
                        rolApartados.push(ob);
                    });
                    console.log(rolApartados);
                });

                row.appendChild(td1);
                row.appendChild(td2);
                row.appendChild(td3);
                row.appendChild(td4);
                row.appendChild(td5);
                row.appendChild(td6);
                return row;
            }

            function fillApartados() {
                tableApart.innerHTML = '';
                rolApartados.forEach(o => {
                    const ap = newRApartados(o);
                    tableApart.appendChild(ap);
                });
            }
        })();

        //Usuarios
        (() => {

            function calcNoLoaded() {
                const arr = [];
                var add = false;
                usuarios.forEach(o => {
                    add = true;
                    rolUsuarios.forEach(ob => {
                        if (ob.idUsuario == o.idUsuario) {
                            add = false;
                        }
                    });
                    if (add) {
                        arr.push(o);
                    }
                });
                return arr;
            }

            (() => {
                function newDiagUser() {
                    const o = {};
                    const dg = ndom();
                    dg.setAttribute('id', 'diag-user');
                    dg.setAttribute('class', 'diag-back');
                    const userDiag = ndom();
                    userDiag.setAttribute('class', 'diag-user');
                    dg.appendChild(userDiag);
                    const title = ndom('h3');
                    title.appendChild(ntn('Usuario'));
                    userDiag.appendChild(title);
                    const hr = ndom('hr');
                    userDiag.appendChild(hr);
                    const f = ndom();
                    f.setAttribute('class', 'form-group');
                    userDiag.appendChild(f);
                    const lbl = ndom('label');
                    lbl.appendChild(ntn('Ingrese un nombre'));
                    f.appendChild(lbl);
                    const divR = ndom();
                    divR.setAttribute('class', 'user-diag-div-rel');
                    f.appendChild(divR);
                    const input = ndom('input');
                    input.setAttribute('class', 'form-control');
                    input.setAttribute('placeholder', 'Ingrese un nombre de un usuario');
                    divR.appendChild(input);
                    const divResults = ndom();
                    divResults.setAttribute('class', 'div-diag-div-results');
                    divResults.style = 'display:none;';
                    divR.appendChild(divResults);
                    input.addEventListener('focus', () => {
                        if (divResults.style.display == 'none') {
                            app.o.tog(divResults);
                        }
                    });
                    input.addEventListener('blur', () => {
                        if (divResults.style.display != 'none') {
                            app.o.tog(divResults);
                        }
                    });
                    //Load users
                    input.addEventListener('keyup', () => {
                        const users = calcNoLoaded();
                        divResults.innerHTML = '';
                        users.forEach(obj => {
                            if (obj.nombre.includes(input.value)) {
                                const dUser = ndom();
                                dUser.setAttribute('class', 'p-2 diag-results-user');
                                dUser.appendChild(ntn(obj.nombre));
                                divResults.appendChild(dUser);
                                dUser.addEventListener('click', () => {
                                    o.idUsuario = obj.idUsuario;
                                    o.nombre = obj.nombre;
                                    input.value = obj.nombre;
                                    if (divResults.style.display != 'none') {
                                        app.o.tog(divResults);
                                    }
                                });
                            }
                        });
                    });
                    const bot = ndom();
                    bot.setAttribute('class', 'd-flex flex-column mb-4');
                    userDiag.appendChild(bot);
                    const accept = ndom('button');
                    accept.setAttribute('class', 'btn btn-block cyc-btn-success-2');
                    accept.appendChild(ntn('Confirmar'));
                    bot.appendChild(accept);
                    accept.addEventListener('click', () => {
                        if (o.idUsuario && o.nombre) {
                            (dg.setAttribute('class', 'diag-back-close'),
                                setTimeout(() => {
                                    rolUsuarios.push(o);
                                    fillUsuarios();
                                    rmM(dg.id);
                                }, 400)
                            );
                        } else {
                            app.o.eM('Selecciona un usuario', userDiag);
                        }
                    });

                    const exit = ndom('button');
                    exit.setAttribute('class', 'btn btn-block cyc-btn-danger-2');
                    exit.appendChild(ntn('Salir'));
                    bot.appendChild(exit);

                    exit.addEventListener('click', () => {
                        (dg.setAttribute('class', 'diag-back-close'),
                            setTimeout(() => {
                                rmM(dg.id);
                            }, 400)
                        );
                    });


                    msg.appendChild(dg);
                }

                if (addUser) {
                    addUser.addEventListener('click', () => {
                        newDiagUser();
                    });
                }
            })();

            function newRwUsuarios(data) {
                const row = ndom('tr');
                row.setAttribute('id', data.idUsuario);
                const td1 = ndom('td');
                td1.appendChild(ntn(data.idUsuario));
                const td2 = ndom('td');
                td2.appendChild(ntn(data.nombre));
                const td3 = ndom('td');
                const i = ndom('i');
                i.setAttribute('class', 'far fa-times-circle cursor-pointer');
                i.addEventListener('click', () => {
                    rmM(row.id);
                    var temp = rolUsuarios.filter(obj => {
                        return obj != data;
                    });
                    rolUsuarios.length = 0;
                    temp.forEach(ob => {
                        rolUsuarios.push(ob);
                    });
                });
                td3.appendChild(i);

                row.appendChild(td1);
                row.appendChild(td2);
                row.appendChild(td3);
                return row;
            }

            function fillUsuarios() {
                tableUser.innerHTML = '';
                rolUsuarios.forEach(obj => {
                    const r = newRwUsuarios(obj);
                    tableUser.appendChild(r);
                });
            }

        })();
    })();

})();