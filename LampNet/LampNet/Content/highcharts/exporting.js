﻿/*
 Highcharts JS v8.1.0 (2020-05-05)

 Exporting module

 (c) 2010-2019 Torstein Honsi

 License: www.highcharts.com/license
*/
(function (g) { "object" === typeof module && module.exports ? (g["default"] = g, module.exports = g) : "function" === typeof define && define.amd ? define("highcharts/modules/exporting", ["highcharts"], function (n) { g(n); g.Highcharts = n; return g }) : g("undefined" !== typeof Highcharts ? Highcharts : void 0) })(function (g) {
    function n(e, f, g, l) { e.hasOwnProperty(f) || (e[f] = l.apply(null, g)) } g = g ? g._modules : {}; n(g, "modules/full-screen.src.js", [g["parts/Globals.js"], g["parts/Utilities.js"]], function (e, f) {
        var g = f.addEvent; f = e.Chart; var l = function () {
            function e(k) {
            this.chart =
                k; this.isOpen = !1; k = k.renderTo; this.browserProps || ("function" === typeof k.requestFullscreen ? this.browserProps = { fullscreenChange: "fullscreenchange", requestFullscreen: "requestFullscreen", exitFullscreen: "exitFullscreen" } : k.mozRequestFullScreen ? this.browserProps = { fullscreenChange: "mozfullscreenchange", requestFullscreen: "mozRequestFullScreen", exitFullscreen: "mozCancelFullScreen" } : k.webkitRequestFullScreen ? this.browserProps = {
                    fullscreenChange: "webkitfullscreenchange", requestFullscreen: "webkitRequestFullScreen",
                    exitFullscreen: "webkitExitFullscreen"
                } : k.msRequestFullscreen && (this.browserProps = { fullscreenChange: "MSFullscreenChange", requestFullscreen: "msRequestFullscreen", exitFullscreen: "msExitFullscreen" }))
            } e.prototype.close = function () { var k = this.chart; if (this.isOpen && this.browserProps && k.container.ownerDocument instanceof Document) k.container.ownerDocument[this.browserProps.exitFullscreen](); this.unbindFullscreenEvent && this.unbindFullscreenEvent(); this.isOpen = !1; this.setButtonText() }; e.prototype.open = function () {
                var k =
                    this, e = k.chart; if (k.browserProps) { k.unbindFullscreenEvent = g(e.container.ownerDocument, k.browserProps.fullscreenChange, function () { k.isOpen ? (k.isOpen = !1, k.close()) : (k.isOpen = !0, k.setButtonText()) }); var f = e.renderTo[k.browserProps.requestFullscreen](); if (f) f["catch"](function () { alert("Full screen is not supported inside a frame.") }); g(e, "destroy", k.unbindFullscreenEvent) }
            }; e.prototype.setButtonText = function () {
                var e, f = this.chart, g = f.exportDivElements, l = f.options.exporting, q = null === (e = null === l || void 0 ===
                    l ? void 0 : l.buttons) || void 0 === e ? void 0 : e.contextButton.menuItems; e = f.options.lang; (null === l || void 0 === l ? 0 : l.menuItemDefinitions) && (null === e || void 0 === e ? 0 : e.exitFullscreen) && e.viewFullscreen && q && g && g.length && (g[q.indexOf("viewFullscreen")].innerHTML = this.isOpen ? e.exitFullscreen : l.menuItemDefinitions.viewFullscreen.text || e.viewFullscreen)
            }; e.prototype.toggle = function () { this.isOpen ? this.close() : this.open() }; return e
        }(); e.Fullscreen = l; g(f, "beforeRender", function () { this.fullscreen = new e.Fullscreen(this) });
        return e.Fullscreen
    }); n(g, "mixins/navigation.js", [], function () { return { initUpdate: function (e) { e.navigation || (e.navigation = { updates: [], update: function (e, g) { this.updates.forEach(function (f) { f.update.call(f.context, e, g) }) } }) }, addUpdate: function (e, f) { f.navigation || this.initUpdate(f); f.navigation.updates.push({ update: e, context: f }) } } }); n(g, "modules/exporting.src.js", [g["parts/Globals.js"], g["parts/Utilities.js"], g["mixins/navigation.js"]], function (e, f, g) {
        var l = f.addEvent, q = f.css, k = f.createElement, n = f.discardElement,
        w = f.extend, I = f.find, A = f.fireEvent, J = f.isObject, r = f.merge, E = f.objectEach, t = f.pick, K = f.removeEvent, L = f.uniqueKey, v = e.defaultOptions, x = e.doc, B = e.Chart, M = e.isTouchDevice, y = e.win, G = y.navigator.userAgent, F = e.SVGRenderer, H = e.Renderer.prototype.symbols, N = /Edge\/|Trident\/|MSIE /.test(G), O = /firefox/i.test(G); w(v.lang, {
            viewFullscreen: "View in full screen", exitFullscreen: "Exit from full screen", printChart: "Print chart", downloadPNG: "Download PNG image", downloadJPEG: "Download JPEG image", downloadPDF: "Download PDF document",
            downloadSVG: "Download SVG vector image", contextButtonTitle: "Chart context menu"
        }); v.navigation || (v.navigation = {}); r(!0, v.navigation, { buttonOptions: { theme: {}, symbolSize: 14, symbolX: 12.5, symbolY: 10.5, align: "right", buttonSpacing: 3, height: 22, verticalAlign: "top", width: 24 } }); r(!0, v.navigation, {
            menuStyle: { border: "1px solid #999999", background: "#ffffff", padding: "5px 0" }, menuItemStyle: { padding: "0.5em 1em", color: "#333333", background: "none", fontSize: M ? "14px" : "11px", transition: "background 250ms, color 250ms" },
            menuItemHoverStyle: { background: "#335cad", color: "#ffffff" }, buttonOptions: { symbolFill: "#666666", symbolStroke: "#666666", symbolStrokeWidth: 3, theme: { padding: 5 } }
        }); v.exporting = {
            type: "image/png", url: "https://export.highcharts.com/", printMaxWidth: 780, scale: 2, buttons: { contextButton: { className: "highcharts-contextbutton", menuClassName: "highcharts-contextmenu", symbol: "menu", titleKey: "contextButtonTitle", menuItems: "viewFullscreen printChart separator downloadPNG downloadJPEG downloadPDF downloadSVG".split(" ") } },
            menuItemDefinitions: {
                viewFullscreen: { textKey: "viewFullscreen", onclick: function () { this.fullscreen.toggle() } }, printChart: { textKey: "printChart", onclick: function () { this.print() } }, separator: { separator: !0 }, downloadPNG: { textKey: "downloadPNG", onclick: function () { this.exportChart() } }, downloadJPEG: { textKey: "downloadJPEG", onclick: function () { this.exportChart({ type: "image/jpeg" }) } }, downloadPDF: { textKey: "downloadPDF", onclick: function () { this.exportChart({ type: "application/pdf" }) } }, downloadSVG: {
                    textKey: "downloadSVG",
                    onclick: function () { this.exportChart({ type: "image/svg+xml" }) }
                }
            }
        }; e.post = function (a, b, c) { var d = k("form", r({ method: "post", action: a, enctype: "multipart/form-data" }, c), { display: "none" }, x.body); E(b, function (a, b) { k("input", { type: "hidden", name: b, value: a }, null, d) }); d.submit(); n(d) }; e.isSafari && e.win.matchMedia("print").addListener(function (a) { e.printingChart && (a.matches ? e.printingChart.beforePrint() : e.printingChart.afterPrint()) }); w(B.prototype, {
            sanitizeSVG: function (a, b) {
                var c = a.indexOf("</svg>") + 6, d = a.substr(c);
                a = a.substr(0, c); b && b.exporting && b.exporting.allowHTML && d && (d = '<foreignObject x="0" y="0" width="' + b.chart.width + '" height="' + b.chart.height + '"><body xmlns="http://www.w3.org/1999/xhtml">' + d + "</body></foreignObject>", a = a.replace("</svg>", d + "</svg>")); a = a.replace(/zIndex="[^"]+"/g, "").replace(/symbolName="[^"]+"/g, "").replace(/jQuery[0-9]+="[^"]+"/g, "").replace(/url\(("|&quot;)(.*?)("|&quot;);?\)/g, "url($2)").replace(/url\([^#]+#/g, "url(#").replace(/<svg /, '<svg xmlns:xlink="http://www.w3.org/1999/xlink" ').replace(/ (|NS[0-9]+:)href=/g,
                    " xlink:href=").replace(/\n/, " ").replace(/(fill|stroke)="rgba\(([ 0-9]+,[ 0-9]+,[ 0-9]+),([ 0-9\.]+)\)"/g, '$1="rgb($2)" $1-opacity="$3"').replace(/&nbsp;/g, "\u00a0").replace(/&shy;/g, "\u00ad"); this.ieSanitizeSVG && (a = this.ieSanitizeSVG(a)); return a
            }, getChartHTML: function () { this.styledMode && this.inlineStyles(); return this.container.innerHTML }, getSVG: function (a) {
                var b, c = r(this.options, a); c.plotOptions = r(this.userOptions.plotOptions, a && a.plotOptions); c.time = r(this.userOptions.time, a && a.time); var d = k("div",
                    null, { position: "absolute", top: "-9999em", width: this.chartWidth + "px", height: this.chartHeight + "px" }, x.body); var f = this.renderTo.style.width; var g = this.renderTo.style.height; f = c.exporting.sourceWidth || c.chart.width || /px$/.test(f) && parseInt(f, 10) || (c.isGantt ? 800 : 600); g = c.exporting.sourceHeight || c.chart.height || /px$/.test(g) && parseInt(g, 10) || 400; w(c.chart, { animation: !1, renderTo: d, forExport: !0, renderer: "SVGRenderer", width: f, height: g }); c.exporting.enabled = !1; delete c.data; c.series = []; this.series.forEach(function (a) {
                        b =
                        r(a.userOptions, { animation: !1, enableMouseTracking: !1, showCheckbox: !1, visible: a.visible }); b.isInternal || c.series.push(b)
                    }); this.axes.forEach(function (a) { a.userOptions.internalKey || (a.userOptions.internalKey = L()) }); var u = new e.Chart(c, this.callback); a && ["xAxis", "yAxis", "series"].forEach(function (b) { var d = {}; a[b] && (d[b] = a[b], u.update(d)) }); this.axes.forEach(function (a) {
                        var b = I(u.axes, function (b) { return b.options.internalKey === a.userOptions.internalKey }), d = a.getExtremes(), c = d.userMin; d = d.userMax; b && ("undefined" !==
                            typeof c && c !== b.min || "undefined" !== typeof d && d !== b.max) && b.setExtremes(c, d, !0, !1)
                    }); f = u.getChartHTML(); A(this, "getSVG", { chartCopy: u }); f = this.sanitizeSVG(f, c); c = null; u.destroy(); n(d); return f
            }, getSVGForExport: function (a, b) { var c = this.options.exporting; return this.getSVG(r({ chart: { borderRadius: 0 } }, c.chartOptions, b, { exporting: { sourceWidth: a && a.sourceWidth || c.sourceWidth, sourceHeight: a && a.sourceHeight || c.sourceHeight } })) }, getFilename: function () {
                var a = this.userOptions.title && this.userOptions.title.text,
                b = this.options.exporting.filename; if (b) return b.replace(/\//g, "-"); "string" === typeof a && (b = a.toLowerCase().replace(/<\/?[^>]+(>|$)/g, "").replace(/[\s_]+/g, "-").replace(/[^a-z0-9\-]/g, "").replace(/^[\-]+/g, "").replace(/[\-]+/g, "-").substr(0, 24).replace(/[\-]+$/g, "")); if (!b || 5 > b.length) b = "chart"; return b
            }, exportChart: function (a, b) {
                b = this.getSVGForExport(a, b); a = r(this.options.exporting, a); e.post(a.url, {
                    filename: a.filename ? a.filename.replace(/\//g, "-") : this.getFilename(), type: a.type, width: a.width || 0,
                    scale: a.scale, svg: b
                }, a.formAttributes)
            }, moveContainers: function (a) { (this.fixedDiv ? [this.fixedDiv, this.scrollingContainer] : [this.container]).forEach(function (b) { a.appendChild(b) }) }, beforePrint: function () {
                var a = x.body, b = this.options.exporting.printMaxWidth, c = { childNodes: a.childNodes, origDisplay: [], resetParams: void 0 }; this.isPrinting = !0; this.pointer.reset(null, 0); A(this, "beforePrint"); b && this.chartWidth > b && (c.resetParams = [this.options.chart.width, void 0, !1], this.setSize(b, void 0, !1));[].forEach.call(c.childNodes,
                    function (a, b) { 1 === a.nodeType && (c.origDisplay[b] = a.style.display, a.style.display = "none") }); this.moveContainers(a); this.printReverseInfo = c
            }, afterPrint: function () {
                if (this.printReverseInfo) {
                    var a = this.printReverseInfo.childNodes, b = this.printReverseInfo.origDisplay, c = this.printReverseInfo.resetParams; this.moveContainers(this.renderTo);[].forEach.call(a, function (a, c) { 1 === a.nodeType && (a.style.display = b[c] || "") }); this.isPrinting = !1; c && this.setSize.apply(this, c); delete this.printReverseInfo; delete e.printingChart;
                    A(this, "afterPrint")
                }
            }, print: function () { var a = this; a.isPrinting || (e.printingChart = a, e.isSafari || a.beforePrint(), setTimeout(function () { y.focus(); y.print(); e.isSafari || setTimeout(function () { a.afterPrint() }, 1E3) }, 1)) }, contextMenu: function (a, b, c, d, e, g, u) {
                var h = this, D = h.options.navigation, r = h.chartWidth, z = h.chartHeight, p = "cache-" + a, m = h[p], C = Math.max(e, g); if (!m) {
                h.exportContextMenu = h[p] = m = k("div", { className: a }, { position: "absolute", zIndex: 1E3, padding: C + "px", pointerEvents: "auto" }, h.fixedDiv || h.container);
                    var n = k("ul", { className: "highcharts-menu" }, { listStyle: "none", margin: 0, padding: 0 }, m); h.styledMode || q(n, w({ MozBoxShadow: "3px 3px 10px #888", WebkitBoxShadow: "3px 3px 10px #888", boxShadow: "3px 3px 10px #888" }, D.menuStyle)); m.hideMenu = function () { q(m, { display: "none" }); u && u.setState(0); h.openMenu = !1; q(h.renderTo, { overflow: "hidden" }); f.clearTimeout(m.hideTimer); A(h, "exportMenuHidden") }; h.exportEvents.push(l(m, "mouseleave", function () { m.hideTimer = y.setTimeout(m.hideMenu, 500) }), l(m, "mouseenter", function () { f.clearTimeout(m.hideTimer) }),
                        l(x, "mouseup", function (b) { h.pointer.inClass(b.target, a) || m.hideMenu() }), l(m, "click", function () { h.openMenu && m.hideMenu() })); b.forEach(function (a) {
                        "string" === typeof a && (a = h.options.exporting.menuItemDefinitions[a]); if (J(a, !0)) {
                            if (a.separator) var b = k("hr", null, null, n); else b = k("li", { className: "highcharts-menu-item", onclick: function (b) { b && b.stopPropagation(); m.hideMenu(); a.onclick && a.onclick.apply(h, arguments) }, innerHTML: a.text || h.options.lang[a.textKey] }, null, n), h.styledMode || (b.onmouseover = function () {
                                q(this,
                                    D.menuItemHoverStyle)
                            }, b.onmouseout = function () { q(this, D.menuItemStyle) }, q(b, w({ cursor: "pointer" }, D.menuItemStyle))); h.exportDivElements.push(b)
                        }
                        }); h.exportDivElements.push(n, m); h.exportMenuWidth = m.offsetWidth; h.exportMenuHeight = m.offsetHeight
                } b = { display: "block" }; c + h.exportMenuWidth > r ? b.right = r - c - e - C + "px" : b.left = c - C + "px"; d + g + h.exportMenuHeight > z && "top" !== u.alignOptions.verticalAlign ? b.bottom = z - d - C + "px" : b.top = d + g - C + "px"; q(m, b); q(h.renderTo, { overflow: "" }); h.openMenu = !0; A(h, "exportMenuShown")
            }, addButton: function (a) {
                var b =
                    this, c = b.renderer, d = r(b.options.navigation.buttonOptions, a), e = d.onclick, f = d.menuItems, g = d.symbolSize || 12; b.btnCount || (b.btnCount = 0); b.exportDivElements || (b.exportDivElements = [], b.exportSVGElements = []); if (!1 !== d.enabled) {
                        var h = d.theme, k = h.states, l = k && k.hover; k = k && k.select; var z; b.styledMode || (h.fill = t(h.fill, "#ffffff"), h.stroke = t(h.stroke, "none")); delete h.states; e ? z = function (a) { a && a.stopPropagation(); e.call(b, a) } : f && (z = function (a) {
                            a && a.stopPropagation(); b.contextMenu(p.menuClassName, f, p.translateX,
                                p.translateY, p.width, p.height, p); p.setState(2)
                        }); d.text && d.symbol ? h.paddingLeft = t(h.paddingLeft, 25) : d.text || w(h, { width: d.width, height: d.height, padding: 0 }); b.styledMode || (h["stroke-linecap"] = "round", h.fill = t(h.fill, "#ffffff"), h.stroke = t(h.stroke, "none")); var p = c.button(d.text, 0, 0, z, h, l, k).addClass(a.className).attr({ title: t(b.options.lang[d._titleKey || d.titleKey], "") }); p.menuClassName = a.menuClassName || "highcharts-menu-" + b.btnCount++; if (d.symbol) {
                            var m = c.symbol(d.symbol, d.symbolX - g / 2, d.symbolY - g / 2,
                                g, g, { width: g, height: g }).addClass("highcharts-button-symbol").attr({ zIndex: 1 }).add(p); b.styledMode || m.attr({ stroke: d.symbolStroke, fill: d.symbolFill, "stroke-width": d.symbolStrokeWidth || 1 })
                        } p.add(b.exportingGroup).align(w(d, { width: p.width, x: t(d.x, b.buttonOffset) }), !0, "spacingBox"); b.buttonOffset += (p.width + d.buttonSpacing) * ("right" === d.align ? -1 : 1); b.exportSVGElements.push(p, m)
                    }
            }, destroyExport: function (a) {
                var b = a ? a.target : this; a = b.exportSVGElements; var c = b.exportDivElements, d = b.exportEvents, e; a && (a.forEach(function (a,
                    d) { a && (a.onclick = a.ontouchstart = null, e = "cache-" + a.menuClassName, b[e] && delete b[e], b.exportSVGElements[d] = a.destroy()) }), a.length = 0); b.exportingGroup && (b.exportingGroup.destroy(), delete b.exportingGroup); c && (c.forEach(function (a, d) { f.clearTimeout(a.hideTimer); K(a, "mouseleave"); b.exportDivElements[d] = a.onmouseout = a.onmouseover = a.ontouchstart = a.onclick = null; n(a) }), c.length = 0); d && (d.forEach(function (a) { a() }), d.length = 0)
            }
        }); F.prototype.inlineToAttributes = "fill stroke strokeLinecap strokeLinejoin strokeWidth textAnchor x y".split(" ");
        F.prototype.inlineBlacklist = [/-/, /^(clipPath|cssText|d|height|width)$/, /^font$/, /[lL]ogical(Width|Height)$/, /perspective/, /TapHighlightColor/, /^transition/, /^length$/]; F.prototype.unstyledElements = ["clipPath", "defs", "desc"]; B.prototype.inlineStyles = function () {
            function a(a) { return a.replace(/([A-Z])/g, function (a, b) { return "-" + b.toLowerCase() }) } function b(c) {
                function p(b, f) {
                    n = q = !1; if (g) { for (t = g.length; t-- && !q;)q = g[t].test(f); n = !q } "transform" === f && "none" === b && (n = !0); for (t = e.length; t-- && !n;)n = e[t].test(f) ||
                        "function" === typeof b; n || w[f] === b && "svg" !== c.nodeName || h[c.nodeName][f] === b || (-1 !== d.indexOf(f) ? c.setAttribute(a(f), b) : m += a(f) + ":" + b + ";")
                } var m = "", n, q, t; if (1 === c.nodeType && -1 === f.indexOf(c.nodeName)) {
                    var u = y.getComputedStyle(c, null); var w = "svg" === c.nodeName ? {} : y.getComputedStyle(c.parentNode, null); if (!h[c.nodeName]) {
                        k = l.getElementsByTagName("svg")[0]; var v = l.createElementNS(c.namespaceURI, c.nodeName); k.appendChild(v); h[c.nodeName] = r(y.getComputedStyle(v, null)); "text" === c.nodeName && delete h.text.fill;
                        k.removeChild(v)
                    } if (O || N) for (var x in u) p(u[x], x); else E(u, p); m && (u = c.getAttribute("style"), c.setAttribute("style", (u ? u + ";" : "") + m)); "svg" === c.nodeName && c.setAttribute("stroke-width", "1px"); "text" !== c.nodeName && [].forEach.call(c.children || c.childNodes, b)
                }
            } var c = this.renderer, d = c.inlineToAttributes, e = c.inlineBlacklist, g = c.inlineWhitelist, f = c.unstyledElements, h = {}, k; c = x.createElement("iframe"); q(c, { width: "1px", height: "1px", visibility: "hidden" }); x.body.appendChild(c); var l = c.contentWindow.document; l.open();
            l.write('<svg xmlns="http://www.w3.org/2000/svg"></svg>'); l.close(); b(this.container.querySelector("svg")); k.parentNode.removeChild(k)
        }; H.menu = function (a, b, c, d) { return [["M", a, b + 2.5], ["L", a + c, b + 2.5], ["M", a, b + d / 2 + .5], ["L", a + c, b + d / 2 + .5], ["M", a, b + d - 1.5], ["L", a + c, b + d - 1.5]] }; H.menuball = function (a, b, c, d) { a = []; d = d / 3 - 2; return a = a.concat(this.circle(c - d, b, d, d), this.circle(c - d, b + d + 4, d, d), this.circle(c - d, b + 2 * (d + 4), d, d)) }; B.prototype.renderExporting = function () {
            var a = this, b = a.options.exporting, c = b.buttons, d = a.isDirtyExporting ||
                !a.exportSVGElements; a.buttonOffset = 0; a.isDirtyExporting && a.destroyExport(); d && !1 !== b.enabled && (a.exportEvents = [], a.exportingGroup = a.exportingGroup || a.renderer.g("exporting-group").attr({ zIndex: 3 }).add(), E(c, function (b) { a.addButton(b) }), a.isDirtyExporting = !1); l(a, "destroy", a.destroyExport)
        }; l(B, "init", function () {
            var a = this; a.exporting = { update: function (b, c) { a.isDirtyExporting = !0; r(!0, a.options.exporting, b); t(c, !0) && a.redraw() } }; g.addUpdate(function (b, c) {
            a.isDirtyExporting = !0; r(!0, a.options.navigation,
                b); t(c, !0) && a.redraw()
            }, a)
        }); B.prototype.callbacks.push(function (a) { a.renderExporting(); l(a, "redraw", a.renderExporting) })
    }); n(g, "masters/modules/exporting.src.js", [], function () { })
});
//# sourceMappingURL=exporting.js.map