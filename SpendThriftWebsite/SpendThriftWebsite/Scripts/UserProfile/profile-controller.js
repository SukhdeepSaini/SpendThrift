spendThriftApp.controller("ProfileCtrl", function ($scope,profileRepository, $http, $location) {

    $http.get('/Profile/Index').success(function (data) { $scope.customer = data; console.log(data); });

    $scope.updateprofile = function (customer) {
        $scope.error = false;
        // console.log('In account controller' + customer.username + customer.email);
        profileRepository.update(customer).then(function () { alert('account Updated successfully'); $location.url('/Home'); },
            function () { $scope.error = true });
    };
});