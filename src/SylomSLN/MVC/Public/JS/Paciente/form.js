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
                gI('paciente-form-nombre').setAttribute('placeholder', '');
                gI('paciente-form-apellido1').setAttribute('placeholder', '');
                gI('paciente-form-apellido2').setAttribute('placeholder', '');
            } else {

            }
        }
        initForm();
    })();



})();