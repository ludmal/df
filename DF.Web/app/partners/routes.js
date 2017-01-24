(function () {
    "use strict";

    angular
        .module("partners.module")
        .config(config);

    config.$inject = ["$stateProvider", '$urlRouterProvider', '$locationProvider'];

    function config($stateProvider, $urlRouterProvider, $locationProvider) {

        $stateProvider
            .state("MainPartners",
            {
                url: "/partners",
                pageTitle: "Main Partners",
                templateUrl: "/partners/index"
            })
            .state("PartnerDeals",
            {
                url: "/partners/{slug}",
                pageTitle: "Partner Deals",
                templateUrl: "/partners/deals"
            });

    }
})();