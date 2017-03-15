(function(){
    var app = angular.module("billerModule", ['ngRoute']);
         app.controller("addBiller",function($scope,$http,$log){
$scope.counter = 0;
$scope.save= function(){
$scope.biller.id=0;
    $scope.message =  $http.post('http://localhost:5000/api/biller/addbiller',$scope.biller).
      then(function (response){
        console.log(response.data);    
 });
}    
  });

app.controller("getBiller",function($scope,$http,$rootScope,$location){
    console.log("sss");
    $scope.message =  $http.post('http://localhost:5000/api/biller/getBiller',$rootScope.billerId).
         then(function (response){        
           $scope.billers = response.data;
               console.log(response.data); 
                });

 $scope.setRoot = function(x){
$rootScope.billerId=x;
console.log($rootScope.billerId);
        };

 $scope.deleteBiller = function(x){
 $scope.message =  $http.post('http://localhost:5000/api/biller/delete',x).
         then(function (response){        
           $scope.response = response.data;
            console.log(response.data);  
           alert($scope.response.developerMessage);
          
           $location.path("/billers");
                });
        };

});
        //controller ends here           
     app.controller('editBController', function($scope,$rootScope,$http){
$scope.message =  $http.post('http://localhost:5000/api/biller/getBiller',$rootScope.billerId).
         then(function (response){        
           $scope.billers = response.data[0];
               console.log(response.data[0]);  
               $rootScope.billerId=0;
                });

                $scope.edit = function()
                {          
$scope.message =  $http.post('http://localhost:5000/api/biller/edit',$scope.billers).
         then(function (response){        
               console.log(response.data);  
                  console.log($scope.billers);  
                
            });
                }
     });        
        
    }
                  )
                       ();