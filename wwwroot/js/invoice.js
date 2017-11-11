(function () {
    var app = angular.module("invoiceModule", ['ngRoute']);
    app.controller('createInvoiceController', function ($scope, $location, getBillerService, getTaxService, $rootScope, $log, createInvoice, getProductId) {
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
                swal({
                    title: 'Saved',
                    text: 'Invoice added Successfully',
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
                $location.path("/invoices");
            },
                function (errorpl) {
                    $log.error('Failure loading Tax', errorpl);
                    console.log($scope.result);
                });
        };




        $scope.cancel = function () {
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


    app.controller('viewinvoices', function ($scope, $rootScope, $http, $location, $timeout) {
        var filter_model = { id: 0, type: "all" };
        $scope.invoices = [];
        $scope.selecteditem = 1;
        $scope.message = $http.post('http://danishtest.ml/api/invoice/getinvoice', filter_model).
            then(function (response) {

                $scope.invoicess = response.data;

                //Pagination
                $scope.totalItems = $scope.invoicess.length;
                $scope.currentPage = 1;
                $scope.itemsPerPage = 15;

                $scope.$watch("currentPage", function () {
                    setPagingData($scope.currentPage);
                });

                function setPagingData(page) {
                    var pagedData = $scope.invoicess.slice(
                        (page - 1) * $scope.itemsPerPage,
                        page * $scope.itemsPerPage
                    );
                    $scope.invoices = pagedData;
                }
                //Invoice DropDown
                console.log($scope.invoicess);
                $scope.updateInvoice = function (index) {

                    // for (var i = 0; i < $scope.invoicess.length; i++) {
                    //     if ($scope.invoicess[i].name == $scope.invoicess[index].name) {
                    //         $scope.invoicess[index].id = $scope.invoicess[i].id;
                    //         return;
                    //     }
                    // }
                }
                $scope.nameFilter=function(){
                    var filter_model = { id: $scope.inId, type: "all" };
                    
                    $scope.message = $http.post('http://danishtest.ml/api/invoice/getinvoice', filter_model).
            then(function (response) {
                  $scope.invoices = response.data;
                  console.log("Invoice created for "+$scope.invoices);
            
            });
                };

                //end here invoice DropDown
                //Pagination
                //$scope.customs = $scope.Customers[0].customfields;
                console.log($scope.invoices);
                $rootScope.invoiceId = 0;
            });

        //pagination 

        // $scope.totalItems = $scope.invoices.length;
        // $scope.currentPage = 1;
        // $scope.numPerPage = 5;

        // $scope.paginate = function (value) {
        //     var begin, end, index;
        //     begin = ($scope.currentPage - 1) * $scope.numPerPage;
        //     end = begin + $scope.numPerPage;
        //     index = $scope.invoices.indexOf(value);
        //     return (begin <= index && index < end);
        // };
        // Pagination End Here
        //print here

        $scope.print = function () {
            $rootScope.printPdfCheck = true;
            var printContents = document.getElementById(viewInvoices).innerHTML;
            var popupWin = window.open('', '_blank', 'width=150,height=150');
            popupWin.document.open();
            popupWin.document.write('<html><head>  <link rel="stylesheet" href="css/bootstrap.min.css"><link rel="stylesheet" href="css/font-awesome/css/font-awesome.min.css"><link rel="stylesheet" href="views/css/stylesheet.css"></head><body onload="window.print()">' + printContents + '</body></html>');
            popupWin.document.close();
        };




        //end here print
        $scope.dueDate = function () {

            $scope.selecteditem = 2;
            filter_model = { id: 0, type: "due" };
            $scope.message = $http.post('http://danishtest.ml/api/invoice/getinvoice', filter_model).
                then(function (response) {
                    $scope.invoices = response.data;
                    //$scope.customs = $scope.Customers[0].customfields;
                    console.log(response.data);
                    $rootScope.invoiceId = 0;
                });
        };
        $scope.paid = function () {
            $scope.selecteditem = 3;
            filter_model = { id: 0, type: "paid" };
            $scope.message = $http.post('http://danishtest.ml/api/invoice/getinvoice', filter_model).
                then(function (response) {
                    $scope.invoices = response.data;
                    //$scope.customs = $scope.Customers[0].customfields;
                    console.log(response.data);
                    $rootScope.invoiceId = 0;
                });
        };
        $scope.delivery = function () {
            $scope.selecteditem = 4;
            filter_model = { id: 0, type: "delivery" };
            $scope.message = $http.post('http://danishtest.ml/api/invoice/getinvoice', filter_model).
                then(function (response) {
                    $scope.invoices = response.data;
                    //$scope.customs = $scope.Customers[0].customfields;
                    console.log(response.data);
                    $rootScope.invoiceId = 0;
                });
        };
        $scope.created = function () {
            $scope.selecteditem = 5;
            filter_model = { id: 0, type: "date" };
            $scope.message = $http.post('http://danishtest.ml/api/invoice/getinvoice', filter_model).
                then(function (response) {
                    $scope.invoices = response.data;
                    //$scope.customs = $scope.Customers[0].customfields;
                    console.log(response.data);
                    $rootScope.invoiceId = 0;
                });
        };
        $scope.setRoot = function (x) {
            $rootScope.invoiceId = x;
            console.log($rootScope.invoiceId);
        };


        $scope.sendEmail = function (x) {

            $rootScope.invoiceId = x;
            console.log("sending Email");
            $scope.message = $http.post('http://danishtest.ml/api/invoice/sendemail', $rootScope.invoiceId).
                then(function (response) {
                    $scope.res = response.data;
                    //$scope.customs = $scope.Customers[0].customfields;
                    console.log(response.res);
                    $timeout(function () { $rootScope.emailCheck = true; }, 1000);
                    $rootScope.emailCheck = false;

                    $rootScope.invoiceId = 0;
                });

        };


        $scope.checkedit = function (x) {
            filter_model = { id: x, type: "null" };
            console.log(filter_model);
            $scope.message = $http.post('http://danishtest.ml/api/invoice/getinvoice', filter_model).
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



    });

    //Print controller here 


    app.controller('pdfController', function ($scope, $rootScope, $http, $location, $timeout) {
        var filter_model = { id: $rootScope.invoiceId, type: "null" };
        $scope.message = $http.post('http://danishtest.ml/api/invoice/getinvoice', filter_model).
            then(function (response) {

                $scope.customers = response.data[0];
                $scope.customers.date = $scope.customers.date.substring(0, 10);
                $scope.customers.delivery = $scope.customers.delivery.substring(0, 10);
                console.log(response.data[0]);
                if (response.data.length > 0) {
                    $scope.exports();
                    if ($rootScope.pdfcheck) {
                        $timeout(function () { $location.path('/invoiceReport'); }, 500);

                    }
                    else {
                        $timeout(function () { $location.path('/invoices'); }, 500);
                    }
                }

                $rootScope.invoiceId = 0;
            });

        //print function here
        $scope.print = function () {
            var printContents = document.getElementById('exportThis').innerHTML;
            var popupWin = window.open('', '_blank', 'width=150,height=150');
            popupWin.document.open();
            popupWin.document.write('<html><head>  <link rel="stylesheet" href="css/bootstrap.min.css"><link rel="stylesheet" href="css/font-awesome/css/font-awesome.min.css"><link rel="stylesheet" href="views/css/stylesheet.css"></head><body onload="window.print()">' + printContents + '</body></html>');
            popupWin.document.close();
        };
        $scope.exports = function () {
            $rootScope.printPdfCheck = true;
            html2canvas(document.getElementById('exportThis'), {
                onrendered: function (canvas) {
                    var data = canvas.toDataURL();
                    var docDefinition = {
                        content: [{
                            image: data,
                            width: 500,
                        }]
                    };
                    pdfMake.createPdf(docDefinition).download("Invoice.pdf");
                }
            });
            $rootScope.printPdfCheck = false;
        };


    });

    // print controller end here
    app.controller('editIController', function ($scope, $rootScope, $http, $location) {
        var filter_model = { id: $rootScope.invoiceId, type: "null" };
        $scope.message = $http.post('http://danishtest.ml/api/invoice/getinvoice', filter_model).
            then(function (response) {

                $scope.customers = response.data[0];
                $scope.customers.date = $scope.customers.date.substring(0, 10);
                $scope.customers.delivery = $scope.customers.delivery.substring(0, 10);
                console.log(response.data[0]);
                $rootScope.invoiceId = 0;
            });

        //print function here
        $scope.print = function () {
            $rootScope.printPdfCheck = true;
            var printContents = document.getElementById('exportThis').innerHTML;
            var popupWin = window.open('', '_blank', 'width=150,height=150');
            popupWin.document.open();
            popupWin.document.write('<html><head>  <link rel="stylesheet" href="css/bootstrap.min.css"><link rel="stylesheet" href="css/font-awesome/css/font-awesome.min.css"><link rel="stylesheet" href="views/css/stylesheet.css"></head><body onload="window.print()">' + printContents + '</body></html>');
            popupWin.document.close();
            $rootScope.printPdfCheck = false;
        };
        $scope.exports = function () {
            $rootScope.printPdfCheck = true;
            html2canvas(document.getElementById('exportThis'), {
                onrendered: function (canvas) {
                    var data = canvas.toDataURL();
                    var docDefinition = {
                        content: [{
                            image: data,
                            width: 500,
                        }]
                    };
                    pdfMake.createPdf(docDefinition).download("Invoice.pdf");
                }
            });
            $rootScope.printPdfCheck = false;
        };

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
    //  edit invoice page directions are set here
    app.controller('editInvoice', function ($scope, $rootScope, $http, $location, getBillerService, getTaxService, createInvoice, getProductId) {
        var filter_model = { id: $rootScope.invoiceId, type: "null" };
        $scope.message = $http.post('http://danishtest.ml/api/invoice/getinvoice', filter_model).
            then(function (response) {

                $scope.customers = response.data[0];
                $rootScope.invoiceId = 0;
                $scope.bille = $scope.customers.billerName;
                $scope.custome = $scope.customers.custName;
                $scope.tax = $scope.customers.taxPercent;
                $scope.quantity = $scope.customers.quantity;
                $scope.created = $scope.customers.date.substring(0, 10);
                $scope.date = $scope.customers.delivery.substring(0, 10);

                for (var i = 0; i < $scope.customers.product.length; i++) {
                    $scope.customers.product[i].total = $scope.customers.product[i].quantity * $scope.customers.product[i].price * $scope.customers.product[i].taxPercent * 0.01 + $scope.customers.product[i].quantity * $scope.customers.product[i].price;
                    // alert($scope.customers.product[i].total);
                }
                var old = [];
                for (var i = 0; i < $scope.customers.product.length; i++) {
                    old[i] = $scope.customers.product[i].price;
                }

                for (var i = 0; i < $scope.customers.product.length; i++) {
                    $scope.$watch('customers.product[' + i + '].total', function (newValue, oldValue) {
                        var old = $scope.customers.price;
                        $scope.customers.price = $scope.customers.price + newValue;
                        $scope.customers.price = $scope.customers.price - oldValue;
                        var diff = $scope.customers.price - old;

                        $scope.customers.balance = $scope.customers.balance + diff;
                    });
                }

            });
        $scope.edits = function () {
            console.log("ssss");
            $scope.customers.billerId = $scope.bill;
            $scope.customers.customerId = $scope.custom;
            $scope.customers.delivery = $scope.dates;
            for (var i = 0; i < $scope.customers.product.length; i++) {
                for (var j = 0; j < $scope.taxes.length; j++) {
                    if ($scope.taxes[j].percent == $scope.customers.product[i].taxPercent) {
                        $scope.customers.product[i].taxId = $scope.taxes[j].id;
                    }
                }
            }
            console.log($scope.customers);


            //here take your $scope.customers invoice  variable :) have fun

            $scope.message = $http.post('http://danishtest.ml/api/invoice/editInvoice', $scope.customers).
                then(function (response) {
                    $scope.sales = response.data;
                    console.log($scope.sales);
                    $location.path('/invoices');
                    // console.log($scope.sales);
                });
        }

        //product
        var product = "Product";
        var promiseGet = createInvoice.fillscope(0); //The MEthod Call from service
        promiseGet.then(function (pl) {
            $scope.products = pl.data
        },
            function (errorPl) {
                $log.error('failure loading products', errorPl);
            });
        //taxes
        var promiseGet = getTaxService.getTaxes();
        promiseGet.then(function (pl) {
            $scope.taxes = pl.data
        },
            function (errorpl) {
                $log.error('Failure loading Tax', errorpl);
            });
        //billers
        var biller = "biller";
        var promiseGet = getBillerService.getBiller(biller); //The MEthod Call from service
        promiseGet.then(function (pl) {
            $scope.billers = pl.data
        },
            function (errorPl) {
                $log.error('failure loading Biller', errorPl);
            });

        //    customers
        var customer = "Customer";
        var promiseGet = getBillerService.getBiller(customer); //The MEthod Call from service

        promiseGet.then(function (pl) {
            $scope.customer = pl.data
        },
            function (errorPl) {
                $log.error('failure loading Customers', errorPl);
            });


        $scope.updatePrice = function (index) {
            var value = document.getElementById('prod-' + index).value;
            var prod = $scope.customers.product[index];
            for (var i = 0; i < $scope.products.length; i++) {
                if ($scope.products[i].name == value) {
                    prod.name = $scope.products[i].name;
                    prod.price = $scope.products[i].price;
                    //call function to update price and all other fields wrt product change
                    $scope.customers.product[index] = prod;
                    prod.total = prod.quantity * prod.price * prod.taxPercent * 0.01 + prod.quantity * prod.price;

                    return;
                }
            }
        }
        //blur function editProd
        $scope.editProd = function (index, name) {
            if (name == "quantity") {

                // now that quantity hass changed so we need to change price accordingly
                var prod = $scope.customers.product[index];
                prod.total = prod.quantity * prod.price * prod.taxPercent * 0.01 + prod.quantity * prod.price;
                $scope.customers.product[index] = prod;
            }
            if (name == "tax") {

                // alert("eeach");// now that tax hass changed so we need to change price accordingly
                var prod = $scope.customers.product[index];
                var taxId = document.getElementById('tax-' + index).value;
                for (var i = 0; i < $scope.taxes.length; i++) {
                    if ($scope.taxes[i].id == taxId) {
                        prod.taxPercent = $scope.taxes[i].percent;
                    }
                }
                prod.total = prod.quantity * prod.price * prod.taxPercent * 0.01 + prod.quantity * prod.price;
                $scope.customers.product[index] = prod;
            }
            if (name == "price") {
                // now that price hass changed so we need to change price accordingly
                var prod = $scope.customers.product[index];


                prod.total = prod.quantity * prod.price * prod.taxPercent * 0.01 + prod.quantity * prod.price;
                $scope.customers.product[index] = prod;
            }

        }
    });
    //
})
    ();