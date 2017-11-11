(function () {


    
    var app = angular.module("loginModule", ['ngRoute']);
    app.controller('loginController', function ($scope,$rootScope, $http, $log,$location,$window,$timeout) {
        $scope.login = { id: 0, email: '', password: '' };
        $scope.validate = function () {
            console.log($scope.login);
            $scope.message = $http.post('http://danishtest.ml/api/login/biller', $scope.login).
                then(function (response) {
                    $scope.result = response.data
                    console.log($scope.result.status);
                    if($scope.result.status>0){
                    $scope.saveSession($scope.result.status);
                //   $timeout(function() { $scope.saveSession($scope.result.status);}, 2000);
               console.log($scope.saveSession($scope.result.status));
                    if($scope.result.status>0){
                        $window.location.href = '../shared/side_layout.html';
                    }
                     
                    }
                    else{
                    $rootScope.check = true;
                    }
                });
           
        };
       

        $scope.saveSession=function(val){
            
            $scope.message = $http.post('http://danishtest.ml/api/login/savesession', val).
                then(function (response) {
                    $scope.result = response.data
                    $rootScope.sessionId= $scope.result;
                    
                });
                
        };
         $scope.getSession=function(){
            $scope.message = $http.post('http://danishtest.ml/api/login/getsession').
                then(function (response) {
                    $scope.result = response.data
                    if($scope.result>0){
                       console.log($scope.result);
                    }
                    else{

                        $window.location.href = '../index.html';
                       // return false;
                    }
                    console.log($scope.result);

                });
        };

    });

})();