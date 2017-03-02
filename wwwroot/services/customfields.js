(
    function(){
  var app = angular.module("customservice", []);

app.service('customfields',function($http){
this.get = function(x) {
         $http.post('http://localhost:5000/api/customfield/getcustomfield',x).
         then(function(response){
             console.log("ending service");
           console.log(response);
          return response;
 });
     }

});



    }
  )
  ();
