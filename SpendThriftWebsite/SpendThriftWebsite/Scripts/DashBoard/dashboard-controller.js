spendThriftApp.controller("DashboardCtrl", function ($scope,$http,$location) {

    $http.get('/Dashboard/Index').success(function (data) {

       // console.log(data);

        var categoriesAndCount = [];
        var seriesData = [];
        for (var i = 0; i < data.length; i++)
        {
            categoriesAndCount.push({
                x: data[i].categoryname,
                y: [data[i].productscount]
            });

            seriesData.push(data[i].categoryname);
        }

        //console.log(categoriesAndCount);

        $scope.chartconfig = {
            title: 'Products',
            tooltips: true,
            labels: false,
            mouseover: function () { },
            mouseout: function () { },
            click: function () { },
            legend: {
                display: true,
                //could be 'left, right'
                position: 'left'
            },
            innerRadius: 0, // applicable on pieCharts, can be a percentage like '50%'
            lineLegend: 'lineEnd' // can be also 'traditional'
        };

        $scope.datachart = {
            series: seriesData,
            data: categoriesAndCount
        };
    });
});