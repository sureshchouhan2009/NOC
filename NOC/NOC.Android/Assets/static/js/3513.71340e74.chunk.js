"use strict";(self.webpackChunketihadrailapp=self.webpackChunketihadrailapp||[]).push([[3513],{33513:function(e,t,r){r.r(t),r.d(t,{default:function(){return Q}});var a=r(1413),n=r(15861),i=r(97326),l=r(11752),o=r(61120),y=r(37762),u=r(15671),s=r(43144),p=r(60136),f=r(29388),c=r(87757),d=r(27366),m=(r(59486),r(52639)),b=(r(51508),r(40110)),v=r(10064),g=r(84652),h=r(92026),S=r(97642),w=r(18202),C=r(51370),O=r(49861),N=(r(25243),r(38511)),Z=r(69912),_=r(31201),k=r(60176),x=r(64455),J=r(92975),L=r(50052),T=r(93655),M=r(74184),I=r(25820),R=r(6693),D=r(6061),j=r(29598),E=r(56811),F=r(83040),G=r(61459),P=r(16851),W=r(16072),z=r(58009),B=r(78952),A=r(53866);function X(e){return e.layers.some((function(e){return null!=e.layerDefinition.visibilityField}))}var q=new F.Z({name:"OBJECTID",alias:"OBJECTID",type:"oid",nullable:!1,editable:!1}),U=new F.Z({name:"title",alias:"Title",type:"string",nullable:!0,editable:!0}),V=function(e){(0,p.Z)(r,e);var t=(0,f.Z)(r);function r(){var e;return(0,u.Z)(this,r),(e=t.apply(this,arguments)).visibilityMode="inherited",e}return(0,s.Z)(r,[{key:"initialize",value:function(){var e,t=this,r=(0,y.Z)(this.graphics);try{for(r.s();!(e=r.n()).done;){e.value.sourceLayer=this.layer}}catch(a){r.e(a)}finally{r.f()}this.graphics.on("after-add",(function(e){e.item.sourceLayer=t.layer})),this.graphics.on("after-remove",(function(e){e.item.sourceLayer=null}))}},{key:"sublayers",get:function(){return this.graphics}}]),r}(T.Z);(0,d._)([(0,O.Cb)({readOnly:!0})],V.prototype,"sublayers",null),(0,d._)([(0,O.Cb)()],V.prototype,"layer",void 0),(0,d._)([(0,O.Cb)({readOnly:!0})],V.prototype,"visibilityMode",void 0),V=(0,d._)([(0,Z.j)("esri.layers.MapNotesLayer.MapNotesSublayer")],V);var H=[{geometryType:"polygon",geometryTypeJSON:"esriGeometryPolygon",layerId:"polygonLayer",title:"Polygons",identifyingSymbol:(new G.default).toJSON()},{geometryType:"polyline",geometryTypeJSON:"esriGeometryPolyline",layerId:"polylineLayer",title:"Polylines",identifyingSymbol:(new P.default).toJSON()},{geometryType:"multipoint",geometryTypeJSON:"esriGeometryMultipoint",layerId:"multipointLayer",title:"Multipoints",identifyingSymbol:(new W.default).toJSON()},{geometryType:"point",geometryTypeJSON:"esriGeometryPoint",layerId:"pointLayer",title:"Points",identifyingSymbol:(new W.default).toJSON()},{geometryType:"point",geometryTypeJSON:"esriGeometryPoint",layerId:"textLayer",title:"Text",identifyingSymbol:(new z.Z).toJSON()}],K=function(e){(0,p.Z)(r,e);var t=(0,f.Z)(r);function r(e){var a;return(0,u.Z)(this,r),(a=t.call(this,e)).capabilities={operations:{supportsMapNotesEditing:!0}},a.featureCollections=null,a.featureCollectionJSON=null,a.featureCollectionType="notes",a.legendEnabled=!1,a.minScale=0,a.maxScale=0,a.spatialReference=B.Z.WGS84,a.sublayers=new b.Z(H.map((function(e){return new V({id:e.layerId,title:e.title,layer:(0,i.Z)(a)})}))),a.title="Map Notes",a.type="map-notes",a.visibilityMode="inherited",a}return(0,s.Z)(r,[{key:"readCapabilities",value:function(e,t,r){return{operations:{supportsMapNotesEditing:!X(t)&&"portal-item"!==(null==r?void 0:r.origin)}}}},{key:"readFeatureCollections",value:function(e,t,r){if(!X(t))return null;var a=t.layers.map((function(e){var t=new L.default;return t.read(e,r),t}));return new b.Z({items:a})}},{key:"readLegacyfeatureCollectionJSON",value:function(e,t){return X(t)?(0,g.d9)(t.featureCollection):null}},{key:"readFullExtent",value:function(e,t){if(!t.layers.length||t.layers.every((function(e){return!e.layerDefinition.extent})))return new A.Z({xmin:-180,ymin:-90,xmax:180,ymax:90,spatialReference:B.Z.WGS84});var r=B.Z.fromJSON(t.layers[0].layerDefinition.spatialReference);return t.layers.reduce((function(e,t){var r=t.layerDefinition.extent;return r?A.Z.fromJSON(r).union(e):e}),new A.Z({spatialReference:r}))}},{key:"readMinScale",value:function(e,t){var r,a=(0,y.Z)(t.layers);try{for(a.s();!(r=a.n()).done;){var n=r.value;if(null!=n.layerDefinition.minScale)return n.layerDefinition.minScale}}catch(i){a.e(i)}finally{a.f()}return 0}},{key:"readMaxScale",value:function(e,t){var r,a=(0,y.Z)(t.layers);try{for(a.s();!(r=a.n()).done;){var n=r.value;if(null!=n.layerDefinition.maxScale)return n.layerDefinition.maxScale}}catch(i){a.e(i)}finally{a.f()}return 0}},{key:"multipointLayer",get:function(){return this._findSublayer("multipointLayer")}},{key:"pointLayer",get:function(){return this._findSublayer("pointLayer")}},{key:"polygonLayer",get:function(){return this._findSublayer("polygonLayer")}},{key:"polylineLayer",get:function(){return this._findSublayer("polylineLayer")}},{key:"readSpatialReference",value:function(e,t){return t.layers.length?B.Z.fromJSON(t.layers[0].layerDefinition.spatialReference):B.Z.WGS84}},{key:"readSublayers",value:function(e,t,r){var a=this;if(X(t))return null;for(var n=[],i=function(e){var r=t.layers[e],i=r.layerDefinition,l=r.featureSet,y=null!=(o=i.geometryType)?o:l.geometryType,u=H.find((function(e){var t,r,a;return y===e.geometryTypeJSON&&(null==(t=i.drawingInfo)||null==(r=t.renderer)||null==(a=r.symbol)?void 0:a.type)===e.identifyingSymbol.type}));if(u){var s=new V({id:u.layerId,title:i.name,layer:a,graphics:l.features.map((function(e){var t=e.geometry,r=e.symbol,a=e.attributes,n=e.popupInfo;return m.Z.fromJSON({attributes:a,geometry:t,symbol:r,popupTemplate:n})}))});n.push(s)}},l=0;l<t.layers.length;l++){var o;i(l)}return new b.Z(n)}},{key:"writeSublayers",value:function(e,t,r,a){var n=this,i=this.minScale,l=this.maxScale;if(!(0,h.Wi)(e)){var o=e.some((function(e){return e.graphics.length>0}));if(this.capabilities.operations.supportsMapNotesEditing){var u,s=[],p=this.spatialReference.toJSON(),f=(0,y.Z)(e);try{e:for(f.s();!(u=f.n()).done;){var c,d=u.value,m=(0,y.Z)(d.graphics);try{for(m.s();!(c=m.n()).done;){var b=c.value;if((0,h.pC)(b.geometry)){p=b.geometry.spatialReference.toJSON();break e}}}catch(N){m.e(N)}finally{m.f()}}}catch(N){f.e(N)}finally{f.f()}var g,S=(0,y.Z)(H);try{var C=function(){var t=g.value,r=e.find((function(e){return t.layerId===e.id}));n._writeMapNoteSublayer(s,r,t,i,l,p,a)};for(S.s();!(g=S.n()).done;)C()}catch(N){S.e(N)}finally{S.f()}(0,w.RB)("featureCollection.layers",s,t)}else{var O;o&&(null==a||null==(O=a.messages)||O.push(new v.Z("map-notes-layer:editing-not-supported","New map notes cannot be added to this layer")))}}}},{key:"textLayer",get:function(){return this._findSublayer("textLayer")}},{key:"load",value:function(e){return this.addResolvingPromise(this.loadFromPortal({supportedTypes:["Feature Collection"]},e)),Promise.resolve(this)}},{key:"read",value:function(e,t){"featureCollection"in e&&(e=(0,g.d9)(e),Object.assign(e,e.featureCollection)),(0,l.Z)((0,o.Z)(r.prototype),"read",this).call(this,e,t)}},{key:"beforeSave",value:function(){var e=(0,n.Z)(c.mark((function e(){var t,r,a,n,i,l,o,u,s,p;return c.wrap((function(e){for(;;)switch(e.prev=e.next){case 0:if(!(0,h.Wi)(this.sublayers)){e.next=2;break}return e.abrupt("return");case 2:t=null,r=[],a=(0,y.Z)(this.sublayers),e.prev=5,a.s();case 7:if((n=a.n()).done){e.next=40;break}i=n.value,l=(0,y.Z)(i.graphics),e.prev=10,l.s();case 12:if((o=l.n()).done){e.next=30;break}if(u=o.value,!(0,h.pC)(u.geometry)){e.next=28;break}if(s=u.geometry,!t){e.next=26;break}if(e.t0=(0,J.fS)(s.spatialReference,t),e.t0){e.next=24;break}if(e.t1=(0,k.Up)(s.spatialReference,t)||(0,k.kR)(),e.t1){e.next=23;break}return e.next=23,(0,k.zD)();case 23:u.geometry=(0,k.iV)(s,t);case 24:e.next=27;break;case 26:t=s.spatialReference;case 27:r.push(u);case 28:e.next=12;break;case 30:e.next=35;break;case 32:e.prev=32,e.t2=e.catch(10),l.e(e.t2);case 35:return e.prev=35,l.f(),e.finish(35);case 38:e.next=7;break;case 40:e.next=45;break;case 42:e.prev=42,e.t3=e.catch(5),a.e(e.t3);case 45:return e.prev=45,a.f(),e.finish(45);case 48:return e.next=50,(0,x.aX)(r.map((function(e){return e.geometry})));case 50:p=e.sent,r.forEach((function(e,t){return e.geometry=p[t]}));case 52:case"end":return e.stop()}}),e,this,[[5,42,45,48],[10,32,35,38]])})));return function(){return e.apply(this,arguments)}}()},{key:"_findSublayer",value:function(e){var t,r;return(0,h.Wi)(this.sublayers)?null:null!=(t=null==(r=this.sublayers)?void 0:r.find((function(t){return t.id===e})))?t:null}},{key:"_writeMapNoteSublayer",value:function(e,t,r,a,n,i,l){var o=[];if(!(0,h.Wi)(t)){var u,s=(0,y.Z)(t.graphics);try{for(s.s();!(u=s.n()).done;){var p=u.value;this._writeMapNote(o,p,r.geometryType,l)}}catch(f){s.e(f)}finally{s.f()}this._normalizeObjectIds(o,q),e.push({layerDefinition:{name:t.title,drawingInfo:{renderer:{type:"simple",symbol:(0,g.d9)(r.identifyingSymbol)}},geometryType:r.geometryTypeJSON,minScale:a,maxScale:n,objectIdField:"OBJECTID",fields:[q.toJSON(),U.toJSON()],spatialReference:i},featureSet:{features:o,geometryType:r.geometryTypeJSON}})}}},{key:"_writeMapNote",value:function(e,t,r,n){if(!(0,h.Wi)(t)){var i,l,o=t.geometry,y=t.symbol,u=t.popupTemplate;if(!(0,h.Wi)(o))if(o.type===r)if((0,h.Wi)(y))null==n||null==(l=n.messages)||l.push(new C.Z("map-notes-layer:no-symbol","Skipping map notes with no symbol",{graphic:t}));else{var s={attributes:(0,a.Z)({},t.attributes),geometry:o.toJSON(),symbol:y.toJSON()};(0,h.pC)(u)&&(s.popupInfo=u.toJSON()),e.push(s)}else null==n||null==(i=n.messages)||i.push(new C.Z("map-notes-layer:invalid-geometry-type",'Geometry "'.concat(o.type,'" cannot be saved in "').concat(r,'" layer'),{graphic:t}))}}},{key:"_normalizeObjectIds",value:function(e,t){var r,a=t.name,n=(0,I.S)(a,e)+1,i=new Set,l=(0,y.Z)(e);try{for(l.s();!(r=l.n()).done;){var o=r.value;o.attributes||(o.attributes={});var u=o.attributes;(null==u[a]||i.has(u[a]))&&(u[a]=n++),i.add(u[a])}}catch(s){l.e(s)}finally{l.f()}}}]),r}((0,R.h)((0,E.M)((0,D.q)((0,j.I)((0,S.R)(M.Z))))));(0,d._)([(0,O.Cb)({readOnly:!0})],K.prototype,"capabilities",void 0),(0,d._)([(0,N.r)(["portal-item","web-map"],"capabilities",["layers"])],K.prototype,"readCapabilities",null),(0,d._)([(0,O.Cb)({readOnly:!0})],K.prototype,"featureCollections",void 0),(0,d._)([(0,N.r)(["web-map","portal-item"],"featureCollections",["layers"])],K.prototype,"readFeatureCollections",null),(0,d._)([(0,O.Cb)({readOnly:!0,json:{origins:{"web-map":{write:{enabled:!0,target:"featureCollection"}}}}})],K.prototype,"featureCollectionJSON",void 0),(0,d._)([(0,N.r)(["web-map","portal-item"],"featureCollectionJSON",["featureCollection"])],K.prototype,"readLegacyfeatureCollectionJSON",null),(0,d._)([(0,O.Cb)({readOnly:!0,json:{read:!1,write:{enabled:!0,ignoreOrigin:!0}}})],K.prototype,"featureCollectionType",void 0),(0,d._)([(0,O.Cb)({json:{write:!1}})],K.prototype,"fullExtent",void 0),(0,d._)([(0,N.r)(["web-map","portal-item"],"fullExtent",["layers"])],K.prototype,"readFullExtent",null),(0,d._)([(0,O.Cb)({readOnly:!0,json:{origins:{"web-map":{write:{target:"featureCollection.showLegend",overridePolicy:function(){return{enabled:null!=this.featureCollectionJSON}}}}}}})],K.prototype,"legendEnabled",void 0),(0,d._)([(0,O.Cb)({type:["show","hide"]})],K.prototype,"listMode",void 0),(0,d._)([(0,O.Cb)({type:Number,nonNullable:!0,json:{write:!1}})],K.prototype,"minScale",void 0),(0,d._)([(0,N.r)(["web-map","portal-item"],"minScale",["layers"])],K.prototype,"readMinScale",null),(0,d._)([(0,O.Cb)({type:Number,nonNullable:!0,json:{write:!1}})],K.prototype,"maxScale",void 0),(0,d._)([(0,N.r)(["web-map","portal-item"],"maxScale",["layers"])],K.prototype,"readMaxScale",null),(0,d._)([(0,O.Cb)({readOnly:!0})],K.prototype,"multipointLayer",null),(0,d._)([(0,O.Cb)({value:"ArcGISFeatureLayer",type:["ArcGISFeatureLayer"]})],K.prototype,"operationalLayerType",void 0),(0,d._)([(0,O.Cb)({readOnly:!0})],K.prototype,"pointLayer",null),(0,d._)([(0,O.Cb)({readOnly:!0})],K.prototype,"polygonLayer",null),(0,d._)([(0,O.Cb)({readOnly:!0})],K.prototype,"polylineLayer",null),(0,d._)([(0,O.Cb)({type:B.Z})],K.prototype,"spatialReference",void 0),(0,d._)([(0,N.r)(["web-map","portal-item"],"spatialReference",["layers"])],K.prototype,"readSpatialReference",null),(0,d._)([(0,O.Cb)({readOnly:!0,json:{origins:{"web-map":{write:{ignoreOrigin:!0}}}}})],K.prototype,"sublayers",void 0),(0,d._)([(0,N.r)("web-map","sublayers",["layers"])],K.prototype,"readSublayers",null),(0,d._)([(0,_.c)("web-map","sublayers")],K.prototype,"writeSublayers",null),(0,d._)([(0,O.Cb)({readOnly:!0})],K.prototype,"textLayer",null),(0,d._)([(0,O.Cb)()],K.prototype,"title",void 0),(0,d._)([(0,O.Cb)({readOnly:!0,json:{read:!1}})],K.prototype,"type",void 0);var Q=K=(0,d._)([(0,Z.j)("esri.layers.MapNotesLayer")],K)},25820:function(e,t,r){r.d(t,{S:function(){return i},X:function(){return n}});var a=r(37762),n=1;function i(e,t){var r,n=0,i=(0,a.Z)(t);try{for(i.s();!(r=i.n()).done;){var l,o=null==(l=r.value.attributes)?void 0:l[e];"number"==typeof o&&isFinite(o)&&(n=Math.max(n,o))}}catch(y){i.e(y)}finally{i.f()}return n}}}]);
//# sourceMappingURL=3513.71340e74.chunk.js.map