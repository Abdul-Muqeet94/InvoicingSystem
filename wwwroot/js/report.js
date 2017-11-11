(function () {
    var app = angular.module("ReportModule", ['ngRoute']);
    app.controller('totalSalesController', function ($scope, $http) {

        $scope.message = $http.post('http://danishtest.ml/api/reports/totalsales').
            then(function (response) {
                $scope.sales = response.data;
                console.log($scope.sales);
            });

    });

    app.controller("totalSalesCustomers", function ($scope, $http, $rootScope, $location) {

        $scope.message = $http.post('http://danishtest.ml/api/reports/totalsalescustomerwise').
            then(function (response) {
                $scope.sales = response.data;
                console.log($scope.sales);
            });
    });
    app.controller("totalSalesBiller", function ($scope, $http, $rootScope, $location) {

        $scope.message = $http.post('http://danishtest.ml/api/reports/totalsalesbiller').
            then(function (response) {
                $scope.sales = response.data;
                console.log($scope.sales);
            });
    });
    app.controller("totalTaxes", function ($scope, $http, $rootScope, $location) {

        $scope.message = $http.post('http://danishtest.ml/api/reports/totaltaxes').
            then(function (response) {
                $scope.sales = response.data;
                console.log(response.data);
            });
    });
    app.controller("customerAndProduct", function ($scope, $http, $rootScope, $location) {

        $scope.message = $http.post('http://danishtest.ml/api/reports/customerproduct').
            then(function (response) {
                $scope.sales = response.data;
                console.log(response.data);
            });
    });

    app.controller("totalProduct", function ($scope, $http, $rootScope, $location) {

        $scope.message = $http.post('http://danishtest.ml/api/reports/totalproduct').
            then(function (response) {
                $scope.sales = response.data;
                console.log($scope.sales);
            });

        $scope.getTotal = function () {
            var total = 0;
            for (var i = 0; i < $scope.sales.length; i++) {
                var product = $scope.sales[i].quantity;
                total += product;
            }
            return total;
        };
    });

    app.controller("totalsalesbillercustomer", function ($scope, $http, $rootScope, $location) {

        $scope.message = $http.post('http://danishtest.ml/api/reports/totalsalesbillercustomer').
            then(function (response) {
                $scope.sales = response.data;
                console.log($scope.sales);
            });

        $scope.getTotal = function (val) {
            var total = 0;
            for (var i = 0; i < $scope.sales[val].customer.length; i++) {
                var product = $scope.sales[val].customer[i].sales;
                total += product;
            }
            return total;
        };
    });
    app.controller("debatorByOwned", function ($scope, $http, $rootScope, $location) {

        $scope.message = $http.post('http://danishtest.ml/api/reports/debatorbyowned').
            then(function (response) {
                $scope.sales = response.data;
                console.log(response.data);
            });

        $scope.getTotal = function () {
            var total = 0;
            for (var i = 0; i < $scope.sales.length; i++) {
                var product = $scope.sales[i].balance;
                total += product;
            }
            return total;
        };
    });


    app.controller("debatorByOwnedCustomer", function ($scope, $http, $rootScope, $location) {

        $scope.message = $http.post('http://danishtest.ml/api/reports/debatorbyownedcustomer').
            then(function (response) {
                $scope.sales = response.data;
                console.log(response.data);
            });

        $scope.getTotal = function () {
            var total = 0;
            for (var i = 0; i < $scope.sales.length; i++) {
                var product = $scope.sales[i].balance;
                total += product;
            }
            return total;
        };
    });


    app.controller("invoiceByFilter", function ($scope, $http, $rootScope, $location) {
        
        $scope.invoice = { fromDate: "", toDate: "" };
       $scope.sales=[];
        $scope.save = function () {
            console.log($scope.invoice);
            var filter_model = { id: $scope.invoice, type: "null" };
            $scope.message = $http.post('http://danishtest.ml/api/reports/invoicebyfilter',filter_model).
            then(function (response) {
                $scope.saless = response.data;
                console.log($scope.saless.length);
                if($scope.saless.length>0){
                    $rootScope.check=true;
                    //Pagination
                      $scope.totalItems = $scope.saless.length;
                $scope.currentPage = 1;
                $scope.itemsPerPage = 15;

                $scope.$watch("currentPage", function () {
                    setPagingData($scope.currentPage);
                });

                function setPagingData(page) {
                    var pagedData = $scope.saless.slice(
                        (page - 1) * $scope.itemsPerPage,
                        page * $scope.itemsPerPage
                    );
                    $scope.sales = pagedData;
                }
                    //Pagination End here
                    console.log($rootScope.check);
                }
               // console.log($scope.sales);
            });
             $scope.setRoot = function (x) {
            $rootScope.pdfcheck=true;
            $rootScope.invoiceId = x;
            console.log($rootScope.invoiceId);
        };
      /*  $scope.setPdfRoot = function (x) {
            $rootScope.pdfcheck
            $rootScope.invoiceId = x;
            console.log($rootScope.invoiceId);
        };
        */
        $scope.sendEmail = function (x) {
            
            $rootScope.invoiceId = x;
            console.log("sending Email");
            $scope.message = $http.post('http://danishtest.ml/api/invoice/sendemail', $rootScope.invoiceId).
                then(function (response) {
                    $scope.res = response.data;
                    //$scope.customs = $scope.Customers[0].customfields;
                    console.log(response.res);
                    if (response.res.status > 0) {
                        $rootScope.check = true;
                    }
                    else {
                        $rootScope.check = false;
                    }
                    $rootScope.invoiceId = 0;
                });

        };


        $scope.checkedit = function (x) {
            filter_model = { id: x, type: "null" };
            console.log(filter_model);
            $scope.message = $http.post('http://danishtest.ml/api/invoice/getinvoice',filter_model).
                then(function (response) {

                    $scope.customers = response.data[0];
                    console.log(response.data[0]);

                    if ($scope.customers.balance <= 0) {
                        $location.path("/invoices");
                    }
                    else {
                        $rootScope.invoiceId = x;
                        $location.path("/editinvoices");
                    }
                });

        }
        $scope.deleteInvoice = function (x) {
            $scope.message = $http.post('http://danishtest.ml/api/invoice/deleteinvoice', x).
                then(function (response) {
                    $scope.response = response.data;
                    console.log(response.data);
                    $location.path("/invoices");
                });
        };


        console.log("SAles");
        console.log($scope.sales);
        };
        $scope.status=function(){
            
            if($rootScope.check)
            return true;
            else
            return false;
        };

    });









})();