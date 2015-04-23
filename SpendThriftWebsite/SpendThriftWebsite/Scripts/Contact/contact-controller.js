spendThriftApp.controller("FeedbackCtrl", function ($scope, contactRepository, $location) {

    $scope.submitfeedback = function (feedback) {
        $scope.error = false;
        contactRepository.savefeedback(feedback).then(function () { alert('FeedBack Submitted successfully'); $location.url('/Home'); },
            function () { $scope.error = true });
    };
});