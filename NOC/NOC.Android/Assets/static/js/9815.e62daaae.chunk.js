"use strict";(self.webpackChunketihadrailapp=self.webpackChunketihadrailapp||[]).push([[9815],{6388:function(e,t,r){r.d(t,{RL:function(){return u},bk:function(){return s},Fp:function(){return f},UV:function(){return m}});var i=r(29439),a=r(37762),o=r(46228),n=r(77981),l=r(691);function f(e){if(!e)return null;switch(e.type){case"CIMPointSymbol":var t=e.symbolLayers;return t&&1===t.length?f(t[0]):null;case"CIMVectorMarker":var r,i=e.markerGraphics;if(!i||1!==i.length)return null;var a=i[0];if(!a)return null;var o=a.geometry;if(!o)return null;var n=a.symbol;return!n||"CIMPolygonSymbol"!==n.type&&"CIMLineSymbol"!==n.type||null!=(r=n.symbolLayers)&&r.some((function(e){return!!e.effects}))?null:{geom:o,asFill:"CIMPolygonSymbol"===n.type};case"sdf":return{geom:e.geom,asFill:e.asFill}}return null}function c(e){var t,r=1/0,i=-1/0,o=1/0,n=-1/0,l=(0,a.Z)(e);try{for(l.s();!(t=l.n()).done;){var f,c=t.value,s=(0,a.Z)(c);try{for(s.s();!(f=s.n()).done;){var m=f.value;m[0]<r&&(r=m[0]),m[0]>i&&(i=m[0]),m[1]<o&&(o=m[1]),m[1]>n&&(n=m[1])}}catch(u){s.e(u)}finally{s.f()}}}catch(u){l.e(u)}finally{l.f()}return[r,o,i,n]}function s(e){return e?e.rings?c(e.rings):e.paths?c(e.paths):(0,n.YX)(e)?[e.xmin,e.ymin,e.xmax,e.ymax]:null:null}function m(e,t,r,a,o){var n=(0,i.Z)(e,4),l=n[0],f=n[1],c=n[2],s=n[3];if(c<l||s<f)return[0,0,0];var m=c-l,u=s-f,h=Math.floor(31.5),y=(128-2*(h+1))/Math.max(m,u),v=Math.round(m*y)+2*h,p=Math.round(u*y)+2*h,d=1;t&&(d=p/y/(t.ymax-t.ymin));var g=0,S=0;if(a)if(o){if(t&&r&&t.ymax-t.ymin>0){var N=(t.xmax-t.xmin)/(t.ymax-t.ymin);g=a.x/(r*N),S=a.y/r}}else g=a.x,S=a.y;return g=.5*(t.xmax+t.xmin)+g*(t.xmax-t.xmin),S=.5*(t.ymax+t.ymin)+S*(t.ymax-t.ymin),g-=l,S-=f,g*=y,S*=y,[d,(g+=h)/v-.5,-((S+=h)/p-.5)]}function u(e){var t,r=function(e){return e?e.rings?e.rings:e.paths?e.paths:void 0!==e.xmin&&void 0!==e.ymin&&void 0!==e.xmax&&void 0!==e.ymax?[[[e.xmin,e.ymin],[e.xmin,e.ymax],[e.xmax,e.ymax],[e.xmax,e.ymin],[e.xmin,e.ymin]]]:null:null}(e.geom),o=function(e){var t,r=1/0,i=-1/0,o=1/0,n=-1/0,f=(0,a.Z)(e);try{for(f.s();!(t=f.n()).done;){var c,s=t.value,m=(0,a.Z)(s);try{for(m.s();!(c=m.n()).done;){var u=c.value;u[0]<r&&(r=u[0]),u[0]>i&&(i=u[0]),u[1]<o&&(o=u[1]),u[1]>n&&(n=u[1])}}catch(h){m.e(h)}finally{m.f()}}}catch(h){f.e(h)}finally{f.f()}return new l.Z(r,o,i-r,n-o)}(r),n=Math.floor(31.5),f=(128-2*(n+1))/Math.max(o.width,o.height),c=Math.round(o.width*f)+2*n,s=Math.round(o.height*f)+2*n,m=[],u=(0,a.Z)(r);try{for(u.s();!(t=u.n()).done;){var y=t.value;if(y&&y.length>1){var v,p=[],d=(0,a.Z)(y);try{for(d.s();!(v=d.n()).done;){var g=v.value,S=(0,i.Z)(g,2),N=S[0],b=S[1];N-=o.x,b-=o.y,N*=f,b*=f,N+=n-.5,b+=n-.5,e.asFill?p.push([N,b]):p.push([Math.round(N),Math.round(b)])}}catch(O){d.e(O)}finally{d.f()}if(e.asFill){var k=p.length-1;p[0][0]===p[k][0]&&p[0][1]===p[k][1]||p.push(p[0])}m.push(p)}}}catch(O){u.e(O)}finally{u.f()}var C=function(e,t,r,i){for(var o=t*r,n=new Array(o),l=i*i+1,f=0;f<o;++f)n[f]=l;var c,s=(0,a.Z)(e);try{for(s.s();!(c=s.n()).done;)for(var m=c.value,u=m.length,h=1;h<u;++h){var y=m[h-1],v=m[h],p=void 0,d=void 0,g=void 0,S=void 0;y[0]<v[0]?(p=y[0],d=v[0]):(p=v[0],d=y[0]),y[1]<v[1]?(g=y[1],S=v[1]):(g=v[1],S=y[1]);var N=Math.floor(p)-i,b=Math.floor(d)+i,k=Math.floor(g)-i,C=Math.floor(S)+i;N<0&&(N=0),b>t&&(b=t),k<0&&(k=0),C>r&&(C=r);for(var P=v[0]-y[0],x=v[1]-y[1],M=P*P+x*x,I=N;I<b;I++)for(var w=k;w<C;w++){var L=void 0,A=void 0,Z=(I-y[0])*P+(w-y[1])*x;Z<0?(L=y[0],A=y[1]):Z>M?(L=v[0],A=v[1]):(Z/=M,L=y[0]+Z*P,A=y[1]+Z*x);var X=(I-L)*(I-L)+(w-A)*(w-A),z=(r-w-1)*t+I;X<n[z]&&(n[z]=X)}}}catch(O){s.e(O)}finally{s.f()}for(var J=0;J<o;++J)n[J]=Math.sqrt(n[J]);return n}(m,c,s,n);return e.asFill&&function(e,t,r,i,o){var n,l=(0,a.Z)(e);try{for(l.s();!(n=l.n()).done;)for(var f=n.value,c=f.length,s=1;s<c;++s){var m=f[s-1],u=f[s],h=void 0,y=void 0,v=void 0,p=void 0;m[0]<u[0]?(h=m[0],y=u[0]):(h=u[0],y=m[0]),m[1]<u[1]?(v=m[1],p=u[1]):(v=u[1],p=m[1]);var d=Math.floor(h),g=Math.floor(y)+1,S=Math.floor(v),N=Math.floor(p)+1;d<i&&(d=i),g>t-i&&(g=t-i),S<i&&(S=i),N>r-i&&(N=r-i);for(var b=S;b<N;++b)if(m[1]>b!=u[1]>b){for(var k=(r-b-1)*t,C=d;C<g;++C)C<(u[0]-m[0])*(b-m[1])/(u[1]-m[1])+m[0]&&(o[k+C]=-o[k+C]);for(var P=i;P<d;++P)o[k+P]=-o[k+P]}}}catch(O){l.e(O)}finally{l.f()}}(m,c,s,n,C),[h(C,n),c,s]}function h(e,t){for(var r=2*t,i=e.length,a=new Uint8Array(4*i),n=0;n<i;++n){var l=.5-e[n]/r;(0,o.I)(l,a,4*n)}return a}},79815:function(e,t,r){r.d(t,{S:function(){return j},c:function(){return M}});var i=r(1413),a=r(37762),o=r(29439),n=r(93433),l=r(15861),f=r(87757),c=r(51995),s=r(32718),m=r(92026),u=r(17842),h=r(643),y=r(819),v=r(78915),p=r(6388),d=r(31027),g=r(95954),S=r(91935),N=s.Z.getLogger("esri.symbols.cim.cimAnalyzer");function b(e){switch(e){case"Butt":return 0;case"Square":return 2;default:return 1}}function k(e){switch(e){case"Bevel":return 0;case"Miter":return 2;default:return 1}}function C(e){switch(e){case"Left":default:return"left";case"Right":return"right";case"Center":return"center";case"Justify":return"justify"}}function O(e){switch(e){case"Top":default:return"top";case"Center":return"middle";case"Baseline":return"baseline";case"Bottom":return"bottom"}}function P(e,t,r,i){var a;e[t]?a=e[t]:(a={},e[t]=a),a[r]=i}function x(e){var t=e.markerPlacement;return t&&t.angleToLine?1:0}function M(e,t,r,i,a){return I.apply(this,arguments)}function I(){return(I=(0,l.Z)(f.mark((function e(t,r,i,o,n){var l,c,s,m,u,h,v,p,d;return f.wrap((function(e){for(;;)switch(e.prev=e.next){case 0:if(l=null!=o?o:[],t){e.next=3;break}return e.abrupt("return",l);case 3:if(m={},"CIMSymbolReference"===t.type){e.next=6;break}return e.abrupt("return",(N.error("Expect cim type to be 'CIMSymbolReference'"),l));case 6:if(c=t.symbol,!(s=t.primitiveOverrides)){e.next=14;break}u=[],h=(0,a.Z)(s);try{for(p=function(){var e=v.value,t=e.valueExpressionInfo;if(t&&r){var i=t.expression,a=(0,y.Yi)(i,r.spatialReference,r.fields).then((function(t){t&&P(m,e.primitiveName,e.propertyName,t)}));u.push(a)}else null!=e.value&&P(m,e.primitiveName,e.propertyName,e.value)},h.s();!(v=h.n()).done;)p()}catch(f){h.e(f)}finally{h.f()}if(e.t0=u.length>0,!e.t0){e.next=14;break}return e.next=14,Promise.all(u);case 14:if(V(c,i,d=[]),e.t2=d.length>0,!e.t2){e.next=20;break}return e.next=20,Promise.all(d);case 20:e.t1=c.type,e.next="CIMPointSymbol"===e.t1||"CIMLineSymbol"===e.t1||"CIMPolygonSymbol"===e.t1?23:24;break;case 23:w(c,s,m,r,l,i,n);case 24:return e.abrupt("return",l);case 25:case"end":return e.stop()}}),e)})))).apply(this,arguments)}function w(e,t,r,i,a,o,l){if(e){var f=e.symbolLayers;if(f){var c,s=e.effects,m=v.B$.getSize(e);"CIMPointSymbol"===e.type&&"Map"===e.angleAlignment&&(c=1);for(var u=f.length;u--;){var h,y=f[u];if(y&&!1!==y.enable){var p=void 0;s&&s.length&&(p=(0,n.Z)(s));var d=y.effects;d&&d.length&&(s?(h=p).push.apply(h,(0,n.Z)(d)):p=(0,n.Z)(d));var g=[];switch(v.E0.findApplicableOverrides(y,t,g),y.type){case"CIMSolidFill":L(y,p,r,g,i,a);break;case"CIMPictureFill":A(y,p,r,g,i,o,a);break;case"CIMHatchFill":Z(y,p,r,g,i,a);break;case"CIMGradientFill":X(y,p,r,g,i,a);break;case"CIMSolidStroke":z(y,p,r,g,i,a,"CIMPolygonSymbol"===e.type,m);break;case"CIMPictureStroke":J(y,p,r,g,i,a,"CIMPolygonSymbol"===e.type,m);break;case"CIMGradientStroke":Y(y,p,r,g,i,a,"CIMPolygonSymbol"===e.type,m);break;case"CIMCharacterMarker":if(H(y,p,r,g,i,a))break;break;case"CIMPictureMarker":if(H(y,p,r,g,i,a))break;"CIMLineSymbol"===e.type&&(c=x(y)),R(y,p,r,g,i,o,a,c,m);break;case"CIMVectorMarker":if(H(y,p,r,g,i,a))break;"CIMLineSymbol"===e.type&&(c=x(y)),F(y,p,r,g,i,a,o,c,m,l);break;default:N.error("Cannot analyze CIM layer",y.type)}}}}}}function L(e,t,r,i,a,n){var l=e.primitiveName,f=(0,d.NO)(e.color),c=D(i,l),s=(0,o.Z)(c,2),m=s[0],u=s[1],y=(0,h.hP)(JSON.stringify(e)+u).toString();n.push({type:"fill",templateHash:y,materialHash:m?function(){return y}:y,cim:e,materialOverrides:null,colorLocked:e.colorLocked,color:G(l,r,"Color",a,f,T),height:0,angle:0,offsetX:0,offsetY:0,scaleX:1,effects:t})}function A(e,t,r,i,a,n,l){var f=e.primitiveName,c=e.tintColor?(0,d.NO)(e.tintColor):{r:255,g:255,b:255,a:1},s=D(i,f),u=(0,o.Z)(s,2),y=u[0],v=u[1],p=(0,h.hP)(JSON.stringify(e)+v).toString(),g=(0,h.hP)("".concat(e.url).concat(JSON.stringify(e.colorSubstitutions))).toString(),S=(0,d.NA)(e.scaleX);if("width"in e){var N=e.width,b=1,k=n.getResource(e.url);(0,m.pC)(k)&&(b=k.width/k.height),S/=b*(e.height/N)}l.push({type:"fill",templateHash:p,materialHash:y?function(){return g}:g,cim:e,materialOverrides:null,colorLocked:e.colorLocked,effects:t,color:G(f,r,"TintColor",a,c,T),height:G(f,r,"Height",a,e.height),scaleX:G(f,r,"ScaleX",a,S),angle:G(f,r,"Rotation",a,(0,d.NA)(e.rotation)),offsetX:G(f,r,"OffsetX",a,(0,d.NA)(e.offsetX)),offsetY:G(f,r,"OffsetY",a,(0,d.NA)(e.offsetY)),url:e.url})}function Z(e,t,r,i,a,n){var l=["Rotation","OffsetX","OffsetY"],f=i.filter((function(t){return t.primitiveName!==e.primitiveName&&-1===l.indexOf(t.propertyName)})),c=e.primitiveName,s=D(i,c),m=(0,o.Z)(s,2),u=m[0],y=m[1],v=(0,h.hP)(JSON.stringify(e)+y).toString(),p=(0,h.hP)("".concat(e.separation).concat(JSON.stringify(e.lineSymbol))).toString();n.push({type:"fill",templateHash:v,materialHash:u?U(p,r,f,a):p,cim:e,materialOverrides:f,colorLocked:e.colorLocked,effects:t,color:{r:255,g:255,b:255,a:1},height:G(c,r,"Separation",a,e.separation),scaleX:1,angle:G(c,r,"Rotation",a,(0,d.NA)(e.rotation)),offsetX:G(c,r,"OffsetX",a,(0,d.NA)(e.offsetX)),offsetY:G(c,r,"OffsetY",a,(0,d.NA)(e.offsetY))})}function X(e,t,r,i,a,n){var l=D(i,e.primitiveName),f=(0,o.Z)(l,2),c=f[0],s=f[1],m=(0,h.hP)(JSON.stringify(e)+s).toString();n.push({type:"fill",templateHash:m,materialHash:c?U(m,r,i,a):m,cim:e,materialOverrides:null,colorLocked:e.colorLocked,effects:t,color:{r:128,g:128,b:128,a:1},height:0,angle:0,offsetX:0,offsetY:0,scaleX:1})}function z(e,t,r,i,a,l,f,c){var s,m,u=e.primitiveName,y=(0,d.NO)(e.color),v=void 0!==e.width?e.width:4,p=b(e.capStyle),g=k(e.joinStyle),S=e.miterLimit,N=D(i,u),C=(0,o.Z)(N,2),O=C[0],P=C[1],x=(0,h.hP)(JSON.stringify(e)+P).toString();if(t&&t.length>0){var M=t[t.length-1];if("CIMGeometricEffectDashes"===M.type&&"NoConstraint"===M.lineDashEnding){var I=(t=(0,n.Z)(e.effects)).pop();s=I.dashTemplate,m=I.scaleDash}}l.push({type:"line",templateHash:x,materialHash:O?function(){return x}:x,cim:e,materialOverrides:null,isOutline:f,colorLocked:e.colorLocked,effects:t,color:G(u,r,"Color",a,y,T),width:G(u,r,"Width",a,v),cap:G(u,r,"CapStyle",a,p),join:G(u,r,"JoinStyle",a,g),miterLimit:G(u,r,"MiterLimit",a,S),referenceWidth:c,zOrder:$(e.name),dashTemplate:s,scaleDash:m})}function J(e,t,r,i,a,n,l,f){var c=(0,h.hP)("".concat(e.url).concat(JSON.stringify(e.colorSubstitutions))).toString(),s=e.primitiveName,m=(0,d.NO)(e.tintColor),u=void 0!==e.width?e.width:4,y=b(e.capStyle),v=k(e.joinStyle),p=e.miterLimit,g=D(i,s),S=(0,o.Z)(g,2),N=S[0],C=S[1],O=(0,h.hP)(JSON.stringify(e)+C).toString();n.push({type:"line",templateHash:O,materialHash:N?function(){return c}:c,cim:e,materialOverrides:null,isOutline:l,colorLocked:e.colorLocked,effects:t,color:G(s,r,"TintColor",a,m,T),width:G(s,r,"Width",a,u),cap:G(s,r,"CapStyle",a,y),join:G(s,r,"JoinStyle",a,v),miterLimit:G(s,r,"MiterLimit",a,p),referenceWidth:f,zOrder:$(e.name),dashTemplate:null,scaleDash:!1,url:e.url})}function Y(e,t,r,i,a,n,l,f){var c=e.primitiveName,s=void 0!==e.width?e.width:4,m=b(e.capStyle),u=k(e.joinStyle),y=e.miterLimit,v=D(i,c),p=(0,o.Z)(v,2),d=p[0],g=p[1],S=(0,h.hP)(JSON.stringify(e)+g).toString();n.push({type:"line",templateHash:S,materialHash:d?U(S,r,i,a):S,cim:e,materialOverrides:null,isOutline:l,colorLocked:e.colorLocked,effects:t,color:{r:128,g:128,b:128,a:1},width:G(c,r,"Width",a,s),cap:G(c,r,"CapStyle",a,m),join:G(c,r,"JoinStyle",a,u),miterLimit:G(c,r,"MiterLimit",a,y),referenceWidth:f,zOrder:$(e.name),dashTemplate:null,scaleDash:!1})}function H(e,t,r,i,a,n){var l=e.markerPlacement;if(!l||"CIMMarkerPlacementInsidePolygon"!==l.type)return!1;var f=l,c=["Rotation","OffsetX","OffsetY"],s=i.filter((function(t){return t.primitiveName!==e.primitiveName&&-1===c.indexOf(t.propertyName)})),m="url"in e?e.url:null,u=D(i,f.primitiveName),y=(0,o.Z)(u,2),v=y[0],p=y[1],g=(0,h.hP)(JSON.stringify(e)+p).toString(),S=f.stepY,N=null,b=1;return l.shiftOddRows&&(S*=2,N=function(e){return e?2*e:0},b=.5),n.push({type:"fill",templateHash:g,materialHash:v?U(g,r,s,a):g,cim:e,materialOverrides:s,colorLocked:e.colorLocked,effects:t,color:{r:255,g:255,b:255,a:1},height:G(f.primitiveName,r,"StepY",a,S,N),scaleX:b,angle:G(f.primitiveName,r,"GridAngle",a,f.gridAngle),offsetX:G(f.primitiveName,r,"OffsetX",a,(0,d.NA)(f.offsetX)),offsetY:G(f.primitiveName,r,"OffsetY",a,(0,d.NA)(f.offsetY)),url:m}),!0}function R(e,t,r,i,a,n,l,f,c){var s,u=e.primitiveName,y=(0,d.NA)(e.size),v=(0,d.NA)(e.scaleX),p=(0,d.NA)(e.rotation),g=(0,d.NA)(e.offsetX),S=(0,d.NA)(e.offsetY),N=e.tintColor?(0,d.NO)(e.tintColor):{r:255,g:255,b:255,a:1},b=(0,h.hP)("".concat(e.url).concat(JSON.stringify(e.colorSubstitutions))).toString(),k=D(i,u),C=(0,o.Z)(k,2),O=C[0],P=C[1],x=(0,h.hP)(JSON.stringify(e)+P).toString(),M=null!=(s=e.anchorPoint)?s:{x:0,y:0};if("width"in e){var I=e.width,w=1,L=n.getResource(e.url);(0,m.pC)(L)&&(w=L.width/L.height),v/=w*(y/I)}l.push({type:"marker",templateHash:x,materialHash:O?function(){return b}:b,cim:e,materialOverrides:null,colorLocked:e.colorLocked,effects:t,scaleSymbolsProportionally:!1,alignment:f,size:G(u,r,"Size",a,y),scaleX:G(u,r,"ScaleX",a,v),rotation:G(u,r,"Rotation",a,p),offsetX:G(u,r,"OffsetX",a,g),offsetY:G(u,r,"OffsetY",a,S),color:G(u,r,"TintColor",a,N,T),anchorPoint:{x:M.x,y:-M.y},isAbsoluteAnchorPoint:"Relative"!==e.anchorPointUnits,outlineColor:{r:0,g:0,b:0,a:0},outlineWidth:0,frameHeight:0,rotateClockwise:e.rotateClockwise,referenceSize:c,sizeRatio:1,markerPlacement:e.markerPlacement,url:e.url})}function F(e,t,r,i,o,n,l,f,c,s){var m=e.markerGraphics;if(m){var u=0;if(e.scaleSymbolsProportionally){var h=e.frame;h&&(u=h.ymax-h.ymin)}var y,v=(0,a.Z)(m);try{for(v.s();!(y=v.n()).done;){var p=y.value;if(p){var d=p.symbol;if(!d)continue;switch(d.type){case"CIMPointSymbol":case"CIMLineSymbol":case"CIMPolygonSymbol":E(e,t,p,i,r,o,n,l,f,c,u,s);break;case"CIMTextSymbol":B(e,t,p,r,i,o,n,f,c,u)}}}}catch(g){v.e(g)}finally{v.f()}}}function B(e,t,r,a,n,l,f,c,s,m){v.E0.findApplicableOverrides(r,n,[]);var u=r.geometry;if("x"in u&&"y"in u){var y=r.symbol,p=function(e){return e.underline?"underline":e.strikethrough?"line-through":"none"}(y),g=function(e){var t="",r="";if(e){var i=e.toLowerCase();-1!==i.indexOf("italic")?t="italic":-1!==i.indexOf("oblique")&&(t="oblique"),-1!==i.indexOf("bold")?r="bold":-1!==i.indexOf("light")&&(r="lighter")}return{style:t,weight:r}}(y.fontStyleName),S=(0,d.mA)(y.fontFamilyName);y.font=(0,i.Z)({family:S,decoration:p},g);var N=e.frame,b=u.x-.5*(N.xmin+N.xmax),k=u.y-.5*(N.ymin+N.ymax),P=e.size/m,x=e.primitiveName,M=(0,d.NA)(y.height)*P,I=(0,d.NA)(y.angle),w=((0,d.NA)(y.offsetX)+b)*P,L=((0,d.NA)(y.offsetY)+k)*P,A=(0,d.NO)(v.B$.getFillColor(y)),Z=(0,d.NO)(v.B$.getStrokeColor(y)),X=v.B$.getStrokeWidth(y);X||(Z=(0,d.NO)(v.B$.getFillColor(y.haloSymbol)),X=y.haloSize*P);var z=D(n,x),J=(0,o.Z)(z,2),Y=J[0],H=J[1],R=JSON.stringify(e.effects)+Number(e.colorLocked)+JSON.stringify(e.anchorPoint)+e.anchorPointUnits+JSON.stringify(e.markerPlacement),F=(0,h.hP)(JSON.stringify(r)+R+H).toString(),B=G(r.primitiveName,a,"TextString",l,r.textString,d.X3,y.textCase),E=y.fontStyleName,W=S+(E?"-"+E.toLowerCase():"-regular"),$=W;f.push({type:"text",templateHash:F,materialHash:Y||"function"==typeof B||B.match(/\[(.*?)\]/)?function(e,t,r){return $+"-"+(0,d.hf)(B,e,t,r)}:$+"-"+(0,h.hP)(B),cim:y,materialOverrides:null,colorLocked:e.colorLocked,effects:t,alignment:c,anchorPoint:{x:e.anchorPoint?e.anchorPoint.x:0,y:e.anchorPoint?e.anchorPoint.y:0},isAbsoluteAnchorPoint:"Relative"!==e.anchorPointUnits,fontName:W,decoration:p,weight:G(x,a,"Weight",l,g.weight),style:G(x,a,"Size",l,g.style),size:G(x,a,"Size",l,M),angle:G(x,a,"Rotation",l,I),offsetX:G(x,a,"OffsetX",l,w),offsetY:G(x,a,"OffsetY",l,L),horizontalAlignment:C(y.horizontalAlignment),verticalAlignment:O(y.verticalAlignment),text:B,color:A,outlineColor:Z,outlineSize:X,referenceSize:s,sizeRatio:1,markerPlacement:e.markerPlacement})}}function E(e,t,r,n,l,f,c,s,m,u,y,S){var N=r.symbol,b=N.symbolLayers;if(b)if(S)W(e,t,r,l,n,f,c,s,m,u,y);else{var k=b.length;if(q(b))!function(e,t,r,n,l,f,c,s,m,u){var y=t.geometry,g=r[0],S=r[1],N=(0,p.bk)(y);if(!N)return;var b,k=(0,p.UV)(N,e.frame,e.size,e.anchorPoint,"Relative"!==e.anchorPointUnits),C=(0,o.Z)(k,3),O=C[0],P=C[1],x=C[2],M={type:"sdf",geom:y,asFill:!0},I=e.primitiveName,w=(0,d.NA)(e.size),L=(0,d.NA)(e.rotation),A=(0,d.NA)(e.offsetX),Z=(0,d.NA)(e.offsetY),X=S.path,z=S.primitiveName,J=g.primitiveName,Y=(0,d.NO)(v.B$.getFillColor(S)),H=(0,d.NO)(v.B$.getStrokeColor(g)),R=v.B$.getStrokeWidth(g),F=!1,B="",E=(0,a.Z)(n);try{for(E.s();!(b=E.n()).done;){var W=b.value;W.primitiveName!==z&&W.primitiveName!==J&&W.primitiveName!==I||(void 0!==W.value?B+="-".concat(W.primitiveName,"-").concat(W.propertyName,"-").concat(JSON.stringify(W.value)):W.valueExpressionInfo&&(F=!0))}}catch(D){E.e(D)}finally{E.f()}var $=JSON.stringify((0,i.Z)((0,i.Z)({},e),{},{markerGraphics:null})),U=(0,h.hP)(JSON.stringify(M)+X).toString(),j={type:"marker",templateHash:(0,h.hP)(JSON.stringify(t)+JSON.stringify(S)+JSON.stringify(g)+$+B).toString(),materialHash:F?function(){return U}:U,cim:M,materialOverrides:null,colorLocked:e.colorLocked,effects:e.effects,scaleSymbolsProportionally:e.scaleSymbolsProportionally,alignment:s,anchorPoint:{x:P,y:x},isAbsoluteAnchorPoint:!1,size:G(e.primitiveName,l,"Size",f,w),rotation:G(e.primitiveName,l,"Rotation",f,L),offsetX:G(e.primitiveName,l,"OffsetX",f,A),offsetY:G(e.primitiveName,l,"OffsetY",f,Z),scaleX:1,frameHeight:u,rotateClockwise:e.rotateClockwise,referenceSize:m,sizeRatio:O,color:G(z,l,"Color",f,Y,T),outlineColor:G(J,l,"Color",f,H,T),outlineWidth:G(J,l,"Width",f,R),markerPlacement:e.markerPlacement,path:X};c.push(j)}(e,r,b,n,l,f,c,m,u,y);else{var C=g.j.applyEffects(N.effects,r.geometry);if(C)for(;k--;){var O=b[k];if(O&&!1!==O.enable)switch(O.type){case"CIMSolidFill":case"CIMSolidStroke":var P,x=function(){var s=g.j.applyEffects(O.effects,C),S=(0,p.bk)(s);if(!S)return"continue";var N=(0,p.UV)(S,e.frame,e.size,e.anchorPoint,"Relative"!==e.anchorPointUnits),b=(0,o.Z)(N,3),k=b[0],x=b[1],M=b[2],I="CIMSolidFill"===O.type,w={type:"sdf",geom:s,asFill:I},L=e.primitiveName,A=null!=(P=(0,d.NA)(e.size))?P:10,Z=(0,d.NA)(e.rotation),X=(0,d.NA)(e.offsetX),z=(0,d.NA)(e.offsetY),J=O.path,Y=O.primitiveName,H=(0,d.NO)(I?v.B$.getFillColor(O):v.B$.getStrokeColor(O)),R=I?{r:0,g:0,b:0,a:0}:(0,d.NO)(v.B$.getStrokeColor(O)),F=v.B$.getStrokeWidth(O);if(!I&&!F)return"break";var B,E=!1,W="",$=(0,a.Z)(n);try{for($.s();!(B=$.n()).done;){var U=B.value;U.primitiveName!==Y&&U.primitiveName!==L||(void 0!==U.value?W+="-".concat(U.primitiveName,"-").concat(U.propertyName,"-").concat(JSON.stringify(U.value)):U.valueExpressionInfo&&(E=!0))}}catch(q){$.e(q)}finally{$.f()}var j=JSON.stringify((0,i.Z)((0,i.Z)({},e),{},{markerGraphics:null})),D=(0,h.hP)(JSON.stringify(w)+J).toString(),V={type:"marker",templateHash:(0,h.hP)(JSON.stringify(r)+JSON.stringify(O)+j+W).toString(),materialHash:E?function(){return D}:D,cim:w,materialOverrides:null,colorLocked:e.colorLocked,effects:t,scaleSymbolsProportionally:e.scaleSymbolsProportionally,alignment:m,anchorPoint:{x:x,y:M},isAbsoluteAnchorPoint:!1,size:G(e.primitiveName,l,"Size",f,A),rotation:G(e.primitiveName,l,"Rotation",f,Z),offsetX:G(e.primitiveName,l,"OffsetX",f,X),offsetY:G(e.primitiveName,l,"OffsetY",f,z),scaleX:1,frameHeight:y,rotateClockwise:e.rotateClockwise,referenceSize:u,sizeRatio:k,color:G(Y,l,"Color",f,H,T),outlineColor:G(Y,l,"Color",f,R,T),outlineWidth:G(Y,l,"Width",f,F),markerPlacement:e.markerPlacement,path:J};return c.push(V),"break"}();if("continue"===x)continue;if("break"===x)break;default:W(e,t,r,l,n,f,c,s,m,u,y)}}}}}function W(e,t,r,i,n,l,f,c,s,m,y){var p,g=function(e,t){return{type:e.type,enable:!0,name:e.name,colorLocked:e.colorLocked,primitiveName:e.primitiveName,anchorPoint:e.anchorPoint,anchorPointUnits:e.anchorPointUnits,offsetX:0,offsetY:0,rotateClockwise:e.rotateClockwise,rotation:0,size:e.size,billboardMode3D:e.billboardMode3D,depth3D:e.depth3D,frame:e.frame,markerGraphics:[t],scaleSymbolsProportionally:e.scaleSymbolsProportionally,respectFrame:e.respectFrame,clippingPath:e.clippingPath}}(e,r),S=["Rotation","OffsetX","OffsetY"];p=n.filter((function(t){return t.primitiveName!==e.primitiveName||-1===S.indexOf(t.propertyName)}));var N,b="",k=(0,a.Z)(n);try{for(k.s();!(N=k.n()).done;){var C=N.value;void 0!==C.value&&(b+="-".concat(C.primitiveName,"-").concat(C.propertyName,"-").concat(JSON.stringify(C.value)))}}catch(J){k.e(J)}finally{k.f()}var O=v.B$.getTextureAnchor(g,c),P=(0,o.Z)(O,3),x=P[0],M=P[1],I=P[2],w=e.primitiveName,L=(0,d.NA)(e.rotation),A=(0,d.NA)(e.offsetX),Z=(0,d.NA)(e.offsetY),X=(0,h.hP)(JSON.stringify(g)+b).toString(),z={type:"marker",templateHash:X,materialHash:0===p.length?X:U(X,i,p,l),cim:g,materialOverrides:p,colorLocked:e.colorLocked,effects:t,scaleSymbolsProportionally:e.scaleSymbolsProportionally,alignment:s,anchorPoint:{x:x,y:M},isAbsoluteAnchorPoint:!1,size:e.size,rotation:G(w,i,"Rotation",l,L),offsetX:G(w,i,"OffsetX",l,A),offsetY:G(w,i,"OffsetY",l,Z),color:{r:255,g:255,b:255,a:1},outlineColor:{r:0,g:0,b:0,a:0},outlineWidth:0,scaleX:1,frameHeight:y,rotateClockwise:e.rotateClockwise,referenceSize:m,sizeRatio:I/(0,u.F2)(e.size),markerPlacement:e.markerPlacement};f.push(z)}function $(e){if(e&&0===e.indexOf("Level_")){var t=parseInt(e.substr(6),10);if(NaN!==t)return t}return 0}function T(e){if(!e||0===e.length)return null;var t=new c.Z(e).toRgba();return{r:t[0],g:t[1],b:t[2],a:t[3]}}function G(e,t,r,i,a,o,n){var l=t[e];if(l){var f=l[r];if("string"==typeof f||"number"==typeof f||f instanceof Array)return o?o.call(null,f,n):f;if(null!=f&&f instanceof y.mz)return function(e,t,r){var l=(0,S.Z)(f,e,{$view:r},i.geometryType,t);return null!==l&&o&&(l=o.call(null,l,n)),null!==l?l:a}}return a}function U(e,t,r,i){var o,n=(0,a.Z)(r);try{for(n.s();!(o=n.n()).done;){var l=o.value;l.valueExpressionInfo&&function(){var e=t[l.primitiveName]&&t[l.primitiveName][l.propertyName];e instanceof y.mz&&(l.fn=function(t,r,a){return(0,S.Z)(e,t,{$view:a},i.geometryType,r)})}()}}catch(f){n.e(f)}finally{n.f()}return function(t,i,o){var n,l=(0,a.Z)(r);try{for(l.s();!(n=l.n()).done;){var c=n.value;c.fn&&(c.value=c.fn(t,i,o))}}catch(f){l.e(f)}finally{l.f()}return(0,h.hP)(e+v.E0.buildOverrideKey(r)).toString()}}function j(e,t){if(!t||0===t.length)return e;var r=JSON.parse(JSON.stringify(e));return v.E0.applyOverrides(r,t),r}function D(e,t){var r,i=!1,o="",n=(0,a.Z)(e);try{for(n.s();!(r=n.n()).done;){var l=r.value;l.primitiveName===t&&(void 0!==l.value?o+="-".concat(l.primitiveName,"-").concat(l.propertyName,"-").concat(JSON.stringify(l.value)):l.valueExpressionInfo&&(i=!0))}}catch(f){n.e(f)}finally{n.f()}return[i,o]}function V(e,t,r){if(e&&t)switch(e.type){case"CIMPointSymbol":case"CIMLineSymbol":case"CIMPolygonSymbol":var i=e.symbolLayers;if(!i)return;var o,n=(0,a.Z)(i);try{for(n.s();!(o=n.n()).done;){var l=o.value;switch(l.type){case"CIMPictureFill":case"CIMHatchFill":case"CIMGradientFill":case"CIMPictureStroke":case"CIMGradientStroke":case"CIMCharacterMarker":case"CIMPictureMarker":"url"in l&&l.url&&r.push(t.fetchResource(l.url,null));break;case"CIMVectorMarker":var f=l.markerGraphics;if(!f)continue;var c,s=(0,a.Z)(f);try{for(s.s();!(c=s.n()).done;){var m=c.value;if(m){var u=m.symbol;u&&V(u,t,r)}}}catch(h){s.e(h)}finally{s.f()}}}}catch(h){n.e(h)}finally{n.f()}}}var q=function(e){return e&&2===e.length&&e[0].enable&&e[1].enable&&"CIMSolidStroke"===e[0].type&&"CIMSolidFill"===e[1].type&&!e[0].effects&&!e[1].effects}},95954:function(e,t,r){r.d(t,{j:function(){return m}});var i=r(93433),a=r(37762),o=r(15671),n=r(43144),l=r(77981),f=r(25290),c=r(35747),s=r(84307),m=function(){function e(){(0,o.Z)(this,e)}return(0,n.Z)(e,null,[{key:"executeEffects",value:function(e,t){var r,i=(0,f.GP)(t),o=new c.M(i),n=(0,a.Z)(e);try{for(n.s();!(r=n.n()).done;){var l=r.value,m=(0,s.h)(l);m&&(o=m.execute(o,l,1.3333333333333333,!0))}}catch(u){n.e(u)}finally{n.f()}return o}},{key:"next",value:function(e){var t=e.next();return(0,f.wp)(t),t}},{key:"applyEffects",value:function(e,t){if(!e)return t;var r,o=new c.M(t),n=(0,a.Z)(e);try{for(n.s();!(r=n.n()).done;){var f=r.value,m=(0,s.h)(f);m&&(o=m.execute(o,f,1,!1))}}catch(p){n.e(p)}finally{n.f()}for(var u,h=null;u=o.next();){var y,v;h?(0,l.l9)(h)?(0,l.l9)(u)&&(y=h.paths).push.apply(y,(0,i.Z)(u.paths)):(0,l.oU)(h)&&(0,l.oU)(u)&&(v=h.rings).push.apply(v,(0,i.Z)(u.rings)):h=u}return h}}]),e}()}}]);
//# sourceMappingURL=9815.e62daaae.chunk.js.map