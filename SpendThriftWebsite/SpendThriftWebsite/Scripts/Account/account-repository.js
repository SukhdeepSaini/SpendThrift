spendThriftApp.factory('accountRepository', function ($http, $q) {

    return {
        save: function (newcustomer) {
            var deffered = $q.defer();
            console.log('In account repository' + newcustomer.username + newcustomer.email);
            $http.post('/Account/Save', newcustomer).success(function () { deffered.resolve(); })
            .error(function () { deffered.reject(); });
            return deffered.promise;
        }
    }

});