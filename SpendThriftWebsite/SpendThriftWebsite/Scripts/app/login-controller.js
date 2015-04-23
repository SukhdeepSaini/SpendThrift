spendThriftApp.controller('loginCtrl', function ($scope, loginRepository, $location) {

    $scope.login = function (customer) {

        $scope.error = false;
        loginRepository.loginCustomer(customer).then(function () { $('#loginModal').modal('hide'); $location.url('/Home'); },
            function () { $scope.error = true });
    };
});