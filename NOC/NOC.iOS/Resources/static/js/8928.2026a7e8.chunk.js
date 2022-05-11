"use strict";(self.webpackChunketihadrailapp=self.webpackChunketihadrailapp||[]).push([[8928],{13491:function(t,e,n){n.d(e,{QB:function(){return c}});var i=n(60136),a=n(29388),r=n(37762),s=n(15671),o=n(43144),h=n(63780),u=n(92026),d=n(27546),l=n(36231),c=function(){function t(){var e=arguments.length>0&&void 0!==arguments[0]?arguments[0]:9,n=arguments.length>1?arguments[1]:void 0;(0,s.Z)(this,t),this.compareMinX=_,this.compareMinY=y,this.toBBox=function(t){return t},this._maxEntries=Math.max(4,e||9),this._minEntries=Math.max(2,Math.ceil(.4*this._maxEntries)),n&&("function"==typeof n?this.toBBox=n:this._initFormat(n)),this.clear()}return(0,o.Z)(t,[{key:"destroy",value:function(){this.clear(),b.prune(),Y.prune(),X.prune(),Z.prune()}},{key:"all",value:function(t){this._all(this.data,t)}},{key:"search",value:function(t,e){var n=this.data,i=this.toBBox;if(k(t,n))for(b.clear();n;){for(var a=0,r=n.children.length;a<r;a++){var s=n.children[a],o=n.leaf?i(s):s;k(t,o)&&(n.leaf?e(s):I(t,o)?this._all(s,e):b.push(s))}n=b.pop()}}},{key:"collides",value:function(t){var e=this.data,n=this.toBBox;if(!k(t,e))return!1;for(b.clear();e;){for(var i=0,a=e.children.length;i<a;i++){var r=e.children[i],s=e.leaf?n(r):r;if(k(t,s)){if(e.leaf||I(t,s))return!0;b.push(r)}}e=b.pop()}return!1}},{key:"load",value:function(t){if(!t.length)return this;if(t.length<this._minEntries){for(var e=0,n=t.length;e<n;e++)this.insert(t[e]);return this}var i=this._build(t.slice(0,t.length),0,t.length-1,0);if(this.data.children.length)if(this.data.height===i.height)this._splitRoot(this.data,i);else{if(this.data.height<i.height){var a=this.data;this.data=i,i=a}this._insert(i,this.data.height-i.height-1,!0)}else this.data=i;return this}},{key:"insert",value:function(t){return t&&this._insert(t,this.data.height-1),this}},{key:"clear",value:function(){return this.data=new S([]),this}},{key:"remove",value:function(t){if(!t)return this;var e,n=this.data,i=null,a=0,r=!1,s=this.toBBox(t);for(X.clear(),Z.clear();n||X.length>0;){var o;if(n||(n=(0,u.j0)(X.pop()),i=X.data[X.length-1],a=null!=(o=Z.pop())?o:0,r=!0),n.leaf&&-1!==(e=(0,h.cq)(n.children,t,n.children.length,n.indexHint)))return n.children.splice(e,1),X.push(n),this._condense(X),this;r||n.leaf||!I(n,s)?i?(a++,n=i.children[a],r=!1):n=null:(X.push(n),Z.push(a),a=0,i=n,n=n.children[0])}return this}},{key:"toJSON",value:function(){return this.data}},{key:"fromJSON",value:function(t){return this.data=t,this}},{key:"_all",value:function(t,e){var n=t;for(Y.clear();n;){var i;if(!0===n.leaf){var a,s=(0,r.Z)(n.children);try{for(s.s();!(a=s.n()).done;){e(a.value)}}catch(o){s.e(o)}finally{s.f()}}else Y.pushArray(n.children);n=null!=(i=Y.pop())?i:null}}},{key:"_build",value:function(t,e,n,i){var a=n-e+1,r=this._maxEntries;if(a<=r){var s=new S(t.slice(e,n+1));return f(s,this.toBBox),s}i||(i=Math.ceil(Math.log(a)/Math.log(r)),r=Math.ceil(a/Math.pow(r,i-1)));var o=new E([]);o.height=i;var h=Math.ceil(a/r),u=h*Math.ceil(Math.sqrt(r));M(t,e,n,u,this.compareMinX);for(var d=e;d<=n;d+=u){var l=Math.min(d+u-1,n);M(t,d,l,h,this.compareMinY);for(var c=d;c<=l;c+=h){var m=Math.min(c+h-1,l);o.children.push(this._build(t,c,m,i-1))}}return f(o,this.toBBox),o}},{key:"_chooseSubtree",value:function(t,e,n,i){for(;i.push(e),!0!==e.leaf&&i.length-1!==n;){for(var a=void 0,r=1/0,s=1/0,o=0,h=e.children.length;o<h;o++){var u=e.children[o],d=g(u),l=B(t,u)-d;l<s?(s=l,r=d<r?d:r,a=u):l===s&&d<r&&(r=d,a=u)}e=a||e.children[0]}return e}},{key:"_insert",value:function(t,e,n){var i=this.toBBox,a=n?t:i(t);X.clear();var r=this._chooseSubtree(a,this.data,e,X);for(r.children.push(t),v(r,a);e>=0&&X.data[e].children.length>this._maxEntries;)this._split(X,e),e--;this._adjustParentBBoxes(a,X,e)}},{key:"_split",value:function(t,e){var n=t.data[e],i=n.children.length,a=this._minEntries;this._chooseSplitAxis(n,a,i);var r=this._chooseSplitIndex(n,a,i);if(r){var s=n.children.splice(r,n.children.length-r),o=n.leaf?new S(s):new E(s);o.height=n.height,f(n,this.toBBox),f(o,this.toBBox),e?t.data[e-1].children.push(o):this._splitRoot(n,o)}else console.log("  Error: assertion failed at PooledRBush._split: no valid split index")}},{key:"_splitRoot",value:function(t,e){this.data=new E([t,e]),this.data.height=t.height+1,f(this.data,this.toBBox)}},{key:"_chooseSplitIndex",value:function(t,e,n){var i,a,r;i=a=1/0;for(var s=e;s<=n-e;s++){var o=m(t,0,s,this.toBBox),h=m(t,s,n,this.toBBox),u=p(o,h),d=g(o)+g(h);u<i?(i=u,r=s,a=d<a?d:a):u===i&&d<a&&(a=d,r=s)}return r}},{key:"_chooseSplitAxis",value:function(t,e,n){var i=t.leaf?this.compareMinX:_,a=t.leaf?this.compareMinY:y;this._allDistMargin(t,e,n,i)<this._allDistMargin(t,e,n,a)&&t.children.sort(i)}},{key:"_allDistMargin",value:function(t,e,n,i){t.children.sort(i);for(var a=this.toBBox,r=m(t,0,e,a),s=m(t,n-e,n,a),o=x(r)+x(s),h=e;h<n-e;h++){var u=t.children[h];v(r,t.leaf?a(u):u),o+=x(r)}for(var d=n-e-1;d>=e;d--){var l=t.children[d];v(s,t.leaf?a(l):l),o+=x(s)}return o}},{key:"_adjustParentBBoxes",value:function(t,e,n){for(var i=n;i>=0;i--)v(e.data[i],t)}},{key:"_condense",value:function(t){for(var e=t.length-1;e>=0;e--){var n=t.data[e];if(0===n.children.length)if(e>0){var i=t.data[e-1],a=i.children;a.splice((0,h.cq)(a,n,a.length,i.indexHint),1)}else this.clear();else f(n,this.toBBox)}}},{key:"_initFormat",value:function(t){var e=["return a"," - b",";"];this.compareMinX=new Function("a","b",e.join(t[0])),this.compareMinY=new Function("a","b",e.join(t[1])),this.toBBox=new Function("a","return {minX: a"+t[0]+", minY: a"+t[1]+", maxX: a"+t[2]+", maxY: a"+t[3]+"};")}}]),t}();function f(t,e){m(t,0,t.children.length,e,t)}function m(t,e,n,i,a){a||(a=new S([])),a.minX=1/0,a.minY=1/0,a.maxX=-1/0,a.maxY=-1/0;for(var r,s=e;s<n;s++)r=t.children[s],v(a,t.leaf?i(r):r);return a}function v(t,e){t.minX=Math.min(t.minX,e.minX),t.minY=Math.min(t.minY,e.minY),t.maxX=Math.max(t.maxX,e.maxX),t.maxY=Math.max(t.maxY,e.maxY)}function _(t,e){return t.minX-e.minX}function y(t,e){return t.minY-e.minY}function g(t){return(t.maxX-t.minX)*(t.maxY-t.minY)}function x(t){return t.maxX-t.minX+(t.maxY-t.minY)}function B(t,e){return(Math.max(e.maxX,t.maxX)-Math.min(e.minX,t.minX))*(Math.max(e.maxY,t.maxY)-Math.min(e.minY,t.minY))}function p(t,e){var n=Math.max(t.minX,e.minX),i=Math.max(t.minY,e.minY),a=Math.min(t.maxX,e.maxX),r=Math.min(t.maxY,e.maxY);return Math.max(0,a-n)*Math.max(0,r-i)}function I(t,e){return t.minX<=e.minX&&t.minY<=e.minY&&e.maxX<=t.maxX&&e.maxY<=t.maxY}function k(t,e){return e.minX<=t.maxX&&e.minY<=t.maxY&&e.maxX>=t.minX&&e.maxY>=t.minY}function M(t,e,n,i,a){for(var r=[e,n];r.length;){var s=(0,u.j0)(r.pop()),o=(0,u.j0)(r.pop());if(!(s-o<=i)){var h=o+Math.ceil((s-o)/i/2)*i;(0,l.q)(t,h,o,s,a),r.push(o,h,h,s)}}}var b=new d.Z,Y=new d.Z,X=new d.Z,Z=new d.Z({deallocator:void 0}),w=function(t){(0,i.Z)(n,t);var e=(0,a.Z)(n);function n(){var t;return(0,s.Z)(this,n),(t=e.apply(this,arguments)).height=1,t.indexHint=new h.SO,t}return(0,o.Z)(n)}((0,o.Z)((function t(){(0,s.Z)(this,t),this.minX=1/0,this.minY=1/0,this.maxX=-1/0,this.maxY=-1/0}))),S=function(t){(0,i.Z)(n,t);var e=(0,a.Z)(n);function n(t){var i;return(0,s.Z)(this,n),(i=e.call(this)).children=t,i.leaf=!0,i}return(0,o.Z)(n)}(w),E=function(t){(0,i.Z)(n,t);var e=(0,a.Z)(n);function n(t){var i;return(0,s.Z)(this,n),(i=e.call(this)).children=t,i.leaf=!1,i}return(0,o.Z)(n)}(w)},66020:function(t,e,n){n.d(e,{H:function(){return h}});var i=n(15671),a=n(43144),r=n(93169),s=n(13491),o={minX:0,minY:0,maxX:0,maxY:0};var h=function(){function t(){var e=this;(0,i.Z)(this,t),this._indexInvalid=!1,this._boundsToLoad=[],this._boundsById=new Map,this._idByBounds=new Map,this._index=new s.QB(9,(0,r.Z)("esri-csp-restrictions")?function(t){return{minX:t[0],minY:t[1],maxX:t[2],maxY:t[3]}}:["[0]","[1]","[2]","[3]"]),this._loadIndex=function(){if(e._indexInvalid){var t=new Array(e._idByBounds.size),n=0;e._idByBounds.forEach((function(e,i){t[n++]=i})),e._indexInvalid=!1,e._index.clear(),e._index.load(t)}else e._boundsToLoad.length&&(e._index.load(e._boundsToLoad.filter((function(t){return e._idByBounds.has(t)}))),e._boundsToLoad.length=0)}}return(0,a.Z)(t,[{key:"clear",value:function(){this._indexInvalid=!1,this._boundsToLoad.length=0,this._boundsById.clear(),this._idByBounds.clear(),this._index.clear()}},{key:"delete",value:function(t){var e=this._boundsById.get(t);this._boundsById.delete(t),e&&(this._idByBounds.delete(e),this._indexInvalid||this._index.remove(e))}},{key:"forEachInBounds",value:function(t,e){var n=this;this._loadIndex(),function(t,e,n){o.minX=e[0],o.minY=e[1],o.maxX=e[2],o.maxY=e[3],t.search(o,n)}(this._index,t,(function(t){return e(n._idByBounds.get(t))}))}},{key:"get",value:function(t){return this._boundsById.get(t)}},{key:"has",value:function(t){return this._boundsById.has(t)}},{key:"invalidateIndex",value:function(){this._indexInvalid||(this._indexInvalid=!0,this._boundsToLoad.length=0)}},{key:"set",value:function(t,e){if(!this._indexInvalid){var n=this._boundsById.get(t);n&&(this._index.remove(n),this._idByBounds.delete(n))}this._boundsById.set(t,e),e&&(this._idByBounds.set(e,t),this._indexInvalid||(this._boundsToLoad.push(e),this._boundsToLoad.length>5e4&&this._loadIndex()))}}]),t}()},68928:function(t,e,n){n.d(e,{Z:function(){return v}});var i=n(37762),a=n(15671),r=n(43144),s=n(10064),o=n(91505),h=n(32718),u=n(92026),d=n(41414),l=n(65156),c=n(83406),f=n(66020),m=n(77835),v=function(){function t(e){(0,a.Z)(this,t),this.geometryInfo=e,this._boundsStore=new f.H,this._featuresById=new Map,this._markedIds=new Set,this.events=new o.Z,this.featureAdapter=m.n}return(0,r.Z)(t,[{key:"geometryType",get:function(){return this.geometryInfo.geometryType}},{key:"hasM",get:function(){return this.geometryInfo.hasM}},{key:"hasZ",get:function(){return this.geometryInfo.hasZ}},{key:"numFeatures",get:function(){return this._featuresById.size}},{key:"fullBounds",get:function(){var t=this;if(!this.numFeatures)return null;var e=(0,l.Ue)(l.Gv);return this._featuresById.forEach((function(n){var i=t._boundsStore.get(n.objectId);i&&(e[0]=Math.min(i[0],e[0]),e[1]=Math.min(i[1],e[1]),e[2]=Math.max(i[2],e[2]),e[3]=Math.max(i[3],e[3]))})),e}},{key:"storeStatistics",get:function(){var t=0;return this._featuresById.forEach((function(e){(0,u.pC)(e.geometry)&&e.geometry.coords&&(t+=e.geometry.coords.length)})),{featureCount:this._featuresById.size,vertexCount:t/(this.hasZ?this.hasM?4:3:this.hasM?3:2)}}},{key:"add",value:function(t){this._add(t),this._emitChanged()}},{key:"addMany",value:function(t){var e,n=(0,i.Z)(t);try{for(n.s();!(e=n.n()).done;){var a=e.value;this._add(a)}}catch(r){n.e(r)}finally{n.f()}this._emitChanged()}},{key:"clear",value:function(){this._featuresById.clear(),this._boundsStore.clear(),this._emitChanged()}},{key:"removeById",value:function(t){var e=this._featuresById.get(t);return e?(this._remove(e),this._emitChanged(),e):null}},{key:"removeManyById",value:function(t){this._boundsStore.invalidateIndex();var e,n=(0,i.Z)(t);try{for(n.s();!(e=n.n()).done;){var a=e.value,r=this._featuresById.get(a);r&&this._remove(r)}}catch(s){n.e(s)}finally{n.f()}this._emitChanged()}},{key:"forEachBounds",value:function(t,e,n){var a,r=(0,i.Z)(t);try{for(r.s();!(a=r.n()).done;){var s=a.value,o=this._boundsStore.get(s.objectId);o&&e((0,d.JR)(n,o))}}catch(h){r.e(h)}finally{r.f()}}},{key:"getFeature",value:function(t){return this._featuresById.get(t)}},{key:"has",value:function(t){return this._featuresById.has(t)}},{key:"forEach",value:function(t){this._featuresById.forEach((function(e){return t(e)}))}},{key:"forEachInBounds",value:function(t,e){var n=this;this._boundsStore.forEachInBounds(t,(function(t){e(n._featuresById.get(t))}))}},{key:"startMarkingUsedFeatures",value:function(){this._boundsStore.invalidateIndex(),this._markedIds.clear()}},{key:"sweep",value:function(){var t=this,e=!1;this._featuresById.forEach((function(n,i){t._markedIds.has(i)||(e=!0,t._remove(n))})),this._markedIds.clear(),e&&this._emitChanged()}},{key:"_emitChanged",value:function(){this.events.emit("changed",void 0)}},{key:"_add",value:function(t){if(t){var e=t.objectId;if(null!=e){var n,i=this._featuresById.get(e);if(this._markedIds.add(e),i?(t.displayId=i.displayId,n=this._boundsStore.get(e),this._boundsStore.delete(e)):(0,u.pC)(this.onFeatureAdd)&&this.onFeatureAdd(t),(0,u.Wi)(t.geometry)||!t.geometry.coords||!t.geometry.coords.length)return this._boundsStore.set(e,null),void this._featuresById.set(e,t);n=(0,c.$)((0,u.pC)(n)?n:(0,l.Ue)(),t.geometry,this.geometryInfo.hasZ,this.geometryInfo.hasM),(0,u.pC)(n)&&this._boundsStore.set(e,n),this._featuresById.set(e,t)}else h.Z.getLogger("esri.layers.graphics.data.FeatureStore").error(new s.Z("featurestore:invalid-feature","feature id is missing",{feature:t}))}}},{key:"_remove",value:function(t){return(0,u.pC)(this.onFeatureRemove)&&this.onFeatureRemove(t),this._markedIds.delete(t.objectId),this._boundsStore.delete(t.objectId),this._featuresById.delete(t.objectId),t}}]),t}()},77835:function(t,e,n){n.d(e,{n:function(){return s}});var i=n(85403),a=n(3182),r=n(80457),s={getObjectId:function(t){return t.objectId},getAttributes:function(t){return t.attributes},getAttribute:function(t,e){return t.attributes[e]},cloneWithGeometry:function(t,e){return new a.ZP(e,t.attributes,null,t.objectId)},getGeometry:function(t){return t.geometry},getCentroid:function(t,e){return t.centroid||(t.centroid=(0,i.Y)(new r.Z,t.geometry,e.hasZ,e.hasM)),t.centroid}}}}]);
//# sourceMappingURL=8928.2026a7e8.chunk.js.map