(function () {
    var app = angular.module("billerModule", ['ngRoute']);
    app.controller("addBiller", function ($scope, $http, $log, customfields, $location) {
        $scope.customFields = [];
        var getResult = customfields.get('"Biller"');
        getResult.then(function (pl) {
            $scope.customFields = pl.data
            for (var i = 0; i < $scope.customFields.length; i++) {
                $scope.customFields[i].fieldValue = "";
            }
        },
            function (errorPl) {
                $log.error('failure loading customeFields', errorPl);
            });

        $scope.counter = 0;
        $scope.save = function () {
            $scope.biller.id = 0;
            $scope.biller.customFields = $scope.customFields;
            console.log($scope.biller);
            $scope.message = $http.post('http://danishtest.ml/api/biller/create', $scope.biller).
                then(function (response) {
                    swal({
                            title: 'Saved',
                            text: 'Biller added Successfully',
                            type:'success',
                            timer: 2000
                        });
                            $location.path("/billers");
                });
        }
    });

    app.controller("getBiller", function ($scope, $http, $rootScope, $location) {

        $scope.message = $http.post('http://danishtest.ml/api/biller/getBiller', $rootScope.billerId).
            then(function (response) {
                $scope.billers = response.data;

            });

        $scope.setRoot = function (x) {
            $rootScope.billerId = x;
        };

        $scope.deleteBiller = function (x) {
            $scope.message = $http.post('http://danishtest.ml/api/biller/delete', x).
                then(function (response) {
                    $scope.response = response.data;

                    alert($scope.response.developerMessage);

                    $location.path("/billers");
                });
        };

    });
    app.controller('editBController', function ($scope, $rootScope, $http, $location) {
        $scope.message = $http.post('http://danishtest.ml/api/biller/getBiller', $rootScope.billerId).
            then(function (response) {
                $scope.billers = response.data[0];
                $rootScope.billerId = 0;
            });

        $scope.edit = function () {

            $scope.message = $http.post('http://danishtest.ml/api/biller/edit', $scope.billers).
                then(function (response) {

                    $scope.promise = response.data;
                    console.log($scope.promise);
                    $location.path("/billers");
                });
        }
    });

}
)
    ();