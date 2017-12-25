var cartController = function ($scope) {
    $scope.models = {
        mode: 'cart',
        orderRows:[]

};

    $scope.gotoPaymentCmd = function() {
        $scope.models.mode = 'order';

    }
}

cartController.$inject = ['$scope'];