"use strict";(self.webpackChunketihadrailapp=self.webpackChunketihadrailapp||[]).push([[6306],{96306:function(t,e,i){i.r(e),i.d(e,{default:function(){return F}});var a=i(29439),r=i(37762),n=i(60136),s=i(29388),o=i(43144),h=i(15671),c=i(27366),l=(i(59486),i(52639)),p=i(91505),u=i(100),v=i(92026),f=i(8537),y=i(49861),d=(i(63780),i(93169),i(25243),i(69912)),_=i(65156),g=i(376),G=i(69662),m=i(80885),b=i(29909),k=i(7882),w=i(77577);function S(t){var e,i=0,a=0,r=t.length,n=t[a];for(a=0;a<r-1;a++)i+=((e=t[a+1])[0]-n[0])*(e[1]+n[1]),n=e;return i>=0}function x(t,e,i,a){var n,s=[],o=(0,r.Z)(t);try{for(o.s();!(n=o.n()).done;){var h=n.value,c=h.slice(0);s.push(c);var l=e*(h[0]-a.x)-i*(h[1]-a.y)+a.x,p=i*(h[0]-a.x)+e*(h[1]-a.y)+a.y;c[0]=l,c[1]=p}}catch(u){o.e(u)}finally{o.f()}return s}function Z(t,e,i){var a,n,s=t.spatialReference,o=e*Math.PI/180,h=Math.cos(o),c=Math.sin(o);if("xmin"in t&&(i=null!=(a=i)?a:t.center,t=new m.Z({spatialReference:s,rings:[[[t.xmin,t.ymin],[t.xmin,t.ymax],[t.xmax,t.ymax],[t.xmax,t.ymin],[t.xmin,t.ymin]]]})),"paths"in t){var l;i=null!=(l=i)?l:t.extent.center;var p,u=[],v=(0,r.Z)(t.paths);try{for(v.s();!(p=v.n()).done;){var f=p.value;u.push(x(f,h,c,i))}}catch(O){v.e(O)}finally{v.f()}return new b.Z({spatialReference:s,paths:u})}if("rings"in t){var y;i=null!=(y=i)?y:t.extent.center;var d,_=[],g=(0,r.Z)(t.rings);try{for(g.s();!(d=g.n()).done;){var G=d.value,Z=S(G),C=x(G,h,c,i);S(C)!==Z&&C.reverse(),_.push(C)}}catch(O){g.e(O)}finally{g.f()}return new m.Z({spatialReference:s,rings:_})}if("x"in t){var R;i=null!=(R=i)?R:t;var M=new k.Z({x:h*(t.x-i.x)-c*(t.y-i.y)+i.x,y:c*(t.x-i.x)+h*(t.y-i.y)+i.y,spatialReference:s});return null!=t.z&&(M.z=t.z),null!=t.m&&(M.m=t.m),M}return"points"in t?(i=null!=(n=i)?n:t.extent.center,new w.Z({points:x(t.points,h,c,i),spatialReference:s})):null}var C=i(61459),R=i(16851),M=i(16072),O=i(20008),I=i(53503),E=i(83089),z=i(70040),L=(0,o.Z)((function t(e,i,a,r){(0,h.Z)(this,t),this.graphics=e,this.mover=i,this.dx=a,this.dy=r,this.type="move-start"})),B=(0,o.Z)((function t(e,i,a,r){(0,h.Z)(this,t),this.graphics=e,this.mover=i,this.dx=a,this.dy=r,this.type="move"})),A=(0,o.Z)((function t(e,i,a,r){(0,h.Z)(this,t),this.graphics=e,this.mover=i,this.dx=a,this.dy=r,this.type="move-stop"})),Y=(0,o.Z)((function t(e,i,a){(0,h.Z)(this,t),this.graphics=e,this.mover=i,this.angle=a,this.type="rotate-start"})),N=(0,o.Z)((function t(e,i,a){(0,h.Z)(this,t),this.graphics=e,this.mover=i,this.angle=a,this.type="rotate"})),X=(0,o.Z)((function t(e,i,a){(0,h.Z)(this,t),this.graphics=e,this.mover=i,this.angle=a,this.type="rotate-stop"})),P=(0,o.Z)((function t(e,i,a,r){(0,h.Z)(this,t),this.graphics=e,this.mover=i,this.xScale=a,this.yScale=r,this.type="scale-start"})),T=(0,o.Z)((function t(e,i,a,r){(0,h.Z)(this,t),this.graphics=e,this.mover=i,this.xScale=a,this.yScale=r,this.type="scale"})),D=(0,o.Z)((function t(e,i,a,r){(0,h.Z)(this,t),this.graphics=e,this.mover=i,this.xScale=a,this.yScale=r,this.type="scale-stop"})),U=z.X.transformGraphics,H={centerIndicator:new M.default({style:"cross",size:U.center.size,color:U.center.color}),fill:{default:new C.default({color:U.fill.color,outline:{color:U.fill.outlineColor,join:"round",width:1}}),active:new C.default({color:U.fill.stagedColor,outline:{color:U.fill.outlineColor,join:"round",style:"dash",width:1}})},handles:{default:new M.default({style:"square",size:U.vertex.size,color:U.vertex.color,outline:{color:U.vertex.outlineColor,width:1}}),hover:new M.default({style:"square",size:U.vertex.hoverSize,color:U.vertex.hoverColor,outline:{color:U.vertex.hoverOutlineColor,width:1}})},rotator:{default:new M.default({style:"circle",size:U.vertex.size,color:U.vertex.color,outline:{color:U.vertex.outlineColor,width:1}}),hover:new M.default({style:"circle",size:U.vertex.hoverSize,color:U.vertex.hoverColor,outline:{color:U.vertex.hoverOutlineColor,width:1}})},rotatorLine:new R.default({color:U.line.color,width:1})},V=function(t){(0,n.Z)(i,t);var e=(0,s.Z)(i);function i(t){var n;return(0,h.Z)(this,i),(n=e.call(this,t))._activeHandleGraphic=null,n._graphicAttributes={esriSketchTool:"box"},n._handles=new u.Z,n._mover=null,n._rotateGraphicOffset=20,n._angleOfRotation=0,n._rotateLineGraphic=null,n._startInfo=null,n._totalDx=0,n._totalDy=0,n._xScale=1,n._yScale=1,n.type="box",n.callbacks={onMoveStart:function(){},onMove:function(){},onMoveStop:function(){},onScaleStart:function(){},onScale:function(){},onScaleStop:function(){},onRotateStart:function(){},onRotate:function(){},onRotateStop:function(){},onGraphicClick:function(){}},n.centerGraphic=null,n.backgroundGraphic=null,n.enableMovement=!0,n.enableRotation=!0,n.enableScaling=!0,n.graphics=[],n.handleGraphics=[],n.layer=null,n.preserveAspectRatio=!1,n.rotateGraphic=null,n.showCenterGraphic=!0,n.view=null,n._getBounds=function(){var t=(0,_.Ue)();return function(e,i){e[0]=Number.POSITIVE_INFINITY,e[1]=Number.POSITIVE_INFINITY,e[2]=Number.NEGATIVE_INFINITY,e[3]=Number.NEGATIVE_INFINITY;var n,s=(0,r.Z)(i);try{for(s.s();!(n=s.n()).done;){var o=n.value;if(o){var h=void 0,c=void 0,l=void 0,p=void 0;if("point"===o.type)h=l=o.x,c=p=o.y;else if("multipoint"===o.type){var u=(0,G.nA)(o),v=(0,g.C6)(t,[u]),f=(0,a.Z)(v,4);h=f[0],c=f[1],l=f[2],p=f[3]}else if("extent"===o.type){var y=[o.xmin,o.ymin,o.xmax,o.ymax];h=y[0],c=y[1],l=y[2],p=y[3]}else{var d=(0,G.nA)(o),_=(0,g.C6)(t,d),m=(0,a.Z)(_,4);h=m[0],c=m[1],l=m[2],p=m[3]}e[0]=Math.min(h,e[0]),e[1]=Math.min(c,e[1]),e[2]=Math.max(l,e[2]),e[3]=Math.max(p,e[3])}}}catch(b){s.e(b)}finally{s.f()}return e}}(),n}return(0,o.Z)(i,[{key:"initialize",value:function(){var t=this;this._setup(),this._handles.add([(0,f.N1)(this,"view.ready",(function(){var e=t.layer,i=t.view;(0,E.p)(i,e)})),(0,f.Wy)(this,"preserveAspectRatio",(function(){t._activeHandleGraphic&&(t._scaleGraphic(t._activeHandleGraphic),t._updateGraphics())})),(0,f.Wy)(this,"view.scale",(function(){t._updateRotateGraphic(),t._updateRotateLineGraphic()})),(0,f.Wy)(this,"graphics",(function(){return t.refresh()})),(0,f.Wy)(this,"layer",(function(e,i){i&&t._resetGraphics(i),t.refresh()}))])}},{key:"destroy",value:function(){this._reset(),this._handles=(0,v.SC)(this._handles)}},{key:"state",get:function(){var t=!!this.get("view.ready"),e=!(!this.get("graphics.length")||!this.get("layer"));return t&&e?"active":t?"ready":"disabled"}},{key:"symbols",set:function(t){var e=t||{},i=e.centerIndicator,a=void 0===i?H.centerIndicator:i,r=e.fill,n=void 0===r?H.fill:r,s=e.handles,o=void 0===s?H.handles:s,h=e.rotator,c=void 0===h?H.rotator:h,l=e.rotatorLine,p=void 0===l?H.rotatorLine:l;this._set("symbols",{centerIndicator:a,fill:n,handles:o,rotator:c,rotatorLine:p})}},{key:"isUIGraphic",value:function(t){var e=[];return this.handleGraphics.length&&(e=e.concat(this.handleGraphics)),this.backgroundGraphic&&e.push(this.backgroundGraphic),this.centerGraphic&&e.push(this.centerGraphic),this.rotateGraphic&&e.push(this.rotateGraphic),this._rotateLineGraphic&&e.push(this._rotateLineGraphic),e.length&&e.includes(t)}},{key:"move",value:function(t,e){if(this._mover&&this.graphics.length){var i,a=(0,r.Z)(this.graphics);try{for(a.s();!(i=a.n()).done;){var n=i.value,s=n.geometry,o=(0,O.e7)(s,t,e,this.view);n.geometry=o}}catch(h){a.e(h)}finally{a.f()}this.refresh(),this._emitMoveStopEvent(t,e,null)}}},{key:"scale",value:function(t,e){if(this._mover&&this.graphics.length){var i,a=(0,r.Z)(this.graphics);try{for(a.s();!(i=a.n()).done;){var n=i.value,s=n.geometry,o=(0,O.bA)(s,t,e);n.geometry=o}}catch(h){a.e(h)}finally{a.f()}this.refresh(),this._emitScaleStopEvent(t,e,null)}}},{key:"rotate",value:function(t,e){if(this._mover&&this.graphics.length){if(!e){var i=this.handleGraphics[1].geometry.x,a=this.handleGraphics[3].geometry.y;e=new k.Z(i,a,this.view.spatialReference)}var n,s=(0,r.Z)(this.graphics);try{for(s.s();!(n=s.n()).done;){var o=n.value,h=Z(o.geometry,t,e);o.geometry=h}}catch(c){s.e(c)}finally{s.f()}this.refresh(),this._emitRotateStopEvent(t,null)}}},{key:"refresh",value:function(){this._reset(),this._setup()}},{key:"reset",value:function(){this.graphics=[]}},{key:"_setup",value:function(){"active"===this.state&&(this._setupGraphics(),this._setupMover(),this._updateGraphics())}},{key:"_reset",value:function(){this._resetGraphicStateVars(),this._resetGraphics(),this._mover&&this._mover.destroy(),this._mover=null,this.view.cursor="default"}},{key:"_resetGraphicStateVars",value:function(){this._startInfo=null,this._activeHandleGraphic=null,this._totalDx=0,this._totalDy=0,this._xScale=1,this._yScale=1,this._angleOfRotation=0}},{key:"_resetGraphics",value:function(t){var e=t||this.layer;e&&(e.removeMany(this.handleGraphics),e.remove(this.backgroundGraphic),e.remove(this.centerGraphic),e.remove(this.rotateGraphic),e.remove(this._rotateLineGraphic));var i,a=(0,r.Z)(this.handleGraphics);try{for(a.s();!(i=a.n()).done;){i.value.destroy()}}catch(n){a.e(n)}finally{a.f()}this._set("handleGraphics",[]),this.backgroundGraphic&&(this.backgroundGraphic.destroy(),this._set("backgroundGraphic",null)),this.centerGraphic&&(this.centerGraphic.destroy(),this._set("centerGraphic",null)),this.rotateGraphic&&(this.rotateGraphic.destroy(),this._set("rotateGraphic",null)),this._rotateLineGraphic&&(this._rotateLineGraphic.destroy(),this._rotateLineGraphic=null)}},{key:"_setupMover",value:function(){var t=this,e=[];this.enableScaling&&(e=e.concat(this.handleGraphics)),this.enableMovement&&(e=e.concat(this.graphics,this.backgroundGraphic)),this.enableRotation&&e.push(this.rotateGraphic),this.showCenterGraphic&&e.push(this.centerGraphic),this._mover=new I.default({enableMoveAllGraphics:!1,indicatorsEnabled:!1,view:this.view,graphics:e,callbacks:{onGraphicClick:function(e){return t._onGraphicClickCallback(e)},onGraphicMoveStart:function(e){return t._onGraphicMoveStartCallback(e)},onGraphicMove:function(e){return t._onGraphicMoveCallback(e)},onGraphicMoveStop:function(e){return t._onGraphicMoveStopCallback(e)},onGraphicPointerOver:function(e){return t._onGraphicPointerOverCallback(e)},onGraphicPointerOut:function(e){return t._onGraphicPointerOutCallback(e)}}})}},{key:"_getStartInfo",value:function(t){var e=this._getBoxBounds((0,_.Ue)()),i=(0,a.Z)(e,4),r=i[0],n=i[1],s=i[2],o=i[3],h=Math.abs(s-r),c=Math.abs(o-n),l=(s+r)/2,p=(o+n)/2,u=t.geometry;return{width:h,height:c,centerX:l,centerY:p,startX:u.x,startY:u.y,graphicInfos:this._getGraphicInfos(),box:this.backgroundGraphic.geometry,rotate:this.rotateGraphic.geometry}}},{key:"_getGraphicInfos",value:function(){var t=this;return this.graphics.map((function(e){return t._getGraphicInfo(e)}))}},{key:"_getGraphicInfo",value:function(t){var e=t.geometry,i=this._getBounds((0,_.Ue)(),[e]),r=(0,a.Z)(i,4),n=r[0],s=r[1],o=r[2],h=r[3];return{width:Math.abs(o-n),height:Math.abs(h-s),centerX:(o+n)/2,centerY:(h+s)/2,geometry:e}}},{key:"_onGraphicClickCallback",value:function(t){t.viewEvent.stopPropagation(),this.emit("graphic-click",t),this.callbacks.onGraphicClick&&this.callbacks.onGraphicClick(t)}},{key:"_onGraphicMoveStartCallback",value:function(t){var e=this._angleOfRotation,i=this._xScale,a=this._yScale,r=this.backgroundGraphic,n=this.handleGraphics,s=this.rotateGraphic,o=this.symbols,h=t.graphic;this._resetGraphicStateVars(),this._hideGraphicsBeforeUpdate(),r.symbol=o.fill.active,this._startInfo=this._getStartInfo(h),h===s?(this.view.cursor="grabbing",this._emitRotateStartEvent(e,h)):n.includes(h)?(this._activeHandleGraphic=h,this._emitScaleStartEvent(i,a,h)):this._emitMoveStartEvent(t.dx,t.dy,h)}},{key:"_onGraphicMoveCallback",value:function(t){var e=t.graphic;if(this._startInfo)if(this.handleGraphics.includes(e))this._scaleGraphic(e),this._emitScaleEvent(this._xScale,this._yScale,e);else if(e===this.rotateGraphic)this._rotateGraphic(e),this._emitRotateEvent(this._angleOfRotation,e);else{var i=t.dx,a=t.dy;this._totalDx+=i,this._totalDy+=a,this._moveGraphic(e,i,a),this._emitMoveEvent(i,a,e)}}},{key:"_onGraphicMoveStopCallback",value:function(t){var e=t.graphic;if(this._startInfo){var i=this._angleOfRotation,a=this._totalDx,r=this._totalDy,n=this._xScale,s=this._yScale,o=this.handleGraphics,h=this.rotateGraphic;this.refresh(),e===h?(this.view.cursor="pointer",this._emitRotateStopEvent(i,e)):o.includes(e)?this._emitScaleStopEvent(n,s,e):this._emitMoveStopEvent(a,r,e)}else this.refresh()}},{key:"_onGraphicPointerOverCallback",value:function(t){var e=this.backgroundGraphic,i=this.handleGraphics,a=this.graphics,r=this.rotateGraphic,n=this.symbols,s=this.view,o=t.graphic;if(o===r)return r.symbol=n.rotator.hover,void(s.cursor="pointer");if(a.includes(o)||o===e)s.cursor="move";else if(i.includes(o)){t.graphic.symbol=n.handles.hover;var h,c=s.rotation,l=t.index;switch(l<8&&(c>=0&&c<45?l%=8:l=c>=45&&c<90?(l+1)%8:c>=90&&c<135?(l+2)%8:c>=135&&c<180?(l+3)%8:c>=180&&c<225?(l+4)%8:c>=225&&c<270?(l+5)%8:c>=270&&c<315?(l+6)%8:(l+7)%8),l){case 0:case 4:h="nwse-resize";break;case 1:case 5:h="ns-resize";break;case 2:case 6:h="nesw-resize";break;case 3:case 7:h="ew-resize";break;default:h="pointer"}s.cursor=h}else s.cursor="pointer"}},{key:"_onGraphicPointerOutCallback",value:function(t){var e=this.handleGraphics,i=this.rotateGraphic,a=this.symbols,r=this.view;t.graphic===i?i.symbol=a.rotator.default:e.includes(t.graphic)&&(t.graphic.symbol=a.handles.default),r.cursor="default"}},{key:"_scaleGraphic",value:function(t){var e=this._startInfo,i=this.handleGraphics,a=this.preserveAspectRatio,n=this.view,s=e.centerX,o=e.centerY,h=e.startX,c=e.startY,l=n.state,p=l.resolution,u=l.transform,v=i.indexOf(t);1!==v&&5!==v||this._updateX(t,s),3!==v&&7!==v||this._updateY(t,o);var f=t.geometry,y=f.x,d=f.y,_=u[0]*y+u[2]*d+u[4],g=u[1]*y+u[3]*d+u[5],G=e.graphicInfos.map((function(t){return t.geometry}));if(a){var m=u[0]*s+u[2]*o+u[4],b=u[1]*s+u[3]*o+u[5],w=u[0]*h+u[2]*c+u[4],S=u[1]*h+u[3]*c+u[5];this._xScale=this._yScale=(0,O.Ru)(m,b,w,S,_,g);var x,Z=(0,r.Z)(G);try{for(Z.s();!(x=Z.n()).done;){var C=x.value,R=G.indexOf(C);this.graphics[R].geometry=(0,O.bA)(C,this._xScale,this._yScale,[s,o])}}catch(K){Z.e(K)}finally{Z.f()}this._updateBackgroundGraphic()}else{var M=e.width,I=e.height,E=y-h,z=c-d;if(1===v||5===v?E=0:3!==v&&7!==v||(z=0),0===E&&0===z)return;var L=M+(h>s?E:-1*E),B=I+(c<o?z:-1*z),A=s+E/2,Y=o+z/2;this._xScale=L/M||1,this._yScale=B/I||1,1===v||5===v?this._xScale=1:3!==v&&7!==v||(this._yScale=1);var N=(A-s)/p,X=(Y-o)/p,P=(0,O.bA)(e.box,this._xScale,this._yScale);this.backgroundGraphic.geometry=(0,O.e7)(P,N,X,n,!0);var T,D=this._getGraphicInfo(this.backgroundGraphic),U=D.centerX,H=D.centerY,V=(U-s)/p,F=-1*(H-o)/p,W=(0,r.Z)(G);try{for(W.s();!(T=W.n()).done;){var j=T.value,q=G.indexOf(j),J=(0,O.bA)(j,this._xScale,this._yScale,[s,o]);this.graphics[q].geometry=(0,O.e7)(J,V,F,n,!0)}}catch(K){W.e(K)}finally{W.f()}this.centerGraphic.geometry=new k.Z(U,H,n.spatialReference)}}},{key:"_rotateGraphic",value:function(t){var e=this._startInfo,i=e.centerX,a=e.centerY,n=e.startX,s=e.startY,o=e.box,h=e.rotate,c=new k.Z(n,s,this.view.spatialReference),l=new k.Z(i,a,this.view.spatialReference),p=t.geometry;this._angleOfRotation=(0,O.cM)(c,p,l);var u,v=this._startInfo.graphicInfos.map((function(t){return t.geometry})),f=(0,r.Z)(v);try{for(f.s();!(u=f.n()).done;){var y=u.value,d=v.indexOf(y),_=Z(y,this._angleOfRotation,l);this.graphics[d].geometry=_}}catch(g){f.e(g)}finally{f.f()}this.backgroundGraphic.geometry=Z(o,this._angleOfRotation,l),this.rotateGraphic.geometry=Z(h,this._angleOfRotation,l)}},{key:"_moveGraphic",value:function(t,e,i){if(this.graphics.includes(t)){var a=this.backgroundGraphic.geometry;this.backgroundGraphic.geometry=(0,O.e7)(a,e,i,this.view);var n,s=(0,r.Z)(this.graphics);try{for(s.s();!(n=s.n()).done;){var o=n.value;o!==t&&(o.geometry=(0,O.e7)(o.geometry,e,i,this.view))}}catch(u){s.e(u)}finally{s.f()}}else if(t===this.centerGraphic){var h=this.backgroundGraphic.geometry;this.backgroundGraphic.geometry=(0,O.e7)(h,e,i,this.view)}if(t===this.backgroundGraphic||t===this.centerGraphic){var c,l=(0,r.Z)(this.graphics);try{for(l.s();!(c=l.n()).done;){var p=c.value;p.geometry=(0,O.e7)(p.geometry,e,i,this.view)}}catch(u){l.e(u)}finally{l.f()}}}},{key:"_setupGraphics",value:function(){var t=this._graphicAttributes,e=this.symbols;this._set("centerGraphic",new l.Z(null,e.centerIndicator,t)),this.showCenterGraphic&&this.layer.add(this.centerGraphic),this._set("backgroundGraphic",new l.Z(null,e.fill.default,t)),this.layer.add(this.backgroundGraphic),this._rotateLineGraphic=new l.Z(null,e.rotatorLine,t),this._set("rotateGraphic",new l.Z(null,e.rotator.default,t)),this.enableRotation&&!this._hasExtentGraphic()&&(this.layer.add(this._rotateLineGraphic),this.layer.add(this.rotateGraphic));for(var i=0;i<8;i++)this.handleGraphics.push(new l.Z(null,e.handles.default,t));this.enableScaling&&this.layer.addMany(this.handleGraphics)}},{key:"_updateGraphics",value:function(){this._updateBackgroundGraphic(),this._updateHandleGraphics(),this._updateCenterGraphic(),this._updateRotateGraphic(),this._updateRotateLineGraphic()}},{key:"_hideGraphicsBeforeUpdate",value:function(){this.centerGraphic.visible=!1,this.rotateGraphic.visible=!1,this._rotateLineGraphic.visible=!1,this.handleGraphics.forEach((function(t){return t.visible=!1}))}},{key:"_updateHandleGraphics",value:function(){var t=this,e=this._getCoordinates(!0);this.handleGraphics.forEach((function(i,r){var n=(0,a.Z)(e[r],2),s=n[0],o=n[1];t._updateXY(i,s,o)}))}},{key:"_updateBackgroundGraphic",value:function(){var t=this._getCoordinates();this.backgroundGraphic.geometry=new m.Z({rings:t,spatialReference:this.view.spatialReference})}},{key:"_updateCenterGraphic",value:function(){var t=this._getBoxBounds((0,_.Ue)()),e=(0,a.Z)(t,4),i=e[0],r=e[1],n=(e[2]+i)/2,s=(e[3]+r)/2;this.centerGraphic.geometry=new k.Z(n,s,this.view.spatialReference)}},{key:"_updateRotateGraphic",value:function(){if(this.handleGraphics.length){var t=this.handleGraphics[1].geometry,e=t.x,i=t.y+this.view.state.resolution*this._rotateGraphicOffset;this.rotateGraphic.geometry=new k.Z(e,i,this.view.spatialReference)}}},{key:"_updateRotateLineGraphic",value:function(){if(this.handleGraphics.length&&this.rotateGraphic&&this.rotateGraphic.geometry){var t=this.handleGraphics[1].geometry,e=this.rotateGraphic.geometry;this._rotateLineGraphic.geometry=new b.Z({paths:[[t.x,t.y],[e.x,e.y]],spatialReference:this.view.spatialReference})}}},{key:"_updateXY",value:function(t,e,i){t.geometry=new k.Z(e,i,this.view.spatialReference)}},{key:"_updateX",value:function(t,e){var i=t.geometry.y;t.geometry=new k.Z(e,i,this.view.spatialReference)}},{key:"_updateY",value:function(t,e){var i=t.geometry.x;t.geometry=new k.Z(i,e,this.view.spatialReference)}},{key:"_hasExtentGraphic",value:function(){return this.graphics.some((function(t){return t&&(0,v.pC)(t.geometry)&&"extent"===t.geometry.type}))}},{key:"_getBoxBounds",value:function(t){var e=this.graphics.map((function(t){return t.geometry}));return this._getBounds(t,e)}},{key:"_getCoordinates",value:function(t){var e=this._getBoxBounds((0,_.Ue)()),i=(0,a.Z)(e,4),r=i[0],n=i[1],s=i[2],o=i[3];if(t){var h=(r+s)/2,c=(o+n)/2;return[[r,o],[h,o],[s,o],[s,c],[s,n],[h,n],[r,n],[r,c]]}return[[r,o],[s,o],[s,n],[r,n]]}},{key:"_emitMoveStartEvent",value:function(t,e,i){var a=new L(this.graphics,i,t,e);this.emit("move-start",a),this.callbacks.onMoveStart&&this.callbacks.onMoveStart(a)}},{key:"_emitMoveEvent",value:function(t,e,i){var a=new B(this.graphics,i,t,e);this.emit("move",a),this.callbacks.onMove&&this.callbacks.onMove(a)}},{key:"_emitMoveStopEvent",value:function(t,e,i){var a=new A(this.graphics,i,t,e);this.emit("move-stop",a),this.callbacks.onMoveStop&&this.callbacks.onMoveStop(a)}},{key:"_emitRotateStartEvent",value:function(t,e){var i=new Y(this.graphics,e,t);this.emit("rotate-start",i),this.callbacks.onRotateStart&&this.callbacks.onRotateStart(i)}},{key:"_emitRotateEvent",value:function(t,e){var i=new N(this.graphics,e,t);this.emit("rotate",i),this.callbacks.onRotate&&this.callbacks.onRotate(i)}},{key:"_emitRotateStopEvent",value:function(t,e){var i=new X(this.graphics,e,t);this.emit("rotate-stop",i),this.callbacks.onRotateStop&&this.callbacks.onRotateStop(i)}},{key:"_emitScaleStartEvent",value:function(t,e,i){var a=new P(this.graphics,i,t,e);this.emit("scale-start",a),this.callbacks.onScaleStart&&this.callbacks.onScaleStart(a)}},{key:"_emitScaleEvent",value:function(t,e,i){var a=new T(this.graphics,i,t,e);this.emit("scale",a),this.callbacks.onScale&&this.callbacks.onScale(a)}},{key:"_emitScaleStopEvent",value:function(t,e,i){var a=new D(this.graphics,i,t,e);this.emit("scale-stop",a),this.callbacks.onScaleStop&&this.callbacks.onScaleStop(a)}}]),i}(p.Z.EventedAccessor);(0,c._)([(0,y.Cb)()],V.prototype,"_rotateLineGraphic",void 0),(0,c._)([(0,y.Cb)({readOnly:!0})],V.prototype,"type",void 0),(0,c._)([(0,y.Cb)()],V.prototype,"callbacks",void 0),(0,c._)([(0,y.Cb)({readOnly:!0})],V.prototype,"centerGraphic",void 0),(0,c._)([(0,y.Cb)({readOnly:!0})],V.prototype,"backgroundGraphic",void 0),(0,c._)([(0,y.Cb)()],V.prototype,"enableMovement",void 0),(0,c._)([(0,y.Cb)()],V.prototype,"enableRotation",void 0),(0,c._)([(0,y.Cb)()],V.prototype,"enableScaling",void 0),(0,c._)([(0,y.Cb)()],V.prototype,"graphics",void 0),(0,c._)([(0,y.Cb)({readOnly:!0})],V.prototype,"handleGraphics",void 0),(0,c._)([(0,y.Cb)()],V.prototype,"layer",void 0),(0,c._)([(0,y.Cb)()],V.prototype,"preserveAspectRatio",void 0),(0,c._)([(0,y.Cb)({readOnly:!0})],V.prototype,"rotateGraphic",void 0),(0,c._)([(0,y.Cb)()],V.prototype,"showCenterGraphic",void 0),(0,c._)([(0,y.Cb)({readOnly:!0})],V.prototype,"state",null),(0,c._)([(0,y.Cb)({value:H})],V.prototype,"symbols",null),(0,c._)([(0,y.Cb)()],V.prototype,"view",void 0);var F=V=(0,c._)([(0,d.j)("esri.views.draw.support.Box")],V)},70040:function(t,e,i){i.d(e,{O:function(){return s},X:function(){return v}});var a=i(43144),r=i(15671),n=i(51995),s={main:new n.Z([255,127,0]),selected:new n.Z([255,255,255]),outline:new n.Z([0,0,0,.5]),selectedOutline:new n.Z([255,255,255]),hoverOutline:new n.Z([255,255,255]),secondary:new n.Z([255,255,255]),secondaryOutline:new n.Z([100,100,100]),transparent:new n.Z([0,0,0,0])};function o(t,e){if(e)for(var i in e)t[i]=e[i]}var h=(0,a.Z)((function t(e){(0,r.Z)(this,t),this.size=8,this.hoverSize=10,this.color=s.main,this.hoverColor=s.main,this.outlineColor=s.outline,this.hoverOutlineColor=s.hoverOutline,o(this,e)})),c=(0,a.Z)((function t(e){(0,r.Z)(this,t),this.color=s.secondary,this.hoverColor=s.main,o(this,e)})),l=(0,a.Z)((function t(e){(0,r.Z)(this,t),this.color=s.transparent,this.hoverColor=s.transparent,this.outlineColor=s.main,this.hoverOutlineColor=s.main,this.stagedColor=s.transparent,this.stagedOutlineColor=s.secondary,o(this,e)})),p=(0,a.Z)((function t(e){(0,r.Z)(this,t),this.vertex=new h,this.midpoint=new h({color:s.secondary,outlineColor:s.secondaryOutline,size:6}),this.selected=new h({color:s.selected,hoverColor:s.selected,hoverOutlineColor:s.hoverOutline}),o(this,e)})),u=(0,a.Z)((function t(e){(0,r.Z)(this,t),this.center=new h({color:s.secondaryOutline}),this.fill=new l,this.line=new c,this.vertex=new h({color:s.selected,outlineColor:s.main,hoverColor:s.selected,hoverOutlineColor:s.secondaryOutline}),o(this,e)})),v=new((0,a.Z)((function t(e){(0,r.Z)(this,t),this.reshapeGraphics=new p,this.transformGraphics=new u,o(this,e)})))}}]);
//# sourceMappingURL=6306.a8180878.chunk.js.map