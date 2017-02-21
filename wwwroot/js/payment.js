(function(){
    var app = angular.module("paymentModule", ['ngRoute']);

app.config(function($routeProvider) {
    $routeProvider
    .when("/payment", {
        //templateUrl : '<h1>HelloWorld!</h1>'
        templateUrl : "../views/payment.html"
    })
    
});


//
      

       }
  )
  ();
