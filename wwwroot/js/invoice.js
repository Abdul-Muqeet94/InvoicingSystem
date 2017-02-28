(function() {
    var app = angular.module("invoiceModule", ['ngRoute']);



    app.controller('billerController', function($scope, getBillerService) {

        $scope.IsNewRecord = 1; //The flag for the new record

        loadRecords();
        loadCustomer();
        //Function to load all Employee records
        function loadRecords() {
            var biller = "biller";
            var promiseGet = getBillerService.getBiller(biller); //The MEthod Call from service

            promiseGet.then(function(pl) { $scope.billers = pl.data },
                function(errorPl) {
                    $log.error('failure loading Employee', errorPl);
                });
        }

        function loadCustomer() {
            var promiseGet = getBillerService.getBiller("customer"); //The MEthod Call from service

            promiseGet.then(function(pl) { $scope.customers = pl.data },
                function(errorPl) {
                    $log.error('failure loading Employee', errorPl);
                });
        }


    });

    app.controller("addInvoice", function($scope, $http) {

        $scope.addInvoice = function() {

            var invoice = {
                id: '0',
                deliveryDate: $scope.deliveryDate,
                createdDate: $scope.createdDate,
                dueDate: $scope.dueDate,
                amount: $scope.amount,
                quantity: $scope.quantity,
                customerId: $scope.customerId,
                billerId: $scope.billerId,
                productId: $scope.productId,
                product: [{
                    id: '0',
                    name: $scope.product.name,
                    color: $scope.product.color,
                    note: $scope.product.note,
                    description: $scope.product.description,
                    price: $scope.product.price,
                    customField: [],
                    design: [{
                        name: $scope.product.design,
                        id: '0',
                        fabric: $scope.product.fabric,
                        cut: $scope.product.cut,
                        color: $scope.product.color,
                        note: $scope.product.note
                    }]
                }]
            }


            $scope.message = $http.post('http://localhost:5000/api/invoice/createInvoice', customer).
            then(function(response) {
                console.log(response.data);
                $scope.message = response.data;
                $log.info(response);
            });

        }
    });
})
();