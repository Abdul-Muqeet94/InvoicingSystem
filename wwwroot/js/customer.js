(function(){
    var app = angular.module("customerModule", ['ngRoute']);

app.controller("addCustomer",function($scope,$http){

$scope.addCustomer = function(){

var customer = {
    id: '0',
    name:$scope.name,
    address:$scope.address,
    contact:$scope.contact,
    email:$scope.email,
    city:$scope.city
}

    $scope.message =  $http.post('http://localhost:5000/api/customer/create',customer).
         then(function (response){
           console.log(response.data);
           $scope.message = response.data;
           $log.info(response);
 });
    
     }
         });
              }
                  )
                       ();