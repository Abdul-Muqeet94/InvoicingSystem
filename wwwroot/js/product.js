(function(){
    var app = angular.module("productModule", ['ngRoute']);


         app.controller("manageDesign",function($scope,$http,$log){

$scope.counter = 0;
$scope.save= function(){
var product = {
    id: '0',
    name:$scope.name,
    color:$scope.color,
    price:$scope.price,
    note:$scope.note,
    description:$scope.description,
    customFields:[]
};
console.log(product);
    $scope.message =  $http.post('http://localhost:5000/api/product/addproduct',product).
         then(function (response){
           console.log(response.data);    
           $scope.message = response.data;
           $log.info(response);
 });

 
}    
  });

app.controller("getProduct",function($scope,$http,$log,$rootScope,$location){

    $scope.message =  $http.post('http://localhost:5000/api/product/getproduct',$rootScope.ProductId).
         then(function (response){        
           $scope.Products = response.data;
           $scope.customs = $scope.Products[0].customfields;
               console.log(response.data);  
                });
 $scope.setRoot = function(x){
$rootScope.ProductId=x;
console.log($rootScope.ProductId);
        };
         $scope.deleteProduct = function(x){
 $scope.message =  $http.post('http://localhost:5000/api/product/deleteproduct',x).
         then(function (response){        
           $scope.response = response.data;
            console.log(response.data);  
           alert($scope.response.developerMessage);
           //  route to customer.html
           $location.path( "/manageproduct" );
                });
        };

});

        //controller ends here
              }
                  )
                       ();