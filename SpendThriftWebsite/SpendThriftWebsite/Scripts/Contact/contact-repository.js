spendThriftApp.factory('contactRepository', function ($http, $q) {

    return {
        savefeedback: function (feedback) {
            var deffered = $q.defer();
            $http.post('/Feedback/Save', feedback).success(function () { deffered.resolve(); })
            .error(function () { deffered.reject(); });
            return deffered.promise;
        }
    }

});