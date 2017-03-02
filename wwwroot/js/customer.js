(function(){
    var app = angular.module("customerModule", ['ngRoute','customservice']);
  app.controller('crudController', function($scope, getCustomerService) {

        $scope.IsNewRecord = 1; //The flag for the new record

        loadRecords();

        //Function to load all Employee records
        function loadRecords() {
            var promiseGet = getCustomerService.getEmployees(); //The MEthod Call from service

            promiseGet.then(function(pl) { $scope.Customers = pl.data },
                function(errorPl) {
                    $log.error('failure loading Employee', errorPl);
                });
        }

    });
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
    picture:$scope.picture.base64,
    bodyType:$scope.select,
    //
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
