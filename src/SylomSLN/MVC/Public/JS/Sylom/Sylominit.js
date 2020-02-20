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
    api: {
        l: "..."
    },
    l: gI("nav-list")
};
sylom.b.addEventListener("click", function () {
    z.R || sylom.o.tog(sylom.l, 0.5);
});