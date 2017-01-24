
(function () {
    "use strict";

    angular
        .module("deals.module")
        .controller("DealController", DealController);

    DealController.$inject = ["$scope", "$rootScope", '$stateParams', "$window", "$http", "Settings", "$location", "UtilService", 'DealService'];

    function DealController($scope, $rootScope, $stateParams, $window, $http, Settings, $location, UtilService, DealService) {
        $scope.slug = $stateParams.slug;

        $scope.deal = {};
        $scope.mostViewed = [];

        $scope.init = function () {
            DealService.dealsBySlug($scope.slug).then(function (response) {
                console.log(response);
                $scope.deal = response.data.Deal;
                $scope.mostViewed = response.data.DealList;
            });
        };

        $scope.init();
    };

})();