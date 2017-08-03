// tripsController.js
(function () {

    "use strict";

    // Getting the existing module
    angular.module("app-trip")
        .controller("tripsController", tripsController);

    function tripsController($http) {

        var vm = this;

        vm.trips = [];

        vm.newTrip = {}; //empty object

        vm.errorMessage = "";
        vm.isBusy = true;


        //ask our interface for all the trips from current user
        $http.get("/api/trips")
            .then(function (response) {
                // Success
                angular.copy(response.data, vm.trips);
                //console.log(vm.trips);
                
            }, function (error) {
                // Failure
                vm.errorMessage = "Failed to load data: " + error;
            })
            .finally(function () {
                vm.isBusy = false;
            });

        vm.addTrip = function () {
            
            vm.isBusy = true;
            vm.errorMessage = "";


            //we are posting to this api with the value from vm.newTrip input
            $http.post("/api/trips", vm.newTrip)
                .then(function (response) {
                    // success
                    vm.trips.push(response.data);
                    vm.newTrip = {}; //then we clear that input
                }, function () {
                    // failure
                    vm.errorMessage = "Failed to save new trip";
                })
                .finally(function () {
                    vm.isBusy = false;
                });

        };



    }

})();