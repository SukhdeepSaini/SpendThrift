spendThriftApp.controller('CarouselCtrl', function ($scope) {
    $scope.myInterval = 5000;
    var imagesArray = ['https://cdn.bigcommerce.com/www/cdn/farfuture/ulM0hngoflleSU40aEc8nlQq_zvrQudQrAe7B36raPY/mtime:1427730626/sites/all/themes/bc_theme/img/highlights/hero.jpg'
                      ,'http://www.techebizz.com/wp-content/uploads/2014/09/ecommerce-websites.jpg'
                      ,'http://www.webseoanalytics.com/blog/wp-content/uploads/2011/10/seo-tips-ecommerce-site.jpg'
                      ,'http://www.shopify.com/assets2/online/products@tablet-91924c9d1fee50665956dc8689387685.jpg'
                      ,'http://cccproduction.com/wp-content/uploads/2014/07/ecommerce-web-design-singapore.png'];
    $scope.slides = [];

    for(var i = 0 ; i < imagesArray.length ; i++)
    {
        $scope.slides.push({ image: imagesArray[i] });
    }
});