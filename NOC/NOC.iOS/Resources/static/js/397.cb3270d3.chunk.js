"use strict";(self.webpackChunketihadrailapp=self.webpackChunketihadrailapp||[]).push([[397],{50397:function(e,t,r){r.r(t),r.d(t,{default:function(){return g}});var n=r(15861),i=r(1413),a=r(15671),o=r(43144),s=r(11752),c=r(61120),l=r(60136),u=r(29388),p=r(87757),y=r(27366),d=r(10064),h=r(92026),f=r(49861),v=(r(63780),r(93169),r(25243),r(69912)),m=r(49818),O=r(99288),b=r(31666);function _(e,t){if((0,h.Wi)(e)&&(0,h.Wi)(t))return null;var r={};return(0,h.pC)(t)&&(r.geometry=t.toJSON()),(0,h.pC)(e)&&(r.where=e),r}var S=function(e){(0,l.Z)(r,e);var t=(0,u.Z)(r);function r(){var e;return(0,a.Z)(this,r),(e=t.apply(this,arguments))._enabledDataReceived=!1,e.errorString=null,e.connectionStatus="disconnected",e}return(0,o.Z)(r,[{key:"initialize",value:function(){var e=this;this.handles.add([this.layer.watch("purgeOptions",(function(){return e._update()}))])}},{key:"destroy",value:function(){this.connectionStatus="disconnected"}},{key:"connectionError",get:function(){if(this.errorString)return new d.Z("stream-controller",this.errorString)}},{key:"on",value:function(e,t){"data-received"===e&&(this._enabledDataReceived=!0,this._proxy.enableEvent("data-received",!0));var n=(0,s.Z)((0,c.Z)(r.prototype),"on",this).call(this,e,t),i=this;return{remove:function(){n.remove(),"data-received"===e&&(i._proxy.closed||i.hasEventListener("data-received")||i._proxy.enableEvent("data-received",!1))}}}},{key:"queryLatestObservations",value:function(e,t){var r=this;if(!this.layer.timeInfo.endField&&!this.layer.timeInfo.startField)throw new d.Z("streamlayer-no-timeField","queryLatestObservation can only be used with services that define a TrackIdField");return this._proxy.queryLatestObservations(this._cleanUpQuery(e),t).then((function(e){var t=m.default.fromJSON(e);return t.features.forEach((function(e){e.layer=r.layer,e.sourceLayer=r.layer})),t}))}},{key:"_createClientOptions",value:function(){var e=this;return(0,i.Z)((0,i.Z)({},(0,s.Z)((0,c.Z)(r.prototype),"_createClientOptions",this).call(this)),{},{setProperty:function(t){e.set(t.propertyName,t.value)}})}},{key:"_createTileRendererHash",value:function(e){var t="".concat(JSON.stringify(this.layer.purgeOptions),".").concat(JSON.stringify(_(this.layer.definitionExpression,this.layer.geometryDefinition)),")");return(0,s.Z)((0,c.Z)(r.prototype),"_createTileRendererHash",this).call(this,e)+t}},{key:"_createServiceOptions",value:function(){var e=(0,n.Z)(p.mark((function e(){var t,r,n,i,a,o;return p.wrap((function(e){for(;;)switch(e.prev=e.next){case 0:return t=this.layer,r=t.objectIdField,n=t.fields.map((function(e){return e.toJSON()})),i=(0,b.oq)(t.geometryType),a=t.timeInfo&&t.timeInfo.toJSON()||null,o=t.spatialReference?t.spatialReference.toJSON():null,e.abrupt("return",{type:"stream",fields:n,geometryType:i,objectIdField:r,timeInfo:a,source:this.layer.parsedUrl,serviceFilter:_(this.layer.definitionExpression,this.layer.geometryDefinition),purgeOptions:this.layer.purgeOptions.toJSON(),enableDataReceived:this._enabledDataReceived,spatialReference:o,maxReconnectionAttempts:this.layer.maxReconnectionAttempts,maxReconnectionInterval:this.layer.maxReconnectionInterval,updateInterval:this.layer.updateInterval,customParameters:t.customParameters});case 2:case"end":return e.stop()}}),e,this)})));return function(){return e.apply(this,arguments)}}()}]),r}(O.default);(0,y._)([(0,f.Cb)()],S.prototype,"errorString",void 0),(0,y._)([(0,f.Cb)({readOnly:!0})],S.prototype,"connectionError",null),(0,y._)([(0,f.Cb)()],S.prototype,"connectionStatus",void 0);var g=S=(0,y._)([(0,v.j)("esri.views.2d.layers.StreamLayerView2D")],S)}}]);
//# sourceMappingURL=397.cb3270d3.chunk.js.map