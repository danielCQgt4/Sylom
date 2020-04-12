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
        const msg = gI('seguridad-msg');
        const action = gI('btn-action');
        const id = gI('seguridad-form-id');
        const desc = gI('seguridad-form-desc');
        const tableApart = gI('seguridad-table-apart');
        const tableUser = gI('seguridad-table-user');
        const addApart = gI('seguridad-form-btn-addApart');
        const addUser = gI('seguridad-form-btn-addUser');

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

            function newDgApart(data) {
                if (data && !data.nombreApartado) {
                    data = null;
                }
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
                    apartados.forEach(obj => {
                        const op = ndom('option');
                        op.setAttribute('value', obj.id);
                        op.appendChild(ntn(obj.nombreApartado));
                        aparts.appendChild(op);
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
                (() => {
                    const mid3 = ndom();
                    mid3.setAttribute('class', 'form-group');
                    dgApart.appendChild(mid3);
                    const subMid3 = ndom('h4');
                    subMid3.appendChild(ntn('Selecciona los permisos'));
                    subMid3.setAttribute('class', 'mb-3');
                    mid3.appendChild(subMid3);

                    const permisos = ndom();
                    permisos.setAttribute('class', 'd-flex flex-column p-2');

                    //Create
                    const create = ndom();
                    create.setAttribute('class', 'd-flex justify-content-between');
                    permisos.appendChild(create);
                    const createLbl = ndom();
                    create.appendChild(createLbl);
                    const lbl = ndom('p');
                    lbl.appendChild(ntn('Permiso de escritura:'));
                    createLbl.appendChild(lbl);
                    const action = ndom();
                    action.setAttribute('class', 'diag-permiso-no');
                    action.appendChild(ntn('NO'));
                    create.appendChild(action);
                    const sep = ndom('hr');
                    permisos.appendChild(sep);

                    //Read
                    const read = ndom();
                    read.setAttribute('class', 'd-flex justify-content-between');
                    permisos.appendChild(read);
                    const createLbl2 = ndom();
                    read.appendChild(createLbl2);
                    const lbl2 = ndom('p');
                    lbl2.appendChild(ntn('Permiso de lectura:'));
                    createLbl2.appendChild(lbl2);
                    const action2 = ndom();
                    action2.setAttribute('class', 'diag-permiso-no');
                    action2.appendChild(ntn('NO'));
                    read.appendChild(action2);
                    const sep2 = ndom('hr');
                    permisos.appendChild(sep2);

                    //Update
                    const update = ndom();
                    update.setAttribute('class', 'd-flex justify-content-between');
                    permisos.appendChild(update);
                    const createLbl3 = ndom();
                    update.appendChild(createLbl3);
                    const lbl3 = ndom('p');
                    lbl3.appendChild(ntn('Permiso de modificacion:'));
                    createLbl3.appendChild(lbl3);
                    const action3 = ndom();
                    action3.setAttribute('class', 'diag-permiso-no');
                    action3.appendChild(ntn('NO'));
                    update.appendChild(action3);
                    const sep3 = ndom('hr');
                    permisos.appendChild(sep3);

                    //Delete
                    const dele = ndom();
                    dele.setAttribute('class', 'd-flex justify-content-between');
                    permisos.appendChild(dele);
                    const createLbl4 = ndom();
                    dele.appendChild(createLbl4);
                    const lbl4 = ndom('p');
                    lbl4.appendChild(ntn('Permiso de eliminacion:'));
                    createLbl4.appendChild(lbl4);
                    const action4 = ndom();
                    action4.setAttribute('class', 'diag-permiso-no');
                    action4.appendChild(ntn('NO'));
                    dele.appendChild(action4);
                    const sep4 = ndom('hr');
                    permisos.appendChild(sep4);

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
    })();

})();