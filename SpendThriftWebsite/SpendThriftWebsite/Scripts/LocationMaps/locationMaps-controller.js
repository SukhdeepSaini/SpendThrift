spendThriftApp.controller("LocationMapsCtrl", function ($scope,$location) {

  
});

google.maps.event.addDomListener(window, 'load', initialize);

var myCenter = new google.maps.LatLng(42.3583333, -71.0602778);
var position2 = new google.maps.LatLng(42.37160790103443, -71.1031723022461);
var position3 = new google.maps.LatLng(42.33228090002313, -71.07295989990234);
var position4 = new google.maps.LatLng(42.370973789813014, -71.07776641845703);

function initialize() {
    var mapProp = {
        center: myCenter,
        zoom: 13,
        mapTypeId: google.maps.MapTypeId.ROADMAP
    };

    var map = new google.maps.Map(document.getElementById("googleMap"), mapProp);

    var marker = new google.maps.Marker({
        position: myCenter,
        animation: google.maps.Animation.BOUNCE
    });

    var marker2 = new google.maps.Marker({
        position: position2,
        animation: google.maps.Animation.BOUNCE
    });

    var marker3 = new google.maps.Marker({
        position: position3,
        animation: google.maps.Animation.BOUNCE
    });

    var marker4 = new google.maps.Marker({
        position: position4,
        animation: google.maps.Animation.BOUNCE
    });

    marker.setMap(map);
    marker2.setMap(map);
    marker3.setMap(map);
    marker4.setMap(map);

    google.maps.event.addListener(marker, 'click', function () {
        map.setZoom(16);
        map.setCenter(marker.getPosition());
    });
}