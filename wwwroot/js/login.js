(function () {


    
    var app = angular.module("loginModule", ['ngRoute']);
    app.controller('loginController', function ($scope,$rootScope, $http, $log,$location,$window) {
        $scope.login = { id: 0, email: '', password: '' };
        $scope.validate = function () {
            console.log($scope.login);
            $scope.message = $http.post('http://localhost:5000/api/login/biller', $scope.login).
                then(function (response) {
                    $scope.result = response.data
                    console.log($scope.result.status);
                    if($scope.result.status>0){
                    $scope.saveSession($scope.result.status);
                     $window.location.href = '../shared/side_layout.html';
                    }
                    else{
                    $rootScope.check = true;
                    }
                });

                
           
        };
       

        $scope.saveSession=function(val){
            $scope.message = $http.post('http://localhost:5000/api/login/savesession', val).
                then(function (response) {
                    $scope.result = response.data
                    console.log($scope.result);
                });
        };
         $scope.getSession=function(){
            $scope.message = $http.post('http://localhost:5000/api/login/getsession').
                then(function (response) {
                    $scope.result = response.data
                    if($scope.result>0){
                       // return true;
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