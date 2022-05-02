"use strict";(self.webpackChunketihadrailapp=self.webpackChunketihadrailapp||[]).push([[2668],{2668:function(e,t,r){r.r(t),r.d(t,{default:function(){return oe}});var i,n=r(15861),o=r(1413),a=r(15671),s=r(43144),l=r(60136),p=r(29388),d=r(87757),u=r(27366),y=(r(59486),r(44055)),c=(r(94931),r(78451),r(34213),r(46797),r(49018),r(34999)),f=r(79850),b=r(9014),m=r(40464),v=r(76200),h=r(51508),g=r(10064),w=r(32718),_=r(92026),I=r(97642),C=r(66978),S=r(49861),k=(r(63780),r(93169),r(25243)),x=r(38511),Z=r(69912),j=r(47492),T=r(27823),R=r(74184),F=r(11936),N=r(6693),O=r(46671),P=r(7632),D=r(6061),E=r(29598),L=r(71684),A=r(56811),U=r(99063),J=r(45948),q=r(68118),z=r(25610),G=r(37270),M=r(77748),Q=r(85116),V=r(67123),Y=i=function(e){(0,l.Z)(r,e);var t=(0,p.Z)(r);function r(){var e;return(0,a.Z)(this,r),(e=t.apply(this,arguments)).age=null,e.ageReceived=null,e.displayCount=null,e.maxObservations=1,e}return(0,s.Z)(r,[{key:"clone",value:function(){return new i({age:this.age,ageReceived:this.ageReceived,displayCount:this.displayCount,maxObservations:this.maxObservations})}}]),r}(V.wq);(0,u._)([(0,S.Cb)({type:Number,json:{write:!0}})],Y.prototype,"age",void 0),(0,u._)([(0,S.Cb)({type:Number,json:{write:!0}})],Y.prototype,"ageReceived",void 0),(0,u._)([(0,S.Cb)({type:Number,json:{write:!0}})],Y.prototype,"displayCount",void 0),(0,u._)([(0,S.Cb)({type:Number,json:{write:!0}})],Y.prototype,"maxObservations",void 0);var W=Y=i=(0,u._)([(0,Z.j)("esri.layers.support.PurgeOptions")],Y),H=r(21371),B=r(21149),K=r(81085),X=r(64575),$=r(78952),ee=r(53866),te=w.Z.getLogger("esri.layers.StreamLayer"),re=(0,z.v)(),ie=function(e){(0,l.Z)(r,e);var t=(0,p.Z)(r);function r(){var e;(0,a.Z)(this,r);for(var i=arguments.length,n=new Array(i),o=0;o<i;o++)n[o]=arguments[o];return(e=t.call.apply(t,[this].concat(n))).copyright=null,e.definitionExpression=null,e.displayField=null,e.elevationInfo=null,e.featureReduction=null,e.fields=null,e.fieldsIndex=null,e.geometryDefinition=null,e.geometryType=null,e.labelsVisible=!0,e.labelingInfo=null,e.legendEnabled=!0,e.maxReconnectionAttempts=0,e.maxReconnectionInterval=20,e.maxScale=0,e.minScale=0,e.objectIdField=null,e.operationalLayerType="ArcGISStreamLayer",e.popupEnabled=!0,e.popupTemplate=null,e.purgeOptions=new W,e.screenSizePerspectiveEnabled=!0,e.sourceJSON=null,e.spatialReference=$.Z.WGS84,e.type="stream",e.url=null,e.updateInterval=300,e.webSocketUrl=null,e}return(0,s.Z)(r,[{key:"normalizeCtorArgs",value:function(e,t){return"string"==typeof e?(0,o.Z)({url:e},t):e}},{key:"load",value:function(e){var t=this;if(!("WebSocket"in globalThis))return this.addResolvingPromise(Promise.reject(new g.Z("stream-layer:websocket-unsupported","WebSocket is not supported in this browser. StreamLayer will not have real-time connection with the stream service."))),Promise.resolve(this);var r=(0,_.pC)(e)?e.signal:null;return this.addResolvingPromise(this.loadFromPortal({supportedTypes:["Stream Service","Feed"]},e).catch(C.r9).then((function(){return t._fetchService(r)}))),Promise.resolve(this)}},{key:"defaultPopupTemplate",get:function(){return this.createPopupTemplate()}},{key:"renderer",set:function(e){(0,G.YN)(e,this.fieldsIndex),this._set("renderer",e)}},{key:"readRenderer",value:function(e,t,r){var i=(t=t.layerDefinition||t).drawingInfo&&t.drawingInfo.renderer||void 0;if(i){var n=(0,b.a)(i,t,r)||void 0;return n||te.error("Failed to create renderer",{rendererDefinition:t.drawingInfo.renderer,layer:this,context:r}),n}if(t.defaultSymbol)return t.types&&t.types.length?new f.Z({defaultSymbol:ne(t.defaultSymbol,t,r),field:t.typeIdField,uniqueValueInfos:t.types.map((function(e){return{id:e.id,symbol:ne(e.symbol,e,r)}}))}):new c.Z({symbol:ne(t.defaultSymbol,t,r)})}},{key:"createPopupTemplate",value:function(e){return(0,K.eZ)(this,e)}},{key:"createQuery",value:function(){var e=new B.Z;return e.returnGeometry=!0,e.outFields=["*"],e.where=this.definitionExpression||"1=1",e}},{key:"getFieldDomain",value:function(e,t){if(!this.fields)return null;var r=null;return this.fields.some((function(t){return t.name===e&&(r=t.domain),!!r})),r}},{key:"getField",value:function(e){return this.fieldsIndex.get(e)}},{key:"_fetchService",value:function(){var e=(0,n.Z)(d.mark((function e(t){var r,i,n,a;return d.wrap((function(e){for(;;)switch(e.prev=e.next){case 0:if(!this.webSocketUrl){e.next=12;break}if(null!=(i=this.timeInfo)&&i.trackIdField){e.next=3;break}throw new g.Z("stream-layer:missing-metadata","The stream layer trackIdField must be specified.");case 3:if(this.objectIdField){e.next=5;break}throw new g.Z("stream-layer:missing-metadata","The stream layer objectIdField must be specified.");case 5:if(this.fields){e.next=7;break}throw new g.Z("stream-layer:missing-metadata","The stream layer fields must be specified.");case 7:if(this.geometryType){e.next=9;break}throw new g.Z("stream-layer:missing-metadata","The stream layer geometryType must be specified.");case 9:this.url=this.webSocketUrl,e.next=18;break;case 12:if(this.sourceJSON){e.next=18;break}return e.next=15,(0,v.default)(this.parsedUrl.path,{query:(0,o.Z)((0,o.Z)({f:"json"},this.customParameters),this.parsedUrl.query),responseType:"json",signal:t});case 15:n=e.sent,a=n.data,this.sourceJSON=a;case 18:return e.abrupt("return",(this.sourceJSON=(0,o.Z)((0,o.Z)({},null!=(r=this.sourceJSON)?r:{}),{},{objectIdField:"__esri_stream_id__"}),this.read(this.sourceJSON,{origin:"service",url:this.parsedUrl}),(0,G.YN)(this.renderer,this.fieldsIndex),(0,G.UF)(this.timeInfo,this.fieldsIndex),(0,H.y)(this,{origin:"service"})));case 19:case"end":return e.stop()}}),e,this)})));return function(t){return e.apply(this,arguments)}}()}]),r}((0,P.b)((0,N.h)((0,U.n)((0,A.M)((0,L.Q)((0,F.Y)((0,D.q)((0,E.I)((0,I.R)((0,O.N)(R.Z)))))))))));(0,u._)([(0,S.Cb)({type:String})],ie.prototype,"copyright",void 0),(0,u._)([(0,S.Cb)({readOnly:!0})],ie.prototype,"defaultPopupTemplate",null),(0,u._)([(0,S.Cb)({type:String,json:{name:"layerDefinition.definitionExpression",write:{enabled:!0,allowNull:!0}}})],ie.prototype,"definitionExpression",void 0),(0,u._)([(0,S.Cb)({type:String})],ie.prototype,"displayField",void 0),(0,u._)([(0,S.Cb)({type:X.Z})],ie.prototype,"elevationInfo",void 0),(0,u._)([(0,S.Cb)(q.d)],ie.prototype,"featureReduction",void 0),(0,u._)([(0,S.Cb)(re.fields)],ie.prototype,"fields",void 0),(0,u._)([(0,S.Cb)(re.fieldsIndex)],ie.prototype,"fieldsIndex",void 0),(0,u._)([(0,S.Cb)({type:ee.Z})],ie.prototype,"geometryDefinition",void 0),(0,u._)([(0,S.Cb)({type:T.Mk.apiValues,json:{read:{reader:T.Mk.read}}})],ie.prototype,"geometryType",void 0),(0,u._)([(0,S.Cb)(J.iR)],ie.prototype,"labelsVisible",void 0),(0,u._)([(0,S.Cb)({type:[M.Z],json:{read:{source:"layerDefinition.drawingInfo.labelingInfo",reader:Q.r},write:{target:"layerDefinition.drawingInfo.labelingInfo"}}})],ie.prototype,"labelingInfo",void 0),(0,u._)([(0,S.Cb)(J.rn)],ie.prototype,"legendEnabled",void 0),(0,u._)([(0,S.Cb)({type:["show","hide"]})],ie.prototype,"listMode",void 0),(0,u._)([(0,S.Cb)({type:k.z8})],ie.prototype,"maxReconnectionAttempts",void 0),(0,u._)([(0,S.Cb)({type:k.z8})],ie.prototype,"maxReconnectionInterval",void 0),(0,u._)([(0,S.Cb)(J.u1)],ie.prototype,"maxScale",void 0),(0,u._)([(0,S.Cb)(J.rO)],ie.prototype,"minScale",void 0),(0,u._)([(0,S.Cb)({type:String})],ie.prototype,"objectIdField",void 0),(0,u._)([(0,S.Cb)({value:"ArcGISStreamLayer",type:["ArcGISStreamLayer"]})],ie.prototype,"operationalLayerType",void 0),(0,u._)([(0,S.Cb)(J.C_)],ie.prototype,"popupEnabled",void 0),(0,u._)([(0,S.Cb)({type:y.Z,json:{read:{source:"popupInfo"},write:{target:"popupInfo"}}})],ie.prototype,"popupTemplate",void 0),(0,u._)([(0,S.Cb)({type:W})],ie.prototype,"purgeOptions",void 0),(0,u._)([(0,S.Cb)({types:m.A,json:{origins:{service:{write:{target:"drawingInfo.renderer",enabled:!1}},"web-scene":{name:"layerDefinition.drawingInfo.renderer",types:m.o,write:!0}},write:{target:"layerDefinition.drawingInfo.renderer"}}})],ie.prototype,"renderer",null),(0,u._)([(0,x.r)("service","renderer",["drawingInfo.renderer","defaultSymbol"]),(0,x.r)("renderer",["layerDefinition.drawingInfo.renderer","layerDefinition.defaultSymbol"])],ie.prototype,"readRenderer",null),(0,u._)([(0,S.Cb)(J.YI)],ie.prototype,"screenSizePerspectiveEnabled",void 0),(0,u._)([(0,S.Cb)({type:$.Z,json:{origins:{service:{read:{source:"spatialReference"}}}}})],ie.prototype,"spatialReference",void 0),(0,u._)([(0,S.Cb)({json:{read:!1}})],ie.prototype,"type",void 0),(0,u._)([(0,S.Cb)(J.HQ)],ie.prototype,"url",void 0),(0,u._)([(0,S.Cb)({type:Number})],ie.prototype,"updateInterval",void 0),(0,u._)([(0,S.Cb)({type:String})],ie.prototype,"webSocketUrl",void 0),ie=(0,u._)([(0,Z.j)("esri.layers.StreamLayer")],ie);var ne=(0,j.d)({types:h.QT}),oe=ie}}]);
//# sourceMappingURL=2668.9d6da7ee.chunk.js.map