(function() {

    var app = angular.module('serviceModule', []);
    app.service('getBillerService', function($http) {
        //Get All Employees
        this.getBiller = function(biller) {
            //console.log(name);

            return $http.post("http://localhost:5000/api/invoice/populatedropdown", '"' + biller + '"');
        }

    });
    app.service('getCustomerService', function($http) {


        //Get All Employees
        this.getEmployees = function() {

            return $http.post("http://localhost:5000/api/customer/getCustomers", 0);
        }

    });
})();