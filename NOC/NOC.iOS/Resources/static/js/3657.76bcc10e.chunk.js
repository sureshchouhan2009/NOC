"use strict";(self.webpackChunketihadrailapp=self.webpackChunketihadrailapp||[]).push([[3657],{23657:function(e,r,n){n.r(r),n.d(r,{clearBoundingBoxCache:function(){return h},computeIconLayerResourceSize:function(){return d},computeLayerResourceSize:function(){return y},computeLayerSize:function(){return b},computeObjectLayerResourceSize:function(){return k}});var t=n(15861),u=n(87757),i=n(76200),o=n(10064),c=n(59026),s=n(92026),a=n(41414),p=n(53720),f=l();function l(){return new c.Z(50)}function h(){f=l()}function y(e,r){if("icon"===e.type)return d(e,r);if("object"===e.type)return k(e,r);throw new o.Z("symbol3d:unsupported-symbol-layer","computeLayerSize only works with symbol layers of type Icon and Object")}function b(e,r){return m.apply(this,arguments)}function m(){return(m=(0,t.Z)(u.mark((function e(r,n){return u.wrap((function(e){for(;;)switch(e.prev=e.next){case 0:if("icon"!==r.type){e.next=2;break}return e.abrupt("return",v(r,n));case 2:if("object"!==r.type){e.next=4;break}return e.abrupt("return",z(r,n));case 4:throw new o.Z("symbol3d:unsupported-symbol-layer","computeLayerSize only works with symbol layers of type Icon and Object");case 5:case"end":return e.stop()}}),e)})))).apply(this,arguments)}function d(e,r){return w.apply(this,arguments)}function w(){return(w=(0,t.Z)(u.mark((function e(r,n){return u.wrap((function(e){for(;;)switch(e.prev=e.next){case 0:if(!r.resource.href){e.next=2;break}return e.abrupt("return",x(r.resource.href).then((function(e){return[e.width,e.height]})));case 2:if(!r.resource.primitive){e.next=4;break}return e.abrupt("return",(0,s.pC)(n)?[n,n]:[256,256]);case 4:throw new o.Z("symbol3d:invalid-symbol-layer","symbol layers of type Icon must have either an href or a primitive resource");case 5:case"end":return e.stop()}}),e)})))).apply(this,arguments)}function v(e,r){return d(e,r).then((function(r){if(null==e.size)return r;var n=r[0]/r[1];return n>1?[e.size,e.size/n]:[e.size*n,e.size]}))}function x(e){return(0,i.default)(e,{responseType:"image"}).then((function(e){return e.data}))}function k(e,r){return function(e,r){return g.apply(this,arguments)}(e,r).then((function(e){return(0,a.dp)(e)}))}function z(e,r){return Z.apply(this,arguments)}function Z(){return(Z=(0,t.Z)(u.mark((function e(r,n){var t;return u.wrap((function(e){for(;;)switch(e.prev=e.next){case 0:return e.next=2,k(r,n);case 2:return t=e.sent,e.abrupt("return",(0,p.$K)(t,r));case 4:case"end":return e.stop()}}),e)})))).apply(this,arguments)}function g(){return(g=(0,t.Z)(u.mark((function e(r,t){var i,c,l,h,y,b;return u.wrap((function(e){for(;;)switch(e.prev=e.next){case 0:if(r.isPrimitive){e.next=11;break}if(i=r.resource.href,void 0===(c=f.get(i))){e.next=4;break}return e.abrupt("return",Promise.resolve(c));case 4:return e.next=6,Promise.all([n.e(1048),n.e(5158),n.e(4032),n.e(6113),n.e(6888),n.e(8945)]).then(n.bind(n,4265));case 6:return l=e.sent,e.next=9,l.fetch(i,{disableTextures:!0});case 9:return h=e.sent,e.abrupt("return",(f.put(i,h.referenceBoundingBox),h.referenceBoundingBox));case 11:if(y=null,r.resource&&r.resource.primitive&&(y=(0,a.Ue)((0,p.Uz)(r.resource.primitive)),(0,s.pC)(t)))for(b=0;b<y.length;b++)y[b]*=t;return e.abrupt("return",y?Promise.resolve(y):Promise.reject(new o.Z("symbol:invalid-resource","The symbol does not have a valid resource")));case 14:case"end":return e.stop()}}),e)})))).apply(this,arguments)}}}]);
//# sourceMappingURL=3657.76bcc10e.chunk.js.map