(function () {
    "use strict";

    angular
        .module("deals.module")
        .config(config);

    config.$inject = ["$stateProvider", '$urlRouterProvider', '$locationProvider'];

    function config($stateProvider, $urlRouterProvider, $locationProvider) {

        $stateProvider
            .state("MainDeal",
            {
                url: "/deals",
                pageTitle: "Main Deals",
                templateUrl: "/deals/index"
            })
            .state("Deal",
            {
                url: "/deals/{slug}",
                pageTitle: "Deal",
                templateUrl: "/deals/deal"
            });

    }
})();