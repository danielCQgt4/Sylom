(function () {
    var dds = gN('empleado-dp-select');

    function init() {
        if (dds) {
            dds.forEach(obj => {
                obj.addEventListener('click', () => {
                    window.location.href = '/paciente';
                });
            });
        }
    }

    init();
})();