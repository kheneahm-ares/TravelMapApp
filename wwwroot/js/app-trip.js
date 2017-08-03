//app-trip.js

(function () {

    "use strict";

    //where I am CREATING the module
    angular.module("app-trip", ["simpleControls","ngRoute"])
        .config(function ($routeProvider) {

            $routeProvider.when("/", {
                controller: "tripsController",
                controllerAs: "vm",
                templateUrl: "/views/tripsView.html"
            });

            $routeProvider.when("/editor/:tripName", { //indicate we want a tripName paramater
                controller: "tripEditorController",
                controllerAs: "vm",
                templateUrl: "/views/tripEditorView.html"
            });

            $routeProvider.otherwise({redirectTo: "/"});

    });
})();