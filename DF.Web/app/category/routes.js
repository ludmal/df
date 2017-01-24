(function () {
    "use strict";

    angular
        .module("category.module")
        .config(config);

    config.$inject = ["$stateProvider", '$urlRouterProvider', '$locationProvider'];

    function config($stateProvider, $urlRouterProvider, $locationProvider) {

        $stateProvider
            .state("MainCategory",
            {
                url: "/categories",
                pageTitle: "Main Category",
                templateUrl: "/category/index"
            })
            .state("DealsCat",
            {
                url: "/category/{slug}",
                pageTitle: "Deals",
                templateUrl: "/category/deals"
            });

    }
})();