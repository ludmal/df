
(function () {
    "use strict";

    angular
        .module("home.module")
        .controller("HomeController", HomeController);

    HomeController.$inject = ["$scope", "$rootScope", "$window", "$http", "Settings", "$location", "UtilService"];

    function HomeController($scope, $rootScope, $window, $http, Settings, $location, UtilService) {

        $scope.title = 'hey this is home';
    };

})();