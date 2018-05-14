(function() {

    "use strict";

    angular
        .module("app")
        .config(config);

    config.$inject = ["$routeProvider", "$locationProvider"];

    function config($routeProvider, $locationProvider) {
        $locationProvider.html5Mode(true);
        $routeProvider.caseInsensitiveMatch = true;
        $routeProvider
            .when("/status",
            {
                templateUrl: "app/shared/status.view.html",
                controller: "StatusController",
                controllerAs: "vm"
            })
            .otherwise(
            {
                redirectTo: "/status"
            });
    }
})();