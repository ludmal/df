
(function () {
    "use strict";

    angular
        .module("deals.module")
        .controller("DealsController", DealsController);

    DealsController.$inject = ["$scope", "$rootScope", "$window", "$http", "Settings", "$location", "UtilService"];

    function DealsController($scope, $rootScope, $window, $http, Settings, $location, UtilService) {

        $scope.title = 'All the deals for you';
    };

})();