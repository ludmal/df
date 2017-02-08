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
            })
         .state("HomeRegister",
            {
                url: "/register",
                pageTitle: "Register",
                templateUrl: "/home/registernew"
            })
         .state("Fav",
            {
                url: "/fav",
                pageTitle: "Fav",
                templateUrl: "/home/fav"
            })
         .state("UserProfole",
            {
                url: "/profile",
                pageTitle: "UserProfile",
                templateUrl: "/home/userprofile"
            });
    }
})();