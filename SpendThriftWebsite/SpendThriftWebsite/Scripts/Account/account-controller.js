spendThriftApp.controller("AccountCtrl", function ($scope, accountRepository, $location) {

    $('.datepicker').datepicker({
            format: "yyyy/mm/dd",
            startDate: "1950-01-01",
            endDate: "2016-01-01",
            todayBtn: "linked",
            autoclose: true,
            todayHighlight: true
        }
    );

    $scope.save = function (newcustomer) {
        $scope.error = false;
       // console.log('In account controller' + customer.username + customer.email);
        accountRepository.save(newcustomer).then(function () { alert('account created successfully'); $location.url('/Home'); },
            function () { $scope.error = true });
    };
});