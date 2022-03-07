!
function(e, t) {
    "use strict";
    "object" == typeof module && "object" == typeof module.exports ? module.exports = e.document ? t(e, !0) : function(e) {
        if (!e.document) throw new Error("jQuery requires a window with a document");
        return t(e)
    }: t(e)
} ("undefined" != typeof window ? window: this,
function(E, e) {
    "use strict";
    var t = [],
    C = E.document,
    r = Object.getPrototypeOf,
    s = t.slice,
    g = t.concat,
    l = t.push,
    i = t.indexOf,
    n = {},
    o = n.toString,
    v = n.hasOwnProperty,
    a = v.toString,
    u = a.call(Object),
    m = {},
    y = function(e) {
        return "function" == typeof e && "number" != typeof e.nodeType
    },
    b = function(e) {
        return null != e && e === e.window
    },
    c = {
        type: !0,
        src: !0,
        noModule: !0
    };
    function _(e, t, n) {
        var r, i = (t = t || C).createElement("script");
        if (i.text = e, n) for (r in c) n[r] && (i[r] = n[r]);
        t.head.appendChild(i).parentNode.removeChild(i)
    }
    function w(e) {
        return null == e ? e + "": "object" == typeof e || "function" == typeof e ? n[o.call(e)] || "object": typeof e
    }
    var f = "3.3.1",
    S = function(e, t) {
        return new S.fn.init(e, t)
    },
    h = /^[\s\uFEFF\xA0]+|[\s\uFEFF\xA0]+$/g;
    function p(e) {
        var t = !!e && "length" in e && e.length,
        n = w(e);
        return ! y(e) && !b(e) && ("array" === n || 0 === t || "number" == typeof t && 0 < t && t - 1 in e)
    }
    S.fn = S.prototype = {
        jquery: f,
        constructor: S,
        length: 0,
        toArray: function() {
            return s.call(this)
        },
        get: function(e) {
            return null == e ? s.call(this) : e < 0 ? this[e + this.length] : this[e]
        },
        pushStack: function(e) {
            var t = S.merge(this.constructor(), e);
            return t.prevObject = this,
            t
        },
        each: function(e) {
            return S.each(this, e)
        },
        map: function(n) {
            return this.pushStack(S.map(this,
            function(e, t) {
                return n.call(e, t, e)
            }))
        },
        slice: function() {
            return this.pushStack(s.apply(this, arguments))
        },
        first: function() {
            return this.eq(0)
        },
        last: function() {
            return this.eq( - 1)
        },
        eq: function(e) {
            var t = this.length,
            n = +e + (e < 0 ? t: 0);
            return this.pushStack(0 <= n && n < t ? [this[n]] : [])
        },
        end: function() {
            return this.prevObject || this.constructor()
        },
        push: l,
        sort: t.sort,
        splice: t.splice
    },
    S.extend = S.fn.extend = function() {
        var e, t, n, r, i, o, a = arguments[0] || {},
        s = 1,
        l = arguments.length,
        u = !1;
        for ("boolean" == typeof a && (u = a, a = arguments[s] || {},
        s++), "object" == typeof a || y(a) || (a = {}), s === l && (a = this, s--); s < l; s++) if (null != (e = arguments[s])) for (t in e) n = a[t],
        a !== (r = e[t]) && (u && r && (S.isPlainObject(r) || (i = Array.isArray(r))) ? (i ? (i = !1, o = n && Array.isArray(n) ? n: []) : o = n && S.isPlainObject(n) ? n: {},
        a[t] = S.extend(u, o, r)) : void 0 !== r && (a[t] = r));
        return a
    },
    S.extend({
        expando: "jQuery" + (f + Math.random()).replace(/\D/g, ""),
        isReady: !0,
        error: function(e) {
            throw new Error(e)
        },
        noop: function() {},
        isPlainObject: function(e) {
            var t, n;
            return ! (!e || "[object Object]" !== o.call(e)) && (!(t = r(e)) || "function" == typeof(n = v.call(t, "constructor") && t.constructor) && a.call(n) === u)
        },
        isEmptyObject: function(e) {
            var t;
            for (t in e) return ! 1;
            return ! 0
        },
        globalEval: function(e) {
            _(e)
        },
        each: function(e, t) {
            var n, r = 0;
            if (p(e)) for (n = e.length; r < n && !1 !== t.call(e[r], r, e[r]); r++);
            else for (r in e) if (!1 === t.call(e[r], r, e[r])) break;
            return e
        },
        trim: function(e) {
            return null == e ? "": (e + "").replace(h, "")
        },
        makeArray: function(e, t) {
            var n = t || [];
            return null != e && (p(Object(e)) ? S.merge(n, "string" == typeof e ? [e] : e) : l.call(n, e)),
            n
        },
        inArray: function(e, t, n) {
            return null == t ? -1 : i.call(t, e, n)
        },
        merge: function(e, t) {
            for (var n = +t.length,
            r = 0,
            i = e.length; r < n; r++) e[i++] = t[r];
            return e.length = i,
            e
        },
        grep: function(e, t, n) {
            for (var r = [], i = 0, o = e.length, a = !n; i < o; i++) ! t(e[i], i) !== a && r.push(e[i]);
            return r
        },
        map: function(e, t, n) {
            var r, i, o = 0,
            a = [];
            if (p(e)) for (r = e.length; o < r; o++) null != (i = t(e[o], o, n)) && a.push(i);
            else for (o in e) null != (i = t(e[o], o, n)) && a.push(i);
            return g.apply([], a)
        },
        guid: 1,
        support: m
    }),
    "function" == typeof Symbol && (S.fn[Symbol.iterator] = t[Symbol.iterator]),
    S.each("Boolean Number String Function Array Date RegExp Object Error Symbol".split(" "),
    function(e, t) {
        n["[object " + t + "]"] = t.toLowerCase()
    });
    var d = function(n) {
        var e, p, _, o, i, d, f, g, w, l, u, x, E, a, C, v, s, c, m, S = "sizzle" + 1 * new Date,
        y = n.document,
        T = 0,
        r = 0,
        h = ae(),
        b = ae(),
        k = ae(),
        A = function(e, t) {
            return e === t && (u = !0),
            0
        },
        D = {}.hasOwnProperty,
        t = [],
        O = t.pop,
        j = t.push,
        N = t.push,
        I = t.slice,
        L = function(e, t) {
            for (var n = 0,
            r = e.length; n < r; n++) if (e[n] === t) return n;
            return - 1
        },
        P = "checked|selected|async|autofocus|autoplay|controls|defer|disabled|hidden|ismap|loop|multiple|open|readonly|required|scoped",
        q = "[\\x20\\t\\r\\n\\f]",
        F = "(?:\\\\.|[\\w-]|[^\0-\\xa0])+",
        R = "\\[" + q + "*(" + F + ")(?:" + q + "*([*^$|!~]?=)" + q + "*(?:'((?:\\\\.|[^\\\\'])*)'|\"((?:\\\\.|[^\\\\\"])*)\"|(" + F + "))|)" + q + "*\\]",
        M = ":(" + F + ")(?:\\((('((?:\\\\.|[^\\\\'])*)'|\"((?:\\\\.|[^\\\\\"])*)\")|((?:\\\\.|[^\\\\()[\\]]|" + R + ")*)|.*)\\)|)",
        H = new RegExp(q + "+", "g"),
        B = new RegExp("^" + q + "+|((?:^|[^\\\\])(?:\\\\.)*)" + q + "+$", "g"),
        $ = new RegExp("^" + q + "*," + q + "*"),
        W = new RegExp("^" + q + "*([>+~]|" + q + ")" + q + "*"),
        U = new RegExp("=" + q + "*([^\\]'\"]*?)" + q + "*\\]", "g"),
        z = new RegExp(M),
        V = new RegExp("^" + F + "$"),
        K = {
            ID: new RegExp("^#(" + F + ")"),
            CLASS: new RegExp("^\\.(" + F + ")"),
            TAG: new RegExp("^(" + F + "|[*])"),
            ATTR: new RegExp("^" + R),
            PSEUDO: new RegExp("^" + M),
            CHILD: new RegExp("^:(only|first|last|nth|nth-last)-(child|of-type)(?:\\(" + q + "*(even|odd|(([+-]|)(\\d*)n|)" + q + "*(?:([+-]|)" + q + "*(\\d+)|))" + q + "*\\)|)", "i"),
            bool: new RegExp("^(?:" + P + ")$", "i"),
            needsContext: new RegExp("^" + q + "*[>+~]|:(even|odd|eq|gt|lt|nth|first|last)(?:\\(" + q + "*((?:-\\d)?\\d*)" + q + "*\\)|)(?=[^-]|$)", "i")
        },
        Q = /^(?:input|select|textarea|button)$/i,
        Y = /^h\d$/i,
        J = /^[^{]+\{\s*\[native \w/,
        X = /^(?:#([\w-]+)|(\w+)|\.([\w-]+))$/,
        G = /[+~]/,
        Z = new RegExp("\\\\([\\da-f]{1,6}" + q + "?|(" + q + ")|.)", "ig"),
        ee = function(e, t, n) {
            var r = "0x" + t - 65536;
            return r != r || n ? t: r < 0 ? String.fromCharCode(r + 65536) : String.fromCharCode(r >> 10 | 55296, 1023 & r | 56320)
        },
        te = /([\0-\x1f\x7f]|^-?\d)|^-$|[^\0-\x1f\x7f-\uFFFF\w-]/g,
        ne = function(e, t) {
            return t ? "\0" === e ? "�": e.slice(0, -1) + "\\" + e.charCodeAt(e.length - 1).toString(16) + " ": "\\" + e
        },
        re = function() {
            x()
        },
        ie = ye(function(e) {
            return ! 0 === e.disabled && ("form" in e || "label" in e)
        },
        {
            dir: "parentNode",
            next: "legend"
        });
        try {
            N.apply(t = I.call(y.childNodes), y.childNodes),
            t[y.childNodes.length].nodeType
        } catch(e) {
            N = {
                apply: t.length ?
                function(e, t) {
                    j.apply(e, I.call(t))
                }: function(e, t) {
                    for (var n = e.length,
                    r = 0; e[n++] = t[r++];);
                    e.length = n - 1
                }
            }
        }
        function oe(e, t, n, r) {
            var i, o, a, s, l, u, c, f = t && t.ownerDocument,
            h = t ? t.nodeType: 9;
            if (n = n || [], "string" != typeof e || !e || 1 !== h && 9 !== h && 11 !== h) return n;
            if (!r && ((t ? t.ownerDocument || t: y) !== E && x(t), t = t || E, C)) {
                if (11 !== h && (l = X.exec(e))) if (i = l[1]) {
                    if (9 === h) {
                        if (! (a = t.getElementById(i))) return n;
                        if (a.id === i) return n.push(a),
                        n
                    } else if (f && (a = f.getElementById(i)) && m(t, a) && a.id === i) return n.push(a),
                    n
                } else {
                    if (l[2]) return N.apply(n, t.getElementsByTagName(e)),
                    n;
                    if ((i = l[3]) && p.getElementsByClassName && t.getElementsByClassName) return N.apply(n, t.getElementsByClassName(i)),
                    n
                }
                if (p.qsa && !k[e + " "] && (!v || !v.test(e))) {
                    if (1 !== h) f = t,
                    c = e;
                    else if ("object" !== t.nodeName.toLowerCase()) {
                        for ((s = t.getAttribute("id")) ? s = s.replace(te, ne) : t.setAttribute("id", s = S), o = (u = d(e)).length; o--;) u[o] = "#" + s + " " + me(u[o]);
                        c = u.join(","),
                        f = G.test(e) && ge(t.parentNode) || t
                    }
                    if (c) try {
                        return N.apply(n, f.querySelectorAll(c)),
                        n
                    } catch(e) {} finally {
                        s === S && t.removeAttribute("id")
                    }
                }
            }
            return g(e.replace(B, "$1"), t, n, r)
        }
        function ae() {
            var r = [];
            return function e(t, n) {
                return r.push(t + " ") > _.cacheLength && delete e[r.shift()],
                e[t + " "] = n
            }
        }
        function se(e) {
            return e[S] = !0,
            e
        }
        function le(e) {
            var t = E.createElement("fieldset");
            try {
                return !! e(t)
            } catch(e) {
                return ! 1
            } finally {
                t.parentNode && t.parentNode.removeChild(t),
                t = null
            }
        }
        function ue(e, t) {
            for (var n = e.split("|"), r = n.length; r--;) _.attrHandle[n[r]] = t
        }
        function ce(e, t) {
            var n = t && e,
            r = n && 1 === e.nodeType && 1 === t.nodeType && e.sourceIndex - t.sourceIndex;
            if (r) return r;
            if (n) for (; n = n.nextSibling;) if (n === t) return - 1;
            return e ? 1 : -1
        }
        function fe(t) {
            return function(e) {
                return "input" === e.nodeName.toLowerCase() && e.type === t
            }
        }
        function he(n) {
            return function(e) {
                var t = e.nodeName.toLowerCase();
                return ("input" === t || "button" === t) && e.type === n
            }
        }
        function pe(t) {
            return function(e) {
                return "form" in e ? e.parentNode && !1 === e.disabled ? "label" in e ? "label" in e.parentNode ? e.parentNode.disabled === t: e.disabled === t: e.isDisabled === t || e.isDisabled !== !t && ie(e) === t: e.disabled === t: "label" in e && e.disabled === t
            }
        }
        function de(a) {
            return se(function(o) {
                return o = +o,
                se(function(e, t) {
                    for (var n, r = a([], e.length, o), i = r.length; i--;) e[n = r[i]] && (e[n] = !(t[n] = e[n]))
                })
            })
        }
        function ge(e) {
            return e && void 0 !== e.getElementsByTagName && e
        }
        for (e in p = oe.support = {},
        i = oe.isXML = function(e) {
            var t = e && (e.ownerDocument || e).documentElement;
            return !! t && "HTML" !== t.nodeName
        },
        x = oe.setDocument = function(e) {
            var t, n, r = e ? e.ownerDocument || e: y;
            return r !== E && 9 === r.nodeType && r.documentElement && (a = (E = r).documentElement, C = !i(E), y !== E && (n = E.defaultView) && n.top !== n && (n.addEventListener ? n.addEventListener("unload", re, !1) : n.attachEvent && n.attachEvent("onunload", re)), p.attributes = le(function(e) {
                return e.className = "i",
                !e.getAttribute("className")
            }), p.getElementsByTagName = le(function(e) {
                return e.appendChild(E.createComment("")),
                !e.getElementsByTagName("*").length
            }), p.getElementsByClassName = J.test(E.getElementsByClassName), p.getById = le(function(e) {
                return a.appendChild(e).id = S,
                !E.getElementsByName || !E.getElementsByName(S).length
            }), p.getById ? (_.filter.ID = function(e) {
                var t = e.replace(Z, ee);
                return function(e) {
                    return e.getAttribute("id") === t
                }
            },
            _.find.ID = function(e, t) {
                if (void 0 !== t.getElementById && C) {
                    var n = t.getElementById(e);
                    return n ? [n] : []
                }
            }) : (_.filter.ID = function(e) {
                var n = e.replace(Z, ee);
                return function(e) {
                    var t = void 0 !== e.getAttributeNode && e.getAttributeNode("id");
                    return t && t.value === n
                }
            },
            _.find.ID = function(e, t) {
                if (void 0 !== t.getElementById && C) {
                    var n, r, i, o = t.getElementById(e);
                    if (o) {
                        if ((n = o.getAttributeNode("id")) && n.value === e) return [o];
                        for (i = t.getElementsByName(e), r = 0; o = i[r++];) if ((n = o.getAttributeNode("id")) && n.value === e) return [o]
                    }
                    return []
                }
            }), _.find.TAG = p.getElementsByTagName ?
            function(e, t) {
                return void 0 !== t.getElementsByTagName ? t.getElementsByTagName(e) : p.qsa ? t.querySelectorAll(e) : void 0
            }: function(e, t) {
                var n, r = [],
                i = 0,
                o = t.getElementsByTagName(e);
                if ("*" === e) {
                    for (; n = o[i++];) 1 === n.nodeType && r.push(n);
                    return r
                }
                return o
            },
            _.find.CLASS = p.getElementsByClassName &&
            function(e, t) {
                if (void 0 !== t.getElementsByClassName && C) return t.getElementsByClassName(e)
            },
            s = [], v = [], (p.qsa = J.test(E.querySelectorAll)) && (le(function(e) {
                a.appendChild(e).innerHTML = "<a id='" + S + "'></a><select id='" + S + "-\r\\' msallowcapture=''><option selected=''></option></select>",
                e.querySelectorAll("[msallowcapture^='']").length && v.push("[*^$]=" + q + "*(?:''|\"\")"),
                e.querySelectorAll("[selected]").length || v.push("\\[" + q + "*(?:value|" + P + ")"),
                e.querySelectorAll("[id~=" + S + "-]").length || v.push("~="),
                e.querySelectorAll(":checked").length || v.push(":checked"),
                e.querySelectorAll("a#" + S + "+*").length || v.push(".#.+[+~]")
            }), le(function(e) {
                e.innerHTML = "<a href='' disabled='disabled'></a><select disabled='disabled'><option/></select>";
                var t = E.createElement("input");
                t.setAttribute("type", "hidden"),
                e.appendChild(t).setAttribute("name", "D"),
                e.querySelectorAll("[name=d]").length && v.push("name" + q + "*[*^$|!~]?="),
                2 !== e.querySelectorAll(":enabled").length && v.push(":enabled", ":disabled"),
                a.appendChild(e).disabled = !0,
                2 !== e.querySelectorAll(":disabled").length && v.push(":enabled", ":disabled"),
                e.querySelectorAll("*,:x"),
                v.push(",.*:")
            })), (p.matchesSelector = J.test(c = a.matches || a.webkitMatchesSelector || a.mozMatchesSelector || a.oMatchesSelector || a.msMatchesSelector)) && le(function(e) {
                p.disconnectedMatch = c.call(e, "*"),
                c.call(e, "[s!='']:x"),
                s.push("!=", M)
            }), v = v.length && new RegExp(v.join("|")), s = s.length && new RegExp(s.join("|")), t = J.test(a.compareDocumentPosition), m = t || J.test(a.contains) ?
            function(e, t) {
                var n = 9 === e.nodeType ? e.documentElement: e,
                r = t && t.parentNode;
                return e === r || !(!r || 1 !== r.nodeType || !(n.contains ? n.contains(r) : e.compareDocumentPosition && 16 & e.compareDocumentPosition(r)))
            }: function(e, t) {
                if (t) for (; t = t.parentNode;) if (t === e) return ! 0;
                return ! 1
            },
            A = t ?
            function(e, t) {
                if (e === t) return u = !0,
                0;
                var n = !e.compareDocumentPosition - !t.compareDocumentPosition;
                return n || (1 & (n = (e.ownerDocument || e) === (t.ownerDocument || t) ? e.compareDocumentPosition(t) : 1) || !p.sortDetached && t.compareDocumentPosition(e) === n ? e === E || e.ownerDocument === y && m(y, e) ? -1 : t === E || t.ownerDocument === y && m(y, t) ? 1 : l ? L(l, e) - L(l, t) : 0 : 4 & n ? -1 : 1)
            }: function(e, t) {
                if (e === t) return u = !0,
                0;
                var n, r = 0,
                i = e.parentNode,
                o = t.parentNode,
                a = [e],
                s = [t];
                if (!i || !o) return e === E ? -1 : t === E ? 1 : i ? -1 : o ? 1 : l ? L(l, e) - L(l, t) : 0;
                if (i === o) return ce(e, t);
                for (n = e; n = n.parentNode;) a.unshift(n);
                for (n = t; n = n.parentNode;) s.unshift(n);
                for (; a[r] === s[r];) r++;
                return r ? ce(a[r], s[r]) : a[r] === y ? -1 : s[r] === y ? 1 : 0
            }),
            E
        },
        oe.matches = function(e, t) {
            return oe(e, null, null, t)
        },
        oe.matchesSelector = function(e, t) {
            if ((e.ownerDocument || e) !== E && x(e), t = t.replace(U, "='$1']"), p.matchesSelector && C && !k[t + " "] && (!s || !s.test(t)) && (!v || !v.test(t))) try {
                var n = c.call(e, t);
                if (n || p.disconnectedMatch || e.document && 11 !== e.document.nodeType) return n
            } catch(e) {}
            return 0 < oe(t, E, null, [e]).length
        },
        oe.contains = function(e, t) {
            return (e.ownerDocument || e) !== E && x(e),
            m(e, t)
        },
        oe.attr = function(e, t) { (e.ownerDocument || e) !== E && x(e);
            var n = _.attrHandle[t.toLowerCase()],
            r = n && D.call(_.attrHandle, t.toLowerCase()) ? n(e, t, !C) : void 0;
            return void 0 !== r ? r: p.attributes || !C ? e.getAttribute(t) : (r = e.getAttributeNode(t)) && r.specified ? r.value: null
        },
        oe.escape = function(e) {
            return (e + "").replace(te, ne)
        },
        oe.error = function(e) {
            throw new Error("Syntax error, unrecognized expression: " + e)
        },
        oe.uniqueSort = function(e) {
            var t, n = [],
            r = 0,
            i = 0;
            if (u = !p.detectDuplicates, l = !p.sortStable && e.slice(0), e.sort(A), u) {
                for (; t = e[i++];) t === e[i] && (r = n.push(i));
                for (; r--;) e.splice(n[r], 1)
            }
            return l = null,
            e
        },
        o = oe.getText = function(e) {
            var t, n = "",
            r = 0,
            i = e.nodeType;
            if (i) {
                if (1 === i || 9 === i || 11 === i) {
                    if ("string" == typeof e.textContent) return e.textContent;
                    for (e = e.firstChild; e; e = e.nextSibling) n += o(e)
                } else if (3 === i || 4 === i) return e.nodeValue
            } else for (; t = e[r++];) n += o(t);
            return n
        },
        (_ = oe.selectors = {
            cacheLength: 50,
            createPseudo: se,
            match: K,
            attrHandle: {},
            find: {},
            relative: {
                ">": {
                    dir: "parentNode",
                    first: !0
                },
                " ": {
                    dir: "parentNode"
                },
                "+": {
                    dir: "previousSibling",
                    first: !0
                },
                "~": {
                    dir: "previousSibling"
                }
            },
            preFilter: {
                ATTR: function(e) {
                    return e[1] = e[1].replace(Z, ee),
                    e[3] = (e[3] || e[4] || e[5] || "").replace(Z, ee),
                    "~=" === e[2] && (e[3] = " " + e[3] + " "),
                    e.slice(0, 4)
                },
                CHILD: function(e) {
                    return e[1] = e[1].toLowerCase(),
                    "nth" === e[1].slice(0, 3) ? (e[3] || oe.error(e[0]), e[4] = +(e[4] ? e[5] + (e[6] || 1) : 2 * ("even" === e[3] || "odd" === e[3])), e[5] = +(e[7] + e[8] || "odd" === e[3])) : e[3] && oe.error(e[0]),
                    e
                },
                PSEUDO: function(e) {
                    var t, n = !e[6] && e[2];
                    return K.CHILD.test(e[0]) ? null: (e[3] ? e[2] = e[4] || e[5] || "": n && z.test(n) && (t = d(n, !0)) && (t = n.indexOf(")", n.length - t) - n.length) && (e[0] = e[0].slice(0, t), e[2] = n.slice(0, t)), e.slice(0, 3))
                }
            },
            filter: {
                TAG: function(e) {
                    var t = e.replace(Z, ee).toLowerCase();
                    return "*" === e ?
                    function() {
                        return ! 0
                    }: function(e) {
                        return e.nodeName && e.nodeName.toLowerCase() === t
                    }
                },
                CLASS: function(e) {
                    var t = h[e + " "];
                    return t || (t = new RegExp("(^|" + q + ")" + e + "(" + q + "|$)")) && h(e,
                    function(e) {
                        return t.test("string" == typeof e.className && e.className || void 0 !== e.getAttribute && e.getAttribute("class") || "")
                    })
                },
                ATTR: function(n, r, i) {
                    return function(e) {
                        var t = oe.attr(e, n);
                        return null == t ? "!=" === r: !r || (t += "", "=" === r ? t === i: "!=" === r ? t !== i: "^=" === r ? i && 0 === t.indexOf(i) : "*=" === r ? i && -1 < t.indexOf(i) : "$=" === r ? i && t.slice( - i.length) === i: "~=" === r ? -1 < (" " + t.replace(H, " ") + " ").indexOf(i) : "|=" === r && (t === i || t.slice(0, i.length + 1) === i + "-"))
                    }
                },
                CHILD: function(d, e, t, g, v) {
                    var m = "nth" !== d.slice(0, 3),
                    y = "last" !== d.slice( - 4),
                    b = "of-type" === e;
                    return 1 === g && 0 === v ?
                    function(e) {
                        return !! e.parentNode
                    }: function(e, t, n) {
                        var r, i, o, a, s, l, u = m !== y ? "nextSibling": "previousSibling",
                        c = e.parentNode,
                        f = b && e.nodeName.toLowerCase(),
                        h = !n && !b,
                        p = !1;
                        if (c) {
                            if (m) {
                                for (; u;) {
                                    for (a = e; a = a[u];) if (b ? a.nodeName.toLowerCase() === f: 1 === a.nodeType) return ! 1;
                                    l = u = "only" === d && !l && "nextSibling"
                                }
                                return ! 0
                            }
                            if (l = [y ? c.firstChild: c.lastChild], y && h) {
                                for (p = (s = (r = (i = (o = (a = c)[S] || (a[S] = {}))[a.uniqueID] || (o[a.uniqueID] = {}))[d] || [])[0] === T && r[1]) && r[2], a = s && c.childNodes[s]; a = ++s && a && a[u] || (p = s = 0) || l.pop();) if (1 === a.nodeType && ++p && a === e) {
                                    i[d] = [T, s, p];
                                    break
                                }
                            } else if (h && (p = s = (r = (i = (o = (a = e)[S] || (a[S] = {}))[a.uniqueID] || (o[a.uniqueID] = {}))[d] || [])[0] === T && r[1]), !1 === p) for (; (a = ++s && a && a[u] || (p = s = 0) || l.pop()) && ((b ? a.nodeName.toLowerCase() !== f: 1 !== a.nodeType) || !++p || (h && ((i = (o = a[S] || (a[S] = {}))[a.uniqueID] || (o[a.uniqueID] = {}))[d] = [T, p]), a !== e)););
                            return (p -= v) === g || p % g == 0 && 0 <= p / g
                        }
                    }
                },
                PSEUDO: function(e, o) {
                    var t, a = _.pseudos[e] || _.setFilters[e.toLowerCase()] || oe.error("unsupported pseudo: " + e);
                    return a[S] ? a(o) : 1 < a.length ? (t = [e, e, "", o], _.setFilters.hasOwnProperty(e.toLowerCase()) ? se(function(e, t) {
                        for (var n, r = a(e, o), i = r.length; i--;) e[n = L(e, r[i])] = !(t[n] = r[i])
                    }) : function(e) {
                        return a(e, 0, t)
                    }) : a
                }
            },
            pseudos: {
                not: se(function(e) {
                    var r = [],
                    i = [],
                    s = f(e.replace(B, "$1"));
                    return s[S] ? se(function(e, t, n, r) {
                        for (var i, o = s(e, null, r, []), a = e.length; a--;)(i = o[a]) && (e[a] = !(t[a] = i))
                    }) : function(e, t, n) {
                        return r[0] = e,
                        s(r, null, n, i),
                        r[0] = null,
                        !i.pop()
                    }
                }),
                has: se(function(t) {
                    return function(e) {
                        return 0 < oe(t, e).length
                    }
                }),
                contains: se(function(t) {
                    return t = t.replace(Z, ee),
                    function(e) {
                        return - 1 < (e.textContent || e.innerText || o(e)).indexOf(t)
                    }
                }),
                lang: se(function(n) {
                    return V.test(n || "") || oe.error("unsupported lang: " + n),
                    n = n.replace(Z, ee).toLowerCase(),
                    function(e) {
                        var t;
                        do {
                            if (t = C ? e.lang: e.getAttribute("xml:lang") || e.getAttribute("lang")) return (t = t.toLowerCase()) === n || 0 === t.indexOf(n + "-")
                        } while (( e = e . parentNode ) && 1 === e.nodeType);
                        return ! 1
                    }
                }),
                target: function(e) {
                    var t = n.location && n.location.hash;
                    return t && t.slice(1) === e.id
                },
                root: function(e) {
                    return e === a
                },
                focus: function(e) {
                    return e === E.activeElement && (!E.hasFocus || E.hasFocus()) && !!(e.type || e.href || ~e.tabIndex)
                },
                enabled: pe(!1),
                disabled: pe(!0),
                checked: function(e) {
                    var t = e.nodeName.toLowerCase();
                    return "input" === t && !!e.checked || "option" === t && !!e.selected
                },
                selected: function(e) {
                    return e.parentNode && e.parentNode.selectedIndex,
                    !0 === e.selected
                },
                empty: function(e) {
                    for (e = e.firstChild; e; e = e.nextSibling) if (e.nodeType < 6) return ! 1;
                    return ! 0
                },
                parent: function(e) {
                    return ! _.pseudos.empty(e)
                },
                header: function(e) {
                    return Y.test(e.nodeName)
                },
                input: function(e) {
                    return Q.test(e.nodeName)
                },
                button: function(e) {
                    var t = e.nodeName.toLowerCase();
                    return "input" === t && "button" === e.type || "button" === t
                },
                text: function(e) {
                    var t;
                    return "input" === e.nodeName.toLowerCase() && "text" === e.type && (null == (t = e.getAttribute("type")) || "text" === t.toLowerCase())
                },
                first: de(function() {
                    return [0]
                }),
                last: de(function(e, t) {
                    return [t - 1]
                }),
                eq: de(function(e, t, n) {
                    return [n < 0 ? n + t: n]
                }),
                even: de(function(e, t) {
                    for (var n = 0; n < t; n += 2) e.push(n);
                    return e
                }),
                odd: de(function(e, t) {
                    for (var n = 1; n < t; n += 2) e.push(n);
                    return e
                }),
                lt: de(function(e, t, n) {
                    for (var r = n < 0 ? n + t: n; 0 <= --r;) e.push(r);
                    return e
                }),
                gt: de(function(e, t, n) {
                    for (var r = n < 0 ? n + t: n; ++r < t;) e.push(r);
                    return e
                })
            }
        }).pseudos.nth = _.pseudos.eq, {
            radio: !0,
            checkbox: !0,
            file: !0,
            password: !0,
            image: !0
        }) _.pseudos[e] = fe(e);
        for (e in {
            submit: !0,
            reset: !0
        }) _.pseudos[e] = he(e);
        function ve() {}
        function me(e) {
            for (var t = 0,
            n = e.length,
            r = ""; t < n; t++) r += e[t].value;
            return r
        }
        function ye(s, e, t) {
            var l = e.dir,
            u = e.next,
            c = u || l,
            f = t && "parentNode" === c,
            h = r++;
            return e.first ?
            function(e, t, n) {
                for (; e = e[l];) if (1 === e.nodeType || f) return s(e, t, n);
                return ! 1
            }: function(e, t, n) {
                var r, i, o, a = [T, h];
                if (n) {
                    for (; e = e[l];) if ((1 === e.nodeType || f) && s(e, t, n)) return ! 0
                } else for (; e = e[l];) if (1 === e.nodeType || f) if (i = (o = e[S] || (e[S] = {}))[e.uniqueID] || (o[e.uniqueID] = {}), u && u === e.nodeName.toLowerCase()) e = e[l] || e;
                else {
                    if ((r = i[c]) && r[0] === T && r[1] === h) return a[2] = r[2];
                    if ((i[c] = a)[2] = s(e, t, n)) return ! 0
                }
                return ! 1
            }
        }
        function be(i) {
            return 1 < i.length ?
            function(e, t, n) {
                for (var r = i.length; r--;) if (!i[r](e, t, n)) return ! 1;
                return ! 0
            }: i[0]
        }
        function _e(e, t, n, r, i) {
            for (var o, a = [], s = 0, l = e.length, u = null != t; s < l; s++)(o = e[s]) && (n && !n(o, r, i) || (a.push(o), u && t.push(s)));
            return a
        }
        function we(p, d, g, v, m, e) {
            return v && !v[S] && (v = we(v)),
            m && !m[S] && (m = we(m, e)),
            se(function(e, t, n, r) {
                var i, o, a, s = [],
                l = [],
                u = t.length,
                c = e ||
                function(e, t, n) {
                    for (var r = 0,
                    i = t.length; r < i; r++) oe(e, t[r], n);
                    return n
                } (d || "*", n.nodeType ? [n] : n, []),
                f = !p || !e && d ? c: _e(c, s, p, n, r),
                h = g ? m || (e ? p: u || v) ? [] : t: f;
                if (g && g(f, h, n, r), v) for (i = _e(h, l), v(i, [], n, r), o = i.length; o--;)(a = i[o]) && (h[l[o]] = !(f[l[o]] = a));
                if (e) {
                    if (m || p) {
                        if (m) {
                            for (i = [], o = h.length; o--;)(a = h[o]) && i.push(f[o] = a);
                            m(null, h = [], i, r)
                        }
                        for (o = h.length; o--;)(a = h[o]) && -1 < (i = m ? L(e, a) : s[o]) && (e[i] = !(t[i] = a))
                    }
                } else h = _e(h === t ? h.splice(u, h.length) : h),
                m ? m(null, t, h, r) : N.apply(t, h)
            })
        }
        function xe(e) {
            for (var i, t, n, r = e.length,
            o = _.relative[e[0].type], a = o || _.relative[" "], s = o ? 1 : 0, l = ye(function(e) {
                return e === i
            },
            a, !0), u = ye(function(e) {
                return - 1 < L(i, e)
            },
            a, !0), c = [function(e, t, n) {
                var r = !o && (n || t !== w) || ((i = t).nodeType ? l(e, t, n) : u(e, t, n));
                return i = null,
                r
            }]; s < r; s++) if (t = _.relative[e[s].type]) c = [ye(be(c), t)];
            else {
                if ((t = _.filter[e[s].type].apply(null, e[s].matches))[S]) {
                    for (n = ++s; n < r && !_.relative[e[n].type]; n++);
                    return we(1 < s && be(c), 1 < s && me(e.slice(0, s - 1).concat({
                        value: " " === e[s - 2].type ? "*": ""
                    })).replace(B, "$1"), t, s < n && xe(e.slice(s, n)), n < r && xe(e = e.slice(n)), n < r && me(e))
                }
                c.push(t)
            }
            return be(c)
        }
        return ve.prototype = _.filters = _.pseudos,
        _.setFilters = new ve,
        d = oe.tokenize = function(e, t) {
            var n, r, i, o, a, s, l, u = b[e + " "];
            if (u) return t ? 0 : u.slice(0);
            for (a = e, s = [], l = _.preFilter; a;) {
                for (o in n && !(r = $.exec(a)) || (r && (a = a.slice(r[0].length) || a), s.push(i = [])), n = !1, (r = W.exec(a)) && (n = r.shift(), i.push({
                    value: n,
                    type: r[0].replace(B, " ")
                }), a = a.slice(n.length)), _.filter) ! (r = K[o].exec(a)) || l[o] && !(r = l[o](r)) || (n = r.shift(), i.push({
                    value: n,
                    type: o,
                    matches: r
                }), a = a.slice(n.length));
                if (!n) break
            }
            return t ? a.length: a ? oe.error(e) : b(e, s).slice(0)
        },
        f = oe.compile = function(e, t) {
            var n, v, m, y, b, r, i = [],
            o = [],
            a = k[e + " "];
            if (!a) {
                for (t || (t = d(e)), n = t.length; n--;)(a = xe(t[n]))[S] ? i.push(a) : o.push(a); (a = k(e, (v = o, y = 0 < (m = i).length, b = 0 < v.length, r = function(e, t, n, r, i) {
                    var o, a, s, l = 0,
                    u = "0",
                    c = e && [],
                    f = [],
                    h = w,
                    p = e || b && _.find.TAG("*", i),
                    d = T += null == h ? 1 : Math.random() || .1,
                    g = p.length;
                    for (i && (w = t === E || t || i); u !== g && null != (o = p[u]); u++) {
                        if (b && o) {
                            for (a = 0, t || o.ownerDocument === E || (x(o), n = !C); s = v[a++];) if (s(o, t || E, n)) {
                                r.push(o);
                                break
                            }
                            i && (T = d)
                        }
                        y && ((o = !s && o) && l--, e && c.push(o))
                    }
                    if (l += u, y && u !== l) {
                        for (a = 0; s = m[a++];) s(c, f, t, n);
                        if (e) {
                            if (0 < l) for (; u--;) c[u] || f[u] || (f[u] = O.call(r));
                            f = _e(f)
                        }
                        N.apply(r, f),
                        i && !e && 0 < f.length && 1 < l + m.length && oe.uniqueSort(r)
                    }
                    return i && (T = d, w = h),
                    c
                },
                y ? se(r) : r))).selector = e
            }
            return a
        },
        g = oe.select = function(e, t, n, r) {
            var i, o, a, s, l, u = "function" == typeof e && e,
            c = !r && d(e = u.selector || e);
            if (n = n || [], 1 === c.length) {
                if (2 < (o = c[0] = c[0].slice(0)).length && "ID" === (a = o[0]).type && 9 === t.nodeType && C && _.relative[o[1].type]) {
                    if (! (t = (_.find.ID(a.matches[0].replace(Z, ee), t) || [])[0])) return n;
                    u && (t = t.parentNode),
                    e = e.slice(o.shift().value.length)
                }
                for (i = K.needsContext.test(e) ? 0 : o.length; i--&&(a = o[i], !_.relative[s = a.type]);) if ((l = _.find[s]) && (r = l(a.matches[0].replace(Z, ee), G.test(o[0].type) && ge(t.parentNode) || t))) {
                    if (o.splice(i, 1), !(e = r.length && me(o))) return N.apply(n, r),
                    n;
                    break
                }
            }
            return (u || f(e, c))(r, t, !C, n, !t || G.test(e) && ge(t.parentNode) || t),
            n
        },
        p.sortStable = S.split("").sort(A).join("") === S,
        p.detectDuplicates = !!u,
        x(),
        p.sortDetached = le(function(e) {
            return 1 & e.compareDocumentPosition(E.createElement("fieldset"))
        }),
        le(function(e) {
            return e.innerHTML = "<a href='#'></a>",
            "#" === e.firstChild.getAttribute("href")
        }) || ue("type|href|height|width",
        function(e, t, n) {
            if (!n) return e.getAttribute(t, "type" === t.toLowerCase() ? 1 : 2)
        }),
        p.attributes && le(function(e) {
            return e.innerHTML = "<input/>",
            e.firstChild.setAttribute("value", ""),
            "" === e.firstChild.getAttribute("value")
        }) || ue("value",
        function(e, t, n) {
            if (!n && "input" === e.nodeName.toLowerCase()) return e.defaultValue
        }),
        le(function(e) {
            return null == e.getAttribute("disabled")
        }) || ue(P,
        function(e, t, n) {
            var r;
            if (!n) return ! 0 === e[t] ? t.toLowerCase() : (r = e.getAttributeNode(t)) && r.specified ? r.value: null
        }),
        oe
    } (E);
    S.find = d,
    S.expr = d.selectors,
    S.expr[":"] = S.expr.pseudos,
    S.uniqueSort = S.unique = d.uniqueSort,
    S.text = d.getText,
    S.isXMLDoc = d.isXML,
    S.contains = d.contains,
    S.escapeSelector = d.escape;
    var x = function(e, t, n) {
        for (var r = [], i = void 0 !== n; (e = e[t]) && 9 !== e.nodeType;) if (1 === e.nodeType) {
            if (i && S(e).is(n)) break;
            r.push(e)
        }
        return r
    },
    T = function(e, t) {
        for (var n = []; e; e = e.nextSibling) 1 === e.nodeType && e !== t && n.push(e);
        return n
    },
    k = S.expr.match.needsContext;
    function A(e, t) {
        return e.nodeName && e.nodeName.toLowerCase() === t.toLowerCase()
    }
    var D = /^<([a-z][^\/\0>:\x20\t\r\n\f]*)[\x20\t\r\n\f]*\/?>(?:<\/\1>|)$/i;
    function O(e, n, r) {
        return y(n) ? S.grep(e,
        function(e, t) {
            return !! n.call(e, t, e) !== r
        }) : n.nodeType ? S.grep(e,
        function(e) {
            return e === n !== r
        }) : "string" != typeof n ? S.grep(e,
        function(e) {
            return - 1 < i.call(n, e) !== r
        }) : S.filter(n, e, r)
    }
    S.filter = function(e, t, n) {
        var r = t[0];
        return n && (e = ":not(" + e + ")"),
        1 === t.length && 1 === r.nodeType ? S.find.matchesSelector(r, e) ? [r] : [] : S.find.matches(e, S.grep(t,
        function(e) {
            return 1 === e.nodeType
        }))
    },
    S.fn.extend({
        find: function(e) {
            var t, n, r = this.length,
            i = this;
            if ("string" != typeof e) return this.pushStack(S(e).filter(function() {
                for (t = 0; t < r; t++) if (S.contains(i[t], this)) return ! 0
            }));
            for (n = this.pushStack([]), t = 0; t < r; t++) S.find(e, i[t], n);
            return 1 < r ? S.uniqueSort(n) : n
        },
        filter: function(e) {
            return this.pushStack(O(this, e || [], !1))
        },
        not: function(e) {
            return this.pushStack(O(this, e || [], !0))
        },
        is: function(e) {
            return !! O(this, "string" == typeof e && k.test(e) ? S(e) : e || [], !1).length
        }
    });
    var j, N = /^(?:\s*(<[\w\W]+>)[^>]*|#([\w-]+))$/; (S.fn.init = function(e, t, n) {
        var r, i;
        if (!e) return this;
        if (n = n || j, "string" == typeof e) {
            if (! (r = "<" === e[0] && ">" === e[e.length - 1] && 3 <= e.length ? [null, e, null] : N.exec(e)) || !r[1] && t) return ! t || t.jquery ? (t || n).find(e) : this.constructor(t).find(e);
            if (r[1]) {
                if (t = t instanceof S ? t[0] : t, S.merge(this, S.parseHTML(r[1], t && t.nodeType ? t.ownerDocument || t: C, !0)), D.test(r[1]) && S.isPlainObject(t)) for (r in t) y(this[r]) ? this[r](t[r]) : this.attr(r, t[r]);
                return this
            }
            return (i = C.getElementById(r[2])) && (this[0] = i, this.length = 1),
            this
        }
        return e.nodeType ? (this[0] = e, this.length = 1, this) : y(e) ? void 0 !== n.ready ? n.ready(e) : e(S) : S.makeArray(e, this)
    }).prototype = S.fn,
    j = S(C);
    var I = /^(?:parents|prev(?:Until|All))/,
    L = {
        children: !0,
        contents: !0,
        next: !0,
        prev: !0
    };
    function P(e, t) {
        for (; (e = e[t]) && 1 !== e.nodeType;);
        return e
    }
    S.fn.extend({
        has: function(e) {
            var t = S(e, this),
            n = t.length;
            return this.filter(function() {
                for (var e = 0; e < n; e++) if (S.contains(this, t[e])) return ! 0
            })
        },
        closest: function(e, t) {
            var n, r = 0,
            i = this.length,
            o = [],
            a = "string" != typeof e && S(e);
            if (!k.test(e)) for (; r < i; r++) for (n = this[r]; n && n !== t; n = n.parentNode) if (n.nodeType < 11 && (a ? -1 < a.index(n) : 1 === n.nodeType && S.find.matchesSelector(n, e))) {
                o.push(n);
                break
            }
            return this.pushStack(1 < o.length ? S.uniqueSort(o) : o)
        },
        index: function(e) {
            return e ? "string" == typeof e ? i.call(S(e), this[0]) : i.call(this, e.jquery ? e[0] : e) : this[0] && this[0].parentNode ? this.first().prevAll().length: -1
        },
        add: function(e, t) {
            return this.pushStack(S.uniqueSort(S.merge(this.get(), S(e, t))))
        },
        addBack: function(e) {
            return this.add(null == e ? this.prevObject: this.prevObject.filter(e))
        }
    }),
    S.each({
        parent: function(e) {
            var t = e.parentNode;
            return t && 11 !== t.nodeType ? t: null
        },
        parents: function(e) {
            return x(e, "parentNode")
        },
        parentsUntil: function(e, t, n) {
            return x(e, "parentNode", n)
        },
        next: function(e) {
            return P(e, "nextSibling")
        },
        prev: function(e) {
            return P(e, "previousSibling")
        },
        nextAll: function(e) {
            return x(e, "nextSibling")
        },
        prevAll: function(e) {
            return x(e, "previousSibling")
        },
        nextUntil: function(e, t, n) {
            return x(e, "nextSibling", n)
        },
        prevUntil: function(e, t, n) {
            return x(e, "previousSibling", n)
        },
        siblings: function(e) {
            return T((e.parentNode || {}).firstChild, e)
        },
        children: function(e) {
            return T(e.firstChild)
        },
        contents: function(e) {
            return A(e, "iframe") ? e.contentDocument: (A(e, "template") && (e = e.content || e), S.merge([], e.childNodes))
        }
    },
    function(r, i) {
        S.fn[r] = function(e, t) {
            var n = S.map(this, i, e);
            return "Until" !== r.slice( - 5) && (t = e),
            t && "string" == typeof t && (n = S.filter(t, n)),
            1 < this.length && (L[r] || S.uniqueSort(n), I.test(r) && n.reverse()),
            this.pushStack(n)
        }
    });
    var q = /[^\x20\t\r\n\f]+/g;
    function F(e) {
        return e
    }
    function R(e) {
        throw e
    }
    function M(e, t, n, r) {
        var i;
        try {
            e && y(i = e.promise) ? i.call(e).done(t).fail(n) : e && y(i = e.then) ? i.call(e, t, n) : t.apply(void 0, [e].slice(r))
        } catch(e) {
            n.apply(void 0, [e])
        }
    }
    S.Callbacks = function(r) {
        var e, n;
        r = "string" == typeof r ? (e = r, n = {},
        S.each(e.match(q) || [],
        function(e, t) {
            n[t] = !0
        }), n) : S.extend({},
        r);
        var i, t, o, a, s = [],
        l = [],
        u = -1,
        c = function() {
            for (a = a || r.once, o = i = !0; l.length; u = -1) for (t = l.shift(); ++u < s.length;) ! 1 === s[u].apply(t[0], t[1]) && r.stopOnFalse && (u = s.length, t = !1);
            r.memory || (t = !1),
            i = !1,
            a && (s = t ? [] : "")
        },
        f = {
            add: function() {
                return s && (t && !i && (u = s.length - 1, l.push(t)),
                function n(e) {
                    S.each(e,
                    function(e, t) {
                        y(t) ? r.unique && f.has(t) || s.push(t) : t && t.length && "string" !== w(t) && n(t)
                    })
                } (arguments), t && !i && c()),
                this
            },
            remove: function() {
                return S.each(arguments,
                function(e, t) {
                    for (var n; - 1 < (n = S.inArray(t, s, n));) s.splice(n, 1),
                    n <= u && u--
                }),
                this
            },
            has: function(e) {
                return e ? -1 < S.inArray(e, s) : 0 < s.length
            },
            empty: function() {
                return s && (s = []),
                this
            },
            disable: function() {
                return a = l = [],
                s = t = "",
                this
            },
            disabled: function() {
                return ! s
            },
            lock: function() {
                return a = l = [],
                t || i || (s = t = ""),
                this
            },
            locked: function() {
                return !! a
            },
            fireWith: function(e, t) {
                return a || (t = [e, (t = t || []).slice ? t.slice() : t], l.push(t), i || c()),
                this
            },
            fire: function() {
                return f.fireWith(this, arguments),
                this
            },
            fired: function() {
                return !! o
            }
        };
        return f
    },
    S.extend({
        Deferred: function(e) {
            var o = [["notify", "progress", S.Callbacks("memory"), S.Callbacks("memory"), 2], ["resolve", "done", S.Callbacks("once memory"), S.Callbacks("once memory"), 0, "resolved"], ["reject", "fail", S.Callbacks("once memory"), S.Callbacks("once memory"), 1, "rejected"]],
            i = "pending",
            a = {
                state: function() {
                    return i
                },
                always: function() {
                    return s.done(arguments).fail(arguments),
                    this
                },
                catch: function(e) {
                    return a.then(null, e)
                },
                pipe: function() {
                    var i = arguments;
                    return S.Deferred(function(r) {
                        S.each(o,
                        function(e, t) {
                            var n = y(i[t[4]]) && i[t[4]];
                            s[t[1]](function() {
                                var e = n && n.apply(this, arguments);
                                e && y(e.promise) ? e.promise().progress(r.notify).done(r.resolve).fail(r.reject) : r[t[0] + "With"](this, n ? [e] : arguments)
                            })
                        }),
                        i = null
                    }).promise()
                },
                then: function(t, n, r) {
                    var l = 0;
                    function u(i, o, a, s) {
                        return function() {
                            var n = this,
                            r = arguments,
                            e = function() {
                                var e, t;
                                if (! (i < l)) {
                                    if ((e = a.apply(n, r)) === o.promise()) throw new TypeError("Thenable self-resolution");
                                    t = e && ("object" == typeof e || "function" == typeof e) && e.then,
                                    y(t) ? s ? t.call(e, u(l, o, F, s), u(l, o, R, s)) : (l++, t.call(e, u(l, o, F, s), u(l, o, R, s), u(l, o, F, o.notifyWith))) : (a !== F && (n = void 0, r = [e]), (s || o.resolveWith)(n, r))
                                }
                            },
                            t = s ? e: function() {
                                try {
                                    e()
                                } catch(e) {
                                    S.Deferred.exceptionHook && S.Deferred.exceptionHook(e, t.stackTrace),
                                    l <= i + 1 && (a !== R && (n = void 0, r = [e]), o.rejectWith(n, r))
                                }
                            };
                            i ? t() : (S.Deferred.getStackHook && (t.stackTrace = S.Deferred.getStackHook()), E.setTimeout(t))
                        }
                    }
                    return S.Deferred(function(e) {
                        o[0][3].add(u(0, e, y(r) ? r: F, e.notifyWith)),
                        o[1][3].add(u(0, e, y(t) ? t: F)),
                        o[2][3].add(u(0, e, y(n) ? n: R))
                    }).promise()
                },
                promise: function(e) {
                    return null != e ? S.extend(e, a) : a
                }
            },
            s = {};
            return S.each(o,
            function(e, t) {
                var n = t[2],
                r = t[5];
                a[t[1]] = n.add,
                r && n.add(function() {
                    i = r
                },
                o[3 - e][2].disable, o[3 - e][3].disable, o[0][2].lock, o[0][3].lock),
                n.add(t[3].fire),
                s[t[0]] = function() {
                    return s[t[0] + "With"](this === s ? void 0 : this, arguments),
                    this
                },
                s[t[0] + "With"] = n.fireWith
            }),
            a.promise(s),
            e && e.call(s, s),
            s
        },
        when: function(e) {
            var n = arguments.length,
            t = n,
            r = Array(t),
            i = s.call(arguments),
            o = S.Deferred(),
            a = function(t) {
                return function(e) {
                    r[t] = this,
                    i[t] = 1 < arguments.length ? s.call(arguments) : e,
                    --n || o.resolveWith(r, i)
                }
            };
            if (n <= 1 && (M(e, o.done(a(t)).resolve, o.reject, !n), "pending" === o.state() || y(i[t] && i[t].then))) return o.then();
            for (; t--;) M(i[t], a(t), o.reject);
            return o.promise()
        }
    });
    var H = /^(Eval|Internal|Range|Reference|Syntax|Type|URI)Error$/;
    S.Deferred.exceptionHook = function(e, t) {
        E.console && E.console.warn && e && H.test(e.name) && E.console.warn("jQuery.Deferred exception: " + e.message, e.stack, t)
    },
    S.readyException = function(e) {
        E.setTimeout(function() {
            throw e
        })
    };
    var B = S.Deferred();
    function $() {
        C.removeEventListener("DOMContentLoaded", $),
        E.removeEventListener("load", $),
        S.ready()
    }
    S.fn.ready = function(e) {
        return B.then(e).
        catch(function(e) {
            S.readyException(e)
        }),
        this
    },
    S.extend({
        isReady: !1,
        readyWait: 1,
        ready: function(e) { (!0 === e ? --S.readyWait: S.isReady) || (S.isReady = !0) !== e && 0 < --S.readyWait || B.resolveWith(C, [S])
        }
    }),
    S.ready.then = B.then,
    "complete" === C.readyState || "loading" !== C.readyState && !C.documentElement.doScroll ? E.setTimeout(S.ready) : (C.addEventListener("DOMContentLoaded", $), E.addEventListener("load", $));
    var W = function(e, t, n, r, i, o, a) {
        var s = 0,
        l = e.length,
        u = null == n;
        if ("object" === w(n)) for (s in i = !0, n) W(e, t, s, n[s], !0, o, a);
        else if (void 0 !== r && (i = !0, y(r) || (a = !0), u && (a ? (t.call(e, r), t = null) : (u = t, t = function(e, t, n) {
            return u.call(S(e), n)
        })), t)) for (; s < l; s++) t(e[s], n, a ? r: r.call(e[s], s, t(e[s], n)));
        return i ? e: u ? t.call(e) : l ? t(e[0], n) : o
    },
    U = /^-ms-/,
    z = /-([a-z])/g;
    function V(e, t) {
        return t.toUpperCase()
    }
    function K(e) {
        return e.replace(U, "ms-").replace(z, V)
    }
    var Q = function(e) {
        return 1 === e.nodeType || 9 === e.nodeType || !+e.nodeType
    };
    function Y() {
        this.expando = S.expando + Y.uid++
    }
    Y.uid = 1,
    Y.prototype = {
        cache: function(e) {
            var t = e[this.expando];
            return t || (t = {},
            Q(e) && (e.nodeType ? e[this.expando] = t: Object.defineProperty(e, this.expando, {
                value: t,
                configurable: !0
            }))),
            t
        },
        set: function(e, t, n) {
            var r, i = this.cache(e);
            if ("string" == typeof t) i[K(t)] = n;
            else for (r in t) i[K(r)] = t[r];
            return i
        },
        get: function(e, t) {
            return void 0 === t ? this.cache(e) : e[this.expando] && e[this.expando][K(t)]
        },
        access: function(e, t, n) {
            return void 0 === t || t && "string" == typeof t && void 0 === n ? this.get(e, t) : (this.set(e, t, n), void 0 !== n ? n: t)
        },
        remove: function(e, t) {
            var n, r = e[this.expando];
            if (void 0 !== r) {
                if (void 0 !== t) {
                    n = (t = Array.isArray(t) ? t.map(K) : (t = K(t)) in r ? [t] : t.match(q) || []).length;
                    for (; n--;) delete r[t[n]]
                } (void 0 === t || S.isEmptyObject(r)) && (e.nodeType ? e[this.expando] = void 0 : delete e[this.expando])
            }
        },
        hasData: function(e) {
            var t = e[this.expando];
            return void 0 !== t && !S.isEmptyObject(t)
        }
    };
    var J = new Y,
    X = new Y,
    G = /^(?:\{[\w\W]*\}|\[[\w\W]*\])$/,
    Z = /[A-Z]/g;
    function ee(e, t, n) {
        var r, i;
        if (void 0 === n && 1 === e.nodeType) if (r = "data-" + t.replace(Z, "-$&").toLowerCase(), "string" == typeof(n = e.getAttribute(r))) {
            try {
                n = "true" === (i = n) || "false" !== i && ("null" === i ? null: i === +i + "" ? +i: G.test(i) ? JSON.parse(i) : i)
            } catch(e) {}
            X.set(e, t, n)
        } else n = void 0;
        return n
    }
    S.extend({
        hasData: function(e) {
            return X.hasData(e) || J.hasData(e)
        },
        data: function(e, t, n) {
            return X.access(e, t, n)
        },
        removeData: function(e, t) {
            X.remove(e, t)
        },
        _data: function(e, t, n) {
            return J.access(e, t, n)
        },
        _removeData: function(e, t) {
            J.remove(e, t)
        }
    }),
    S.fn.extend({
        data: function(n, e) {
            var t, r, i, o = this[0],
            a = o && o.attributes;
            if (void 0 === n) {
                if (this.length && (i = X.get(o), 1 === o.nodeType && !J.get(o, "hasDataAttrs"))) {
                    for (t = a.length; t--;) a[t] && 0 === (r = a[t].name).indexOf("data-") && (r = K(r.slice(5)), ee(o, r, i[r]));
                    J.set(o, "hasDataAttrs", !0)
                }
                return i
            }
            return "object" == typeof n ? this.each(function() {
                X.set(this, n)
            }) : W(this,
            function(e) {
                var t;
                if (o && void 0 === e) return void 0 !== (t = X.get(o, n)) ? t: void 0 !== (t = ee(o, n)) ? t: void 0;
                this.each(function() {
                    X.set(this, n, e)
                })
            },
            null, e, 1 < arguments.length, null, !0)
        },
        removeData: function(e) {
            return this.each(function() {
                X.remove(this, e)
            })
        }
    }),
    S.extend({
        queue: function(e, t, n) {
            var r;
            if (e) return t = (t || "fx") + "queue",
            r = J.get(e, t),
            n && (!r || Array.isArray(n) ? r = J.access(e, t, S.makeArray(n)) : r.push(n)),
            r || []
        },
        dequeue: function(e, t) {
            t = t || "fx";
            var n = S.queue(e, t),
            r = n.length,
            i = n.shift(),
            o = S._queueHooks(e, t);
            "inprogress" === i && (i = n.shift(), r--),
            i && ("fx" === t && n.unshift("inprogress"), delete o.stop, i.call(e,
            function() {
                S.dequeue(e, t)
            },
            o)),
            !r && o && o.empty.fire()
        },
        _queueHooks: function(e, t) {
            var n = t + "queueHooks";
            return J.get(e, n) || J.access(e, n, {
                empty: S.Callbacks("once memory").add(function() {
                    J.remove(e, [t + "queue", n])
                })
            })
        }
    }),
    S.fn.extend({
        queue: function(t, n) {
            var e = 2;
            return "string" != typeof t && (n = t, t = "fx", e--),
            arguments.length < e ? S.queue(this[0], t) : void 0 === n ? this: this.each(function() {
                var e = S.queue(this, t, n);
                S._queueHooks(this, t),
                "fx" === t && "inprogress" !== e[0] && S.dequeue(this, t)
            })
        },
        dequeue: function(e) {
            return this.each(function() {
                S.dequeue(this, e)
            })
        },
        clearQueue: function(e) {
            return this.queue(e || "fx", [])
        },
        promise: function(e, t) {
            var n, r = 1,
            i = S.Deferred(),
            o = this,
            a = this.length,
            s = function() {--r || i.resolveWith(o, [o])
            };
            for ("string" != typeof e && (t = e, e = void 0), e = e || "fx"; a--;)(n = J.get(o[a], e + "queueHooks")) && n.empty && (r++, n.empty.add(s));
            return s(),
            i.promise(t)
        }
    });
    var te = /[+-]?(?:\d*\.|)\d+(?:[eE][+-]?\d+|)/.source,
    ne = new RegExp("^(?:([+-])=|)(" + te + ")([a-z%]*)$", "i"),
    re = ["Top", "Right", "Bottom", "Left"],
    ie = function(e, t) {
        return "none" === (e = t || e).style.display || "" === e.style.display && S.contains(e.ownerDocument, e) && "none" === S.css(e, "display")
    },
    oe = function(e, t, n, r) {
        var i, o, a = {};
        for (o in t) a[o] = e.style[o],
        e.style[o] = t[o];
        for (o in i = n.apply(e, r || []), t) e.style[o] = a[o];
        return i
    };
    function ae(e, t, n, r) {
        var i, o, a = 20,
        s = r ?
        function() {
            return r.cur()
        }: function() {
            return S.css(e, t, "")
        },
        l = s(),
        u = n && n[3] || (S.cssNumber[t] ? "": "px"),
        c = (S.cssNumber[t] || "px" !== u && +l) && ne.exec(S.css(e, t));
        if (c && c[3] !== u) {
            for (l /= 2, u = u || c[3], c = +l || 1; a--;) S.style(e, t, c + u),
            (1 - o) * (1 - (o = s() / l || .5)) <= 0 && (a = 0),
            c /= o;
            c *= 2,
            S.style(e, t, c + u),
            n = n || []
        }
        return n && (c = +c || +l || 0, i = n[1] ? c + (n[1] + 1) * n[2] : +n[2], r && (r.unit = u, r.start = c, r.end = i)),
        i
    }
    var se = {};
    function le(e, t) {
        for (var n, r, i, o, a, s, l, u = [], c = 0, f = e.length; c < f; c++)(r = e[c]).style && (n = r.style.display, t ? ("none" === n && (u[c] = J.get(r, "display") || null, u[c] || (r.style.display = "")), "" === r.style.display && ie(r) && (u[c] = (l = a = o = void 0, a = (i = r).ownerDocument, s = i.nodeName, (l = se[s]) || (o = a.body.appendChild(a.createElement(s)), l = S.css(o, "display"), o.parentNode.removeChild(o), "none" === l && (l = "block"), se[s] = l)))) : "none" !== n && (u[c] = "none", J.set(r, "display", n)));
        for (c = 0; c < f; c++) null != u[c] && (e[c].style.display = u[c]);
        return e
    }
    S.fn.extend({
        show: function() {
            return le(this, !0)
        },
        hide: function() {
            return le(this)
        },
        toggle: function(e) {
            return "boolean" == typeof e ? e ? this.show() : this.hide() : this.each(function() {
                ie(this) ? S(this).show() : S(this).hide()
            })
        }
    });
    var ue = /^(?:checkbox|radio)$/i,
    ce = /<([a-z][^\/\0>\x20\t\r\n\f]+)/i,
    fe = /^$|^module$|\/(?:java|ecma)script/i,
    he = {
        option: [1, "<select multiple='multiple'>", "</select>"],
        thead: [1, "<table>", "</table>"],
        col: [2, "<table><colgroup>", "</colgroup></table>"],
        tr: [2, "<table><tbody>", "</tbody></table>"],
        td: [3, "<table><tbody><tr>", "</tr></tbody></table>"],
        _default: [0, "", ""]
    };
    function pe(e, t) {
        var n;
        return n = void 0 !== e.getElementsByTagName ? e.getElementsByTagName(t || "*") : void 0 !== e.querySelectorAll ? e.querySelectorAll(t || "*") : [],
        void 0 === t || t && A(e, t) ? S.merge([e], n) : n
    }
    function de(e, t) {
        for (var n = 0,
        r = e.length; n < r; n++) J.set(e[n], "globalEval", !t || J.get(t[n], "globalEval"))
    }
    he.optgroup = he.option,
    he.tbody = he.tfoot = he.colgroup = he.caption = he.thead,
    he.th = he.td;
    var ge, ve, me = /<|&#?\w+;/;
    function ye(e, t, n, r, i) {
        for (var o, a, s, l, u, c, f = t.createDocumentFragment(), h = [], p = 0, d = e.length; p < d; p++) if ((o = e[p]) || 0 === o) if ("object" === w(o)) S.merge(h, o.nodeType ? [o] : o);
        else if (me.test(o)) {
            for (a = a || f.appendChild(t.createElement("div")), s = (ce.exec(o) || ["", ""])[1].toLowerCase(), l = he[s] || he._default, a.innerHTML = l[1] + S.htmlPrefilter(o) + l[2], c = l[0]; c--;) a = a.lastChild;
            S.merge(h, a.childNodes),
            (a = f.firstChild).textContent = ""
        } else h.push(t.createTextNode(o));
        for (f.textContent = "", p = 0; o = h[p++];) if (r && -1 < S.inArray(o, r)) i && i.push(o);
        else if (u = S.contains(o.ownerDocument, o), a = pe(f.appendChild(o), "script"), u && de(a), n) for (c = 0; o = a[c++];) fe.test(o.type || "") && n.push(o);
        return f
    }
    ge = C.createDocumentFragment().appendChild(C.createElement("div")),
    (ve = C.createElement("input")).setAttribute("type", "radio"),
    ve.setAttribute("checked", "checked"),
    ve.setAttribute("name", "t"),
    ge.appendChild(ve),
    m.checkClone = ge.cloneNode(!0).cloneNode(!0).lastChild.checked,
    ge.innerHTML = "<textarea>x</textarea>",
    m.noCloneChecked = !!ge.cloneNode(!0).lastChild.defaultValue;
    var be = C.documentElement,
    _e = /^key/,
    we = /^(?:mouse|pointer|contextmenu|drag|drop)|click/,
    xe = /^([^.]*)(?:\.(.+)|)/;
    function Ee() {
        return ! 0
    }
    function Ce() {
        return ! 1
    }
    function Se() {
        try {
            return C.activeElement
        } catch(e) {}
    }
    function Te(e, t, n, r, i, o) {
        var a, s;
        if ("object" == typeof t) {
            for (s in "string" != typeof n && (r = r || n, n = void 0), t) Te(e, s, n, r, t[s], o);
            return e
        }
        if (null == r && null == i ? (i = n, r = n = void 0) : null == i && ("string" == typeof n ? (i = r, r = void 0) : (i = r, r = n, n = void 0)), !1 === i) i = Ce;
        else if (!i) return e;
        return 1 === o && (a = i, (i = function(e) {
            return S().off(e),
            a.apply(this, arguments)
        }).guid = a.guid || (a.guid = S.guid++)),
        e.each(function() {
            S.event.add(this, t, i, r, n)
        })
    }
    S.event = {
        global: {},
        add: function(t, e, n, r, i) {
            var o, a, s, l, u, c, f, h, p, d, g, v = J.get(t);
            if (v) for (n.handler && (n = (o = n).handler, i = o.selector), i && S.find.matchesSelector(be, i), n.guid || (n.guid = S.guid++), (l = v.events) || (l = v.events = {}), (a = v.handle) || (a = v.handle = function(e) {
                return void 0 !== S && S.event.triggered !== e.type ? S.event.dispatch.apply(t, arguments) : void 0
            }), u = (e = (e || "").match(q) || [""]).length; u--;) p = g = (s = xe.exec(e[u]) || [])[1],
            d = (s[2] || "").split(".").sort(),
            p && (f = S.event.special[p] || {},
            p = (i ? f.delegateType: f.bindType) || p, f = S.event.special[p] || {},
            c = S.extend({
                type: p,
                origType: g,
                data: r,
                handler: n,
                guid: n.guid,
                selector: i,
                needsContext: i && S.expr.match.needsContext.test(i),
                namespace: d.join(".")
            },
            o), (h = l[p]) || ((h = l[p] = []).delegateCount = 0, f.setup && !1 !== f.setup.call(t, r, d, a) || t.addEventListener && t.addEventListener(p, a)), f.add && (f.add.call(t, c), c.handler.guid || (c.handler.guid = n.guid)), i ? h.splice(h.delegateCount++, 0, c) : h.push(c), S.event.global[p] = !0)
        },
        remove: function(e, t, n, r, i) {
            var o, a, s, l, u, c, f, h, p, d, g, v = J.hasData(e) && J.get(e);
            if (v && (l = v.events)) {
                for (u = (t = (t || "").match(q) || [""]).length; u--;) if (p = g = (s = xe.exec(t[u]) || [])[1], d = (s[2] || "").split(".").sort(), p) {
                    for (f = S.event.special[p] || {},
                    h = l[p = (r ? f.delegateType: f.bindType) || p] || [], s = s[2] && new RegExp("(^|\\.)" + d.join("\\.(?:.*\\.|)") + "(\\.|$)"), a = o = h.length; o--;) c = h[o],
                    !i && g !== c.origType || n && n.guid !== c.guid || s && !s.test(c.namespace) || r && r !== c.selector && ("**" !== r || !c.selector) || (h.splice(o, 1), c.selector && h.delegateCount--, f.remove && f.remove.call(e, c));
                    a && !h.length && (f.teardown && !1 !== f.teardown.call(e, d, v.handle) || S.removeEvent(e, p, v.handle), delete l[p])
                } else for (p in l) S.event.remove(e, p + t[u], n, r, !0);
                S.isEmptyObject(l) && J.remove(e, "handle events")
            }
        },
        dispatch: function(e) {
            var t, n, r, i, o, a, s = S.event.fix(e),
            l = new Array(arguments.length),
            u = (J.get(this, "events") || {})[s.type] || [],
            c = S.event.special[s.type] || {};
            for (l[0] = s, t = 1; t < arguments.length; t++) l[t] = arguments[t];
            if (s.delegateTarget = this, !c.preDispatch || !1 !== c.preDispatch.call(this, s)) {
                for (a = S.event.handlers.call(this, s, u), t = 0; (i = a[t++]) && !s.isPropagationStopped();) for (s.currentTarget = i.elem, n = 0; (o = i.handlers[n++]) && !s.isImmediatePropagationStopped();) s.rnamespace && !s.rnamespace.test(o.namespace) || (s.handleObj = o, s.data = o.data, void 0 !== (r = ((S.event.special[o.origType] || {}).handle || o.handler).apply(i.elem, l)) && !1 === (s.result = r) && (s.preventDefault(), s.stopPropagation()));
                return c.postDispatch && c.postDispatch.call(this, s),
                s.result
            }
        },
        handlers: function(e, t) {
            var n, r, i, o, a, s = [],
            l = t.delegateCount,
            u = e.target;
            if (l && u.nodeType && !("click" === e.type && 1 <= e.button)) for (; u !== this; u = u.parentNode || this) if (1 === u.nodeType && ("click" !== e.type || !0 !== u.disabled)) {
                for (o = [], a = {},
                n = 0; n < l; n++) void 0 === a[i = (r = t[n]).selector + " "] && (a[i] = r.needsContext ? -1 < S(i, this).index(u) : S.find(i, this, null, [u]).length),
                a[i] && o.push(r);
                o.length && s.push({
                    elem: u,
                    handlers: o
                })
            }
            return u = this,
            l < t.length && s.push({
                elem: u,
                handlers: t.slice(l)
            }),
            s
        },
        addProp: function(t, e) {
            Object.defineProperty(S.Event.prototype, t, {
                enumerable: !0,
                configurable: !0,
                get: y(e) ?
                function() {
                    if (this.originalEvent) return e(this.originalEvent)
                }: function() {
                    if (this.originalEvent) return this.originalEvent[t]
                },
                set: function(e) {
                    Object.defineProperty(this, t, {
                        enumerable: !0,
                        configurable: !0,
                        writable: !0,
                        value: e
                    })
                }
            })
        },
        fix: function(e) {
            return e[S.expando] ? e: new S.Event(e)
        },
        special: {
            load: {
                noBubble: !0
            },
            focus: {
                trigger: function() {
                    if (this !== Se() && this.focus) return this.focus(),
                    !1
                },
                delegateType: "focusin"
            },
            blur: {
                trigger: function() {
                    if (this === Se() && this.blur) return this.blur(),
                    !1
                },
                delegateType: "focusout"
            },
            click: {
                trigger: function() {
                    if ("checkbox" === this.type && this.click && A(this, "input")) return this.click(),
                    !1
                },
                _default: function(e) {
                    return A(e.target, "a")
                }
            },
            beforeunload: {
                postDispatch: function(e) {
                    void 0 !== e.result && e.originalEvent && (e.originalEvent.returnValue = e.result)
                }
            }
        }
    },
    S.removeEvent = function(e, t, n) {
        e.removeEventListener && e.removeEventListener(t, n)
    },
    S.Event = function(e, t) {
        if (! (this instanceof S.Event)) return new S.Event(e, t);
        e && e.type ? (this.originalEvent = e, this.type = e.type, this.isDefaultPrevented = e.defaultPrevented || void 0 === e.defaultPrevented && !1 === e.returnValue ? Ee: Ce, this.target = e.target && 3 === e.target.nodeType ? e.target.parentNode: e.target, this.currentTarget = e.currentTarget, this.relatedTarget = e.relatedTarget) : this.type = e,
        t && S.extend(this, t),
        this.timeStamp = e && e.timeStamp || Date.now(),
        this[S.expando] = !0
    },
    S.Event.prototype = {
        constructor: S.Event,
        isDefaultPrevented: Ce,
        isPropagationStopped: Ce,
        isImmediatePropagationStopped: Ce,
        isSimulated: !1,
        preventDefault: function() {
            var e = this.originalEvent;
            this.isDefaultPrevented = Ee,
            e && !this.isSimulated && e.preventDefault()
        },
        stopPropagation: function() {
            var e = this.originalEvent;
            this.isPropagationStopped = Ee,
            e && !this.isSimulated && e.stopPropagation()
        },
        stopImmediatePropagation: function() {
            var e = this.originalEvent;
            this.isImmediatePropagationStopped = Ee,
            e && !this.isSimulated && e.stopImmediatePropagation(),
            this.stopPropagation()
        }
    },
    S.each({
        altKey: !0,
        bubbles: !0,
        cancelable: !0,
        changedTouches: !0,
        ctrlKey: !0,
        detail: !0,
        eventPhase: !0,
        metaKey: !0,
        pageX: !0,
        pageY: !0,
        shiftKey: !0,
        view: !0,
        char: !0,
        charCode: !0,
        key: !0,
        keyCode: !0,
        button: !0,
        buttons: !0,
        clientX: !0,
        clientY: !0,
        offsetX: !0,
        offsetY: !0,
        pointerId: !0,
        pointerType: !0,
        screenX: !0,
        screenY: !0,
        targetTouches: !0,
        toElement: !0,
        touches: !0,
        which: function(e) {
            var t = e.button;
            return null == e.which && _e.test(e.type) ? null != e.charCode ? e.charCode: e.keyCode: !e.which && void 0 !== t && we.test(e.type) ? 1 & t ? 1 : 2 & t ? 3 : 4 & t ? 2 : 0 : e.which
        }
    },
    S.event.addProp),
    S.each({
        mouseenter: "mouseover",
        mouseleave: "mouseout",
        pointerenter: "pointerover",
        pointerleave: "pointerout"
    },
    function(e, i) {
        S.event.special[e] = {
            delegateType: i,
            bindType: i,
            handle: function(e) {
                var t, n = e.relatedTarget,
                r = e.handleObj;
                return n && (n === this || S.contains(this, n)) || (e.type = r.origType, t = r.handler.apply(this, arguments), e.type = i),
                t
            }
        }
    }),
    S.fn.extend({
        on: function(e, t, n, r) {
            return Te(this, e, t, n, r)
        },
        one: function(e, t, n, r) {
            return Te(this, e, t, n, r, 1)
        },
        off: function(e, t, n) {
            var r, i;
            if (e && e.preventDefault && e.handleObj) return r = e.handleObj,
            S(e.delegateTarget).off(r.namespace ? r.origType + "." + r.namespace: r.origType, r.selector, r.handler),
            this;
            if ("object" == typeof e) {
                for (i in e) this.off(i, t, e[i]);
                return this
            }
            return ! 1 !== t && "function" != typeof t || (n = t, t = void 0),
            !1 === n && (n = Ce),
            this.each(function() {
                S.event.remove(this, e, n, t)
            })
        }
    });
    var ke = /<(?!area|br|col|embed|hr|img|input|link|meta|param)(([a-z][^\/\0>\x20\t\r\n\f]*)[^>]*)\/>/gi,
    Ae = /<script|<style|<link/i,
    De = /checked\s*(?:[^=]|=\s*.checked.)/i,
    Oe = /^\s*<!(?:\[CDATA\[|--)|(?:\]\]|--)>\s*$/g;
    function je(e, t) {
        return A(e, "table") && A(11 !== t.nodeType ? t: t.firstChild, "tr") && S(e).children("tbody")[0] || e
    }
    function Ne(e) {
        return e.type = (null !== e.getAttribute("type")) + "/" + e.type,
        e
    }
    function Ie(e) {
        return "true/" === (e.type || "").slice(0, 5) ? e.type = e.type.slice(5) : e.removeAttribute("type"),
        e
    }
    function Le(e, t) {
        var n, r, i, o, a, s, l, u;
        if (1 === t.nodeType) {
            if (J.hasData(e) && (o = J.access(e), a = J.set(t, o), u = o.events)) for (i in delete a.handle, a.events = {},
            u) for (n = 0, r = u[i].length; n < r; n++) S.event.add(t, i, u[i][n]);
            X.hasData(e) && (s = X.access(e), l = S.extend({},
            s), X.set(t, l))
        }
    }
    function Pe(n, r, i, o) {
        r = g.apply([], r);
        var e, t, a, s, l, u, c = 0,
        f = n.length,
        h = f - 1,
        p = r[0],
        d = y(p);
        if (d || 1 < f && "string" == typeof p && !m.checkClone && De.test(p)) return n.each(function(e) {
            var t = n.eq(e);
            d && (r[0] = p.call(this, e, t.html())),
            Pe(t, r, i, o)
        });
        if (f && (t = (e = ye(r, n[0].ownerDocument, !1, n, o)).firstChild, 1 === e.childNodes.length && (e = t), t || o)) {
            for (s = (a = S.map(pe(e, "script"), Ne)).length; c < f; c++) l = e,
            c !== h && (l = S.clone(l, !0, !0), s && S.merge(a, pe(l, "script"))),
            i.call(n[c], l, c);
            if (s) for (u = a[a.length - 1].ownerDocument, S.map(a, Ie), c = 0; c < s; c++) l = a[c],
            fe.test(l.type || "") && !J.access(l, "globalEval") && S.contains(u, l) && (l.src && "module" !== (l.type || "").toLowerCase() ? S._evalUrl && S._evalUrl(l.src) : _(l.textContent.replace(Oe, ""), u, l))
        }
        return n
    }
    function qe(e, t, n) {
        for (var r, i = t ? S.filter(t, e) : e, o = 0; null != (r = i[o]); o++) n || 1 !== r.nodeType || S.cleanData(pe(r)),
        r.parentNode && (n && S.contains(r.ownerDocument, r) && de(pe(r, "script")), r.parentNode.removeChild(r));
        return e
    }
    S.extend({
        htmlPrefilter: function(e) {
            return e.replace(ke, "<$1></$2>")
        },
        clone: function(e, t, n) {
            var r, i, o, a, s, l, u, c = e.cloneNode(!0),
            f = S.contains(e.ownerDocument, e);
            if (! (m.noCloneChecked || 1 !== e.nodeType && 11 !== e.nodeType || S.isXMLDoc(e))) for (a = pe(c), r = 0, i = (o = pe(e)).length; r < i; r++) s = o[r],
            l = a[r],
            void 0,
            "input" === (u = l.nodeName.toLowerCase()) && ue.test(s.type) ? l.checked = s.checked: "input" !== u && "textarea" !== u || (l.defaultValue = s.defaultValue);
            if (t) if (n) for (o = o || pe(e), a = a || pe(c), r = 0, i = o.length; r < i; r++) Le(o[r], a[r]);
            else Le(e, c);
            return 0 < (a = pe(c, "script")).length && de(a, !f && pe(e, "script")),
            c
        },
        cleanData: function(e) {
            for (var t, n, r, i = S.event.special,
            o = 0; void 0 !== (n = e[o]); o++) if (Q(n)) {
                if (t = n[J.expando]) {
                    if (t.events) for (r in t.events) i[r] ? S.event.remove(n, r) : S.removeEvent(n, r, t.handle);
                    n[J.expando] = void 0
                }
                n[X.expando] && (n[X.expando] = void 0)
            }
        }
    }),
    S.fn.extend({
        detach: function(e) {
            return qe(this, e, !0)
        },
        remove: function(e) {
            return qe(this, e)
        },
        text: function(e) {
            return W(this,
            function(e) {
                return void 0 === e ? S.text(this) : this.empty().each(function() {
                    1 !== this.nodeType && 11 !== this.nodeType && 9 !== this.nodeType || (this.textContent = e)
                })
            },
            null, e, arguments.length)
        },
        append: function() {
            return Pe(this, arguments,
            function(e) {
                1 !== this.nodeType && 11 !== this.nodeType && 9 !== this.nodeType || je(this, e).appendChild(e)
            })
        },
        prepend: function() {
            return Pe(this, arguments,
            function(e) {
                if (1 === this.nodeType || 11 === this.nodeType || 9 === this.nodeType) {
                    var t = je(this, e);
                    t.insertBefore(e, t.firstChild)
                }
            })
        },
        before: function() {
            return Pe(this, arguments,
            function(e) {
                this.parentNode && this.parentNode.insertBefore(e, this)
            })
        },
        after: function() {
            return Pe(this, arguments,
            function(e) {
                this.parentNode && this.parentNode.insertBefore(e, this.nextSibling)
            })
        },
        empty: function() {
            for (var e, t = 0; null != (e = this[t]); t++) 1 === e.nodeType && (S.cleanData(pe(e, !1)), e.textContent = "");
            return this
        },
        clone: function(e, t) {
            return e = null != e && e,
            t = null == t ? e: t,
            this.map(function() {
                return S.clone(this, e, t)
            })
        },
        html: function(e) {
            return W(this,
            function(e) {
                var t = this[0] || {},
                n = 0,
                r = this.length;
                if (void 0 === e && 1 === t.nodeType) return t.innerHTML;
                if ("string" == typeof e && !Ae.test(e) && !he[(ce.exec(e) || ["", ""])[1].toLowerCase()]) {
                    e = S.htmlPrefilter(e);
                    try {
                        for (; n < r; n++) 1 === (t = this[n] || {}).nodeType && (S.cleanData(pe(t, !1)), t.innerHTML = e);
                        t = 0
                    } catch(e) {}
                }
                t && this.empty().append(e)
            },
            null, e, arguments.length)
        },
        replaceWith: function() {
            var n = [];
            return Pe(this, arguments,
            function(e) {
                var t = this.parentNode;
                S.inArray(this, n) < 0 && (S.cleanData(pe(this)), t && t.replaceChild(e, this))
            },
            n)
        }
    }),
    S.each({
        appendTo: "append",
        prependTo: "prepend",
        insertBefore: "before",
        insertAfter: "after",
        replaceAll: "replaceWith"
    },
    function(e, a) {
        S.fn[e] = function(e) {
            for (var t, n = [], r = S(e), i = r.length - 1, o = 0; o <= i; o++) t = o === i ? this: this.clone(!0),
            S(r[o])[a](t),
            l.apply(n, t.get());
            return this.pushStack(n)
        }
    });
    var Fe = new RegExp("^(" + te + ")(?!px)[a-z%]+$", "i"),
    Re = function(e) {
        var t = e.ownerDocument.defaultView;
        return t && t.opener || (t = E),
        t.getComputedStyle(e)
    },
    Me = new RegExp(re.join("|"), "i");
    function He(e, t, n) {
        var r, i, o, a, s = e.style;
        return (n = n || Re(e)) && ("" !== (a = n.getPropertyValue(t) || n[t]) || S.contains(e.ownerDocument, e) || (a = S.style(e, t)), !m.pixelBoxStyles() && Fe.test(a) && Me.test(t) && (r = s.width, i = s.minWidth, o = s.maxWidth, s.minWidth = s.maxWidth = s.width = a, a = n.width, s.width = r, s.minWidth = i, s.maxWidth = o)),
        void 0 !== a ? a + "": a
    }
    function Be(e, t) {
        return {
            get: function() {
                if (!e()) return (this.get = t).apply(this, arguments);
                delete this.get
            }
        }
    } !
    function() {
        function e() {
            if (l) {
                s.style.cssText = "position:absolute;left:-11111px;width:60px;margin-top:1px;padding:0;border:0",
                l.style.cssText = "position:relative;display:block;box-sizing:border-box;overflow:scroll;margin:auto;border:1px;padding:1px;width:60%;top:1%",
                be.appendChild(s).appendChild(l);
                var e = E.getComputedStyle(l);
                n = "1%" !== e.top,
                a = 12 === t(e.marginLeft),
                l.style.right = "60%",
                o = 36 === t(e.right),
                r = 36 === t(e.width),
                l.style.position = "absolute",
                i = 36 === l.offsetWidth || "absolute",
                be.removeChild(s),
                l = null
            }
        }
        function t(e) {
            return Math.round(parseFloat(e))
        }
        var n, r, i, o, a, s = C.createElement("div"),
        l = C.createElement("div");
        l.style && (l.style.backgroundClip = "content-box", l.cloneNode(!0).style.backgroundClip = "", m.clearCloneStyle = "content-box" === l.style.backgroundClip, S.extend(m, {
            boxSizingReliable: function() {
                return e(),
                r
            },
            pixelBoxStyles: function() {
                return e(),
                o
            },
            pixelPosition: function() {
                return e(),
                n
            },
            reliableMarginLeft: function() {
                return e(),
                a
            },
            scrollboxSize: function() {
                return e(),
                i
            }
        }))
    } ();
    var $e = /^(none|table(?!-c[ea]).+)/,
    We = /^--/,
    Ue = {
        position: "absolute",
        visibility: "hidden",
        display: "block"
    },
    ze = {
        letterSpacing: "0",
        fontWeight: "400"
    },
    Ve = ["Webkit", "Moz", "ms"],
    Ke = C.createElement("div").style;
    function Qe(e) {
        var t = S.cssProps[e];
        return t || (t = S.cssProps[e] = function(e) {
            if (e in Ke) return e;
            for (var t = e[0].toUpperCase() + e.slice(1), n = Ve.length; n--;) if ((e = Ve[n] + t) in Ke) return e
        } (e) || e),
        t
    }
    function Ye(e, t, n) {
        var r = ne.exec(t);
        return r ? Math.max(0, r[2] - (n || 0)) + (r[3] || "px") : t
    }
    function Je(e, t, n, r, i, o) {
        var a = "width" === t ? 1 : 0,
        s = 0,
        l = 0;
        if (n === (r ? "border": "content")) return 0;
        for (; a < 4; a += 2)"margin" === n && (l += S.css(e, n + re[a], !0, i)),
        r ? ("content" === n && (l -= S.css(e, "padding" + re[a], !0, i)), "margin" !== n && (l -= S.css(e, "border" + re[a] + "Width", !0, i))) : (l += S.css(e, "padding" + re[a], !0, i), "padding" !== n ? l += S.css(e, "border" + re[a] + "Width", !0, i) : s += S.css(e, "border" + re[a] + "Width", !0, i));
        return ! r && 0 <= o && (l += Math.max(0, Math.ceil(e["offset" + t[0].toUpperCase() + t.slice(1)] - o - l - s - .5))),
        l
    }
    function Xe(e, t, n) {
        var r = Re(e),
        i = He(e, t, r),
        o = "border-box" === S.css(e, "boxSizing", !1, r),
        a = o;
        if (Fe.test(i)) {
            if (!n) return i;
            i = "auto"
        }
        return a = a && (m.boxSizingReliable() || i === e.style[t]),
        ("auto" === i || !parseFloat(i) && "inline" === S.css(e, "display", !1, r)) && (i = e["offset" + t[0].toUpperCase() + t.slice(1)], a = !0),
        (i = parseFloat(i) || 0) + Je(e, t, n || (o ? "border": "content"), a, r, i) + "px"
    }
    function Ge(e, t, n, r, i) {
        return new Ge.prototype.init(e, t, n, r, i)
    }
    S.extend({
        cssHooks: {
            opacity: {
                get: function(e, t) {
                    if (t) {
                        var n = He(e, "opacity");
                        return "" === n ? "1": n
                    }
                }
            }
        },
        cssNumber: {
            animationIterationCount: !0,
            columnCount: !0,
            fillOpacity: !0,
            flexGrow: !0,
            flexShrink: !0,
            fontWeight: !0,
            lineHeight: !0,
            opacity: !0,
            order: !0,
            orphans: !0,
            widows: !0,
            zIndex: !0,
            zoom: !0
        },
        cssProps: {},
        style: function(e, t, n, r) {
            if (e && 3 !== e.nodeType && 8 !== e.nodeType && e.style) {
                var i, o, a, s = K(t),
                l = We.test(t),
                u = e.style;
                if (l || (t = Qe(s)), a = S.cssHooks[t] || S.cssHooks[s], void 0 === n) return a && "get" in a && void 0 !== (i = a.get(e, !1, r)) ? i: u[t];
                "string" === (o = typeof n) && (i = ne.exec(n)) && i[1] && (n = ae(e, t, i), o = "number"),
                null != n && n == n && ("number" === o && (n += i && i[3] || (S.cssNumber[s] ? "": "px")), m.clearCloneStyle || "" !== n || 0 !== t.indexOf("background") || (u[t] = "inherit"), a && "set" in a && void 0 === (n = a.set(e, n, r)) || (l ? u.setProperty(t, n) : u[t] = n))
            }
        },
        css: function(e, t, n, r) {
            var i, o, a, s = K(t);
            return We.test(t) || (t = Qe(s)),
            (a = S.cssHooks[t] || S.cssHooks[s]) && "get" in a && (i = a.get(e, !0, n)),
            void 0 === i && (i = He(e, t, r)),
            "normal" === i && t in ze && (i = ze[t]),
            "" === n || n ? (o = parseFloat(i), !0 === n || isFinite(o) ? o || 0 : i) : i
        }
    }),
    S.each(["height", "width"],
    function(e, s) {
        S.cssHooks[s] = {
            get: function(e, t, n) {
                if (t) return ! $e.test(S.css(e, "display")) || e.getClientRects().length && e.getBoundingClientRect().width ? Xe(e, s, n) : oe(e, Ue,
                function() {
                    return Xe(e, s, n)
                })
            },
            set: function(e, t, n) {
                var r, i = Re(e),
                o = "border-box" === S.css(e, "boxSizing", !1, i),
                a = n && Je(e, s, n, o, i);
                return o && m.scrollboxSize() === i.position && (a -= Math.ceil(e["offset" + s[0].toUpperCase() + s.slice(1)] - parseFloat(i[s]) - Je(e, s, "border", !1, i) - .5)),
                a && (r = ne.exec(t)) && "px" !== (r[3] || "px") && (e.style[s] = t, t = S.css(e, s)),
                Ye(0, t, a)
            }
        }
    }),
    S.cssHooks.marginLeft = Be(m.reliableMarginLeft,
    function(e, t) {
        if (t) return (parseFloat(He(e, "marginLeft")) || e.getBoundingClientRect().left - oe(e, {
            marginLeft: 0
        },
        function() {
            return e.getBoundingClientRect().left
        })) + "px"
    }),
    S.each({
        margin: "",
        padding: "",
        border: "Width"
    },
    function(i, o) {
        S.cssHooks[i + o] = {
            expand: function(e) {
                for (var t = 0,
                n = {},
                r = "string" == typeof e ? e.split(" ") : [e]; t < 4; t++) n[i + re[t] + o] = r[t] || r[t - 2] || r[0];
                return n
            }
        },
        "margin" !== i && (S.cssHooks[i + o].set = Ye)
    }),
    S.fn.extend({
        css: function(e, t) {
            return W(this,
            function(e, t, n) {
                var r, i, o = {},
                a = 0;
                if (Array.isArray(t)) {
                    for (r = Re(e), i = t.length; a < i; a++) o[t[a]] = S.css(e, t[a], !1, r);
                    return o
                }
                return void 0 !== n ? S.style(e, t, n) : S.css(e, t)
            },
            e, t, 1 < arguments.length)
        }
    }),
    ((S.Tween = Ge).prototype = {
        constructor: Ge,
        init: function(e, t, n, r, i, o) {
            this.elem = e,
            this.prop = n,
            this.easing = i || S.easing._default,
            this.options = t,
            this.start = this.now = this.cur(),
            this.end = r,
            this.unit = o || (S.cssNumber[n] ? "": "px")
        },
        cur: function() {
            var e = Ge.propHooks[this.prop];
            return e && e.get ? e.get(this) : Ge.propHooks._default.get(this)
        },
        run: function(e) {
            var t, n = Ge.propHooks[this.prop];
            return this.options.duration ? this.pos = t = S.easing[this.easing](e, this.options.duration * e, 0, 1, this.options.duration) : this.pos = t = e,
            this.now = (this.end - this.start) * t + this.start,
            this.options.step && this.options.step.call(this.elem, this.now, this),
            n && n.set ? n.set(this) : Ge.propHooks._default.set(this),
            this
        }
    }).init.prototype = Ge.prototype,
    (Ge.propHooks = {
        _default: {
            get: function(e) {
                var t;
                return 1 !== e.elem.nodeType || null != e.elem[e.prop] && null == e.elem.style[e.prop] ? e.elem[e.prop] : (t = S.css(e.elem, e.prop, "")) && "auto" !== t ? t: 0
            },
            set: function(e) {
                S.fx.step[e.prop] ? S.fx.step[e.prop](e) : 1 !== e.elem.nodeType || null == e.elem.style[S.cssProps[e.prop]] && !S.cssHooks[e.prop] ? e.elem[e.prop] = e.now: S.style(e.elem, e.prop, e.now + e.unit)
            }
        }
    }).scrollTop = Ge.propHooks.scrollLeft = {
        set: function(e) {
            e.elem.nodeType && e.elem.parentNode && (e.elem[e.prop] = e.now)
        }
    },
    S.easing = {
        linear: function(e) {
            return e
        },
        swing: function(e) {
            return.5 - Math.cos(e * Math.PI) / 2
        },
        _default: "swing"
    },
    S.fx = Ge.prototype.init,
    S.fx.step = {};
    var Ze, et, tt, nt, rt = /^(?:toggle|show|hide)$/,
    it = /queueHooks$/;
    function ot() {
        et && (!1 === C.hidden && E.requestAnimationFrame ? E.requestAnimationFrame(ot) : E.setTimeout(ot, S.fx.interval), S.fx.tick())
    }
    function at() {
        return E.setTimeout(function() {
            Ze = void 0
        }),
        Ze = Date.now()
    }
    function st(e, t) {
        var n, r = 0,
        i = {
            height: e
        };
        for (t = t ? 1 : 0; r < 4; r += 2 - t) i["margin" + (n = re[r])] = i["padding" + n] = e;
        return t && (i.opacity = i.width = e),
        i
    }
    function lt(e, t, n) {
        for (var r, i = (ut.tweeners[t] || []).concat(ut.tweeners["*"]), o = 0, a = i.length; o < a; o++) if (r = i[o].call(n, t, e)) return r
    }
    function ut(o, e, t) {
        var n, a, r = 0,
        i = ut.prefilters.length,
        s = S.Deferred().always(function() {
            delete l.elem
        }),
        l = function() {
            if (a) return ! 1;
            for (var e = Ze || at(), t = Math.max(0, u.startTime + u.duration - e), n = 1 - (t / u.duration || 0), r = 0, i = u.tweens.length; r < i; r++) u.tweens[r].run(n);
            return s.notifyWith(o, [u, n, t]),
            n < 1 && i ? t: (i || s.notifyWith(o, [u, 1, 0]), s.resolveWith(o, [u]), !1)
        },
        u = s.promise({
            elem: o,
            props: S.extend({},
            e),
            opts: S.extend(!0, {
                specialEasing: {},
                easing: S.easing._default
            },
            t),
            originalProperties: e,
            originalOptions: t,
            startTime: Ze || at(),
            duration: t.duration,
            tweens: [],
            createTween: function(e, t) {
                var n = S.Tween(o, u.opts, e, t, u.opts.specialEasing[e] || u.opts.easing);
                return u.tweens.push(n),
                n
            },
            stop: function(e) {
                var t = 0,
                n = e ? u.tweens.length: 0;
                if (a) return this;
                for (a = !0; t < n; t++) u.tweens[t].run(1);
                return e ? (s.notifyWith(o, [u, 1, 0]), s.resolveWith(o, [u, e])) : s.rejectWith(o, [u, e]),
                this
            }
        }),
        c = u.props;
        for (!
        function(e, t) {
            var n, r, i, o, a;
            for (n in e) if (i = t[r = K(n)], o = e[n], Array.isArray(o) && (i = o[1], o = e[n] = o[0]), n !== r && (e[r] = o, delete e[n]), (a = S.cssHooks[r]) && "expand" in a) for (n in o = a.expand(o), delete e[r], o) n in e || (e[n] = o[n], t[n] = i);
            else t[r] = i
        } (c, u.opts.specialEasing); r < i; r++) if (n = ut.prefilters[r].call(u, o, c, u.opts)) return y(n.stop) && (S._queueHooks(u.elem, u.opts.queue).stop = n.stop.bind(n)),
        n;
        return S.map(c, lt, u),
        y(u.opts.start) && u.opts.start.call(o, u),
        u.progress(u.opts.progress).done(u.opts.done, u.opts.complete).fail(u.opts.fail).always(u.opts.always),
        S.fx.timer(S.extend(l, {
            elem: o,
            anim: u,
            queue: u.opts.queue
        })),
        u
    }
    S.Animation = S.extend(ut, {
        tweeners: {
            "*": [function(e, t) {
                var n = this.createTween(e, t);
                return ae(n.elem, e, ne.exec(t), n),
                n
            }]
        },
        tweener: function(e, t) {
            y(e) ? (t = e, e = ["*"]) : e = e.match(q);
            for (var n, r = 0,
            i = e.length; r < i; r++) n = e[r],
            ut.tweeners[n] = ut.tweeners[n] || [],
            ut.tweeners[n].unshift(t)
        },
        prefilters: [function(e, t, n) {
            var r, i, o, a, s, l, u, c, f = "width" in t || "height" in t,
            h = this,
            p = {},
            d = e.style,
            g = e.nodeType && ie(e),
            v = J.get(e, "fxshow");
            for (r in n.queue || (null == (a = S._queueHooks(e, "fx")).unqueued && (a.unqueued = 0, s = a.empty.fire, a.empty.fire = function() {
                a.unqueued || s()
            }), a.unqueued++, h.always(function() {
                h.always(function() {
                    a.unqueued--,
                    S.queue(e, "fx").length || a.empty.fire()
                })
            })), t) if (i = t[r], rt.test(i)) {
                if (delete t[r], o = o || "toggle" === i, i === (g ? "hide": "show")) {
                    if ("show" !== i || !v || void 0 === v[r]) continue;
                    g = !0
                }
                p[r] = v && v[r] || S.style(e, r)
            }
            if ((l = !S.isEmptyObject(t)) || !S.isEmptyObject(p)) for (r in f && 1 === e.nodeType && (n.overflow = [d.overflow, d.overflowX, d.overflowY], null == (u = v && v.display) && (u = J.get(e, "display")), "none" === (c = S.css(e, "display")) && (u ? c = u: (le([e], !0), u = e.style.display || u, c = S.css(e, "display"), le([e]))), ("inline" === c || "inline-block" === c && null != u) && "none" === S.css(e, "float") && (l || (h.done(function() {
                d.display = u
            }), null == u && (c = d.display, u = "none" === c ? "": c)), d.display = "inline-block")), n.overflow && (d.overflow = "hidden", h.always(function() {
                d.overflow = n.overflow[0],
                d.overflowX = n.overflow[1],
                d.overflowY = n.overflow[2]
            })), l = !1, p) l || (v ? "hidden" in v && (g = v.hidden) : v = J.access(e, "fxshow", {
                display: u
            }), o && (v.hidden = !g), g && le([e], !0), h.done(function() {
                for (r in g || le([e]), J.remove(e, "fxshow"), p) S.style(e, r, p[r])
            })),
            l = lt(g ? v[r] : 0, r, h),
            r in v || (v[r] = l.start, g && (l.end = l.start, l.start = 0))
        }],
        prefilter: function(e, t) {
            t ? ut.prefilters.unshift(e) : ut.prefilters.push(e)
        }
    }),
    S.speed = function(e, t, n) {
        var r = e && "object" == typeof e ? S.extend({},
        e) : {
            complete: n || !n && t || y(e) && e,
            duration: e,
            easing: n && t || t && !y(t) && t
        };
        return S.fx.off ? r.duration = 0 : "number" != typeof r.duration && (r.duration in S.fx.speeds ? r.duration = S.fx.speeds[r.duration] : r.duration = S.fx.speeds._default),
        null != r.queue && !0 !== r.queue || (r.queue = "fx"),
        r.old = r.complete,
        r.complete = function() {
            y(r.old) && r.old.call(this),
            r.queue && S.dequeue(this, r.queue)
        },
        r
    },
    S.fn.extend({
        fadeTo: function(e, t, n, r) {
            return this.filter(ie).css("opacity", 0).show().end().animate({
                opacity: t
            },
            e, n, r)
        },
        animate: function(t, e, n, r) {
            var i = S.isEmptyObject(t),
            o = S.speed(e, n, r),
            a = function() {
                var e = ut(this, S.extend({},
                t), o); (i || J.get(this, "finish")) && e.stop(!0)
            };
            return a.finish = a,
            i || !1 === o.queue ? this.each(a) : this.queue(o.queue, a)
        },
        stop: function(i, e, o) {
            var a = function(e) {
                var t = e.stop;
                delete e.stop,
                t(o)
            };
            return "string" != typeof i && (o = e, e = i, i = void 0),
            e && !1 !== i && this.queue(i || "fx", []),
            this.each(function() {
                var e = !0,
                t = null != i && i + "queueHooks",
                n = S.timers,
                r = J.get(this);
                if (t) r[t] && r[t].stop && a(r[t]);
                else for (t in r) r[t] && r[t].stop && it.test(t) && a(r[t]);
                for (t = n.length; t--;) n[t].elem !== this || null != i && n[t].queue !== i || (n[t].anim.stop(o), e = !1, n.splice(t, 1)); ! e && o || S.dequeue(this, i)
            })
        },
        finish: function(a) {
            return ! 1 !== a && (a = a || "fx"),
            this.each(function() {
                var e, t = J.get(this),
                n = t[a + "queue"],
                r = t[a + "queueHooks"],
                i = S.timers,
                o = n ? n.length: 0;
                for (t.finish = !0, S.queue(this, a, []), r && r.stop && r.stop.call(this, !0), e = i.length; e--;) i[e].elem === this && i[e].queue === a && (i[e].anim.stop(!0), i.splice(e, 1));
                for (e = 0; e < o; e++) n[e] && n[e].finish && n[e].finish.call(this);
                delete t.finish
            })
        }
    }),
    S.each(["toggle", "show", "hide"],
    function(e, r) {
        var i = S.fn[r];
        S.fn[r] = function(e, t, n) {
            return null == e || "boolean" == typeof e ? i.apply(this, arguments) : this.animate(st(r, !0), e, t, n)
        }
    }),
    S.each({
        slideDown: st("show"),
        slideUp: st("hide"),
        slideToggle: st("toggle"),
        fadeIn: {
            opacity: "show"
        },
        fadeOut: {
            opacity: "hide"
        },
        fadeToggle: {
            opacity: "toggle"
        }
    },
    function(e, r) {
        S.fn[e] = function(e, t, n) {
            return this.animate(r, e, t, n)
        }
    }),
    S.timers = [],
    S.fx.tick = function() {
        var e, t = 0,
        n = S.timers;
        for (Ze = Date.now(); t < n.length; t++)(e = n[t])() || n[t] !== e || n.splice(t--, 1);
        n.length || S.fx.stop(),
        Ze = void 0
    },
    S.fx.timer = function(e) {
        S.timers.push(e),
        S.fx.start()
    },
    S.fx.interval = 13,
    S.fx.start = function() {
        et || (et = !0, ot())
    },
    S.fx.stop = function() {
        et = null
    },
    S.fx.speeds = {
        slow: 600,
        fast: 200,
        _default: 400
    },
    S.fn.delay = function(r, e) {
        return r = S.fx && S.fx.speeds[r] || r,
        e = e || "fx",
        this.queue(e,
        function(e, t) {
            var n = E.setTimeout(e, r);
            t.stop = function() {
                E.clearTimeout(n)
            }
        })
    },
    tt = C.createElement("input"),
    nt = C.createElement("select").appendChild(C.createElement("option")),
    tt.type = "checkbox",
    m.checkOn = "" !== tt.value,
    m.optSelected = nt.selected,
    (tt = C.createElement("input")).value = "t",
    tt.type = "radio",
    m.radioValue = "t" === tt.value;
    var ct, ft = S.expr.attrHandle;
    S.fn.extend({
        attr: function(e, t) {
            return W(this, S.attr, e, t, 1 < arguments.length)
        },
        removeAttr: function(e) {
            return this.each(function() {
                S.removeAttr(this, e)
            })
        }
    }),
    S.extend({
        attr: function(e, t, n) {
            var r, i, o = e.nodeType;
            if (3 !== o && 8 !== o && 2 !== o) return void 0 === e.getAttribute ? S.prop(e, t, n) : (1 === o && S.isXMLDoc(e) || (i = S.attrHooks[t.toLowerCase()] || (S.expr.match.bool.test(t) ? ct: void 0)), void 0 !== n ? null === n ? void S.removeAttr(e, t) : i && "set" in i && void 0 !== (r = i.set(e, n, t)) ? r: (e.setAttribute(t, n + ""), n) : i && "get" in i && null !== (r = i.get(e, t)) ? r: null == (r = S.find.attr(e, t)) ? void 0 : r)
        },
        attrHooks: {
            type: {
                set: function(e, t) {
                    if (!m.radioValue && "radio" === t && A(e, "input")) {
                        var n = e.value;
                        return e.setAttribute("type", t),
                        n && (e.value = n),
                        t
                    }
                }
            }
        },
        removeAttr: function(e, t) {
            var n, r = 0,
            i = t && t.match(q);
            if (i && 1 === e.nodeType) for (; n = i[r++];) e.removeAttribute(n)
        }
    }),
    ct = {
        set: function(e, t, n) {
            return ! 1 === t ? S.removeAttr(e, n) : e.setAttribute(n, n),
            n
        }
    },
    S.each(S.expr.match.bool.source.match(/\w+/g),
    function(e, t) {
        var a = ft[t] || S.find.attr;
        ft[t] = function(e, t, n) {
            var r, i, o = t.toLowerCase();
            return n || (i = ft[o], ft[o] = r, r = null != a(e, t, n) ? o: null, ft[o] = i),
            r
        }
    });
    var ht = /^(?:input|select|textarea|button)$/i,
    pt = /^(?:a|area)$/i;
    function dt(e) {
        return (e.match(q) || []).join(" ")
    }
    function gt(e) {
        return e.getAttribute && e.getAttribute("class") || ""
    }
    function vt(e) {
        return Array.isArray(e) ? e: "string" == typeof e && e.match(q) || []
    }
    S.fn.extend({
        prop: function(e, t) {
            return W(this, S.prop, e, t, 1 < arguments.length)
        },
        removeProp: function(e) {
            return this.each(function() {
                delete this[S.propFix[e] || e]
            })
        }
    }),
    S.extend({
        prop: function(e, t, n) {
            var r, i, o = e.nodeType;
            if (3 !== o && 8 !== o && 2 !== o) return 1 === o && S.isXMLDoc(e) || (t = S.propFix[t] || t, i = S.propHooks[t]),
            void 0 !== n ? i && "set" in i && void 0 !== (r = i.set(e, n, t)) ? r: e[t] = n: i && "get" in i && null !== (r = i.get(e, t)) ? r: e[t]
        },
        propHooks: {
            tabIndex: {
                get: function(e) {
                    var t = S.find.attr(e, "tabindex");
                    return t ? parseInt(t, 10) : ht.test(e.nodeName) || pt.test(e.nodeName) && e.href ? 0 : -1
                }
            }
        },
        propFix: {
            for: "htmlFor",
            class: "className"
        }
    }),
    m.optSelected || (S.propHooks.selected = {
        get: function(e) {
            var t = e.parentNode;
            return t && t.parentNode && t.parentNode.selectedIndex,
            null
        },
        set: function(e) {
            var t = e.parentNode;
            t && (t.selectedIndex, t.parentNode && t.parentNode.selectedIndex)
        }
    }),
    S.each(["tabIndex", "readOnly", "maxLength", "cellSpacing", "cellPadding", "rowSpan", "colSpan", "useMap", "frameBorder", "contentEditable"],
    function() {
        S.propFix[this.toLowerCase()] = this
    }),
    S.fn.extend({
        addClass: function(t) {
            var e, n, r, i, o, a, s, l = 0;
            if (y(t)) return this.each(function(e) {
                S(this).addClass(t.call(this, e, gt(this)))
            });
            if ((e = vt(t)).length) for (; n = this[l++];) if (i = gt(n), r = 1 === n.nodeType && " " + dt(i) + " ") {
                for (a = 0; o = e[a++];) r.indexOf(" " + o + " ") < 0 && (r += o + " ");
                i !== (s = dt(r)) && n.setAttribute("class", s)
            }
            return this
        },
        removeClass: function(t) {
            var e, n, r, i, o, a, s, l = 0;
            if (y(t)) return this.each(function(e) {
                S(this).removeClass(t.call(this, e, gt(this)))
            });
            if (!arguments.length) return this.attr("class", "");
            if ((e = vt(t)).length) for (; n = this[l++];) if (i = gt(n), r = 1 === n.nodeType && " " + dt(i) + " ") {
                for (a = 0; o = e[a++];) for (; - 1 < r.indexOf(" " + o + " ");) r = r.replace(" " + o + " ", " ");
                i !== (s = dt(r)) && n.setAttribute("class", s)
            }
            return this
        },
        toggleClass: function(i, t) {
            var o = typeof i,
            a = "string" === o || Array.isArray(i);
            return "boolean" == typeof t && a ? t ? this.addClass(i) : this.removeClass(i) : y(i) ? this.each(function(e) {
                S(this).toggleClass(i.call(this, e, gt(this), t), t)
            }) : this.each(function() {
                var e, t, n, r;
                if (a) for (t = 0, n = S(this), r = vt(i); e = r[t++];) n.hasClass(e) ? n.removeClass(e) : n.addClass(e);
                else void 0 !== i && "boolean" !== o || ((e = gt(this)) && J.set(this, "__className__", e), this.setAttribute && this.setAttribute("class", e || !1 === i ? "": J.get(this, "__className__") || ""))
            })
        },
        hasClass: function(e) {
            var t, n, r = 0;
            for (t = " " + e + " "; n = this[r++];) if (1 === n.nodeType && -1 < (" " + dt(gt(n)) + " ").indexOf(t)) return ! 0;
            return ! 1
        }
    });
    var mt = /\r/g;
    S.fn.extend({
        val: function(n) {
            var r, e, i, t = this[0];
            return arguments.length ? (i = y(n), this.each(function(e) {
                var t;
                1 === this.nodeType && (null == (t = i ? n.call(this, e, S(this).val()) : n) ? t = "": "number" == typeof t ? t += "": Array.isArray(t) && (t = S.map(t,
                function(e) {
                    return null == e ? "": e + ""
                })), (r = S.valHooks[this.type] || S.valHooks[this.nodeName.toLowerCase()]) && "set" in r && void 0 !== r.set(this, t, "value") || (this.value = t))
            })) : t ? (r = S.valHooks[t.type] || S.valHooks[t.nodeName.toLowerCase()]) && "get" in r && void 0 !== (e = r.get(t, "value")) ? e: "string" == typeof(e = t.value) ? e.replace(mt, "") : null == e ? "": e: void 0
        }
    }),
    S.extend({
        valHooks: {
            option: {
                get: function(e) {
                    var t = S.find.attr(e, "value");
                    return null != t ? t: dt(S.text(e))
                }
            },
            select: {
                get: function(e) {
                    var t, n, r, i = e.options,
                    o = e.selectedIndex,
                    a = "select-one" === e.type,
                    s = a ? null: [],
                    l = a ? o + 1 : i.length;
                    for (r = o < 0 ? l: a ? o: 0; r < l; r++) if (((n = i[r]).selected || r === o) && !n.disabled && (!n.parentNode.disabled || !A(n.parentNode, "optgroup"))) {
                        if (t = S(n).val(), a) return t;
                        s.push(t)
                    }
                    return s
                },
                set: function(e, t) {
                    for (var n, r, i = e.options,
                    o = S.makeArray(t), a = i.length; a--;)((r = i[a]).selected = -1 < S.inArray(S.valHooks.option.get(r), o)) && (n = !0);
                    return n || (e.selectedIndex = -1),
                    o
                }
            }
        }
    }),
    S.each(["radio", "checkbox"],
    function() {
        S.valHooks[this] = {
            set: function(e, t) {
                if (Array.isArray(t)) return e.checked = -1 < S.inArray(S(e).val(), t)
            }
        },
        m.checkOn || (S.valHooks[this].get = function(e) {
            return null === e.getAttribute("value") ? "on": e.value
        })
    }),
    m.focusin = "onfocusin" in E;
    var yt = /^(?:focusinfocus|focusoutblur)$/,
    bt = function(e) {
        e.stopPropagation()
    };
    S.extend(S.event, {
        trigger: function(e, t, n, r) {
            var i, o, a, s, l, u, c, f, h = [n || C],
            p = v.call(e, "type") ? e.type: e,
            d = v.call(e, "namespace") ? e.namespace.split(".") : [];
            if (o = f = a = n = n || C, 3 !== n.nodeType && 8 !== n.nodeType && !yt.test(p + S.event.triggered) && ( - 1 < p.indexOf(".") && (p = (d = p.split(".")).shift(), d.sort()), l = p.indexOf(":") < 0 && "on" + p, (e = e[S.expando] ? e: new S.Event(p, "object" == typeof e && e)).isTrigger = r ? 2 : 3, e.namespace = d.join("."), e.rnamespace = e.namespace ? new RegExp("(^|\\.)" + d.join("\\.(?:.*\\.|)") + "(\\.|$)") : null, e.result = void 0, e.target || (e.target = n), t = null == t ? [e] : S.makeArray(t, [e]), c = S.event.special[p] || {},
            r || !c.trigger || !1 !== c.trigger.apply(n, t))) {
                if (!r && !c.noBubble && !b(n)) {
                    for (s = c.delegateType || p, yt.test(s + p) || (o = o.parentNode); o; o = o.parentNode) h.push(o),
                    a = o;
                    a === (n.ownerDocument || C) && h.push(a.defaultView || a.parentWindow || E)
                }
                for (i = 0; (o = h[i++]) && !e.isPropagationStopped();) f = o,
                e.type = 1 < i ? s: c.bindType || p,
                (u = (J.get(o, "events") || {})[e.type] && J.get(o, "handle")) && u.apply(o, t),
                (u = l && o[l]) && u.apply && Q(o) && (e.result = u.apply(o, t), !1 === e.result && e.preventDefault());
                return e.type = p,
                r || e.isDefaultPrevented() || c._default && !1 !== c._default.apply(h.pop(), t) || !Q(n) || l && y(n[p]) && !b(n) && ((a = n[l]) && (n[l] = null), S.event.triggered = p, e.isPropagationStopped() && f.addEventListener(p, bt), n[p](), e.isPropagationStopped() && f.removeEventListener(p, bt), S.event.triggered = void 0, a && (n[l] = a)),
                e.result
            }
        },
        simulate: function(e, t, n) {
            var r = S.extend(new S.Event, n, {
                type: e,
                isSimulated: !0
            });
            S.event.trigger(r, null, t)
        }
    }),
    S.fn.extend({
        trigger: function(e, t) {
            return this.each(function() {
                S.event.trigger(e, t, this)
            })
        },
        triggerHandler: function(e, t) {
            var n = this[0];
            if (n) return S.event.trigger(e, t, n, !0)
        }
    }),
    m.focusin || S.each({
        focus: "focusin",
        blur: "focusout"
    },
    function(n, r) {
        var i = function(e) {
            S.event.simulate(r, e.target, S.event.fix(e))
        };
        S.event.special[r] = {
            setup: function() {
                var e = this.ownerDocument || this,
                t = J.access(e, r);
                t || e.addEventListener(n, i, !0),
                J.access(e, r, (t || 0) + 1)
            },
            teardown: function() {
                var e = this.ownerDocument || this,
                t = J.access(e, r) - 1;
                t ? J.access(e, r, t) : (e.removeEventListener(n, i, !0), J.remove(e, r))
            }
        }
    });
    var _t = E.location,
    wt = Date.now(),
    xt = /\?/;
    S.parseXML = function(e) {
        var t;
        if (!e || "string" != typeof e) return null;
        try {
            t = (new E.DOMParser).parseFromString(e, "text/xml")
        } catch(e) {
            t = void 0
        }
        return t && !t.getElementsByTagName("parsererror").length || S.error("Invalid XML: " + e),
        t
    };
    var Et = /\[\]$/,
    Ct = /\r?\n/g,
    St = /^(?:submit|button|image|reset|file)$/i,
    Tt = /^(?:input|select|textarea|keygen)/i;
    function kt(n, e, r, i) {
        var t;
        if (Array.isArray(e)) S.each(e,
        function(e, t) {
            r || Et.test(n) ? i(n, t) : kt(n + "[" + ("object" == typeof t && null != t ? e: "") + "]", t, r, i)
        });
        else if (r || "object" !== w(e)) i(n, e);
        else for (t in e) kt(n + "[" + t + "]", e[t], r, i)
    }
    S.param = function(e, t) {
        var n, r = [],
        i = function(e, t) {
            var n = y(t) ? t() : t;
            r[r.length] = encodeURIComponent(e) + "=" + encodeURIComponent(null == n ? "": n)
        };
        if (Array.isArray(e) || e.jquery && !S.isPlainObject(e)) S.each(e,
        function() {
            i(this.name, this.value)
        });
        else for (n in e) kt(n, e[n], t, i);
        return r.join("&")
    },
    S.fn.extend({
        serialize: function() {
            return S.param(this.serializeArray())
        },
        serializeArray: function() {
            return this.map(function() {
                var e = S.prop(this, "elements");
                return e ? S.makeArray(e) : this
            }).filter(function() {
                var e = this.type;
                return this.name && !S(this).is(":disabled") && Tt.test(this.nodeName) && !St.test(e) && (this.checked || !ue.test(e))
            }).map(function(e, t) {
                var n = S(this).val();
                return null == n ? null: Array.isArray(n) ? S.map(n,
                function(e) {
                    return {
                        name: t.name,
                        value: e.replace(Ct, "\r\n")
                    }
                }) : {
                    name: t.name,
                    value: n.replace(Ct, "\r\n")
                }
            }).get()
        }
    });
    var At = /%20/g,
    Dt = /#.*$/,
    Ot = /([?&])_=[^&]*/,
    jt = /^(.*?):[ \t]*([^\r\n]*)$/gm,
    Nt = /^(?:GET|HEAD)$/,
    It = /^\/\//,
    Lt = {},
    Pt = {},
    qt = "*/".concat("*"),
    Ft = C.createElement("a");
    function Rt(o) {
        return function(e, t) {
            "string" != typeof e && (t = e, e = "*");
            var n, r = 0,
            i = e.toLowerCase().match(q) || [];
            if (y(t)) for (; n = i[r++];)"+" === n[0] ? (n = n.slice(1) || "*", (o[n] = o[n] || []).unshift(t)) : (o[n] = o[n] || []).push(t)
        }
    }
    function Mt(t, i, o, a) {
        var s = {},
        l = t === Pt;
        function u(e) {
            var r;
            return s[e] = !0,
            S.each(t[e] || [],
            function(e, t) {
                var n = t(i, o, a);
                return "string" != typeof n || l || s[n] ? l ? !(r = n) : void 0 : (i.dataTypes.unshift(n), u(n), !1)
            }),
            r
        }
        return u(i.dataTypes[0]) || !s["*"] && u("*")
    }
    function Ht(e, t) {
        var n, r, i = S.ajaxSettings.flatOptions || {};
        for (n in t) void 0 !== t[n] && ((i[n] ? e: r || (r = {}))[n] = t[n]);
        return r && S.extend(!0, e, r),
        e
    }
    Ft.href = _t.href,
    S.extend({
        active: 0,
        lastModified: {},
        etag: {},
        ajaxSettings: {
            url: _t.href,
            type: "GET",
            isLocal: /^(?:about|app|app-storage|.+-extension|file|res|widget):$/.test(_t.protocol),
            global: !0,
            processData: !0,
            async: !0,
            contentType: "application/x-www-form-urlencoded; charset=UTF-8",
            accepts: {
                "*": qt,
                text: "text/plain",
                html: "text/html",
                xml: "application/xml, text/xml",
                json: "application/json, text/javascript"
            },
            contents: {
                xml: /\bxml\b/,
                html: /\bhtml/,
                json: /\bjson\b/
            },
            responseFields: {
                xml: "responseXML",
                text: "responseText",
                json: "responseJSON"
            },
            converters: {
                "* text": String,
                "text html": !0,
                "text json": JSON.parse,
                "text xml": S.parseXML
            },
            flatOptions: {
                url: !0,
                context: !0
            }
        },
        ajaxSetup: function(e, t) {
            return t ? Ht(Ht(e, S.ajaxSettings), t) : Ht(S.ajaxSettings, e)
        },
        ajaxPrefilter: Rt(Lt),
        ajaxTransport: Rt(Pt),
        ajax: function(e, t) {
            "object" == typeof e && (t = e, e = void 0),
            t = t || {};
            var c, f, h, n, p, r, d, g, i, o, v = S.ajaxSetup({},
            t),
            m = v.context || v,
            y = v.context && (m.nodeType || m.jquery) ? S(m) : S.event,
            b = S.Deferred(),
            _ = S.Callbacks("once memory"),
            w = v.statusCode || {},
            a = {},
            s = {},
            l = "canceled",
            x = {
                readyState: 0,
                getResponseHeader: function(e) {
                    var t;
                    if (d) {
                        if (!n) for (n = {}; t = jt.exec(h);) n[t[1].toLowerCase()] = t[2];
                        t = n[e.toLowerCase()]
                    }
                    return null == t ? null: t
                },
                getAllResponseHeaders: function() {
                    return d ? h: null
                },
                setRequestHeader: function(e, t) {
                    return null == d && (e = s[e.toLowerCase()] = s[e.toLowerCase()] || e, a[e] = t),
                    this
                },
                overrideMimeType: function(e) {
                    return null == d && (v.mimeType = e),
                    this
                },
                statusCode: function(e) {
                    var t;
                    if (e) if (d) x.always(e[x.status]);
                    else for (t in e) w[t] = [w[t], e[t]];
                    return this
                },
                abort: function(e) {
                    var t = e || l;
                    return c && c.abort(t),
                    u(0, t),
                    this
                }
            };
            if (b.promise(x), v.url = ((e || v.url || _t.href) + "").replace(It, _t.protocol + "//"), v.type = t.method || t.type || v.method || v.type, v.dataTypes = (v.dataType || "*").toLowerCase().match(q) || [""], null == v.crossDomain) {
                r = C.createElement("a");
                try {
                    r.href = v.url,
                    r.href = r.href,
                    v.crossDomain = Ft.protocol + "//" + Ft.host != r.protocol + "//" + r.host
                } catch(e) {
                    v.crossDomain = !0
                }
            }
            if (v.data && v.processData && "string" != typeof v.data && (v.data = S.param(v.data, v.traditional)), Mt(Lt, v, t, x), d) return x;
            for (i in (g = S.event && v.global) && 0 == S.active++&&S.event.trigger("ajaxStart"), v.type = v.type.toUpperCase(), v.hasContent = !Nt.test(v.type), f = v.url.replace(Dt, ""), v.hasContent ? v.data && v.processData && 0 === (v.contentType || "").indexOf("application/x-www-form-urlencoded") && (v.data = v.data.replace(At, "+")) : (o = v.url.slice(f.length), v.data && (v.processData || "string" == typeof v.data) && (f += (xt.test(f) ? "&": "?") + v.data, delete v.data), !1 === v.cache && (f = f.replace(Ot, "$1"), o = (xt.test(f) ? "&": "?") + "_=" + wt+++o), v.url = f + o), v.ifModified && (S.lastModified[f] && x.setRequestHeader("If-Modified-Since", S.lastModified[f]), S.etag[f] && x.setRequestHeader("If-None-Match", S.etag[f])), (v.data && v.hasContent && !1 !== v.contentType || t.contentType) && x.setRequestHeader("Content-Type", v.contentType), x.setRequestHeader("Accept", v.dataTypes[0] && v.accepts[v.dataTypes[0]] ? v.accepts[v.dataTypes[0]] + ("*" !== v.dataTypes[0] ? ", " + qt + "; q=0.01": "") : v.accepts["*"]), v.headers) x.setRequestHeader(i, v.headers[i]);
            if (v.beforeSend && (!1 === v.beforeSend.call(m, x, v) || d)) return x.abort();
            if (l = "abort", _.add(v.complete), x.done(v.success), x.fail(v.error), c = Mt(Pt, v, t, x)) {
                if (x.readyState = 1, g && y.trigger("ajaxSend", [x, v]), d) return x;
                v.async && 0 < v.timeout && (p = E.setTimeout(function() {
                    x.abort("timeout")
                },
                v.timeout));
                try {
                    d = !1,
                    c.send(a, u)
                } catch(e) {
                    if (d) throw e;
                    u( - 1, e)
                }
            } else u( - 1, "No Transport");
            function u(e, t, n, r) {
                var i, o, a, s, l, u = t;
                d || (d = !0, p && E.clearTimeout(p), c = void 0, h = r || "", x.readyState = 0 < e ? 4 : 0, i = 200 <= e && e < 300 || 304 === e, n && (s = function(e, t, n) {
                    for (var r, i, o, a, s = e.contents,
                    l = e.dataTypes;
                    "*" === l[0];) l.shift(),
                    void 0 === r && (r = e.mimeType || t.getResponseHeader("Content-Type"));
                    if (r) for (i in s) if (s[i] && s[i].test(r)) {
                        l.unshift(i);
                        break
                    }
                    if (l[0] in n) o = l[0];
                    else {
                        for (i in n) {
                            if (!l[0] || e.converters[i + " " + l[0]]) {
                                o = i;
                                break
                            }
                            a || (a = i)
                        }
                        o = o || a
                    }
                    if (o) return o !== l[0] && l.unshift(o),
                    n[o]
                } (v, x, n)), s = function(e, t, n, r) {
                    var i, o, a, s, l, u = {},
                    c = e.dataTypes.slice();
                    if (c[1]) for (a in e.converters) u[a.toLowerCase()] = e.converters[a];
                    for (o = c.shift(); o;) if (e.responseFields[o] && (n[e.responseFields[o]] = t), !l && r && e.dataFilter && (t = e.dataFilter(t, e.dataType)), l = o, o = c.shift()) if ("*" === o) o = l;
                    else if ("*" !== l && l !== o) {
                        if (! (a = u[l + " " + o] || u["* " + o])) for (i in u) if ((s = i.split(" "))[1] === o && (a = u[l + " " + s[0]] || u["* " + s[0]])) { ! 0 === a ? a = u[i] : !0 !== u[i] && (o = s[0], c.unshift(s[1]));
                            break
                        }
                        if (!0 !== a) if (a && e.throws) t = a(t);
                        else try {
                            t = a(t)
                        } catch(e) {
                            return {
                                state: "parsererror",
                                error: a ? e: "No conversion from " + l + " to " + o
                            }
                        }
                    }
                    return {
                        state: "success",
                        data: t
                    }
                } (v, s, x, i), i ? (v.ifModified && ((l = x.getResponseHeader("Last-Modified")) && (S.lastModified[f] = l), (l = x.getResponseHeader("etag")) && (S.etag[f] = l)), 204 === e || "HEAD" === v.type ? u = "nocontent": 304 === e ? u = "notmodified": (u = s.state, o = s.data, i = !(a = s.error))) : (a = u, !e && u || (u = "error", e < 0 && (e = 0))), x.status = e, x.statusText = (t || u) + "", i ? b.resolveWith(m, [o, u, x]) : b.rejectWith(m, [x, u, a]), x.statusCode(w), w = void 0, g && y.trigger(i ? "ajaxSuccess": "ajaxError", [x, v, i ? o: a]), _.fireWith(m, [x, u]), g && (y.trigger("ajaxComplete", [x, v]), --S.active || S.event.trigger("ajaxStop")))
            }
            return x
        },
        getJSON: function(e, t, n) {
            return S.get(e, t, n, "json")
        },
        getScript: function(e, t) {
            return S.get(e, void 0, t, "script")
        }
    }),
    S.each(["get", "post"],
    function(e, i) {
        S[i] = function(e, t, n, r) {
            return y(t) && (r = r || n, n = t, t = void 0),
            S.ajax(S.extend({
                url: e,
                type: i,
                dataType: r,
                data: t,
                success: n
            },
            S.isPlainObject(e) && e))
        }
    }),
    S._evalUrl = function(e) {
        return S.ajax({
            url: e,
            type: "GET",
            dataType: "script",
            cache: !0,
            async: !1,
            global: !1,
            throws: !0
        })
    },
    S.fn.extend({
        wrapAll: function(e) {
            var t;
            return this[0] && (y(e) && (e = e.call(this[0])), t = S(e, this[0].ownerDocument).eq(0).clone(!0), this[0].parentNode && t.insertBefore(this[0]), t.map(function() {
                for (var e = this; e.firstElementChild;) e = e.firstElementChild;
                return e
            }).append(this)),
            this
        },
        wrapInner: function(n) {
            return y(n) ? this.each(function(e) {
                S(this).wrapInner(n.call(this, e))
            }) : this.each(function() {
                var e = S(this),
                t = e.contents();
                t.length ? t.wrapAll(n) : e.append(n)
            })
        },
        wrap: function(t) {
            var n = y(t);
            return this.each(function(e) {
                S(this).wrapAll(n ? t.call(this, e) : t)
            })
        },
        unwrap: function(e) {
            return this.parent(e).not("body").each(function() {
                S(this).replaceWith(this.childNodes)
            }),
            this
        }
    }),
    S.expr.pseudos.hidden = function(e) {
        return ! S.expr.pseudos.visible(e)
    },
    S.expr.pseudos.visible = function(e) {
        return !! (e.offsetWidth || e.offsetHeight || e.getClientRects().length)
    },
    S.ajaxSettings.xhr = function() {
        try {
            return new E.XMLHttpRequest
        } catch(e) {}
    };
    var Bt = {
        0 : 200,
        1223 : 204
    },
    $t = S.ajaxSettings.xhr();
    m.cors = !!$t && "withCredentials" in $t,
    m.ajax = $t = !!$t,
    S.ajaxTransport(function(i) {
        var o, a;
        if (m.cors || $t && !i.crossDomain) return {
            send: function(e, t) {
                var n, r = i.xhr();
                if (r.open(i.type, i.url, i.async, i.username, i.password), i.xhrFields) for (n in i.xhrFields) r[n] = i.xhrFields[n];
                for (n in i.mimeType && r.overrideMimeType && r.overrideMimeType(i.mimeType), i.crossDomain || e["X-Requested-With"] || (e["X-Requested-With"] = "XMLHttpRequest"), e) r.setRequestHeader(n, e[n]);
                o = function(e) {
                    return function() {
                        o && (o = a = r.onload = r.onerror = r.onabort = r.ontimeout = r.onreadystatechange = null, "abort" === e ? r.abort() : "error" === e ? "number" != typeof r.status ? t(0, "error") : t(r.status, r.statusText) : t(Bt[r.status] || r.status, r.statusText, "text" !== (r.responseType || "text") || "string" != typeof r.responseText ? {
                            binary: r.response
                        }: {
                            text: r.responseText
                        },
                        r.getAllResponseHeaders()))
                    }
                },
                r.onload = o(),
                a = r.onerror = r.ontimeout = o("error"),
                void 0 !== r.onabort ? r.onabort = a: r.onreadystatechange = function() {
                    4 === r.readyState && E.setTimeout(function() {
                        o && a()
                    })
                },
                o = o("abort");
                try {
                    r.send(i.hasContent && i.data || null)
                } catch(e) {
                    if (o) throw e
                }
            },
            abort: function() {
                o && o()
            }
        }
    }),
    S.ajaxPrefilter(function(e) {
        e.crossDomain && (e.contents.script = !1)
    }),
    S.ajaxSetup({
        accepts: {
            script: "text/javascript, application/javascript, application/ecmascript, application/x-ecmascript"
        },
        contents: {
            script: /\b(?:java|ecma)script\b/
        },
        converters: {
            "text script": function(e) {
                return S.globalEval(e),
                e
            }
        }
    }),
    S.ajaxPrefilter("script",
    function(e) {
        void 0 === e.cache && (e.cache = !1),
        e.crossDomain && (e.type = "GET")
    }),
    S.ajaxTransport("script",
    function(n) {
        var r, i;
        if (n.crossDomain) return {
            send: function(e, t) {
                r = S("<script>").prop({
                    charset: n.scriptCharset,
                    src: n.url
                }).on("load error", i = function(e) {
                    r.remove(),
                    i = null,
                    e && t("error" === e.type ? 404 : 200, e.type)
                }),
                C.head.appendChild(r[0])
            },
            abort: function() {
                i && i()
            }
        }
    });
    var Wt, Ut = [],
    zt = /(=)\?(?=&|$)|\?\?/;
    S.ajaxSetup({
        jsonp: "callback",
        jsonpCallback: function() {
            var e = Ut.pop() || S.expando + "_" + wt++;
            return this[e] = !0,
            e
        }
    }),
    S.ajaxPrefilter("json jsonp",
    function(e, t, n) {
        var r, i, o, a = !1 !== e.jsonp && (zt.test(e.url) ? "url": "string" == typeof e.data && 0 === (e.contentType || "").indexOf("application/x-www-form-urlencoded") && zt.test(e.data) && "data");
        if (a || "jsonp" === e.dataTypes[0]) return r = e.jsonpCallback = y(e.jsonpCallback) ? e.jsonpCallback() : e.jsonpCallback,
        a ? e[a] = e[a].replace(zt, "$1" + r) : !1 !== e.jsonp && (e.url += (xt.test(e.url) ? "&": "?") + e.jsonp + "=" + r),
        e.converters["script json"] = function() {
            return o || S.error(r + " was not called"),
            o[0]
        },
        e.dataTypes[0] = "json",
        i = E[r],
        E[r] = function() {
            o = arguments
        },
        n.always(function() {
            void 0 === i ? S(E).removeProp(r) : E[r] = i,
            e[r] && (e.jsonpCallback = t.jsonpCallback, Ut.push(r)),
            o && y(i) && i(o[0]),
            o = i = void 0
        }),
        "script"
    }),
    m.createHTMLDocument = ((Wt = C.implementation.createHTMLDocument("").body).innerHTML = "<form></form><form></form>", 2 === Wt.childNodes.length),
    S.parseHTML = function(e, t, n) {
        return "string" != typeof e ? [] : ("boolean" == typeof t && (n = t, t = !1), t || (m.createHTMLDocument ? ((r = (t = C.implementation.createHTMLDocument("")).createElement("base")).href = C.location.href, t.head.appendChild(r)) : t = C), o = !n && [], (i = D.exec(e)) ? [t.createElement(i[1])] : (i = ye([e], t, o), o && o.length && S(o).remove(), S.merge([], i.childNodes)));
        var r, i, o
    }, S.fn.load = function(e, t, n) {
        var r, i, o, a = this,
        s = e.indexOf(" ");
        return - 1 < s && (r = dt(e.slice(s)), e = e.slice(0, s)),
        y(t) ? (n = t, t = void 0) : t && "object" == typeof t && (i = "POST"),
        0 < a.length && S.ajax({
            url: e,
            type: i || "GET",
            dataType: "html",
            data: t
        }).done(function(e) {
            o = arguments,
            a.html(r ? S("<div>").append(S.parseHTML(e)).find(r) : e)
        }).always(n &&
        function(e, t) {
            a.each(function() {
                n.apply(this, o || [e.responseText, t, e])
            })
        }),
        this
    },
    S.each(["ajaxStart", "ajaxStop", "ajaxComplete", "ajaxError", "ajaxSuccess", "ajaxSend"],
    function(e, t) {
        S.fn[t] = function(e) {
            return this.on(t, e)
        }
    }),
    S.expr.pseudos.animated = function(t) {
        return S.grep(S.timers,
        function(e) {
            return t === e.elem
        }).length
    },
    S.offset = {
        setOffset: function(e, t, n) {
            var r, i, o, a, s, l, u = S.css(e, "position"),
            c = S(e),
            f = {};
            "static" === u && (e.style.position = "relative"),
            s = c.offset(),
            o = S.css(e, "top"),
            l = S.css(e, "left"),
            ("absolute" === u || "fixed" === u) && -1 < (o + l).indexOf("auto") ? (a = (r = c.position()).top, i = r.left) : (a = parseFloat(o) || 0, i = parseFloat(l) || 0),
            y(t) && (t = t.call(e, n, S.extend({},
            s))),
            null != t.top && (f.top = t.top - s.top + a),
            null != t.left && (f.left = t.left - s.left + i),
            "using" in t ? t.using.call(e, f) : c.css(f)
        }
    },
    S.fn.extend({
        offset: function(t) {
            if (arguments.length) return void 0 === t ? this: this.each(function(e) {
                S.offset.setOffset(this, t, e)
            });
            var e, n, r = this[0];
            return r ? r.getClientRects().length ? (e = r.getBoundingClientRect(), n = r.ownerDocument.defaultView, {
                top: e.top + n.pageYOffset,
                left: e.left + n.pageXOffset
            }) : {
                top: 0,
                left: 0
            }: void 0
        },
        position: function() {
            if (this[0]) {
                var e, t, n, r = this[0],
                i = {
                    top: 0,
                    left: 0
                };
                if ("fixed" === S.css(r, "position")) t = r.getBoundingClientRect();
                else {
                    for (t = this.offset(), n = r.ownerDocument, e = r.offsetParent || n.documentElement; e && (e === n.body || e === n.documentElement) && "static" === S.css(e, "position");) e = e.parentNode;
                    e && e !== r && 1 === e.nodeType && ((i = S(e).offset()).top += S.css(e, "borderTopWidth", !0), i.left += S.css(e, "borderLeftWidth", !0))
                }
                return {
                    top: t.top - i.top - S.css(r, "marginTop", !0),
                    left: t.left - i.left - S.css(r, "marginLeft", !0)
                }
            }
        },
        offsetParent: function() {
            return this.map(function() {
                for (var e = this.offsetParent; e && "static" === S.css(e, "position");) e = e.offsetParent;
                return e || be
            })
        }
    }),
    S.each({
        scrollLeft: "pageXOffset",
        scrollTop: "pageYOffset"
    },
    function(t, i) {
        var o = "pageYOffset" === i;
        S.fn[t] = function(e) {
            return W(this,
            function(e, t, n) {
                var r;
                if (b(e) ? r = e: 9 === e.nodeType && (r = e.defaultView), void 0 === n) return r ? r[i] : e[t];
                r ? r.scrollTo(o ? r.pageXOffset: n, o ? n: r.pageYOffset) : e[t] = n
            },
            t, e, arguments.length)
        }
    }),
    S.each(["top", "left"],
    function(e, n) {
        S.cssHooks[n] = Be(m.pixelPosition,
        function(e, t) {
            if (t) return t = He(e, n),
            Fe.test(t) ? S(e).position()[n] + "px": t
        })
    }),
    S.each({
        Height: "height",
        Width: "width"
    },
    function(a, s) {
        S.each({
            padding: "inner" + a,
            content: s,
            "": "outer" + a
        },
        function(r, o) {
            S.fn[o] = function(e, t) {
                var n = arguments.length && (r || "boolean" != typeof e),
                i = r || (!0 === e || !0 === t ? "margin": "border");
                return W(this,
                function(e, t, n) {
                    var r;
                    return b(e) ? 0 === o.indexOf("outer") ? e["inner" + a] : e.document.documentElement["client" + a] : 9 === e.nodeType ? (r = e.documentElement, Math.max(e.body["scroll" + a], r["scroll" + a], e.body["offset" + a], r["offset" + a], r["client" + a])) : void 0 === n ? S.css(e, t, i) : S.style(e, t, n, i)
                },
                s, n ? e: void 0, n)
            }
        })
    }),
    S.each("blur focus focusin focusout resize scroll click dblclick mousedown mouseup mousemove mouseover mouseout mouseenter mouseleave change select submit keydown keypress keyup contextmenu".split(" "),
    function(e, n) {
        S.fn[n] = function(e, t) {
            return 0 < arguments.length ? this.on(n, null, e, t) : this.trigger(n)
        }
    }),
    S.fn.extend({
        hover: function(e, t) {
            return this.mouseenter(e).mouseleave(t || e)
        }
    }),
    S.fn.extend({
        bind: function(e, t, n) {
            return this.on(e, null, t, n)
        },
        unbind: function(e, t) {
            return this.off(e, null, t)
        },
        delegate: function(e, t, n, r) {
            return this.on(t, e, n, r)
        },
        undelegate: function(e, t, n) {
            return 1 === arguments.length ? this.off(e, "**") : this.off(t, e || "**", n)
        }
    }),
    S.proxy = function(e, t) {
        var n, r, i;
        if ("string" == typeof t && (n = e[t], t = e, e = n), y(e)) return r = s.call(arguments, 2),
        (i = function() {
            return e.apply(t || this, r.concat(s.call(arguments)))
        }).guid = e.guid = e.guid || S.guid++,
        i
    },
    S.holdReady = function(e) {
        e ? S.readyWait++:S.ready(!0)
    },
    S.isArray = Array.isArray,
    S.parseJSON = JSON.parse,
    S.nodeName = A,
    S.isFunction = y,
    S.isWindow = b,
    S.camelCase = K,
    S.type = w,
    S.now = Date.now,
    S.isNumeric = function(e) {
        var t = S.type(e);
        return ("number" === t || "string" === t) && !isNaN(e - parseFloat(e))
    },
    "function" == typeof define && define.amd && define("jquery", [],
    function() {
        return S
    });
    var Vt = E.jQuery,
    Kt = E.$;
    return S.noConflict = function(e) {
        return E.$ === S && (E.$ = Kt),
        e && E.jQuery === S && (E.jQuery = Vt),
        S
    },
    e || (E.jQuery = E.$ = S),
    S
}),
function() {
    var e = "object" == typeof self && self.self === self && self || "object" == typeof global && global.global === global && global || this || {},
    t = e._,
    r = Array.prototype,
    a = Object.prototype,
    f = "undefined" != typeof Symbol ? Symbol.prototype: null,
    i = r.push,
    l = r.slice,
    h = a.toString,
    o = a.hasOwnProperty,
    n = Array.isArray,
    s = Object.keys,
    u = Object.create,
    c = function() {},
    p = function(e) {
        return e instanceof p ? e: this instanceof p ? void(this._wrapped = e) : new p(e)
    };
    "undefined" == typeof exports || exports.nodeType ? e._ = p: ("undefined" != typeof module && !module.nodeType && module.exports && (exports = module.exports = p), exports._ = p),
    p.VERSION = "1.9.1";
    var d, g = function(i, o, e) {
        if (void 0 === o) return i;
        switch (null == e ? 3 : e) {
        case 1:
            return function(e) {
                return i.call(o, e)
            };
        case 3:
            return function(e, t, n) {
                return i.call(o, e, t, n)
            };
        case 4:
            return function(e, t, n, r) {
                return i.call(o, e, t, n, r)
            }
        }
        return function() {
            return i.apply(o, arguments)
        }
    },
    v = function(e, t, n) {
        return p.iteratee !== d ? p.iteratee(e, t) : null == e ? p.identity: p.isFunction(e) ? g(e, t, n) : p.isObject(e) && !p.isArray(e) ? p.matcher(e) : p.property(e)
    };
    p.iteratee = d = function(e, t) {
        return v(e, t, 1 / 0)
    };
    var m = function(i, o) {
        return o = null == o ? i.length - 1 : +o,
        function() {
            for (var e = Math.max(arguments.length - o, 0), t = Array(e), n = 0; n < e; n++) t[n] = arguments[n + o];
            switch (o) {
            case 0:
                return i.call(this, t);
            case 1:
                return i.call(this, arguments[0], t);
            case 2:
                return i.call(this, arguments[0], arguments[1], t)
            }
            var r = Array(o + 1);
            for (n = 0; n < o; n++) r[n] = arguments[n];
            return r[o] = t,
            i.apply(this, r)
        }
    },
    y = function(e) {
        if (!p.isObject(e)) return {};
        if (u) return u(e);
        c.prototype = e;
        var t = new c;
        return c.prototype = null,
        t
    },
    b = function(t) {
        return function(e) {
            return null == e ? void 0 : e[t]
        }
    },
    _ = function(e, t) {
        return null != e && o.call(e, t)
    },
    w = function(e, t) {
        for (var n = t.length,
        r = 0; r < n; r++) {
            if (null == e) return;
            e = e[t[r]]
        }
        return n ? e: void 0
    },
    x = Math.pow(2, 53) - 1,
    E = b("length"),
    C = function(e) {
        var t = E(e);
        return "number" == typeof t && 0 <= t && t <= x
    };
    p.each = p.forEach = function(e, t, n) {
        var r, i;
        if (t = g(t, n), C(e)) for (r = 0, i = e.length; r < i; r++) t(e[r], r, e);
        else {
            var o = p.keys(e);
            for (r = 0, i = o.length; r < i; r++) t(e[o[r]], o[r], e)
        }
        return e
    },
    p.map = p.collect = function(e, t, n) {
        t = v(t, n);
        for (var r = !C(e) && p.keys(e), i = (r || e).length, o = Array(i), a = 0; a < i; a++) {
            var s = r ? r[a] : a;
            o[a] = t(e[s], s, e)
        }
        return o
    };
    var S = function(l) {
        return function(e, t, n, r) {
            var i = 3 <= arguments.length;
            return function(e, t, n, r) {
                var i = !C(e) && p.keys(e),
                o = (i || e).length,
                a = 0 < l ? 0 : o - 1;
                for (r || (n = e[i ? i[a] : a], a += l); 0 <= a && a < o; a += l) {
                    var s = i ? i[a] : a;
                    n = t(n, e[s], s, e)
                }
                return n
            } (e, g(t, r, 4), n, i)
        }
    };
    p.reduce = p.foldl = p.inject = S(1),
    p.reduceRight = p.foldr = S( - 1),
    p.find = p.detect = function(e, t, n) {
        var r = (C(e) ? p.findIndex: p.findKey)(e, t, n);
        if (void 0 !== r && -1 !== r) return e[r]
    },
    p.filter = p.select = function(e, r, t) {
        var i = [];
        return r = v(r, t),
        p.each(e,
        function(e, t, n) {
            r(e, t, n) && i.push(e)
        }),
        i
    },
    p.reject = function(e, t, n) {
        return p.filter(e, p.negate(v(t)), n)
    },
    p.every = p.all = function(e, t, n) {
        t = v(t, n);
        for (var r = !C(e) && p.keys(e), i = (r || e).length, o = 0; o < i; o++) {
            var a = r ? r[o] : o;
            if (!t(e[a], a, e)) return ! 1
        }
        return ! 0
    },
    p.some = p.any = function(e, t, n) {
        t = v(t, n);
        for (var r = !C(e) && p.keys(e), i = (r || e).length, o = 0; o < i; o++) {
            var a = r ? r[o] : o;
            if (t(e[a], a, e)) return ! 0
        }
        return ! 1
    },
    p.contains = p.includes = p.include = function(e, t, n, r) {
        return C(e) || (e = p.values(e)),
        ("number" != typeof n || r) && (n = 0),
        0 <= p.indexOf(e, t, n)
    },
    p.invoke = m(function(e, n, r) {
        var i, o;
        return p.isFunction(n) ? o = n: p.isArray(n) && (i = n.slice(0, -1), n = n[n.length - 1]),
        p.map(e,
        function(e) {
            var t = o;
            if (!t) {
                if (i && i.length && (e = w(e, i)), null == e) return;
                t = e[n]
            }
            return null == t ? t: t.apply(e, r)
        })
    }),
    p.pluck = function(e, t) {
        return p.map(e, p.property(t))
    },
    p.where = function(e, t) {
        return p.filter(e, p.matcher(t))
    },
    p.findWhere = function(e, t) {
        return p.find(e, p.matcher(t))
    },
    p.max = function(e, r, t) {
        var n, i, o = -1 / 0,
        a = -1 / 0;
        if (null == r || "number" == typeof r && "object" != typeof e[0] && null != e) for (var s = 0,
        l = (e = C(e) ? e: p.values(e)).length; s < l; s++) null != (n = e[s]) && o < n && (o = n);
        else r = v(r, t),
        p.each(e,
        function(e, t, n) {
            i = r(e, t, n),
            (a < i || i === -1 / 0 && o === -1 / 0) && (o = e, a = i)
        });
        return o
    },
    p.min = function(e, r, t) {
        var n, i, o = 1 / 0,
        a = 1 / 0;
        if (null == r || "number" == typeof r && "object" != typeof e[0] && null != e) for (var s = 0,
        l = (e = C(e) ? e: p.values(e)).length; s < l; s++) null != (n = e[s]) && n < o && (o = n);
        else r = v(r, t),
        p.each(e,
        function(e, t, n) { ((i = r(e, t, n)) < a || i === 1 / 0 && o === 1 / 0) && (o = e, a = i)
        });
        return o
    },
    p.shuffle = function(e) {
        return p.sample(e, 1 / 0)
    },
    p.sample = function(e, t, n) {
        if (null == t || n) return C(e) || (e = p.values(e)),
        e[p.random(e.length - 1)];
        var r = C(e) ? p.clone(e) : p.values(e),
        i = E(r);
        t = Math.max(Math.min(t, i), 0);
        for (var o = i - 1,
        a = 0; a < t; a++) {
            var s = p.random(a, o),
            l = r[a];
            r[a] = r[s],
            r[s] = l
        }
        return r.slice(0, t)
    },
    p.sortBy = function(e, r, t) {
        var i = 0;
        return r = v(r, t),
        p.pluck(p.map(e,
        function(e, t, n) {
            return {
                value: e,
                index: i++,
                criteria: r(e, t, n)
            }
        }).sort(function(e, t) {
            var n = e.criteria,
            r = t.criteria;
            if (n !== r) {
                if (r < n || void 0 === n) return 1;
                if (n < r || void 0 === r) return - 1
            }
            return e.index - t.index
        }), "value")
    };
    var T = function(a, t) {
        return function(r, i, e) {
            var o = t ? [[], []] : {};
            return i = v(i, e),
            p.each(r,
            function(e, t) {
                var n = i(e, t, r);
                a(o, e, n)
            }),
            o
        }
    };
    p.groupBy = T(function(e, t, n) {
        _(e, n) ? e[n].push(t) : e[n] = [t]
    }),
    p.indexBy = T(function(e, t, n) {
        e[n] = t
    }),
    p.countBy = T(function(e, t, n) {
        _(e, n) ? e[n]++:e[n] = 1
    });
    var k = /[^\ud800-\udfff]|[\ud800-\udbff][\udc00-\udfff]|[\ud800-\udfff]/g;
    p.toArray = function(e) {
        return e ? p.isArray(e) ? l.call(e) : p.isString(e) ? e.match(k) : C(e) ? p.map(e, p.identity) : p.values(e) : []
    },
    p.size = function(e) {
        return null == e ? 0 : C(e) ? e.length: p.keys(e).length
    },
    p.partition = T(function(e, t, n) {
        e[n ? 0 : 1].push(t)
    },
    !0),
    p.first = p.head = p.take = function(e, t, n) {
        return null == e || e.length < 1 ? null == t ? void 0 : [] : null == t || n ? e[0] : p.initial(e, e.length - t)
    },
    p.initial = function(e, t, n) {
        return l.call(e, 0, Math.max(0, e.length - (null == t || n ? 1 : t)))
    },
    p.last = function(e, t, n) {
        return null == e || e.length < 1 ? null == t ? void 0 : [] : null == t || n ? e[e.length - 1] : p.rest(e, Math.max(0, e.length - t))
    },
    p.rest = p.tail = p.drop = function(e, t, n) {
        return l.call(e, null == t || n ? 1 : t)
    },
    p.compact = function(e) {
        return p.filter(e, Boolean)
    };
    var A = function(e, t, n, r) {
        for (var i = (r = r || []).length, o = 0, a = E(e); o < a; o++) {
            var s = e[o];
            if (C(s) && (p.isArray(s) || p.isArguments(s))) if (t) for (var l = 0,
            u = s.length; l < u;) r[i++] = s[l++];
            else A(s, t, n, r),
            i = r.length;
            else n || (r[i++] = s)
        }
        return r
    };
    p.flatten = function(e, t) {
        return A(e, t, !1)
    },
    p.without = m(function(e, t) {
        return p.difference(e, t)
    }),
    p.uniq = p.unique = function(e, t, n, r) {
        p.isBoolean(t) || (r = n, n = t, t = !1),
        null != n && (n = v(n, r));
        for (var i = [], o = [], a = 0, s = E(e); a < s; a++) {
            var l = e[a],
            u = n ? n(l, a, e) : l;
            t && !n ? (a && o === u || i.push(l), o = u) : n ? p.contains(o, u) || (o.push(u), i.push(l)) : p.contains(i, l) || i.push(l)
        }
        return i
    },
    p.union = m(function(e) {
        return p.uniq(A(e, !0, !0))
    }),
    p.intersection = function(e) {
        for (var t = [], n = arguments.length, r = 0, i = E(e); r < i; r++) {
            var o = e[r];
            if (!p.contains(t, o)) {
                var a;
                for (a = 1; a < n && p.contains(arguments[a], o); a++);
                a === n && t.push(o)
            }
        }
        return t
    },
    p.difference = m(function(e, t) {
        return t = A(t, !0, !0),
        p.filter(e,
        function(e) {
            return ! p.contains(t, e)
        })
    }),
    p.unzip = function(e) {
        for (var t = e && p.max(e, E).length || 0, n = Array(t), r = 0; r < t; r++) n[r] = p.pluck(e, r);
        return n
    },
    p.zip = m(p.unzip),
    p.object = function(e, t) {
        for (var n = {},
        r = 0,
        i = E(e); r < i; r++) t ? n[e[r]] = t[r] : n[e[r][0]] = e[r][1];
        return n
    };
    var D = function(o) {
        return function(e, t, n) {
            t = v(t, n);
            for (var r = E(e), i = 0 < o ? 0 : r - 1; 0 <= i && i < r; i += o) if (t(e[i], i, e)) return i;
            return - 1
        }
    };
    p.findIndex = D(1),
    p.findLastIndex = D( - 1),
    p.sortedIndex = function(e, t, n, r) {
        for (var i = (n = v(n, r, 1))(t), o = 0, a = E(e); o < a;) {
            var s = Math.floor((o + a) / 2);
            n(e[s]) < i ? o = s + 1 : a = s
        }
        return o
    };
    var O = function(o, a, s) {
        return function(e, t, n) {
            var r = 0,
            i = E(e);
            if ("number" == typeof n) 0 < o ? r = 0 <= n ? n: Math.max(n + i, r) : i = 0 <= n ? Math.min(n + 1, i) : n + i + 1;
            else if (s && n && i) return e[n = s(e, t)] === t ? n: -1;
            if (t != t) return 0 <= (n = a(l.call(e, r, i), p.isNaN)) ? n + r: -1;
            for (n = 0 < o ? r: i - 1; 0 <= n && n < i; n += o) if (e[n] === t) return n;
            return - 1
        }
    };
    p.indexOf = O(1, p.findIndex, p.sortedIndex),
    p.lastIndexOf = O( - 1, p.findLastIndex),
    p.range = function(e, t, n) {
        null == t && (t = e || 0, e = 0),
        n || (n = t < e ? -1 : 1);
        for (var r = Math.max(Math.ceil((t - e) / n), 0), i = Array(r), o = 0; o < r; o++, e += n) i[o] = e;
        return i
    },
    p.chunk = function(e, t) {
        if (null == t || t < 1) return [];
        for (var n = [], r = 0, i = e.length; r < i;) n.push(l.call(e, r, r += t));
        return n
    };
    var j = function(e, t, n, r, i) {
        if (! (r instanceof t)) return e.apply(n, i);
        var o = y(e.prototype),
        a = e.apply(o, i);
        return p.isObject(a) ? a: o
    };
    p.bind = m(function(t, n, r) {
        if (!p.isFunction(t)) throw new TypeError("Bind must be called on a function");
        var i = m(function(e) {
            return j(t, i, n, this, r.concat(e))
        });
        return i
    }),
    p.partial = m(function(i, o) {
        var a = p.partial.placeholder,
        s = function() {
            for (var e = 0,
            t = o.length,
            n = Array(t), r = 0; r < t; r++) n[r] = o[r] === a ? arguments[e++] : o[r];
            for (; e < arguments.length;) n.push(arguments[e++]);
            return j(i, s, this, this, n)
        };
        return s
    }),
    (p.partial.placeholder = p).bindAll = m(function(e, t) {
        var n = (t = A(t, !1, !1)).length;
        if (n < 1) throw new Error("bindAll must be passed function names");
        for (; n--;) {
            var r = t[n];
            e[r] = p.bind(e[r], e)
        }
    }),
    p.memoize = function(r, i) {
        var o = function(e) {
            var t = o.cache,
            n = "" + (i ? i.apply(this, arguments) : e);
            return _(t, n) || (t[n] = r.apply(this, arguments)),
            t[n]
        };
        return o.cache = {},
        o
    },
    p.delay = m(function(e, t, n) {
        return setTimeout(function() {
            return e.apply(null, n)
        },
        t)
    }),
    p.defer = p.partial(p.delay, p, 1),
    p.throttle = function(n, r, i) {
        var o, a, s, l, u = 0;
        i || (i = {});
        var c = function() {
            u = !1 === i.leading ? 0 : p.now(),
            o = null,
            l = n.apply(a, s),
            o || (a = s = null)
        },
        e = function() {
            var e = p.now();
            u || !1 !== i.leading || (u = e);
            var t = r - (e - u);
            return a = this,
            s = arguments,
            t <= 0 || r < t ? (o && (clearTimeout(o), o = null), u = e, l = n.apply(a, s), o || (a = s = null)) : o || !1 === i.trailing || (o = setTimeout(c, t)),
            l
        };
        return e.cancel = function() {
            clearTimeout(o),
            u = 0,
            o = a = s = null
        },
        e
    },
    p.debounce = function(n, r, i) {
        var o, a, s = function(e, t) {
            o = null,
            t && (a = n.apply(e, t))
        },
        e = m(function(e) {
            if (o && clearTimeout(o), i) {
                var t = !o;
                o = setTimeout(s, r),
                t && (a = n.apply(this, e))
            } else o = p.delay(s, r, this, e);
            return a
        });
        return e.cancel = function() {
            clearTimeout(o),
            o = null
        },
        e
    },
    p.wrap = function(e, t) {
        return p.partial(t, e)
    },
    p.negate = function(e) {
        return function() {
            return ! e.apply(this, arguments)
        }
    },
    p.compose = function() {
        var n = arguments,
        r = n.length - 1;
        return function() {
            for (var e = r,
            t = n[r].apply(this, arguments); e--;) t = n[e].call(this, t);
            return t
        }
    },
    p.after = function(e, t) {
        return function() {
            if (--e < 1) return t.apply(this, arguments)
        }
    },
    p.before = function(e, t) {
        var n;
        return function() {
            return 0 < --e && (n = t.apply(this, arguments)),
            e <= 1 && (t = null),
            n
        }
    },
    p.once = p.partial(p.before, 2),
    p.restArguments = m;
    var N = !{
        toString: null
    }.propertyIsEnumerable("toString"),
    I = ["valueOf", "isPrototypeOf", "toString", "propertyIsEnumerable", "hasOwnProperty", "toLocaleString"],
    L = function(e, t) {
        var n = I.length,
        r = e.constructor,
        i = p.isFunction(r) && r.prototype || a,
        o = "constructor";
        for (_(e, o) && !p.contains(t, o) && t.push(o); n--;)(o = I[n]) in e && e[o] !== i[o] && !p.contains(t, o) && t.push(o)
    };
    p.keys = function(e) {
        if (!p.isObject(e)) return [];
        if (s) return s(e);
        var t = [];
        for (var n in e) _(e, n) && t.push(n);
        return N && L(e, t),
        t
    },
    p.allKeys = function(e) {
        if (!p.isObject(e)) return [];
        var t = [];
        for (var n in e) t.push(n);
        return N && L(e, t),
        t
    },
    p.values = function(e) {
        for (var t = p.keys(e), n = t.length, r = Array(n), i = 0; i < n; i++) r[i] = e[t[i]];
        return r
    },
    p.mapObject = function(e, t, n) {
        t = v(t, n);
        for (var r = p.keys(e), i = r.length, o = {},
        a = 0; a < i; a++) {
            var s = r[a];
            o[s] = t(e[s], s, e)
        }
        return o
    },
    p.pairs = function(e) {
        for (var t = p.keys(e), n = t.length, r = Array(n), i = 0; i < n; i++) r[i] = [t[i], e[t[i]]];
        return r
    },
    p.invert = function(e) {
        for (var t = {},
        n = p.keys(e), r = 0, i = n.length; r < i; r++) t[e[n[r]]] = n[r];
        return t
    },
    p.functions = p.methods = function(e) {
        var t = [];
        for (var n in e) p.isFunction(e[n]) && t.push(n);
        return t.sort()
    };
    var P = function(l, u) {
        return function(e) {
            var t = arguments.length;
            if (u && (e = Object(e)), t < 2 || null == e) return e;
            for (var n = 1; n < t; n++) for (var r = arguments[n], i = l(r), o = i.length, a = 0; a < o; a++) {
                var s = i[a];
                u && void 0 !== e[s] || (e[s] = r[s])
            }
            return e
        }
    };
    p.extend = P(p.allKeys),
    p.extendOwn = p.assign = P(p.keys),
    p.findKey = function(e, t, n) {
        t = v(t, n);
        for (var r, i = p.keys(e), o = 0, a = i.length; o < a; o++) if (t(e[r = i[o]], r, e)) return r
    };
    var q, F, R = function(e, t, n) {
        return t in n
    };
    p.pick = m(function(e, t) {
        var n = {},
        r = t[0];
        if (null == e) return n;
        p.isFunction(r) ? (1 < t.length && (r = g(r, t[1])), t = p.allKeys(e)) : (r = R, t = A(t, !1, !1), e = Object(e));
        for (var i = 0,
        o = t.length; i < o; i++) {
            var a = t[i],
            s = e[a];
            r(s, a, e) && (n[a] = s)
        }
        return n
    }),
    p.omit = m(function(e, n) {
        var t, r = n[0];
        return p.isFunction(r) ? (r = p.negate(r), 1 < n.length && (t = n[1])) : (n = p.map(A(n, !1, !1), String), r = function(e, t) {
            return ! p.contains(n, t)
        }),
        p.pick(e, r, t)
    }),
    p.defaults = P(p.allKeys, !0),
    p.create = function(e, t) {
        var n = y(e);
        return t && p.extendOwn(n, t),
        n
    },
    p.clone = function(e) {
        return p.isObject(e) ? p.isArray(e) ? e.slice() : p.extend({},
        e) : e
    },
    p.tap = function(e, t) {
        return t(e),
        e
    },
    p.isMatch = function(e, t) {
        var n = p.keys(t),
        r = n.length;
        if (null == e) return ! r;
        for (var i = Object(e), o = 0; o < r; o++) {
            var a = n[o];
            if (t[a] !== i[a] || !(a in i)) return ! 1
        }
        return ! 0
    },
    q = function(e, t, n, r) {
        if (e === t) return 0 !== e || 1 / e == 1 / t;
        if (null == e || null == t) return ! 1;
        if (e != e) return t != t;
        var i = typeof e;
        return ("function" === i || "object" === i || "object" == typeof t) && F(e, t, n, r)
    },
    F = function(e, t, n, r) {
        e instanceof p && (e = e._wrapped),
        t instanceof p && (t = t._wrapped);
        var i = h.call(e);
        if (i !== h.call(t)) return ! 1;
        switch (i) {
        case "[object RegExp]":
        case "[object String]":
            return "" + e == "" + t;
        case "[object Number]":
            return + e != +e ? +t != +t: 0 == +e ? 1 / +e == 1 / t: +e == +t;
        case "[object Date]":
        case "[object Boolean]":
            return + e == +t;
        case "[object Symbol]":
            return f.valueOf.call(e) === f.valueOf.call(t)
        }
        var o = "[object Array]" === i;
        if (!o) {
            if ("object" != typeof e || "object" != typeof t) return ! 1;
            var a = e.constructor,
            s = t.constructor;
            if (a !== s && !(p.isFunction(a) && a instanceof a && p.isFunction(s) && s instanceof s) && "constructor" in e && "constructor" in t) return ! 1
        }
        r = r || [];
        for (var l = (n = n || []).length; l--;) if (n[l] === e) return r[l] === t;
        if (n.push(e), r.push(t), o) {
            if ((l = e.length) !== t.length) return ! 1;
            for (; l--;) if (!q(e[l], t[l], n, r)) return ! 1
        } else {
            var u, c = p.keys(e);
            if (l = c.length, p.keys(t).length !== l) return ! 1;
            for (; l--;) if (u = c[l], !_(t, u) || !q(e[u], t[u], n, r)) return ! 1
        }
        return n.pop(),
        r.pop(),
        !0
    },
    p.isEqual = function(e, t) {
        return q(e, t)
    },
    p.isEmpty = function(e) {
        return null == e || (C(e) && (p.isArray(e) || p.isString(e) || p.isArguments(e)) ? 0 === e.length: 0 === p.keys(e).length)
    },
    p.isElement = function(e) {
        return ! (!e || 1 !== e.nodeType)
    },
    p.isArray = n ||
    function(e) {
        return "[object Array]" === h.call(e)
    },
    p.isObject = function(e) {
        var t = typeof e;
        return "function" === t || "object" === t && !!e
    },
    p.each(["Arguments", "Function", "String", "Number", "Date", "RegExp", "Error", "Symbol", "Map", "WeakMap", "Set", "WeakSet"],
    function(t) {
        p["is" + t] = function(e) {
            return h.call(e) === "[object " + t + "]"
        }
    }),
    p.isArguments(arguments) || (p.isArguments = function(e) {
        return _(e, "callee")
    });
    var M = e.document && e.document.childNodes;
    "function" != typeof / . / &&"object" != typeof Int8Array && "function" != typeof M && (p.isFunction = function(e) {
        return "function" == typeof e || !1
    }),
    p.isFinite = function(e) {
        return ! p.isSymbol(e) && isFinite(e) && !isNaN(parseFloat(e))
    },
    p.isNaN = function(e) {
        return p.isNumber(e) && isNaN(e)
    },
    p.isBoolean = function(e) {
        return ! 0 === e || !1 === e || "[object Boolean]" === h.call(e)
    },
    p.isNull = function(e) {
        return null === e
    },
    p.isUndefined = function(e) {
        return void 0 === e
    },
    p.has = function(e, t) {
        if (!p.isArray(t)) return _(e, t);
        for (var n = t.length,
        r = 0; r < n; r++) {
            var i = t[r];
            if (null == e || !o.call(e, i)) return ! 1;
            e = e[i]
        }
        return !! n
    },
    p.noConflict = function() {
        return e._ = t,
        this
    },
    p.identity = function(e) {
        return e
    },
    p.constant = function(e) {
        return function() {
            return e
        }
    },
    p.noop = function() {},
    p.property = function(t) {
        return p.isArray(t) ?
        function(e) {
            return w(e, t)
        }: b(t)
    },
    p.propertyOf = function(t) {
        return null == t ?
        function() {}: function(e) {
            return p.isArray(e) ? w(t, e) : t[e]
        }
    },
    p.matcher = p.matches = function(t) {
        return t = p.extendOwn({},
        t),
        function(e) {
            return p.isMatch(e, t)
        }
    },
    p.times = function(e, t, n) {
        var r = Array(Math.max(0, e));
        t = g(t, n, 1);
        for (var i = 0; i < e; i++) r[i] = t(i);
        return r
    },
    p.random = function(e, t) {
        return null == t && (t = e, e = 0),
        e + Math.floor(Math.random() * (t - e + 1))
    },
    p.now = Date.now ||
    function() {
        return (new Date).getTime()
    };
    var H = {
        "&": "&amp;",
        "<": "&lt;",
        ">": "&gt;",
        '"': "&quot;",
        "'": "&#x27;",
        "`": "&#x60;"
    },
    B = p.invert(H),
    $ = function(t) {
        var n = function(e) {
            return t[e]
        },
        e = "(?:" + p.keys(t).join("|") + ")",
        r = RegExp(e),
        i = RegExp(e, "g");
        return function(e) {
            return e = null == e ? "": "" + e,
            r.test(e) ? e.replace(i, n) : e
        }
    };
    p.escape = $(H),
    p.unescape = $(B),
    p.result = function(e, t, n) {
        p.isArray(t) || (t = [t]);
        var r = t.length;
        if (!r) return p.isFunction(n) ? n.call(e) : n;
        for (var i = 0; i < r; i++) {
            var o = null == e ? void 0 : e[t[i]];
            void 0 === o && (o = n, i = r),
            e = p.isFunction(o) ? o.call(e) : o
        }
        return e
    };
    var W = 0;
    p.uniqueId = function(e) {
        var t = ++W + "";
        return e ? e + t: t
    },
    p.templateSettings = {
        evaluate: /<%([\s\S]+?)%>/g,
        interpolate: /<%=([\s\S]+?)%>/g,
        escape: /<%-([\s\S]+?)%>/g
    };
    var U = /(.)^/,
    z = {
        "'": "'",
        "\\": "\\",
        "\r": "r",
        "\n": "n",
        "\u2028": "u2028",
        "\u2029": "u2029"
    },
    V = /\\|'|\r|\n|\u2028|\u2029/g,
    K = function(e) {
        return "\\" + z[e]
    };
    p.template = function(o, e, t) { ! e && t && (e = t),
        e = p.defaults({},
        e, p.templateSettings);
        var n, r = RegExp([(e.escape || U).source, (e.interpolate || U).source, (e.evaluate || U).source].join("|") + "|$", "g"),
        a = 0,
        s = "__p+='";
        o.replace(r,
        function(e, t, n, r, i) {
            return s += o.slice(a, i).replace(V, K),
            a = i + e.length,
            t ? s += "'+\n((__t=(" + t + "))==null?'':_.escape(__t))+\n'": n ? s += "'+\n((__t=(" + n + "))==null?'':__t)+\n'": r && (s += "';\n" + r + "\n__p+='"),
            e
        }),
        s += "';\n",
        e.variable || (s = "with(obj||{}){\n" + s + "}\n"),
        s = "var __t,__p='',__j=Array.prototype.join,print=function(){__p+=__j.call(arguments,'');};\n" + s + "return __p;\n";
        try {
            n = new Function(e.variable || "obj", "_", s)
        } catch(e) {
            throw e.source = s,
            e
        }
        var i = function(e) {
            return n.call(this, e, p)
        },
        l = e.variable || "obj";
        return i.source = "function(" + l + "){\n" + s + "}",
        i
    },
    p.chain = function(e) {
        var t = p(e);
        return t._chain = !0,
        t
    };
    var Q = function(e, t) {
        return e._chain ? p(t).chain() : t
    };
    p.mixin = function(n) {
        return p.each(p.functions(n),
        function(e) {
            var t = p[e] = n[e];
            p.prototype[e] = function() {
                var e = [this._wrapped];
                return i.apply(e, arguments),
                Q(this, t.apply(p, e))
            }
        }),
        p
    },
    p.mixin(p),
    p.each(["pop", "push", "reverse", "shift", "sort", "splice", "unshift"],
    function(t) {
        var n = r[t];
        p.prototype[t] = function() {
            var e = this._wrapped;
            return n.apply(e, arguments),
            "shift" !== t && "splice" !== t || 0 !== e.length || delete e[0],
            Q(this, e)
        }
    }),
    p.each(["concat", "join", "slice"],
    function(e) {
        var t = r[e];
        p.prototype[e] = function() {
            return Q(this, t.apply(this._wrapped, arguments))
        }
    }),
    p.prototype.value = function() {
        return this._wrapped
    },
    p.prototype.valueOf = p.prototype.toJSON = p.prototype.value,
    p.prototype.toString = function() {
        return String(this._wrapped)
    },
    "function" == typeof define && define.amd && define("underscore", [],
    function() {
        return p
    })
} (),
function(e, t) {
    "object" == typeof exports && "undefined" != typeof module ? module.exports = t() : "function" == typeof define && define.amd ? define(t) : e.Popper = t()
} (this,
function() {
    "use strict";
    for (var e = "undefined" != typeof window && "undefined" != typeof document,
    t = ["Edge", "Trident", "Firefox"], n = 0, r = 0; r < t.length; r += 1) if (e && 0 <= navigator.userAgent.indexOf(t[r])) {
        n = 1;
        break
    }
    var a = e && window.Promise ?
    function(e) {
        var t = !1;
        return function() {
            t || (t = !0, window.Promise.resolve().then(function() {
                t = !1,
                e()
            }))
        }
    }: function(e) {
        var t = !1;
        return function() {
            t || (t = !0, setTimeout(function() {
                t = !1,
                e()
            },
            n))
        }
    };
    function s(e) {
        return e && "[object Function]" === {}.toString.call(e)
    }
    function _(e, t) {
        if (1 !== e.nodeType) return [];
        var n = getComputedStyle(e, null);
        return t ? n[t] : n
    }
    function p(e) {
        return "HTML" === e.nodeName ? e: e.parentNode || e.host
    }
    function d(e) {
        if (!e) return document.body;
        switch (e.nodeName) {
        case "HTML":
        case "BODY":
            return e.ownerDocument.body;
        case "#document":
            return e.body
        }
        var t = _(e),
        n = t.overflow,
        r = t.overflowX,
        i = t.overflowY;
        return /(auto|scroll|overlay)/.test(n + i + r) ? e: d(p(e))
    }
    var i = e && !(!window.MSInputMethodContext || !document.documentMode),
    o = e && /MSIE 10/.test(navigator.userAgent);
    function g(e) {
        return 11 === e ? i: 10 === e ? o: i || o
    }
    function b(e) {
        if (!e) return document.documentElement;
        for (var t = g(10) ? document.body: null, n = e.offsetParent; n === t && e.nextElementSibling;) n = (e = e.nextElementSibling).offsetParent;
        var r = n && n.nodeName;
        return r && "BODY" !== r && "HTML" !== r ? -1 !== ["TD", "TABLE"].indexOf(n.nodeName) && "static" === _(n, "position") ? b(n) : n: e ? e.ownerDocument.documentElement: document.documentElement
    }
    function c(e) {
        return null !== e.parentNode ? c(e.parentNode) : e
    }
    function v(e, t) {
        if (! (e && e.nodeType && t && t.nodeType)) return document.documentElement;
        var n = e.compareDocumentPosition(t) & Node.DOCUMENT_POSITION_FOLLOWING,
        r = n ? e: t,
        i = n ? t: e,
        o = document.createRange();
        o.setStart(r, 0),
        o.setEnd(i, 0);
        var a, s, l = o.commonAncestorContainer;
        if (e !== l && t !== l || r.contains(i)) return "BODY" === (s = (a = l).nodeName) || "HTML" !== s && b(a.firstElementChild) !== a ? b(l) : l;
        var u = c(e);
        return u.host ? v(u.host, t) : v(e, c(t).host)
    }
    function m(e) {
        var t = "top" === (1 < arguments.length && void 0 !== arguments[1] ? arguments[1] : "top") ? "scrollTop": "scrollLeft",
        n = e.nodeName;
        if ("BODY" === n || "HTML" === n) {
            var r = e.ownerDocument.documentElement;
            return (e.ownerDocument.scrollingElement || r)[t]
        }
        return e[t]
    }
    function f(e, t) {
        var n = "x" === t ? "Left": "Top",
        r = "Left" === n ? "Right": "Bottom";
        return parseFloat(e["border" + n + "Width"], 10) + parseFloat(e["border" + r + "Width"], 10)
    }
    function l(e, t, n, r) {
        return Math.max(t["offset" + e], t["scroll" + e], n["client" + e], n["offset" + e], n["scroll" + e], g(10) ? parseInt(n["offset" + e]) + parseInt(r["margin" + ("Height" === e ? "Top": "Left")]) + parseInt(r["margin" + ("Height" === e ? "Bottom": "Right")]) : 0)
    }
    function y(e) {
        var t = e.body,
        n = e.documentElement,
        r = g(10) && getComputedStyle(n);
        return {
            height: l("Height", t, n, r),
            width: l("Width", t, n, r)
        }
    }
    var u = function() {
        function r(e, t) {
            for (var n = 0; n < t.length; n++) {
                var r = t[n];
                r.enumerable = r.enumerable || !1,
                r.configurable = !0,
                "value" in r && (r.writable = !0),
                Object.defineProperty(e, r.key, r)
            }
        }
        return function(e, t, n) {
            return t && r(e.prototype, t),
            n && r(e, n),
            e
        }
    } (),
    w = function(e, t, n) {
        return t in e ? Object.defineProperty(e, t, {
            value: n,
            enumerable: !0,
            configurable: !0,
            writable: !0
        }) : e[t] = n,
        e
    },
    x = Object.assign ||
    function(e) {
        for (var t = 1; t < arguments.length; t++) {
            var n = arguments[t];
            for (var r in n) Object.prototype.hasOwnProperty.call(n, r) && (e[r] = n[r])
        }
        return e
    };
    function E(e) {
        return x({},
        e, {
            right: e.left + e.width,
            bottom: e.top + e.height
        })
    }
    function C(e) {
        var t = {};
        try {
            if (g(10)) {
                t = e.getBoundingClientRect();
                var n = m(e, "top"),
                r = m(e, "left");
                t.top += n,
                t.left += r,
                t.bottom += n,
                t.right += r
            } else t = e.getBoundingClientRect()
        } catch(e) {}
        var i = {
            left: t.left,
            top: t.top,
            width: t.right - t.left,
            height: t.bottom - t.top
        },
        o = "HTML" === e.nodeName ? y(e.ownerDocument) : {},
        a = o.width || e.clientWidth || i.right - i.left,
        s = o.height || e.clientHeight || i.bottom - i.top,
        l = e.offsetWidth - a,
        u = e.offsetHeight - s;
        if (l || u) {
            var c = _(e);
            l -= f(c, "x"),
            u -= f(c, "y"),
            i.width -= l,
            i.height -= u
        }
        return E(i)
    }
    function S(e, t) {
        var n = 2 < arguments.length && void 0 !== arguments[2] && arguments[2],
        r = g(10),
        i = "HTML" === t.nodeName,
        o = C(e),
        a = C(t),
        s = d(e),
        l = _(t),
        u = parseFloat(l.borderTopWidth, 10),
        c = parseFloat(l.borderLeftWidth, 10);
        n && i && (a.top = Math.max(a.top, 0), a.left = Math.max(a.left, 0));
        var f = E({
            top: o.top - a.top - u,
            left: o.left - a.left - c,
            width: o.width,
            height: o.height
        });
        if (f.marginTop = 0, f.marginLeft = 0, !r && i) {
            var h = parseFloat(l.marginTop, 10),
            p = parseFloat(l.marginLeft, 10);
            f.top -= u - h,
            f.bottom -= u - h,
            f.left -= c - p,
            f.right -= c - p,
            f.marginTop = h,
            f.marginLeft = p
        }
        return (r && !n ? t.contains(s) : t === s && "BODY" !== s.nodeName) && (f = function(e, t) {
            var n = 2 < arguments.length && void 0 !== arguments[2] && arguments[2],
            r = m(t, "top"),
            i = m(t, "left"),
            o = n ? -1 : 1;
            return e.top += r * o,
            e.bottom += r * o,
            e.left += i * o,
            e.right += i * o,
            e
        } (f, t)),
        f
    }
    function T(e) {
        if (!e || !e.parentElement || g()) return document.documentElement;
        for (var t = e.parentElement; t && "none" === _(t, "transform");) t = t.parentElement;
        return t || document.documentElement
    }
    function h(e, t, n, r) {
        var i = 4 < arguments.length && void 0 !== arguments[4] && arguments[4],
        o = {
            top: 0,
            left: 0
        },
        a = i ? T(e) : v(e, t);
        if ("viewport" === r) o = function(e) {
            var t = 1 < arguments.length && void 0 !== arguments[1] && arguments[1],
            n = e.ownerDocument.documentElement,
            r = S(e, n),
            i = Math.max(n.clientWidth, window.innerWidth || 0),
            o = Math.max(n.clientHeight, window.innerHeight || 0),
            a = t ? 0 : m(n),
            s = t ? 0 : m(n, "left");
            return E({
                top: a - r.top + r.marginTop,
                left: s - r.left + r.marginLeft,
                width: i,
                height: o
            })
        } (a, i);
        else {
            var s = void 0;
            "scrollParent" === r ? "BODY" === (s = d(p(t))).nodeName && (s = e.ownerDocument.documentElement) : s = "window" === r ? e.ownerDocument.documentElement: r;
            var l = S(s, a, i);
            if ("HTML" !== s.nodeName ||
            function e(t) {
                var n = t.nodeName;
                return "BODY" !== n && "HTML" !== n && ("fixed" === _(t, "position") || e(p(t)))
            } (a)) o = l;
            else {
                var u = y(e.ownerDocument),
                c = u.height,
                f = u.width;
                o.top += l.top - l.marginTop,
                o.bottom = c + l.top,
                o.left += l.left - l.marginLeft,
                o.right = f + l.left
            }
        }
        var h = "number" == typeof(n = n || 0);
        return o.left += h ? n: n.left || 0,
        o.top += h ? n: n.top || 0,
        o.right -= h ? n: n.right || 0,
        o.bottom -= h ? n: n.bottom || 0,
        o
    }
    function k(e, t, r, n, i) {
        var o = 5 < arguments.length && void 0 !== arguments[5] ? arguments[5] : 0;
        if ( - 1 === e.indexOf("auto")) return e;
        var a = h(r, n, o, i),
        s = {
            top: {
                width: a.width,
                height: t.top - a.top
            },
            right: {
                width: a.right - t.right,
                height: a.height
            },
            bottom: {
                width: a.width,
                height: a.bottom - t.bottom
            },
            left: {
                width: t.left - a.left,
                height: a.height
            }
        },
        l = Object.keys(s).map(function(e) {
            return x({
                key: e
            },
            s[e], {
                area: (t = s[e], t.width * t.height)
            });
            var t
        }).sort(function(e, t) {
            return t.area - e.area
        }),
        u = l.filter(function(e) {
            var t = e.width,
            n = e.height;
            return t >= r.clientWidth && n >= r.clientHeight
        }),
        c = 0 < u.length ? u[0].key: l[0].key,
        f = e.split("-")[1];
        return c + (f ? "-" + f: "")
    }
    function A(e, t, n) {
        var r = 3 < arguments.length && void 0 !== arguments[3] ? arguments[3] : null;
        return S(n, r ? T(t) : v(t, n), r)
    }
    function D(e) {
        var t = getComputedStyle(e),
        n = parseFloat(t.marginTop) + parseFloat(t.marginBottom),
        r = parseFloat(t.marginLeft) + parseFloat(t.marginRight);
        return {
            width: e.offsetWidth + r,
            height: e.offsetHeight + n
        }
    }
    function O(e) {
        var t = {
            left: "right",
            right: "left",
            bottom: "top",
            top: "bottom"
        };
        return e.replace(/left|right|bottom|top/g,
        function(e) {
            return t[e]
        })
    }
    function j(e, t, n) {
        n = n.split("-")[0];
        var r = D(e),
        i = {
            width: r.width,
            height: r.height
        },
        o = -1 !== ["right", "left"].indexOf(n),
        a = o ? "top": "left",
        s = o ? "left": "top",
        l = o ? "height": "width",
        u = o ? "width": "height";
        return i[a] = t[a] + t[l] / 2 - r[l] / 2,
        i[s] = n === s ? t[s] - r[u] : t[O(s)],
        i
    }
    function N(e, t) {
        return Array.prototype.find ? e.find(t) : e.filter(t)[0]
    }
    function I(e, n, t) {
        return (void 0 === t ? e: e.slice(0,
        function(e, t, n) {
            if (Array.prototype.findIndex) return e.findIndex(function(e) {
                return e[t] === n
            });
            var r = N(e,
            function(e) {
                return e[t] === n
            });
            return e.indexOf(r)
        } (e, "name", t))).forEach(function(e) {
            e.
            function && console.warn("`modifier.function` is deprecated, use `modifier.fn`!");
            var t = e.
            function || e.fn;
            e.enabled && s(t) && (n.offsets.popper = E(n.offsets.popper), n.offsets.reference = E(n.offsets.reference), n = t(n, e))
        }),
        n
    }
    function L(e, n) {
        return e.some(function(e) {
            var t = e.name;
            return e.enabled && t === n
        })
    }
    function P(e) {
        for (var t = [!1, "ms", "Webkit", "Moz", "O"], n = e.charAt(0).toUpperCase() + e.slice(1), r = 0; r < t.length; r++) {
            var i = t[r],
            o = i ? "" + i + n: e;
            if (void 0 !== document.body.style[o]) return o
        }
        return null
    }
    function q(e) {
        var t = e.ownerDocument;
        return t ? t.defaultView: window
    }
    function F(e, t, n, r) {
        n.updateBound = r,
        q(e).addEventListener("resize", n.updateBound, {
            passive: !0
        });
        var i = d(e);
        return function e(t, n, r, i) {
            var o = "BODY" === t.nodeName,
            a = o ? t.ownerDocument.defaultView: t;
            a.addEventListener(n, r, {
                passive: !0
            }),
            o || e(d(a.parentNode), n, r, i),
            i.push(a)
        } (i, "scroll", n.updateBound, n.scrollParents),
        n.scrollElement = i,
        n.eventsEnabled = !0,
        n
    }
    function R() {
        var e, t;
        this.state.eventsEnabled && (cancelAnimationFrame(this.scheduleUpdate), this.state = (e = this.reference, t = this.state, q(e).removeEventListener("resize", t.updateBound), t.scrollParents.forEach(function(e) {
            e.removeEventListener("scroll", t.updateBound)
        }), t.updateBound = null, t.scrollParents = [], t.scrollElement = null, t.eventsEnabled = !1, t))
    }
    function M(e) {
        return "" !== e && !isNaN(parseFloat(e)) && isFinite(e)
    }
    function H(n, r) {
        Object.keys(r).forEach(function(e) {
            var t = ""; - 1 !== ["width", "height", "top", "right", "bottom", "left"].indexOf(e) && M(r[e]) && (t = "px"),
            n.style[e] = r[e] + t
        })
    }
    function B(e, t, n) {
        var r = N(e,
        function(e) {
            return e.name === t
        }),
        i = !!r && e.some(function(e) {
            return e.name === n && e.enabled && e.order < r.order
        });
        if (!i) {
            var o = "`" + t + "`",
            a = "`" + n + "`";
            console.warn(a + " modifier is required by " + o + " modifier in order to work, be sure to include it before " + o + "!")
        }
        return i
    }
    var $ = ["auto-start", "auto", "auto-end", "top-start", "top", "top-end", "right-start", "right", "right-end", "bottom-end", "bottom", "bottom-start", "left-end", "left", "left-start"],
    W = $.slice(3);
    function U(e) {
        var t = 1 < arguments.length && void 0 !== arguments[1] && arguments[1],
        n = W.indexOf(e),
        r = W.slice(n + 1).concat(W.slice(0, n));
        return t ? r.reverse() : r
    }
    var z = "flip",
    V = "clockwise",
    K = "counterclockwise";
    function Q(e, i, o, t) {
        var a = [0, 0],
        s = -1 !== ["right", "left"].indexOf(t),
        n = e.split(/(\+|\-)/).map(function(e) {
            return e.trim()
        }),
        r = n.indexOf(N(n,
        function(e) {
            return - 1 !== e.search(/,|\s/)
        }));
        n[r] && -1 === n[r].indexOf(",") && console.warn("Offsets separated by white space(s) are deprecated, use a comma (,) instead.");
        var l = /\s*,\s*|\s+/,
        u = -1 !== r ? [n.slice(0, r).concat([n[r].split(l)[0]]), [n[r].split(l)[1]].concat(n.slice(r + 1))] : [n];
        return (u = u.map(function(e, t) {
            var n = (1 === t ? !s: s) ? "height": "width",
            r = !1;
            return e.reduce(function(e, t) {
                return "" === e[e.length - 1] && -1 !== ["+", "-"].indexOf(t) ? (e[e.length - 1] = t, r = !0, e) : r ? (e[e.length - 1] += t, r = !1, e) : e.concat(t)
            },
            []).map(function(e) {
                return function(e, t, n, r) {
                    var i = e.match(/((?:\-|\+)?\d*\.?\d*)(.*)/),
                    o = +i[1],
                    a = i[2];
                    if (!o) return e;
                    if (0 === a.indexOf("%")) {
                        var s = void 0;
                        switch (a) {
                        case "%p":
                            s = n;
                            break;
                        case "%":
                        case "%r":
                        default:
                            s = r
                        }
                        return E(s)[t] / 100 * o
                    }
                    if ("vh" === a || "vw" === a) return ("vh" === a ? Math.max(document.documentElement.clientHeight, window.innerHeight || 0) : Math.max(document.documentElement.clientWidth, window.innerWidth || 0)) / 100 * o;
                    return o
                } (e, n, i, o)
            })
        })).forEach(function(n, r) {
            n.forEach(function(e, t) {
                M(e) && (a[r] += e * ("-" === n[t - 1] ? -1 : 1))
            })
        }),
        a
    }
    var Y = {
        placement: "bottom",
        positionFixed: !1,
        eventsEnabled: !0,
        removeOnDestroy: !1,
        onCreate: function() {},
        onUpdate: function() {},
        modifiers: {
            shift: {
                order: 100,
                enabled: !0,
                fn: function(e) {
                    var t = e.placement,
                    n = t.split("-")[0],
                    r = t.split("-")[1];
                    if (r) {
                        var i = e.offsets,
                        o = i.reference,
                        a = i.popper,
                        s = -1 !== ["bottom", "top"].indexOf(n),
                        l = s ? "left": "top",
                        u = s ? "width": "height",
                        c = {
                            start: w({},
                            l, o[l]),
                            end: w({},
                            l, o[l] + o[u] - a[u])
                        };
                        e.offsets.popper = x({},
                        a, c[r])
                    }
                    return e
                }
            },
            offset: {
                order: 200,
                enabled: !0,
                fn: function(e, t) {
                    var n = t.offset,
                    r = e.placement,
                    i = e.offsets,
                    o = i.popper,
                    a = i.reference,
                    s = r.split("-")[0],
                    l = void 0;
                    return l = M( + n) ? [ + n, 0] : Q(n, o, a, s),
                    "left" === s ? (o.top += l[0], o.left -= l[1]) : "right" === s ? (o.top += l[0], o.left += l[1]) : "top" === s ? (o.left += l[0], o.top -= l[1]) : "bottom" === s && (o.left += l[0], o.top += l[1]),
                    e.popper = o,
                    e
                },
                offset: 0
            },
            preventOverflow: {
                order: 300,
                enabled: !0,
                fn: function(e, r) {
                    var t = r.boundariesElement || b(e.instance.popper);
                    e.instance.reference === t && (t = b(t));
                    var n = P("transform"),
                    i = e.instance.popper.style,
                    o = i.top,
                    a = i.left,
                    s = i[n];
                    i.top = "",
                    i.left = "",
                    i[n] = "";
                    var l = h(e.instance.popper, e.instance.reference, r.padding, t, e.positionFixed);
                    i.top = o,
                    i.left = a,
                    i[n] = s,
                    r.boundaries = l;
                    var u = r.priority,
                    c = e.offsets.popper,
                    f = {
                        primary: function(e) {
                            var t = c[e];
                            return c[e] < l[e] && !r.escapeWithReference && (t = Math.max(c[e], l[e])),
                            w({},
                            e, t)
                        },
                        secondary: function(e) {
                            var t = "right" === e ? "left": "top",
                            n = c[t];
                            return c[e] > l[e] && !r.escapeWithReference && (n = Math.min(c[t], l[e] - ("right" === e ? c.width: c.height))),
                            w({},
                            t, n)
                        }
                    };
                    return u.forEach(function(e) {
                        var t = -1 !== ["left", "top"].indexOf(e) ? "primary": "secondary";
                        c = x({},
                        c, f[t](e))
                    }),
                    e.offsets.popper = c,
                    e
                },
                priority: ["left", "right", "top", "bottom"],
                padding: 5,
                boundariesElement: "scrollParent"
            },
            keepTogether: {
                order: 400,
                enabled: !0,
                fn: function(e) {
                    var t = e.offsets,
                    n = t.popper,
                    r = t.reference,
                    i = e.placement.split("-")[0],
                    o = Math.floor,
                    a = -1 !== ["top", "bottom"].indexOf(i),
                    s = a ? "right": "bottom",
                    l = a ? "left": "top",
                    u = a ? "width": "height";
                    return n[s] < o(r[l]) && (e.offsets.popper[l] = o(r[l]) - n[u]),
                    n[l] > o(r[s]) && (e.offsets.popper[l] = o(r[s])),
                    e
                }
            },
            arrow: {
                order: 500,
                enabled: !0,
                fn: function(e, t) {
                    var n;
                    if (!B(e.instance.modifiers, "arrow", "keepTogether")) return e;
                    var r = t.element;
                    if ("string" == typeof r) {
                        if (! (r = e.instance.popper.querySelector(r))) return e
                    } else if (!e.instance.popper.contains(r)) return console.warn("WARNING: `arrow.element` must be child of its popper element!"),
                    e;
                    var i = e.placement.split("-")[0],
                    o = e.offsets,
                    a = o.popper,
                    s = o.reference,
                    l = -1 !== ["left", "right"].indexOf(i),
                    u = l ? "height": "width",
                    c = l ? "Top": "Left",
                    f = c.toLowerCase(),
                    h = l ? "left": "top",
                    p = l ? "bottom": "right",
                    d = D(r)[u];
                    s[p] - d < a[f] && (e.offsets.popper[f] -= a[f] - (s[p] - d)),
                    s[f] + d > a[p] && (e.offsets.popper[f] += s[f] + d - a[p]),
                    e.offsets.popper = E(e.offsets.popper);
                    var g = s[f] + s[u] / 2 - d / 2,
                    v = _(e.instance.popper),
                    m = parseFloat(v["margin" + c], 10),
                    y = parseFloat(v["border" + c + "Width"], 10),
                    b = g - e.offsets.popper[f] - m - y;
                    return b = Math.max(Math.min(a[u] - d, b), 0),
                    e.arrowElement = r,
                    e.offsets.arrow = (w(n = {},
                    f, Math.round(b)), w(n, h, ""), n),
                    e
                },
                element: "[x-arrow]"
            },
            flip: {
                order: 600,
                enabled: !0,
                fn: function(d, g) {
                    if (L(d.instance.modifiers, "inner")) return d;
                    if (d.flipped && d.placement === d.originalPlacement) return d;
                    var v = h(d.instance.popper, d.instance.reference, g.padding, g.boundariesElement, d.positionFixed),
                    m = d.placement.split("-")[0],
                    y = O(m),
                    b = d.placement.split("-")[1] || "",
                    _ = [];
                    switch (g.behavior) {
                    case z:
                        _ = [m, y];
                        break;
                    case V:
                        _ = U(m);
                        break;
                    case K:
                        _ = U(m, !0);
                        break;
                    default:
                        _ = g.behavior
                    }
                    return _.forEach(function(e, t) {
                        if (m !== e || _.length === t + 1) return d;
                        m = d.placement.split("-")[0],
                        y = O(m);
                        var n, r = d.offsets.popper,
                        i = d.offsets.reference,
                        o = Math.floor,
                        a = "left" === m && o(r.right) > o(i.left) || "right" === m && o(r.left) < o(i.right) || "top" === m && o(r.bottom) > o(i.top) || "bottom" === m && o(r.top) < o(i.bottom),
                        s = o(r.left) < o(v.left),
                        l = o(r.right) > o(v.right),
                        u = o(r.top) < o(v.top),
                        c = o(r.bottom) > o(v.bottom),
                        f = "left" === m && s || "right" === m && l || "top" === m && u || "bottom" === m && c,
                        h = -1 !== ["top", "bottom"].indexOf(m),
                        p = !!g.flipVariations && (h && "start" === b && s || h && "end" === b && l || !h && "start" === b && u || !h && "end" === b && c); (a || f || p) && (d.flipped = !0, (a || f) && (m = _[t + 1]), p && (b = "end" === (n = b) ? "start": "start" === n ? "end": n), d.placement = m + (b ? "-" + b: ""), d.offsets.popper = x({},
                        d.offsets.popper, j(d.instance.popper, d.offsets.reference, d.placement)), d = I(d.instance.modifiers, d, "flip"))
                    }),
                    d
                },
                behavior: "flip",
                padding: 5,
                boundariesElement: "viewport"
            },
            inner: {
                order: 700,
                enabled: !1,
                fn: function(e) {
                    var t = e.placement,
                    n = t.split("-")[0],
                    r = e.offsets,
                    i = r.popper,
                    o = r.reference,
                    a = -1 !== ["left", "right"].indexOf(n),
                    s = -1 === ["top", "left"].indexOf(n);
                    return i[a ? "left": "top"] = o[n] - (s ? i[a ? "width": "height"] : 0),
                    e.placement = O(t),
                    e.offsets.popper = E(i),
                    e
                }
            },
            hide: {
                order: 800,
                enabled: !0,
                fn: function(e) {
                    if (!B(e.instance.modifiers, "hide", "preventOverflow")) return e;
                    var t = e.offsets.reference,
                    n = N(e.instance.modifiers,
                    function(e) {
                        return "preventOverflow" === e.name
                    }).boundaries;
                    if (t.bottom < n.top || t.left > n.right || t.top > n.bottom || t.right < n.left) {
                        if (!0 === e.hide) return e;
                        e.hide = !0,
                        e.attributes["x-out-of-boundaries"] = ""
                    } else {
                        if (!1 === e.hide) return e;
                        e.hide = !1,
                        e.attributes["x-out-of-boundaries"] = !1
                    }
                    return e
                }
            },
            computeStyle: {
                order: 850,
                enabled: !0,
                fn: function(e, t) {
                    var n = t.x,
                    r = t.y,
                    i = e.offsets.popper,
                    o = N(e.instance.modifiers,
                    function(e) {
                        return "applyStyle" === e.name
                    }).gpuAcceleration;
                    void 0 !== o && console.warn("WARNING: `gpuAcceleration` option moved to `computeStyle` modifier and will not be supported in future versions of Popper.js!");
                    var a = void 0 !== o ? o: t.gpuAcceleration,
                    s = b(e.instance.popper),
                    l = C(s),
                    u = {
                        position: i.position
                    },
                    c = {
                        left: Math.floor(i.left),
                        top: Math.round(i.top),
                        bottom: Math.round(i.bottom),
                        right: Math.floor(i.right)
                    },
                    f = "bottom" === n ? "top": "bottom",
                    h = "right" === r ? "left": "right",
                    p = P("transform"),
                    d = void 0,
                    g = void 0;
                    if (g = "bottom" === f ? "HTML" === s.nodeName ? -s.clientHeight + c.bottom: -l.height + c.bottom: c.top, d = "right" === h ? "HTML" === s.nodeName ? -s.clientWidth + c.right: -l.width + c.right: c.left, a && p) u[p] = "translate3d(" + d + "px, " + g + "px, 0)",
                    u[f] = 0,
                    u[h] = 0,
                    u.willChange = "transform";
                    else {
                        var v = "bottom" === f ? -1 : 1,
                        m = "right" === h ? -1 : 1;
                        u[f] = g * v,
                        u[h] = d * m,
                        u.willChange = f + ", " + h
                    }
                    var y = {
                        "x-placement": e.placement
                    };
                    return e.attributes = x({},
                    y, e.attributes),
                    e.styles = x({},
                    u, e.styles),
                    e.arrowStyles = x({},
                    e.offsets.arrow, e.arrowStyles),
                    e
                },
                gpuAcceleration: !0,
                x: "bottom",
                y: "right"
            },
            applyStyle: {
                order: 900,
                enabled: !0,
                fn: function(e) {
                    var t, n;
                    return H(e.instance.popper, e.styles),
                    t = e.instance.popper,
                    n = e.attributes,
                    Object.keys(n).forEach(function(e) { ! 1 !== n[e] ? t.setAttribute(e, n[e]) : t.removeAttribute(e)
                    }),
                    e.arrowElement && Object.keys(e.arrowStyles).length && H(e.arrowElement, e.arrowStyles),
                    e
                },
                onLoad: function(e, t, n, r, i) {
                    var o = A(i, t, e, n.positionFixed),
                    a = k(n.placement, o, t, e, n.modifiers.flip.boundariesElement, n.modifiers.flip.padding);
                    return t.setAttribute("x-placement", a),
                    H(t, {
                        position: n.positionFixed ? "fixed": "absolute"
                    }),
                    n
                },
                gpuAcceleration: void 0
            }
        }
    },
    J = function() {
        function o(e, t) {
            var n = this,
            r = 2 < arguments.length && void 0 !== arguments[2] ? arguments[2] : {}; !
            function(e, t) {
                if (! (e instanceof t)) throw new TypeError("Cannot call a class as a function")
            } (this, o),
            this.scheduleUpdate = function() {
                return requestAnimationFrame(n.update)
            },
            this.update = a(this.update.bind(this)),
            this.options = x({},
            o.Defaults, r),
            this.state = {
                isDestroyed: !1,
                isCreated: !1,
                scrollParents: []
            },
            this.reference = e && e.jquery ? e[0] : e,
            this.popper = t && t.jquery ? t[0] : t,
            this.options.modifiers = {},
            Object.keys(x({},
            o.Defaults.modifiers, r.modifiers)).forEach(function(e) {
                n.options.modifiers[e] = x({},
                o.Defaults.modifiers[e] || {},
                r.modifiers ? r.modifiers[e] : {})
            }),
            this.modifiers = Object.keys(this.options.modifiers).map(function(e) {
                return x({
                    name: e
                },
                n.options.modifiers[e])
            }).sort(function(e, t) {
                return e.order - t.order
            }),
            this.modifiers.forEach(function(e) {
                e.enabled && s(e.onLoad) && e.onLoad(n.reference, n.popper, n.options, e, n.state)
            }),
            this.update();
            var i = this.options.eventsEnabled;
            i && this.enableEventListeners(),
            this.state.eventsEnabled = i
        }
        return u(o, [{
            key: "update",
            value: function() {
                return function() {
                    if (!this.state.isDestroyed) {
                        var e = {
                            instance: this,
                            styles: {},
                            arrowStyles: {},
                            attributes: {},
                            flipped: !1,
                            offsets: {}
                        };
                        e.offsets.reference = A(this.state, this.popper, this.reference, this.options.positionFixed),
                        e.placement = k(this.options.placement, e.offsets.reference, this.popper, this.reference, this.options.modifiers.flip.boundariesElement, this.options.modifiers.flip.padding),
                        e.originalPlacement = e.placement,
                        e.positionFixed = this.options.positionFixed,
                        e.offsets.popper = j(this.popper, e.offsets.reference, e.placement),
                        e.offsets.popper.position = this.options.positionFixed ? "fixed": "absolute",
                        e = I(this.modifiers, e),
                        this.state.isCreated ? this.options.onUpdate(e) : (this.state.isCreated = !0, this.options.onCreate(e))
                    }
                }.call(this)
            }
        },
        {
            key: "destroy",
            value: function() {
                return function() {
                    return this.state.isDestroyed = !0,
                    L(this.modifiers, "applyStyle") && (this.popper.removeAttribute("x-placement"), this.popper.style.position = "", this.popper.style.top = "", this.popper.style.left = "", this.popper.style.right = "", this.popper.style.bottom = "", this.popper.style.willChange = "", this.popper.style[P("transform")] = ""),
                    this.disableEventListeners(),
                    this.options.removeOnDestroy && this.popper.parentNode.removeChild(this.popper),
                    this
                }.call(this)
            }
        },
        {
            key: "enableEventListeners",
            value: function() {
                return function() {
                    this.state.eventsEnabled || (this.state = F(this.reference, this.options, this.state, this.scheduleUpdate))
                }.call(this)
            }
        },
        {
            key: "disableEventListeners",
            value: function() {
                return R.call(this)
            }
        }]),
        o
    } ();
    return J.Utils = ("undefined" != typeof window ? window: global).PopperUtils,
    J.placements = $,
    J.Defaults = Y,
    J
}),
function(e, t) {
    "object" == typeof exports && "undefined" != typeof module ? t(exports, require("jquery"), require("popper.js")) : "function" == typeof define && define.amd ? define(["exports", "jquery", "popper.js"], t) : t(e.bootstrap = {},
    e.jQuery, e.Popper)
} (this,
function(e, t, c) {
    "use strict";
    function r(e, t) {
        for (var n = 0; n < t.length; n++) {
            var r = t[n];
            r.enumerable = r.enumerable || !1,
            r.configurable = !0,
            "value" in r && (r.writable = !0),
            Object.defineProperty(e, r.key, r)
        }
    }
    function a(e, t, n) {
        return t && r(e.prototype, t),
        n && r(e, n),
        e
    }
    function l(i) {
        for (var e = 1; e < arguments.length; e++) {
            var o = null != arguments[e] ? arguments[e] : {},
            t = Object.keys(o);
            "function" == typeof Object.getOwnPropertySymbols && (t = t.concat(Object.getOwnPropertySymbols(o).filter(function(e) {
                return Object.getOwnPropertyDescriptor(o, e).enumerable
            }))),
            t.forEach(function(e) {
                var t, n, r;
                t = i,
                r = o[n = e],
                n in t ? Object.defineProperty(t, n, {
                    value: r,
                    enumerable: !0,
                    configurable: !0,
                    writable: !0
                }) : t[n] = r
            })
        }
        return i
    }
    t = t && t.hasOwnProperty("default") ? t.
default:
    t,
    c = c && c.hasOwnProperty("default") ? c.
default:
    c;
    var i, n, o, s, u, f, h, p, d, g, v, m, y, b, _, w, x, E, C, S, T, k, A, D, O, j, N, I, L, P, q, F, R, M, H, B, $, W, U, z, V, K, Q, Y, J, X, G, Z, ee, te, ne, re, ie, oe, ae, se, le, ue, ce, fe, he, pe, de, ge, ve, me, ye, be, _e, we, xe, Ee, Ce, Se, Te, ke, Ae, De, Oe, je, Ne, Ie, Le, Pe, qe, Fe, Re, Me, He, Be, $e, We, Ue, ze, Ve, Ke, Qe, Ye, Je, Xe, Ge, Ze, et, tt, nt, rt, it, ot, at, st, lt, ut, ct, ft, ht, pt, dt, gt, vt, mt, yt, bt, _t, wt, xt, Et, Ct, St, Tt, kt, At, Dt, Ot, jt, Nt, It, Lt, Pt, qt, Ft, Rt, Mt, Ht, Bt, $t, Wt, Ut, zt, Vt, Kt, Qt, Yt, Jt, Xt, Gt, Zt, en, tn, nn, rn, on, an, sn, ln, un, cn, fn, hn, pn, dn, gn, vn, mn, yn, bn, _n, wn, xn, En, Cn, Sn, Tn, kn, An, Dn, On, jn, Nn, In, Ln, Pn, qn, Fn, Rn, Mn, Hn, Bn = function(r) {
        var t = "transitionend";
        function e(e) {
            var t = this,
            n = !1;
            return r(this).one(l.TRANSITION_END,
            function() {
                n = !0
            }),
            setTimeout(function() {
                n || l.triggerTransitionEnd(t)
            },
            e),
            this
        }
        var l = {
            TRANSITION_END: "bsTransitionEnd",
            getUID: function(e) {
                for (; e += ~~ (1e6 * Math.random()), document.getElementById(e););
                return e
            },
            getSelectorFromElement: function(e) {
                var t = e.getAttribute("data-target");
                t && "#" !== t || (t = e.getAttribute("href") || "");
                try {
                    return document.querySelector(t) ? t: null
                } catch(e) {
                    return null
                }
            },
            getTransitionDurationFromElement: function(e) {
                if (!e) return 0;
                var t = r(e).css("transition-duration");
                return parseFloat(t) ? (t = t.split(",")[0], 1e3 * parseFloat(t)) : 0
            },
            reflow: function(e) {
                return e.offsetHeight
            },
            triggerTransitionEnd: function(e) {
                r(e).trigger(t)
            },
            supportsTransitionEnd: function() {
                return Boolean(t)
            },
            isElement: function(e) {
                return (e[0] || e).nodeType
            },
            typeCheckConfig: function(e, t, n) {
                for (var r in n) if (Object.prototype.hasOwnProperty.call(n, r)) {
                    var i = n[r],
                    o = t[r],
                    a = o && l.isElement(o) ? "element": (s = o, {}.toString.call(s).match(/\s([a-z]+)/i)[1].toLowerCase());
                    if (!new RegExp(i).test(a)) throw new Error(e.toUpperCase() + ': Option "' + r + '" provided type "' + a + '" but expected type "' + i + '".')
                }
                var s
            }
        };
        return r.fn.emulateTransitionEnd = e,
        r.event.special[l.TRANSITION_END] = {
            bindType: t,
            delegateType: t,
            handle: function(e) {
                if (r(e.target).is(this)) return e.handleObj.handler.apply(this, arguments)
            }
        },
        l
    } (t),
    $n = (n = "alert", s = "." + (o = "bs.alert"), u = (i = t).fn[n], f = {
        CLOSE: "close" + s,
        CLOSED: "closed" + s,
        CLICK_DATA_API: "click" + s + ".data-api"
    },
    h = "alert", p = "fade", d = "show", g = function() {
        function r(e) {
            this._element = e
        }
        var e = r.prototype;
        return e.close = function(e) {
            var t = this._element;
            e && (t = this._getRootElement(e)),
            this._triggerCloseEvent(t).isDefaultPrevented() || this._removeElement(t)
        },
        e.dispose = function() {
            i.removeData(this._element, o),
            this._element = null
        },
        e._getRootElement = function(e) {
            var t = Bn.getSelectorFromElement(e),
            n = !1;
            return t && (n = document.querySelector(t)),
            n || (n = i(e).closest("." + h)[0]),
            n
        },
        e._triggerCloseEvent = function(e) {
            var t = i.Event(f.CLOSE);
            return i(e).trigger(t),
            t
        },
        e._removeElement = function(t) {
            var n = this;
            if (i(t).removeClass(d), i(t).hasClass(p)) {
                var e = Bn.getTransitionDurationFromElement(t);
                i(t).one(Bn.TRANSITION_END,
                function(e) {
                    return n._destroyElement(t, e)
                }).emulateTransitionEnd(e)
            } else this._destroyElement(t)
        },
        e._destroyElement = function(e) {
            i(e).detach().trigger(f.CLOSED).remove()
        },
        r._jQueryInterface = function(n) {
            return this.each(function() {
                var e = i(this),
                t = e.data(o);
                t || (t = new r(this), e.data(o, t)),
                "close" === n && t[n](this)
            })
        },
        r._handleDismiss = function(t) {
            return function(e) {
                e && e.preventDefault(),
                t.close(this)
            }
        },
        a(r, null, [{
            key: "VERSION",
            get: function() {
                return "4.1.3"
            }
        }]),
        r
    } (), i(document).on(f.CLICK_DATA_API, '[data-dismiss="alert"]', g._handleDismiss(new g)), i.fn[n] = g._jQueryInterface, i.fn[n].Constructor = g, i.fn[n].noConflict = function() {
        return i.fn[n] = u,
        g._jQueryInterface
    },
    g),
    Wn = (m = "button", b = "." + (y = "bs.button"), _ = ".data-api", w = (v = t).fn[m], x = "active", E = "btn", S = '[data-toggle^="button"]', T = '[data-toggle="buttons"]', k = "input", A = ".active", D = ".btn", O = {
        CLICK_DATA_API: "click" + b + _,
        FOCUS_BLUR_DATA_API: (C = "focus") + b + _ + " blur" + b + _
    },
    j = function() {
        function n(e) {
            this._element = e
        }
        var e = n.prototype;
        return e.toggle = function() {
            var e = !0,
            t = !0,
            n = v(this._element).closest(T)[0];
            if (n) {
                var r = this._element.querySelector(k);
                if (r) {
                    if ("radio" === r.type) if (r.checked && this._element.classList.contains(x)) e = !1;
                    else {
                        var i = n.querySelector(A);
                        i && v(i).removeClass(x)
                    }
                    if (e) {
                        if (r.hasAttribute("disabled") || n.hasAttribute("disabled") || r.classList.contains("disabled") || n.classList.contains("disabled")) return;
                        r.checked = !this._element.classList.contains(x),
                        v(r).trigger("change")
                    }
                    r.focus(),
                    t = !1
                }
            }
            t && this._element.setAttribute("aria-pressed", !this._element.classList.contains(x)),
            e && v(this._element).toggleClass(x)
        },
        e.dispose = function() {
            v.removeData(this._element, y),
            this._element = null
        },
        n._jQueryInterface = function(t) {
            return this.each(function() {
                var e = v(this).data(y);
                e || (e = new n(this), v(this).data(y, e)),
                "toggle" === t && e[t]()
            })
        },
        a(n, null, [{
            key: "VERSION",
            get: function() {
                return "4.1.3"
            }
        }]),
        n
    } (), v(document).on(O.CLICK_DATA_API, S,
    function(e) {
        e.preventDefault();
        var t = e.target;
        v(t).hasClass(E) || (t = v(t).closest(D)),
        j._jQueryInterface.call(v(t), "toggle")
    }).on(O.FOCUS_BLUR_DATA_API, S,
    function(e) {
        var t = v(e.target).closest(D)[0];
        v(t).toggleClass(C, /^focus(in)?$/.test(e.type))
    }), v.fn[m] = j._jQueryInterface, v.fn[m].Constructor = j, v.fn[m].noConflict = function() {
        return v.fn[m] = w,
        j._jQueryInterface
    },
    j),
    Un = (I = "carousel", P = "." + (L = "bs.carousel"), q = ".data-api", F = (N = t).fn[I], R = {
        interval: 5e3,
        keyboard: !0,
        slide: !1,
        pause: "hover",
        wrap: !0
    },
    M = {
        interval: "(number|boolean)",
        keyboard: "boolean",
        slide: "(boolean|string)",
        pause: "(string|boolean)",
        wrap: "boolean"
    },
    H = "next", B = "prev", $ = "left", W = "right", U = {
        SLIDE: "slide" + P,
        SLID: "slid" + P,
        KEYDOWN: "keydown" + P,
        MOUSEENTER: "mouseenter" + P,
        MOUSELEAVE: "mouseleave" + P,
        TOUCHEND: "touchend" + P,
        LOAD_DATA_API: "load" + P + q,
        CLICK_DATA_API: "click" + P + q
    },
    z = "carousel", V = "active", K = "slide", Q = "carousel-item-right", Y = "carousel-item-left", J = "carousel-item-next", X = "carousel-item-prev", G = ".active", Z = ".active.carousel-item", ee = ".carousel-item", te = ".carousel-item-next, .carousel-item-prev", ne = ".carousel-indicators", re = "[data-slide], [data-slide-to]", ie = '[data-ride="carousel"]', oe = function() {
        function o(e, t) {
            this._items = null,
            this._interval = null,
            this._activeElement = null,
            this._isPaused = !1,
            this._isSliding = !1,
            this.touchTimeout = null,
            this._config = this._getConfig(t),
            this._element = N(e)[0],
            this._indicatorsElement = this._element.querySelector(ne),
            this._addEventListeners()
        }
        var e = o.prototype;
        return e.next = function() {
            this._isSliding || this._slide(H)
        },
        e.nextWhenVisible = function() { ! document.hidden && N(this._element).is(":visible") && "hidden" !== N(this._element).css("visibility") && this.next()
        },
        e.prev = function() {
            this._isSliding || this._slide(B)
        },
        e.pause = function(e) {
            e || (this._isPaused = !0),
            this._element.querySelector(te) && (Bn.triggerTransitionEnd(this._element), this.cycle(!0)),
            clearInterval(this._interval),
            this._interval = null
        },
        e.cycle = function(e) {
            e || (this._isPaused = !1),
            this._interval && (clearInterval(this._interval), this._interval = null),
            this._config.interval && !this._isPaused && (this._interval = setInterval((document.visibilityState ? this.nextWhenVisible: this.next).bind(this), this._config.interval))
        },
        e.to = function(e) {
            var t = this;
            this._activeElement = this._element.querySelector(Z);
            var n = this._getItemIndex(this._activeElement);
            if (! (e > this._items.length - 1 || e < 0)) if (this._isSliding) N(this._element).one(U.SLID,
            function() {
                return t.to(e)
            });
            else {
                if (n === e) return this.pause(),
                void this.cycle();
                var r = n < e ? H: B;
                this._slide(r, this._items[e])
            }
        },
        e.dispose = function() {
            N(this._element).off(P),
            N.removeData(this._element, L),
            this._items = null,
            this._config = null,
            this._element = null,
            this._interval = null,
            this._isPaused = null,
            this._isSliding = null,
            this._activeElement = null,
            this._indicatorsElement = null
        },
        e._getConfig = function(e) {
            return e = l({},
            R, e),
            Bn.typeCheckConfig(I, e, M),
            e
        },
        e._addEventListeners = function() {
            var t = this;
            this._config.keyboard && N(this._element).on(U.KEYDOWN,
            function(e) {
                return t._keydown(e)
            }),
            "hover" === this._config.pause && (N(this._element).on(U.MOUSEENTER,
            function(e) {
                return t.pause(e)
            }).on(U.MOUSELEAVE,
            function(e) {
                return t.cycle(e)
            }), "ontouchstart" in document.documentElement && N(this._element).on(U.TOUCHEND,
            function() {
                t.pause(),
                t.touchTimeout && clearTimeout(t.touchTimeout),
                t.touchTimeout = setTimeout(function(e) {
                    return t.cycle(e)
                },
                500 + t._config.interval)
            }))
        },
        e._keydown = function(e) {
            if (!/input|textarea/i.test(e.target.tagName)) switch (e.which) {
            case 37:
                e.preventDefault(),
                this.prev();
                break;
            case 39:
                e.preventDefault(),
                this.next()
            }
        },
        e._getItemIndex = function(e) {
            return this._items = e && e.parentNode ? [].slice.call(e.parentNode.querySelectorAll(ee)) : [],
            this._items.indexOf(e)
        },
        e._getItemByDirection = function(e, t) {
            var n = e === H,
            r = e === B,
            i = this._getItemIndex(t),
            o = this._items.length - 1;
            if ((r && 0 === i || n && i === o) && !this._config.wrap) return t;
            var a = (i + (e === B ? -1 : 1)) % this._items.length;
            return - 1 === a ? this._items[this._items.length - 1] : this._items[a]
        },
        e._triggerSlideEvent = function(e, t) {
            var n = this._getItemIndex(e),
            r = this._getItemIndex(this._element.querySelector(Z)),
            i = N.Event(U.SLIDE, {
                relatedTarget: e,
                direction: t,
                from: r,
                to: n
            });
            return N(this._element).trigger(i),
            i
        },
        e._setActiveIndicatorElement = function(e) {
            if (this._indicatorsElement) {
                var t = [].slice.call(this._indicatorsElement.querySelectorAll(G));
                N(t).removeClass(V);
                var n = this._indicatorsElement.children[this._getItemIndex(e)];
                n && N(n).addClass(V)
            }
        },
        e._slide = function(e, t) {
            var n, r, i, o = this,
            a = this._element.querySelector(Z),
            s = this._getItemIndex(a),
            l = t || a && this._getItemByDirection(e, a),
            u = this._getItemIndex(l),
            c = Boolean(this._interval);
            if (e === H ? (n = Y, r = J, i = $) : (n = Q, r = X, i = W), l && N(l).hasClass(V)) this._isSliding = !1;
            else if (!this._triggerSlideEvent(l, i).isDefaultPrevented() && a && l) {
                this._isSliding = !0,
                c && this.pause(),
                this._setActiveIndicatorElement(l);
                var f = N.Event(U.SLID, {
                    relatedTarget: l,
                    direction: i,
                    from: s,
                    to: u
                });
                if (N(this._element).hasClass(K)) {
                    N(l).addClass(r),
                    Bn.reflow(l),
                    N(a).addClass(n),
                    N(l).addClass(n);
                    var h = Bn.getTransitionDurationFromElement(a);
                    N(a).one(Bn.TRANSITION_END,
                    function() {
                        N(l).removeClass(n + " " + r).addClass(V),
                        N(a).removeClass(V + " " + r + " " + n),
                        o._isSliding = !1,
                        setTimeout(function() {
                            return N(o._element).trigger(f)
                        },
                        0)
                    }).emulateTransitionEnd(h)
                } else N(a).removeClass(V),
                N(l).addClass(V),
                this._isSliding = !1,
                N(this._element).trigger(f);
                c && this.cycle()
            }
        },
        o._jQueryInterface = function(r) {
            return this.each(function() {
                var e = N(this).data(L),
                t = l({},
                R, N(this).data());
                "object" == typeof r && (t = l({},
                t, r));
                var n = "string" == typeof r ? r: t.slide;
                if (e || (e = new o(this, t), N(this).data(L, e)), "number" == typeof r) e.to(r);
                else if ("string" == typeof n) {
                    if (void 0 === e[n]) throw new TypeError('No method named "' + n + '"');
                    e[n]()
                } else t.interval && (e.pause(), e.cycle())
            })
        },
        o._dataApiClickHandler = function(e) {
            var t = Bn.getSelectorFromElement(this);
            if (t) {
                var n = N(t)[0];
                if (n && N(n).hasClass(z)) {
                    var r = l({},
                    N(n).data(), N(this).data()),
                    i = this.getAttribute("data-slide-to");
                    i && (r.interval = !1),
                    o._jQueryInterface.call(N(n), r),
                    i && N(n).data(L).to(i),
                    e.preventDefault()
                }
            }
        },
        a(o, null, [{
            key: "VERSION",
            get: function() {
                return "4.1.3"
            }
        },
        {
            key: "Default",
            get: function() {
                return R
            }
        }]),
        o
    } (), N(document).on(U.CLICK_DATA_API, re, oe._dataApiClickHandler), N(window).on(U.LOAD_DATA_API,
    function() {
        for (var e = [].slice.call(document.querySelectorAll(ie)), t = 0, n = e.length; t < n; t++) {
            var r = N(e[t]);
            oe._jQueryInterface.call(r, r.data())
        }
    }), N.fn[I] = oe._jQueryInterface, N.fn[I].Constructor = oe, N.fn[I].noConflict = function() {
        return N.fn[I] = F,
        oe._jQueryInterface
    },
    oe),
    zn = (se = "collapse", ue = "." + (le = "bs.collapse"), ce = (ae = t).fn[se], fe = {
        toggle: !0,
        parent: ""
    },
    he = {
        toggle: "boolean",
        parent: "(string|element)"
    },
    pe = {
        SHOW: "show" + ue,
        SHOWN: "shown" + ue,
        HIDE: "hide" + ue,
        HIDDEN: "hidden" + ue,
        CLICK_DATA_API: "click" + ue + ".data-api"
    },
    de = "show", ge = "collapse", ve = "collapsing", me = "collapsed", ye = "width", be = "height", _e = ".show, .collapsing", we = '[data-toggle="collapse"]', xe = function() {
        function s(t, e) {
            this._isTransitioning = !1,
            this._element = t,
            this._config = this._getConfig(e),
            this._triggerArray = ae.makeArray(document.querySelectorAll('[data-toggle="collapse"][href="#' + t.id + '"],[data-toggle="collapse"][data-target="#' + t.id + '"]'));
            for (var n = [].slice.call(document.querySelectorAll(we)), r = 0, i = n.length; r < i; r++) {
                var o = n[r],
                a = Bn.getSelectorFromElement(o),
                s = [].slice.call(document.querySelectorAll(a)).filter(function(e) {
                    return e === t
                });
                null !== a && 0 < s.length && (this._selector = a, this._triggerArray.push(o))
            }
            this._parent = this._config.parent ? this._getParent() : null,
            this._config.parent || this._addAriaAndCollapsedClass(this._element, this._triggerArray),
            this._config.toggle && this.toggle()
        }
        var e = s.prototype;
        return e.toggle = function() {
            ae(this._element).hasClass(de) ? this.hide() : this.show()
        },
        e.show = function() {
            var e, t, n = this;
            if (!this._isTransitioning && !ae(this._element).hasClass(de) && (this._parent && 0 === (e = [].slice.call(this._parent.querySelectorAll(_e)).filter(function(e) {
                return e.getAttribute("data-parent") === n._config.parent
            })).length && (e = null), !(e && (t = ae(e).not(this._selector).data(le)) && t._isTransitioning))) {
                var r = ae.Event(pe.SHOW);
                if (ae(this._element).trigger(r), !r.isDefaultPrevented()) {
                    e && (s._jQueryInterface.call(ae(e).not(this._selector), "hide"), t || ae(e).data(le, null));
                    var i = this._getDimension();
                    ae(this._element).removeClass(ge).addClass(ve),
                    this._element.style[i] = 0,
                    this._triggerArray.length && ae(this._triggerArray).removeClass(me).attr("aria-expanded", !0),
                    this.setTransitioning(!0);
                    var o = "scroll" + (i[0].toUpperCase() + i.slice(1)),
                    a = Bn.getTransitionDurationFromElement(this._element);
                    ae(this._element).one(Bn.TRANSITION_END,
                    function() {
                        ae(n._element).removeClass(ve).addClass(ge).addClass(de),
                        n._element.style[i] = "",
                        n.setTransitioning(!1),
                        ae(n._element).trigger(pe.SHOWN)
                    }).emulateTransitionEnd(a),
                    this._element.style[i] = this._element[o] + "px"
                }
            }
        },
        e.hide = function() {
            var e = this;
            if (!this._isTransitioning && ae(this._element).hasClass(de)) {
                var t = ae.Event(pe.HIDE);
                if (ae(this._element).trigger(t), !t.isDefaultPrevented()) {
                    var n = this._getDimension();
                    this._element.style[n] = this._element.getBoundingClientRect()[n] + "px",
                    Bn.reflow(this._element),
                    ae(this._element).addClass(ve).removeClass(ge).removeClass(de);
                    var r = this._triggerArray.length;
                    if (0 < r) for (var i = 0; i < r; i++) {
                        var o = this._triggerArray[i],
                        a = Bn.getSelectorFromElement(o);
                        if (null !== a) ae([].slice.call(document.querySelectorAll(a))).hasClass(de) || ae(o).addClass(me).attr("aria-expanded", !1)
                    }
                    this.setTransitioning(!0);
                    this._element.style[n] = "";
                    var s = Bn.getTransitionDurationFromElement(this._element);
                    ae(this._element).one(Bn.TRANSITION_END,
                    function() {
                        e.setTransitioning(!1),
                        ae(e._element).removeClass(ve).addClass(ge).trigger(pe.HIDDEN)
                    }).emulateTransitionEnd(s)
                }
            }
        },
        e.setTransitioning = function(e) {
            this._isTransitioning = e
        },
        e.dispose = function() {
            ae.removeData(this._element, le),
            this._config = null,
            this._parent = null,
            this._element = null,
            this._triggerArray = null,
            this._isTransitioning = null
        },
        e._getConfig = function(e) {
            return (e = l({},
            fe, e)).toggle = Boolean(e.toggle),
            Bn.typeCheckConfig(se, e, he),
            e
        },
        e._getDimension = function() {
            return ae(this._element).hasClass(ye) ? ye: be
        },
        e._getParent = function() {
            var n = this,
            e = null;
            Bn.isElement(this._config.parent) ? (e = this._config.parent, void 0 !== this._config.parent.jquery && (e = this._config.parent[0])) : e = document.querySelector(this._config.parent);
            var t = '[data-toggle="collapse"][data-parent="' + this._config.parent + '"]',
            r = [].slice.call(e.querySelectorAll(t));
            return ae(r).each(function(e, t) {
                n._addAriaAndCollapsedClass(s._getTargetFromElement(t), [t])
            }),
            e
        },
        e._addAriaAndCollapsedClass = function(e, t) {
            if (e) {
                var n = ae(e).hasClass(de);
                t.length && ae(t).toggleClass(me, !n).attr("aria-expanded", n)
            }
        },
        s._getTargetFromElement = function(e) {
            var t = Bn.getSelectorFromElement(e);
            return t ? document.querySelector(t) : null
        },
        s._jQueryInterface = function(r) {
            return this.each(function() {
                var e = ae(this),
                t = e.data(le),
                n = l({},
                fe, e.data(), "object" == typeof r && r ? r: {});
                if (!t && n.toggle && /show|hide/.test(r) && (n.toggle = !1), t || (t = new s(this, n), e.data(le, t)), "string" == typeof r) {
                    if (void 0 === t[r]) throw new TypeError('No method named "' + r + '"');
                    t[r]()
                }
            })
        },
        a(s, null, [{
            key: "VERSION",
            get: function() {
                return "4.1.3"
            }
        },
        {
            key: "Default",
            get: function() {
                return fe
            }
        }]),
        s
    } (), ae(document).on(pe.CLICK_DATA_API, we,
    function(e) {
        "A" === e.currentTarget.tagName && e.preventDefault();
        var n = ae(this),
        t = Bn.getSelectorFromElement(this),
        r = [].slice.call(document.querySelectorAll(t));
        ae(r).each(function() {
            var e = ae(this),
            t = e.data(le) ? "toggle": n.data();
            xe._jQueryInterface.call(e, t)
        })
    }), ae.fn[se] = xe._jQueryInterface, ae.fn[se].Constructor = xe, ae.fn[se].noConflict = function() {
        return ae.fn[se] = ce,
        xe._jQueryInterface
    },
    xe),
    Vn = (Ce = "dropdown", Te = "." + (Se = "bs.dropdown"), ke = ".data-api", Ae = (Ee = t).fn[Ce], De = new RegExp("38|40|27"), Oe = {
        HIDE: "hide" + Te,
        HIDDEN: "hidden" + Te,
        SHOW: "show" + Te,
        SHOWN: "shown" + Te,
        CLICK: "click" + Te,
        CLICK_DATA_API: "click" + Te + ke,
        KEYDOWN_DATA_API: "keydown" + Te + ke,
        KEYUP_DATA_API: "keyup" + Te + ke
    },
    je = "disabled", Ne = "show", Ie = "dropup", Le = "dropright", Pe = "dropleft", qe = "dropdown-menu-right", Fe = "position-static", Re = '[data-toggle="dropdown"]', Me = ".dropdown form", He = ".dropdown-menu", Be = ".navbar-nav", $e = ".dropdown-menu .dropdown-item:not(.disabled):not(:disabled)", We = "top-start", Ue = "top-end", ze = "bottom-start", Ve = "bottom-end", Ke = "right-start", Qe = "left-start", Ye = {
        offset: 0,
        flip: !0,
        boundary: "scrollParent",
        reference: "toggle",
        display: "dynamic"
    },
    Je = {
        offset: "(number|string|function)",
        flip: "boolean",
        boundary: "(string|element)",
        reference: "(string|element)",
        display: "string"
    },
    Xe = function() {
        function u(e, t) {
            this._element = e,
            this._popper = null,
            this._config = this._getConfig(t),
            this._menu = this._getMenuElement(),
            this._inNavbar = this._detectNavbar(),
            this._addEventListeners()
        }
        var e = u.prototype;
        return e.toggle = function() {
            if (!this._element.disabled && !Ee(this._element).hasClass(je)) {
                var e = u._getParentFromElement(this._element),
                t = Ee(this._menu).hasClass(Ne);
                if (u._clearMenus(), !t) {
                    var n = {
                        relatedTarget: this._element
                    },
                    r = Ee.Event(Oe.SHOW, n);
                    if (Ee(e).trigger(r), !r.isDefaultPrevented()) {
                        if (!this._inNavbar) {
                            if (void 0 === c) throw new TypeError("Bootstrap dropdown require Popper.js (https://popper.js.org)");
                            var i = this._element;
                            "parent" === this._config.reference ? i = e: Bn.isElement(this._config.reference) && (i = this._config.reference, void 0 !== this._config.reference.jquery && (i = this._config.reference[0])),
                            "scrollParent" !== this._config.boundary && Ee(e).addClass(Fe),
                            this._popper = new c(i, this._menu, this._getPopperConfig())
                        }
                        "ontouchstart" in document.documentElement && 0 === Ee(e).closest(Be).length && Ee(document.body).children().on("mouseover", null, Ee.noop),
                        this._element.focus(),
                        this._element.setAttribute("aria-expanded", !0),
                        Ee(this._menu).toggleClass(Ne),
                        Ee(e).toggleClass(Ne).trigger(Ee.Event(Oe.SHOWN, n))
                    }
                }
            }
        },
        e.dispose = function() {
            Ee.removeData(this._element, Se),
            Ee(this._element).off(Te),
            this._element = null,
            (this._menu = null) !== this._popper && (this._popper.destroy(), this._popper = null)
        },
        e.update = function() {
            this._inNavbar = this._detectNavbar(),
            null !== this._popper && this._popper.scheduleUpdate()
        },
        e._addEventListeners = function() {
            var t = this;
            Ee(this._element).on(Oe.CLICK,
            function(e) {
                e.preventDefault(),
                e.stopPropagation(),
                t.toggle()
            })
        },
        e._getConfig = function(e) {
            return e = l({},
            this.constructor.Default, Ee(this._element).data(), e),
            Bn.typeCheckConfig(Ce, e, this.constructor.DefaultType),
            e
        },
        e._getMenuElement = function() {
            if (!this._menu) {
                var e = u._getParentFromElement(this._element);
                e && (this._menu = e.querySelector(He))
            }
            return this._menu
        },
        e._getPlacement = function() {
            var e = Ee(this._element.parentNode),
            t = ze;
            return e.hasClass(Ie) ? (t = We, Ee(this._menu).hasClass(qe) && (t = Ue)) : e.hasClass(Le) ? t = Ke: e.hasClass(Pe) ? t = Qe: Ee(this._menu).hasClass(qe) && (t = Ve),
            t
        },
        e._detectNavbar = function() {
            return 0 < Ee(this._element).closest(".navbar").length
        },
        e._getPopperConfig = function() {
            var t = this,
            e = {};
            "function" == typeof this._config.offset ? e.fn = function(e) {
                return e.offsets = l({},
                e.offsets, t._config.offset(e.offsets) || {}),
                e
            }: e.offset = this._config.offset;
            var n = {
                placement: this._getPlacement(),
                modifiers: {
                    offset: e,
                    flip: {
                        enabled: this._config.flip
                    },
                    preventOverflow: {
                        boundariesElement: this._config.boundary
                    }
                }
            };
            return "static" === this._config.display && (n.modifiers.applyStyle = {
                enabled: !1
            }),
            n
        },
        u._jQueryInterface = function(t) {
            return this.each(function() {
                var e = Ee(this).data(Se);
                if (e || (e = new u(this, "object" == typeof t ? t: null), Ee(this).data(Se, e)), "string" == typeof t) {
                    if (void 0 === e[t]) throw new TypeError('No method named "' + t + '"');
                    e[t]()
                }
            })
        },
        u._clearMenus = function(e) {
            if (!e || 3 !== e.which && ("keyup" !== e.type || 9 === e.which)) for (var t = [].slice.call(document.querySelectorAll(Re)), n = 0, r = t.length; n < r; n++) {
                var i = u._getParentFromElement(t[n]),
                o = Ee(t[n]).data(Se),
                a = {
                    relatedTarget: t[n]
                };
                if (e && "click" === e.type && (a.clickEvent = e), o) {
                    var s = o._menu;
                    if (Ee(i).hasClass(Ne) && !(e && ("click" === e.type && /input|textarea/i.test(e.target.tagName) || "keyup" === e.type && 9 === e.which) && Ee.contains(i, e.target))) {
                        var l = Ee.Event(Oe.HIDE, a);
                        Ee(i).trigger(l),
                        l.isDefaultPrevented() || ("ontouchstart" in document.documentElement && Ee(document.body).children().off("mouseover", null, Ee.noop), t[n].setAttribute("aria-expanded", "false"), Ee(s).removeClass(Ne), Ee(i).removeClass(Ne).trigger(Ee.Event(Oe.HIDDEN, a)))
                    }
                }
            }
        },
        u._getParentFromElement = function(e) {
            var t, n = Bn.getSelectorFromElement(e);
            return n && (t = document.querySelector(n)),
            t || e.parentNode
        },
        u._dataApiKeydownHandler = function(e) {
            if ((/input|textarea/i.test(e.target.tagName) ? !(32 === e.which || 27 !== e.which && (40 !== e.which && 38 !== e.which || Ee(e.target).closest(He).length)) : De.test(e.which)) && (e.preventDefault(), e.stopPropagation(), !this.disabled && !Ee(this).hasClass(je))) {
                var t = u._getParentFromElement(this),
                n = Ee(t).hasClass(Ne);
                if ((n || 27 === e.which && 32 === e.which) && (!n || 27 !== e.which && 32 !== e.which)) {
                    var r = [].slice.call(t.querySelectorAll($e));
                    if (0 !== r.length) {
                        var i = r.indexOf(e.target);
                        38 === e.which && 0 < i && i--,
                        40 === e.which && i < r.length - 1 && i++,
                        i < 0 && (i = 0),
                        r[i].focus()
                    }
                } else {
                    if (27 === e.which) {
                        var o = t.querySelector(Re);
                        Ee(o).trigger("focus")
                    }
                    Ee(this).trigger("click")
                }
            }
        },
        a(u, null, [{
            key: "VERSION",
            get: function() {
                return "4.1.3"
            }
        },
        {
            key: "Default",
            get: function() {
                return Ye
            }
        },
        {
            key: "DefaultType",
            get: function() {
                return Je
            }
        }]),
        u
    } (), Ee(document).on(Oe.KEYDOWN_DATA_API, Re, Xe._dataApiKeydownHandler).on(Oe.KEYDOWN_DATA_API, He, Xe._dataApiKeydownHandler).on(Oe.CLICK_DATA_API + " " + Oe.KEYUP_DATA_API, Xe._clearMenus).on(Oe.CLICK_DATA_API, Re,
    function(e) {
        e.preventDefault(),
        e.stopPropagation(),
        Xe._jQueryInterface.call(Ee(this), "toggle")
    }).on(Oe.CLICK_DATA_API, Me,
    function(e) {
        e.stopPropagation()
    }), Ee.fn[Ce] = Xe._jQueryInterface, Ee.fn[Ce].Constructor = Xe, Ee.fn[Ce].noConflict = function() {
        return Ee.fn[Ce] = Ae,
        Xe._jQueryInterface
    },
    Xe),
    Kn = (Ze = "modal", tt = "." + (et = "bs.modal"), nt = (Ge = t).fn[Ze], rt = {
        backdrop: !0,
        keyboard: !0,
        focus: !0,
        show: !0
    },
    it = {
        backdrop: "(boolean|string)",
        keyboard: "boolean",
        focus: "boolean",
        show: "boolean"
    },
    ot = {
        HIDE: "hide" + tt,
        HIDDEN: "hidden" + tt,
        SHOW: "show" + tt,
        SHOWN: "shown" + tt,
        FOCUSIN: "focusin" + tt,
        RESIZE: "resize" + tt,
        CLICK_DISMISS: "click.dismiss" + tt,
        KEYDOWN_DISMISS: "keydown.dismiss" + tt,
        MOUSEUP_DISMISS: "mouseup.dismiss" + tt,
        MOUSEDOWN_DISMISS: "mousedown.dismiss" + tt,
        CLICK_DATA_API: "click" + tt + ".data-api"
    },
    at = "modal-scrollbar-measure", st = "modal-backdrop", lt = "modal-open", ut = "fade", ct = "show", ft = ".modal-dialog", ht = '[data-toggle="modal"]', pt = '[data-dismiss="modal"]', dt = ".fixed-top, .fixed-bottom, .is-fixed, .sticky-top", gt = ".sticky-top", vt = function() {
        function i(e, t) {
            this._config = this._getConfig(t),
            this._element = e,
            this._dialog = e.querySelector(ft),
            this._backdrop = null,
            this._isShown = !1,
            this._isBodyOverflowing = !1,
            this._ignoreBackdropClick = !1,
            this._scrollbarWidth = 0
        }
        var e = i.prototype;
        return e.toggle = function(e) {
            return this._isShown ? this.hide() : this.show(e)
        },
        e.show = function(e) {
            var t = this;
            if (!this._isTransitioning && !this._isShown) {
                Ge(this._element).hasClass(ut) && (this._isTransitioning = !0);
                var n = Ge.Event(ot.SHOW, {
                    relatedTarget: e
                });
                Ge(this._element).trigger(n),
                this._isShown || n.isDefaultPrevented() || (this._isShown = !0, this._checkScrollbar(), this._setScrollbar(), this._adjustDialog(), Ge(document.body).addClass(lt), this._setEscapeEvent(), this._setResizeEvent(), Ge(this._element).on(ot.CLICK_DISMISS, pt,
                function(e) {
                    return t.hide(e)
                }), Ge(this._dialog).on(ot.MOUSEDOWN_DISMISS,
                function() {
                    Ge(t._element).one(ot.MOUSEUP_DISMISS,
                    function(e) {
                        Ge(e.target).is(t._element) && (t._ignoreBackdropClick = !0)
                    })
                }), this._showBackdrop(function() {
                    return t._showElement(e)
                }))
            }
        },
        e.hide = function(e) {
            var t = this;
            if (e && e.preventDefault(), !this._isTransitioning && this._isShown) {
                var n = Ge.Event(ot.HIDE);
                if (Ge(this._element).trigger(n), this._isShown && !n.isDefaultPrevented()) {
                    this._isShown = !1;
                    var r = Ge(this._element).hasClass(ut);
                    if (r && (this._isTransitioning = !0), this._setEscapeEvent(), this._setResizeEvent(), Ge(document).off(ot.FOCUSIN), Ge(this._element).removeClass(ct), Ge(this._element).off(ot.CLICK_DISMISS), Ge(this._dialog).off(ot.MOUSEDOWN_DISMISS), r) {
                        var i = Bn.getTransitionDurationFromElement(this._element);
                        Ge(this._element).one(Bn.TRANSITION_END,
                        function(e) {
                            return t._hideModal(e)
                        }).emulateTransitionEnd(i)
                    } else this._hideModal()
                }
            }
        },
        e.dispose = function() {
            Ge.removeData(this._element, et),
            Ge(window, document, this._element, this._backdrop).off(tt),
            this._config = null,
            this._element = null,
            this._dialog = null,
            this._backdrop = null,
            this._isShown = null,
            this._isBodyOverflowing = null,
            this._ignoreBackdropClick = null,
            this._scrollbarWidth = null
        },
        e.handleUpdate = function() {
            this._adjustDialog()
        },
        e._getConfig = function(e) {
            return e = l({},
            rt, e),
            Bn.typeCheckConfig(Ze, e, it),
            e
        },
        e._showElement = function(e) {
            var t = this,
            n = Ge(this._element).hasClass(ut);
            this._element.parentNode && this._element.parentNode.nodeType === Node.ELEMENT_NODE || document.body.appendChild(this._element),
            this._element.style.display = "block",
            this._element.removeAttribute("aria-hidden"),
            this._element.scrollTop = 0,
            n && Bn.reflow(this._element),
            Ge(this._element).addClass(ct),
            this._config.focus && this._enforceFocus();
            var r = Ge.Event(ot.SHOWN, {
                relatedTarget: e
            }),
            i = function() {
                t._config.focus && t._element.focus(),
                t._isTransitioning = !1,
                Ge(t._element).trigger(r)
            };
            if (n) {
                var o = Bn.getTransitionDurationFromElement(this._element);
                Ge(this._dialog).one(Bn.TRANSITION_END, i).emulateTransitionEnd(o)
            } else i()
        },
        e._enforceFocus = function() {
            var t = this;
            Ge(document).off(ot.FOCUSIN).on(ot.FOCUSIN,
            function(e) {
                document !== e.target && t._element !== e.target && 0 === Ge(t._element).has(e.target).length && t._element.focus()
            })
        },
        e._setEscapeEvent = function() {
            var t = this;
            this._isShown && this._config.keyboard ? Ge(this._element).on(ot.KEYDOWN_DISMISS,
            function(e) {
                27 === e.which && (e.preventDefault(), t.hide())
            }) : this._isShown || Ge(this._element).off(ot.KEYDOWN_DISMISS)
        },
        e._setResizeEvent = function() {
            var t = this;
            this._isShown ? Ge(window).on(ot.RESIZE,
            function(e) {
                return t.handleUpdate(e)
            }) : Ge(window).off(ot.RESIZE)
        },
        e._hideModal = function() {
            var e = this;
            this._element.style.display = "none",
            this._element.setAttribute("aria-hidden", !0),
            this._isTransitioning = !1,
            this._showBackdrop(function() {
                Ge(document.body).removeClass(lt),
                e._resetAdjustments(),
                e._resetScrollbar(),
                Ge(e._element).trigger(ot.HIDDEN)
            })
        },
        e._removeBackdrop = function() {
            this._backdrop && (Ge(this._backdrop).remove(), this._backdrop = null)
        },
        e._showBackdrop = function(e) {
            var t = this,
            n = Ge(this._element).hasClass(ut) ? ut: "";
            if (this._isShown && this._config.backdrop) {
                if (this._backdrop = document.createElement("div"), this._backdrop.className = st, n && this._backdrop.classList.add(n), Ge(this._backdrop).appendTo(document.body), Ge(this._element).on(ot.CLICK_DISMISS,
                function(e) {
                    t._ignoreBackdropClick ? t._ignoreBackdropClick = !1 : e.target === e.currentTarget && ("static" === t._config.backdrop ? t._element.focus() : t.hide())
                }), n && Bn.reflow(this._backdrop), Ge(this._backdrop).addClass(ct), !e) return;
                if (!n) return void e();
                var r = Bn.getTransitionDurationFromElement(this._backdrop);
                Ge(this._backdrop).one(Bn.TRANSITION_END, e).emulateTransitionEnd(r)
            } else if (!this._isShown && this._backdrop) {
                Ge(this._backdrop).removeClass(ct);
                var i = function() {
                    t._removeBackdrop(),
                    e && e()
                };
                if (Ge(this._element).hasClass(ut)) {
                    var o = Bn.getTransitionDurationFromElement(this._backdrop);
                    Ge(this._backdrop).one(Bn.TRANSITION_END, i).emulateTransitionEnd(o)
                } else i()
            } else e && e()
        },
        e._adjustDialog = function() {
            var e = this._element.scrollHeight > document.documentElement.clientHeight; ! this._isBodyOverflowing && e && (this._element.style.paddingLeft = this._scrollbarWidth + "px"),
            this._isBodyOverflowing && !e && (this._element.style.paddingRight = this._scrollbarWidth + "px")
        },
        e._resetAdjustments = function() {
            this._element.style.paddingLeft = "",
            this._element.style.paddingRight = ""
        },
        e._checkScrollbar = function() {
            var e = document.body.getBoundingClientRect();
            this._isBodyOverflowing = e.left + e.right < window.innerWidth,
            this._scrollbarWidth = this._getScrollbarWidth()
        },
        e._setScrollbar = function() {
            var i = this;
            if (this._isBodyOverflowing) {
                var e = [].slice.call(document.querySelectorAll(dt)),
                t = [].slice.call(document.querySelectorAll(gt));
                Ge(e).each(function(e, t) {
                    var n = t.style.paddingRight,
                    r = Ge(t).css("padding-right");
                    Ge(t).data("padding-right", n).css("padding-right", parseFloat(r) + i._scrollbarWidth + "px")
                }),
                Ge(t).each(function(e, t) {
                    var n = t.style.marginRight,
                    r = Ge(t).css("margin-right");
                    Ge(t).data("margin-right", n).css("margin-right", parseFloat(r) - i._scrollbarWidth + "px")
                });
                var n = document.body.style.paddingRight,
                r = Ge(document.body).css("padding-right");
                Ge(document.body).data("padding-right", n).css("padding-right", parseFloat(r) + this._scrollbarWidth + "px")
            }
        },
        e._resetScrollbar = function() {
            var e = [].slice.call(document.querySelectorAll(dt));
            Ge(e).each(function(e, t) {
                var n = Ge(t).data("padding-right");
                Ge(t).removeData("padding-right"),
                t.style.paddingRight = n || ""
            });
            var t = [].slice.call(document.querySelectorAll("" + gt));
            Ge(t).each(function(e, t) {
                var n = Ge(t).data("margin-right");
                void 0 !== n && Ge(t).css("margin-right", n).removeData("margin-right")
            });
            var n = Ge(document.body).data("padding-right");
            Ge(document.body).removeData("padding-right"),
            document.body.style.paddingRight = n || ""
        },
        e._getScrollbarWidth = function() {
            var e = document.createElement("div");
            e.className = at,
            document.body.appendChild(e);
            var t = e.getBoundingClientRect().width - e.clientWidth;
            return document.body.removeChild(e),
            t
        },
        i._jQueryInterface = function(n, r) {
            return this.each(function() {
                var e = Ge(this).data(et),
                t = l({},
                rt, Ge(this).data(), "object" == typeof n && n ? n: {});
                if (e || (e = new i(this, t), Ge(this).data(et, e)), "string" == typeof n) {
                    if (void 0 === e[n]) throw new TypeError('No method named "' + n + '"');
                    e[n](r)
                } else t.show && e.show(r)
            })
        },
        a(i, null, [{
            key: "VERSION",
            get: function() {
                return "4.1.3"
            }
        },
        {
            key: "Default",
            get: function() {
                return rt
            }
        }]),
        i
    } (), Ge(document).on(ot.CLICK_DATA_API, ht,
    function(e) {
        var t, n = this,
        r = Bn.getSelectorFromElement(this);
        r && (t = document.querySelector(r));
        var i = Ge(t).data(et) ? "toggle": l({},
        Ge(t).data(), Ge(this).data());
        "A" !== this.tagName && "AREA" !== this.tagName || e.preventDefault();
        var o = Ge(t).one(ot.SHOW,
        function(e) {
            e.isDefaultPrevented() || o.one(ot.HIDDEN,
            function() {
                Ge(n).is(":visible") && n.focus()
            })
        });
        vt._jQueryInterface.call(Ge(t), i, this)
    }), Ge.fn[Ze] = vt._jQueryInterface, Ge.fn[Ze].Constructor = vt, Ge.fn[Ze].noConflict = function() {
        return Ge.fn[Ze] = nt,
        vt._jQueryInterface
    },
    vt),
    Qn = (yt = "tooltip", _t = "." + (bt = "bs.tooltip"), wt = (mt = t).fn[yt], xt = "bs-tooltip", Et = new RegExp("(^|\\s)" + xt + "\\S+", "g"), Tt = {
        animation: !0,
        template: '<div class="tooltip" role="tooltip"><div class="arrow"></div><div class="tooltip-inner"></div></div>',
        trigger: "hover focus",
        title: "",
        delay: 0,
        html: !(St = {
            AUTO: "auto",
            TOP: "top",
            RIGHT: "right",
            BOTTOM: "bottom",
            LEFT: "left"
        }),
        selector: !(Ct = {
            animation: "boolean",
            template: "string",
            title: "(string|element|function)",
            trigger: "string",
            delay: "(number|object)",
            html: "boolean",
            selector: "(string|boolean)",
            placement: "(string|function)",
            offset: "(number|string)",
            container: "(string|element|boolean)",
            fallbackPlacement: "(string|array)",
            boundary: "(string|element)"
        }),
        placement: "top",
        offset: 0,
        container: !1,
        fallbackPlacement: "flip",
        boundary: "scrollParent"
    },
    At = "out", Dt = {
        HIDE: "hide" + _t,
        HIDDEN: "hidden" + _t,
        SHOW: (kt = "show") + _t,
        SHOWN: "shown" + _t,
        INSERTED: "inserted" + _t,
        CLICK: "click" + _t,
        FOCUSIN: "focusin" + _t,
        FOCUSOUT: "focusout" + _t,
        MOUSEENTER: "mouseenter" + _t,
        MOUSELEAVE: "mouseleave" + _t
    },
    Ot = "fade", jt = "show", Nt = ".tooltip-inner", It = ".arrow", Lt = "hover", Pt = "focus", qt = "click", Ft = "manual", Rt = function() {
        function r(e, t) {
            if (void 0 === c) throw new TypeError("Bootstrap tooltips require Popper.js (https://popper.js.org)");
            this._isEnabled = !0,
            this._timeout = 0,
            this._hoverState = "",
            this._activeTrigger = {},
            this._popper = null,
            this.element = e,
            this.config = this._getConfig(t),
            this.tip = null,
            this._setListeners()
        }
        var e = r.prototype;
        return e.enable = function() {
            this._isEnabled = !0
        },
        e.disable = function() {
            this._isEnabled = !1
        },
        e.toggleEnabled = function() {
            this._isEnabled = !this._isEnabled
        },
        e.toggle = function(e) {
            if (this._isEnabled) if (e) {
                var t = this.constructor.DATA_KEY,
                n = mt(e.currentTarget).data(t);
                n || (n = new this.constructor(e.currentTarget, this._getDelegateConfig()), mt(e.currentTarget).data(t, n)),
                n._activeTrigger.click = !n._activeTrigger.click,
                n._isWithActiveTrigger() ? n._enter(null, n) : n._leave(null, n)
            } else {
                if (mt(this.getTipElement()).hasClass(jt)) return void this._leave(null, this);
                this._enter(null, this)
            }
        },
        e.dispose = function() {
            clearTimeout(this._timeout),
            mt.removeData(this.element, this.constructor.DATA_KEY),
            mt(this.element).off(this.constructor.EVENT_KEY),
            mt(this.element).closest(".modal").off("hide.bs.modal"),
            this.tip && mt(this.tip).remove(),
            this._isEnabled = null,
            this._timeout = null,
            this._hoverState = null,
            (this._activeTrigger = null) !== this._popper && this._popper.destroy(),
            this._popper = null,
            this.element = null,
            this.config = null,
            this.tip = null
        },
        e.show = function() {
            var t = this;
            if ("none" === mt(this.element).css("display")) throw new Error("Please use show on visible elements");
            var e = mt.Event(this.constructor.Event.SHOW);
            if (this.isWithContent() && this._isEnabled) {
                mt(this.element).trigger(e);
                var n = mt.contains(this.element.ownerDocument.documentElement, this.element);
                if (e.isDefaultPrevented() || !n) return;
                var r = this.getTipElement(),
                i = Bn.getUID(this.constructor.NAME);
                r.setAttribute("id", i),
                this.element.setAttribute("aria-describedby", i),
                this.setContent(),
                this.config.animation && mt(r).addClass(Ot);
                var o = "function" == typeof this.config.placement ? this.config.placement.call(this, r, this.element) : this.config.placement,
                a = this._getAttachment(o);
                this.addAttachmentClass(a);
                var s = !1 === this.config.container ? document.body: mt(document).find(this.config.container);
                mt(r).data(this.constructor.DATA_KEY, this),
                mt.contains(this.element.ownerDocument.documentElement, this.tip) || mt(r).appendTo(s),
                mt(this.element).trigger(this.constructor.Event.INSERTED),
                this._popper = new c(this.element, r, {
                    placement: a,
                    modifiers: {
                        offset: {
                            offset: this.config.offset
                        },
                        flip: {
                            behavior: this.config.fallbackPlacement
                        },
                        arrow: {
                            element: It
                        },
                        preventOverflow: {
                            boundariesElement: this.config.boundary
                        }
                    },
                    onCreate: function(e) {
                        e.originalPlacement !== e.placement && t._handlePopperPlacementChange(e)
                    },
                    onUpdate: function(e) {
                        t._handlePopperPlacementChange(e)
                    }
                }),
                mt(r).addClass(jt),
                "ontouchstart" in document.documentElement && mt(document.body).children().on("mouseover", null, mt.noop);
                var l = function() {
                    t.config.animation && t._fixTransition();
                    var e = t._hoverState;
                    t._hoverState = null,
                    mt(t.element).trigger(t.constructor.Event.SHOWN),
                    e === At && t._leave(null, t)
                };
                if (mt(this.tip).hasClass(Ot)) {
                    var u = Bn.getTransitionDurationFromElement(this.tip);
                    mt(this.tip).one(Bn.TRANSITION_END, l).emulateTransitionEnd(u)
                } else l()
            }
        },
        e.hide = function(e) {
            var t = this,
            n = this.getTipElement(),
            r = mt.Event(this.constructor.Event.HIDE),
            i = function() {
                t._hoverState !== kt && n.parentNode && n.parentNode.removeChild(n),
                t._cleanTipClass(),
                t.element.removeAttribute("aria-describedby"),
                mt(t.element).trigger(t.constructor.Event.HIDDEN),
                null !== t._popper && t._popper.destroy(),
                e && e()
            };
            if (mt(this.element).trigger(r), !r.isDefaultPrevented()) {
                if (mt(n).removeClass(jt), "ontouchstart" in document.documentElement && mt(document.body).children().off("mouseover", null, mt.noop), this._activeTrigger[qt] = !1, this._activeTrigger[Pt] = !1, this._activeTrigger[Lt] = !1, mt(this.tip).hasClass(Ot)) {
                    var o = Bn.getTransitionDurationFromElement(n);
                    mt(n).one(Bn.TRANSITION_END, i).emulateTransitionEnd(o)
                } else i();
                this._hoverState = ""
            }
        },
        e.update = function() {
            null !== this._popper && this._popper.scheduleUpdate()
        },
        e.isWithContent = function() {
            return Boolean(this.getTitle())
        },
        e.addAttachmentClass = function(e) {
            mt(this.getTipElement()).addClass(xt + "-" + e)
        },
        e.getTipElement = function() {
            return this.tip = this.tip || mt(this.config.template)[0],
            this.tip
        },
        e.setContent = function() {
            var e = this.getTipElement();
            this.setElementContent(mt(e.querySelectorAll(Nt)), this.getTitle()),
            mt(e).removeClass(Ot + " " + jt)
        },
        e.setElementContent = function(e, t) {
            var n = this.config.html;
            "object" == typeof t && (t.nodeType || t.jquery) ? n ? mt(t).parent().is(e) || e.empty().append(t) : e.text(mt(t).text()) : e[n ? "html": "text"](t)
        },
        e.getTitle = function() {
            var e = this.element.getAttribute("data-original-title");
            return e || (e = "function" == typeof this.config.title ? this.config.title.call(this.element) : this.config.title),
            e
        },
        e._getAttachment = function(e) {
            return St[e.toUpperCase()]
        },
        e._setListeners = function() {
            var r = this;
            this.config.trigger.split(" ").forEach(function(e) {
                if ("click" === e) mt(r.element).on(r.constructor.Event.CLICK, r.config.selector,
                function(e) {
                    return r.toggle(e)
                });
                else if (e !== Ft) {
                    var t = e === Lt ? r.constructor.Event.MOUSEENTER: r.constructor.Event.FOCUSIN,
                    n = e === Lt ? r.constructor.Event.MOUSELEAVE: r.constructor.Event.FOCUSOUT;
                    mt(r.element).on(t, r.config.selector,
                    function(e) {
                        return r._enter(e)
                    }).on(n, r.config.selector,
                    function(e) {
                        return r._leave(e)
                    })
                }
                mt(r.element).closest(".modal").on("hide.bs.modal",
                function() {
                    return r.hide()
                })
            }),
            this.config.selector ? this.config = l({},
            this.config, {
                trigger: "manual",
                selector: ""
            }) : this._fixTitle()
        },
        e._fixTitle = function() {
            var e = typeof this.element.getAttribute("data-original-title"); (this.element.getAttribute("title") || "string" !== e) && (this.element.setAttribute("data-original-title", this.element.getAttribute("title") || ""), this.element.setAttribute("title", ""))
        },
        e._enter = function(e, t) {
            var n = this.constructor.DATA_KEY; (t = t || mt(e.currentTarget).data(n)) || (t = new this.constructor(e.currentTarget, this._getDelegateConfig()), mt(e.currentTarget).data(n, t)),
            e && (t._activeTrigger["focusin" === e.type ? Pt: Lt] = !0),
            mt(t.getTipElement()).hasClass(jt) || t._hoverState === kt ? t._hoverState = kt: (clearTimeout(t._timeout), t._hoverState = kt, t.config.delay && t.config.delay.show ? t._timeout = setTimeout(function() {
                t._hoverState === kt && t.show()
            },
            t.config.delay.show) : t.show())
        },
        e._leave = function(e, t) {
            var n = this.constructor.DATA_KEY; (t = t || mt(e.currentTarget).data(n)) || (t = new this.constructor(e.currentTarget, this._getDelegateConfig()), mt(e.currentTarget).data(n, t)),
            e && (t._activeTrigger["focusout" === e.type ? Pt: Lt] = !1),
            t._isWithActiveTrigger() || (clearTimeout(t._timeout), t._hoverState = At, t.config.delay && t.config.delay.hide ? t._timeout = setTimeout(function() {
                t._hoverState === At && t.hide()
            },
            t.config.delay.hide) : t.hide())
        },
        e._isWithActiveTrigger = function() {
            for (var e in this._activeTrigger) if (this._activeTrigger[e]) return ! 0;
            return ! 1
        },
        e._getConfig = function(e) {
            return "number" == typeof(e = l({},
            this.constructor.Default, mt(this.element).data(), "object" == typeof e && e ? e: {})).delay && (e.delay = {
                show: e.delay,
                hide: e.delay
            }),
            "number" == typeof e.title && (e.title = e.title.toString()),
            "number" == typeof e.content && (e.content = e.content.toString()),
            Bn.typeCheckConfig(yt, e, this.constructor.DefaultType),
            e
        },
        e._getDelegateConfig = function() {
            var e = {};
            if (this.config) for (var t in this.config) this.constructor.Default[t] !== this.config[t] && (e[t] = this.config[t]);
            return e
        },
        e._cleanTipClass = function() {
            var e = mt(this.getTipElement()),
            t = e.attr("class").match(Et);
            null !== t && t.length && e.removeClass(t.join(""))
        },
        e._handlePopperPlacementChange = function(e) {
            var t = e.instance;
            this.tip = t.popper,
            this._cleanTipClass(),
            this.addAttachmentClass(this._getAttachment(e.placement))
        },
        e._fixTransition = function() {
            var e = this.getTipElement(),
            t = this.config.animation;
            null === e.getAttribute("x-placement") && (mt(e).removeClass(Ot), this.config.animation = !1, this.hide(), this.show(), this.config.animation = t)
        },
        r._jQueryInterface = function(n) {
            return this.each(function() {
                var e = mt(this).data(bt),
                t = "object" == typeof n && n;
                if ((e || !/dispose|hide/.test(n)) && (e || (e = new r(this, t), mt(this).data(bt, e)), "string" == typeof n)) {
                    if (void 0 === e[n]) throw new TypeError('No method named "' + n + '"');
                    e[n]()
                }
            })
        },
        a(r, null, [{
            key: "VERSION",
            get: function() {
                return "4.1.3"
            }
        },
        {
            key: "Default",
            get: function() {
                return Tt
            }
        },
        {
            key: "NAME",
            get: function() {
                return yt
            }
        },
        {
            key: "DATA_KEY",
            get: function() {
                return bt
            }
        },
        {
            key: "Event",
            get: function() {
                return Dt
            }
        },
        {
            key: "EVENT_KEY",
            get: function() {
                return _t
            }
        },
        {
            key: "DefaultType",
            get: function() {
                return Ct
            }
        }]),
        r
    } (), mt.fn[yt] = Rt._jQueryInterface, mt.fn[yt].Constructor = Rt, mt.fn[yt].noConflict = function() {
        return mt.fn[yt] = wt,
        Rt._jQueryInterface
    },
    Rt),
    Yn = (Ht = "popover", $t = "." + (Bt = "bs.popover"), Wt = (Mt = t).fn[Ht], Ut = "bs-popover", zt = new RegExp("(^|\\s)" + Ut + "\\S+", "g"), Vt = l({},
    Qn.Default, {
        placement: "right",
        trigger: "click",
        content: "",
        template: '<div class="popover" role="tooltip"><div class="arrow"></div><h3 class="popover-header"></h3><div class="popover-body"></div></div>'
    }), Kt = l({},
    Qn.DefaultType, {
        content: "(string|element|function)"
    }), Qt = "fade", Jt = ".popover-header", Xt = ".popover-body", Gt = {
        HIDE: "hide" + $t,
        HIDDEN: "hidden" + $t,
        SHOW: (Yt = "show") + $t,
        SHOWN: "shown" + $t,
        INSERTED: "inserted" + $t,
        CLICK: "click" + $t,
        FOCUSIN: "focusin" + $t,
        FOCUSOUT: "focusout" + $t,
        MOUSEENTER: "mouseenter" + $t,
        MOUSELEAVE: "mouseleave" + $t
    },
    Zt = function(e) {
        var t, n;
        function r() {
            return e.apply(this, arguments) || this
        }
        n = e,
        (t = r).prototype = Object.create(n.prototype),
        (t.prototype.constructor = t).__proto__ = n;
        var i = r.prototype;
        return i.isWithContent = function() {
            return this.getTitle() || this._getContent()
        },
        i.addAttachmentClass = function(e) {
            Mt(this.getTipElement()).addClass(Ut + "-" + e)
        },
        i.getTipElement = function() {
            return this.tip = this.tip || Mt(this.config.template)[0],
            this.tip
        },
        i.setContent = function() {
            var e = Mt(this.getTipElement());
            this.setElementContent(e.find(Jt), this.getTitle());
            var t = this._getContent();
            "function" == typeof t && (t = t.call(this.element)),
            this.setElementContent(e.find(Xt), t),
            e.removeClass(Qt + " " + Yt)
        },
        i._getContent = function() {
            return this.element.getAttribute("data-content") || this.config.content
        },
        i._cleanTipClass = function() {
            var e = Mt(this.getTipElement()),
            t = e.attr("class").match(zt);
            null !== t && 0 < t.length && e.removeClass(t.join(""))
        },
        r._jQueryInterface = function(n) {
            return this.each(function() {
                var e = Mt(this).data(Bt),
                t = "object" == typeof n ? n: null;
                if ((e || !/destroy|hide/.test(n)) && (e || (e = new r(this, t), Mt(this).data(Bt, e)), "string" == typeof n)) {
                    if (void 0 === e[n]) throw new TypeError('No method named "' + n + '"');
                    e[n]()
                }
            })
        },
        a(r, null, [{
            key: "VERSION",
            get: function() {
                return "4.1.3"
            }
        },
        {
            key: "Default",
            get: function() {
                return Vt
            }
        },
        {
            key: "NAME",
            get: function() {
                return Ht
            }
        },
        {
            key: "DATA_KEY",
            get: function() {
                return Bt
            }
        },
        {
            key: "Event",
            get: function() {
                return Gt
            }
        },
        {
            key: "EVENT_KEY",
            get: function() {
                return $t
            }
        },
        {
            key: "DefaultType",
            get: function() {
                return Kt
            }
        }]),
        r
    } (Qn), Mt.fn[Ht] = Zt._jQueryInterface, Mt.fn[Ht].Constructor = Zt, Mt.fn[Ht].noConflict = function() {
        return Mt.fn[Ht] = Wt,
        Zt._jQueryInterface
    },
    Zt),
    Jn = (tn = "scrollspy", rn = "." + (nn = "bs.scrollspy"), on = (en = t).fn[tn], an = {
        offset: 10,
        method: "auto",
        target: ""
    },
    sn = {
        offset: "number",
        method: "string",
        target: "(string|element)"
    },
    ln = {
        ACTIVATE: "activate" + rn,
        SCROLL: "scroll" + rn,
        LOAD_DATA_API: "load" + rn + ".data-api"
    },
    un = "dropdown-item", cn = "active", fn = '[data-spy="scroll"]', hn = ".active", pn = ".nav, .list-group", dn = ".nav-link", gn = ".nav-item", vn = ".list-group-item", mn = ".dropdown", yn = ".dropdown-item", bn = ".dropdown-toggle", _n = "offset", wn = "position", xn = function() {
        function n(e, t) {
            var n = this;
            this._element = e,
            this._scrollElement = "BODY" === e.tagName ? window: e,
            this._config = this._getConfig(t),
            this._selector = this._config.target + " " + dn + "," + this._config.target + " " + vn + "," + this._config.target + " " + yn,
            this._offsets = [],
            this._targets = [],
            this._activeTarget = null,
            this._scrollHeight = 0,
            en(this._scrollElement).on(ln.SCROLL,
            function(e) {
                return n._process(e)
            }),
            this.refresh(),
            this._process()
        }
        var e = n.prototype;
        return e.refresh = function() {
            var t = this,
            e = this._scrollElement === this._scrollElement.window ? _n: wn,
            i = "auto" === this._config.method ? e: this._config.method,
            o = i === wn ? this._getScrollTop() : 0;
            this._offsets = [],
            this._targets = [],
            this._scrollHeight = this._getScrollHeight(),
            [].slice.call(document.querySelectorAll(this._selector)).map(function(e) {
                var t, n = Bn.getSelectorFromElement(e);
                if (n && (t = document.querySelector(n)), t) {
                    var r = t.getBoundingClientRect();
                    if (r.width || r.height) return [en(t)[i]().top + o, n]
                }
                return null
            }).filter(function(e) {
                return e
            }).sort(function(e, t) {
                return e[0] - t[0]
            }).forEach(function(e) {
                t._offsets.push(e[0]),
                t._targets.push(e[1])
            })
        },
        e.dispose = function() {
            en.removeData(this._element, nn),
            en(this._scrollElement).off(rn),
            this._element = null,
            this._scrollElement = null,
            this._config = null,
            this._selector = null,
            this._offsets = null,
            this._targets = null,
            this._activeTarget = null,
            this._scrollHeight = null
        },
        e._getConfig = function(e) {
            if ("string" != typeof(e = l({},
            an, "object" == typeof e && e ? e: {})).target) {
                var t = en(e.target).attr("id");
                t || (t = Bn.getUID(tn), en(e.target).attr("id", t)),
                e.target = "#" + t
            }
            return Bn.typeCheckConfig(tn, e, sn),
            e
        },
        e._getScrollTop = function() {
            return this._scrollElement === window ? this._scrollElement.pageYOffset: this._scrollElement.scrollTop
        },
        e._getScrollHeight = function() {
            return this._scrollElement.scrollHeight || Math.max(document.body.scrollHeight, document.documentElement.scrollHeight)
        },
        e._getOffsetHeight = function() {
            return this._scrollElement === window ? window.innerHeight: this._scrollElement.getBoundingClientRect().height
        },
        e._process = function() {
            var e = this._getScrollTop() + this._config.offset,
            t = this._getScrollHeight(),
            n = this._config.offset + t - this._getOffsetHeight();
            if (this._scrollHeight !== t && this.refresh(), n <= e) {
                var r = this._targets[this._targets.length - 1];
                this._activeTarget !== r && this._activate(r)
            } else {
                if (this._activeTarget && e < this._offsets[0] && 0 < this._offsets[0]) return this._activeTarget = null,
                void this._clear();
                for (var i = this._offsets.length; i--;) {
                    this._activeTarget !== this._targets[i] && e >= this._offsets[i] && (void 0 === this._offsets[i + 1] || e < this._offsets[i + 1]) && this._activate(this._targets[i])
                }
            }
        },
        e._activate = function(t) {
            this._activeTarget = t,
            this._clear();
            var e = this._selector.split(",");
            e = e.map(function(e) {
                return e + '[data-target="' + t + '"],' + e + '[href="' + t + '"]'
            });
            var n = en([].slice.call(document.querySelectorAll(e.join(","))));
            n.hasClass(un) ? (n.closest(mn).find(bn).addClass(cn), n.addClass(cn)) : (n.addClass(cn), n.parents(pn).prev(dn + ", " + vn).addClass(cn), n.parents(pn).prev(gn).children(dn).addClass(cn)),
            en(this._scrollElement).trigger(ln.ACTIVATE, {
                relatedTarget: t
            })
        },
        e._clear = function() {
            var e = [].slice.call(document.querySelectorAll(this._selector));
            en(e).filter(hn).removeClass(cn)
        },
        n._jQueryInterface = function(t) {
            return this.each(function() {
                var e = en(this).data(nn);
                if (e || (e = new n(this, "object" == typeof t && t), en(this).data(nn, e)), "string" == typeof t) {
                    if (void 0 === e[t]) throw new TypeError('No method named "' + t + '"');
                    e[t]()
                }
            })
        },
        a(n, null, [{
            key: "VERSION",
            get: function() {
                return "4.1.3"
            }
        },
        {
            key: "Default",
            get: function() {
                return an
            }
        }]),
        n
    } (), en(window).on(ln.LOAD_DATA_API,
    function() {
        for (var e = [].slice.call(document.querySelectorAll(fn)), t = e.length; t--;) {
            var n = en(e[t]);
            xn._jQueryInterface.call(n, n.data())
        }
    }), en.fn[tn] = xn._jQueryInterface, en.fn[tn].Constructor = xn, en.fn[tn].noConflict = function() {
        return en.fn[tn] = on,
        xn._jQueryInterface
    },
    xn),
    Xn = (Sn = "." + (Cn = "bs.tab"), Tn = (En = t).fn.tab, kn = {
        HIDE: "hide" + Sn,
        HIDDEN: "hidden" + Sn,
        SHOW: "show" + Sn,
        SHOWN: "shown" + Sn,
        CLICK_DATA_API: "click.bs.tab.data-api"
    },
    An = "dropdown-menu", Dn = "active", On = "disabled", jn = "fade", Nn = "show", In = ".dropdown", Ln = ".nav, .list-group", Pn = ".active", qn = "> li > .active", Fn = '[data-toggle="tab"], [data-toggle="pill"], [data-toggle="list"]', Rn = ".dropdown-toggle", Mn = "> .dropdown-menu .active", Hn = function() {
        function r(e) {
            this._element = e
        }
        var e = r.prototype;
        return e.show = function() {
            var n = this;
            if (! (this._element.parentNode && this._element.parentNode.nodeType === Node.ELEMENT_NODE && En(this._element).hasClass(Dn) || En(this._element).hasClass(On))) {
                var e, r, t = En(this._element).closest(Ln)[0],
                i = Bn.getSelectorFromElement(this._element);
                if (t) {
                    var o = "UL" === t.nodeName ? qn: Pn;
                    r = (r = En.makeArray(En(t).find(o)))[r.length - 1]
                }
                var a = En.Event(kn.HIDE, {
                    relatedTarget: this._element
                }),
                s = En.Event(kn.SHOW, {
                    relatedTarget: r
                });
                if (r && En(r).trigger(a), En(this._element).trigger(s), !s.isDefaultPrevented() && !a.isDefaultPrevented()) {
                    i && (e = document.querySelector(i)),
                    this._activate(this._element, t);
                    var l = function() {
                        var e = En.Event(kn.HIDDEN, {
                            relatedTarget: n._element
                        }),
                        t = En.Event(kn.SHOWN, {
                            relatedTarget: r
                        });
                        En(r).trigger(e),
                        En(n._element).trigger(t)
                    };
                    e ? this._activate(e, e.parentNode, l) : l()
                }
            }
        },
        e.dispose = function() {
            En.removeData(this._element, Cn),
            this._element = null
        },
        e._activate = function(e, t, n) {
            var r = this,
            i = ("UL" === t.nodeName ? En(t).find(qn) : En(t).children(Pn))[0],
            o = n && i && En(i).hasClass(jn),
            a = function() {
                return r._transitionComplete(e, i, n)
            };
            if (i && o) {
                var s = Bn.getTransitionDurationFromElement(i);
                En(i).one(Bn.TRANSITION_END, a).emulateTransitionEnd(s)
            } else a()
        },
        e._transitionComplete = function(e, t, n) {
            if (t) {
                En(t).removeClass(Nn + " " + Dn);
                var r = En(t.parentNode).find(Mn)[0];
                r && En(r).removeClass(Dn),
                "tab" === t.getAttribute("role") && t.setAttribute("aria-selected", !1)
            }
            if (En(e).addClass(Dn), "tab" === e.getAttribute("role") && e.setAttribute("aria-selected", !0), Bn.reflow(e), En(e).addClass(Nn), e.parentNode && En(e.parentNode).hasClass(An)) {
                var i = En(e).closest(In)[0];
                if (i) {
                    var o = [].slice.call(i.querySelectorAll(Rn));
                    En(o).addClass(Dn)
                }
                e.setAttribute("aria-expanded", !0)
            }
            n && n()
        },
        r._jQueryInterface = function(n) {
            return this.each(function() {
                var e = En(this),
                t = e.data(Cn);
                if (t || (t = new r(this), e.data(Cn, t)), "string" == typeof n) {
                    if (void 0 === t[n]) throw new TypeError('No method named "' + n + '"');
                    t[n]()
                }
            })
        },
        a(r, null, [{
            key: "VERSION",
            get: function() {
                return "4.1.3"
            }
        }]),
        r
    } (), En(document).on(kn.CLICK_DATA_API, Fn,
    function(e) {
        e.preventDefault(),
        Hn._jQueryInterface.call(En(this), "show")
    }), En.fn.tab = Hn._jQueryInterface, En.fn.tab.Constructor = Hn, En.fn.tab.noConflict = function() {
        return En.fn.tab = Tn,
        Hn._jQueryInterface
    },
    Hn); !
    function(e) {
        if (void 0 === e) throw new TypeError("Bootstrap's JavaScript requires jQuery. jQuery must be included before Bootstrap's JavaScript.");
        var t = e.fn.jquery.split(" ")[0].split(".");
        if (t[0] < 2 && t[1] < 9 || 1 === t[0] && 9 === t[1] && t[2] < 1 || 4 <= t[0]) throw new Error("Bootstrap's JavaScript requires at least jQuery v1.9.1 but less than v4.0.0")
    } (t),
    e.Util = Bn,
    e.Alert = $n,
    e.Button = Wn,
    e.Carousel = Un,
    e.Collapse = zn,
    e.Dropdown = Vn,
    e.Modal = Kn,
    e.Popover = Yn,
    e.Scrollspy = Jn,
    e.Tab = Xn,
    e.Tooltip = Qn,
    Object.defineProperty(e, "__esModule", {
        value: !0
    })
}),
function(e) {
    var t = !1;
    if ("function" == typeof define && define.amd && (define(e), t = !0), "object" == typeof exports && (module.exports = e(), t = !0), !t) {
        var n = window.Cookies,
        r = window.Cookies = e();
        r.noConflict = function() {
            return window.Cookies = n,
            r
        }
    }
} (function() {
    function g() {
        for (var e = 0,
        t = {}; e < arguments.length; e++) {
            var n = arguments[e];
            for (var r in n) t[r] = n[r]
        }
        return t
    }
    return function e(p) {
        function d(e, t, n) {
            var r;
            if ("undefined" != typeof document) {
                if (1 < arguments.length) {
                    if ("number" == typeof(n = g({
                        path: "/"
                    },
                    d.defaults, n)).expires) {
                        var i = new Date;
                        i.setMilliseconds(i.getMilliseconds() + 864e5 * n.expires),
                        n.expires = i
                    }
                    n.expires = n.expires ? n.expires.toUTCString() : "";
                    try {
                        r = JSON.stringify(t),
                        /^[\{\[]/.test(r) && (t = r)
                    } catch(e) {}
                    t = p.write ? p.write(t, e) : encodeURIComponent(String(t)).replace(/%(23|24|26|2B|3A|3C|3E|3D|2F|3F|40|5B|5D|5E|60|7B|7D|7C)/g, decodeURIComponent),
                    e = (e = (e = encodeURIComponent(String(e))).replace(/%(23|24|26|2B|5E|60|7C)/g, decodeURIComponent)).replace(/[\(\)]/g, escape);
                    var o = "";
                    for (var a in n) n[a] && (o += "; " + a, !0 !== n[a] && (o += "=" + n[a]));
                    return document.cookie = e + "=" + t + o
                }
                e || (r = {});
                for (var s = document.cookie ? document.cookie.split("; ") : [], l = /(%[0-9A-Z]{2})+/g, u = 0; u < s.length; u++) {
                    var c = s[u].split("="),
                    f = c.slice(1).join("=");
                    this.json || '"' !== f.charAt(0) || (f = f.slice(1, -1));
                    try {
                        var h = c[0].replace(l, decodeURIComponent);
                        if (f = p.read ? p.read(f, h) : p(f, h) || f.replace(l, decodeURIComponent), this.json) try {
                            f = JSON.parse(f)
                        } catch(e) {}
                        if (e === h) {
                            r = f;
                            break
                        }
                        e || (r[h] = f)
                    } catch(e) {}
                }
                return r
            }
        }
        return (d.set = d).get = function(e) {
            return d.call(d, e)
        },
        d.getJSON = function() {
            return d.apply({
                json: !0
            },
            [].slice.call(arguments))
        },
        d.defaults = {},
        d.remove = function(e, t) {
            d(e, "", g(t, {
                expires: -1
            }))
        },
        d.withConverter = e,
        d
    } (function() {})
}),
function(e) {
    "function" == typeof define && define.amd ? define(e) : window.purl = e()
} (function() {
    var o = {
        a: "href",
        img: "src",
        form: "action",
        base: "href",
        script: "src",
        iframe: "src",
        link: "href",
        embed: "src",
        object: "data"
    },
    a = ["source", "protocol", "authority", "userInfo", "user", "password", "host", "port", "relative", "path", "directory", "file", "query", "fragment"],
    n = {
        anchor: "fragment"
    },
    s = {
        strict: /^(?:([^:\/?#]+):)?(?:\/\/((?:(([^:@]*):?([^:@]*))?@)?([^:\/?#]*)(?::(\d*))?))?((((?:[^?#\/]*\/)*)([^?#]*))(?:\?([^#]*))?(?:#(.*))?)/,
        loose: /^(?:(?![^:@]+:[^:@\/]*@)([^:\/?#.]+):)?(?:\/\/)?((?:(([^:@]*):?([^:@]*))?@)?([^:\/?#]*)(?::(\d*))?)(((\/(?:[^?#](?![^?#\/]*\.[^?#\/.]+(?:[?#]|$)))*\/?)?([^?#\/]*))(?:\?([^#]*))?(?:#(.*))?)/
    },
    u = /^[0-9]+$/;
    function c(e, t) {
        if (0 === e[t].length) return e[t] = {};
        var n = {};
        for (var r in e[t]) n[r] = e[t][r];
        return e[t] = n
    }
    function l(e, t, n) {
        if (~t.indexOf("]")) { !
            function e(t, n, r, i) {
                var o = t.shift();
                if (o) {
                    var a = n[r] = n[r] || [];
                    "]" == o ? h(a) ? "" !== i && a.push(i) : "object" == typeof a ? a[function(e) {
                        var t = [];
                        for (var n in e) e.hasOwnProperty(n) && t.push(n);
                        return t
                    } (a).length] = i: a = n[r] = [n[r], i] : (~o.indexOf("]") && (o = o.substr(0, o.length - 1)), !u.test(o) && h(a) && (a = c(n, r)), e(t, a, o, i))
                } else h(n[r]) ? n[r].push(i) : "object" == typeof n[r] ? n[r] = i: void 0 === n[r] ? n[r] = i: n[r] = [n[r], i]
            } (t.split("["), e, "base", n)
        } else {
            if (!u.test(t) && h(e.base)) {
                var r = {};
                for (var i in e.base) r[i] = e.base[i];
                e.base = r
            }
            "" !== t && (o = e.base, s = n, void 0 === (l = o[a = t]) ? o[a] = s: h(l) ? l.push(s) : o[a] = [l, s])
        }
        var o, a, s, l;
        return e
    }
    function f(e) {
        return function(e, t) {
            var n = 0,
            r = e.length >> 0,
            i = arguments[2];
            for (; n < r;) n in e && (i = t.call(void 0, i, e[n], n, e)),
            ++n;
            return i
        } (String(e).split(/&|;/),
        function(e, t) {
            try {
                t = decodeURIComponent(t.replace(/\+/g, " "))
            } catch(e) {}
            var n = t.indexOf("="),
            r = function(e) {
                for (var t, n, r = e.length,
                i = 0; i < r; ++i) if ("]" == (n = e[i]) && (t = !1), "[" == n && (t = !0), "=" == n && !t) return i
            } (t),
            i = t.substr(0, r || n),
            o = t.substr(r || n, t.length);
            return o = o.substr(o.indexOf("=") + 1, o.length),
            "" === i && (i = t, o = ""),
            l(e, i, o)
        },
        {
            base: {}
        }).base
    }
    function h(e) {
        return "[object Array]" === Object.prototype.toString.call(e)
    }
    function p(e, t) {
        return 1 === arguments.length && !0 === e && (t = !0, e = void 0),
        t = t || !1,
        {
            data: function(e, t) {
                for (var n = decodeURI(e), r = s[t ? "strict": "loose"].exec(n), i = {
                    attr: {},
                    param: {},
                    seg: {}
                },
                o = 14; o--;) i.attr[a[o]] = r[o] || "";
                return i.param.query = f(i.attr.query),
                i.param.fragment = f(i.attr.fragment),
                i.seg.path = i.attr.path.replace(/^\/+|\/+$/g, "").split("/"),
                i.seg.fragment = i.attr.fragment.replace(/^\/+|\/+$/g, "").split("/"),
                i.attr.base = i.attr.host ? (i.attr.protocol ? i.attr.protocol + "://" + i.attr.host: i.attr.host) + (i.attr.port ? ":" + i.attr.port: "") : "",
                i
            } (e = e || window.location.toString(), t),
            attr: function(e) {
                return void 0 !== (e = n[e] || e) ? this.data.attr[e] : this.data.attr
            },
            param: function(e) {
                return void 0 !== e ? this.data.param.query[e] : this.data.param.query
            },
            fparam: function(e) {
                return void 0 !== e ? this.data.param.fragment[e] : this.data.param.fragment
            },
            segment: function(e) {
                return void 0 === e ? this.data.seg.path: (e = e < 0 ? this.data.seg.path.length + e: e - 1, this.data.seg.path[e])
            },
            fsegment: function(e) {
                return void 0 === e ? this.data.seg.fragment: (e = e < 0 ? this.data.seg.fragment.length + e: e - 1, this.data.seg.fragment[e])
            }
        }
    }
    return p.jQuery = function(i) {
        null != i && (i.fn.url = function(e) {
            var t, n, r = "";
            return this.length && (r = i(this).attr((t = this[0], void 0 !== (n = t.tagName) ? o[n.toLowerCase()] : n)) || ""),
            p(r, e)
        },
        i.url = p)
    },
    p.jQuery(window.jQuery),
    p
}),
function(e, t) {
    "object" == typeof exports && "object" == typeof module ? module.exports = t() : "function" == typeof define && define.amd ? define([], t) : "object" == typeof exports ? exports.nunjucks = t() : e.nunjucks = t()
} ("undefined" != typeof self ? self: this,
function() {
    return function(n) {
        var r = {};
        function i(e) {
            if (r[e]) return r[e].exports;
            var t = r[e] = {
                i: e,
                l: !1,
                exports: {}
            };
            return n[e].call(t.exports, t, t.exports, i),
            t.l = !0,
            t.exports
        }
        return i.m = n,
        i.c = r,
        i.d = function(e, t, n) {
            i.o(e, t) || Object.defineProperty(e, t, {
                configurable: !1,
                enumerable: !0,
                get: n
            })
        },
        i.n = function(e) {
            var t = e && e.__esModule ?
            function() {
                return e.
            default
            }:
            function() {
                return e
            };
            return i.d(t, "a", t),
            t
        },
        i.o = function(e, t) {
            return Object.prototype.hasOwnProperty.call(e, t)
        },
        i.p = "",
        i(i.s = 6)
    } ([function(e, t) {},
    function(e, t, n) {
        "use strict";
        var o = Array.prototype,
        r = Object.prototype,
        i = {
            "&": "&amp;",
            '"': "&quot;",
            "'": "&#39;",
            "<": "&lt;",
            ">": "&gt;"
        },
        a = /[&"'<>]/g,
        s = e.exports = {};
        function l(e, t) {
            return r.hasOwnProperty.call(e, t)
        }
        function u(e) {
            return i[e]
        }
        function c(e, t, n) {
            var r, i, o;
            if (e instanceof Error && (e = (i = e).name + ": " + i.message), Object.setPrototypeOf ? (r = new Error(e), Object.setPrototypeOf(r, c.prototype)) : (r = this, Object.defineProperty(r, "message", {
                enumerable: !1,
                writable: !0,
                value: e
            })), Object.defineProperty(r, "name", {
                value: "Template render error"
            }), Error.captureStackTrace && Error.captureStackTrace(r, this.constructor), i) {
                var a = Object.getOwnPropertyDescriptor(i, "stack"); (o = a && (a.get ||
                function() {
                    return a.value
                })) || (o = function() {
                    return i.stack
                })
            } else {
                var s = new Error(e).stack;
                o = function() {
                    return s
                }
            }
            return Object.defineProperty(r, "stack", {
                get: function() {
                    return o.call(r)
                }
            }),
            Object.defineProperty(r, "cause", {
                value: i
            }),
            r.lineno = t,
            r.colno = n,
            r.firstUpdate = !0,
            r.Update = function(e) {
                var t = "(" + (e || "unknown path") + ")";
                return this.firstUpdate && (this.lineno && this.colno ? t += " [Line " + this.lineno + ", Column " + this.colno + "]": this.lineno && (t += " [Line " + this.lineno + "]")),
                t += "\n ",
                this.firstUpdate && (t += " "),
                this.message = t + (this.message || ""),
                this.firstUpdate = !1,
                this
            },
            r
        }
        function f(e) {
            return "[object Function]" === r.toString.call(e)
        }
        function h(e) {
            return "[object Array]" === r.toString.call(e)
        }
        function p(e) {
            return "[object String]" === r.toString.call(e)
        }
        function d(e) {
            return "[object Object]" === r.toString.call(e)
        }
        function g(e) {
            return Array.prototype.slice.call(e)
        }
        function v(e, t, n) {
            return Array.prototype.indexOf.call(e || [], t, n)
        }
        function m(e) {
            var t = [];
            for (var n in e) l(e, n) && t.push(n);
            return t
        }
        s.hasOwnProp = l,
        s._prettifyError = function(e, t, n) {
            if (n.Update || (n = new s.TemplateError(n)), n.Update(e), !t) {
                var r = n; (n = new Error(r.message)).name = r.name
            }
            return n
        },
        Object.setPrototypeOf ? Object.setPrototypeOf(c.prototype, Error.prototype) : c.prototype = Object.create(Error.prototype, {
            constructor: {
                value: c
            }
        }),
        s.TemplateError = c,
        s.escape = function(e) {
            return e.replace(a, u)
        },
        s.isFunction = f,
        s.isArray = h,
        s.isString = p,
        s.isObject = d,
        s.groupBy = function(e, t) {
            for (var n = {},
            r = f(t) ? t: function(e) {
                return e[t]
            },
            i = 0; i < e.length; i++) {
                var o = e[i],
                a = r(o, i); (n[a] || (n[a] = [])).push(o)
            }
            return n
        },
        s.toArray = g,
        s.without = function(e) {
            var t = [];
            if (!e) return t;
            for (var n = e.length,
            r = g(arguments).slice(1), i = -1; ++i < n;) - 1 === v(r, e[i]) && t.push(e[i]);
            return t
        },
        s.repeat = function(e, t) {
            for (var n = "",
            r = 0; r < t; r++) n += e;
            return n
        },
        s.each = function(e, t, n) {
            if (null != e) if (o.forEach && e.forEach === o.forEach) e.forEach(t, n);
            else if (e.length === +e.length) for (var r = 0,
            i = e.length; r < i; r++) t.call(n, e[r], r, e)
        },
        s.map = function(e, t) {
            var n = [];
            if (null == e) return n;
            if (o.map && e.map === o.map) return e.map(t);
            for (var r = 0; r < e.length; r++) n[n.length] = t(e[r], r);
            return e.length === +e.length && (n.length = e.length),
            n
        },
        s.asyncIter = function(t, n, r) {
            var i = -1; !
            function e() {++i < t.length ? n(t[i], i, e, r) : r()
            } ()
        },
        s.asyncFor = function(n, r, i) {
            var o = m(n || {}),
            a = o.length,
            s = -1; !
            function e() {
                var t = o[++s];
                s < a ? r(t, n[t], s, a, e) : i()
            } ()
        },
        s.indexOf = v,
        s.keys = m,
        s._entries = function(t) {
            return m(t).map(function(e) {
                return [e, t[e]]
            })
        },
        s._values = function(t) {
            return m(t).map(function(e) {
                return t[e]
            })
        },
        s._assign = s.extend = function(t, n) {
            return t = t || {},
            m(n).forEach(function(e) {
                t[e] = n[e]
            }),
            t
        },
        s.inOperator = function(e, t) {
            if (h(t) || p(t)) return - 1 !== t.indexOf(e);
            if (d(t)) return e in t;
            throw new Error('Cannot use "in" operator to search for "' + e + '" in unexpected types.')
        }
    },
    function(e, t, n) {
        "use strict";
        var p = n(1),
        r = Array.from,
        i = "function" == typeof Symbol && Symbol.iterator && "function" == typeof r,
        o = function() {
            function t(e, t) {
                this.variables = {},
                this.parent = e,
                this.topLevel = !1,
                this.isolateWrites = t
            }
            var e = t.prototype;
            return e.set = function(e, t, n) {
                var r = e.split("."),
                i = this.variables,
                o = this;
                if (n && (o = this.resolve(r[0], !0))) o.set(e, t);
                else {
                    for (var a = 0; a < r.length - 1; a++) {
                        var s = r[a];
                        i[s] || (i[s] = {}),
                        i = i[s]
                    }
                    i[r[r.length - 1]] = t
                }
            },
            e.get = function(e) {
                var t = this.variables[e];
                return void 0 !== t ? t: null
            },
            e.lookup = function(e) {
                var t = this.parent,
                n = this.variables[e];
                return void 0 !== n ? n: t && t.lookup(e)
            },
            e.resolve = function(e, t) {
                var n = t && this.isolateWrites ? void 0 : this.parent;
                return void 0 !== this.variables[e] ? this: n && n.resolve(e)
            },
            e.push = function(e) {
                return new t(this, e)
            },
            e.pop = function() {
                return this.parent
            },
            t
        } ();
        function h(e) {
            return e && Object.prototype.hasOwnProperty.call(e, "__keywords")
        }
        function d(e) {
            var t = e.length;
            return 0 === t ? 0 : h(e[t - 1]) ? t - 1 : t
        }
        function a(e) {
            if ("string" != typeof e) return e;
            this.val = e,
            this.length = e.length
        } (a.prototype = Object.create(String.prototype, {
            length: {
                writable: !0,
                configurable: !0,
                value: 0
            }
        })).valueOf = function() {
            return this.val
        },
        a.prototype.toString = function() {
            return this.val
        },
        e.exports = {
            Frame: o,
            makeMacro: function(l, u, c) {
                var f = this;
                return function() {
                    for (var e = arguments.length,
                    t = new Array(e), n = 0; n < e; n++) t[n] = arguments[n];
                    var r, i = d(t),
                    o = function(e) {
                        var t = e.length;
                        if (t) {
                            var n = e[t - 1];
                            if (h(n)) return n
                        }
                        return {}
                    } (t);
                    if (i > l.length) r = t.slice(0, l.length),
                    t.slice(r.length, i).forEach(function(e, t) {
                        t < u.length && (o[u[t]] = e)
                    }),
                    r.push(o);
                    else if (i < l.length) {
                        r = t.slice(0, i);
                        for (var a = i; a < l.length; a++) {
                            var s = l[a];
                            r.push(o[s]),
                            delete o[s]
                        }
                        r.push(o)
                    } else r = t;
                    return c.apply(f, r)
                }
            },
            makeKeywordArgs: function(e) {
                return e.__keywords = !0,
                e
            },
            numArgs: d,
            suppressValue: function(e, t) {
                return e = null != e ? e: "",
                !t || e instanceof a || (e = p.escape(e.toString())),
                e
            },
            ensureDefined: function(e, t, n) {
                if (null == e) throw new p.TemplateError("attempted to output null or undefined value", t + 1, n + 1);
                return e
            },
            memberLookup: function(r, i) {
                if (null != r) return "function" == typeof r[i] ?
                function() {
                    for (var e = arguments.length,
                    t = new Array(e), n = 0; n < e; n++) t[n] = arguments[n];
                    return r[i].apply(r, t)
                }: r[i]
            },
            contextOrFrameLookup: function(e, t, n) {
                var r = t.lookup(n);
                return void 0 !== r ? r: e.lookup(n)
            },
            callWrap: function(e, t, n, r) {
                if (!e) throw new Error("Unable to call `" + t + "`, which is undefined or falsey");
                if ("function" != typeof e) throw new Error("Unable to call `" + t + "`, which is not a function");
                return e.apply(n, r)
            },
            handleError: function(e, t, n) {
                return e.lineno ? e: new p.TemplateError(e, t, n)
            },
            isArray: p.isArray,
            keys: p.keys,
            SafeString: a,
            copySafeness: function(e, t) {
                return e instanceof a ? new a(t) : t.toString()
            },
            markSafe: function(n) {
                var e = typeof n;
                return "string" === e ? new a(n) : "function" !== e ? n: function(e) {
                    var t = n.apply(this, arguments);
                    return "string" == typeof t ? new a(t) : t
                }
            },
            asyncEach: function(e, r, o, t) {
                if (p.isArray(e)) {
                    var i = e.length;
                    p.asyncIter(e,
                    function(e, t, n) {
                        switch (r) {
                        case 1:
                            o(e, t, i, n);
                            break;
                        case 2:
                            o(e[0], e[1], t, i, n);
                            break;
                        case 3:
                            o(e[0], e[1], e[2], t, i, n);
                            break;
                        default:
                            e.push(t, i, n),
                            o.apply(this, e)
                        }
                    },
                    t)
                } else p.asyncFor(e,
                function(e, t, n, r, i) {
                    o(e, t, n, r, i)
                },
                t)
            },
            asyncAll: function(e, t, n, r) {
                var i, o, a = 0;
                function s(e, t) {
                    a++,
                    o[e] = t,
                    a === i && r(null, o.join(""))
                }
                if (p.isArray(e)) if (i = e.length, o = new Array(i), 0 === i) r(null, "");
                else for (var l = 0; l < e.length; l++) {
                    var u = e[l];
                    switch (t) {
                    case 1:
                        n(u, l, i, s);
                        break;
                    case 2:
                        n(u[0], u[1], l, i, s);
                        break;
                    case 3:
                        n(u[0], u[1], u[2], l, i, s);
                        break;
                    default:
                        u.push(l, i, s),
                        n.apply(this, u)
                    }
                } else {
                    var c = p.keys(e || {});
                    if (i = c.length, o = new Array(i), 0 === i) r(null, "");
                    else for (var f = 0; f < c.length; f++) {
                        var h = c[f];
                        n(h, e[h], f, i, s)
                    }
                }
            },
            inOperator: p.inOperator,
            fromIterator: function(e) {
                return "object" != typeof e || null === e || p.isArray(e) ? e: i && Symbol.iterator in e ? r(e) : e
            }
        }
    },
    function(e, t, n) {
        "use strict";
        var r = function(n) {
            function e(e) {
                var t;
                return (t = n.call(this) || this).precompiled = e || {},
                t
            }
            var t, r;
            return e.prototype.getSource = function(e) {
                return this.precompiled[e] ? {
                    src: {
                        type: "code",
                        obj: this.precompiled[e]
                    },
                    path: e
                }: null
            },
            r = n,
            (t = e).prototype.__proto__ = r && r.prototype,
            t.__proto__ = r,
            e
        } (n(4));
        e.exports = {
            PrecompiledLoader: r
        }
    },
    function(e, t, n) {
        "use strict";
        var o = n(0),
        r = n(5);
        e.exports = function(e) {
            function t() {
                return e.apply(this, arguments) || this
            }
            var n, r, i = t.prototype;
            return i.on = function(e, t) {
                this.listeners = this.listeners || {},
                this.listeners[e] = this.listeners[e] || [],
                this.listeners[e].push(t)
            },
            i.emit = function(e) {
                for (var t = arguments.length,
                n = new Array(1 < t ? t - 1 : 0), r = 1; r < t; r++) n[r - 1] = arguments[r];
                this.listeners && this.listeners[e] && this.listeners[e].forEach(function(e) {
                    e.apply(void 0, n)
                })
            },
            i.resolve = function(e, t) {
                return o.resolve(o.dirname(e), t)
            },
            i.isRelative = function(e) {
                return 0 === e.indexOf("./") || 0 === e.indexOf("../")
            },
            r = e,
            (n = t).prototype.__proto__ = r && r.prototype,
            n.__proto__ = r,
            t
        } (r)
    },
    function(e, t, n) {
        "use strict";
        function r(e, t) {
            for (var n = 0; n < t.length; n++) {
                var r = t[n];
                r.enumerable = r.enumerable || !1,
                r.configurable = !0,
                "value" in r && (r.writable = !0),
                Object.defineProperty(e, r.key, r)
            }
        }
        function a(e, t, n) {
            return t && r(e.prototype, t),
            n && r(e, n),
            e
        }
        var s = n(1);
        var i = function() {
            function e() {
                this.init.apply(this, arguments)
            }
            return e.prototype.init = function() {},
            e.extend = function(e, t) {
                return "object" == typeof e && (t = e, e = "anonymous"),
                function(t, i, o) {
                    o = o || {},
                    s.keys(o).forEach(function(e) {
                        var n, r;
                        o[e] = (n = t.prototype[e], r = o[e], "function" != typeof n || "function" != typeof r ? r: function() {
                            var e = this.parent;
                            this.parent = n;
                            var t = r.apply(this, arguments);
                            return this.parent = e,
                            t
                        })
                    });
                    var e = function(e) {
                        function t() {
                            return e.apply(this, arguments) || this
                        }
                        var n, r;
                        return a(t, [{
                            key: "typename",
                            get: function() {
                                return i
                            }
                        }]),
                        r = e,
                        (n = t).prototype.__proto__ = r && r.prototype,
                        n.__proto__ = r,
                        t
                    } (t);
                    return s._assign(e.prototype, o),
                    e
                } (this, e, t)
            },
            a(e, [{
                key: "typename",
                get: function() {
                    return this.constructor.name
                }
            }]),
            e
        } ();
        e.exports = i
    },
    function(e, t, n) {
        "use strict";
        var i, r = n(1),
        o = n(7),
        a = o.Environment,
        s = o.Template,
        l = n(4),
        u = n(3),
        c = n(0),
        f = n(0),
        h = n(0),
        p = n(0),
        d = n(2),
        g = n(0),
        v = n(16);
        function m(e, t) {
            var n;
            return t = t || {},
            r.isObject(e) && (t = e, e = null),
            u.FileSystemLoader ? n = new u.FileSystemLoader(e, {
                watch: t.watch,
                noCache: t.noCache
            }) : u.WebLoader && (n = new u.WebLoader(e, {
                useCache: t.web && t.web.useCache,
                async: t.web && t.web.async
            })),
            i = new a(n, t),
            t && t.express && i.express(t.express),
            i
        }
        e.exports = {
            Environment: a,
            Template: s,
            Loader: l,
            FileSystemLoader: u.FileSystemLoader,
            PrecompiledLoader: u.PrecompiledLoader,
            WebLoader: u.WebLoader,
            compiler: f,
            parser: h,
            lexer: p,
            runtime: d,
            lib: r,
            nodes: g,
            installJinjaCompat: v,
            configure: m,
            reset: function() {
                i = void 0
            },
            compile: function(e, t, n, r) {
                return i || m(),
                new s(e, t, n, r)
            },
            render: function(e, t, n) {
                return i || m(),
                i.render(e, t, n)
            },
            renderString: function(e, t, n) {
                return i || m(),
                i.renderString(e, t, n)
            },
            precompile: c ? c.precompile: void 0,
            precompileString: c ? c.precompileString: void 0
        }
    },
    function(e, t, n) {
        "use strict";
        function r(e, t) {
            e.prototype.__proto__ = t && t.prototype,
            e.__proto__ = t
        }
        var i = n(8),
        o = n(11),
        f = n(1),
        a = n(0),
        s = n(12),
        l = n(3),
        u = l.FileSystemLoader,
        c = l.WebLoader,
        h = l.PrecompiledLoader,
        p = n(13),
        d = n(14),
        g = n(5),
        v = n(2),
        m = v.handleError,
        y = v.Frame,
        b = n(15);
        function _(e, t, n) {
            i(function() {
                e(t, n)
            })
        }
        var w = {
            type: "code",
            obj: {
                root: function(e, t, n, r, i) {
                    try {
                        i(null, "")
                    } catch(e) {
                        i(m(e, null, null))
                    }
                }
            }
        },
        x = function(e) {
            function t() {
                return e.apply(this, arguments) || this
            }
            var n = t.prototype;
            return n.init = function(e, t) {
                var r = this;
                t = this.opts = t || {},
                this.opts.dev = !!t.dev,
                this.opts.autoescape = null == t.autoescape || t.autoescape,
                this.opts.throwOnUndefined = !!t.throwOnUndefined,
                this.opts.trimBlocks = !!t.trimBlocks,
                this.opts.lstripBlocks = !!t.lstripBlocks,
                this.loaders = [],
                e ? this.loaders = f.isArray(e) ? e: [e] : u ? this.loaders = [new u("views")] : c && (this.loaders = [new c("/views")]),
                "undefined" != typeof window && window.nunjucksPrecompiled && this.loaders.unshift(new h(window.nunjucksPrecompiled)),
                this.initCache(),
                this.globals = d(),
                this.filters = {},
                this.tests = {},
                this.asyncFilters = [],
                this.extensions = {},
                this.extensionsList = [],
                f._entries(s).forEach(function(e) {
                    var t = e[0],
                    n = e[1];
                    return r.addFilter(t, n)
                }),
                f._entries(p).forEach(function(e) {
                    var t = e[0],
                    n = e[1];
                    return r.addTest(t, n)
                })
            },
            n.initCache = function() {
                this.loaders.forEach(function(t) {
                    t.cache = {},
                    "function" == typeof t.on && t.on("update",
                    function(e) {
                        t.cache[e] = null
                    })
                })
            },
            n.addExtension = function(e, t) {
                return t.__name = e,
                this.extensions[e] = t,
                this.extensionsList.push(t),
                this
            },
            n.removeExtension = function(e) {
                var t = this.getExtension(e);
                t && (this.extensionsList = f.without(this.extensionsList, t), delete this.extensions[e])
            },
            n.getExtension = function(e) {
                return this.extensions[e]
            },
            n.hasExtension = function(e) {
                return !! this.extensions[e]
            },
            n.addGlobal = function(e, t) {
                return this.globals[e] = t,
                this
            },
            n.getGlobal = function(e) {
                if (void 0 === this.globals[e]) throw new Error("global not found: " + e);
                return this.globals[e]
            },
            n.addFilter = function(e, t, n) {
                var r = t;
                return n && this.asyncFilters.push(e),
                this.filters[e] = r,
                this
            },
            n.getFilter = function(e) {
                if (!this.filters[e]) throw new Error("filter not found: " + e);
                return this.filters[e]
            },
            n.addTest = function(e, t) {
                return this.tests[e] = t,
                this
            },
            n.getTest = function(e) {
                if (!this.tests[e]) throw new Error("test not found: " + e);
                return this.tests[e]
            },
            n.resolveTemplate = function(e, t, n) {
                return ! (!e.isRelative || !t) && e.isRelative(n) && e.resolve ? e.resolve(t, n) : n
            },
            n.getTemplate = function(o, r, a, i, s) {
                var l, u = this,
                c = this,
                e = null;
                if (o && o.raw && (o = o.raw), f.isFunction(a) && (s = a, a = null, r = r || !1), f.isFunction(r) && (s = r, r = !1), o instanceof C) e = o;
                else {
                    if ("string" != typeof o) throw new Error("template names must be a string: " + o);
                    for (var t = 0; t < this.loaders.length; t++) {
                        var n = this.loaders[t];
                        if (e = n.cache[this.resolveTemplate(n, a, o)]) break
                    }
                }
                if (e) return r && e.compile(),
                s ? void s(null, e) : e;
                return f.asyncIter(this.loaders,
                function(n, e, r, i) {
                    function t(e, t) {
                        e ? i(e) : t ? (t.loader = n, i(null, t)) : r()
                    }
                    o = c.resolveTemplate(n, a, o),
                    n.async ? n.getSource(o, t) : t(null, n.getSource(o))
                },
                function(e, t) {
                    if (t || e || i || (e = new Error("template not found: " + o)), e) {
                        if (s) return void s(e);
                        throw e
                    }
                    var n;
                    t ? (n = new C(t.src, u, t.path, r), t.noCache || (t.loader.cache[o] = n)) : n = new C(w, u, "", r),
                    s ? s(null, n) : l = n
                }),
                l
            },
            n.express = function(e) {
                return b(this, e)
            },
            n.render = function(e, n, r) {
                f.isFunction(n) && (r = n, n = null);
                var i = null;
                return this.getTemplate(e,
                function(e, t) {
                    if (e && r) _(r, e);
                    else {
                        if (e) throw e;
                        i = t.render(n, r)
                    }
                }),
                i
            },
            n.renderString = function(e, t, n, r) {
                return f.isFunction(n) && (r = n, n = {}),
                new C(e, this, (n = n || {}).path).render(t, r)
            },
            n.waterfall = function(e, t, n) {
                return o(e, t, n)
            },
            r(t, e),
            t
        } (g),
        E = function(e) {
            function t() {
                return e.apply(this, arguments) || this
            }
            var n = t.prototype;
            return n.init = function(e, t, n) {
                var r = this;
                this.env = n || new x,
                this.ctx = f.extend({},
                e),
                this.blocks = {},
                this.exported = [],
                f.keys(t).forEach(function(e) {
                    r.addBlock(e, t[e])
                })
            },
            n.lookup = function(e) {
                return e in this.env.globals && !(e in this.ctx) ? this.env.globals[e] : this.ctx[e]
            },
            n.setVariable = function(e, t) {
                this.ctx[e] = t
            },
            n.getVariables = function() {
                return this.ctx
            },
            n.addBlock = function(e, t) {
                return this.blocks[e] = this.blocks[e] || [],
                this.blocks[e].push(t),
                this
            },
            n.getBlock = function(e) {
                if (!this.blocks[e]) throw new Error('unknown block "' + e + '"');
                return this.blocks[e][0]
            },
            n.getSuper = function(e, t, n, r, i, o) {
                var a = f.indexOf(this.blocks[t] || [], n),
                s = this.blocks[t][a + 1];
                if ( - 1 === a || !s) throw new Error('no super block available for "' + t + '"');
                s(e, this, r, i, o)
            },
            n.addExport = function(e) {
                this.exported.push(e)
            },
            n.getExported = function() {
                var t = this,
                n = {};
                return this.exported.forEach(function(e) {
                    n[e] = t.ctx[e]
                }),
                n
            },
            r(t, e),
            t
        } (g),
        C = function(e) {
            function t() {
                return e.apply(this, arguments) || this
            }
            var n = t.prototype;
            return n.init = function(e, t, n, r) {
                if (this.env = t || new x, f.isObject(e)) switch (e.type) {
                case "code":
                    this.tmplProps = e.obj;
                    break;
                case "string":
                    this.tmplStr = e.obj;
                    break;
                default:
                    throw new Error("Unexpected template object type " + e.type + "; expected 'code', or 'string'")
                } else {
                    if (!f.isString(e)) throw new Error("src must be a string or an object describing the source");
                    this.tmplStr = e
                }
                if (this.path = n, r) try {
                    this._compile()
                } catch(e) {
                    throw f._prettifyError(this.path, this.env.opts.dev, e)
                } else this.compiled = !1
            },
            n.render = function(e, t, n) {
                var r = this;
                "function" == typeof e ? (n = e, e = {}) : "function" == typeof t && (n = t, t = null);
                var i = !t;
                try {
                    this.compile()
                } catch(e) {
                    var o = f._prettifyError(this.path, this.env.opts.dev, e);
                    if (n) return _(n, o);
                    throw o
                }
                var a = new E(e || {},
                this.blocks, this.env),
                s = t ? t.push(!0) : new y;
                s.topLevel = !0;
                var l = null,
                u = !1;
                return this.rootRenderFunc(this.env, a, s, v,
                function(e, t) {
                    if (!u) if (e && (e = f._prettifyError(r.path, r.env.opts.dev, e), u = !0), n) i ? _(n, e, t) : n(e, t);
                    else {
                        if (e) throw e;
                        l = t
                    }
                }),
                l
            },
            n.getExported = function(e, t, n) {
                "function" == typeof e && (n = e, e = {}),
                "function" == typeof t && (n = t, t = null);
                try {
                    this.compile()
                } catch(e) {
                    if (n) return n(e);
                    throw e
                }
                var r = t ? t.push() : new y;
                r.topLevel = !0;
                var i = new E(e || {},
                this.blocks, this.env);
                this.rootRenderFunc(this.env, i, r, v,
                function(e) {
                    e ? n(e, null) : n(null, i.getExported())
                })
            },
            n.compile = function() {
                this.compiled || this._compile()
            },
            n._compile = function() {
                var e;
                if (this.tmplProps) e = this.tmplProps;
                else {
                    var t = a.compile(this.tmplStr, this.env.asyncFilters, this.env.extensionsList, this.path, this.env.opts);
                    e = new Function(t)()
                }
                this.blocks = this._getBlocks(e),
                this.rootRenderFunc = e.root,
                this.compiled = !0
            },
            n._getBlocks = function(t) {
                var n = {};
                return f.keys(t).forEach(function(e) {
                    "b_" === e.slice(0, 2) && (n[e.slice(2)] = t[e])
                }),
                n
            },
            r(t, e),
            t
        } (g);
        e.exports = {
            Environment: x,
            Template: C
        }
    },
    function(e, t, n) {
        "use strict";
        var r = n(9),
        i = [],
        o = [],
        a = r.makeRequestCallFromTimer(function() {
            if (o.length) throw o.shift()
        });
        function s(e) {
            var t; (t = i.length ? i.pop() : new l).task = e,
            r(t)
        }
        function l() {
            this.task = null
        }
        e.exports = s,
        l.prototype.call = function() {
            try {
                this.task.call()
            } catch(e) {
                s.onerror ? s.onerror(e) : (o.push(e), a())
            } finally {
                this.task = null,
                i[i.length] = this
            }
        }
    },
    function(h, e, t) {
        "use strict"; (function(e) {
            function t(e) {
                r.length || (n(), !0),
                r[r.length] = e
            }
            h.exports = t;
            var n, r = [],
            i = 0;
            function o() {
                for (; i < r.length;) {
                    var e = i;
                    if (i += 1, r[e].call(), 1024 < i) {
                        for (var t = 0,
                        n = r.length - i; t < n; t++) r[t] = r[t + i];
                        r.length -= i,
                        i = 0
                    }
                }
                r.length = 0,
                i = 0,
                !1
            }
            var a, s, l, u = void 0 !== e ? e: self,
            c = u.MutationObserver || u.WebKitMutationObserver;
            function f(r) {
                return function() {
                    var e = setTimeout(n, 0),
                    t = setInterval(n, 50);
                    function n() {
                        clearTimeout(e),
                        clearInterval(t),
                        r()
                    }
                }
            }
            "function" == typeof c ? (a = 1, s = new c(o), l = document.createTextNode(""), s.observe(l, {
                characterData: !0
            }), n = function() {
                a = -a,
                l.data = a
            }) : n = f(o),
            t.requestFlush = n,
            t.makeRequestCallFromTimer = f
        }).call(e, t(10))
    },
    function(Gra, Hra) {
        var Ira;
        Ira = function() {
            return this
        } ();
        try {
            Ira = Ira || Function("return this")() || eval("this")
        } catch(e) {
            "object" == typeof window && (Ira = window)
        }
        Gra.exports = Ira
    },
    function(n, r, e) {
        var i; !
        function(e) {
            "use strict";
            var l = function() {
                var e = Array.prototype.slice.call(arguments);
                "function" == typeof e[0] && e[0].apply(null, e.splice(1))
            },
            u = function(e) {
                "function" == typeof setImmediate ? setImmediate(e) : "undefined" != typeof process && process.nextTick ? process.nextTick(e) : setTimeout(e, 0)
            },
            c = Array.isArray ||
            function(e) {
                return "[object Array]" === Object.prototype.toString.call(e)
            },
            t = function(e, i, t) {
                var o = t ? u: l;
                if (i = i ||
                function() {},
                !c(e)) {
                    var n = new Error("First argument to waterfall must be an array of functions");
                    return i(n)
                }
                if (!e.length) return i();
                var r, a, s = function(r) {
                    return function(e) {
                        if (e) i.apply(null, arguments),
                        i = function() {};
                        else {
                            var t = Array.prototype.slice.call(arguments, 1),
                            n = r.next();
                            n ? t.push(s(n)) : t.push(i),
                            o(function() {
                                r.apply(null, t)
                            })
                        }
                    }
                };
                s((r = e, (a = function(e) {
                    var t = function() {
                        return r.length && r[e].apply(null, arguments),
                        t.next()
                    };
                    return t.next = function() {
                        return e < r.length - 1 ? a(e + 1) : null
                    },
                    t
                })(0)))()
            };
            void 0 === (i = function() {
                return t
            }.apply(r, [])) || (n.exports = i)
        } ()
    },
    function(e, t, n) {
        "use strict";
        var s = n(1),
        u = n(2),
        r = e.exports = {};
        function a(e, t) {
            return null == e || !1 === e ? t: e
        }
        function l(e) {
            return e != e
        }
        function i(e) {
            var t = (e = a(e, "")).toLowerCase();
            return u.copySafeness(e, t.charAt(0).toUpperCase() + t.slice(1))
        }
        function o(e) {
            if (s.isString(e)) return e.split("");
            if (s.isObject(e)) return s._entries(e || {}).map(function(e) {
                return {
                    key: e[0],
                    value: e[1]
                }
            });
            if (s.isArray(e)) return e;
            throw new s.TemplateError("list filter: type not iterable")
        }
        function c(e) {
            return u.copySafeness(e, e.replace(/^\s*|\s*$/g, ""))
        }
        r.abs = Math.abs,
        r.batch = function(e, t, n) {
            var r, i = [],
            o = [];
            for (r = 0; r < e.length; r++) r % t == 0 && o.length && (i.push(o), o = []),
            o.push(e[r]);
            if (o.length) {
                if (n) for (r = o.length; r < t; r++) o.push(n);
                i.push(o)
            }
            return i
        },
        r.capitalize = i,
        r.center = function(e, t) {
            if (t = t || 80, (e = a(e, "")).length >= t) return e;
            var n = t - e.length,
            r = s.repeat(" ", n / 2 - n % 2),
            i = s.repeat(" ", n / 2);
            return u.copySafeness(e, r + e + i)
        },
        r.
    default = function(e, t, n) {
            return n ? e || t: void 0 !== e ? e: t
        },
        r.dictsort = function(e, i, t) {
            if (!s.isObject(e)) throw new s.TemplateError("dictsort filter: val must be an object");
            var o, n = [];
            for (var r in e) n.push([r, e[r]]);
            if (void 0 === t || "key" === t) o = 0;
            else {
                if ("value" !== t) throw new s.TemplateError("dictsort filter: You can only sort by either key or value");
                o = 1
            }
            return n.sort(function(e, t) {
                var n = e[o],
                r = t[o];
                return i || (s.isString(n) && (n = n.toUpperCase()), s.isString(r) && (r = r.toUpperCase())),
                r < n ? 1 : n === r ? 0 : -1
            }),
            n
        },
        r.dump = function(e, t) {
            return JSON.stringify(e, null, t)
        },
        r.escape = function(e) {
            return e instanceof u.SafeString ? e: (e = null == e ? "": e, u.markSafe(s.escape(e.toString())))
        },
        r.safe = function(e) {
            return e instanceof u.SafeString ? e: (e = null == e ? "": e, u.markSafe(e.toString()))
        },
        r.first = function(e) {
            return e[0]
        },
        r.forceescape = function(e) {
            return e = null == e ? "": e,
            u.markSafe(s.escape(e.toString()))
        },
        r.groupby = function(e, t) {
            return s.groupBy(e, t)
        },
        r.indent = function(e, t, n) {
            if ("" === (e = a(e, ""))) return "";
            t = t || 4;
            var r = e.split("\n"),
            i = s.repeat(" ", t),
            o = r.map(function(e, t) {
                return 0 !== t || n ? "" + i + e + "\n": e + "\n"
            }).join("");
            return u.copySafeness(e, o)
        },
        r.join = function(e, t, n) {
            return t = t || "",
            n && (e = s.map(e,
            function(e) {
                return e[n]
            })),
            e.join(t)
        },
        r.last = function(e) {
            return e[e.length - 1]
        },
        r.length = function(e) {
            var t = a(e, "");
            return void 0 !== t ? "function" == typeof Map && t instanceof Map || "function" == typeof Set && t instanceof Set ? t.size: !s.isObject(t) || t instanceof u.SafeString ? t.length: s.keys(t).length: 0
        },
        r.list = o,
        r.lower = function(e) {
            return (e = a(e, "")).toLowerCase()
        },
        r.nl2br = function(e) {
            return null == e ? "": u.copySafeness(e, e.replace(/\r\n|\n/g, "<br />\n"))
        },
        r.random = function(e) {
            return e[Math.floor(Math.random() * e.length)]
        },
        r.rejectattr = function(e, t) {
            return e.filter(function(e) {
                return ! e[t]
            })
        },
        r.selectattr = function(e, t) {
            return e.filter(function(e) {
                return !! e[t]
            })
        },
        r.replace = function(e, t, n, r) {
            var i = e;
            if (t instanceof RegExp) return e.replace(t, n);
            void 0 === r && (r = -1);
            var o = "";
            if ("number" == typeof t) t = "" + t;
            else if ("string" != typeof t) return e;
            if ("number" == typeof e && (e = "" + e), "string" != typeof e && !(e instanceof u.SafeString)) return e;
            if ("" === t) return o = n + e.split("").join(n) + n,
            u.copySafeness(e, o);
            var a = e.indexOf(t);
            if (0 === r || -1 === a) return e;
            for (var s = 0,
            l = 0; - 1 < a && ( - 1 === r || l < r);) o += e.substring(s, a) + n,
            s = a + t.length,
            l++,
            a = e.indexOf(t, s);
            return s < e.length && (o += e.substring(s)),
            u.copySafeness(i, o)
        },
        r.reverse = function(e) {
            var t;
            return (t = s.isString(e) ? o(e) : s.map(e,
            function(e) {
                return e
            })).reverse(),
            s.isString(e) ? u.copySafeness(e, t.join("")) : t
        },
        r.round = function(e, t, n) {
            t = t || 0;
            var r = Math.pow(10, t);
            return ("ceil" === n ? Math.ceil: "floor" === n ? Math.floor: Math.round)(e * r) / r
        },
        r.slice = function(e, t, n) {
            for (var r = Math.floor(e.length / t), i = e.length % t, o = [], a = 0, s = 0; s < t; s++) {
                var l = a + s * r;
                s < i && a++;
                var u = a + (s + 1) * r,
                c = e.slice(l, u);
                n && i <= s && c.push(n),
                o.push(c)
            }
            return o
        },
        r.sum = function(e, t, n) {
            return void 0 === n && (n = 0),
            t && (e = s.map(e,
            function(e) {
                return e[t]
            })),
            n + e.reduce(function(e, t) {
                return e + t
            },
            0)
        },
        r.sort = u.makeMacro(["value", "reverse", "case_sensitive", "attribute"], [],
        function(e, i, o, a) {
            var t = s.map(e,
            function(e) {
                return e
            });
            return t.sort(function(e, t) {
                var n = a ? e[a] : e,
                r = a ? t[a] : t;
                return ! o && s.isString(n) && s.isString(r) && (n = n.toLowerCase(), r = r.toLowerCase()),
                n < r ? i ? 1 : -1 : r < n ? i ? -1 : 1 : 0
            }),
            t
        }),
        r.string = function(e) {
            return u.copySafeness(e, e)
        },
        r.striptags = function(e, t) {
            var n = c((e = a(e, "")).replace(/<\/?([a-z][a-z0-9]*)\b[^>]*>|<!--[\s\S]*?-->/gi, "")),
            r = "";
            return r = t ? n.replace(/^ +| +$/gm, "").replace(/ +/g, " ").replace(/(\r\n)/g, "\n").replace(/\n\n\n+/g, "\n\n") : n.replace(/\s+/gi, " "),
            u.copySafeness(e, r)
        },
        r.title = function(e) {
            var t = (e = a(e, "")).split(" ").map(function(e) {
                return i(e)
            });
            return u.copySafeness(e, t.join(" "))
        },
        r.trim = c,
        r.truncate = function(e, t, n, r) {
            var i = e;
            if (t = t || 255, (e = a(e, "")).length <= t) return e;
            if (n) e = e.substring(0, t);
            else {
                var o = e.lastIndexOf(" ", t); - 1 === o && (o = t),
                e = e.substring(0, o)
            }
            return e += null != r ? r: "...",
            u.copySafeness(i, e)
        },
        r.upper = function(e) {
            return (e = a(e, "")).toUpperCase()
        },
        r.urlencode = function(e) {
            var r = encodeURIComponent;
            return s.isString(e) ? r(e) : (s.isArray(e) ? e: s._entries(e)).map(function(e) {
                var t = e[0],
                n = e[1];
                return r(t) + "=" + r(n)
            }).join("&")
        };
        var f = /^(?:\(|<|&lt;)?(.*?)(?:\.|,|\)|\n|&gt;)?$/,
        h = /^[\w.!#$%&'*+\-\/=?\^`{|}~]+@[a-z\d\-]+(\.[a-z\d\-]+)+$/i,
        p = /^https?:\/\/.*$/,
        d = /^www\./,
        g = /\.(?:org|net|com)(?:\:|\/|$)/;
        r.urlize = function(e, i, t) {
            l(i) && (i = 1 / 0);
            var o = !0 === t ? ' rel="nofollow"': "";
            return e.split(/(\s+)/).filter(function(e) {
                return e && e.length
            }).map(function(e) {
                var t = e.match(f),
                n = t ? t[1] : e,
                r = n.substr(0, i);
                return p.test(n) ? '<a href="' + n + '"' + o + ">" + r + "</a>": d.test(n) ? '<a href="http://' + n + '"' + o + ">" + r + "</a>": h.test(n) ? '<a href="mailto:' + n + '">' + n + "</a>": g.test(n) ? '<a href="http://' + n + '"' + o + ">" + r + "</a>": e
            }).join("")
        },
        r.wordcount = function(e) {
            var t = (e = a(e, "")) ? e.match(/\w+/g) : null;
            return t ? t.length: null
        },
        r.float = function(e, t) {
            var n = parseFloat(e);
            return l(n) ? t: n
        },
        r.int = function(e, t) {
            var n = parseInt(e, 10);
            return l(n) ? t: n
        },
        r.d = r.
    default,
        r.e = r.escape
    },
    function(e, t, n) {
        "use strict";
        var r = n(2).SafeString;
        t.callable = function(e) {
            return "function" == typeof e
        },
        t.defined = function(e) {
            return void 0 !== e
        },
        t.divisibleby = function(e, t) {
            return e % t == 0
        },
        t.escaped = function(e) {
            return e instanceof r
        },
        t.equalto = function(e, t) {
            return e === t
        },
        t.eq = t.equalto,
        t.sameas = t.equalto,
        t.even = function(e) {
            return e % 2 == 0
        },
        t.falsy = function(e) {
            return ! e
        },
        t.ge = function(e, t) {
            return t <= e
        },
        t.greaterthan = function(e, t) {
            return t < e
        },
        t.gt = t.greaterthan,
        t.le = function(e, t) {
            return e <= t
        },
        t.lessthan = function(e, t) {
            return e < t
        },
        t.lt = t.lessthan,
        t.lower = function(e) {
            return e.toLowerCase() === e
        },
        t.ne = function(e, t) {
            return e !== t
        },
        t.null = function(e) {
            return null === e
        },
        t.number = function(e) {
            return "number" == typeof e
        },
        t.odd = function(e) {
            return e % 2 == 1
        },
        t.string = function(e) {
            return "string" == typeof e
        },
        t.truthy = function(e) {
            return !! e
        },
        t.undefined = function(e) {
            return void 0 === e
        },
        t.upper = function(e) {
            return e.toUpperCase() === e
        },
        t.iterable = function(e) {
            return "undefined" != typeof Symbol ? !!e[Symbol.iterator] : Array.isArray(e) || "string" == typeof e
        },
        t.mapping = function(e) {
            var t = null != e && "object" == typeof e && !Array.isArray(e);
            return Set ? t && !(e instanceof Set) : t
        }
    },
    function(e, t, n) {
        "use strict";
        e.exports = function() {
            return {
                range: function(e, t, n) {
                    void 0 === t ? (t = e, e = 0, n = 1) : n || (n = 1);
                    var r = [];
                    if (0 < n) for (var i = e; i < t; i += n) r.push(i);
                    else for (var o = e; t < o; o += n) r.push(o);
                    return r
                },
                cycler: function() {
                    return e = Array.prototype.slice.call(arguments),
                    t = -1,
                    {
                        current: null,
                        reset: function() {
                            t = -1,
                            this.current = null
                        },
                        next: function() {
                            return++t >= e.length && (t = 0),
                            this.current = e[t],
                            this.current
                        }
                    };
                    var e, t
                }, joiner: function(e) {
                    return function(t) {
                        t = t || ",";
                        var n = !0;
                        return function() {
                            var e = n ? "": t;
                            return n = !1,
                            e
                        }
                    } (e)
                }
            }
        }
    },
    function(e, t, n) {
        "use strict";
        var r = n(0);
        e.exports = function(n, e) {
            function t(e, t) {
                if (this.name = e, this.path = e, this.defaultEngine = t.defaultEngine, this.ext = r.extname(e), !this.ext && !this.defaultEngine) throw new Error("No default engine was specified and no extension was provided.");
                this.ext || (this.name += this.ext = ("." !== this.defaultEngine[0] ? ".": "") + this.defaultEngine)
            }
            return t.prototype.render = function(e, t) {
                n.render(this.name, e, t)
            },
            e.set("view", t),
            e.set("nunjucksEnv", n),
            n
        }
    },
    function(e, t, n) {
        "use strict";
        e.exports = function() {
            var e, t, a = this.runtime,
            r = this.lib,
            n = this.compiler.Compiler,
            i = this.parser.Parser,
            o = (this.nodes, this.lexer, a.contextOrFrameLookup),
            s = a.memberLookup;
            function l(e, t) {
                return Object.prototype.hasOwnProperty.call(e, t)
            }
            n && (e = n.prototype.assertType),
            i && (t = i.prototype.parseAggregate),
            a.contextOrFrameLookup = function(e, t, n) {
                var r = o.apply(this, arguments);
                if (void 0 !== r) return r;
                switch (n) {
                case "True":
                    return ! 0;
                case "False":
                    return ! 1;
                case "None":
                    return null;
                default:
                    return
                }
            };
            var u = {
                pop: function(e) {
                    if (void 0 === e) return this.pop();
                    if (e >= this.length || e < 0) throw new Error("KeyError");
                    return this.splice(e, 1)
                },
                append: function(e) {
                    return this.push(e)
                },
                remove: function(e) {
                    for (var t = 0; t < this.length; t++) if (this[t] === e) return this.splice(t, 1);
                    throw new Error("ValueError")
                },
                count: function(e) {
                    for (var t = 0,
                    n = 0; n < this.length; n++) this[n] === e && t++;
                    return t
                },
                index: function(e) {
                    var t;
                    if ( - 1 === (t = this.indexOf(e))) throw new Error("ValueError");
                    return t
                },
                find: function(e) {
                    return this.indexOf(e)
                },
                insert: function(e, t) {
                    return this.splice(e, 0, t)
                }
            },
            c = {
                items: function() {
                    return r._entries(this)
                },
                values: function() {
                    return r._values(this)
                },
                keys: function() {
                    return r.keys(this)
                },
                get: function(e, t) {
                    var n = this[e];
                    return void 0 === n && (n = t),
                    n
                },
                has_key: function(e) {
                    return l(this, e)
                },
                pop: function(e, t) {
                    var n = this[e];
                    if (void 0 === n && void 0 !== t) n = t;
                    else {
                        if (void 0 === n) throw new Error("KeyError");
                        delete this[e]
                    }
                    return n
                },
                popitem: function() {
                    var e = r.keys(this);
                    if (!e.length) throw new Error("KeyError");
                    var t = e[0],
                    n = this[t];
                    return delete this[t],
                    [t, n]
                },
                setdefault: function(e, t) {
                    return void 0 === t && (t = null),
                    e in this || (this[e] = t),
                    this[e]
                },
                update: function(e) {
                    return r._assign(this, e),
                    null
                }
            };
            return c.iteritems = c.items,
            c.itervalues = c.values,
            c.iterkeys = c.keys,
            a.memberLookup = function(e, t, n) {
                return 4 === arguments.length ?
                function(e, t, n, r) {
                    e = e || [],
                    null === t && (t = r < 0 ? e.length - 1 : 0),
                    null === n ? n = r < 0 ? -1 : e.length: n < 0 && (n += e.length),
                    t < 0 && (t += e.length);
                    for (var i = [], o = t; ! (o < 0 || o > e.length || 0 < r && n <= o || r < 0 && o <= n); o += r) i.push(a.memberLookup(e, o));
                    return i
                }.apply(this, arguments) : (e = e || {},
                r.isArray(e) && l(u, t) ? u[t].bind(e) : r.isObject(e) && l(c, t) ? c[t].bind(e) : s.apply(this, arguments))
            },
            function() {
                a.contextOrFrameLookup = o,
                a.memberLookup = s,
                n && (n.prototype.assertType = e),
                i && (i.prototype.parseAggregate = t)
            }
        }
    }])
}),
function(e, n) {
    if ("function" == typeof define && define.amd) define(["exports", "jquery"],
    function(e, t) {
        return n(e, t)
    });
    else if ("undefined" != typeof exports) {
        var t = require("jquery");
        n(exports, t)
    } else n(e, e.jQuery || e.Zepto || e.ender || e.$)
} (this,
function(e, s) {
    var l = {
        validate: /^[a-z_][a-z0-9_]*(?:\[(?:\d*|[a-z0-9_]+)\])*$/i,
        key: /[a-z0-9_]+|(?=\[\])/gi,
        push: /^$/,
        fixed: /^\d+$/,
        named: /^[a-z0-9_]+$/i
    };
    function t(r, n) {
        var i = {},
        o = {};
        function a(e, t, n) {
            return e[t] = n,
            e
        }
        function e() {
            return i
        }
        this.addPair = function(e) {
            if (!l.validate.test(e.name)) return this;
            var t = function(e, t) {
                for (var n, r = e.match(l.key); void 0 !== (n = r.pop());) l.push.test(n) ? t = a([], (i = e.replace(/\[\]$/, ""), void 0 === o[i] && (o[i] = 0), o[i]++), t) : l.fixed.test(n) ? t = a([], n, t) : l.named.test(n) && (t = a({},
                n, t));
                var i;
                return t
            } (e.name,
            function(e) {
                switch (s('[name="' + e.name + '"]', n).attr("type")) {
                case "checkbox":
                    return "on" === e.value || e.value;
                default:
                    return e.value
                }
            } (e));
            return i = r.extend(!0, i, t),
            this
        },
        this.addPairs = function(e) {
            if (!r.isArray(e)) throw new Error("formSerializer.addPairs expects an Array");
            for (var t = 0,
            n = e.length; t < n; t++) this.addPair(e[t]);
            return this
        },
        this.serialize = e,
        this.serializeJSON = function() {
            return JSON.stringify(e())
        }
    }
    return t.patterns = l,
    t.serializeObject = function() {
        return new t(s, this).addPairs(this.serializeArray()).serialize()
    },
    t.serializeJSON = function() {
        return new t(s, this).addPairs(this.serializeArray()).serializeJSON()
    },
    void 0 !== s.fn && (s.fn.serializeObject = t.serializeObject, s.fn.serializeJSON = t.serializeJSON),
    e.FormSerializer = t
}),
function() {
    var l, u, i, c, e, t, n, r, o, a, s, f, h, p, d, g, v, m, y, b, _, w, x, E, C = [].slice,
    S = [].indexOf ||
    function(e) {
        for (var t = 0,
        n = this.length; t < n; t++) if (t in this && this[t] === e) return t;
        return - 1
    }; (l = window.jQuery || window.Zepto || window.$).payment = {},
    l.payment.fn = {},
    l.fn.payment = function() {
        var e, t;
        return t = arguments[0],
        e = 2 <= arguments.length ? C.call(arguments, 1) : [],
        l.payment.fn[t].apply(this, e)
    },
    e = /(\d{1,4})/g,
    l.payment.cards = c = [{
        type: "maestro",
        patterns: [5018, 502, 503, 506, 56, 58, 639, 6220, 67],
        format: e,
        length: [12, 13, 14, 15, 16, 17, 18, 19],
        cvcLength: [3],
        luhn: !0
    },
    {
        type: "forbrugsforeningen",
        patterns: [600],
        format: e,
        length: [16],
        cvcLength: [3],
        luhn: !0
    },
    {
        type: "dankort",
        patterns: [5019],
        format: e,
        length: [16],
        cvcLength: [3],
        luhn: !0
    },
    {
        type: "visa",
        patterns: [4],
        format: e,
        length: [13, 16],
        cvcLength: [3],
        luhn: !0
    },
    {
        type: "mastercard",
        patterns: [51, 52, 53, 54, 55, 22, 23, 24, 25, 26, 27],
        format: e,
        length: [16],
        cvcLength: [3],
        luhn: !0
    },
    {
        type: "amex",
        patterns: [34, 37],
        format: /(\d{1,4})(\d{1,6})?(\d{1,5})?/,
        length: [15],
        cvcLength: [3, 4],
        luhn: !0
    },
    {
        type: "dinersclub",
        patterns: [30, 36, 38, 39],
        format: /(\d{1,4})(\d{1,6})?(\d{1,4})?/,
        length: [14],
        cvcLength: [3],
        luhn: !0
    },
    {
        type: "discover",
        patterns: [60, 64, 65, 622],
        format: e,
        length: [16],
        cvcLength: [3],
        luhn: !0
    },
    {
        type: "unionpay",
        patterns: [62, 88],
        format: e,
        length: [16, 17, 18, 19],
        cvcLength: [3],
        luhn: !1
    },
    {
        type: "jcb",
        patterns: [35],
        format: e,
        length: [16],
        cvcLength: [3],
        luhn: !0
    }],
    u = function(e) {
        var t, n, r, i, o, a, s;
        for (e = (e + "").replace(/\D/g, ""), r = 0, o = c.length; r < o; r++) for (i = 0, a = (s = (t = c[r]).patterns).length; i < a; i++) if (n = s[i] + "", e.substr(0, n.length) === n) return t
    },
    i = function(e) {
        var t, n, r;
        for (n = 0, r = c.length; n < r; n++) if ((t = c[n]).type === e) return t
    },
    h = function(e) {
        var t, n, r, i, o, a;
        for (r = !0, o = i = 0, a = (n = (e + "").split("").reverse()).length; o < a; o++) t = n[o],
        t = parseInt(t, 10),
        (r = !r) && (t *= 2),
        9 < t && (t -= 9),
        i += t;
        return i % 10 == 0
    },
    f = function(e) {
        var t;
        return null != e.prop("selectionStart") && e.prop("selectionStart") !== e.prop("selectionEnd") || !(null == ("undefined" != typeof document && null !== document && null != (t = document.selection) ? t.createRange: void 0) || !document.selection.createRange().text)
    },
    x = function(e, t) {
        var n, r, i, o, a;
        try {
            r = t.prop("selectionStart")
        } catch(e) {
            e,
            r = null
        }
        if (o = t.val(), t.val(e), null !== r && t.is(":focus")) return r === o.length && (r = e.length),
        o !== e && (a = o.slice(r - 1, +r + 1 || 9e9), n = e.slice(r - 1, +r + 1 || 9e9), i = e[r], /\d/.test(i) && a === i + " " && n === " " + i && (r += 1)),
        t.prop("selectionStart", r),
        t.prop("selectionEnd", r)
    },
    m = function(e) {
        var t, n, r, i, o, a;
        for (null == e && (e = ""), "０１２３４５６７８９", "0123456789", i = "", o = 0, a = (t = e.split("")).length; o < a; o++) n = t[o],
        -1 < (r = "０１２３４５６７８９".indexOf(n)) && (n = "0123456789" [r]),
        i += n;
        return i
    },
    v = function(e) {
        var t;
        return t = l(e.currentTarget),
        setTimeout(function() {
            var e;
            return e = t.val(),
            e = (e = m(e)).replace(/\D/g, ""),
            x(e, t)
        })
    },
    d = function(e) {
        var t;
        return t = l(e.currentTarget),
        setTimeout(function() {
            var e;
            return e = t.val(),
            e = m(e),
            e = l.payment.formatCardNumber(e),
            x(e, t)
        })
    },
    r = function(e) {
        var t, n, r, i, o, a, s;
        if (r = String.fromCharCode(e.which), /^\d+$/.test(r) && (t = l(e.currentTarget), s = t.val(), n = u(s + r), i = (s.replace(/\D/g, "") + r).length, a = 16, n && (a = n.length[n.length.length - 1]), !(a <= i || null != t.prop("selectionStart") && t.prop("selectionStart") !== s.length))) return (o = n && "amex" === n.type ? /^(\d{4}|\d{4}\s\d{6})$/: /(?:^|\s)(\d{4})$/).test(s) ? (e.preventDefault(), setTimeout(function() {
            return t.val(s + " " + r)
        })) : o.test(s + r) ? (e.preventDefault(), setTimeout(function() {
            return t.val(s + r + " ")
        })) : void 0
    },
    t = function(e) {
        var t, n;
        if (t = l(e.currentTarget), n = t.val(), 8 === e.which && (null == t.prop("selectionStart") || t.prop("selectionStart") === n.length)) return /\d\s$/.test(n) ? (e.preventDefault(), setTimeout(function() {
            return t.val(n.replace(/\d\s$/, ""))
        })) : /\s\d?$/.test(n) ? (e.preventDefault(), setTimeout(function() {
            return t.val(n.replace(/\d$/, ""))
        })) : void 0
    },
    g = function(e) {
        var t;
        return t = l(e.currentTarget),
        setTimeout(function() {
            var e;
            return e = t.val(),
            e = m(e),
            e = l.payment.formatExpiry(e),
            x(e, t)
        })
    },
    o = function(e) {
        var n, t, r;
        if (t = String.fromCharCode(e.which), /^\d+$/.test(t)) return n = l(e.currentTarget),
        r = n.val() + t,
        /^\d$/.test(r) && "0" !== r && "1" !== r ? (e.preventDefault(), setTimeout(function() {
            return n.val("0" + r + " / ")
        })) : /^\d\d$/.test(r) ? (e.preventDefault(), setTimeout(function() {
            var e, t;
            return e = parseInt(r[0], 10),
            2 < (t = parseInt(r[1], 10)) && 0 !== e ? n.val("0" + e + " / " + t) : n.val(r + " / ")
        })) : void 0
    },
    a = function(e) {
        var t, n, r;
        if (n = String.fromCharCode(e.which), /^\d+$/.test(n)) return r = (t = l(e.currentTarget)).val(),
        /^\d\d$/.test(r) ? t.val(r + " / ") : void 0
    },
    s = function(e) {
        var t, n, r;
        if ("/" === (r = String.fromCharCode(e.which)) || " " === r) return n = (t = l(e.currentTarget)).val(),
        /^\d$/.test(n) && "0" !== n ? t.val("0" + n + " / ") : void 0
    },
    n = function(e) {
        var t, n;
        if (t = l(e.currentTarget), n = t.val(), 8 === e.which && (null == t.prop("selectionStart") || t.prop("selectionStart") === n.length)) return /\d\s\/\s$/.test(n) ? (e.preventDefault(), setTimeout(function() {
            return t.val(n.replace(/\d\s\/\s$/, ""))
        })) : void 0
    },
    p = function(e) {
        var t;
        return t = l(e.currentTarget),
        setTimeout(function() {
            var e;
            return e = t.val(),
            e = (e = m(e)).replace(/\D/g, "").slice(0, 4),
            x(e, t)
        })
    },
    w = function(e) {
        var t;
        return ! (!e.metaKey && !e.ctrlKey) || 32 !== e.which && (0 === e.which || (e.which < 33 || (t = String.fromCharCode(e.which), !!/[\d\s]/.test(t))))
    },
    b = function(e) {
        var t, n, r, i;
        if (t = l(e.currentTarget), r = String.fromCharCode(e.which), /^\d+$/.test(r) && !f(t)) return i = (t.val() + r).replace(/\D/g, ""),
        (n = u(i)) ? i.length <= n.length[n.length.length - 1] : i.length <= 16
    },
    _ = function(e) {
        var t, n;
        if (t = l(e.currentTarget), n = String.fromCharCode(e.which), /^\d+$/.test(n) && !f(t)) return ! (6 < (t.val() + n).replace(/\D/g, "").length) && void 0
    },
    y = function(e) {
        var t, n;
        if (t = l(e.currentTarget), n = String.fromCharCode(e.which), /^\d+$/.test(n) && !f(t)) return (t.val() + n).length <= 4
    },
    E = function(e) {
        var t, n, r, i, o;
        if (o = (t = l(e.currentTarget)).val(), i = l.payment.cardType(o) || "unknown", !t.hasClass(i)) return n = function() {
            var e, t, n;
            for (n = [], e = 0, t = c.length; e < t; e++) r = c[e],
            n.push(r.type);
            return n
        } (),
        t.removeClass("unknown"),
        t.removeClass(n.join(" ")),
        t.addClass(i),
        t.toggleClass("identified", "unknown" !== i),
        t.trigger("payment.cardType", i)
    },
 
    l.payment.formatExpiry = function(e) {
        var t, n, r, i;
        return (n = e.match(/^\D*(\d{1,2})(\D+)?(\d{1,4})?/)) ? (t = n[1] || "", r = n[2] || "", 0 < (i = n[3] || "").length ? r = " / ": " /" === r ? (t = t.substring(0, 1), r = "") : 2 === t.length || 0 < r.length ? r = " / ": 1 === t.length && "0" !== t && "1" !== t && (t = "0" + t, r = " / "), t + r + i) : ""
    }
}.call(this),
jQuery.fn.flexdatalist = function(e, t) {
    "use strict";
    var n = function(e, i) {
        e.each(function() {
            var e = $(this),
            t = e.data(),
            n = t.flexdatalist,
            r = t.aliascontainer;
            r && (e.removeClass("flexdatalist-set").attr({
                style: null,
                tabindex: null
            }).val(n && n.originalValue && !i ? n.originalValue: "").removeData("flexdatalist").removeData("aliascontainer").off(), r.remove())
        })
    };
    if ("string" == typeof e && "reset" !== e) {
        if (void 0 !== this[0].fvalue) {
            var r = this[0];
            if ("destroy" === e) n(this, t);
            else if ("value" === e) {
                if (void 0 === t) return r.fvalue.get();
                r.fvalue.set(t)
            } else if ("add" === e) {
                if (void 0 === t) return r.debug("Missing value to add!");
                r.fvalue.add(t)
            } else if ("toggle" === e) {
                if (void 0 === t) return r.debug("Missing value to toggle!");
                r.fvalue.toggle(t)
            } else if ("remove" === e) {
                if (void 0 === t) return r.debug("Missing value to remove!");
                r.fvalue.remove(t)
            } else if ("disabled" === e) {
                if (void 0 === t) return r.fdisabled();
                r.fdisabled(t)
            } else if ("string" == typeof e) {
                if (void 0 === t) return r.options.get(e);
                r.options.set(e, t)
            }
            return this
        }
        e = {
            _option: t
        }
    }
    0 < this.length && void 0 !== this[0].fvalue && n(this);
    var i = $.extend({
        url: null,
        data: [],
        params: {},
        relatives: null,
        chainedRelatives: !1,
        cache: !0,
        cacheLifetime: 60,
        minLength: 2,
        groupBy: !1,
        selectionRequired: !1,
        focusFirstResult: !1,
        textProperty: null,
        valueProperty: null,
        visibleProperties: [],
        iconProperty: "thumb",
        searchIn: ["label"],
        searchContain: !1,
        searchEqual: !1,
        searchByWord: !1,
        searchDisabled: !1,
        searchDelay: 300,
        normalizeString: null,
        multiple: null,
        disabled: null,
        maxShownResults: 100,
        removeOnBackspace: !0,
        noResultsText: 'No results found for "{keyword}"',
        toggleSelected: !1,
        allowDuplicateValues: !1,
        redoSearchOnFocus: !0,
        requestType: "get",
        requestContentType: "x-www-form-urlencoded",
        resultsProperty: "results",
        keywordParamName: "keyword",
        limitOfValues: 0,
        valuesSeparator: ",",
        debug: !0
    },
    e);
    return this.each(function(e) {
        var u = $(this),
        p = this,
        o = null,
        a = [],
        s = "flex" + e,
        f = null,
        r = null;
        this.init = function() {
            var n = this.options.init();
            this.set.up(),
            f.on("focusin",
            function(e) {
                p.action.redoSearchFocus(e),
                p.action.showAllResults(e),
                r && r.addClass("focus")
            }).on("input keydown",
            function(e) {
                9 === p.keyNum(e) && p.results.remove(),
                p.action.keypressValue(e, 188),
                p.action.backSpaceKeyRemove(e)
            }).on("input keyup",
            function(e) {
                p.action.keypressValue(e, 13),
                p.action.keypressSearch(e),
                p.action.copyValue(e),
                p.action.backSpaceKeyRemove(e),
                p.action.showAllResults(e),
                p.action.clearValue(e),
                p.action.removeResults(e),
                p.action.inputWidth(e)
            }).on("focusout",
            function(e) {
                r && r.removeClass("focus"),
                p.action.clearText(e),
                p.action.clearValue(e)
            }),
            window.onresize = function(e) {
                p.position()
            },
            this.cache.gc(),
            n.selectionRequired && p.fvalue.clear(!0, !0),
            this.fvalue._load(n.originalValue,
            function(e, t) {
                p.fdisabled(n.disabled),
                u.trigger("init:flexdatalist", [n])
            },
            !0)
        },
        this.action = {
            keypressValue: function(e, t) {
                var n = p.keyNum(e),
                r = f[0].value,
                i = p.options.get();
                if (0 < r.length && n === t && !i.selectionRequired && i.multiple) {
                    r = f[0].value;
                    e.preventDefault(),
                    p.fvalue.extract(r),
                    p.results.remove()
                }
            },
            keypressSearch: function(e) {
                var t = p.keyNum(e),
                n = f.val(),
                r = n.length,
                i = p.options.get();
                clearTimeout(o),
                (!t || 13 !== t && (t < 37 || 40 < t)) && (o = setTimeout(function() { (0 === i.minLength && 0 < r || 0 < i.minLength && r >= i.minLength) && p.data.load(function(e) {
                        p.search.get(n, e,
                        function(e) {
                            p.results.show(e)
                        })
                    })
                },
                i.searchDelay))
            },
            redoSearchFocus: function(e) {
                var t = p.fvalue.get(),
                n = p.options.get(),
                r = f.val();
                n.redoSearchOnFocus && (0 < r.length && n.multiple || 0 < r.length && 0 === t.length) && this.keypressSearch(e)
            },
            copyValue: function(e) {
                if (13 !== p.keyNum(e)) {
                    var t = f.val(),
                    n = p.fvalue.get(!0),
                    r = p.options.get();
                    r.multiple || r.selectionRequired || t.length === n.length || p.fvalue.extract(t)
                }
            },
            backSpaceKeyRemove: function(e) {
                var t = p.options.get();
                if (t.removeOnBackspace && t.multiple) {
                    var n = f.val(),
                    r = f.data("_remove");
                    8 === p.keyNum(e) && (0 === n.length ? r ? (p.fvalue.remove(r), f.data("_remove", null)) : (console.log("remove!"), f.data("_remove", f.parents("li:eq(0)").prev())) : f.data("_remove", null))
                }
            },
            showAllResults: function(e) {
                var t = f.val();
                "" === (t = $.trim(t)) && 0 === p.options.get("minLength") && p.data.load(function(e) {
                    p.results.show(e)
                })
            },
            inputWidth: function(e) {
                if (p.options.get().multiple) {
                    var t = f.val(),
                    n = parseInt(f.css("fontSize").replace("px", "")),
                    r = u.innerWidth(),
                    i = (t.length + 1) * n;
                    40 <= i && i <= r && (f[0].style.width = i + "px")
                }
            },
            clearText: function(e) {
                var t = p.fvalue.get(),
                n = p.options.get(); ! n.multiple && n.selectionRequired && 0 === t.length && (f[0].value = "")
            },
            clearValue: function(e) {
                p.fvalue.get();
                var t = f.val(),
                n = p.options.get(); ! n.multiple && n.selectionRequired && t.length <= n.minLength && p.fvalue.clear()
            },
            removeResults: function(e) {
                p.fvalue.get();
                var t = f.val(),
                n = p.options.get();
                0 < n.minLength && t.length < n.minLength && p.results.remove()
            }
        },
        this.set = {
            up: function() {
                f = this.alias(),
                p.options.get("multiple") ? r = this.multipleInput(f) : f.insertAfter(u),
                u.attr("autofocus") && f.focus(),
                u.data("aliascontainer", r || f).addClass("flexdatalist flexdatalist-set").css({
                    position: "absolute",
                    top: -14e3,
                    left: -14e3
                }).attr("tabindex", -1);
                var e = u.attr("id"),
                t = f.attr("id");
                $('label[for="' + e + '"]').attr("for", t),
                this.chained()
            },
            alias: function() {
                var e = u.attr("id") ? u.attr("id") + "-flexdatalist": s;
                return $('<input type="text">').attr({
                    class: u.attr("class"),
                    name: u.attr("name") ? "flexdatalist-" + u.attr("name") : null,
                    id: e,
                    placeholder: u.attr("placeholder")
                }).addClass("flexdatalist-alias " + e).removeClass("flexdatalist").attr("autocomplete", "off")
            },
            multipleInput: function(e) {
                return r = $('<ul tabindex="1">').addClass("flexdatalist-multiple " + s).css({
                    "border-color": u.css("border-left-color"),
                    "border-width": u.css("border-left-width"),
                    "border-style": u.css("border-left-style"),
                    "border-radius": u.css("border-top-left-radius"),
                    "background-color": u.css("background-color")
                }).insertAfter(u).click(function() {
                    $(this).find("input").focus()
                }),
                $('<li class="input-container">').addClass("flexdatalist-multiple-value").append(e).appendTo(r),
                r
            },
            chained: function() {
                var t = p.options.get();
                if (t.relatives && t.chainedRelatives) {
                    var e = function(e) {
                        t.relatives.each(function() {
                            var e = p.isEmpty($(this).val()),
                            t = p.isEmpty(p.value); ! e && t || p.fvalue.clear(),
                            p.fdisabled(e)
                        })
                    };
                    t.relatives.on("change",
                    function() {
                        e()
                    }),
                    e()
                }
            }
        },
        this.fvalue = {
            get: function(e) {
                var t = p.value;
                return ! p.options.get().multiple && !this.isJSON() || e ? t: this.toObj(t)
            },
            set: function(e, t) {
                return p.fdisabled() || (t || this.clear(!0), this._load(e)),
                u
            },
            add: function(e) {
                return p.options.get("multiple") && this.set(e, !0),
                this
            },
            toggle: function(e) {
                return p.fdisabled() || this.multiple.toggle(e),
                this
            },
            remove: function(e) {
                if (!p.fdisabled()) {
                    e = this.toObj(e),
                    u.trigger("before:flexdatalist.remove", [e]);
                    var r = [];
                    if ($.isArray(e)) $.each(e,
                    function(e, t) {
                        var n = p.fvalue.multiple.remove(t);
                        n && r.push(n)
                    });
                    else {
                        var t = this.multiple.remove(e);
                        t && r.push(t)
                    }
                    u.trigger("after:flexdatalist.remove", [e, r]).trigger("change:flexdatalist", [r, p.options.get()]).trigger("change")
                }
                return this
            },
            _load: function(l, u, e) {
                var c = p.options.get().valueProperty,
                t = this.toStr(l),
                n = this.get(!0);
                if (u = u || $.noop, 0 != t.length || 0 != n.length) {
                    if (l = this.toObj(l), !p.isEmpty(l) && !p.isEmpty(c) && "*" !== c) return p.isObject(c) || (c = c.split(",")),
                    void p.data.load(function(e) {
                        p.isObject(l) ? $.isArray(l) || (l = [l]) : l = l.split(",");
                        for (var t = [], n = 0; n < l.length; n++) for (var r = l[n], i = 0; i < e.length; i++) for (var o = e[i], a = 0; a < c.length; a++) {
                            var s = c[a];
                            r = p.isDefined(r, s) ? r[s] : r;
                            p.isDefined(o, s) && r === o[s] && t.push(o)
                        }
                        0 < t.length && p.fvalue.extract(t, !0),
                        u(l)
                    },
                    l);
                    u(l),
                    p.fvalue.extract(l, e)
                } else u(l)
            },
            extract: function(e, t) {
                var n = p.options.get(),
                r = [];
                t || u.trigger("before:flexdatalist.value", [e, n]),
                $.isArray(e) ? $.each(e,
                function(e, t) {
                    r.push(p.fvalue._extract(t))
                }) : r = p.fvalue._extract(e),
                t || u.trigger("after:flexdatalist.value", [r, n]).trigger("change:flexdatalist", [r, n]).trigger("change")
            },
            _extract: function(e) {
                var t = this.text(e),
                n = this.value(e);
                p.value;
                if (p.options.get().multiple) {
                    if (!p.isEmpty(n)) {
                        if (p.isDup(n)) return;
                        a.push(n),
                        this.multiple.add(n, t)
                    }
                } else this.single(n, t);
                return {
                    value: n,
                    text: t
                }
            },
            single: function(e, t) {
                t && t !== f.val() && (f[0].value = t),
                p.value = e
            },
            multiple: {
                add: function(e, t) {
                    var n = this,
                    r = this.li(e, t);
                    p.options.get();
                    r.click(function() {
                        n.toggle($(this))
                    }).find(".fdl-remove").click(function() {
                        p.fvalue.remove($(this).parent())
                    }),
                    this.push(e),
                    f[0].value = "",
                    this.checkLimit()
                },
                push: function(e, t) {
                    var n = p.fvalue.get();
                    e = p.fvalue.toObj(e),
                    n.push(e),
                    e = p.fvalue.toStr(n),
                    p.value = e
                },
                toggle: function(e) {
                    var t = p.options.get();
                    if (t.toggleSelected) {
                        var n = this.findLi(e);
                        if (n) {
                            var r = n.index(),
                            i = n.data(),
                            o = n.hasClass("disabled") ? "enable": "disable",
                            a = p.fvalue.get(),
                            s = [{
                                value: i.value,
                                text: i.text,
                                action: o
                            },
                            t];
                            if (u.trigger("before:flexdatalist.toggle", s), "enable" === o) {
                                var l = n.data("value");
                                a.splice(r, 0, l),
                                n.removeClass("disabled")
                            } else a.splice(r, 1),
                            n.addClass("disabled");
                            a = p.fvalue.toStr(a),
                            p.value = a,
                            u.trigger("after:flexdatalist.toggle", s).trigger("change:flexdatalist", s).trigger("change")
                        }
                    }
                },
                remove: function(e) {
                    var t = this.findLi(e);
                    if (t) {
                        var n = p.fvalue.get(),
                        r = t.index(),
                        i = t.data(),
                        o = (p.options.get(), {
                            value: i.value,
                            text: i.text
                        });
                        return n.splice(r, 1),
                        n = p.fvalue.toStr(n),
                        p.value = n,
                        t.remove(),
                        p.fvalue.multiple.checkLimit(),
                        a.splice(r, 1),
                        o
                    }
                },
                removeAll: function() {
                    var e = p.fvalue.get(),
                    t = p.options.get();
                    u.trigger("before:flexdatalist.remove.all", [e, t]),
                    r.find("li:not(.input-container)").remove(),
                    p.value = "",
                    a = [],
                    u.trigger("after:flexdatalist.remove.all", [e, t])
                },
                li: function(e, t) {
                    var n = r.find("li.input-container");
                    return $("<li>").addClass("value" + (p.options.get("toggleSelected") ? " toggle": "")).append('<span class="text">' + t + "</span>").append('<span class="fdl-remove">&times;</span>').data({
                        text: t,
                        value: p.fvalue.toObj(e)
                    }).insertBefore(n)
                },
                checkLimit: function() {
                    var e = p.options.get("limitOfValues");
                    if (0 < e) {
                        var t = r.find("li.input-container");
                        e == a.length ? t.hide() : t.show()
                    }
                },
                findLi: function(t) {
                    if (t instanceof jQuery) 0 === t.length && (t = null);
                    else {
                        var n = t;
                        t = null,
                        r.find("li:not(.input-container)").each(function() {
                            var e = $(this);
                            if (e.data("value") === n) return t = e,
                            !1
                        })
                    }
                    return t
                },
                isEmpty: function() {
                    return 0 < this.get().length
                }
            },
            value: function(e) {
                var t = e,
                n = p.options.get(),
                r = n.valueProperty;
                if (p.isObject(e)) if (this.isJSON() || this.isMixed()) if (delete e.name_highlight, $.isArray(r)) {
                    for (var i = {},
                    o = 0; o < r.length; o++) p.isDefined(e, r[o]) && (i[r[o]] = e[r[o]]);
                    t = this.toStr(i)
                } else t = this.toStr(e);
                else t = p.isDefined(e, r) ? e[r] : p.isDefined(e, n.searchIn[0]) ? e[n.searchIn[0]] : null;
                return t
            },
            text: function(e) {
                var t = e,
                n = p.options.get();
                return p.isObject(e) && (t = e[n.searchIn[0]], t = p.isDefined(e, n.textProperty) ? e[n.textProperty] : this.placeholders.replace(e, n.textProperty, t)),
                $("<div>").html(t).text()
            },
            placeholders: {
                replace: function(n, r, e) {
                    if (p.isObject(n) && "string" == typeof r) {
                        var t = this.parse(r);
                        if (!p.isEmpty(n) && t) return $.each(t,
                        function(e, t) {
                            p.isDefined(n, t) && (r = r.replace(e, n[t]))
                        }),
                        r
                    }
                    return e
                },
                parse: function(e) {
                    var t = e.match(/\{.+?\}/g);
                    if (t) {
                        var n = {};
                        return t.map(function(e) {
                            n[e] = e.slice(1, -1)
                        }),
                        n
                    }
                    return ! 1
                }
            },
            clear: function(e, t) {
                var n = p.value,
                r = p.options.get();
                return r.multiple && this.multiple.removeAll(),
                (p.value = "") === n || t || u.trigger("change:flexdatalist", [{
                    value: "",
                    text: ""
                },
                r]).trigger("change"),
                e && (f[0].value = ""),
                a = [],
                this
            },
            toObj: function(e) {
                if ("object" != typeof e) {
                    var t = p.options.get();
                    p.isEmpty(e) || !p.isDefined(e) ? e = t.multiple ? [] : this.isJSON() ? {}: "": this.isCSV() ? (e = e.toString().split(t.valuesSeparator), e = $.map(e,
                    function(e) {
                        return $.trim(e)
                    })) : (this.isMixed() || this.isJSON()) && this.isJSON(e) ? e = JSON.parse(e) : "number" == typeof e && (e = e.toString())
                }
                return e
            },
            toStr: function(e) {
                return "string" != typeof e && (p.isEmpty(e) || !p.isDefined(e) ? e = "": "number" == typeof e ? e = e.toString() : this.isCSV() ? e = e.join(p.options.get("valuesSeparator")) : (this.isJSON() || this.isMixed()) && (e = JSON.stringify(e))),
                $.trim(e)
            },
            isJSON: function(e) {
                if (void 0 !== e) {
                    if (p.isObject(e)) e = JSON.stringify(e);
                    else if ("string" != typeof e) return ! 1;
                    return 0 === e.indexOf("{") || 0 === e.indexOf("[{")
                }
                var t = p.options.get().valueProperty;
                return p.isObject(t) || "*" === t
            },
            isMixed: function() {
                var e = p.options.get();
                return ! e.selectionRequired && "*" === e.valueProperty
            },
            isCSV: function() {
                return ! this.isJSON() && p.options.get("multiple")
            }
        },
        this.data = {
            load: function(t, e) {
                var n = this,
                r = [];
                u.trigger("before:flexdatalist.data"),
                this.url(function(e) {
                    r = r.concat(e),
                    n.static(function(e) {
                        r = r.concat(e),
                        n.datalist(function(e) {
                            r = r.concat(e),
                            u.trigger("after:flexdatalist.data", [r]),
                            t(r)
                        })
                    })
                },
                e)
            },
            static: function(t) {
                var n = p.options.get();
                if ("string" == typeof n.data) {
                    var r = n.data,
                    e = p.cache.read(r, !0);
                    if (e) return void t(e);
                    this.remote({
                        url: r,
                        success: function(e) {
                            n.data = e,
                            t(e),
                            p.cache.write(r, e, n.cacheLifetime, !0)
                        }
                    })
                } else "object" != typeof n.data && (n.data = []),
                t(n.data)
            },
            datalist: function(e) {
                var t = u.attr("list"),
                r = [];
                p.isEmpty(t) || $("#" + t).find("option").each(function() {
                    var e = $(this),
                    t = e.val(),
                    n = e.text();
                    r.push({
                        label: 0 < n.length ? n: t,
                        value: t
                    })
                }),
                e(r)
            },
            url: function(t, e) {
                var n = f.val(),
                r = p.options.get(),
                i = r.keywordParamName,
                o = p.fvalue.get(),
                a = this.relativesData();
                if (p.isEmpty(r.url)) return t([]);
                var s = {};
                "post" === r.requestType && ($.each(r,
                function(e, t) {
                    0 != e.indexOf("_") && "data" != e && (s[e] = t)
                }), delete s.relatives);
                var l = p.cache.keyGen({
                    relative: a,
                    load: e,
                    keyword: n,
                    contain: r.searchContain
                },
                r.url),
                u = p.cache.read(l, !0);
                if (u) t(u);
                else {
                    var c = $.extend(a, r.params, {
                        load: e,
                        contain: r.searchContain,
                        selected: o,
                        original: r.originalValue,
                        options: s
                    });
                    c[i] = n,
                    this.remote({
                        url: r.url,
                        data: c,
                        success: function(e) {
                            f.val().length >= n.length && t(e),
                            p.cache.write(l, e, r.cacheLifetime, !0)
                        }
                    })
                }
            },
            remote: function(t) {
                var n = this,
                e = p.options.get();
                u.hasClass("flexdatalist-loading") || (u.addClass("flexdatalist-loading"), "json" === e.requestContentType && (t.data = JSON.stringify(t.data)), $.ajax($.extend({
                    type: e.requestType,
                    dataType: "json",
                    contentType: "application/" + e.requestContentType + "; charset=UTF-8",
                    complete: function() {
                        u.removeClass("flexdatalist-loading")
                    }
                },
                t, {
                    success: function(e) {
                        e = n.extractRemoteData(e),
                        t.success(e)
                    }
                })))
            },
            extractRemoteData: function(e) {
                var t = p.options.get(),
                n = p.isDefined(e, t.resultsProperty) ? e[t.resultsProperty] : e;
                return "string" == typeof n && 0 === n.indexOf("[{") && (n = JSON.parse(n)),
                n && n.options && p.options.set($.extend({},
                t, n.options)),
                p.isObject(n) ? n: []
            },
            relativesData: function() {
                var e = p.options.get("relatives"),
                n = {};
                return e && (n.relatives = {},
                e.each(function() {
                    var e = $(this),
                    t = e.attr("name").split("][").join("-").split("]").join("-").split("[").join("-").replace(/^\|+|\-+$/g, "");
                    n.relatives[t] = e.val()
                })),
                n
            }
        },
        this.search = {
            get: function(e, t, n) {
                if (p.options.get().searchDisabled) r = t;
                else {
                    var r = p.cache.read(e);
                    if (!r) {
                        if (u.trigger("before:flexdatalist.search", [e, t]), !p.isEmpty(e)) {
                            r = [];
                            for (var i = this.split(e), o = 0; o < t.length; o++) {
                                var a = t[o];
                                p.isDup(a) || (a = this.matches(a, i)) && r.push(a)
                            }
                        }
                        p.cache.write(e, r, 2),
                        u.trigger("after:flexdatalist.search", [e, t, r])
                    }
                }
                n(r)
            },
            matches: function(e, t) {
                var n = $.extend({},
                e),
                r = [],
                i = p.options.get(),
                o = i.searchIn;
                if (0 < t.length) for (var a = 0; a < o.length; a++) {
                    var s = o[a];
                    if (p.isDefined(e, s) && e[s]) {
                        for (var l = e[s].toString(), u = l, c = this.split(l), f = 0; f < t.length; f++) {
                            var h = t[f];
                            this.find(h, c) && (r.push(h), u = this.highlight(h, u))
                        }
                        u !== l && (n[s + "_highlight"] = this.highlight(u))
                    }
                }
                return ! (0 === r.length || i.searchByWord && r.length < t.length - 1) && n
            },
            highlight: function(e, t) {
                return t ? t.replace(new RegExp(e, p.options.get("searchContain") ? "ig": "i"), "|:|$&|::|") : (e = e.split("|:|").join('<span class="highlight">')).split("|::|").join("</span>")
            },
            find: function(e, t) {
                for (var n = p.options.get(), r = 0; r < t.length; r++) {
                    var i = t[r];
                    if (i = this.normalizeString(i), e = this.normalizeString(e), n.searchEqual) return i == e;
                    if (n.searchContain ? 0 <= i.indexOf(e) : 0 === i.indexOf(e)) return ! 0
                }
                return ! 1
            },
            split: function(e) {
                if ("string" == typeof e && (e = [$.trim(e)]), p.options.get("searchByWord")) for (var t = 0; t < e.length; t++) {
                    var n = $.trim(e[t]);
                    if (0 < n.indexOf(" ")) {
                        var r = n.split(" ");
                        $.merge(e, r)
                    }
                }
                return e
            },
            normalizeString: function(e) {
                if ("string" == typeof e) {
                    var t = p.options.get("normalizeString");
                    return "function" == typeof t && (e = t(e)),
                    e.toUpperCase()
                }
                return e
            }
        },
        this.results = {
            show: function(o) {
                var a = this,
                s = p.options.get();
                if (this.remove(!0), o) if (0 !== o.length) {
                    var l = this.container();
                    s.groupBy ? (o = this.group(o), Object.keys(o).forEach(function(e, t) {
                        var n = o[e],
                        r = s.groupBy,
                        i = p.results.highlight(n[0], r, e);
                        $("<li>").addClass("group").append($("<span>").addClass("group-name").html(i)).append($("<span>").addClass("group-item-count").text(" " + n.length)).appendTo(l);
                        a.items(n, l)
                    })) : this.items(o, l);
                    var e = l.find("li:not(.group)");
                    e.on("click",
                    function(e) {
                        var t = $(this).data("item");
                        t && (p.fvalue.extract(t), a.remove(), u.trigger("select:flexdatalist", [t, s]))
                    }).hover(function() {
                        e.removeClass("active"),
                        $(this).addClass("active").trigger("active:flexdatalist.results", [$(this).data("item")])
                    },
                    function() {
                        $(this).removeClass("active")
                    }),
                    s.focusFirstResult && e.filter(":first").addClass("active")
                } else this.empty(s.noResultsText)
            },
            empty: function(e) {
                if (!p.isEmpty(e)) {
                    var t = this.container(),
                    n = f.val();
                    e = e.split("{keyword}").join(n),
                    $("<li>").addClass("item no-results").append(e).appendTo(t)
                }
            },
            items: function(e, t) {
                var n = p.options.get("maxShownResults");
                u.trigger("show:flexdatalist.results", [e]);
                for (var r = 0; r < e.length && !(0 < n && n === r); r++) this.item(e[r]).appendTo(t);
                u.trigger("shown:flexdatalist.results", [e])
            },
            item: function(e) {
                for (var t = $("<li>").data("item", e).addClass("item"), n = p.options.get(), r = n.visibleProperties, i = 0; i < r.length; i++) {
                    var o = r[i];
                    if ( - 1 < o.indexOf("{")) {
                        var a = p.fvalue.placeholders.replace(e, o),
                        s = p.fvalue.placeholders.parse(o);
                        l = $("<span>").addClass("item item-" + Object.values(s).join("-")).html(a + " ").appendTo(t)
                    } else {
                        if (n.groupBy && n.groupBy === o || !p.isDefined(e, o)) continue;
                        var l = {};
                        if (o === n.iconProperty) l = $("<img>").addClass("item item-" + o).attr("src", e[o]);
                        else {
                            var u = p.results.highlight(e, o);
                            l = $("<span>").addClass("item item-" + o).html(u + " ")
                        }
                    }
                    l.appendTo(t)
                }
                return t
            },
            container: function() {
                var e = u;
                r && (e = r);
                var t = $("ul.flexdatalist-results");
                return 0 === t.length && (t = $("<ul>").addClass("flexdatalist-results ").appendTo("body").attr("id", f.attr("id") + "-results").css({
                    "border-color": e.css("border-left-color"),
                    "border-width": "1px",
                    "border-bottom-left-radius": e.css("border-bottom-left-radius"),
                    "border-bottom-right-radius": e.css("border-bottom-right-radius")
                }).data({
                    target: r || f,
                    input: u
                }), p.position(f)),
                t
            },
            group: function(e) {
                for (var t = [], n = p.options.get("groupBy"), r = 0; r < e.length; r++) {
                    var i = e[r];
                    if (p.isDefined(i, n)) {
                        var o = i[n];
                        p.isDefined(t, o) || (t[o] = []),
                        t[o].push(i)
                    }
                }
                return t
            },
            highlight: function(e, t, n) {
                return p.isDefined(e, t + "_highlight") ? e[t + "_highlight"] : p.isDefined(e, t) ? e[t] : n
            },
            remove: function(e) {
                var t = "ul.flexdatalist-results";
                e && (t = "ul.flexdatalist-results li"),
                u.trigger("remove:flexdatalist.results"),
                $(t).remove(),
                u.trigger("removed:flexdatalist.results")
            }
        },
        this.cache = {
            write: function(e, t, n, r) {
                if (p.cache.isSupported()) {
                    e = this.keyGen(e, void 0, r);
                    var i = {
                        value: t,
                        timestamp: p.unixtime(),
                        lifetime: n || !1
                    };
                    localStorage.setItem(e, JSON.stringify(i))
                }
            },
            read: function(e, t) {
                if (p.cache.isSupported()) {
                    e = this.keyGen(e, void 0, t);
                    var n = localStorage.getItem(e);
                    if (n) {
                        var r = JSON.parse(n);
                        if (!this.expired(r)) return r.value;
                        localStorage.removeItem(e)
                    }
                }
                return null
            },
            delete: function(e, t) {
                p.cache.isSupported() && (e = this.keyGen(e, void 0, t), localStorage.removeItem(e))
            },
            clear: function() {
                if (p.cache.isSupported()) {
                    for (var e in localStorage)( - 1 < e.indexOf(s) || -1 < e.indexOf("global")) && localStorage.removeItem(e);
                    localStorage.clear()
                }
            },
            gc: function() {
                if (p.cache.isSupported()) for (var e in localStorage) if ( - 1 < e.indexOf(s) || -1 < e.indexOf("global")) {
                    var t = localStorage.getItem(e);
                    t = JSON.parse(t),
                    this.expired(t) && localStorage.removeItem(e)
                }
            },
            isSupported: function() {
                if (p.options.get("cache")) try {
                    return "localStorage" in window && null !== window.localStorage
                } catch(e) {
                    return ! 1
                }
                return ! 1
            },
            expired: function(e) {
                if (e.lifetime) {
                    var t = p.unixtime() - e.timestamp;
                    return e.lifetime <= t
                }
                return ! 1
            },
            keyGen: function(e, t, n) {
                "object" == typeof e && (e = JSON.stringify(e));
                var r, i, o = void 0 === t ? 2166136261 : t;
                for (r = 0, i = e.length; r < i; r++) o ^= e.charCodeAt(r),
                o += (o << 1) + (o << 4) + (o << 7) + (o << 8) + (o << 24);
                return (n ? "global": s) + ("0000000" + (o >>> 0).toString(16)).substr( - 8)
            }
        },
        this.options = {
            init: function() {
                var e = $.extend({},
                i, u.data(), {
                    multiple: null === i.multiple ? u.is("[multiple]") : i.multiple,
                    disabled: null === i.disabled ? u.is("[disabled]") : i.disabled,
                    originalValue: p.value
                });
                return this.set(e),
                e
            },
            get: function(e) {
                var t = u.data("flexdatalist");
                return e ? p.isDefined(t, e) ? t[e] : null: t || {}
            },
            set: function(e, t) {
                var n = this.get();
                return p.isDefined(n, e) && p.isDefined(t) ? n[e] = t: p.isObject(e) && (n = this._normalize(e)),
                u.data("flexdatalist", n),
                u
            },
            _normalize: function(e) {
                if (e.searchIn = p.csvToArray(e.searchIn), e.relatives = e.relatives && 0 < $(e.relatives).length ? $(e.relatives) : null, e.textProperty = null === e.textProperty ? e.searchIn[0] : e.textProperty, e.visibleProperties = p.csvToArray(e.visibleProperties, e.searchIn), "*" === e.valueProperty && e.multiple && !e.selectionRequired) throw new Error("Selection must be required for multiple, JSON fields!");
                return e
            }
        },
        this.position = function() {
            var e = $("ul.flexdatalist-results"),
            t = e.data("target");
            0 < e.length && e.css({
                width: t.outerWidth() + "px",
                top: t.offset().top + t.outerHeight() + "px",
                left: t.offset().left + "px"
            })
        },
        this.fdisabled = function(e) {
            if (this.isDefined(e)) {
                if (u.prop("disabled", e), f.prop("disabled", e), r) {
                    r.css("background-color", u.css("background-color"));
                    var t = r.find("li .fdl-remove"),
                    n = r.find("li.input-container");
                    e ? (r.addClass("disabled"), 0 < t.length && n.hide(), t.hide()) : (r.removeClass("disabled"), n.show(), t.show())
                }
                this.options.set("disabled", e)
            }
            return this.options.get("disabled")
        },
        this.isDup = function(e) {
            return ! this.options.get("allowDuplicateValues") && (0 < a.length && -1 < a.indexOf(this.fvalue.value(e)))
        },
        this.keyNum = function(e) {
            return e.which || e.keyCode
        },
        this.isEmpty = function(e) {
            return ! p.isDefined(e) || (null === e || !0 !== e && (0 === this.length(e) || "" === $.trim(e)))
        },
        this.isObject = function(e) {
            return e && "object" == typeof e
        },
        this.length = function(e) {
            return this.isObject(e) ? Object.keys(e).length: "number" == typeof e || "number" == typeof e.length ? e.toString().length: 0
        },
        this.isDefined = function(e, t) {
            var n = void 0 !== e;
            return n && void 0 !== t ? void 0 !== e[t] : n
        },
        this.unixtime = function(e) {
            var t = new Date;
            return e && (t = new Date(e)),
            Math.round(t.getTime() / 1e3)
        },
        this.csvToArray = function(e, t) {
            return 0 === e.length ? t: "string" == typeof e ? e.split(p.options.get("valuesSeparator")) : e
        },
        this.debug = function(e, t) {
            var n = p.options.get();
            n.debug && (t || (t = {}), e = "Flexdatalist: " + e, console.warn(e), console.log($.extend({
                inputName: u.attr("name"),
                options: n
            },
            t)), console.log("--- /flexdatalist ---"))
        },
        this.init()
    })
} 