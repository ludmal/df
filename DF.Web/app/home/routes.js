(function () {
    "use strict";

    angular
        .module("home.module")
        .config(config);

    config.$inject = ["$stateProvider", '$urlRouterProvider', '$locationProvider'];

    function config($stateProvider, $urlRouterProvider, $locationProvider) {

        $urlRouterProvider
             .when('', '/');

        $stateProvider
            .state("HomeMain",
            {
                url: "/",
                pageTitle: "Main",
                templateUrl: "/home/homemain"
            });

    }
})();