"use strict";(self.webpackChunketihadrailapp=self.webpackChunketihadrailapp||[]).push([[2922],{33624:function(t,e,i){i.d(e,{W:function(){return f}});var n=i(1413),s=i(37762),r=i(15671),a=i(43144),u=i(11752),o=i(61120),l=i(60136),h=i(29388),c=i(23588),v=i(41978),f=function(t){(0,l.Z)(i,t);var e=(0,h.Z)(i);function i(){var t;return(0,r.Z)(this,i),(t=e.apply(this,arguments))._childrenSet=new Set,t._needsSort=!1,t.children=[],t._effectView=null,t}return(0,a.Z)(i,[{key:"blendMode",get:function(){return this._blendMode},set:function(t){this._blendMode=t,this.requestRender()}},{key:"clips",get:function(){return this._clips},set:function(t){this._clips=t,this.children.forEach((function(e){return e.clips=t}))}},{key:"computedEffects",get:function(){var t,e;return null!=(t=null==(e=this._effectView)?void 0:e.effects)?t:null}},{key:"effect",get:function(){var t,e;return null!=(t=null==(e=this._effectView)?void 0:e.effect)?t:""},set:function(t){(this._effectView||t)&&(this._effectView||(this._effectView=new v.ZP),this._effectView.effect=t,this.requestRender())}},{key:"updateTransitionProperties",value:function(t,e){(0,u.Z)((0,o.Z)(i.prototype),"updateTransitionProperties",this).call(this,t,e),this._effectView&&(this._effectView.transitionStep(t,e),this._effectView.transitioning&&this.requestRender())}},{key:"doRender",value:function(t){var e=this.createRenderParams(t);this.renderChildren(e)}},{key:"addChild",value:function(t){return this.addChildAt(t,this.children.length)}},{key:"addChildAt",value:function(t){var e=arguments.length>1&&void 0!==arguments[1]?arguments[1]:this.children.length;if(!t)return t;if(this.contains(t))return t;this._needsSort=!0;var i=t.parent;return i&&i!==this&&i.removeChild(t),e>=this.children.length?this.children.push(t):this.children.splice(e,0,t),this._childrenSet.add(t),t.parent=this,t.stage=this.stage,this!==this.stage&&(t.clips=this.clips),this.requestRender(),t}},{key:"contains",value:function(t){return this._childrenSet.has(t)}},{key:"removeAllChildren",value:function(){this._childrenSet.clear(),this._needsSort=!0;var t,e=(0,s.Z)(this.children);try{for(e.s();!(t=e.n()).done;){var i=t.value;this!==this.stage&&(i.clips=null),i.stage=null,i.parent=null}}catch(n){e.e(n)}finally{e.f()}this.children.length=0}},{key:"removeChild",value:function(t){return this.contains(t)?this.removeChildAt(this.children.indexOf(t)):t}},{key:"removeChildAt",value:function(t){if(t<0||t>=this.children.length)return null;this._needsSort=!0;var e=this.children.splice(t,1)[0];return this._childrenSet.delete(e),this!==this.stage&&(e.clips=null),e.stage=null,e.parent=null,e}},{key:"sortChildren",value:function(t){this._needsSort&&(this.children.sort(t),this._needsSort=!1)}},{key:"_createTransforms",value:function(){return{dvs:(0,c.c)()}}},{key:"onAttach",value:function(){(0,u.Z)((0,o.Z)(i.prototype),"onAttach",this).call(this);var t,e=this.stage,n=(0,s.Z)(this.children);try{for(n.s();!(t=n.n()).done;){t.value.stage=e}}catch(r){n.e(r)}finally{n.f()}}},{key:"onDetach",value:function(){(0,u.Z)((0,o.Z)(i.prototype),"onDetach",this).call(this);var t,e=(0,s.Z)(this.children);try{for(e.s();!(t=e.n()).done;){t.value.stage=null}}catch(n){e.e(n)}finally{e.f()}}},{key:"renderChildren",value:function(t){var e,i=(0,s.Z)(this.children);try{for(i.s();!(e=i.n()).done;){e.value.beforeRender(t)}}catch(o){i.e(o)}finally{i.f()}var n,r=(0,s.Z)(this.children);try{for(r.s();!(n=r.n()).done;){n.value.processRender(t)}}catch(o){r.e(o)}finally{r.f()}var a,u=(0,s.Z)(this.children);try{for(u.s();!(a=u.n()).done;){a.value.afterRender(t)}}catch(o){u.e(o)}finally{u.f()}}},{key:"createRenderParams",value:function(t){return(0,n.Z)((0,n.Z)({},t),{},{blendMode:this.blendMode,effects:this.computedEffects,globalOpacity:t.globalOpacity*this.computedOpacity,inFadeTransition:this.inFadeTransition})}}]),i}(i(87422).s)},87422:function(t,e,i){i.d(e,{s:function(){return v}});var n=i(15671),s=i(43144),r=i(60136),a=i(29388),u=i(91505),o=i(93169),l=i(92026),h=i(66978),c=1/(0,o.Z)("mapview-transitions-duration"),v=function(t){(0,r.Z)(i,t);var e=(0,a.Z)(i);function i(){var t;return(0,n.Z)(this,i),(t=e.apply(this,arguments))._fadeOutResolver=null,t._fadeInResolver=null,t._clips=null,t.computedVisible=!0,t.computedOpacity=1,t.fadeTransitionEnabled=!1,t.inFadeTransition=!1,t._isReady=!1,t._opacity=1,t._stage=null,t._visible=!0,t}return(0,s.Z)(i,[{key:"clips",get:function(){return this._clips},set:function(t){this._clips=t,this.requestRender()}},{key:"isReady",get:function(){return this._isReady}},{key:"opacity",get:function(){return this._opacity},set:function(t){this._opacity!==t&&(this._opacity=Math.min(1,Math.max(t,0)),this.requestRender())}},{key:"stage",get:function(){return this._stage},set:function(t){if(this._stage!==t){var e=this._stage;this._stage=t,t?this._stage.untrashDisplayObject(this)||(this.onAttach(),this.emit("attach")):e.trashDisplayObject(this)}}},{key:"transforms",get:function(){return this._getTransforms()}},{key:"_getTransforms",value:function(){return(0,l.Wi)(this._transforms)&&(this._transforms=this._createTransforms()),this._transforms}},{key:"visible",get:function(){return this._visible},set:function(t){this._visible!==t&&(this._visible=t,this.requestRender())}},{key:"fadeIn",value:function(){return this._fadeInResolver||(this._fadeOutResolver&&(this._fadeOutResolver(),this._fadeOutResolver=null),this.computedOpacity=0,this.fadeTransitionEnabled=!0,this._fadeInResolver=(0,h.hh)(),this.requestRender()),this._fadeInResolver.promise}},{key:"fadeOut",value:function(){return this._fadeOutResolver||(this._fadeInResolver&&(this._fadeInResolver(),this._fadeInResolver=null),this.fadeTransitionEnabled=!0,this._fadeOutResolver=(0,h.hh)(),this.requestRender()),this._fadeOutResolver.promise}},{key:"beforeRender",value:function(t){this.updateTransitionProperties(t.deltaTime,t.state.scale)}},{key:"afterRender",value:function(t){this._fadeInResolver&&this.computedOpacity===this.opacity?(this._fadeInResolver(),this._fadeInResolver=null):this._fadeOutResolver&&0===this.computedOpacity&&(this._fadeOutResolver(),this._fadeOutResolver=null)}},{key:"remove",value:function(){var t;null==(t=this.parent)||t.removeChild(this)}},{key:"setTransform",value:function(t){}},{key:"processRender",value:function(t){this.stage&&this.computedVisible&&this.doRender(t)}},{key:"requestRender",value:function(){this.stage&&this.stage.requestRender()}},{key:"processDetach",value:function(){this.onDetach(),this.emit("detach")}},{key:"updateTransitionProperties",value:function(t,e){if(this.fadeTransitionEnabled){var i=this._fadeOutResolver||!this.visible?0:this.opacity,n=this.computedOpacity;if(n===i)this.computedVisible=this.visible;else{var s=t*c;this.computedOpacity=n>i?Math.max(i,n-s):Math.min(i,n+s),this.computedVisible=this.computedOpacity>0;var r=i===this.computedOpacity;this.inFadeTransition=!r,r||this.requestRender()}}else this.computedOpacity=this.opacity,this.computedVisible=this.visible}},{key:"onAttach",value:function(){}},{key:"onDetach",value:function(){}},{key:"doRender",value:function(t){}},{key:"ready",value:function(){this._isReady||(this._isReady=!0,this.emit("isReady"),this.requestRender())}}]),i}(u.Z)},54815:function(t,e,i){i.d(e,{dk:function(){return V},Gq:function(){return R},a:function(){return k},mE:function(){return g},m2:function(){return y},qr:function(){return m},jj:function(){return f},hF:function(){return d}});var n=i(1413),s=i(11752),r=i(61120),a=i(60136),u=i(29388),o=i(15671),l=i(43144),h=i(10064),c=i(80613),v=i(49083);function f(t,e){switch(t){case c.LW.FILL:return V.from(e);case c.LW.LINE:return k.from(e);case c.LW.MARKER:return g.from(e);case c.LW.TEXT:return m.from(e);case c.LW.LABEL:return R.from(e);default:throw new Error("Unable to createMaterialKey for unknown geometryType ".concat(t))}}function d(t){switch(y.load(t).geometryType){case c.LW.MARKER:return new g(t);case c.LW.FILL:return new V(t);case c.LW.LINE:return new k(t);case c.LW.TEXT:return new m(t);case c.LW.LABEL:return new R(t)}}var y=function(){function t(e){(0,o.Z)(this,t),this._data=0,this._data=e}return(0,l.Z)(t,[{key:"data",get:function(){return this._data},set:function(t){this._data=t}},{key:"geometryType",get:function(){return this.bits(8,11)},set:function(t){this.setBits(t,8,11)}},{key:"mapAligned",get:function(){return!!this.bit(20)},set:function(t){this.setBit(20,t)}},{key:"sdf",get:function(){return!!this.bit(11)},set:function(t){this.setBit(11,t)}},{key:"pattern",get:function(){return!!this.bit(12)},set:function(t){this.setBit(12,t)}},{key:"textureBinding",get:function(){return this.bits(0,8)},set:function(t){this.setBits(t,0,8)}},{key:"geometryTypeString",get:function(){switch(this.geometryType){case c.LW.FILL:return"fill";case c.LW.MARKER:return"marker";case c.LW.LINE:return"line";case c.LW.TEXT:return"text";case c.LW.LABEL:return"label";default:throw new h.Z("Unable to handle unknown geometryType: ".concat(this.geometryType))}}},{key:"setBit",value:function(t,e){var i=1<<t;e?this._data|=i:this._data&=~i}},{key:"bit",value:function(t){return(this._data&1<<t)>>t}},{key:"setBits",value:function(t,e,i){for(var n=e,s=0;n<i;n++,s++)this.setBit(n,0!=(t&1<<s))}},{key:"bits",value:function(t,e){for(var i=0,n=t,s=0;n<e;n++,s++)i|=this.bit(n)<<s;return i}},{key:"hasVV",value:function(){return!1}},{key:"setVV",value:function(t,e){}},{key:"getVariation",value:function(){return{mapAligned:this.mapAligned,pattern:this.pattern,sdf:this.sdf}}},{key:"getVariationHash",value:function(){return this._data&~(7&this.textureBinding)}}],[{key:"load",value:function(t){var e=this.shared;return e.data=t,e}}]),t}();y.shared=new y(0);var p=function(t){return function(t){(0,a.Z)(i,t);var e=(0,u.Z)(i);function i(){return(0,o.Z)(this,i),e.apply(this,arguments)}return(0,l.Z)(i,[{key:"vvSizeMinMaxValue",get:function(){return 0!==this.bit(16)},set:function(t){this.setBit(16,t)}},{key:"vvSizeScaleStops",get:function(){return 0!==this.bit(17)},set:function(t){this.setBit(17,t)}},{key:"vvSizeFieldStops",get:function(){return 0!==this.bit(18)},set:function(t){this.setBit(18,t)}},{key:"vvSizeUnitValue",get:function(){return 0!==this.bit(19)},set:function(t){this.setBit(19,t)}},{key:"hasVV",value:function(){return(0,s.Z)((0,r.Z)(i.prototype),"hasVV",this).call(this)||this.vvSizeMinMaxValue||this.vvSizeScaleStops||this.vvSizeFieldStops||this.vvSizeUnitValue}},{key:"setVV",value:function(t,e){(0,s.Z)((0,r.Z)(i.prototype),"setVV",this).call(this,t,e);var n=function(t,e){var i=c.X.SIZE_FIELD_STOPS|c.X.SIZE_MINMAX_VALUE|c.X.SIZE_SCALE_STOPS|c.X.SIZE_UNIT_VALUE,n=(t&(c.mf.FIELD_TARGETS_OUTLINE|c.mf.MINMAX_TARGETS_OUTLINE|c.mf.SCALE_TARGETS_OUTLINE|c.mf.UNIT_TARGETS_OUTLINE))>>>4;return e.isOutline||e.isOutlinedFill?i&n:i&~n}(t,e)&t;this.vvSizeMinMaxValue=!!(n&c.X.SIZE_MINMAX_VALUE),this.vvSizeFieldStops=!!(n&c.X.SIZE_FIELD_STOPS),this.vvSizeUnitValue=!!(n&c.X.SIZE_UNIT_VALUE),this.vvSizeScaleStops=!!(n&c.X.SIZE_SCALE_STOPS)}}]),i}(t)},S=function(t){return function(t){(0,a.Z)(i,t);var e=(0,u.Z)(i);function i(){return(0,o.Z)(this,i),e.apply(this,arguments)}return(0,l.Z)(i,[{key:"vvRotation",get:function(){return 0!==this.bit(15)},set:function(t){this.setBit(15,t)}},{key:"hasVV",value:function(){return(0,s.Z)((0,r.Z)(i.prototype),"hasVV",this).call(this)||this.vvRotation}},{key:"setVV",value:function(t,e){(0,s.Z)((0,r.Z)(i.prototype),"setVV",this).call(this,t,e),this.vvRotation=!e.isOutline&&!!(t&c.X.ROTATION)}}]),i}(t)},Z=function(t){return function(t){(0,a.Z)(i,t);var e=(0,u.Z)(i);function i(){return(0,o.Z)(this,i),e.apply(this,arguments)}return(0,l.Z)(i,[{key:"vvColor",get:function(){return 0!==this.bit(13)},set:function(t){this.setBit(13,t)}},{key:"hasVV",value:function(){return(0,s.Z)((0,r.Z)(i.prototype),"hasVV",this).call(this)||this.vvColor}},{key:"setVV",value:function(t,e){(0,s.Z)((0,r.Z)(i.prototype),"setVV",this).call(this,t,e),this.vvColor=!e.isOutline&&!!(t&c.X.COLOR)}}]),i}(t)},_=function(t){return function(t){(0,a.Z)(i,t);var e=(0,u.Z)(i);function i(){return(0,o.Z)(this,i),e.apply(this,arguments)}return(0,l.Z)(i,[{key:"vvOpacity",get:function(){return 0!==this.bit(14)},set:function(t){this.setBit(14,t)}},{key:"hasVV",value:function(){return(0,s.Z)((0,r.Z)(i.prototype),"hasVV",this).call(this)||this.vvOpacity}},{key:"setVV",value:function(t,e){(0,s.Z)((0,r.Z)(i.prototype),"setVV",this).call(this,t,e),this.vvOpacity=!e.isOutline&&!!(t&c.X.OPACITY)}}]),i}(t)},V=function(t){(0,a.Z)(i,t);var e=(0,u.Z)(i);function i(){return(0,o.Z)(this,i),e.apply(this,arguments)}return(0,l.Z)(i,[{key:"getVariation",value:function(){return(0,n.Z)((0,n.Z)({},(0,s.Z)((0,r.Z)(i.prototype),"getVariation",this).call(this)),{},{dotDensity:this.dotDensity,outlinedFill:this.outlinedFill,simple:this.simple,vvColor:this.vvColor,vvOpacity:this.vvOpacity,vvSizeFieldStops:this.vvSizeFieldStops,vvSizeMinMaxValue:this.vvSizeMinMaxValue,vvSizeScaleStops:this.vvSizeScaleStops,vvSizeUnitValue:this.vvSizeUnitValue})}},{key:"dotDensity",get:function(){return!!this.bit(15)},set:function(t){this.setBit(15,t)}},{key:"simple",get:function(){return!!this.bit(22)},set:function(t){this.setBit(22,t)}},{key:"outlinedFill",get:function(){return!!this.bit(21)},set:function(t){this.setBit(21,t)}}],[{key:"load",value:function(t){var e=this.shared;return e.data=t,e}},{key:"from",value:function(t){var e=this.load(0);return e.geometryType=c.LW.FILL,e.dotDensity="dot-density"===t.stride.fill,e.simple="simple"===t.stride.fill,e.outlinedFill=t.isOutlinedFill,e.dotDensity||e.setVV(t.vvFlags,t),e.data}}]),i}(Z(_(p(y))));V.shared=new V(0);var g=function(t){(0,a.Z)(i,t);var e=(0,u.Z)(i);function i(){return(0,o.Z)(this,i),e.apply(this,arguments)}return(0,l.Z)(i,[{key:"getVariation",value:function(){return(0,n.Z)((0,n.Z)({},(0,s.Z)((0,r.Z)(i.prototype),"getVariation",this).call(this)),{},{vvColor:this.vvColor,vvRotation:this.vvRotation,vvOpacity:this.vvOpacity,vvSizeFieldStops:this.vvSizeFieldStops,vvSizeMinMaxValue:this.vvSizeMinMaxValue,vvSizeScaleStops:this.vvSizeScaleStops,vvSizeUnitValue:this.vvSizeUnitValue})}}],[{key:"load",value:function(t){var e=this.shared;return e.data=t,e}},{key:"from",value:function(t){var e=this.load(0);return e.geometryType=c.LW.MARKER,e.setVV(t.vvFlags,t),e.data}}]),i}(Z(_(S(p(y)))));g.shared=new g(0);var k=function(t){(0,a.Z)(i,t);var e=(0,u.Z)(i);function i(){return(0,o.Z)(this,i),e.apply(this,arguments)}return(0,l.Z)(i,[{key:"getVariation",value:function(){return(0,n.Z)((0,n.Z)({},(0,s.Z)((0,r.Z)(i.prototype),"getVariation",this).call(this)),{},{vvColor:this.vvColor,vvOpacity:this.vvOpacity,vvSizeFieldStops:this.vvSizeFieldStops,vvSizeMinMaxValue:this.vvSizeMinMaxValue,vvSizeScaleStops:this.vvSizeScaleStops,vvSizeUnitValue:this.vvSizeUnitValue})}}],[{key:"load",value:function(t){var e=this.shared;return e.data=t,e}},{key:"from",value:function(t){var e=this.load(0);return e.geometryType=c.LW.LINE,e.setVV(t.vvFlags,t),e.data}}]),i}(Z(_(p(y))));k.shared=new k(0);var m=function(t){(0,a.Z)(i,t);var e=(0,u.Z)(i);function i(){return(0,o.Z)(this,i),e.apply(this,arguments)}return(0,l.Z)(i,[{key:"getVariation",value:function(){return(0,n.Z)((0,n.Z)({},(0,s.Z)((0,r.Z)(i.prototype),"getVariation",this).call(this)),{},{vvColor:this.vvColor,vvOpacity:this.vvOpacity,vvRotation:this.vvRotation,vvSizeFieldStops:this.vvSizeFieldStops,vvSizeMinMaxValue:this.vvSizeMinMaxValue,vvSizeScaleStops:this.vvSizeScaleStops,vvSizeUnitValue:this.vvSizeUnitValue})}}],[{key:"load",value:function(t){var e=this.shared;return e.data=t,e}},{key:"from",value:function(t){var e=this.load(0);return e.geometryType=c.LW.TEXT,e.setVV(t.vvFlags,t),e.data}}]),i}(Z(_(S(p(y)))));m.shared=new m(0);var R=function(t){(0,a.Z)(i,t);var e=(0,u.Z)(i);function i(){return(0,o.Z)(this,i),e.apply(this,arguments)}return(0,l.Z)(i,[{key:"getVariation",value:function(){return(0,n.Z)((0,n.Z)({},(0,s.Z)((0,r.Z)(i.prototype),"getVariation",this).call(this)),{},{vvSizeFieldStops:this.vvSizeFieldStops,vvSizeMinMaxValue:this.vvSizeMinMaxValue,vvSizeScaleStops:this.vvSizeScaleStops,vvSizeUnitValue:this.vvSizeUnitValue})}}],[{key:"load",value:function(t){var e=this.shared;return e.data=t,e}},{key:"from",value:function(t){var e=this.load(0);return e.geometryType=c.LW.LABEL,e.setVV(t.vvFlags,t),e.mapAligned=(0,v.N)(t.placement),e.data}}]),i}(p(y));R.shared=new R(0)},49083:function(t,e,i){function n(t){switch(t){case"above-along":case"below-along":case"center-along":case"esriServerLinePlacementAboveAlong":case"esriServerLinePlacementBelowAlong":case"esriServerLinePlacementCenterAlong":return!0;default:return!1}}i.d(e,{N:function(){return n}})}}]);
//# sourceMappingURL=2922.c012226e.chunk.js.map