// Setup a closure around the methods used
var taxi = function () {

    // Private stuff here
    var hub = null;
    var map = new OpenLayers.Map("map");
    var mapnik = new OpenLayers.Layer.OSM();
    var fromProjection = new OpenLayers.Projection("EPSG:4326");   // Transform from WGS 1984
    var toProjection = new OpenLayers.Projection("EPSG:900913"); // to Spherical Mercator Projection
    var position = new OpenLayers.LonLat(-2.800784, 54.048354).transform(fromProjection, toProjection);
    var zoom = 15;
    var _this = this;

    var setupOpenLayers = function () {
        map.addLayer(mapnik);
        map.setCenter(position, zoom);

        // Create a vector layer, so we can add features?
        _this.vector = new OpenLayers.Layer.Vector("Points", {

            //strategies: [this.strategy],
            /*tyleMap: new OpenLayers.StyleMap({
            "default": this.getDefaultStyle(),
            "select": this.getSelectedStyle()
            })*/
        });
        map.addLayer(vector);
    };

    var setupSignalR = function () {

        hub = $.connection.taxiHub;

        hub.requestTaxi = function (response) {
            // A taxi request has come in, so display this in some meaningful way (popup for now)
            console.log("taxiRequest",response);
            var latLon = new OpenLayers.LonLat(response.lon, response.lat);
            var pos = latLon.transform(fromProjection, toProjection);
            var popup = new OpenLayers.Popup.FramedCloud("chicken",
              pos,
              null,
              "<p><h2>Taxi Request!</h2><br>From " + response.name + ", " + response.mobileNumber + "</p>",
              null, true, null);
            map.addPopup(popup);
        };

        hub.sayHello = function() {
            console.log("helllooo");
        };

        $.connection.hub.start();

        window.setTimeout(function () {
            hub.ping().done(function (response) {
                console.log("done" + response);
            });
        }, 2000);

    };

    return {
        hub : hub,
        map: map,
        init: function () {
            setupOpenLayers();
            setupSignalR();
        }
    };
} ();


$(function () {
    taxi.init();
});