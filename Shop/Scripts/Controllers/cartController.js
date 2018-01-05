var cartController = function ($scope, $http) {
    $scope.models = {
        mode: 'cart',
        orderNumber:'',
        orderRows: undefined,
        total: 0,
        comment:''
    };

    $http.get("GetOrder").then(function(response) {

        if (response.data !== undefined) {
            $scope.models.orderRows = response.data.orderRows;
            $scope.models.total = response.data.total;
            $scope.models.orderNumber = response.data.orderId;

            if ($scope.models.orderRows.length === 0)
                $scope.models.mode = '';
        }

    });

    $scope.gotoPaymentCmd = function () {
        $scope.models.mode = 'order';

    }

    $scope.QtyChange = function (rowData) {

        rowData.sum = rowData.qty * rowData.price;

        calculateTotal();

    };

    $scope.paymentCmd = function () {
        $scope.models.mode = 'complete';
    }

    $scope.$watch('models.orderRows', calculateTotal);

    function calculateTotal () {

        var total = 0;

        if ($scope.models.orderRows !== undefined) {
            $scope.models.orderRows.forEach(function (row) { total += row.sum; })
            $scope.models.total = total;
        }

    }

}

cartController.$inject = ['$scope', '$http'];
