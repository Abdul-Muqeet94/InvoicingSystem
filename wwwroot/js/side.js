(function(){
    var app = angular.module("sideModule", ['ngRoute','customerModule','productModule']);

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

    .when("/newInvoices", {
        templateUrl : "../views/customer.html"
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
        templateUrl : "../views/addCustomer.html"
    })
    .when("/Adduser", {
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
    .when("/manageproduct", {
        templateUrl : "../views/manageproduct.html"
    })

      .when("/addproduct", {
        templateUrl : "../views/Addproduct.html"
    })

});
    }
  )
  ();
