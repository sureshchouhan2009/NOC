"use strict";(self.webpackChunketihadrailapp=self.webpackChunketihadrailapp||[]).push([[8435],{98435:function(e,t,r){r.r(t),r.d(t,{default:function(){return P}});var n=r(37762),o=r(15861),i=r(1413),s=r(15671),u=r(43144),a=r(11752),c=r(61120),l=r(60136),p=r(29388),d=r(87757),f=r(27366),y=(r(59486),r(92026)),h=r(35995),v=r(49861),m=(r(63780),r(93169)),g=(r(25243),r(38511)),b=r(69912),w=r(50052),k=r(54472),C=r(66978),S=r(31009),x=r(49818),_=r(53866),O=function(e){(0,l.Z)(r,e);var t=(0,p.Z)(r);function r(e){var n;return(0,s.Z)(this,r),(n=t.call(this,e)).type="csv",n.refresh=(0,C.Ds)(function(){var e=(0,o.Z)(d.mark((function e(t){var r,o,i;return d.wrap((function(e){for(;;)switch(e.prev=e.next){case 0:return e.next=2,n.load();case 2:return e.next=4,n._connection.invoke("refresh",t);case 4:return r=e.sent,o=r.extent,i=r.timeExtent,e.abrupt("return",(n.sourceJSON.extent=o,i&&(n.sourceJSON.timeInfo.timeExtent=[i.start,i.end]),{dataChanged:!0,updates:{extent:n.sourceJSON.extent,timeInfo:n.sourceJSON.timeInfo}}));case 8:case"end":return e.stop()}}),e)})));return function(t){return e.apply(this,arguments)}}()),n}return(0,u.Z)(r,[{key:"load",value:function(e){var t=(0,y.pC)(e)?e.signal:null;return this.addResolvingPromise(this._startWorker(t)),Promise.resolve(this)}},{key:"destroy",value:function(){var e;null==(e=this._connection)||e.close(),this._connection=null}},{key:"openPorts",value:function(){var e=(0,o.Z)(d.mark((function e(){return d.wrap((function(e){for(;;)switch(e.prev=e.next){case 0:return e.next=2,this.load();case 2:return e.abrupt("return",this._connection.openPorts());case 3:case"end":return e.stop()}}),e,this)})));return function(){return e.apply(this,arguments)}}()},{key:"queryFeatures",value:function(){var e=(0,o.Z)(d.mark((function e(t){var r,n,o=arguments;return d.wrap((function(e){for(;;)switch(e.prev=e.next){case 0:return r=o.length>1&&void 0!==o[1]?o[1]:{},e.next=3,this.load(r);case 3:return e.next=5,this._connection.invoke("queryFeatures",t?t.toJSON():null,r);case 5:return n=e.sent,e.abrupt("return",x.default.fromJSON(n));case 7:case"end":return e.stop()}}),e,this)})));return function(t){return e.apply(this,arguments)}}()},{key:"queryFeaturesJSON",value:function(){var e=(0,o.Z)(d.mark((function e(t){var r,n=arguments;return d.wrap((function(e){for(;;)switch(e.prev=e.next){case 0:return r=n.length>1&&void 0!==n[1]?n[1]:{},e.next=3,this.load(r);case 3:return e.abrupt("return",this._connection.invoke("queryFeatures",t?t.toJSON():null,r));case 4:case"end":return e.stop()}}),e,this)})));return function(t){return e.apply(this,arguments)}}()},{key:"queryFeatureCount",value:function(){var e=(0,o.Z)(d.mark((function e(t){var r,n=arguments;return d.wrap((function(e){for(;;)switch(e.prev=e.next){case 0:return r=n.length>1&&void 0!==n[1]?n[1]:{},e.next=3,this.load(r);case 3:return e.abrupt("return",this._connection.invoke("queryFeatureCount",t?t.toJSON():null,r));case 4:case"end":return e.stop()}}),e,this)})));return function(t){return e.apply(this,arguments)}}()},{key:"queryObjectIds",value:function(){var e=(0,o.Z)(d.mark((function e(t){var r,n=arguments;return d.wrap((function(e){for(;;)switch(e.prev=e.next){case 0:return r=n.length>1&&void 0!==n[1]?n[1]:{},e.next=3,this.load(r);case 3:return e.abrupt("return",this._connection.invoke("queryObjectIds",t?t.toJSON():null,r));case 4:case"end":return e.stop()}}),e,this)})));return function(t){return e.apply(this,arguments)}}()},{key:"queryExtent",value:function(){var e=(0,o.Z)(d.mark((function e(t){var r,n,o=arguments;return d.wrap((function(e){for(;;)switch(e.prev=e.next){case 0:return r=o.length>1&&void 0!==o[1]?o[1]:{},e.next=3,this.load(r);case 3:return e.next=5,this._connection.invoke("queryExtent",t?t.toJSON():null,r);case 5:return n=e.sent,e.abrupt("return",{count:n.count,extent:_.Z.fromJSON(n.extent)});case 7:case"end":return e.stop()}}),e,this)})));return function(t){return e.apply(this,arguments)}}()},{key:"querySnapping",value:function(){var e=(0,o.Z)(d.mark((function e(t){var r,n=arguments;return d.wrap((function(e){for(;;)switch(e.prev=e.next){case 0:return r=n.length>1&&void 0!==n[1]?n[1]:{},e.next=3,this.load(r);case 3:return e.abrupt("return",this._connection.invoke("querySnapping",t,r));case 4:case"end":return e.stop()}}),e,this)})));return function(t){return e.apply(this,arguments)}}()},{key:"_startWorker",value:function(){var e=(0,o.Z)(d.mark((function e(t){var r,n,o,i,s,u,a,c,l;return d.wrap((function(e){for(;;)switch(e.prev=e.next){case 0:return e.next=2,(0,S.bA)("CSVSourceWorker",{strategy:(0,m.Z)("feature-layers-workers")?"dedicated":"local",signal:t});case 2:return this._connection=e.sent,r=this.loadOptions,n=r.url,o=r.delimiter,i=r.fields,s=r.latitudeField,u=r.longitudeField,a=r.spatialReference,c=r.timeInfo,e.next=13,this._connection.invoke("load",{url:n,customParameters:this.customParameters,parsingOptions:{delimiter:o,fields:null==i?void 0:i.map((function(e){return e.toJSON()})),latitudeField:s,longitudeField:u,spatialReference:null==a?void 0:a.toJSON(),timeInfo:null==c?void 0:c.toJSON()}},{signal:t});case 13:l=e.sent,this.locationInfo=l.locationInfo,this.sourceJSON=l.layerDefinition,this.delimiter=l.delimiter;case 15:case"end":return e.stop()}}),e,this)})));return function(t){return e.apply(this,arguments)}}()}]),r}(k.Z);(0,f._)([(0,v.Cb)()],O.prototype,"type",void 0),(0,f._)([(0,v.Cb)()],O.prototype,"loadOptions",void 0),(0,f._)([(0,v.Cb)()],O.prototype,"customParameters",void 0),(0,f._)([(0,v.Cb)()],O.prototype,"locationInfo",void 0),(0,f._)([(0,v.Cb)()],O.prototype,"sourceJSON",void 0),(0,f._)([(0,v.Cb)()],O.prototype,"delimiter",void 0);var Z=O=(0,f._)([(0,b.j)("esri.layers.graphics.sources.CSVSource")],O),F=r(63543),I=r(21149),q=r(53283),N=r(78952),D=function(e){(0,l.Z)(r,e);var t=(0,p.Z)(r);function r(){var e;(0,s.Z)(this,r);for(var n=arguments.length,o=new Array(n),i=0;i<n;i++)o[i]=arguments[i];return(e=t.call.apply(t,[this].concat(o))).capabilities=(0,F.MS)(!1,!1),e.delimiter=null,e.editingEnabled=!1,e.fields=null,e.latitudeField=null,e.locationType="coordinates",e.longitudeField=null,e.operationalLayerType="CSV",e.outFields=["*"],e.path=null,e.portalItem=null,e.spatialReference=N.Z.WGS84,e.source=null,e.type="csv",e}return(0,u.Z)(r,[{key:"normalizeCtorArgs",value:function(e,t){return"string"==typeof e?(0,i.Z)({url:e},t):e}},{key:"isTable",get:function(){return this.loaded&&null==this.geometryType}},{key:"readWebMapLabelsVisible",value:function(e,t){return null!=t.showLabels?t.showLabels:!!(t.layerDefinition&&t.layerDefinition.drawingInfo&&t.layerDefinition.drawingInfo.labelingInfo)}},{key:"url",set:function(e){if(e){var t=(0,h.mN)(e);this._set("url",t.path),t.query&&(this.customParameters=(0,i.Z)((0,i.Z)({},this.customParameters),t.query))}else this._set("url",e)}},{key:"createGraphicsSource",value:function(){var e=(0,o.Z)(d.mark((function e(t){var r;return d.wrap((function(e){for(;;)switch(e.prev=e.next){case 0:return r=new Z({loadOptions:{delimiter:this.delimiter,fields:this.fields,latitudeField:this.latitudeField,longitudeField:this.longitudeField,spatialReference:this.spatialReference,timeInfo:this.timeInfo,url:this.url},customParameters:this.customParameters}),this._set("source",r),e.next=4,r.load({signal:t});case 4:return this.read({locationInfo:r.locationInfo,columnDelimiter:r.delimiter},{origin:"service",url:this.parsedUrl}),e.abrupt("return",r);case 6:case"end":return e.stop()}}),e,this)})));return function(t){return e.apply(this,arguments)}}()},{key:"queryFeatures",value:function(e,t){var r=this;return this.load().then((function(){return r.source.queryFeatures(I.Z.from(e)||r.createQuery())})).then((function(e){if(null!=e&&e.features){var t,o=(0,n.Z)(e.features);try{for(o.s();!(t=o.n()).done;){var i=t.value;i.layer=i.sourceLayer=r}}catch(s){o.e(s)}finally{o.f()}}return e}))}},{key:"queryObjectIds",value:function(e,t){var r=this;return this.load().then((function(){return r.source.queryObjectIds(I.Z.from(e)||r.createQuery())}))}},{key:"queryFeatureCount",value:function(e,t){var r=this;return this.load().then((function(){return r.source.queryFeatureCount(I.Z.from(e)||r.createQuery())}))}},{key:"queryExtent",value:function(e,t){var r=this;return this.load().then((function(){return r.source.queryExtent(I.Z.from(e)||r.createQuery())}))}},{key:"write",value:function(e,t){return(0,a.Z)((0,c.Z)(r.prototype),"write",this).call(this,e,(0,i.Z)((0,i.Z)({},t),{},{writeLayerSchema:!0}))}},{key:"hasDataChanged",value:function(){var e=(0,o.Z)(d.mark((function e(){var t,r,n;return d.wrap((function(e){for(;;)switch(e.prev=e.next){case 0:return e.prev=0,e.next=3,this.source.refresh(this.customParameters);case 3:return t=e.sent,r=t.dataChanged,n=t.updates,e.abrupt("return",((0,y.pC)(n)&&this.read(n,{origin:"service",url:this.parsedUrl,ignoreDefaults:!0}),r));case 9:e.prev=9,e.t0=e.catch(0);case 11:return e.abrupt("return",!1);case 12:case"end":return e.stop()}}),e,this,[[0,9]])})));return function(){return e.apply(this,arguments)}}()},{key:"_verifyFields",value:function(){}},{key:"_verifySource",value:function(){}},{key:"_hasMemorySource",value:function(){return!1}}]),r}(w.default);(0,f._)([(0,v.Cb)({readOnly:!0,json:{read:!1,write:!1}})],D.prototype,"capabilities",void 0),(0,f._)([(0,v.Cb)({type:[","," ",";","|","\t"],json:{read:{source:"columnDelimiter"},write:{target:"columnDelimiter",ignoreOrigin:!0}}})],D.prototype,"delimiter",void 0),(0,f._)([(0,v.Cb)({readOnly:!0,type:Boolean,json:{origins:{"web-scene":{read:!1,write:!1}}}})],D.prototype,"editingEnabled",void 0),(0,f._)([(0,v.Cb)({json:{read:{source:"layerDefinition.fields"},write:{target:"layerDefinition.fields"}}})],D.prototype,"fields",void 0),(0,f._)([(0,v.Cb)({type:Boolean,readOnly:!0})],D.prototype,"isTable",null),(0,f._)([(0,g.r)("web-map","labelsVisible",["layerDefinition.drawingInfo.labelingInfo","showLabels"])],D.prototype,"readWebMapLabelsVisible",null),(0,f._)([(0,v.Cb)({type:String,json:{read:{source:"locationInfo.latitudeFieldName"},write:{target:"locationInfo.latitudeFieldName",ignoreOrigin:!0}}})],D.prototype,"latitudeField",void 0),(0,f._)([(0,v.Cb)({type:["show","hide"]})],D.prototype,"listMode",void 0),(0,f._)([(0,v.Cb)({type:["coordinates"],json:{read:{source:"locationInfo.locationType"},write:{target:"locationInfo.locationType",ignoreOrigin:!0,isRequired:!0}}})],D.prototype,"locationType",void 0),(0,f._)([(0,v.Cb)({type:String,json:{read:{source:"locationInfo.longitudeFieldName"},write:{target:"locationInfo.longitudeFieldName",ignoreOrigin:!0}}})],D.prototype,"longitudeField",void 0),(0,f._)([(0,v.Cb)({type:["CSV"]})],D.prototype,"operationalLayerType",void 0),(0,f._)([(0,v.Cb)()],D.prototype,"outFields",void 0),(0,f._)([(0,v.Cb)({type:String,json:{origins:{"web-scene":{read:!1,write:!1}},read:!1,write:!1}})],D.prototype,"path",void 0),(0,f._)([(0,v.Cb)({json:{read:!1,write:!1,origins:{"web-document":{read:!1,write:!1}}}})],D.prototype,"portalItem",void 0),(0,f._)([(0,v.Cb)({json:{read:!1},cast:null,type:Z,readOnly:!0})],D.prototype,"source",void 0),(0,f._)([(0,v.Cb)({json:{read:!1},value:"csv",readOnly:!0})],D.prototype,"type",void 0),(0,f._)([(0,v.Cb)({json:{read:q.r,write:{isRequired:!0,ignoreOrigin:!0,writer:q.w}}})],D.prototype,"url",null);var P=D=(0,f._)([(0,b.j)("esri.layers.CSVLayer")],D)},60480:function(e,t,r){r.d(t,{g:function(){return n}});var n={supportsStatistics:!0,supportsPercentileStatistics:!0,supportsCentroid:!0,supportsCacheHint:!1,supportsDistance:!0,supportsDistinct:!0,supportsExtent:!0,supportsGeometryProperties:!1,supportsHavingClause:!0,supportsOrderBy:!0,supportsPagination:!0,supportsQuantization:!0,supportsQuantizationEditMode:!1,supportsQueryGeometry:!0,supportsResultType:!1,supportsSqlExpression:!0,supportsMaxRecordCountFactor:!1,supportsStandardizedQueriesOnly:!0,supportsTopFeaturesQuery:!1,supportsQueryByOthers:!0,supportsHistoricMoment:!1,supportsFormatPBF:!1,supportsDisjointSpatialRelationship:!0,maxRecordCountFactor:void 0,maxRecordCount:void 0,standardMaxRecordCount:void 0,tileMaxRecordCount:void 0}},63543:function(e,t,r){r.d(t,{MS:function(){return d},Dm:function(){return l},Hq:function(){return p},bU:function(){return c}});var n=r(4942),o=r(1413),i=r(93169),s=r(84652),u=r(60480),a=r(76115);function c(e){return{renderer:{type:"simple",symbol:"esriGeometryPoint"===e||"esriGeometryMultipoint"===e?a.I4:"esriGeometryPolyline"===e?a.ET:a.lF}}}function l(e,t){if((0,i.Z)("esri-csp-restrictions"))return function(){return(0,o.Z)((0,n.Z)({},t,null),e)};try{var r="this.".concat(t," = null;");for(var s in e)r+="this".concat(s.includes(".")?'["'.concat(s,'"]'):".".concat(s)," = ").concat(JSON.stringify(e[s]),";");var u=new Function(r);return function(){return new u}}catch(a){return function(){return(0,o.Z)((0,n.Z)({},t,null),e)}}}function p(){var e=arguments.length>0&&void 0!==arguments[0]?arguments[0]:{};return[{name:"New Feature",description:"",prototype:{attributes:(0,s.d9)(e)}}]}function d(e,t){return{attachment:null,data:{isVersioned:!1,supportsAttachment:!1,supportsM:!1,supportsZ:e},metadata:{supportsAdvancedFieldProperties:!1},operations:{supportsCalculate:!1,supportsTruncate:!1,supportsValidateSql:!1,supportsAdd:t,supportsDelete:t,supportsEditing:t,supportsChangeTracking:!1,supportsQuery:!0,supportsQueryAttachments:!1,supportsResizeAttachments:!1,supportsSync:!1,supportsUpdate:t,supportsExceedsLimitStatistics:!0},query:u.g,queryRelated:{supportsCount:!0,supportsOrderBy:!0,supportsPagination:!0},editing:{supportsGeometryUpdate:t,supportsGlobalId:!1,supportsReturnServiceEditsInSourceSpatialReference:!1,supportsRollbackOnFailure:!1,supportsUpdateWithoutM:!1,supportsUploadWithItemId:!1,supportsDeleteByAnonymous:!1,supportsDeleteByOthers:!1,supportsUpdateByAnonymous:!1,supportsUpdateByOthers:!1}}}}}]);
//# sourceMappingURL=8435.96982102.chunk.js.map