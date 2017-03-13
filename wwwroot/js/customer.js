(function(){
    var app = angular.module("customerModule", ['ngRoute','customservice','naif.base64']);
  app.controller('crudController', function($scope,$log,$rootScope,$http,$location) {

 $scope.message =  $http.post('http://localhost:5000/api/customer/getCustomers',$rootScope.customerId).
         then(function (response){        
           $scope.Customers = response.data;
           $scope.customs = $scope.Customers[0].customfields;
               console.log(response.data);  
                });
                $scope.edit = function()
                {
var customer = {
id: '0',
    name:$scope.name,
    address:$scope.address,
    contact:$scope.contact,
    email:$scope.email,
    city:$scope.city,
    shoulder:$scope.shoulder,
    chest:$scope.chest,
    waist:$scope.waist,
    upperWaist:$scope.upperWaist,
    lowerWaist:$scope.lowerWaist,
    hips:$scope.hips,
    armHole:$scope.armHole,
    fullSleeveLength:$scope.fullSleeveLength,
    sleeveLength:$scope.sleeveLength,
    bicep:$scope.bicep,
    foreArm:$scope.foreArm,
    wrist:$scope.wrist,
    longShirtLength:$scope.longShirtLength,
    shortShirtLength:$scope.shortShirtLength,
    chaak:$scope.chaak,
    daaman:$scope.daaman,
    frontNeckDepth:$scope.frontNeckDepth,
    frontNeckWidth:$scope.frontNeckWidth,
    backNeckDepth:$scope.backNeckDepth,
    backNeckWidth:$scope.backNeckWidth,
    thigh:$scope.thigh,
    kneeCap:$scope.kneeCap,
    calf:$scope.calf,
    ankle:$scope.ankle,
    pantLength:$scope.pantLength,
  // imagePath:$scope.picture.base64,
    bodyType:$scope.select,
    customFields:[]
}
console.log(customer);
$scope.message =  $http.post('http://localhost:5000/api/customer/edit',customer).
         then(function (response){        
           $scope.Customers = response.data;
           $scope.customs = $scope.Customers[0].customfields;
               console.log(response.data);  
                });

                }
       
        $scope.setRoot = function(x){
$rootScope.customerId=x;
console.log($rootScope.customerId);
        };
        ///////
        $scope.deleteCustomer = function(x){
 $scope.message =  $http.post('http://localhost:5000/api/customer/delete',x).
         then(function (response){        
           $scope.response = response.data;
            console.log(response.data);  
           alert($scope.response.developerMessage);
           //  route to customer.html
           $location.path( "/customer" );
                });
        };
        //////

    });
app.controller("addCustomer", function($scope,$http,customfields){
$scope.customFields = [];
var getResult =  customfields.get('"Customer"');
getResult.then(function(pl) { $scope.customFields = pl.data },
                function(errorPl) {
                    $log.error('failure loading customeFields', errorPl);
                });
console.log($scope.customFields);
$scope.addCustomer = function(){
   
var customer = {
    id: '0',
    name:$scope.name,
    address:$scope.address,
    contact:$scope.contact,
    email:$scope.email,
    city:$scope.city,
    shoulder:$scope.shoulder,
    chest:$scope.chest,
    waist:$scope.waist,
    upperWaist:$scope.upperWaist,
    lowerWaist:$scope.lowerWaist,
    hips:$scope.hips,
    armHole:$scope.armHole,
    fullSleeveLength:$scope.fullSleeveLength,
    sleeveLength:$scope.sleeveLength,
    bicep:$scope.bicep,
    foreArm:$scope.foreArm,
    wrist:$scope.wrist,
    longShirtLength:$scope.longShirtLength,
    shortShirtLength:$scope.shortShirtLength,
    chaak:$scope.chaak,
    daaman:$scope.daaman,
    frontNeckDepth:$scope.frontNeckDepth,
    frontNeckWidth:$scope.frontNeckWidth,
    backNeckDepth:$scope.backNeckDepth,
    backNeckWidth:$scope.backNeckWidth,
    thigh:$scope.thigh,
    kneeCap:$scope.kneeCap,
    calf:$scope.calf,
    ankle:$scope.ankle,
    pantLength:$scope.pantLength,
   imagePath:$scope.picture.base64,
    bodyType:$scope.select,
    
    customFields:$scope.customFields
}


 console.log(customer);
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
