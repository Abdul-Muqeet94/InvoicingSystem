(function(){
    var app = angular.module("productModule", ['ngRoute']);


         app.controller("manageDesign",function($scope,$http,$log){

 $scope.inputs = [];

$scope.counter = 0;
   
    $scope.add = function(){
   var obj = {color:'', fabric:'',note:'',cut:''};
   $scope.inputs.push(obj);
     }
 $scope.remove = function(){
   
   $scope.inputs.splice(1,1);
}
$scope.save= function(){
var product = {
    id: '0',
    name:$scope.name,
    color:$scope.color,
    price:$scope.price,
    note:$scope.note,
    description:$scope.description,
    customFields:[],
    design:$scope.inputs
}
console.log(product);
    $scope.message =  $http.post('http://localhost:5000/api/product/addproduct',product).
         then(function (response){
           console.log(response.data);    
           $scope.message = response.data;
           $log.info(response);
 });
}    




  });

        //controller ends here
              }
                  )
                       ();