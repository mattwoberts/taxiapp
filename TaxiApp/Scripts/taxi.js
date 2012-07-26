// Map init here please
$(function () {

    var map = new OpenLayers.Map("map");
    var mapnik = new OpenLayers.Layer.OSM();
    var fromProjection = new OpenLayers.Projection("EPSG:4326");   // Transform from WGS 1984
    var toProjection = new OpenLayers.Projection("EPSG:900913"); // to Spherical Mercator Projection
    var position = new OpenLayers.LonLat(-2.800784, 54.048354).transform(fromProjection, toProjection);
    var zoom = 15;

    map.addLayer(mapnik);
    map.setCenter(position, zoom);

});