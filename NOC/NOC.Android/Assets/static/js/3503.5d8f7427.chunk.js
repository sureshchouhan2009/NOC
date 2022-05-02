"use strict";(self.webpackChunketihadrailapp=self.webpackChunketihadrailapp||[]).push([[3503],{53503:function(t,i,e){e.r(i),e.d(i,{default:function(){return I}});var n=e(93433),r=e(37762),a=e(15671),s=e(43144),o=e(60136),h=e(29388),l=e(27366),c=(e(51508),e(91505)),u=e(100),p=e(84652),v=e(92026),y=e(8537),f=e(49861),d=(e(25243),e(69912)),g=e(93655),_=e(20008),m=e(83089),b=(0,s.Z)((function t(i,e,n,r,s){(0,a.Z)(this,t),this.graphic=i,this.index=e,this.x=n,this.y=r,this.viewEvent=s,this.type="graphic-click"})),x=(0,s.Z)((function t(i,e,n,r,s){(0,a.Z)(this,t),this.graphic=i,this.index=e,this.x=n,this.y=r,this.viewEvent=s,this.type="graphic-double-click"})),w=function(){function t(i,e,n,r,s,o,h,l,c,u){(0,a.Z)(this,t),this.graphic=i,this.allGraphics=e,this.index=n,this.x=r,this.y=s,this.dx=o,this.dy=h,this.totalDx=l,this.totalDy=c,this.viewEvent=u,this.defaultPrevented=!1,this.type="graphic-move-start"}return(0,s.Z)(t,[{key:"preventDefault",value:function(){this.defaultPrevented=!0}}]),t}(),k=function(){function t(i,e,n,r,s,o,h,l,c,u){(0,a.Z)(this,t),this.graphic=i,this.allGraphics=e,this.index=n,this.x=r,this.y=s,this.dx=o,this.dy=h,this.totalDx=l,this.totalDy=c,this.viewEvent=u,this.defaultPrevented=!1,this.type="graphic-move"}return(0,s.Z)(t,[{key:"preventDefault",value:function(){this.defaultPrevented=!0}}]),t}(),G=function(){function t(i,e,n,r,s,o,h,l,c,u){(0,a.Z)(this,t),this.graphic=i,this.allGraphics=e,this.index=n,this.x=r,this.y=s,this.dx=o,this.dy=h,this.totalDx=l,this.totalDy=c,this.viewEvent=u,this.defaultPrevented=!1,this.type="graphic-move-stop"}return(0,s.Z)(t,[{key:"preventDefault",value:function(){this.defaultPrevented=!0}}]),t}(),C=(0,s.Z)((function t(i,e,n,r,s){(0,a.Z)(this,t),this.graphic=i,this.index=e,this.x=n,this.y=r,this.viewEvent=s,this.type="graphic-pointer-over"})),S=(0,s.Z)((function t(i,e,n,r,s){(0,a.Z)(this,t),this.graphic=i,this.index=e,this.x=n,this.y=r,this.viewEvent=s,this.type="graphic-pointer-out"})),Z=(0,s.Z)((function t(i,e,n,r,s){(0,a.Z)(this,t),this.graphic=i,this.index=e,this.x=n,this.y=r,this.viewEvent=s,this.type="graphic-pointer-down"})),O=(0,s.Z)((function t(i,e,n,r,s){(0,a.Z)(this,t),this.graphic=i,this.index=e,this.x=n,this.y=r,this.viewEvent=s,this.type="graphic-pointer-up"})),D=e(31235),M=e(2346),E=e(72612),P=e(16072),H=e(16851),T=e(61459),U=function(t){(0,o.Z)(e,t);var i=(0,h.Z)(e);function e(t){var n;return(0,a.Z)(this,e),(n=i.call(this,t))._activeGraphic=null,n._indicators=[],n._dragEvent=null,n._handles=new u.Z,n._hoverGraphic=null,n._initialDragGeometry=null,n._viewHandles=new u.Z,n._manipulators=[],n._layerViews=null,n.type="graphic-mover",n.callbacks={onGraphicClick:function(){},onGraphicDoubleClick:function(){},onGraphicMoveStart:function(){},onGraphicMove:function(){},onGraphicMoveStop:function(){},onGraphicPointerOver:function(){},onGraphicPointerOut:function(){},onGraphicPointerDown:function(){},onGraphicPointerUp:function(){}},n.enableMoveAllGraphics=!1,n.graphics=[],n.indicatorsEnabled=!0,n.layer=new g.Z({listMode:"hide",internal:!0,title:"GraphicMover highlight layer"}),n.view=null,n}return(0,s.Z)(e,[{key:"initialize",value:function(){var t=this;(0,m.p)(this.view,this.layer),this.refresh(),this._handles.add([(0,y.YP)(this,["graphics","graphics.length"],(function(){return t.refresh()})),(0,y.N1)(this,"view.ready",(function(){t._viewHandles.add([t.view.on("immediate-click",(function(i){return t._clickHandler(i)}),D.f.TOOL),t.view.on("double-click",(function(i){return t._doubleClickHandler(i)}),D.f.TOOL),t.view.on("pointer-down",(function(i){return t._pointerDownHandler(i)}),D.f.TOOL),t.view.on("pointer-move",(function(i){return t._pointerMoveHandler(i)}),D.f.TOOL),t.view.on("pointer-up",(function(i){return t._pointerUpHandler(i)}),D.f.TOOL),t.view.on("drag",(function(i){return t._dragHandler(i)}),D.f.TOOL),t.view.on("key-down",(function(i){return t._keyDownHandler(i)}),D.f.TOOL)])}))])}},{key:"destroy",value:function(){var t;this._removeIndicators(),null==(t=this.view.map)||t.remove(this.layer),this.layer.destroy(),this.reset(),this._manipulators.forEach((function(t){return t.destroy()})),this._manipulators=null,this._handles=(0,v.SC)(this._handles),this._viewHandles=(0,v.SC)(this._viewHandles)}},{key:"state",get:function(){var t=!!this.get("view.ready"),i=!!this.get("graphics.length"),e=this._activeGraphic;return t&&i?e?"moving":"active":t?"ready":"disabled"}},{key:"refresh",value:function(){this._setUpIndicators(),this._setUpManipulators(),this._syncLayerViews()}},{key:"reset",value:function(){this._activeGraphic=null,this._hoverGraphic=null,this._dragEvent=null}},{key:"updateGeometry",value:function(t,i){var e=this.graphics[t];e&&(e.set("geometry",i),this._setUpIndicators())}},{key:"_clickHandler",value:function(t){var i=this._findTargetGraphic((0,E.vT)(t));if(i){var e=new b(i,this.graphics.indexOf(i),t.x,t.y,t);this.emit("graphic-click",e),this.callbacks.onGraphicClick&&this.callbacks.onGraphicClick(e)}}},{key:"_doubleClickHandler",value:function(t){var i=this._findTargetGraphic((0,E.vT)(t));if(i){var e=new x(i,this.graphics.indexOf(i),t.x,t.y,t);this.emit("graphic-double-click",e),this.callbacks.onGraphicDoubleClick&&this.callbacks.onGraphicDoubleClick(e)}}},{key:"_pointerDownHandler",value:function(t){var i=this._findTargetGraphic((0,E.vT)(t));if(i){this._activeGraphic=i;var e=t.x,n=t.y,r=new Z(i,this.graphics.indexOf(i),e,n,t);this.emit("graphic-pointer-down",r),this.callbacks.onGraphicPointerDown&&this.callbacks.onGraphicPointerDown(r)}else this._activeGraphic=null}},{key:"_pointerUpHandler",value:function(t){if(this._activeGraphic){var i=t.x,e=t.y,n=this.graphics.indexOf(this._activeGraphic),r=new O(this._activeGraphic,n,i,e,t);this.emit("graphic-pointer-up",r),this.callbacks.onGraphicPointerUp&&this.callbacks.onGraphicPointerUp(r)}}},{key:"_pointerMoveHandler",value:function(t){if(!this._dragEvent){var i=this._findTargetGraphic((0,E.vT)(t));if(i){var e=t.x,n=t.y;if(this._hoverGraphic){if(this._hoverGraphic===i)return;var r=this.graphics.indexOf(this._hoverGraphic),a=new S(this.graphics[r],r,e,n,t);this._hoverGraphic=null,this.emit("graphic-pointer-out",a),this.callbacks.onGraphicPointerOut&&this.callbacks.onGraphicPointerOut(a)}var s=this.graphics.indexOf(i),o=new C(i,s,e,n,t);return this._hoverGraphic=i,this.emit("graphic-pointer-over",o),void(this.callbacks.onGraphicPointerOver&&this.callbacks.onGraphicPointerOver(o))}if(this._hoverGraphic){var h=t.x,l=t.y,c=this.graphics.indexOf(this._hoverGraphic),u=new S(this.graphics[c],c,h,l,t);this._hoverGraphic=null,this.emit("graphic-pointer-out",u),this.callbacks.onGraphicPointerOut&&this.callbacks.onGraphicPointerOut(u)}}}},{key:"_dragHandler",value:function(t){var i=this;if(("start"===t.action||this._dragEvent)&&this._activeGraphic&&this._activeGraphic.geometry){"start"===t.action&&this._removeIndicators(),t.stopPropagation();var e=t.action,n=t.x,r=t.y,a=this.graphics.indexOf(this._activeGraphic),s=this._dragEvent?n-this._dragEvent.x:0,o=this._dragEvent?r-this._dragEvent.y:0,h=n-t.origin.x,l=r-t.origin.y,c="start"===e?this._activeGraphic.geometry:this._initialDragGeometry,u=(0,_.e7)(c,h,l,this.view);if(this._activeGraphic.geometry=u,this.enableMoveAllGraphics&&this.graphics.forEach((function(t){t!==i._activeGraphic&&(t.geometry=(0,_.e7)(t.geometry,s,o,i.view))})),this._dragEvent=t,"start"===e){this._initialDragGeometry=(0,p.d9)(c);var v=new w(this._activeGraphic,this.graphics,a,n,r,s,o,h,l,t);this.emit("graphic-move-start",v),this.callbacks.onGraphicMoveStart&&this.callbacks.onGraphicMoveStart(v),v.defaultPrevented&&this._activeGraphic.set("geometry",c)}else if("update"===e){var y=new k(this._activeGraphic,this.graphics,a,n,r,s,o,h,l,t);this.emit("graphic-move",y),this.callbacks.onGraphicMove&&this.callbacks.onGraphicMove(y),y.defaultPrevented&&(this._activeGraphic.geometry=c)}else{var f=new G(this._activeGraphic,this.graphics,a,n,r,s,o,h,l,t);this._dragEvent=null,this._activeGraphic=null,this._setUpIndicators(),this.emit("graphic-move-stop",f),this.callbacks.onGraphicMoveStop&&this.callbacks.onGraphicMoveStop(f),f.defaultPrevented&&(this.graphics[a].set("geometry",this._initialDragGeometry),this._setUpIndicators()),this._initialDragGeometry=null}}}},{key:"_keyDownHandler",value:function(t){"a"!==t.key&&"d"!==t.key&&"n"!==t.key||"moving"!==this.state||t.stopPropagation()}},{key:"_findTargetGraphic",value:function(t){var i=this,e=this.view.toMap(t),n=null,r=Number.MAX_VALUE;this._syncLayerViews();var a=this._layerViews.flatMap((function(t){return"graphicsViews"in t?Array.from(t.graphicsViews(),(function(t){return t.hitTest(e)})).flat():t.graphicsView.hitTest(e)})).filter((function(t){return i.graphics.indexOf(t)>-1}));return a.length?a[0]:(this._manipulators.forEach((function(i){var e=i.intersectionDistance(t);(0,v.pC)(e)&&e<r&&(r=e,n=i.graphic)})),n)}},{key:"_syncLayerViews",value:function(){var t=this;this._layerViews=[];var i,e=new Set,a=(0,r.Z)(this.graphics);try{var s=function(){var n=i.value,r=t.view.allLayerViews.find((function(t){var i=t.layer;return"sublayers"in i&&(0,v.pC)(i.sublayers)&&!!i.sublayers.find((function(t){return t===n.layer}))||i===n.layer}));r&&e.add(r)};for(a.s();!(i=a.n()).done;)s()}catch(o){a.e(o)}finally{a.f()}this._layerViews=(0,n.Z)(e)}},{key:"_setUpManipulators",value:function(){var t=this.graphics,i=this.view;this._manipulators.forEach((function(t){return t.destroy()})),this._manipulators=null!=t&&t.length?t.map((function(t){return new M.L({graphic:t,view:i})})):[]}},{key:"_setUpIndicators",value:function(){var t,i=this;this._removeIndicators(),this.indicatorsEnabled&&(this._indicators=(null==(t=this.graphics)?void 0:t.map((function(t){var e=t.clone();return e.symbol=i._getSymbolForIndicator(t),e})))||[],this.layer.addMany(this._indicators))}},{key:"_removeIndicators",value:function(){this._indicators.length&&(this.layer.removeMany(this._indicators),this._indicators.forEach((function(t){return t.destroy()})),this._indicators=[])}},{key:"_getSymbolForIndicator",value:function(t){if((0,v.Wi)(t.symbol))return null;switch(t.symbol.type){case"cim":return new P.default({style:"circle",size:12,color:[0,0,0,0],outline:{color:[255,127,0,1],width:1}});case"picture-marker":var i=t.symbol,e=i.xoffset,n=i.yoffset,r=i.height,a=i.width,s=r===a?a:Math.max(r,a);return new P.default({xoffset:e,yoffset:n,size:s,style:"square",color:[0,0,0,0],outline:{color:[255,127,0,1],width:1}});case"simple-marker":var o=t.symbol,h=o.xoffset,l=o.yoffset,c=o.size,u=o.style;return new P.default({xoffset:h,yoffset:l,style:"circle"===u?"circle":"square",size:c+2,color:[0,0,0,0],outline:{color:[255,127,0,1],width:1}});case"simple-fill":return new T.default({color:[0,0,0,0],outline:{style:"dash",color:[255,127,0,1],width:1}});case"simple-line":return new H.default({color:[255,127,0,1],style:"dash",width:1});case"text":var p=t.symbol,y=p.xoffset,f=p.yoffset;return new P.default({xoffset:y,yoffset:f,size:12,color:[0,0,0,0],outline:{color:[255,127,0,1],width:1}});default:return null}}}]),e}(c.Z.EventedAccessor);(0,l._)([(0,f.Cb)()],U.prototype,"_activeGraphic",void 0),(0,l._)([(0,f.Cb)({readOnly:!0})],U.prototype,"type",void 0),(0,l._)([(0,f.Cb)()],U.prototype,"callbacks",void 0),(0,l._)([(0,f.Cb)()],U.prototype,"enableMoveAllGraphics",void 0),(0,l._)([(0,f.Cb)()],U.prototype,"graphics",void 0),(0,l._)([(0,f.Cb)()],U.prototype,"indicatorsEnabled",void 0),(0,l._)([(0,f.Cb)()],U.prototype,"layer",void 0),(0,l._)([(0,f.Cb)({readOnly:!0})],U.prototype,"state",null),(0,l._)([(0,f.Cb)()],U.prototype,"view",void 0);var I=U=(0,l._)([(0,d.j)("esri.views.draw.support.GraphicMover")],U)},20008:function(t,i,e){e.d(i,{e7:function(){return l},cM:function(){return p},Ru:function(){return u},pB:function(){return h},bA:function(){return c}});var n=e(29439),r=e(16889),a=e(65156),s=e(376),o=e(69662);function h(t,i,e,n){if(null==n||t.hasZ||(n=void 0),"point"===t.type)return t.x+=i,t.y+=e,t.hasZ&&null!=n&&(t.z+=n),t;if("multipoint"===t.type){for(var r=t.points,a=0;a<r.length;a++)r[a]=v(r[a],i,e,n);return t}if("extent"===t.type)return t.xmin+=i,t.xmax+=i,t.ymin+=e,t.ymax+=e,null!=n&&(t.zmin+=n,t.zmax+=n),t;for(var s=(0,o.nA)(t),h="polyline"===t.type?t.paths:t.rings,l=0;l<s.length;l++)for(var c=s[l],u=0;u<c.length;u++)c[u]=v(c[u],i,e,n);return"paths"in t?t.paths=h:t.rings=h,t}function l(t,i,e,n,r){var a=t.clone(),s=n.resolution;if("point"===a.type){if(r)h(a,i*s,-e*s);else{var l=n.state.transform,c=n.state.inverseTransform,u=l[0]*a.x+l[2]*a.y+l[4],p=l[1]*a.x+l[3]*a.y+l[5];a.x=c[0]*(u+i)+c[2]*(p+e)+c[4],a.y=c[1]*(u+i)+c[3]*(p+e)+c[5]}return a}if("multipoint"===a.type){if(r)h(a,i*s,-e*s);else for(var v=a.points,f=n.state.transform,d=n.state.inverseTransform,g=0;g<v.length;g++){var _=v[g],m=f[0]*_[0]+f[2]*_[1]+f[4],b=f[1]*_[0]+f[3]*_[1]+f[5],x=d[0]*(m+i)+d[2]*(b+e)+d[4],w=d[1]*(m+i)+d[3]*(b+e)+d[5];v[g]=y(_,x,w,void 0)}return a}if("extent"===a.type){if(r)h(a,i*s,-e*s);else{var k=n.state.transform,G=n.state.inverseTransform,C=k[0]*a.xmin+k[2]*a.ymin+k[4],S=k[1]*a.xmin+k[3]*a.ymin+k[5],Z=k[0]*a.xmax+k[2]*a.ymax+k[4],O=k[1]*a.xmax+k[3]*a.ymax+k[5];a.xmin=G[0]*(C+i)+G[2]*(S+e)+G[4],a.ymin=G[1]*(C+i)+G[3]*(S+e)+G[5],a.xmax=G[0]*(Z+i)+G[2]*(O+e)+G[4],a.ymax=G[1]*(Z+i)+G[3]*(O+e)+G[5]}return a}if(r)h(a,i*s,-e*s);else{for(var D=(0,o.nA)(a),M="polyline"===a.type?a.paths:a.rings,E=n.state.transform,P=n.state.inverseTransform,H=0;H<D.length;H++)for(var T=D[H],U=0;U<T.length;U++){var I=T[U],L=E[0]*I[0]+E[2]*I[1]+E[4],V=E[1]*I[0]+E[3]*I[1]+E[5],A=P[0]*(L+i)+P[2]*(V+e)+P[4],z=P[1]*(L+i)+P[3]*(V+e)+P[5];T[U]=y(I,A,z,void 0)}"paths"in a?a.paths=M:a.rings=M}return a}function c(t,i,e,r){if("point"===t.type){var h=t.x,l=t.y,c=r?r[0]:h,u=r?r[1]:l,p=t.clone(),v=(h-c)*i+c,f=(l-u)*e+u;return p.x=v,p.y=f,p}if("multipoint"===t.type){for(var d=(0,o.nA)(t),g=(0,a.Ue)(),_=(0,s.C6)(g,[d]),m=(0,n.Z)(_,4),b=m[0],x=m[1],w=m[2],k=m[3],G=r?r[0]:(b+w)/2,C=r?r[1]:(k+x)/2,S=t.clone(),Z=S.points,O=0;O<Z.length;O++){var D=Z[O],M=(0,n.Z)(D,2),E=(M[0]-G)*i+G,P=(M[1]-C)*e+C;Z[O]=y(D,E,P,void 0)}return S}if("extent"===t.type){var H=t.xmin,T=t.xmax,U=t.ymin,I=t.ymax,L=r?r[0]:(H+T)/2,V=r?r[1]:(I+U)/2,A=t.clone();if(A.xmin=(H-L)*i+L,A.ymax=(I-V)*e+V,A.xmax=(T-L)*i+L,A.ymin=(U-V)*e+V,A.xmin>A.xmax){var z=A.xmin,F=A.xmax;A.xmin=F,A.xmax=z}if(A.ymin>A.ymax){var q=A.ymin,N=A.ymax;A.ymin=N,A.ymax=q}return A}for(var R=(0,o.nA)(t),W=(0,a.Ue)(),j=(0,s.C6)(W,R),B=(0,n.Z)(j,4),K=B[0],X=B[1],Y=B[2],J=B[3],Q=r?r[0]:(K+Y)/2,$=r?r[1]:(J+X)/2,tt=t.clone(),it="polyline"===tt.type?tt.paths:tt.rings,et=0;et<R.length;et++)for(var nt=R[et],rt=0;rt<nt.length;rt++){var at=nt[rt],st=(0,n.Z)(at,2),ot=(st[0]-Q)*i+Q,ht=(st[1]-$)*e+$;it[et][rt]=y(at,ot,ht,void 0)}return"paths"in tt?tt.paths=it:tt.rings=it,tt}function u(t,i,e,n,r,a){var s=Math.sqrt((e-t)*(e-t)+(n-i)*(n-i));return Math.sqrt((r-t)*(r-t)+(a-i)*(a-i))/s}function p(t,i,e){var n=Math.atan2(i.y-e.y,i.x-e.x)-Math.atan2(t.y-e.y,t.x-e.x),a=Math.atan2(Math.sin(n),Math.cos(n));return(0,r.BV)(a)}function v(t,i,e,n){return y(t,t[0]+i,t[1]+e,null!=t[2]&&null!=n?t[2]+n:void 0)}function y(t,i,e,n){var r=[i,e];return t.length>2&&r.push(null!=n?n:t[2]),t.length>3&&r.push(t[3]),r}},2346:function(t,i,e){e.d(i,{L:function(){return w}});var n=e(15671),r=e(43144),a=e(60136),s=e(29388),o=e(27366),h=e(85015),l=e(91505),c=e(92026),u=e(17842),p=e(49861),v=(e(63780),e(93169),e(25243),e(69912)),y=e(88396),f=e(11186),d=e(71353),g=e(60176),_=e(74509),m=e(61574),b=e(64575),x=e(45008),w=function(t){(0,a.Z)(e,t);var i=(0,s.Z)(e);function e(t){var r;return(0,n.Z)(this,e),(r=i.call(this,t)).layer=null,r.interactive=!0,r.selectable=!1,r.grabbable=!0,r.dragging=!1,r.cursor=null,r.events=new l.Z.EventEmitter,r._circleCollisionCache=null,r._graphicSymbolChangedHandle=null,r._originalSymbol=null,r}return(0,r.Z)(e,[{key:"graphic",set:function(t){this._circleCollisionCache=null,this._originalSymbol=t.symbol,this._set("graphic",t),this.attachSymbolChanged()}},{key:"elevationInfo",get:function(){var t="elevationInfo"in this.graphic.layer&&this.graphic.layer.elevationInfo,i=(0,_.vu)(this.graphic),e=t?t.offset:0;return new b.Z({mode:i,offset:e})}},{key:"focusedSymbol",set:function(t){t!==this._get("focusedSymbol")&&(this._set("focusedSymbol",t),this._updateGraphicSymbol(),this._circleCollisionCache=null)}},{key:"grabbableForEvent",value:function(){return!0}},{key:"grabbing",set:function(t){t!==this._get("grabbing")&&(this._set("grabbing",t),this._updateGraphicSymbol())}},{key:"hovering",set:function(t){t!==this._get("hovering")&&(this._set("hovering",t),this._updateGraphicSymbol())}},{key:"selected",set:function(t){t!==this._get("selected")&&(this._set("selected",t),this._updateGraphicSymbol(),this.events.emit("select-changed",{action:t?"select":"deselect"}))}},{key:"_focused",get:function(){return this._get("hovering")||this._get("grabbing")}},{key:"destroy",value:function(){this.detachSymbolChanged(),this._resetGraphicSymbol(),this._set("view",null)}},{key:"intersectionDistance",value:function(t){var i=this.graphic;if(!1===i.visible)return null;var e=i.geometry;if((0,c.Wi)(e))return null;var n=this._get("focusedSymbol"),r=(0,c.pC)(n)?n:i.symbol;return"2d"===this.view.type?this._intersectDistance2D(this.view,t,e,r):this._intersectDistance3D(this.view,t,i)}},{key:"attach",value:function(){this.attachSymbolChanged(),(0,c.pC)(this.layer)&&this.layer.add(this.graphic)}},{key:"detach",value:function(){this.detachSymbolChanged(),this._resetGraphicSymbol(),(0,c.pC)(this.layer)&&this.layer.remove(this.graphic)}},{key:"attachSymbolChanged",value:function(){var t=this;this.detachSymbolChanged(),this._graphicSymbolChangedHandle=this.graphic.watch("symbol",(function(i){(0,c.pC)(i)&&i!==t.focusedSymbol&&i!==t._originalSymbol&&(t._originalSymbol=i,t._focused&&(0,c.pC)(t.focusedSymbol)&&(t.graphic.symbol=t.focusedSymbol))}),!0)}},{key:"detachSymbolChanged",value:function(){(0,c.pC)(this._graphicSymbolChangedHandle)&&(this._graphicSymbolChangedHandle.remove(),this._graphicSymbolChangedHandle=null)}},{key:"_updateGraphicSymbol",value:function(){this.graphic.symbol=this._focused&&(0,c.pC)(this.focusedSymbol)?this.focusedSymbol:this._originalSymbol}},{key:"_resetGraphicSymbol",value:function(){this.graphic.symbol=this._originalSymbol}},{key:"_intersectDistance2D",value:function(t,i,e,n){if(n=n||(0,m.js)(e),(0,c.Wi)(n))return null;var r=this._circleCollisionCache;if("point"!==e.type||"simple-marker"!==n.type)return(0,x.D)(i,e,t)?1:null;if((0,c.Wi)(r)||!r.originalPoint.equals(e)){var a=e,s=t.spatialReference;if((0,g.Up)(a.spatialReference,s)){var o=(0,g.iV)(a,s);r={originalPoint:a.clone(),mapPoint:o,radiusPx:(0,u.F2)(n.size)},this._circleCollisionCache=r}}if((0,c.pC)(r)){var h=(0,u.md)(i,G),l=t.toScreen(r.mapPoint),p=r.radiusPx,v=l.x+(0,u.F2)(n.xoffset),f=l.y-(0,u.F2)(n.yoffset);return(0,y.a)(h,[v,f])<p*p?1:null}return null}},{key:"_intersectDistance3D",value:function(t,i,e){var n=t.toMap(i,{include:[e]});return n&&(0,g.KC)(n,k,t.renderSpatialReference)?(0,f.i)(k,t.state.camera.eye):null}}]),e}(h.Z);(0,o._)([(0,p.Cb)({constructOnly:!0,nonNullable:!0})],w.prototype,"graphic",null),(0,o._)([(0,p.Cb)({readOnly:!0})],w.prototype,"elevationInfo",null),(0,o._)([(0,p.Cb)({constructOnly:!0,nonNullable:!0})],w.prototype,"view",void 0),(0,o._)([(0,p.Cb)({value:null})],w.prototype,"focusedSymbol",null),(0,o._)([(0,p.Cb)({constructOnly:!0})],w.prototype,"layer",void 0),(0,o._)([(0,p.Cb)()],w.prototype,"interactive",void 0),(0,o._)([(0,p.Cb)()],w.prototype,"selectable",void 0),(0,o._)([(0,p.Cb)()],w.prototype,"grabbable",void 0),(0,o._)([(0,p.Cb)({value:!1})],w.prototype,"grabbing",null),(0,o._)([(0,p.Cb)()],w.prototype,"dragging",void 0),(0,o._)([(0,p.Cb)()],w.prototype,"hovering",null),(0,o._)([(0,p.Cb)({value:!1})],w.prototype,"selected",null),(0,o._)([(0,p.Cb)()],w.prototype,"cursor",void 0),w=(0,o._)([(0,v.j)("esri.views.interactive.GraphicManipulator")],w);var k=(0,d.c)(),G=(0,u.s1)()}}]);
//# sourceMappingURL=3503.5d8f7427.chunk.js.map