var z = {
    W: screen.width,
    R: this.W > 1100,
    C: 1
},
    x = function (t) {
        null != t && (this.o = t);
    };
//Aqui va s y setTimeOut
function r(c) {
    if (c && (typeof c === 'object')) {
        const a = window.location.pathname;
        var e = gN(c.n);
        for (i = 0; i < e.length; i++) {
            if (e[i].dataset.path == a) {
                e[i].className += ' ' + c.a;
                break;
            }
        }
    } else {
        console.error("Not valid obj");
    }
}
function rmM(t) {
    if (gI(t) && t) {
        var e = gI(t);
        e.parentNode.removeChild(e);
    }
}
function nI(t) {
    var e = ndom("img");
    return t && "object" == typeof t && Object.assign(e, t), e;
}
function ndom(t) {
    return t ? document.createElement(t) : ndom("div");
}
function ntn(t) {
    return t || console.error("Not text gotted"), document.createTextNode(t);
}
function gI(t) {
    return t || console.error("Not id gotted"), document.getElementById(t);
}
function gN(t) {
    return t || console.error("Not name gotted"), document.getElementsByName(t);
}
(x.prototype.tog = function (t, e) {
    if ((null == e && (e = 1), "none" != t.style.display))
        var i = 100,
            r = setInterval(() => {
                i >= 0
                    ? ((t.style.opacity = i / 100), (i -= 1))
                    : ((t.style.display = "none"), clearInterval(r));
            }, e);
    else {
        i = 0;
        (t.style.opacity = 0), (t.style.display = "block");
        r = setInterval(() => {
            i <= 100
                ? ((t.style.opacity = i / 100), (i += 1))
                : ((t.style.display = "block"), clearInterval(r));
        }, e);
    }
}),
    ( //HERE
        (() => {
            x.prototype.diagW = function (t) {
                null == t && (t = 'Un momento');
                const {
                    db: d,
                    dbo: i,
                    dc: e
                }
                    = function (t) {
                        const d = ndom();
                        d.setAttribute('id', t.id || 'diag-gen'),
                            d.setAttribute('class', 'diag-back');
                        const i = ndom();
                        i.setAttribute('id', t.id + '-c' || 'diag-c-gen'),
                            i.setAttribute('class', 'diag-container-2'),
                            d.appendChild(i);
                        const e = ndom();
                        return e.setAttribute('class', 'diag-body-2'),
                            i.appendChild(e),
                        {
                            db: d,
                            dbo: e,
                            dc: i
                        }
                    }({
                        id: 'd-wait'
                    }),
                    n = gI('body'),
                    s = ndom();
                s.setAttribute('class', 'diag-wait'),
                    i.appendChild(s);
                const a = ndom();
                a.setAttribute('class', 'diag-wait-top');
                const o = ndom();
                o.setAttribute('class', 'diag-wait-top-inner'),
                    a.appendChild(o);
                const c = ndom();
                c.setAttribute('class', 'diag-wait-x'),
                    o.appendChild(c);
                const l = ndom();
                l.setAttribute('class', 'diag-wait-check-ltb'),
                    c.appendChild(l);
                const p = ndom();
                p.setAttribute('class', 'diag-wait-chech-lbt'),
                    c.appendChild(p);
                const r = ndom();
                r.setAttribute('class', 'diag-wait-center');
                const b = ndom('span');
                b.setAttribute('class', 'diag-wait-center-title'),
                    b.appendChild(ntn(t || 'Un momento')),
                    r.appendChild(b);
                const u = ndom();
                u.setAttribute('class', 'diag-wait-bottom');
                const m = ndom();
                return m.setAttribute('class', 'load-pg load-pg-primary'),
                    u.appendChild(m),
                    s.appendChild(a),
                    s.appendChild(r),
                    s.appendChild(u),
                    n.appendChild(d),
                {
                    db: d,
                    rm: function () {
                        e.setAttribute('class', 'diag-container-2-close'),
                            setTimeout(() => {
                                rmM(e.id),
                                    d.setAttribute('class', 'diag-back-close'),
                                    setTimeout(() => {
                                        rmM(d.id)
                                    }, 400)
                            }, 500)
                    }
                }
            }
        })()/*END*/
    ),
    (
        (() => {
            const t = (t, e) => {
                null == t && (t = {
                    type: !0
                });
                const {
                    db: n,
                    dbo: i,
                    dc: z
                }
                    = function (t) {
                        const e = ndom();
                        e.setAttribute('id', t.id || 'diag-gen'),
                            e.setAttribute('class', 'diag-back');
                        const n = ndom();
                        n.setAttribute('id', t.id + '-c' || 'diag-c-gen'),
                            n.setAttribute('class', 'diag-container'),
                            e.appendChild(n);
                        const i = ndom();
                        return i.setAttribute('class', 'diag-body'),
                            n.appendChild(i),
                        {
                            db: e,
                            dbo: i,
                            dc: n
                        }
                    }({
                        id: 'gen-se-gen'
                    });
                t.type ? (t.c = 'success', t.title || (t.title = 'Exito'), t.text || (t.text = 'La tarea fue completada'), t.btn || (t.btn = 'Ok')) : (t.c = 'error', t.title || (t.title = 'Error'), t.text || (t.text = 'Ocurrio un problema'), t.btn || (t.btn = 'Ok'));
                const c = gI('body'),
                    s = ndom();
                s.setAttribute('class', 'diag-' + t.c),
                    i.appendChild(s);
                const d = ndom();
                d.setAttribute('class', 'diag-' + t.c + '-top');
                const o = ndom();
                o.setAttribute('class', 'diag-' + t.c + '-top-inner'),
                    d.appendChild(o);
                const a = ndom();
                a.setAttribute('class', 'diag-' + t.c + '-check'),
                    o.appendChild(a);
                const r = ndom();
                r.setAttribute('class', 'diag-' + t.c + '-check-ltb'),
                    a.appendChild(r);
                const l = ndom();
                l.setAttribute('class', 'diag-' + t.c + '-chech-lbt'),
                    a.appendChild(l);
                const p = ndom();
                p.setAttribute('class', 'diag-' + t.c + '-center');
                const b = ndom('span');
                b.setAttribute('class', 'diag-' + t.c + '-center-title'),
                    b.appendChild(ntn(t.title)),
                    p.appendChild(b);
                const u = ndom('p');
                u.setAttribute('class', 'diag-' + t.c + '-center-msg'),
                    u.appendChild(ntn(t.text)),
                    p.appendChild(u);
                const g = ndom();
                g.setAttribute('class', 'diag-' + t.c + '-bottom');
                const m = ndom('button');
                return m.setAttribute('class', 'diag-' + t.c + '-btn'),
                    m.appendChild(ntn(t.btn || 'Ok')),
                    m.addEventListener('click', () => {
                        e && 'function' == typeof e ? e() : z.setAttribute('class', 'diag-container-close'),
                            setTimeout(() => {
                                rmM(z.id),
                                    n.setAttribute('class', 'diag-back-close'),
                                    setTimeout(() => {
                                        rmM(n.id)
                                    }, 400)
                            }, 500)
                    }),
                    g.appendChild(m),
                    s.appendChild(d),
                    s.appendChild(p),
                    s.appendChild(g),
                    c.appendChild(n),
                {
                    n,
                    rm: function () {
                        z.setAttribute('class', 'diag-container-close'),
                            setTimeout(() => {
                                rmM(z.id),
                                    n.setAttribute('class', 'diag-back-close'),
                                    setTimeout(() => {
                                        rmM(n.id)
                                    }, 400)
                            }, 500)
                    }
                }
            };
            x.prototype.diagE = function (e, n) {
                if (null == e) (e = {
                }).type = 0,
                    e.c = 'error',
                    e.title = 'Error',
                    e.text = 'Ocurrio un problema',
                    e.btn = 'Ok';
                else if ('string' == typeof e) {
                    const t = {
                    };
                    e.c = 'error',
                        e.title = 'Error',
                        t.text = e,
                        t.btn = 'Ok',
                        e = t
                } else 'object' != typeof e && ((e = {
                }).c = 'error', e.title = 'Error', e.text = 'Ocurrio problema', e.btn = 'Ok');
                return e.type = 0,
                    t(e, n)
            },
                x.prototype.diagS = function (e, n) {
                    if (null == e) (e = {
                    }).type = !0,
                        e.c = 'success',
                        e.title = 'Exito',
                        e.text = 'La tarea fue completada',
                        e.btn = 'Ok';
                    else if ('string' == typeof e) {
                        const t = {
                            c: 'success',
                            title: 'Exito'
                        };
                        t.text = e,
                            t.btn = 'Ok',
                            e = t
                    } else 'object' != typeof e && ((e = {
                    }).type = !0, e.c = 'success', e.title = 'Exito', e.text = 'La tarea fue completada', e.btn = 'Ok');
                    return e.type = !0,
                        t(e, n)
                }
        })()
    ),
    (x.prototype.iF = function (e) {
        for (var i = 0, l = arguments.length; i < l; i++) {
            arguments[i].style = e ? "border: 1px solid #ff0000;" : "";
        }
        //t.style = e ? "border: 1px solid #ff0000;" : "";
    }),
    (x.prototype.diagC = function (t, e) {
        var i = gI("body"),
            r = ndom("div");
        r.setAttribute(
            "class",
            "dialog-confirm-back cyc-box-center-fixed cyc-position-relative"
        ),
            r.setAttribute("id", "dialog-confirm");
        var n = ndom("div");
        n.setAttribute(
            "class",
            "dialog-confirm cyc-box-center-fixed cyc-position-relative"
        );
        var o = ndom("div");
        o.setAttribute("class", "dialog-confirm-header");
        var s = ndom("h5");
        s.setAttribute("class", "dialog-confirm-msg"), s.appendChild(ntn(t));
        var a = ndom("div"),
            d = {
                s: ndom("input"),
                n: ndom("input")
            };
        return (
            a.setAttribute("class", "dialog-confirm-actions"),
            d.s.setAttribute(
                "class",
                "cyc-btn cyc-btn-danger dialog-confirm-btn-accept"
            ),
            d.s.setAttribute("type", "button"),
            d.s.setAttribute("value", "Cancelar"),
            d.s.addEventListener("click", function () {
                e || "function" == typeof e ? e(!1) : rmM(r.id);
            }),
            d.n.setAttribute(
                "class",
                "cyc-btn cyc-btn-success dialog-confirm-btn-accept"
            ),
            d.n.setAttribute("type", "button"),
            d.n.setAttribute("value", "Aceptar"),
            d.n.addEventListener("click", function () {
                e(!0);
            }),
            a.appendChild(d.s),
            a.appendChild(d.n),
            n.appendChild(o),
            n.appendChild(s),
            n.appendChild(a),
            r.appendChild(n),
            i.appendChild(r),
            r
        );
    }),
    (x.prototype.m = function (t, e) {
        var i = ndom("div"),
            r = ndom("input");
        return (
            i.setAttribute("id", "error-msg"),
            i.setAttribute('class', 'error-msg border-r-8 pt-2 pb-2 pl-1 pr-1 mb w-100'),
            i.appendChild(ntn(t)),
            rmM(i.id),
            r.addEventListener("click", function () {
                rmM(i.id);
            }),
            r.setAttribute("class", "m-btn"),
            r.setAttribute("value", "X"),
            r.setAttribute("type", "button"),
            i.appendChild(r),
            e.insertBefore(i, e.childNodes[0]),
            i
        );
    }),
    (x.prototype.sM = function (t, e) {
        var i = this.m(t, e);
        return i.setAttribute("class", "s-msg cyc-p-1 cyc-mb"), i;
    }),
    (x.prototype.eM = function (t, e) {
        var i = this.m(t, e);
        return i.setAttribute("class", "error-msg cyc-p-1 cyc-mb"), i;
    }),
    (x.prototype.p = function (t, e, i) {
        var r = new XMLHttpRequest();
        r.open("POST", t, !0),
            r.setRequestHeader("Content-type", "application/x-www-form-urlencoded"),
            (r.onreadystatechange = function () {
                if (4 == this.readyState && 200 == this.status) {
                    var t = JSON.parse(this.responseText);
                    i(t);
                } else {
                    if ((this.status >= 400 && this.status <= 451) || 0 == this.status) {
                        i({
                            errorBC: this.status
                        });
                    }
                }
            }),
            r.send(e);
    }),
    (x.prototype.pjson = function (t, e, i) {
        var r = new XMLHttpRequest();
        if (typeof e == 'object') {
            e = JSON.stringify(e);
        } else if (typeof e != 'string') {
            console.err('The data is not a valid json, or something is wrong');
            return;
        }
        r.open("POST", t, !0),
            r.setRequestHeader("Content-type", "application/json"),
            (r.onreadystatechange = function () {
                if (4 == this.readyState && 200 == this.status) {
                    var t = JSON.parse(this.responseText);
                    i(t);
                } else {
                    if ((this.status >= 400 && this.status <= 451) || 0 == this.status) {
                        i({
                            errorBC: this.status
                        });
                    }
                }
            }),
            r.send(e);
    }),
    (x.prototype.gjson = function (t, e, i) {
        var r = new XMLHttpRequest();
        if (typeof e == 'object') {
            e = JSON.stringify(e);
        } else if (typeof e != 'string') {
            console.err('The data is not a valid json, or something is wrong');
            return;
        }
        r.open("GET", t + '?' + e, !0),
            r.setRequestHeader("Content-type", "application/json"),
            (r.onreadystatechange = function () {
                if (4 == this.readyState && 200 == this.status) {
                    var t = JSON.parse(this.responseText);
                    i(t);
                } else {
                    if ((this.status >= 400 && this.status <= 451) || 0 == this.status) {
                        i({
                            errorBC: this.status
                        });
                    }
                }
            }),
            r.send();
    }),
    (x.prototype.g = function (t, e, i) {
        var r = new XMLHttpRequest();
        r.open("GET", t + "?" + e, !0),
            (r.onreadystatechange = function () {
                if (4 == this.readyState && 200 == this.status) {
                    var t = JSON.parse(this.responseText);
                    i(t);
                } else {
                    if ((this.status >= 400 &&
                        this.status <= 451) || 0 == this.status) {
                        i({
                            errorBC: this.status
                        });
                    }
                }
            }),
            r.send();
    }),
    (x.prototype.vld = function () {
        var data;
        var arr = [];
        for (var i = 0, l = arguments.length; i < l; i++) {
            data = arguments[i];
            if (data) {
                if (typeof data == 'object') {
                    if (data.id) {
                        if (!(!!data.value)) {
                            arr.push(data);
                        }
                    }
                } else {
                    if (!(!!data)) {
                        arr.push(data);
                    }
                }
            } else {
            }
        }
        if (arr.length == 0) {
            arr = [];
        }
        return {
            valid: !(arr.length > 0),
            array: arr
        };
    }),
    (x.prototype.reFi = function () {
        var data;
        for (var i = 0, l = arguments.length; i < l; i++) {
            data = arguments[i];
            if (data) {
                if (typeof data == 'object') {
                    data.value = '';
                }
            }
        }
    }),
    (x.prototype.ro = function () {
        for (var i = 0, l = arguments.length; i < l; i++) {
            arguments[i].setAttribute('readonly', 'true');
        }
    }),
    (x.prototype.isEmail = function (e) {
        var re = /^(([^<>()\[\]\\.,;:\s@"]+(\.[^<>()\[\]\\.,;:\s@"]+)*)|(".+"))@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\])|(([a-zA-Z\-0-9]+\.)+[a-zA-Z]{2,}))$/;
        return re.test(String(e).toLowerCase());
    }),
    (x.prototype.jsonF = function (j) {
        var r = '';
        if (typeof j == 'object') {
            var k = Object.keys(j);
            var l = k.length;
            for (var i = 0; i < l; i++) {
                r += k[i] + '=' + j[k[i]];
                if (i < (l - 1)) {
                    r += '&';
                }
            }
        }
        return r;
    });
//Aqui va app
var app = {
    o: new x(),
    api: {
        mante: {
            u: '/mantenimientos',
            urc: '/mantenimientos/c',
            uru: '/mantenimientos/u',
            uc: '/mantenimientos/a/create',
            ur: '/mantenimientos/a/read',
            uro: '/mantenimientos/a/readone',
            uu: '/mantenimientos/a/update',
            ud: '/mantenimientos/a/delete'
        }
    }
}