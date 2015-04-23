var spendThriftApp = angular.module('spendThrift', ['ui.bootstrap','ngResource','ngRoute','angularCharts']);

spendThriftApp.config(['$routeProvider', '$locationProvider', function ($routeProvider, $locationProvider) {
        $routeProvider.when
        ('/Home',
        {
            templateUrl: '/Templates/Home.html',
            controller: 'CarouselCtrl'
        }),
        $routeProvider.when
        ('/Dashboard',
        {
            templateUrl: '/Templates/Dashboard.html',
            controller: 'DashboardCtrl'
        }),
        $routeProvider.when
        ('/FindUs',
        {
            templateUrl: '/Templates/LocationMap.html',
            controller: 'LocationMapsCtrl'
        }),
        $routeProvider.when
        ('/Contact',
        {
            templateUrl: '/Templates/Contact.html',
            controller: 'FeedbackCtrl'
        }),
        $routeProvider.when
        ('/EbaySearch',
        {
            templateUrl: '/Templates/EbayProducts.html',
            controller: 'EbaySearchCtrl'
        }),
        $routeProvider.when
        ('/Profile',
        {
            templateUrl: '/Templates/Profile.html',
            controller: 'ProfileCtrl'
        }),
        $routeProvider.when
        ('/Account/Create',
        {
            templateUrl: '/Templates/Account.html',
            controller: 'AccountCtrl'
        })
        .otherwise({ redirectTo: '/' });
    //    $locationProvider.html5Mode([true]);
}]);
