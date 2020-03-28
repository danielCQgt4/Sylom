setInterval(s, 10)
function s(t) {
    t && "object" == typeof t
        ? (t.i || (t.i = "display: flex;"), t.a || (t.a = "flex"))
        : (t = {
            i: "display: flex;",
            a: "flex"
        }),
        (z.W = screen.width),
        (z.R = z.W > 1100),
        z.R
            ? ((sylom.l.style = t.i), (z.C = !0))
            : z.C &&
            sylom.l.style.display == t.a &&
            ((z.C = !1), (sylom.l.style.display = "none"));
}
var sylom = {
    o: new x(),
    b: gI("btn-action"),
    l: gI("nav-list")
};
sylom.b.addEventListener("click", function () {
    z.R || sylom.o.tog(sylom.l, 0.5);
});

(() => {
    const rols = gN('role');
    const rol = gI('rol');
    const rolC = gI('rols-c');

    if (rols) {
        rols.forEach(o => {
            o.addEventListener('click', () => {
                const rol = o.children[0].innerHTML;
                app.o.pjson('/cambiorol', { rol }, json => {
                    window.location.pathname = '/';
                });
            });
        });
    }

    if (rol) {
        rol.addEventListener('click', () => {
            if (rolC) {
                app.o.tog(rolC);
            }
        });
    }

})();