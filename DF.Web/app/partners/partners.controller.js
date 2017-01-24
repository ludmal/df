
(function () {
    "use strict";

    angular
        .module("partners.module")
        .controller("PartnersController", PartnersController);

    PartnersController.$inject = ["$scope", "$rootScope", "$window", "$http", "Settings", "$location", "UtilService"];

    function PartnersController($scope, $rootScope, $window, $http, Settings, $location, UtilService) {

        $scope.title = 'hey part';
    };

})();