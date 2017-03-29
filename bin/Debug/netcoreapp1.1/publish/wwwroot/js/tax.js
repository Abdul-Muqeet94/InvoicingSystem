( function(){
    var app = angular.module("taxModule", ['ngRoute']);
    app.controller('taxController',function($scope,createTaxService, $rootScope, $log){
        $scope.tax={};
        $scope.save=function(){
            console.log($scope.tax);
            var promiseGet=createTaxService.createTax($scope.tax);
            promiseGet.then(function(pl){
                $scope.response=pl.data
            },function(errorpl){
                $log.error('failure to Create Invoice',errorpl);
            });
        };
        $scope.reset=function(){
            $scope.tax={};
        }
    });
})();