(function () {
    var app = angular.module("invoiceModule", ['ngRoute']);
    app.controller('createInvoiceController', function ($scope, getBillerService, getTaxService, $rootScope, $log, createInvoice, getProductId) {
        $scope.invoices = [];
        $scope.invoice = [];

        var d1 = {
            color: '',
            cut: '',
            fabric: '',
            note: '',
            name: 'dupatta'
        };
        var d2 = {
            color: '',
            cut: '',
            fabric: '',
            note: '',
            name: 'pant'
        };
        var d3 = {
            color: '',
            cut: '',
            fabric: '',
            note: '',
            name: 'kurta'
        };
        var product = {
            id: 0,
            name: '',
            price: '',
            quantity: '',
            taxId: '',
            designs: [],
            color: '',
            note: '',
            description: ''
        };
        product.designs.push(d1);
        product.designs.push(d2);
        product.designs.push(d3);
        $scope.invoices.push(product);
        $scope.addProduct = function () {
            var d1 = {
                color: '',
                cut: '',
                fabric: '',
                note: '',
                name: 'dupatta'
            };
            var d2 = {
                color: '',
                cut: '',
                fabric: '',
                note: '',
                name: 'pant'
            };
            var d3 = {
                color: '',
                cut: '',
                fabric: '',
                note: '',
                name: 'kurta'
            };
            var product = {
                id: 0,
                name: '',
                price: '',
                quantity: '',
                taxId: '',
                designs: [],
                color: '',
                note: '',
                description: ''
            };
            product.designs.push(d1);
            product.designs.push(d2);
            product.designs.push(d3);
            $scope.invoices.push(product);
            console.log($scope.invoices);
        };

        $scope.removeProduct = function () {
            $scope.invoices.splice(-1, 1);
            console.log($scope.invoices);
        };

        $scope.updateProduct = function (index) {
            for (var i = 0; i < $scope.products.length; i++) {
                if ($scope.products[i].name == $scope.invoices[index].name) {
                    $scope.invoices[index].price = $scope.products[i].price;
                    $scope.invoices[index].id = $scope.products[i].id;
                    return;
                }
            }
        }
        $scope.updateTax = function (id, index) {
            $scope.invoices[index].taxId = id;
        };
        $scope.save = function () {

            var addInvoice = { products: $scope.invoices, note: $scope.note, date: $scope.date, biller: $scope.biller, customer: $scope.customer }
     var promiseGet = createInvoice.addInvoices(addInvoice);
        promiseGet.then(function (pl) {
            $scope.result = pl.data
        },
            function (errorpl) {
                $log.error('Failure loading Tax', errorpl);
                console.log($scope.result);
            });  
      };
       



        $scope.cancel = function () {
            $scope.invoices = [];
        };
        var product = "Product";
        var promiseGet = createInvoice.fillscope(0); //The MEthod Call from service

        promiseGet.then(function (pl) {
            $scope.products = pl.data
        },
            function (errorPl) {
                $log.error('failure loading products', errorPl);
            });

        var promiseGet = getTaxService.getTaxes();
        promiseGet.then(function (pl) {
            $scope.taxes = pl.data
        },
            function (errorpl) {
                $log.error('Failure loading Tax', errorpl);
            });

        var biller = "biller";
        var promiseGet = getBillerService.getBiller(biller); //The MEthod Call from service
        promiseGet.then(function (pl) {
            $scope.billers = pl.data
        },
            function (errorPl) {
                $log.error('failure loading Biller', errorPl);
            });
        var customer = "Customer";
        var promiseGet = getBillerService.getBiller(customer); //The MEthod Call from service

        promiseGet.then(function (pl) {
            $scope.customers = pl.data
        },
            function (errorPl) {
                $log.error('failure loading Customers', errorPl);
            });
    });


    app.controller('viewinvoices', function ($scope, $rootScope, $http,  $log,$location) {
$scope.invoices=[];
        $scope.message = $http.post('http://localhost:5000/api/invoice/getinvoice', $rootScope.invoiceId).
            then(function (response) {
                $scope.invoices = response.data[0];
                //$scope.customs = $scope.Customers[0].customfields;
                console.log(response.data[0]);
                $rootScope.invoiceId = 0;
            });

        $scope.setRoot = function (x) {
            $rootScope.invoiceId = x;
            console.log($rootScope.invoiceId);
        };


        $scope.deleteInvoice = function (x) {
            $scope.message = $http.post('http://localhost:5000/api/customer/delete', x).
                then(function (response) {
                    $scope.response = response.data;
                    console.log(response.data);
                    alert($scope.response.developerMessage);
                    //  route to customer.html
                    $location.path("/invoices");
                });
        };



    });
    //controller ends here



})
    ();