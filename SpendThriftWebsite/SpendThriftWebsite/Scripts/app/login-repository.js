spendThriftApp.factory('loginRepository', function ($http, $q) {

    return {
        loginCustomer : function (customer) {
            var deffered = $q.defer();
            $http.post('/Home/Login', customer).success(function () { deffered.resolve(); })
            .error(function () { deffered.reject(); });
            return deffered.promise;
        }
    }

});