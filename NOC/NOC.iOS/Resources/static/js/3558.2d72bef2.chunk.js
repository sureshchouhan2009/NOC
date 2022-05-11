"use strict";(self.webpackChunketihadrailapp=self.webpackChunketihadrailapp||[]).push([[3558],{73558:function(e,t,i){i.r(t),i.d(t,{default:function(){return Z}});var n=i(15861),r=i(15671),a=i(43144),s=i(60136),u=i(29388),o=i(87757),l=i(27366),p=i(52639),h=i(40110),d=i(49861),c=(i(63780),i(93169),i(25243),i(69912)),y=i(95986),v=i(75391),f=i(34035),g=i(67581),w={remove:function(){},pause:function(){},resume:function(){}},b=function(e){(0,s.Z)(i,e);var t=(0,u.Z)(i);function i(){return(0,r.Z)(this,i),t.apply(this,arguments)}return(0,a.Z)(i,[{key:"initialize",value:function(){var e=this;this.graphicsView=new f.Z({requestUpdateCallback:function(){return e.requestUpdate()},view:this.view,graphics:this.layer.graphics,container:new v.Z(this.view.featuresTilingScheme)})}},{key:"attach",value:function(){this.container.addChild(this.graphicsView.container),this.handles.add(this.layer.on("graphic-update",this.graphicsView.graphicUpdateHandler),"graphicslayerview2d")}},{key:"detach",value:function(){this.container.removeAllChildren(),this.graphicsView.destroy(),this.handles.remove("graphicslayerview2d")}},{key:"hitTest",value:function(){var e=(0,n.Z)(o.mark((function e(t){return o.wrap((function(e){for(;;)switch(e.prev=e.next){case 0:return e.abrupt("return",this.graphicsView?this.graphicsView.hitTest(t):null);case 1:case"end":return e.stop()}}),e,this)})));return function(t){return e.apply(this,arguments)}}()},{key:"fetchPopupFeatures",value:function(){var e=(0,n.Z)(o.mark((function e(t){return o.wrap((function(e){for(;;)switch(e.prev=e.next){case 0:if(!this.graphicsView){e.next=2;break}return e.abrupt("return",this.graphicsView.hitTest(t).filter((function(e){return!!e.popupTemplate})));case 2:case"end":return e.stop()}}),e,this)})));return function(t){return e.apply(this,arguments)}}()},{key:"update",value:function(e){this.graphicsView.processUpdate(e)}},{key:"moveStart",value:function(){}},{key:"viewChange",value:function(){this.graphicsView.viewChange()}},{key:"moveEnd",value:function(){}},{key:"isUpdating",value:function(){return!this.graphicsView||this.graphicsView.updating}},{key:"highlight",value:function(e){var t,i,n=this;return"number"==typeof e?i=[e]:e instanceof p.Z?i=[e.uid]:Array.isArray(e)&&e.length>0?i="number"==typeof e[0]?e:e.map((function(e){return e&&e.uid})):h.Z.isCollection(e)&&e.length>0&&(i=e.map((function(e){return e&&e.uid})).toArray()),i=null==(t=i)?void 0:t.filter((function(e){return null!=e})),i.length?(this.graphicsView.addHighlight(i),{remove:function(){return n.graphicsView.removeHighlight(i)}}):w}},{key:"queryGraphics",value:function(){return Promise.resolve(this.graphicsView.graphics)}}]),i}((0,y.y)(g.Z));(0,l._)([(0,d.Cb)()],b.prototype,"graphicsView",void 0);var Z=b=(0,l._)([(0,c.j)("esri.views.2d.layers.GraphicsLayerView2D")],b)},95986:function(e,t,i){i.d(t,{y:function(){return P}});var n,r=i(15671),a=i(43144),s=i(11752),u=i(61120),o=i(60136),l=i(29388),p=i(27366),h=i(40110),d=i(60354),c=i(8537),y=i(49861),v=(i(63780),i(93169),i(25243),i(69912)),f=i(33624),g=i(67123),w=(i(32718),i(75366),function(e){(0,o.Z)(i,e);var t=(0,l.Z)(i);function i(){return(0,r.Z)(this,i),t.apply(this,arguments)}return(0,a.Z)(i)}(g.wq)),b=w=(0,p._)([(0,v.j)("esri.views.layers.support.ClipArea")],w),Z=n=function(e){(0,o.Z)(i,e);var t=(0,l.Z)(i);function i(){var e;return(0,r.Z)(this,i),(e=t.apply(this,arguments)).type="rect",e.left=null,e.right=null,e.top=null,e.bottom=null,e}return(0,a.Z)(i,[{key:"clone",value:function(){return new n({left:this.left,right:this.right,top:this.top,bottom:this.bottom})}},{key:"version",get:function(){return(this._get("version")||0)+1}}]),i}(b);(0,p._)([(0,y.Cb)({type:[Number,String],json:{write:!0}})],Z.prototype,"left",void 0),(0,p._)([(0,y.Cb)({type:[Number,String],json:{write:!0}})],Z.prototype,"right",void 0),(0,p._)([(0,y.Cb)({type:[Number,String],json:{write:!0}})],Z.prototype,"top",void 0),(0,p._)([(0,y.Cb)({type:[Number,String],json:{write:!0}})],Z.prototype,"bottom",void 0),(0,p._)([(0,y.Cb)({readOnly:!0})],Z.prototype,"version",null);var k,_=Z=n=(0,p._)([(0,v.j)("esri.views.layers.support.ClipRect")],Z),m=(i(59486),i(32238)),C=i(77981),V=i(53866),R=i(80885),q={base:m.Z,key:"type",typeMap:{extent:V.Z,polygon:R.Z}},S=k=function(e){(0,o.Z)(i,e);var t=(0,l.Z)(i);function i(){var e;return(0,r.Z)(this,i),(e=t.apply(this,arguments)).type="geometry",e.geometry=null,e}return(0,a.Z)(i,[{key:"version",get:function(){return(this._get("version")||0)+1}},{key:"clone",value:function(){return new k({geometry:this.geometry.clone()})}}]),i}(b);(0,p._)([(0,y.Cb)({types:q,json:{read:C.im,write:!0}})],S.prototype,"geometry",void 0),(0,p._)([(0,y.Cb)({readOnly:!0})],S.prototype,"version",null);var U=S=k=(0,p._)([(0,v.j)("esri.views.layers.support.Geometry")],S),j=function(e){(0,o.Z)(i,e);var t=(0,l.Z)(i);function i(){var e;return(0,r.Z)(this,i),(e=t.apply(this,arguments)).type="path",e.path=[],e}return(0,a.Z)(i,[{key:"version",get:function(){return(this._get("version")||0)+1}}]),i}(b);(0,p._)([(0,y.Cb)({type:[[[Number]]],json:{write:!0}})],j.prototype,"path",void 0),(0,p._)([(0,y.Cb)({readOnly:!0})],j.prototype,"version",null);var H=j=(0,p._)([(0,v.j)("esri.views.layers.support.Path")],j),O=h.Z.ofType({key:"type",base:b,typeMap:{rect:_,path:H,geometry:U}}),P=function(e){var t=function(e){(0,o.Z)(i,e);var t=(0,l.Z)(i);function i(){var e;return(0,r.Z)(this,i),(e=t.apply(this,arguments)).clips=new O,e.moving=!1,e.attached=!1,e.lastUpdateId=-1,e.updateRequested=!1,e}return(0,a.Z)(i,[{key:"initialize",value:function(){var e,t=this;this.container||(this.container=new f.W),this.container.fadeTransitionEnabled=!0,this.container.opacity=0,this.container.clips=this.clips,this.handles.add([(0,c.S1)(this,"suspended",(function(e){t.container&&(t.container.visible=!e),t.view&&!e&&t.updateRequested&&t.view.requestUpdate()}),!0),(0,c.S1)(this,["layer.opacity","container"],(function(){var e,i;t.container&&(t.container.opacity=null!=(e=null==(i=t.layer)?void 0:i.opacity)?e:1)}),!0),(0,c.S1)(this,["layer.blendMode"],(function(e){t.container&&(t.container.blendMode=e)}),!0),(0,c.S1)(this,["layer.effect"],(function(e){t.container&&(t.container.effect=e)}),!0),this.clips.on("change",(function(){t.container.clips=t.clips,t.notifyChange("clips")}))]),null!=(e=this.view)&&e.whenLayerView?this.view.whenLayerView(this.layer).then((function(e){e!==t||t.attached||t.destroyed||(t.attach(),t.requestUpdate(),t.attached=!0)}),(function(){})):this.when().then((function(){t.attached||t.destroyed||(t.attach(),t.requestUpdate(),t.attached=!0)}),(function(){}))}},{key:"destroy",value:function(){this.attached&&(this.detach(),this.attached=!1),this.handles.remove("initialize"),this.updateRequested=!1}},{key:"updating",get:function(){return!this.attached||!this.suspended&&(this.updateRequested||this.isUpdating())||!(!this.updatingHandles||!this.updatingHandles.updating)}},{key:"isVisibleAtScale",value:function(e){var t=!0,i=this.layer,n=i.minScale,r=i.maxScale;if(null!=n&&null!=r){var a=!n,s=!r;!a&&e<=n&&(a=!0),!s&&e>=r&&(s=!0),t=a&&s}return t}},{key:"requestUpdate",value:function(){this.destroyed||this.updateRequested||(this.updateRequested=!0,this.suspended||this.view.requestUpdate())}},{key:"processUpdate",value:function(e){!this.isFulfilled()||this.isResolved()?(this._set("updateParameters",e),this.updateRequested&&!this.suspended&&(this.updateRequested=!1,this.update(e))):this.updateRequested=!1}},{key:"hitTest",value:function(e,t){return Promise.resolve(null)}},{key:"isUpdating",value:function(){return!1}},{key:"isRendering",value:function(){return!1}},{key:"canResume",value:function(){return!!(0,s.Z)((0,u.Z)(i.prototype),"canResume",this).call(this)&&this.isVisibleAtScale(this.view.scale)}}]),i}(e);return(0,p._)([(0,y.Cb)({type:O,set:function(e){var t=(0,d.Z)(e,this._get("clips"),O);this._set("clips",t)}})],t.prototype,"clips",void 0),(0,p._)([(0,y.Cb)()],t.prototype,"moving",void 0),(0,p._)([(0,y.Cb)()],t.prototype,"attached",void 0),(0,p._)([(0,y.Cb)()],t.prototype,"container",void 0),(0,p._)([(0,y.Cb)()],t.prototype,"suspended",void 0),(0,p._)([(0,y.Cb)({readOnly:!0})],t.prototype,"updateParameters",void 0),(0,p._)([(0,y.Cb)()],t.prototype,"updateRequested",void 0),(0,p._)([(0,y.Cb)()],t.prototype,"updating",null),(0,p._)([(0,y.Cb)()],t.prototype,"view",void 0),t=(0,p._)([(0,v.j)("esri.views.2d.layers.LayerView2D")],t)}},75391:function(e,t,i){i.d(t,{Z:function(){return p}});var n=i(15671),r=i(43144),a=i(11752),s=i(61120),u=i(60136),o=i(29388),l=i(80613),p=function(e){(0,u.Z)(i,e);var t=(0,o.Z)(i);function i(){return(0,n.Z)(this,i),t.apply(this,arguments)}return(0,r.Z)(i,[{key:"renderChildren",value:function(e){this.attributeView.bindTextures(e.context,!1),this.children.some((function(e){return e.hasData}))&&((0,a.Z)((0,s.Z)(i.prototype),"renderChildren",this).call(this,e),e.drawPhase===l.jx.MAP&&this._renderChildren(e),this.hasHighlight()&&e.drawPhase===l.jx.HIGHLIGHT&&this._renderHighlight(e),this._boundsRenderer&&this._boundsRenderer.doRender(e))}},{key:"_renderHighlight",value:function(e){var t=e.painter.effects.highlight;t.bind(e),this._renderChildren(e,t.defines),t.draw(e),t.unbind()}}]),i}(i(82022).Z)},67581:function(e,t,i){i.d(t,{Z:function(){return w}});var n=i(15671),r=i(43144),a=i(60136),s=i(29388),u=i(27366),o=i(85015),l=i(91505),p=i(41691),h=i(79056),d=i(32718),c=i(92026),y=i(67426),v=i(49861),f=(i(63780),i(93169),i(25243),i(69912)),g=function(e){(0,a.Z)(i,e);var t=(0,s.Z)(i);function i(e){var r;return(0,n.Z)(this,i),(r=t.call(this,e)).layer=null,r.parent=null,r}return(0,r.Z)(i,[{key:"initialize",value:function(){var e=this;this.when().catch((function(t){if("layerview:create-error"!==t.name){var i=e.layer&&e.layer.id||"no id",n=e.layer&&e.layer.title||"no title";throw d.Z.getLogger(e.declaredClass).error("#resolve()","Failed to resolve layer view (layer title: '".concat(n,"', id: '").concat(i,"')"),t),t}}))}},{key:"fullOpacity",get:function(){return(0,c.Pt)(this.get("layer.opacity"),1)*(0,c.Pt)(this.get("parent.fullOpacity"),1)}},{key:"suspended",get:function(){return!this.canResume()}},{key:"suspendInfo",get:function(){return this.getSuspendInfo()}},{key:"legendEnabled",get:function(){return!this.suspended&&!0===this.layer.legendEnabled}},{key:"updating",get:function(){return!!(this.updatingHandles&&this.updatingHandles.updating||this.isUpdating())}},{key:"updatingProgress",get:function(){return this.updating?0:1}},{key:"visible",get:function(){var e;return!0===(null==(e=this.layer)?void 0:e.visible)},set:function(e){void 0!==e?this._override("visible",e):this._clearOverride("visible")}},{key:"canResume",value:function(){return!this.get("parent.suspended")&&this.get("view.ready")&&this.get("layer.loaded")&&this.visible||!1}},{key:"getSuspendInfo",value:function(){var e=this.parent&&this.parent.suspended?this.parent.suspendInfo:{};return this.view&&this.view.ready||(e.viewNotReady=!0),this.layer&&this.layer.loaded||(e.layerNotLoaded=!0),this.visible||(e.layerInvisible=!0),e}},{key:"isUpdating",value:function(){return!1}}]),i}((0,p.p)((0,h.I)((0,y.v)(l.Z.EventedMixin(o.Z)))));(0,u._)([(0,v.Cb)()],g.prototype,"fullOpacity",null),(0,u._)([(0,v.Cb)()],g.prototype,"layer",void 0),(0,u._)([(0,v.Cb)()],g.prototype,"parent",void 0),(0,u._)([(0,v.Cb)({readOnly:!0})],g.prototype,"suspended",null),(0,u._)([(0,v.Cb)({readOnly:!0})],g.prototype,"suspendInfo",null),(0,u._)([(0,v.Cb)({readOnly:!0})],g.prototype,"legendEnabled",null),(0,u._)([(0,v.Cb)({type:Boolean,readOnly:!0})],g.prototype,"updating",null),(0,u._)([(0,v.Cb)({readOnly:!0})],g.prototype,"updatingProgress",null),(0,u._)([(0,v.Cb)()],g.prototype,"visible",null);var w=g=(0,u._)([(0,f.j)("esri.views.layers.LayerView")],g)}}]);
//# sourceMappingURL=3558.2d72bef2.chunk.js.map