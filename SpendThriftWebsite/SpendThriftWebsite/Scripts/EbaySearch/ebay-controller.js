
$(function () {
    $('[data-toggle="popover"]').popover()
});

spendThriftApp.controller("EbaySearchCtrl", function ($scope, $http, $q,$window) {

    var paPromise = $q.defer()
    var items;
    
   

    $scope.searchebay = function (searchItem) {

        var searchCriteria = searchItem.name;
        var numberOfResult = searchItem.number;

        var url = 'http://svcs.ebay.com/services/search/FindingService/v1?SECURITY-APPNAME=Northeas-90d2-42ad-893a-492db0c44a13&OPERATION-NAME=findItemsByKeywords&SERVICE-VERSION=1.0.0&RESPONSE-DATA-FORMAT=JSON&callback=angular.callbacks._0&REST-PAYLOAD&keywords=' + searchCriteria + '&paginationInput.entriesPerPage=' + numberOfResult;

        $http({
            method: 'JSONP',
            url: url
        }).success(function (data) {

            items = data.findItemsByKeywordsResponse[0].searchResult[0].item || [];
            var myData = [];
            for (var i = 0; i < items.length; i++) {
                //console.log(items[i]);
                var imgUrl = items[i].galleryURL[0];
                //console.log(imgUrl);
                var title = items[i].title[0];
                //console.log(title);
                var itemUrl = items[i].viewItemURL[0];
                var ebayItem = { imageUrl: imgUrl, itemTitle: title, itemURL: itemUrl };
                myData.push(ebayItem);
                //console.log(myData.length);
            }
            $scope.ebayData = myData;
            myData = [];
            paPromise.resolve();
        });

    };

});



function ProjectDescriptionDisplay(ID)
{
    var $btn2 = $(ID);
    $btn2.data('state', 'hover');

    var enterShow = function () {
        if ($btn2.data('state') === 'hover') {
            $btn2.popover('show');
        }
    };
    var exitHide = function () {
        if ($btn2.data('state') === 'hover') {
            $btn2.popover('hide');
        }
    };

    var clickToggle = function () {
        if ($btn2.data('state') === 'hover') {
            $btn2.data('state', 'pinned');
        } else {
            $btn2.data('state', 'hover')
            $btn.popover('hover');
        }
    };

    $btn2.popover({ trigger: 'manual' })
        .on('mouseenter', enterShow)
        .on('mouseleave', exitHide)
        .on('click', clickToggle);

}

