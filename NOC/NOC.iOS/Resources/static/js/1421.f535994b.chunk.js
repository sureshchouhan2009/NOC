"use strict";(self.webpackChunketihadrailapp=self.webpackChunketihadrailapp||[]).push([[1421],{41421:function(e,t,i){i.r(t),i.d(t,{default:function(){return ae}});var r=i(15671),s=i(43144),a=i(60136),n=i(29388),l=i(27366),o=i(66978),u=i(68860),c=i(8025),d=(i(63780),i(93169),i(25243),i(49861)),h=i(69912),m=i(27496),p=i(100),v=i(32718),_=i(92026),f=i(8537),y=i(77671),g=i(29439),w=i(15861),b=i(87757),k=(i(59486),i(52639)),C=(i(59166),i(51508),i(5163)),M=i(2170),Z=i(60176),L=i(15559),A=i(93655),S=i(65069),D=i(59968),O=i(74229),G=i(2346),T=i(45900),I=i(41201),V=i(36257),q=i(7882),x=i(61459),U=i(16851),W=i(58009),R=i(73268),j=i(16072),E=i(29909),z=i(78952),B=i(80885),N=1e5,H=function(e){(0,a.Z)(i,e);var t=(0,n.Z)(i);function i(){var e;return(0,r.Z)(this,i),(e=t.apply(this,arguments))._drawActive=!1,e._handles=new p.Z,e._graphicsLayer=new A.Z,e._manipulatorLayer=new A.Z,e._groupLayer=new S.default({layers:[e._graphicsLayer,e._manipulatorLayer],listMode:"hide",visible:!1}),e._vertices=[],e.geodesicDistanceThreshold=1e5,e.measurement=null,e.measurementLabel=null,e}return(0,s.Z)(i,[{key:"initialize",value:function(){var e=this;(0,I.ME)("esri/core/t9n/Units").then((function(t){e.messages=t})),this._handles.add((0,V.qe)((0,w.Z)(b.mark((function t(){return b.wrap((function(t){for(;;)switch(t.prev=t.next){case 0:return t.next=2,(0,I.ME)("esri/core/t9n/Units");case 2:e.messages=t.sent;case 3:case"end":return t.stop()}}),t)}))))),this.startToolCreation()}},{key:"destroy",value:function(){this._draw=(0,_.SC)(this._draw),this._handles=(0,_.SC)(this._handles),this._graphicsLayer=(0,_.SC)(this._graphicsLayer),this._manipulatorLayer=(0,_.SC)(this._manipulatorLayer)}},{key:"cursor",get:function(){return this._drawActive?"crosshair":null}},{key:"editable",set:function(e){this._set("editable",e),e||this._draw.reset()}},{key:"onActivate",value:function(){this._drawActive||0!==this._vertices.length||this._startSketch()}},{key:"onAttach",value:function(){var e=this,t=this.view;this._draw=new D.Z({view:t}),t.map.add(this._groupLayer),t.focus(),this._handles.add([(0,f.S1)(this,["unit","geodesicDistanceThreshold","palette","messages"],(function(){e._vertices.length>0&&e._updateGraphics()})),(0,f.S1)(this,"view.spatialReference",(function(e){J(e)&&!(0,Z.kR)()&&(0,Z.zD)()}))]),this.finishToolCreation()}},{key:"onDetach",value:function(){var e=this.view.map;this._draw.view=null,this._draw=(0,_.SC)(this._draw),e.remove(this._groupLayer),this._handles.removeAll(),this._graphicsLayer.removeAll(),this._manipulatorLayer.removeAll(),this._set("measurement",null),this._set("measurementLabel",null)}},{key:"onShow",value:function(){this._groupLayer.visible=!0}},{key:"onHide",value:function(){this._groupLayer.visible=!1}},{key:"reset",value:function(){this._vertices=[],this._graphicsLayer.removeAll(),this._set("measurement",null),this._set("measurementLabel",null),this._draw.reset(),this._drawActive=!1,this._updateSketch([])}},{key:"_startSketch",value:function(){var e=this;this._drawActive=!0;var t=this._draw.create("polyline",{mode:"click"});t.on(["vertex-add","vertex-update","vertex-remove","cursor-update","undo","redo"],(function(t){return e._updateSketch(t.vertices)})),t.on("draw-complete",(function(){return e._stopSketch()}))}},{key:"_stopSketch",value:function(){if(this._vertices.length<3)return this.reset(),void this._startSketch();this.manipulators.forEach((function(e){e.manipulator.interactive=!0})),this._drawActive=!1,this.complete()}},{key:"_updateSketch",value:function(e){var t=this;if(!J(this.view.spatialReference)||(0,Z.kR)()){if(e.length<2)return this._vertices=[],this.manipulators.removeAll(),void this._graphicsLayer.removeAll();this.finishToolCreation();for(var i=this.view.spatialReference;this._vertices.length>e.length;){var r=this._vertices.pop().manipulatorId;this.manipulators.remove(r)}for(var s=function(r){var s=(0,g.Z)(e[r],2),a=s[0],n=s[1],l=function(e,t,i,r){var s=new j.default({style:"circle",color:r.handleColor,size:r.handleWidth,outline:{type:"simple-line",width:0}}),a=new j.default({style:"circle",color:r.handleColor,size:1.5*r.handleWidth,outline:{type:"simple-line",width:0}}),n=new k.Z({geometry:e,symbol:s});return new G.L({view:t,layer:i,graphic:n,focusedSymbol:a})}(new q.Z({x:a,y:n,spatialReference:i}),t.view,t._manipulatorLayer,t.palette),o=t.manipulators.add(l);(0,O.Xd)(l,(function(e,i){i.next((0,O.Cf)(t.view)).next((0,O.a9)(e.graphic,2)).next((function(){var i=e.graphic.geometry;t._vertices[r].coord=[i.x,i.y],t._updateGraphics()}))})),t._vertices.push({manipulatorId:o,coord:[a,n]})},a=this._vertices.length;a<e.length;a++)s(a);var n=this._vertices.length-1,l=this._vertices[n],o=(0,g.Z)(e[n],2),u=o[0],c=o[1];if(l.coord[0]!==u||l.coord[1]!==c){l.coord=[u,c];var d=new q.Z({x:u,y:c,spatialReference:i});this.manipulators.findById(l.manipulatorId).graphic.geometry=d}var h=this._drawActive?this._vertices[n].manipulatorId:null;this.manipulators.forEach((function(e){e.manipulator.interactive=null==h||e.id!==h})),this._updateGraphics()}}},{key:"_updateGraphics",value:function(){var e=function(e,t,i){if(2===e.length){var r,s=new E.Z({paths:e,spatialReference:t});if(t.isGeographic)if((0,L.Gb)(t))r=(0,L.j2)(s,N);else{var a=(0,Z.iV)(s,z.Z.WGS84),n=(0,L.j2)(a,N);r=(0,Z.iV)(n,t)}else if(t.isWebMercator)r=(0,M.geodesicDensify)(s,N,"meters");else if((0,M.planarLength)(s,"meters")>=i){var l=(0,Z.iV)(s,z.Z.WGS84),o=(0,L.j2)(l,N);r=(0,Z.iV)(o,t)}else r=s;return{measurement:null,fillGeometry:null,outlineGeometry:r}}e.push(e[0]);var u,c,d=new E.Z({paths:[e],spatialReference:t}),h=new B.Z({rings:[e],spatialReference:t}),m=null,p=null;if(t.isGeographic)if((0,L.Gb)(t)){if(m=(0,L.j2)(d,N),p=(0,L.j2)(h,N),!(p=(0,M.simplify)(p)))return null;u=(0,L.Jf)([d],"meters")[0],c=(0,L.p8)([p],"square-meters")[0]}else{var v=z.Z.WGS84,_=(0,Z.iV)(d,v),f=(0,Z.iV)(h,v);if(m=(0,L.j2)(_,N),p=(0,L.j2)(f,N),!(p=(0,M.simplify)(p)))return null;u=(0,L.Jf)([_],"meters")[0],c=(0,L.p8)([p],"square-meters")[0],m=(0,Z.iV)(m,t),p=(0,Z.iV)(p,t)}else if(t.isWebMercator){if(m=(0,M.geodesicDensify)(d,N,"meters"),p=(0,M.geodesicDensify)(h,N,"meters"),!(p=(0,M.simplify)(p)))return null;u=(0,M.geodesicLength)(d,"meters"),c=(0,M.geodesicArea)(p,"square-meters")}else{var y=(0,M.planarLength)(d,"meters");if(y>=i){var g=z.Z.WGS84,w=(0,Z.iV)(d,g),b=(0,Z.iV)(h,g);if(m=(0,L.j2)(w,N),p=(0,L.j2)(b,N),!(p=(0,M.simplify)(p)))return null;u=(0,L.Jf)([w],"meters")[0],c=(0,L.p8)([p],"square-meters")[0],m=(0,Z.iV)(m,t),p=(0,Z.iV)(p,t)}else{if(m=d,!(p=(0,M.simplify)(h)))return null;u=y,c=(0,M.planarArea)(p,"square-meters")}}return{measurement:{geometry:p,area:c,perimeter:u},fillGeometry:p,outlineGeometry:m}}(this._vertices.map((function(e){return e.coord})),this.view.spatialReference,this.geodesicDistanceThreshold);if(e){var t=e.measurement,i=e.fillGeometry,r=e.outlineGeometry;this._set("measurement",t);var s=t?function(e,t,i){if(!t||!e)return null;var r={area:null,perimeter:null},s=t.area,a=t.perimeter;switch(i){case"metric":r.area=(0,C.ld)(e,s,"square-meters");break;case"imperial":r.area=(0,C.yc)(e,s,"square-meters");break;default:var n=(0,u.En)(s,"square-meters",i);r.area=(0,C.VG)(e,n,i)}var l=function(e){switch(e){case"metric":case"ares":case"hectares":return"metric";case"imperial":case"acres":return"imperial";case"square-inches":return"inches";case"square-feet":return"feet";case"square-yards":return"yards";case"square-miles":return"miles";case"square-us-feet":return"us-feet";case"square-meters":return"meters";case"square-kilometers":return"kilometers";case"square-millimeters":return"millimeters";case"square-centimeters":return"centimeters";case"square-decimeters":return"decimeters";default:return null}}(i);if(l)switch(l){case"metric":r.perimeter=(0,C.Rd)(e,a,"meters");break;case"imperial":r.perimeter=(0,C.Ud)(e,a,"meters");break;default:var o=(0,u.En)(a,"meters",l);r.perimeter=(0,C.VG)(e,o,l)}else r.perimeter="";return r}(this.messages,t,this.unit):null;if(this._set("measurementLabel",s),i||r){var a,n,l,o=this._graphicsLayer.graphics;if(3===o.length)a=o.getItemAt(0),n=o.getItemAt(1),l=o.getItemAt(2);else{var c=this.palette,d=c.fillColor,h=c.pathColor,m=c.pathWidth;a=new k.Z({symbol:new x.default({color:d,outline:null})}),n=new k.Z({symbol:new U.default({color:h,width:m})}),l=new k.Z({symbol:new W.Z({color:[255,255,255,1],font:new R.Z({size:14,family:"sans-serif"}),haloColor:[0,0,0,.5],haloSize:2})}),o.removeAll(),o.addMany([a,n,l])}a.geometry=i,n.geometry=r,l.geometry=null==i?void 0:i.centroid,l.symbol.text=null==s?void 0:s.area}}}}]),i}(T.m);function J(e){if(!e)return!1;var t=e.isGeographic,i=e.isWebMercator,r=e.isWGS84;return t&&!r&&!(0,L.Gb)(e)||!t&&!i}(0,l._)([(0,d.Cb)()],H.prototype,"_drawActive",void 0),(0,l._)([(0,d.Cb)()],H.prototype,"cursor",null),(0,l._)([(0,d.Cb)({value:!0})],H.prototype,"editable",null),(0,l._)([(0,d.Cb)({type:Number})],H.prototype,"geodesicDistanceThreshold",void 0),(0,l._)([(0,d.Cb)({readOnly:!0})],H.prototype,"measurement",void 0),(0,l._)([(0,d.Cb)({readOnly:!0})],H.prototype,"measurementLabel",void 0),(0,l._)([(0,d.Cb)()],H.prototype,"messages",void 0),(0,l._)([(0,d.Cb)()],H.prototype,"palette",void 0),(0,l._)([(0,d.Cb)()],H.prototype,"unit",void 0),(0,l._)([(0,d.Cb)({constructOnly:!0})],H.prototype,"view",void 0);var P=H=(0,l._)([(0,h.j)("esri.widgets.AreaMeasurement2D.AreaMeasurement2DTool")],H),X=i(32845),Y={handleWidth:8,handleColor:[255,128,0,.5],pathWidth:2,pathColor:[255,128,0,1],fillColor:[255,128,0,.3]},F=v.Z.getLogger("esri.widgets.AreaMeasurement2D.AreaMeasurement2DViewModel"),K=function(e){(0,a.Z)(i,e);var t=(0,n.Z)(i);function i(e){var s;return(0,r.Z)(this,i),(s=t.call(this,e)).logger=F,s.supportedViewType="2d",s.unsupportedErrorMessage="AreaMeasurement2DViewModel is only supported in 2D views.",s._handles=new p.Z,s.geodesicDistanceThreshold=1e5,s.measurement=null,s.measurementLabel=null,s.palette=Y,s}return(0,s.Z)(i,[{key:"initialize",value:function(){var e=this;this._handles.add([(0,f.S1)(this,["unit","palette","geodesicDistanceThreshold"],(function(t,i,r){e.tool&&(e.tool[r]=t)}))])}},{key:"destroy",value:function(){this._handles&&(this._handles.destroy(),this._handles=null)}},{key:"state",get:function(){return this.disabled||(0,_.Wi)(this.view)||null==this.view.spatialReference?"disabled":(0,_.pC)(this.tool)&&this.tool.measurement?this.tool.active?"measuring":"measured":"ready"}},{key:"unit",get:function(){return this._validateUnit(this.defaultUnit)},set:function(e){void 0!==e?this._override("unit",this._validateUnit(e)):this._clearOverride("unit")}},{key:"unitOptions",get:function(){return u.fN},set:function(e){void 0!==e?this._override("unitOptions",this._validateUnits(e)):this._clearOverride("unitOptions")}},{key:"start",value:function(){return this.createTool()}},{key:"clear",value:function(){this.removeTool()}},{key:"createToolParams",value:function(){var e=this;return{toolConstructor:P,constructorArguments:function(){return{geodesicDistanceThreshold:e.geodesicDistanceThreshold,palette:e.palette,unit:e.unit}}}}},{key:"_validateUnit",value:function(e){return-1!==this.unitOptions.indexOf(e)?e:-1!==this.unitOptions.indexOf(this.defaultUnit)?this.defaultUnit:this.unitOptions[0]}},{key:"_validateUnits",value:function(){var e=arguments.length>0&&void 0!==arguments[0]?arguments[0]:[],t=e.filter((function(e){return-1!==u.fN.indexOf(e)}));return 0===t.length?u.fN.slice():t}}]),i}(X.V);(0,l._)([(0,d.Cb)(y.Y)],K.prototype,"defaultUnit",void 0),(0,l._)([(0,d.Cb)({type:Number})],K.prototype,"geodesicDistanceThreshold",void 0),(0,l._)([(0,d.Cb)({readOnly:!0,aliasOf:"tool.measurement"})],K.prototype,"measurement",void 0),(0,l._)([(0,d.Cb)({readOnly:!0,aliasOf:"tool.measurementLabel"})],K.prototype,"measurementLabel",void 0),(0,l._)([(0,d.Cb)()],K.prototype,"palette",void 0),(0,l._)([(0,d.Cb)({readOnly:!0})],K.prototype,"state",null),(0,l._)([(0,d.Cb)({type:String})],K.prototype,"unit",null),(0,l._)([(0,d.Cb)({type:[String]})],K.prototype,"unitOptions",null);var Q=K=(0,l._)([(0,h.j)("esri.widgets.AreaMeasurement2D.AreaMeasurement2DViewModel")],K),$=i(78088),ee=i(80532),te=i(67005),ie=(i(80975),"esri-area-measurement-2d"),re={buttonDisabled:"esri-button--disabled",widgetIcon:"esri-icon-measure-area",base:"".concat(ie," esri-widget esri-widget--panel"),container:"".concat(ie,"__container"),hint:"".concat(ie,"__hint"),hintText:"".concat(ie,"__hint-text"),panelError:"".concat(ie,"__panel--error"),measurement:"".concat(ie,"__measurement"),measurementItem:"".concat(ie,"__measurement-item"),measurementItemDisabled:"".concat(ie,"__measurement-item--disabled"),measurementItemTitle:"".concat(ie,"__measurement-item-title"),measurementItemValue:"".concat(ie,"__measurement-item-value"),settings:"".concat(ie,"__settings"),units:"".concat(ie,"__units"),unitsLabel:"".concat(ie,"__units-label"),unitsSelect:"".concat(ie,"__units-select esri-select"),unitsSelectWrapper:"".concat(ie,"__units-select-wrapper"),actionSection:"".concat(ie,"__actions"),newMeasurementButton:"".concat(ie,"__clear-button esri-button esri-button--primary")},se=function(e){(0,a.Z)(i,e);var t=(0,n.Z)(i);function i(e,s){var a;return(0,r.Z)(this,i),(a=t.call(this,e,s)).active=null,a.iconClass=re.widgetIcon,a.label=void 0,a.messages=null,a.messagesUnits=null,a.unit=null,a.unitOptions=null,a.view=null,a.viewModel=new Q,a}return(0,s.Z)(i,[{key:"render",value:function(){var e=this,t=this.id,i=this.viewModel,r=this.visible,s=i.active,a=i.supported,n=i.measurementLabel,l=i.state,o=i.unit,c=i.unitOptions,d="disabled"===l,h="ready"===l,m="measuring"===l||"measured"===l,p=this.messages,v=this.messagesUnits,_=s&&h?(0,te.u)("section",{key:"hint",class:re.hint},(0,te.u)("p",{class:re.hintText},p.hint)):null,f=a?null:(0,te.u)("section",{key:"unsupported",class:re.panelError},(0,te.u)("p",null,p.unsupported)),y=function(t,i,r){return i?(0,te.u)("div",{key:"".concat(r,"-enabled"),class:re.measurementItem},(0,te.u)("span",{class:re.measurementItemTitle},t),(0,te.u)("span",{class:re.measurementItemValue},i)):(0,te.u)("div",{key:"".concat(r,"-disabled"),class:e.classes(re.measurementItem,re.measurementItemDisabled),"aria-disabled":"true"},(0,te.u)("span",{class:re.measurementItemTitle},t))},g=m?(0,te.u)("section",{key:"measurement",class:re.measurement},y(p.area,n.area,"area"),y(p.perimeter,n.perimeter,"perimeter")):null,w="".concat(t,"__units"),b=(0,te.u)("section",{key:"units",class:re.units},(0,te.u)("label",{class:re.unitsLabel,for:w},p.unit),(0,te.u)("div",{class:re.unitsSelectWrapper},(0,te.u)("select",{class:re.unitsSelect,id:w,onchange:this._changeUnit,bind:this,value:o},c.map((function(e){var t;return(0,te.u)("option",{key:e,value:e},(0,u.ZO)(e)?v.systems[e]:null==(t=v.units[e])?void 0:t.pluralCapitalized)}))))),k=m?(0,te.u)("div",{key:"settings",class:re.settings},b):null,C=!a||s&&!m?null:(0,te.u)("div",{class:re.actionSection},(0,te.u)("button",{disabled:d,class:this.classes(re.newMeasurementButton,d&&re.buttonDisabled),bind:this,onclick:this._newMeasurement,title:p.newMeasurement,type:"button","aria-label":p.newMeasurement},p.newMeasurement)),M=r?(0,te.u)("div",{class:re.container},f,_,k,g,C):null;return(0,te.u)("div",{class:re.base},M)}},{key:"_newMeasurement",value:function(){(0,o.R8)(this.viewModel.start())}},{key:"_changeUnit",value:function(e){var t=e.target,i=t.options[t.selectedIndex];i&&(this.viewModel.unit=i.value)}}]),i}(m.Z);(0,l._)([(0,c.B)("viewModel.active")],se.prototype,"active",void 0),(0,l._)([(0,d.Cb)()],se.prototype,"iconClass",void 0),(0,l._)([(0,d.Cb)({aliasOf:{source:"messages.widgetLabel",overridable:!0}})],se.prototype,"label",void 0),(0,l._)([(0,d.Cb)(),(0,ee.H)("esri/widgets/AreaMeasurement2D/t9n/AreaMeasurement2D")],se.prototype,"messages",void 0),(0,l._)([(0,d.Cb)(),(0,ee.H)("esri/core/t9n/Units")],se.prototype,"messagesUnits",void 0),(0,l._)([(0,d.Cb)()],se.prototype,"uiStrings",void 0),(0,l._)([(0,c.B)("viewModel.unit")],se.prototype,"unit",void 0),(0,l._)([(0,c.B)("viewModel.unitOptions")],se.prototype,"unitOptions",void 0),(0,l._)([(0,c.B)("viewModel.view")],se.prototype,"view",void 0),(0,l._)([(0,d.Cb)({type:Q})],se.prototype,"viewModel",void 0),(0,l._)([(0,c.B)("viewModel.visible")],se.prototype,"visible",void 0),(0,l._)([(0,$.h)()],se.prototype,"_newMeasurement",null),(0,l._)([(0,$.h)()],se.prototype,"_changeUnit",null);var ae=se=(0,l._)([(0,h.j)("esri.widgets.AreaMeasurement2D")],se)}}]);
//# sourceMappingURL=1421.f535994b.chunk.js.map