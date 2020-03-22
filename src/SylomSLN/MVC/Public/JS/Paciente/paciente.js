(function () {
    const pathM = window.location.pathname;
    switch (pathM) {
        case '/paciente':
            (function () {
                var btnAdd = gI('paciente-btn-add') || null;
                if (btnAdd) {
                    btnAdd.addEventListener('click', () => {
                        window.location.href = "/paciente/crear";
                    });
                }
            })();
            break;
        default:
            window.location.href = '/paciente';
    }

    app.o.pjson('/paciente/temp', { key: 'value' }, (json) => {
        console.log(json);
    });
})();