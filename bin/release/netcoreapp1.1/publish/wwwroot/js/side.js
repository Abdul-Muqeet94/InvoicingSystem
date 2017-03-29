(function(){
    var app = angular.module("sideModule", ['ngRoute','customerModule','productModule','invoiceModule', 'serviceModule','billerModule','customModule','taxModule','paymentModule']);
app.run(function($rootScope) {

    $rootScope.customerId = 0;
     $rootScope.ProductId = 0;
     $rootScope.billerId = 0;
     $rootScope.customId = 0;
     $rootScope.invoiceId=0;
     $rootScope.taxId=0;
});

app.config(function($routeProvider) {
    $routeProvider
    .when("/customer", {
        templateUrl : "../views/customer.html"
    })

    .when("/payment", {
        templateUrl : "../views/payment.html"
    })

    .when("/invoices", {
        templateUrl : "../views/invoices.html"
    })

.when("/viewinvoices", {
        templateUrl : "../views/viewinvoices.html"
    })
    .when("/editinvoices", {
        templateUrl : "../views/editinvoices.html"
    })


    .when("/salesReport", {
        templateUrl : "../views/customer.html"
    })

    .when("/user", {
        templateUrl : "../views/customer.html"
    })
    .when("/allReports", {
        templateUrl : "../views/Allreports.html"
    })
    .when("/add", {
        templateUrl : "../views/addCustomer.html",
       
    })
    .when("/adduser", {
        templateUrl : "../views/Adduser.html"
    })
.when("/reccurence", {
        templateUrl : "../views/reccurence.html"
    })
.when("/viewinvoices", {
        templateUrl : "../views/viewinvoices.html"
    })
.when("/addinvoice", {
        templateUrl : "../views/addinvoice.html"
    })
.when("/addpayment", {
        templateUrl : "../views/addpayment.html"
    })

    .when("/manageproduct", {
        templateUrl : "../views/manageproduct.html"
    })

      .when("/addproduct", {
        templateUrl : "../views/Addproduct.html"
    })
    .when("/viewCustomer", {
        templateUrl : "../views/viewCustomer.html"
    })
 .when("/editCustomer", {
        templateUrl : "../views/editCustomer.html"
    })
      .when("/viewProduct", {
        templateUrl : "../views/viewProduct.html"
    })
 .when("/editProduct", {
        templateUrl : "../views/editProduct.html"
    })

       .when("/viewBiller", {
        templateUrl : "../views/viewbiller.html"
    })
 .when("/editBiller", {
        templateUrl : "../views/editbiller.html"
    })
    .when("/billers", {
        templateUrl : "../views/billers.html"
    })
    
    .when("/customfields", {
        templateUrl : "../views/customfields.html"
    })

       .when("/viewcustomfields", {
        templateUrl : "../views/viewcustomfields.html"
    })
    .when("/addcustoms", {
        templateUrl : "../views/addcustoms.html"
    })
    .when("/customs", {
        templateUrl : "../views/customs.html"
    })
 .when("/editcustoms", {
        templateUrl : "../views/editcustoms.html"
    })
    .when("/tax", {
        templateUrl : "../views/tax.html"
    })
    .when("/edittax", {
        templateUrl : "../views/edittax.html"
    })
    .when("/addtax", {
        templateUrl : "../views/addtax.html"
    })
   
});
    }
  )
  ();
