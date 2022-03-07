 
window.filters = {
    priceformat: function(e, t) {
        return t = t || "USD",
        currency_symbols = {
            USD: "$",
            EUR: "&euro;"
        },
        symbol = currency_symbols[t] || t,
        symbol + e.toFixed(2)
    },
    filesizeformat: function(e, t) {
        var n = t ? 1024 : 1e3,
        i = parseFloat(e);
        return 1 === i ? "1 Byte": i < n ? i + " Bytes": ["Bytes", t ? "KiB": "kB", t ? "MiB": "MB", t ? "GiB": "GB", t ? "TiB": "TB", t ? "PiB": "PB", t ? "EiB": "EB", t ? "ZiB": "ZB", t ? "YiB": "YB"].reduce(function(e, t, a) {
            var o = Math.pow(n, a);
            return o <= i ? (i / o).toFixed(1) + " " + t: e
        })
    },
    intcomma: function(e) {
        return e.toString().replace(/\B(?=(\d{3})+(?!\d))/g, ",")
    },
    sum: function(e, t) {
        var a = 0;
        return e.forEach(function(e) {
            a += e[t.attribute]
        }),
        a
    },
    title: function(e) {
        return e.charAt(0).toUpperCase() + e.slice(1)
    }
},
$(function() {
    window.templates = new nunjucks.Environment,
    $.each(window.filters,
    function(e, t) {
        templates.addFilter(e, t, !0)
    })
}),
 
$(function() {
    if ($.extend(FormSerializer.patterns, {
        validate: /^[a-z][a-z0-9_-]*(?:\[(?:\d*|[a-z0-9_-]+)\])*$/i,
        key: /[a-z0-9_-]+|(?=\[\])/gi,
        named: /^[a-z0-9_-]+$/i
    }), $(document).on("click", '[data-toggle="toggle"]',
    function(e) {
        e.preventDefault();
        var t = $(this),
        a = t.data("target") || t.attr("href");
        $(a).toggleClass("d-none")
    }),   $(".search-form .flexdatalist").on("select:flexdatalist",
    function() {
        $(this).parents("form").submit()
    }), $(".search-form .flexdatalist-alias").on("keydown",
    function(e) {
        13 == e.keyCode && $(this).parents("form").submit()
    }), $(".flexdatalist").parents("form").on("submit",
    function() {
        $(this).find(".flexdatalist-alias").removeAttr("name")
    }), $(document).on("click", "[data-confirm]",
    function(e) {
        var t = confirm($(this).data("confirm"));
        return t || e.stopImmediatePropagation(),
        t
    }), $(document).on("click", '[data-toggle="tooltip"]',
    function() {
        $(this).tooltip("hide")
    }), $(document).on("shown.bs.collapse", ".collapse",
    function() {
        $(this).find("[autofocus]").trigger("focus")
    }), $(".background-picker").on("click", "a",
    function(e) {
        e.preventDefault();
        var t = $(this),
        a = t.parents(".background-picker"),
        o = t.data("value");
        a.find(".active").removeClass("active"),
        t.addClass("active"),
        $("body").removeClass("preview-white preview-black preview-gray preview-transparent").addClass("preview-" + o),
        Cookies.set("preview-color", o)
    }), $(document).on("click", "a.icon-preview-img",
    function() {
        tracking.track("event", {
            category: "Icon",
            action: "Click link"
        })
    }), $(document).on("click", '[data-requires="user"]',
    function(e) {
        if ("undefined" == typeof USER) {
            e.preventDefault(),
            e.stopImmediatePropagation(),
            renderModal("login/_modal");
            var t = $(this);
            $("body").on("form.submit.success", "#login-form, #signup-form",
            function(e) {
                t.is("a") && "#" !== t.attr("href") && (e.stopImmediatePropagation(), location.href = t.attr("href"))
            })
        }
    }), $(document).on("click", '[href="/user/logout"]',
    function() {
        Intercom("shutdown")
    }) ) {
      
    }
}),
 
$(function() {
    $(".navbar").each(function() {
        var e = $(this).offset().top,
        t = $('[data-toggle="navigation-sticky"]');
        t.length && (e = t.offset().top + t.outerHeight(), $("body").addClass("nav-fade")),
        $(window).on("load scroll",
        function() {
            $("body").toggleClass("nav-fixed", $(window).scrollTop() >= e)
        })
    })
}) 
 
 
 