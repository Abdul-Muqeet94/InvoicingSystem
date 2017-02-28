(function() {
    var app = angular.module("customerModule", ['ngRoute']);



    app.controller('crudController', function($scope, getCustomerService) {

        $scope.IsNewRecord = 1; //The flag for the new record

        loadRecords();

        //Function to load all Employee records
        function loadRecords() {
            var promiseGet = getCustomerService.getEmployees(); //The MEthod Call from service

            promiseGet.then(function(pl) { $scope.Customers = pl.data },
                function(errorPl) {
                    $log.error('failure loading Employee', errorPl);
                });
        }

    });

    app.controller("addCustomer", function($scope, $http) {

        $scope.addCustomer = function() {

            var customer = {
                id: '0',
                name: $scope.name,
                address: $scope.address,
                contact: $scope.contact,
                email: $scope.email,
                city: $scope.city,
                customFields: []
            }


            $scope.message = $http.post('http://localhost:5000/api/customer/create', customer).
            then(function(response) {
                console.log(response.data);
                $scope.message = response.data;
                $log.info(response);
            });

        }
    });
})
();