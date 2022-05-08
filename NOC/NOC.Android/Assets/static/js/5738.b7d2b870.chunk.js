"use strict";(self.webpackChunketihadrailapp=self.webpackChunketihadrailapp||[]).push([[5738],{4321:function(e,t,i){i.d(t,{Y:function(){return c}});var n=i(15671),r=i(43144),a=i(60136),u=i(29388),s=i(27366),l=(i(32718),i(25243),i(63780),i(93169),i(75366),i(69912)),h=i(9849),c=function(e){var t=function(e){(0,a.Z)(i,e);var t=(0,u.Z)(i);function i(){return(0,n.Z)(this,i),t.apply(this,arguments)}return(0,r.Z)(i,[{key:"attach",value:function(){this.view.timeline.record("".concat(this.layer.title," (BitmapTileLayer) Attach")),this._bitmapView=new h.s(this._tileInfoView),this.container.addChild(this._bitmapView)}},{key:"detach",value:function(){var e;this.container.removeChild(this._bitmapView),null==(e=this._bitmapView)||e.removeAllChildren()}}]),i}(e);return t=(0,s._)([(0,l.j)("esri.views.2d.layers.BitmapTileLayerView2D")],t)}},5738:function(e,t,i){i.r(t),i.d(t,{default:function(){return R}});var n=i(1413),r=i(15861),a=i(29439),u=i(15671),s=i(43144),l=i(11752),h=i(61120),c=i(60136),o=i(29388),f=i(87757),p=i(27366),d=i(32718),v=i(66978),y=i(49861),w=(i(63780),i(93169),i(25243),i(69912)),_=i(4321),g=i(95986),m=i(34622),k=i(37995),I=i(73828),b=i(32344),x=i(85269),Z=i(67581),T=i(13107),V=[102113,102100,3857,3785,900913],S=[0,0],M=d.Z.getLogger("esri.views.2d.layers.WMTSLayerView2D"),C=function(e){(0,c.Z)(i,e);var t=(0,o.Z)(i);function i(){var e;return(0,u.Z)(this,i),(e=t.apply(this,arguments))._tileStrategy=null,e._fetchQueue=null,e._tileRequests=new Map,e.layer=null,e}return(0,s.Z)(i,[{key:"tileMatrixSet",get:function(){if(this.layer.activeLayer.tileMatrixSetId)return this.layer.activeLayer.tileMatrixSet;var e=this._getTileMatrixSetBySpatialReference(this.layer.activeLayer);return e?(this.layer.activeLayer.tileMatrixSetId=e.id,e):null}},{key:"update",value:function(e){this._fetchQueue.pause(),this._fetchQueue.state=e.state,this._tileStrategy.update(e),this._fetchQueue.resume(),this.notifyChange("updating")}},{key:"attach",value:function(){var e=this;if(this.tileMatrixSet){var t=this.tileMatrixSet.tileInfo;this._tileInfoView=new k.Z(t),this._fetchQueue=new b.Z({tileInfoView:this._tileInfoView,concurrency:16,process:function(t,i){return e.fetchTile(t,i)}}),this._tileStrategy=new x.Z({cachePolicy:"keep",resampling:!0,acquireTile:function(t){return e.acquireTile(t)},releaseTile:function(t){return e.releaseTile(t)},tileInfoView:this._tileInfoView}),this.handles.add(this.watch(["layer.activeLayer.styleId","tileMatrixSet"],(function(){return e._refresh()})),this.declaredClass),(0,l.Z)((0,h.Z)(i.prototype),"attach",this).call(this)}}},{key:"detach",value:function(){var e,t;(0,l.Z)((0,h.Z)(i.prototype),"detach",this).call(this),this.handles.remove(this.declaredClass),null==(e=this._tileStrategy)||e.destroy(),null==(t=this._fetchQueue)||t.destroy(),this._fetchQueue=this._tileStrategy=this._tileInfoView=null}},{key:"moveStart",value:function(){this.requestUpdate()}},{key:"viewChange",value:function(){this.requestUpdate()}},{key:"moveEnd",value:function(){this.requestUpdate()}},{key:"releaseTile",value:function(e){this._fetchQueue.abort(e.key.id),this._bitmapView.removeChild(e),e.once("detach",(function(){return e.destroy()})),this.requestUpdate()}},{key:"acquireTile",value:function(e){var t,i,n,r,u=this._bitmapView.createTile(e),s=u.bitmap;return t=this._tileInfoView.getTileCoords(S,u.key),i=(0,a.Z)(t,2),s.x=i[0],s.y=i[1],s.resolution=this._tileInfoView.getTileResolution(u.key),n=this._tileInfoView.tileInfo.size,r=(0,a.Z)(n,2),s.width=r[0],s.height=r[1],this._enqueueTileFetch(u),this._bitmapView.addChild(u),this.requestUpdate(),u}},{key:"doRefresh",value:function(){var e=(0,r.Z)(f.mark((function e(){return f.wrap((function(e){for(;;)switch(e.prev=e.next){case 0:this.updateRequested||this.suspended||this._refresh();case 1:case"end":return e.stop()}}),e,this)})));return function(){return e.apply(this,arguments)}}()},{key:"isUpdating",value:function(){return this._fetchQueue.length>0}},{key:"fetchTile",value:function(){var e=(0,r.Z)(f.mark((function e(t){var i,r,a,u,s,l,h,c,o,p,d=arguments;return f.wrap((function(e){for(;;)switch(e.prev=e.next){case 0:if(i=d.length>1&&void 0!==d[1]?d[1]:{},r="tilemapCache"in this.layer?this.layer.tilemapCache:null,a=i.signal,u=i.resamplingLevel,s=void 0===u?0:u,r){e.next=4;break}return e.abrupt("return",this._fetchImage(t,a));case 4:return l=new I.Z(0,0,0,0),e.prev=5,e.next=8,r.fetchAvailabilityUpsample(t.level,t.row,t.col,l,{signal:a});case 8:return e.next=10,this._fetchImage(l,a);case 10:h=e.sent,e.next=26;break;case 13:if(e.prev=13,e.t0=e.catch(5),!(0,v.D_)(e.t0)){e.next=17;break}throw e.t0;case 17:if(!(s<3)){e.next=25;break}if(!(c=this._tileInfoView.getTileParentId(t.id))){e.next=25;break}return o=new I.Z(c),e.next=23,this.fetchTile(o,(0,n.Z)((0,n.Z)({},i),{},{resamplingLevel:s+1}));case 23:return p=e.sent,e.abrupt("return",(0,m.i)(this._tileInfoView,p,o,t));case 25:throw e.t0;case 26:return e.abrupt("return",(0,m.i)(this._tileInfoView,h,l,t));case 27:case"end":return e.stop()}}),e,this,[[5,13]])})));return function(t){return e.apply(this,arguments)}}()},{key:"canResume",value:function(){var e=(0,l.Z)((0,h.Z)(i.prototype),"canResume",this).call(this);return e?null!==this.tileMatrixSet:e}},{key:"_enqueueTileFetch",value:function(){var e=(0,r.Z)(f.mark((function e(t){var i,n=this;return f.wrap((function(e){for(;;)switch(e.prev=e.next){case 0:if(this._fetchQueue.has(t.key.id)){e.next=12;break}return e.prev=1,e.next=4,this._fetchQueue.push(t.key);case 4:i=e.sent,t.bitmap.source=i,t.bitmap.width=this._tileInfoView.tileInfo.size[0],t.bitmap.height=this._tileInfoView.tileInfo.size[1],t.once("attach",(function(){return n.requestUpdate()})),e.next=11;break;case 8:e.prev=8,e.t0=e.catch(1),(0,v.D_)(e.t0)||M.error(e.t0);case 11:this.requestUpdate();case 12:case"end":return e.stop()}}),e,this,[[1,8]])})));return function(t){return e.apply(this,arguments)}}()},{key:"_fetchImage",value:function(){var e=(0,r.Z)(f.mark((function e(t,i){return f.wrap((function(e){for(;;)switch(e.prev=e.next){case 0:return e.abrupt("return",this.layer.fetchTile(t.level,t.row,t.col,{signal:i}));case 1:case"end":return e.stop()}}),e,this)})));return function(t,i){return e.apply(this,arguments)}}()},{key:"_refresh",value:function(){var e=this;this._fetchQueue.reset(),this._tileStrategy.tiles.forEach((function(t){if(t.bitmap.source){var i={id:t.key.id,fulfilled:!1,promise:e._fetchQueue.push(t.key).then((function(e){t.bitmap.source=e})).catch((function(e){(0,v.D_)(e)||(t.bitmap.source=null)})).finally((function(){t.requestRender(),e.notifyChange("updating"),i.fulfilled=!0}))};e._tileRequests.set(t,i)}})),this.notifyChange("updating")}},{key:"_getTileMatrixSetBySpatialReference",value:function(e){var t=this.view.spatialReference;if(!e.tileMatrixSets)return null;var i=e.tileMatrixSets.find((function(e){return e.tileInfo.spatialReference.wkid===t.wkid}));return!i&&t.isWebMercator&&(i=e.tileMatrixSets.find((function(e){return V.indexOf(e.tileInfo.spatialReference.wkid)>-1}))),i}}]),i}((0,T.y)((0,_.Y)((0,g.y)(Z.Z))));(0,p._)([(0,y.Cb)()],C.prototype,"suspended",void 0),(0,p._)([(0,y.Cb)({readOnly:!0})],C.prototype,"tileMatrixSet",null);var R=C=(0,p._)([(0,w.j)("esri.views.2d.layers.WMTSLayerView2D")],C)},34622:function(e,t,i){i.d(t,{V:function(){return a},i:function(){return r}});var n=i(29439);function r(e,t,i,n){if(i.level===n.level)return t;var r=e.tileInfo.size,u=e.getTileResolution(i.level),s=e.getTileResolution(n.level),l=e.getLODInfoAt(n.level),h=l.getXForColumn(n.col),c=l.getYForRow(n.row),o=(l=e.getLODInfoAt(i.level)).getXForColumn(i.col),f=l.getYForRow(i.row),p=function(e){return e instanceof HTMLImageElement?e.naturalWidth:e.width}(t)/r[0],d=function(e){return e instanceof HTMLImageElement?e.naturalHeight:e.height}(t)/r[1],v=Math.round(p*((h-o)/u)),y=Math.round(d*(-(c-f)/u)),w=Math.round(p*r[0]*(s/u)),_=Math.round(d*r[1]*(s/u)),g=a(r);return g.getContext("2d").drawImage(t,v,y,w,_,0,0,r[0],r[1]),g}function a(e){var t,i,r=document.createElement("canvas");return t=e,i=(0,n.Z)(t,2),r.width=i[0],r.height=i[1],r}}}]);
//# sourceMappingURL=5738.b7d2b870.chunk.js.map