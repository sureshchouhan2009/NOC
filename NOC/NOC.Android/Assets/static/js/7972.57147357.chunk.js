"use strict";(self.webpackChunketihadrailapp=self.webpackChunketihadrailapp||[]).push([[7972],{87972:function(e,t,r){r.r(t),r.d(t,{default:function(){return ot}});var n=r(15861),a=r(1413),i=r(15671),s=r(43144),o=r(60136),l=r(29388),u=r(87757),c=r(27366),p=r(43404),f=r(49861),y=(r(63780),r(93169),r(25243),r(69912)),d=r(93433),m=r(37762),b=r(42265),h=r(19545),g=r(76200),x=r(10064),v=r(92026),w=r(17842),k=r(35995),S=r(80885),D=r(37270),I=r(56011),L=r(85216),T=r(11741),V=new p.Xn({PDF:"pdf",PNG32:"png32",PNG8:"png8",JPG:"jpg",GIF:"gif",EPS:"eps",SVG:"svg",SVGZ:"svgz"}),P=(V.fromJSON.bind(V),V.toJSON.bind(V)),M=new p.Xn({MAP_ONLY:"map-only","A3 Landscape":"a3-landscape","A3 Portrait":"a3-portrait","A4 Landscape":"a4-landscape","A4 Portrait":"a4-portrait","Letter ANSI A Landscape":"letter-ansi-a-landscape","Letter ANSI A Portrait":"letter-ansi-a-portrait","Tabloid ANSI B Landscape":"tabloid-ansi-b-landscape","Tabloid ANSI B Portrait":"tabloid-ansi-b-portrait"}),O=(M.fromJSON.bind(M),M.toJSON.bind(M)),E="simple-marker",Z="simple-line";function F(e,t){var r=t.graphic,n=t.renderer,a=t.symbol,i=a.type;if("text"!==i&&"shield-label-symbol"!==i&&"visualVariables"in n&&n.visualVariables){var s=n.getVisualVariablesForType("size"),o=n.getVisualVariablesForType("color"),l=n.getVisualVariablesForType("opacity"),u=n.getVisualVariablesForType("rotation"),c=s[0],p=o[0],f=l[0],y=u[0];if(c){var d=i===E?a.style:null,m=(0,I.getSize)(c,r,{shape:d});null!=m&&(i===E?e.size=(0,w.Wz)(m):"picture-marker"===i?(e.width=(0,w.Wz)(m),e.height=(0,w.Wz)(m)):i===Z?e.width=(0,w.Wz)(m):e.outline&&(e.outline.width=(0,w.Wz)(m)))}if(p){var b=(0,I.getColor)(p,r);(b&&i===E||i===Z||"simple-fill"===i)&&(e.color=b?b.toJSON():void 0)}if(f){var h=(0,I.getOpacity)(f,r);null!=h&&e.color&&(e.color[3]=Math.round(255*h))}y&&(e.angle=-(0,I.getRotationAngle)(n,r))}}function C(e){var t,r,n,a,i,s,o=arguments.length>1&&void 0!==arguments[1]?arguments[1]:15,l=e.canvas.width,u=e.canvas.height,c=e.getImageData(0,0,l,u).data;e:for(r=u;r--;)for(t=l;t--;)if(c[4*(l*r+t)+3]>o){s=r;break e}if(!s)return null;e:for(t=l;t--;)for(r=s+1;r--;)if(c[4*(l*r+t)+3]>o){i=t;break e}e:for(t=0;t<=i;++t)for(r=s+1;r--;)if(c[4*(l*r+t)+3]>o){n=t;break e}e:for(r=0;r<=s;++r)for(t=n;t<=i;++t)if(c[4*(l*r+t)+3]>o){a=r;break e}return{x:n,y:a,width:i-n,height:s-a}}function A(e,t){var r=e.allLayerViews.items;if(t===e.scale)return r.filter((function(e){return!e.suspended}));var n,a=new Array,i=(0,m.Z)(r);try{for(i.s();!(n=i.n()).done;){var s=n.value;W(s.parent)&&!a.includes(s.parent)||!s.visible||t&&"isVisibleAtScale"in s&&!s.isVisibleAtScale(t)||a.push(s)}}catch(o){i.e(o)}finally{i.f()}return a}function N(e){return e&&"bing-maps"===e.type}function J(e){return e&&"blendMode"in e&&"effect"in e}function _(e){return e&&"csv"===e.type}function R(e){return e&&"feature"===e.type}function z(e){return e&&"geojson"===e.type}function G(e){return e&&"graphics"===e.type}function U(e){return e&&"group"===e.type}function W(e){return e&&"esri.views.2d.layers.GroupLayerView2D"===e.declaredClass}function K(e){return e&&"imagery"===e.type}function j(e){return e&&"imagery-tile"===e.type}function q(e){return e&&"kml"===e.type}function B(e){return e&&"map-image"===e.type}function X(e){return e&&"map-notes"===e.type}function Q(e){return e&&"open-street-map"===e.type}function H(e){var t=e.layer;if(J(t)){var r=t.blendMode;if((!r||"normal"===r)&&(t.effect||"featureEffect"in e&&e.featureEffect))return!0}return!1}function Y(e){return e&&"stream"===e.type}function $(e){return e&&"tile"===e.type}function ee(e){return e&&"vector-tile"===e.type}function te(e){return e&&"web-tile"===e.type}function re(e){return e&&"wms"===e.type}function ne(e){return e&&"wmts"===e.type}var ae=function(e){(0,o.Z)(r,e);var t=(0,l.Z)(r);function r(e){var n;return(0,i.Z)(this,r),(n=t.call(this,e)).attributionVisible=!0,n.exportOptions={width:800,height:1100,dpi:96},n.forceFeatureAttributes=!1,n.format="png32",n.label=null,n.layout="map-only",n.layoutOptions=null,n.outScale=0,n.scalePreserved=!0,n.showLabels=!0,n}return(0,s.Z)(r)}(r(85015).Z);(0,c._)([(0,f.Cb)()],ae.prototype,"attributionVisible",void 0),(0,c._)([(0,f.Cb)()],ae.prototype,"exportOptions",void 0),(0,c._)([(0,f.Cb)()],ae.prototype,"forceFeatureAttributes",void 0),(0,c._)([(0,f.Cb)()],ae.prototype,"format",void 0),(0,c._)([(0,f.Cb)()],ae.prototype,"label",void 0),(0,c._)([(0,f.Cb)()],ae.prototype,"layout",void 0),(0,c._)([(0,f.Cb)()],ae.prototype,"layoutOptions",void 0),(0,c._)([(0,f.Cb)()],ae.prototype,"outScale",void 0),(0,c._)([(0,f.Cb)()],ae.prototype,"scalePreserved",void 0),(0,c._)([(0,f.Cb)()],ae.prototype,"showLabels",void 0);var ie=ae=(0,c._)([(0,y.j)("esri.rest.support.PrintTemplate")],ae),se=r(66660),oe=r(10141),le={Feet:"ft",Kilometers:"km",Meters:"m",Miles:"mi"},ue=new p.Xn({esriFeet:"Feet",esriKilometers:"Kilometers",esriMeters:"Meters",esriMiles:"Miles"}),ce=new p.Xn({esriExecutionTypeSynchronous:"sync",esriExecutionTypeAsynchronous:"async"}),pe=new Map;function fe(){return fe=(0,n.Z)(u.mark((function e(t,r,n){var a,i;return u.wrap((function(e){for(;;)switch(e.prev=e.next){case 0:return a=he(t),i=pe.get(a),e.abrupt("return",Promise.resolve().then((function(){return i?{data:i.gpMetadata}:(i={gpServerUrl:a,is11xService:!1,legendLayerNameMap:{},legendLayers:[]},(0,g.default)(a,{query:{f:"json"}}))})).then((function(e){return i.gpMetadata=e.data,i.cimVersion=i.gpMetadata.cimVersion,i.is11xService=!!i.cimVersion,pe.set(a,i),ye(r,i)})).then((function(e){var a,s=rt(i),o=function(e){return"sync"===s?e.results&&e.results[0]&&e.results[0].value:a.fetchResultData("Output_File",null,n).then((function(e){return e.value}))};return"async"===s?(0,T.p)(t,e,null,n).then((function(e){return a=e,e.waitForJobCompletion({interval:r.updateDelay}).then(o)})):(0,L.h)(t,e,null,n).then(o)})));case 3:case"end":return e.stop()}}),e)}))),fe.apply(this,arguments)}function ye(e,t){return de.apply(this,arguments)}function de(){return de=(0,n.Z)(u.mark((function e(t,r){var n,a,i,s,o,l,c,p,f,y,d,m,b,h,g,v,w;return u.wrap((function(e){for(;;)switch(e.prev=e.next){case 0:return r=r||{is11xService:!1,legendLayerNameMap:{},legendLayers:[]},null==(n=t.template||new ie).showLabels&&(n.showLabels=!0),a=n.exportOptions,s=O(n.layout),a&&(i={dpi:a.dpi},("map_only"===s.toLowerCase()||""===s)&&(o=a.width,l=a.height,i.outputSize=[o,l])),(c=n.layoutOptions)&&("Miles"===c.scalebarUnit||"Kilometers"===c.scalebarUnit?(f="Kilometers",y="Miles"):"Meters"!==c.scalebarUnit&&"Feet"!==c.scalebarUnit||(f="Meters",y="Feet"),p={titleText:c.titleText,authorText:c.authorText,copyrightText:c.copyrightText,customTextElements:c.customTextElements,scaleBarOptions:{metricUnit:ue.toJSON(f),metricLabel:le[f],nonMetricUnit:ue.toJSON(y),nonMetricLabel:le[y]}}),d=null,null!=c&&c.legendLayers&&(d=c.legendLayers.map((function(e){r.legendLayerNameMap[e.layerId]=e.title;var t={id:e.layerId};return e.subLayerIds&&(t.subLayerIds=e.subLayerIds),t}))),e.next=12,me(t,n,r);case 12:return(m=e.sent).operationalLayers&&(b=new RegExp("[\\u4E00-\\u9FFF\\u0E00-\\u0E7F\\u0900-\\u097F\\u3040-\\u309F\\u30A0-\\u30FF\\u31F0-\\u31FF]"),h=/[\u0600-\u06FF]/,g=function(e){var t=e.text,r=e.font,n=r&&r.family&&r.family.toLowerCase();t&&r&&("arial"===n||"arial unicode ms"===n)&&(r.family=b.test(t)?"Arial Unicode MS":"Arial","normal"!==r.style&&h.test(t)&&(r.family="Arial Unicode MS"))},v=function(){throw new x.Z("print-task:cim-symbol-unsupported","CIMSymbol is not supported by a print service published from ArcMap")},m.operationalLayers.forEach((function(e){var t,n,a;null!=(t=e.featureCollection)&&t.layers?e.featureCollection.layers.forEach((function(e){var t,n,a,i;if(null!=(t=e.layerDefinition)&&null!=(n=t.drawingInfo)&&null!=(a=n.renderer)&&a.symbol){var s=e.layerDefinition.drawingInfo.renderer;"esriTS"===s.symbol.type?g(s.symbol):"CIMSymbolReference"!==s.symbol.type||r.is11xService||v()}null!=(i=e.featureSet)&&i.features&&e.featureSet.features.forEach((function(e){e.symbol&&("esriTS"===e.symbol.type?g(e.symbol):"CIMSymbolReference"!==e.symbol.type||r.is11xService||v())}))})):!r.is11xService&&null!=(n=e.layerDefinition)&&null!=(a=n.drawingInfo)&&a.renderer&&JSON.stringify(e.layerDefinition.drawingInfo.renderer).includes('"type":"CIMSymbolReference"')&&v()}))),t.outSpatialReference&&(m.mapOptions.spatialReference=t.outSpatialReference.toJSON()),Object.assign(m,{exportOptions:i,layoutOptions:p||{}}),Object.assign(m.layoutOptions,{legendOptions:{operationalLayers:null!=d?d:r.legendLayers.slice()}}),r.legendLayers.length=0,pe.set(r.gpServerUrl,r),w={Web_Map_as_JSON:JSON.stringify(m),Format:P(n.format),Layout_Template:s},e.abrupt("return",(t.extraParameters&&Object.assign(w,t.extraParameters),w));case 17:case"end":return e.stop()}}),e)}))),de.apply(this,arguments)}function me(e,t,r){return be.apply(this,arguments)}function be(){return be=(0,n.Z)(u.mark((function e(t,r,n){var a,i,s,o,l,c;return u.wrap((function(e){for(;;)switch(e.prev=e.next){case 0:return a=t.view,i=a.spatialReference,e.next=4,ge(a,r,n);case 4:return e.t0=e.sent,s={operationalLayers:e.t0},o=n.ssExtent||t.extent||a.extent,i&&i.isWrappable&&(o=o.clone()._normalize(!0),i=o.spatialReference),s.mapOptions={extent:o&&o.toJSON(),spatialReference:i&&i.toJSON(),showAttribution:r.attributionVisible},n.ssExtent=null,a.background&&(s.background=a.background.toJSON()),a.rotation&&(s.mapOptions.rotation=-a.rotation),r.scalePreserved&&(s.mapOptions.scale=r.outScale||a.scale),(0,v.pC)(a.timeExtent)&&(l=(0,v.pC)(a.timeExtent.start)?a.timeExtent.start.getTime():null,c=(0,v.pC)(a.timeExtent.end)?a.timeExtent.end.getTime():null,s.mapOptions.time=[l,c]),e.abrupt("return",s);case 9:case"end":return e.stop()}}),e)}))),be.apply(this,arguments)}function he(e){var t=e,r=t.lastIndexOf("/GPServer/");return r>0&&(t=t.slice(0,r+9)),t}function ge(e,t,r){return xe.apply(this,arguments)}function xe(){return xe=(0,n.Z)(u.mark((function e(t,r,n){var a,i,s,o,l,c,p,f,y,b;return u.wrap((function(e){for(;;)switch(e.prev=e.next){case 0:a=[],i={layerView:null,printTemplate:r,view:t},s=0,r.scalePreserved&&(s=r.outScale||t.scale),o=A(t,s),l=(0,m.Z)(o),e.prev=5,l.s();case 7:if((c=l.n()).done){e.next=128;break}if(p=c.value,(f=p.layer).loaded&&!U(f)){e.next=12;break}return e.abrupt("continue",126);case 12:if(y=void 0,i.layerView=p,!H(p)){e.next=20;break}return e.next=17,Je(f,i,n);case 17:e.t0=e.sent,e.next=124;break;case 20:if(!N(f)){e.next=24;break}e.t1=ve(f),e.next=123;break;case 24:if(!_(f)){e.next=30;break}return e.next=27,we(f,i,n);case 27:e.t2=e.sent,e.next=122;break;case 30:if(!R(f)){e.next=36;break}return e.next=33,Ie(f,i,n);case 33:e.t3=e.sent,e.next=121;break;case 36:if(!z(f)){e.next=42;break}return e.next=39,Te(f,i,n);case 39:e.t4=e.sent,e.next=120;break;case 42:if(!G(f)){e.next=48;break}return e.next=45,Pe(f,i,n);case 45:e.t5=e.sent,e.next=119;break;case 48:if(!K(f)){e.next=52;break}e.t6=Oe(f,n),e.next=118;break;case 52:if(!j(f)){e.next=56;break}e.t7=Ee(f,n),e.next=117;break;case 56:if(!q(f)){e.next=62;break}return e.next=59,Ze(f,i,n);case 59:e.t8=e.sent,e.next=116;break;case 62:if(!B(f)){e.next=66;break}e.t9=Ce(f,i,n),e.next=115;break;case 66:if(!X(f)){e.next=72;break}return e.next=69,Ae(i,n);case 69:e.t10=e.sent,e.next=114;break;case 72:if(!Q(f)){e.next=76;break}e.t11={type:"OpenStreetMap"},e.next=113;break;case 76:if(!Y(f)){e.next=82;break}return e.next=79,Re(f,i,n);case 79:e.t12=e.sent,e.next=112;break;case 82:if(!$(f)){e.next=86;break}e.t13=Ge(f),e.next=111;break;case 86:if(!ee(f)){e.next=92;break}return e.next=89,Ue(f,i,n);case 89:e.t14=e.sent,e.next=110;break;case 92:if(!te(f)){e.next=96;break}e.t15=Ke(f),e.next=109;break;case 96:if(!re(f)){e.next=100;break}e.t16=je(f),e.next=108;break;case 100:if(!ne(f)){e.next=104;break}e.t17=qe(f),e.next=107;break;case 104:return e.next=106,Je(f,i,n);case 106:e.t17=e.sent;case 107:e.t16=e.t17;case 108:e.t15=e.t16;case 109:e.t14=e.t15;case 110:e.t13=e.t14;case 111:e.t12=e.t13;case 112:e.t11=e.t12;case 113:e.t10=e.t11;case 114:e.t9=e.t10;case 115:e.t8=e.t9;case 116:e.t7=e.t8;case 117:e.t6=e.t7;case 118:e.t5=e.t6;case 119:e.t4=e.t5;case 120:e.t3=e.t4;case 121:e.t2=e.t3;case 122:e.t1=e.t2;case 123:e.t0=e.t1;case 124:(y=e.t0)&&(Array.isArray(y)?a.push.apply(a,(0,d.Z)(y)):(y.id=f.id,y.title=n.legendLayerNameMap[f.id]||f.title,y.opacity=f.opacity,y.minScale=f.minScale||0,y.maxScale=f.maxScale||0,J(f)&&f.blendMode&&"normal"!==f.blendMode&&(y.blendMode=f.blendMode),a.push(y)));case 126:e.next=7;break;case 128:e.next=133;break;case 130:e.prev=130,e.t18=e.catch(5),l.e(e.t18);case 133:return e.prev=133,l.f(),e.finish(133);case 136:if(s&&a.forEach((function(e){e.minScale=0,e.maxScale=0})),!t.graphics||!t.graphics.length){e.next=141;break}return e.next=139,Se(null,t.graphics,r,n);case 139:(b=e.sent)&&a.push(b);case 141:return e.abrupt("return",a);case 142:case"end":return e.stop()}}),e,null,[[5,130,133,136]])}))),xe.apply(this,arguments)}function ve(e){return{culture:e.culture,key:e.key,type:"BingMaps"+("aerial"===e.style?"Aerial":"hybrid"===e.style?"Hybrid":"Road")}}function we(e,t,r){return ke.apply(this,arguments)}function ke(){return ke=(0,n.Z)(u.mark((function e(t,r,n){var a,i,s;return u.wrap((function(e){for(;;)switch(e.prev=e.next){case 0:if(t.legendEnabled&&n.legendLayers.push({id:t.id}),a=r.layerView,i=r.printTemplate,n.is11xService&&!a.filter){e.next=11;break}return e.t0=Se,e.t1=t,e.next=7,et(a);case 7:return e.t2=e.sent,e.t3=i,e.t4=n,e.abrupt("return",(0,e.t0)(e.t1,e.t2,e.t3,e.t4));case 11:return e.abrupt("return",(s={type:"CSV"},t.write(s,{origin:"web-map"}),delete s.popupInfo,delete s.layerType,s.showLabels=i.showLabels&&t.labelsVisible,s));case 12:case"end":return e.stop()}}),e)}))),ke.apply(this,arguments)}function Se(e,t,r,n){return De.apply(this,arguments)}function De(){return De=(0,n.Z)(u.mark((function e(t,r,n,a){var i,s,o,l,c,p,f,y,d,b,h,g,x,v,w,k,I,L,T,V,P,M,O,E,Z,C,A,N;return u.wrap((function(e){for(;;)switch(e.prev=e.next){case 0:if(s={layerDefinition:{name:"polygonLayer",geometryType:"esriGeometryPolygon",drawingInfo:{renderer:null}},featureSet:{geometryType:"esriGeometryPolygon",features:[]}},o={layerDefinition:{name:"polylineLayer",geometryType:"esriGeometryPolyline",drawingInfo:{renderer:null}},featureSet:{geometryType:"esriGeometryPolyline",features:[]}},l={layerDefinition:{name:"pointLayer",geometryType:"esriGeometryPoint",drawingInfo:{renderer:null}},featureSet:{geometryType:"esriGeometryPoint",features:[]}},c={layerDefinition:{name:"multipointLayer",geometryType:"esriGeometryMultipoint",drawingInfo:{renderer:null}},featureSet:{geometryType:"esriGeometryMultipoint",features:[]}},(p={layerDefinition:{name:"pointLayer",geometryType:"esriGeometryPoint",drawingInfo:{renderer:null}},featureSet:{geometryType:"esriGeometryPoint",features:[]}}).layerDefinition.name="textLayer",delete p.layerDefinition.drawingInfo,t&&("esri.layers.FeatureLayer"===t.declaredClass||"esri.layers.StreamLayer"===t.declaredClass?s.layerDefinition.name=o.layerDefinition.name=l.layerDefinition.name=c.layerDefinition.name=a.legendLayerNameMap[t.id]||t.get("arcgisProps.title")||t.title:"esri.layers.GraphicsLayer"===t.declaredClass&&(r=t.graphics.items),t.renderer&&(f=t.renderer.toJSON(),s.layerDefinition.drawingInfo.renderer=f,o.layerDefinition.drawingInfo.renderer=f,l.layerDefinition.drawingInfo.renderer=f,c.layerDefinition.drawingInfo.renderer=f),n.showLabels&&t.labelsVisible&&"function"==typeof t.write&&(b=null==(y=t.write({},{origin:"web-map"}).layerDefinition)||null==(d=y.drawingInfo)?void 0:d.labelingInfo)&&(i=!0,s.layerDefinition.drawingInfo.labelingInfo=b,o.layerDefinition.drawingInfo.labelingInfo=b,l.layerDefinition.drawingInfo.labelingInfo=b,c.layerDefinition.drawingInfo.labelingInfo=b)),null!=t&&t.renderer||i||(delete s.layerDefinition.drawingInfo,delete o.layerDefinition.drawingInfo,delete l.layerDefinition.drawingInfo,delete c.layerDefinition.drawingInfo),g=null==t?void 0:t.fieldsIndex,x=null==t?void 0:t.renderer,!g){e.next=17;break}if(v=new Set,e.t0=i,!e.t0){e.next=10;break}return e.next=10,(0,D.Mu)(v,t);case 10:if(e.t1=x&&"function"==typeof x.collectRequiredFields,!e.t1){e.next=14;break}return e.next=14,x.collectRequiredFields(v,g);case 14:h=Array.from(v),w=g.fields.map((function(e){return e.toJSON()})),s.layerDefinition.fields=w,o.layerDefinition.fields=w,l.layerDefinition.fields=w,c.layerDefinition.fields=w;case 17:k=r&&r.length,L=0;case 19:if(!(L<k)){e.next=51;break}if(!1!==(V=r[L]||r.getItemAt(L)).visible&&V.geometry){e.next=23;break}return e.abrupt("continue",48);case 23:if((I=V.toJSON()).hasOwnProperty("popupTemplate")&&delete I.popupTemplate,I.geometry&&I.geometry.z&&delete I.geometry.z,!I.symbol||!I.symbol.outline||"esriCLS"!==I.symbol.outline.type||a.is11xService){e.next=25;break}return e.abrupt("continue",48);case 25:if(!a.is11xService&&I.symbol&&I.symbol.outline&&I.symbol.outline.color&&I.symbol.outline.color[3]&&(I.symbol.outline.color[3]=255),P=t&&t.renderer&&("valueExpression"in t.renderer&&t.renderer.valueExpression||"hasVisualVariables"in t.renderer&&t.renderer.hasVisualVariables()),I.symbol||!t||!t.renderer||!P||a.is11xService){e.next=35;break}return M=t.renderer,e.next=31,M.getSymbolAsync(V);case 31:if(O=e.sent){e.next=34;break}return e.abrupt("continue",48);case 34:I.symbol=O.toJSON(),"hasVisualVariables"in M&&M.hasVisualVariables()&&F(I.symbol,{renderer:M,graphic:V,symbol:O});case 35:if(e.t2=I.symbol,!e.t2){e.next=45;break}if(I.symbol.angle||delete I.symbol.angle,!nt(I.symbol)){e.next=44;break}return e.next=41,Qe(I.symbol,a);case 41:I.symbol=e.sent,e.next=45;break;case 44:I.symbol.text&&delete I.attributes;case 45:if(n&&n.forceFeatureAttributes||null==(T=h)||!T.length){e.next=47;break}!function(){var e={};h.forEach((function(t){I.attributes&&I.attributes.hasOwnProperty(t)&&(e[t]=I.attributes[t])})),I.attributes=e}();case 47:"polygon"===V.geometry.type?s.featureSet.features.push(I):"polyline"===V.geometry.type?o.featureSet.features.push(I):"point"===V.geometry.type?I.symbol&&I.symbol.text?p.featureSet.features.push(I):l.featureSet.features.push(I):"multipoint"===V.geometry.type?c.featureSet.features.push(I):"extent"===V.geometry.type&&(I.geometry=S.Z.fromExtent(V.geometry).toJSON(),s.featureSet.features.push(I));case 48:L++,e.next=19;break;case 51:E=[s,o,c,l,p].filter((function(e){return e.featureSet.features.length>0})),Z=(0,m.Z)(E),e.prev=53,Z.s();case 55:if((C=Z.n()).done){e.next=66;break}if(A=C.value,N=A.featureSet.features.every((function(e){return e.symbol})),!N||n&&n.forceFeatureAttributes||A.featureSet.features.forEach((function(e){delete e.attributes})),N&&delete A.layerDefinition.drawingInfo,e.t3=A.layerDefinition.drawingInfo&&A.layerDefinition.drawingInfo.renderer,!e.t3){e.next=64;break}return e.next=64,Ye(A.layerDefinition.drawingInfo.renderer,a);case 64:e.next=55;break;case 66:e.next=71;break;case 68:e.prev=68,e.t4=e.catch(53),Z.e(e.t4);case 71:return e.prev=71,Z.f(),e.finish(71);case 74:return e.abrupt("return",E.length?{featureCollection:{layers:E},showLabels:i}:null);case 75:case"end":return e.stop()}}),e,null,[[53,68,71,74]])}))),De.apply(this,arguments)}function Ie(e,t,r){return Le.apply(this,arguments)}function Le(){return Le=(0,n.Z)(u.mark((function e(t,r,n){var a,i,s,o,l,c,p,f,y,d,m,b,h,g,x,v,w;return u.wrap((function(e){for(;;)switch(e.prev=e.next){case 0:if(o=t.renderer,l=parseFloat(n.cimVersion),!(t.featureReduction&&(!n.is11xService||l<2.9)||"dot-density"===(null==o?void 0:o.type)&&(!n.is11xService||l<2.6))){e.next=3;break}return e.abrupt("return",Je(t,r,n));case 3:if(t.legendEnabled&&n.legendLayers.push({id:t.id}),c=r.layerView,p=r.printTemplate,f=r.view,y=o&&("valueExpression"in o&&o.valueExpression||"hasVisualVariables"in o&&o.hasVisualVariables()),d="feature-layer"!==(null==(a=t.source)?void 0:a.type)&&"ogc-feature"!==(null==(i=t.source)?void 0:i.type),!(!n.is11xService&&y||c.filter||d)&&o&&(!("field"in o)||null==o.field||"string"==typeof o.field&&t.getField(o.field))){e.next=14;break}return e.next=8,et(c);case 8:return m=e.sent,e.next=11,Se(t,m,p,n);case 11:s=e.sent,e.next=29;break;case 14:if((s={id:(w=t.write()).id,title:w.title,opacity:w.opacity,minScale:w.minScale,maxScale:w.maxScale,url:w.url,layerType:w.layerType,customParameters:w.customParameters,layerDefinition:w.layerDefinition}).showLabels=p.showLabels&&t.labelsVisible,Be(s,t),e.t0=null!=(b=s.layerDefinition)&&null!=(h=b.drawingInfo)&&h.renderer,!e.t0){e.next=24;break}return delete s.layerDefinition.minScale,delete s.layerDefinition.maxScale,e.next=23,Ye(s.layerDefinition.drawingInfo.renderer,n);case 23:e.t0="visualVariables"in o&&o.visualVariables&&o.visualVariables[0];case 24:if(!e.t0){e.next=27;break}"size"===(g=o.visualVariables[0]).type&&g.maxSize&&"number"!=typeof g.maxSize&&g.minSize&&"number"!=typeof g.minSize&&(x=(0,I.getSizeRangeAtScale)(g,f.scale),s.layerDefinition.drawingInfo.renderer.visualVariables[0].minSize=x.minSize,s.layerDefinition.drawingInfo.renderer.visualVariables[0].maxSize=x.maxSize);case 27:(v=(0,oe.cx)(c))&&(s.layerDefinition||(s.layerDefinition={}),s.layerDefinition.definitionExpression=s.layerDefinition.definitionExpression?"(".concat(s.layerDefinition.definitionExpression,") AND (").concat(v,")"):v);case 29:return e.abrupt("return",s);case 30:case"end":return e.stop()}}),e)}))),Le.apply(this,arguments)}function Te(e,t,r){return Ve.apply(this,arguments)}function Ve(){return Ve=(0,n.Z)(u.mark((function e(t,r,n){var a,i;return u.wrap((function(e){for(;;)switch(e.prev=e.next){case 0:return a=r.layerView,i=r.printTemplate,t.legendEnabled&&n.legendLayers.push({id:t.id}),e.t0=Se,e.t1=t,e.next=6,et(a);case 6:return e.t2=e.sent,e.t3=i,e.t4=n,e.abrupt("return",(0,e.t0)(e.t1,e.t2,e.t3,e.t4));case 10:case"end":return e.stop()}}),e)}))),Ve.apply(this,arguments)}function Pe(e,t,r){return Me.apply(this,arguments)}function Me(){return Me=(0,n.Z)(u.mark((function e(t,r,n){var a;return u.wrap((function(e){for(;;)switch(e.prev=e.next){case 0:return a=r.printTemplate,e.abrupt("return",Se(t,null,a,n));case 2:case"end":return e.stop()}}),e)}))),Me.apply(this,arguments)}function Oe(e,t){e.legendEnabled&&t.legendLayers.push({id:e.id});var r,n={layerType:(r=e.write()).layerType,customParameters:r.customParameters};if(n.bandIds=e.bandIds,n.compressionQuality=e.compressionQuality,n.format=e.format,n.interpolation=e.interpolation,(e.mosaicRule||e.definitionExpression)&&(n.mosaicRule=e.exportImageServiceParameters.mosaicRule.toJSON()),e.renderingRule||e.renderer)if(t.is11xService)e.renderingRule&&(n.renderingRule=e.renderingRule.toJSON()),e.renderer&&(n.layerDefinition=n.layerDefinition||{},n.layerDefinition.drawingInfo=n.layerDefinition.drawingInfo||{},n.layerDefinition.drawingInfo.renderer=e.renderer.toJSON());else{var a=e.exportImageServiceParameters.combineRendererWithRenderingRule();a&&(n.renderingRule=a.toJSON())}return Be(n,e),n}function Ee(e,t){e.legendEnabled&&t.legendLayers.push({id:e.id});var r,n={bandIds:(r=e.write()||{}).bandIds,customParameters:r.customParameters,interpolation:r.interpolation,layerDefinition:r.layerDefinition};return n.layerType="ArcGISImageServiceLayer",Be(n,e),n}function Ze(e,t,r){return Fe.apply(this,arguments)}function Fe(){return Fe=(0,n.Z)(u.mark((function e(t,r,n){var i,s,o,l,c,p;return u.wrap((function(e){for(;;)switch(e.prev=e.next){case 0:if(i=r.printTemplate,!n.is11xService){e.next=4;break}return s={type:"kml"},e.abrupt("return",(t.write(s,{origin:"web-map"}),delete s.layerType,s.url=(0,k.Fv)(t.url),s));case 4:return o=[],(l=r.layerView).allVisibleMapImages.forEach((function(e,r){var n={id:"".concat(t.id,"_image").concat(r),type:"image",title:t.id,minScale:t.minScale||0,maxScale:t.maxScale||0,opacity:t.opacity,extent:e.extent};"data:image/png;base64,"===e.href.substr(0,22)?n.imageData=e.href.substr(22):n.url=e.href,o.push(n)})),c=[].concat((0,d.Z)(l.allVisiblePoints.items),(0,d.Z)(l.allVisiblePolylines.items),(0,d.Z)(l.allVisiblePolygons.items)),e.t0=a.Z,e.t1={id:t.id},e.next=11,Se(null,c,i,n);case 11:return e.t2=e.sent,p=(0,e.t0)(e.t1,e.t2),e.abrupt("return",(o.push(p),o));case 14:case"end":return e.stop()}}),e)}))),Fe.apply(this,arguments)}function Ce(e,t,r){var n,a,i=t.view,s={id:e.id,subLayerIds:[]},o=[],l=i.scale;return e.sublayers&&e.sublayers.forEach((function e(t){var r=0===l,n=0===t.minScale||l<=t.minScale,a=0===t.maxScale||l>=t.maxScale;if(t.visible&&(r||n&&a))if(t.sublayers)t.sublayers.forEach(e);else{var i=t.toExportImageJSON(),u={id:t.id,name:t.title,layerDefinition:{drawingInfo:i.drawingInfo,definitionExpression:i.definitionExpression,source:i.source}};o.unshift(u),s.subLayerIds.push(t.id)}})),o.length&&(o=o.map((function(e){return{id:e.id,name:e.name,layerDefinition:e.layerDefinition}})),(n={layerType:(a=e.write()).layerType,customParameters:a.customParameters}).layers=o,n.visibleLayers=e.capabilities.exportMap.supportsDynamicLayers?void 0:s.subLayerIds,Be(n,e),e.legendEnabled&&r.legendLayers.push(s)),n}function Ae(e,t){return Ne.apply(this,arguments)}function Ne(){return Ne=(0,n.Z)(u.mark((function e(t,r){var n,a,i,s,o,l,c,p,f,y,b,h;return u.wrap((function(e){for(;;)switch(e.prev=e.next){case 0:if(n=t.layerView,a=t.printTemplate,i=[],s=n.layer,!(0,v.pC)(s.featureCollections)){e.next=24;break}o=(0,m.Z)(s.featureCollections),e.prev=4,o.s();case 6:if((l=o.n()).done){e.next=14;break}return c=l.value,e.next=10,Se(c,c.source,a,r);case 10:(p=e.sent)&&i.push.apply(i,(0,d.Z)(p.featureCollection.layers));case 12:e.next=6;break;case 14:e.next=19;break;case 16:e.prev=16,e.t0=e.catch(4),o.e(e.t0);case 19:return e.prev=19,o.f(),e.finish(19);case 22:e.next=44;break;case 24:if(!(0,v.pC)(s.sublayers)){e.next=44;break}f=(0,m.Z)(s.sublayers),e.prev=26,f.s();case 28:if((y=f.n()).done){e.next=36;break}return b=y.value,e.next=32,Se(null,b.graphics,a,r);case 32:(h=e.sent)&&i.push.apply(i,(0,d.Z)(h.featureCollection.layers));case 34:e.next=28;break;case 36:e.next=41;break;case 38:e.prev=38,e.t1=e.catch(26),f.e(e.t1);case 41:return e.prev=41,f.f(),e.finish(41);case 44:return e.abrupt("return",{featureCollection:{layers:i}});case 45:case"end":return e.stop()}}),e,null,[[4,16,19,22],[26,38,41,44]])}))),Ne.apply(this,arguments)}function Je(e,t,r){return _e.apply(this,arguments)}function _e(){return _e=(0,n.Z)(u.mark((function e(t,r,n){var a,i,s,o,l,c,p,f,y,d,m,b,h;return u.wrap((function(e){for(;;)switch(e.prev=e.next){case 0:return a=r.printTemplate,i=r.view,s={type:"image"},o={format:"png",ignoreBackground:!0,layers:[t],rotation:0},l=n.ssExtent||i.extent.clone(),c=96,p=!0,f=!0,a.exportOptions&&((y=a.exportOptions).dpi>0&&(c=y.dpi),y.width>0&&(p=y.width%2==i.width%2),y.height>0&&(f=y.height%2==i.height%2)),"map-only"!==a.layout||!a.scalePreserved||a.outScale&&a.outScale!==i.scale||96!==c||p&&f||(o.area={x:0,y:0,width:i.width,height:i.height},p||(o.area.width-=1),f||(o.area.height-=1),n.ssExtent)||(d=i.toMap((0,w.vW)(o.area.width,o.area.height)),l.ymin=d.y,l.xmax=d.x,n.ssExtent=l),s.extent=l.clone()._normalize(!0).toJSON(),e.next=8,i.takeScreenshot(o);case 8:return m=e.sent,b=(0,k.sJ)(m.dataUrl),h=b.data,e.abrupt("return",(s.imageData=h,s));case 12:case"end":return e.stop()}}),e)}))),_e.apply(this,arguments)}function Re(e,t,r){return ze.apply(this,arguments)}function ze(){return ze=(0,n.Z)(u.mark((function e(t,r,n){var a,i;return u.wrap((function(e){for(;;)switch(e.prev=e.next){case 0:return a=r.layerView,i=r.printTemplate,t.legendEnabled&&n.legendLayers.push({id:t.id}),e.t0=Se,e.t1=t,e.next=6,et(a);case 6:return e.t2=e.sent,e.t3=i,e.t4=n,e.abrupt("return",(0,e.t0)(e.t1,e.t2,e.t3,e.t4));case 10:case"end":return e.stop()}}),e)}))),ze.apply(this,arguments)}function Ge(e){var t,r={layerType:(t=e.write()).layerType,customParameters:t.customParameters};return Be(r,e),r}function Ue(e,t,r){return We.apply(this,arguments)}function We(){return We=(0,n.Z)(u.mark((function e(t,r,n){var a,i,s;return u.wrap((function(e){for(;;)switch(e.prev=e.next){case 0:if(!(n.is11xService&&t.serviceUrl&&t.styleUrl)){e.next=5;break}if(a=Xe(t.styleUrl,t.apiKey),i=Xe(t.serviceUrl,t.apiKey),(a||i)&&"2.1.0"===n.cimVersion){e.next=5;break}return s={type:"VectorTileLayer"},e.abrupt("return",(s.styleUrl=(0,k.Fv)(t.styleUrl),s.token=a,i!==a&&(s.additionalTokens=[{url:t.serviceUrl,token:i}]),s));case 5:return e.abrupt("return",Je(t,r,n));case 6:case"end":return e.stop()}}),e)}))),We.apply(this,arguments)}function Ke(e){var t={type:"WebTiledLayer",urlTemplate:e.urlTemplate.replace(/\${/g,"{"),credits:e.copyright};return e.subDomains&&e.subDomains.length>0&&(t.subDomains=e.subDomains),t}function je(e){var t,r=[];return e.sublayers&&e.sublayers.forEach((function e(t){t.visible&&(t.sublayers?t.sublayers.forEach(e):t.name&&r.unshift(t.name))})),r.length&&(t={type:"wms",customLayerParameters:e.customLayerParameters,customParameters:e.customParameters,transparentBackground:e.imageTransparency,visibleLayers:r,url:(0,k.Fv)(e.url),version:e.version}),t}function qe(e){var t=e.activeLayer;return{type:"wmts",customLayerParameters:e.customLayerParameters,customParameters:e.customParameters,format:t.imageFormat,layer:t.id,style:t.styleId,tileMatrixSet:t.tileMatrixSetId,url:(0,k.Fv)(e.url)}}function Be(e,t){t.url&&(e.url=(0,k.Fv)(e.url||t.url),e.token=Xe(e.url,t.apiKey))}function Xe(e,t){var r,n;return(0,se.r)(e)&&(t||b.Z.apiKey)?t||b.Z.apiKey:null==(r=h.id)||null==(n=r.findCredential(e))?void 0:n.token}function Qe(e,t){return He.apply(this,arguments)}function He(){return He=(0,n.Z)(u.mark((function e(t,r){var n,a,i,s,o,l,c,p,f,y,d,m,b,h,x;return u.wrap((function(e){for(;;)switch(e.prev=e.next){case 0:if(r.canvas||(r.canvas=document.createElement("canvas")),n=1024,r.canvas.width=n,r.canvas.height=n,a=r.canvas.getContext("2d"),!t.path){e.next=20;break}if((l=new Path2D(t.path)).closePath(),a.fillStyle=Array.isArray(t.color)?"rgba(".concat(t.color[0],",").concat(t.color[1],",").concat(t.color[2],",").concat(t.color[3]/255,")"):"rgb(0,0,0)",a.fill(l),c=C(a)){e.next=10;break}return e.abrupt("return",null);case 10:a.clearRect(0,0,n,n),p=(0,w.F2)(t.size)/Math.max(c.width,c.height),a.scale(p,p),y=(f=n/p)/2-c.width/2-c.x,d=f/2-c.height/2-c.y,a.translate(y,d),Array.isArray(t.color)&&a.fill(l),null!=(o=t.outline)&&o.width&&Array.isArray(t.outline.color)&&(m=t.outline,a.lineWidth=(0,w.F2)(m.width)/p,a.lineJoin="round",a.strokeStyle="rgba(".concat(m.color[0],",").concat(m.color[1],",").concat(m.color[2],",").concat(m.color[3]/255,")"),a.stroke(l),c.width+=a.lineWidth,c.height+=a.lineWidth),c.width*=p,c.height*=p,b=a.getImageData(n/2-c.width/2,n/2-c.height/2,Math.ceil(c.width),Math.ceil(c.height)),i=b.width,s=b.height,a.canvas.width=i,a.canvas.height=s,a.putImageData(b,0,0),e.next=25;break;case 20:return h="image/svg+xml"===t.contentType?"data:image/svg+xml;base64,"+t.imageData:t.url,e.next=23,(0,g.default)(h,{responseType:"image"});case 23:x=e.sent.data,i=(0,w.F2)(t.width),s=(0,w.F2)(t.height),a.canvas.width=i,a.canvas.height=s,a.drawImage(x,0,0,a.canvas.width,a.canvas.height);case 25:return e.abrupt("return",{type:"esriPMS",imageData:a.canvas.toDataURL("image/png").substr(22),angle:t.angle,contentType:"image/png",height:p(s),width:p(i),xoffset:t.xoffset,yoffset:t.yoffset});case 26:case"end":return e.stop()}}),e)}))),He.apply(this,arguments)}function Ye(e,t){return $e.apply(this,arguments)}function $e(){return $e=(0,n.Z)(u.mark((function e(t,r){var n,a,i,s,o;return u.wrap((function(e){for(;;)switch(e.prev=e.next){case 0:if("simple"!==(n=t.type)||!nt(t.symbol)){e.next=7;break}return e.next=4,Qe(t.symbol,r);case 4:t.symbol=e.sent,e.next=35;break;case 7:if("uniqueValue"!==n&&"classBreaks"!==n){e.next=35;break}if(e.t0=nt(t.defaultSymbol),!e.t0){e.next=13;break}return e.next=12,Qe(t.defaultSymbol,r);case 12:t.defaultSymbol=e.sent;case 13:if(!(a=t["uniqueValue"===n?"uniqueValueInfos":"classBreakInfos"])){e.next=35;break}i=(0,m.Z)(a),e.prev=16,i.s();case 18:if((s=i.n()).done){e.next=27;break}if(o=s.value,e.t1=nt(o.symbol),!e.t1){e.next=25;break}return e.next=24,Qe(o.symbol,r);case 24:o.symbol=e.sent;case 25:e.next=18;break;case 27:e.next=32;break;case 29:e.prev=29,e.t2=e.catch(16),i.e(e.t2);case 32:return e.prev=32,i.f(),e.finish(32);case 35:case"end":return e.stop()}}),e,null,[[16,29,32,35]])}))),$e.apply(this,arguments)}function et(e){return tt.apply(this,arguments)}function tt(){return(tt=(0,n.Z)(u.mark((function e(t){return u.wrap((function(e){for(;;)switch(e.prev=e.next){case 0:return e.abrupt("return",t.queryFeatures(t.createQuery()).then((function(e){return e.features})));case 1:case"end":return e.stop()}}),e)})))).apply(this,arguments)}function rt(e){return e.gpMetadata&&e.gpMetadata.executionType?ce.fromJSON(e.gpMetadata.executionType):"sync"}function nt(e){return e&&(e.path||"image/svg+xml"===e.contentType||e.url&&e.url.endsWith(".svg"))}var at=r(4338),it=new p.Xn({esriExecutionTypeSynchronous:"sync",esriExecutionTypeAsynchronous:"async"}),st=function(e){(0,o.Z)(r,e);var t=(0,l.Z)(r);function r(){var e;(0,i.Z)(this,r);for(var n=arguments.length,a=new Array(n),s=0;s<n;s++)a[s]=arguments[s];return(e=t.call.apply(t,[this].concat(a)))._gpMetadata=null,e.updateDelay=1e3,e}return(0,s.Z)(r,[{key:"mode",get:function(){return this._gpMetadata&&this._gpMetadata.executionType?it.fromJSON(this._gpMetadata.executionType):"sync"}},{key:"execute",value:function(e,t){return e&&(e.updateDelay=this.updateDelay),function(e,t,r){return fe.apply(this,arguments)}(this.url,e,(0,a.Z)((0,a.Z)({},this.requestOptions),t))}},{key:"_getGpPrintParams",value:function(){var e=(0,n.Z)(u.mark((function e(t){var r,n;return u.wrap((function(e){for(;;)switch(e.prev=e.next){case 0:return r=he(this.url),n=pe.get(r),e.abrupt("return",ye(t,n));case 2:case"end":return e.stop()}}),e,this)})));return function(t){return e.apply(this,arguments)}}()}]),r}(at.Z);(0,c._)([(0,f.Cb)()],st.prototype,"_gpMetadata",void 0),(0,c._)([(0,f.Cb)({readOnly:!0})],st.prototype,"mode",null),(0,c._)([(0,f.Cb)()],st.prototype,"updateDelay",void 0);var ot=st=(0,c._)([(0,y.j)("esri.tasks.PrintTask")],st)}}]);
//# sourceMappingURL=7972.57147357.chunk.js.map