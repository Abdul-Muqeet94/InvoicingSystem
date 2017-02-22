(function(){
    var app = angular.module("productModule", ['ngRoute']);

app.controller("addProduct",function($scope,$http){

$scope.addProduct = function(){

var customer = {
    id: '0',
    name:$scope.name,
    address:$scope.address,
    contact:$scope.contact,
    email:$scope.email,
    city:$scope.city,
    customFields:[]
}

    $scope.message =  $http.post('http://localhost:5000/api/customer/create',customer).
         then(function (response){
           console.log(response.data);
           $scope.message = response.data;
           $log.info(response);
 });
    
     }
         });

         //controller ends here

         app.controller("manageDesign",function($scope){

 $scope.inputs = [];

$scope.counter = 0;
   var page = $scope.counter+'color';
    $scope.add = function(){
   var obj = {page:'', fabric:''};
   $scope.inputs.push(obj);
     }

 $scope.remove = function(){
   
   $scope.inputs.splice(1,1);
   
}
         });

        //controller ends here
              }
                  )
                       ();