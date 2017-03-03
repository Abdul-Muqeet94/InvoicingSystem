(function() {
    var app = angular.module("invoiceModule", ['ngRoute']);



    app.controller('createInvoiceController', function($scope, createInvoice, getProductId) {
        //$scope.invoices = [];
        $scope.ledgers = { id: "0", products: [] };
        $scope.invoices = [id = "0"];
        $scope.$on('someEvent', function(event, args) {
            // loadscope(args);'
            var fillScope = createInvoice.fillscope(args);
            fillScope.then(function(pl) {
                    $scope.invoices[0].products.push(pl.data)
                },
                function(errorpl) {
                    $log.error('fail to load data' + errorpl);
                });
        });


        $scope.addDesigns = function(idx) {
            //  var productIndex = $scope.invoices.length - 1;
            alert(idx);
            $scope.invoices[idx].designs.push({ 'id': 0 });
        }
        $scope.removeDesign = function(idx) {
            alert(idx);
            var lastItem = $scope.invoices[0].designs.length - 1;
            $scope.invoices[idx].designs.splice(lastItem);
        }

        $scope.createnewInvoice = function(idx) {
            alert(idx);
            //var newinvoiceNo = $scope.invoices.length - 1;
            $scope.invoices.push({ 'id': 0, designs: [{ id: "0" }] });



            /*
                        
                            */
        }

        $scope.addLedger = function() {
            $scope.ledgers.products = $scope.invoices;
            var getResponse = createInvoice.addInvoices($scope.invoice);
            getResponse.then(function(pl) { $scope.response = pl.data },
                function(errorpl) {
                    $log.error('failure adding invoices', errorpl);
                });
        };
        $scope.removeinvoice = function(idx) {
            alert(idx);
            var lastItem = $scope.invoices.length - 1;
            $scope.invoices.splice(lastItem);
        };
    });



    app.controller('billerController', function($scope, getBillerService, getTaxService, $rootScope) {

        $scope.model = { id: "0", product: [{}] };
        $scope.IsNewRecord = 1; //The flag for the new record

        loadRecords();
        loadCustomer();
        loadProduct();
        loadTax();
        $scope.update = function update() {
            alert("update");
            $rootScope.$broadcast('someEvent', $scope.value);
        }

        function loadTax() {
            var promiseGet = getTaxService.getTaxes();
            promiseGet.then(function(pl) { $scope.taxes = pl.data },
                function(errorpl) {
                    $log.error('Failure loading Tax', errorpl);
                });
        }
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

        function loadProduct() {
            var promiseGet = getBillerService.getBiller("product"); //The MEthod Call from service

            promiseGet.then(function(pl) { $scope.products = pl.data },
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