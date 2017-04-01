(function () {
    var app = angular.module("ReportModule", ['ngRoute']);
    app.controller('totalSalesController', function ($scope, $http) {

        $scope.message = $http.post('http://localhost:5000/api/reports/totalsales').
            then(function (response) {
                $scope.sales = response.data;
                console.log($scope.sales);
            });

    });

    app.controller("totalSalesCustomers", function ($scope, $http, $rootScope, $location) {

        $scope.message = $http.post('http://localhost:5000/api/reports/totalsalescustomerwise').
            then(function (response) {
                $scope.sales = response.data;
                console.log($scope.sales);
            });
    });
    app.controller("totalSalesBiller", function ($scope, $http, $rootScope, $location) {

        $scope.message = $http.post('http://localhost:5000/api/reports/totalsalesbiller').
            then(function (response) {
                $scope.sales = response.data;
                console.log($scope.sales);
            });
    });
    app.controller("totalTaxes", function ($scope, $http, $rootScope, $location) {

        $scope.message = $http.post('http://localhost:5000/api/reports/totaltaxes').
            then(function (response) {
                $scope.sales = response.data;
                console.log(response.data);
            });
    });
    app.controller("customerAndProduct", function ($scope, $http, $rootScope, $location) {

        $scope.message = $http.post('http://localhost:5000/api/reports/customerproduct').
            then(function (response) {
                $scope.sales = response.data;
                console.log(response.data);
            });
    });

    app.controller("totalProduct", function ($scope, $http, $rootScope, $location) {

        $scope.message = $http.post('http://localhost:5000/api/reports/totalproduct').
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

        $scope.message = $http.post('http://localhost:5000/api/reports/totalsalesbillercustomer').
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

        $scope.message = $http.post('http://localhost:5000/api/reports/debatorbyowned').
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

        $scope.message = $http.post('http://localhost:5000/api/reports/debatorbyownedcustomer').
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
            $scope.message = $http.post('http://localhost:5000/api/reports/invoicebyfilter',$scope.invoice).
            then(function (response) {
                $scope.sales = response.data;
                console.log($scope.sales.length);
                if($scope.sales.length>0){
                    $rootScope.check=true;
                    console.log($rootScope.check);
                }
               // console.log($scope.sales);
            });

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