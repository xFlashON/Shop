var cartController = function ($scope, $http) {
    $scope.models = {
        mode: 'cart',
        orderRows: undefined,
        total: 0
    };

    $http.get("GetOrder").then(function(response) {

        if (response.data !== undefined) {
            $scope.models.orderRows = response.data.orderRows;
            $scope.models.total = response.data.total;
        }

    });

    $scope.gotoPaymentCmd = function () {
        $scope.models.mode = 'order';

    }

}

cartController.$inject = ['$scope', '$http'];
