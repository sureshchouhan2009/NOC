window._this_Map_Controllers = {
    ETRApp: null,
    isMapReady: false,

    afterMapRender: function (ETRApp) {
        this.ETRApp = ETRApp;
        this.isMapReady = true;
    }
}