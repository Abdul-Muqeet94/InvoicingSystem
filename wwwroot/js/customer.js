(function () {
    var app = angular.module("customerModule", ['ngRoute', 'customservice']);
    app.controller('crudController', function ($scope, $log, $rootScope, $location, $http) {

        $scope.message = $http.post('http://danishtest.ml/api/customer/getCustomers', $rootScope.customerId).
            then(function (response) {

                $scope.Customerss = response.data;
                //Pagination 
                 $scope.totalItems = $scope.Customerss.length;
                $scope.currentPage = 1;
                $scope.itemsPerPage = 15;

                $scope.$watch("currentPage", function () {
                    setPagingData($scope.currentPage);
                });

                function setPagingData(page) {
                    var pagedData = $scope.Customerss.slice(
                        (page - 1) * $scope.itemsPerPage,
                        page * $scope.itemsPerPage
                    );
                    $scope.Customers = pagedData;
                }
                //End here 
                console.log(response.data);
            });

        $scope.setRoot = function (x) {
            $rootScope.customerId = x;
            console.log($rootScope.customerId);
        };
        ///////
        $scope.deleteCustomer = function (x) {
            $scope.message = $http.post('http://danishtest.ml/api/customer/delete', x).
                then(function (response) {
                    $scope.response = response.data;
                    console.log(response.data);
                    //  route to customer.html
                    $location.path("/customer");
                });
        };
    });

    app.controller('editCController', function ($scope, $location, $rootScope, $http) {

        $scope.message = $http.post('http://danishtest.ml/api/customer/getCustomers', $rootScope.customerId).
            then(function (response) {

                $scope.Customers = response.data[0];
                console.log(response.data[0]);
                $rootScope.customerId = 0;
            });
        $scope.getImage = function (data) {
            return 'data:image/jpeg;base64,' + data;

        }
        $scope.edit = function () {
            var file = document.getElementById('myfile').files[0];
            if (file) {
                var reader = new FileReader();
                reader.readAsBinaryString(file);
                reader.onload = function (e) {
                    $scope.Customers.imagepath = btoa(reader.result);
                    console.log($scope.Customers);
                    $scope.message = $http.post('http://danishtest.ml/api/customer/edit', $scope.Customers).
                        then(function (response) {
                            console.log(response.data);
                        });
                }
            }




        }

    });
    app.controller("addCustomer", function ($scope, $http, customfields,$location) {
        $scope.customFields = [];
        var getResult = customfields.get('"Customer"');
        getResult.then(function (pl) {
            $scope.customFields = pl.data
        },
            function (errorPl) {
                $log.error('failure loading customeFields', errorPl);
            });
        console.log($scope.customFields);


        $scope.addCustomer = function () {
            //
            var file = document.getElementById('myfile').files[0];
            if (file != null) {
            var reader = new FileReader();
            
                reader.readAsBinaryString(file);
            

            reader.onload = function (e) {
                
                    $scope.customer.imagepath = btoa(reader.result);
                
                $scope.customer.id = '0';
                $scope.customer.customFields = $scope.customFields;
                console.log($scope.customer);
                $scope.message = $http.post('http://danishtest.ml/api/customer/create', $scope.customer).
                    then(function (response) {
                        console.log(response.data);
                        swal({
                            title: 'Saved',
                            text: 'Customer added Successfully',
                            timer: 2000
                        }).then(
                            function () { },
                            // handling the promise rejection
                            function (dismiss) {
                                if (dismiss === 'timer') {
                                    console.log('.............')
                                }
                            }
                            )
                        $location.path('customer');
                    });
            };
        }
        else
        {
               $scope.customer.imagepath ="";
                
                $scope.customer.id = '0';
                $scope.customer.customFields = $scope.customFields;
                console.log($scope.customer);
                $scope.message = $http.post('http://danishtest.ml/api/customer/create', $scope.customer).
                    then(function (response) {
                        console.log(response.data);
                        swal({
                            title: 'Saved',
                            text: 'Customer added Successfully',
                            timer: 2000
                        }).then(
                            function () { },
                            // handling the promise rejection
                            function (dismiss) {
                                if (dismiss === 'timer') {
                                    console.log('.............')
                                }
                            }
                            )
                        $location.path('customer');
                    });
        }

            //


        }
    });
}
)
    ();
