(function () {
  var app = angular.module("paymentModule", ['ngRoute']);

  app.controller("addpayment", function ($scope, $http,$location) {
      var  filter_model = { id: 0, type: "all" };
    $scope.message = $http.post('http://danishtest.ml/api/invoice/getinvoice',filter_model).
      then(function (response) {
        $scope.invoices = response.data;
        console.log($scope.invoices);

        $scope.save = function () {
          $scope.paymentTypeId = 1;

          $scope.message = $http.post('http://danishtest.ml/api/payment/createpayment', $scope.pay).
            then(function (response) {
              $scope.invoices = response.data[0];
              swal({
                            title: 'Saved',
                            text: 'Payment added Successfully',
                            timer: 2000
                        }).then(
                            function () { },
                            // handling the promise rejection
                            function (dismiss) {
                                if (dismiss === 'timer') {
                                    console.log('.............')
                                }
                            }
                            )
             $location.path("/invoices");
            });
        };

      });
  });

  //list of payments
  app.controller("listallpayment", function ($scope, $http) {

    $scope.message = $http.post('http://danishtest.ml/api/payment/listpayment', 0).
      then(function (response) {
        $scope.payments = response.data;
        console.log($scope.payments);
      });
  });
  //
})();
