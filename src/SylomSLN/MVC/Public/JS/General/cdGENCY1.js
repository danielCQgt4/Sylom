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
        var a = window.location.pathname;
        var r = a.split('/');
        a = '/' + r[1];
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
    (x.prototype.iF = function (e) {
        for (var i = 0, l = arguments.length; i < l; i++) {
            arguments[i].style = e ? "border: 1px solid #ff0000;" : "";
        }
        //t.style = e ? "border: 1px solid #ff0000;" : "";
    }),
    (x.prototype.diagW = function (t) {
        if (gI('dialog-wait')) {
            rmM(gI('dialog-wait'));
        }
        var e = gI("body"),
            i = ndom("div");
        i.setAttribute(
            "class",
            "dialog-error-back cyc-box-center-fixed cyc-position-relative"
        ),
            i.setAttribute("id", "dialog-wait");
        var r = ndom("div");
        r.setAttribute(
            "class",
            "dialog-error cyc-box-center-fixed cyc-position-relative"
        );
        var n = ndom("div");
        n.setAttribute("class", "dialog-error-header");
        var o = ndom("h5");
        o.setAttribute("class", "dialog-error-msg cyc-text-center"),
            o.appendChild(ntn(t));
        var s = ndom("div");
        return (
            s.setAttribute("class", "dialog-error-actions"),
            r.appendChild(n),
            r.appendChild(o),
            r.appendChild(s),
            i.appendChild(r),
            e.appendChild(i),
            i
        );
    }),
    (x.prototype.diagE = function (t, e) {
        var i = gI("body"),
            r = ndom("div");
        r.setAttribute(
            "class",
            "dialog-error-back cyc-box-center-fixed cyc-position-relative"
        ),
            r.setAttribute("id", "dialog-error");
        var n = ndom("div");
        n.setAttribute(
            "class",
            "dialog-error cyc-box-center-fixed cyc-position-relative"
        );
        var o = ndom("div");
        o.setAttribute("class", "dialog-error-header");
        var s = ndom("h5");
        s.setAttribute("class", "dialog-error-msg"), s.appendChild(ntn(t));
        var a = ndom("div"),
            d = ndom("input");
        return (
            a.setAttribute("class", "dialog-error-actions"),
            d.setAttribute("class", "cyc-btn cyc-btn-danger dialog-error-btn-accept"),
            d.setAttribute("type", "button"),
            d.setAttribute("value", "Aceptar"),
            d.addEventListener("click", function () {
                e && "function" == typeof e ? e() : rmM("dialog-error");
            }),
            a.appendChild(d),
            n.appendChild(o),
            n.appendChild(s),
            n.appendChild(a),
            r.appendChild(n),
            i.appendChild(r),
            r
        );
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
            }), ((() => {
                if (e) {
                    e = JSON.stringify(e);
                } else {
                    e = {};
                }
            })()
            ),
            r.send(e);
    }),
    (x.prototype.gjson = function (t, e, i) {
        var r = new XMLHttpRequest();
        e = JSON.stringify(e);
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
            uc: '/mantenimientos/create',
            ur: '/mantenimientos/read',
            uu: '/mantenimientos/update',
            ud: '/mantenimientos/delete'
        }
    }
}