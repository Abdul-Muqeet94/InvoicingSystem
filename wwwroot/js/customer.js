(function(){
    var app = angular.module("customerModule", ['ngRoute','customservice']);

app.controller("addCustomer", function($scope,$http,customfields){
$scope.customFields = [];
$scope.customFields =  customfields.get('customer');
console.log($scope.customFields);

$scope.addCustomer = function(){

var customer = {
    id: '0',
    name:$scope.name,
    address:$scope.address,
    contact:$scope.contact,
    email:$scope.email,
    city:$scope.city,
    customFields:$scope.customFields
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