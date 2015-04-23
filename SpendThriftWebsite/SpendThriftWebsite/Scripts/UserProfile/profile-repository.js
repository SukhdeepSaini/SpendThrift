spendThriftApp.factory('profileRepository', function ($http, $q) {

    return {
        update: function (customer) {
            var deffered = $q.defer();
            console.log('In profile repository' + customer.username + customer.email);
            $http.post('/Profile/Update', customer).success(function () { deffered.resolve(); })
            .error(function () { deffered.reject(); });
            return deffered.promise;
        }
    }

});