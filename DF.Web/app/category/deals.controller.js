
(function () {
    "use strict";

    angular
        .module("category.module")
        .controller("DealsCatController", DealsCatController);

    DealsCatController.$inject = ["$scope", "$rootScope", "$window", "$http",'$stateParams', "Settings", "$location", "UtilService", 'DealService'];

    function DealsCatController($scope, $rootScope, $window, $http,$stateParams, Settings, $location, UtilService, DealService) {

        $scope.category = $stateParams.slug;
        $scope.list = [];
        $scope.loaded = false;

        $scope.init = function () {
            DealService.dealsByCategory($scope.category).then(function (response) {
                console.log(response);
                $scope.list = response.data;
                $scope.loaded = true;

            });
        };

        $scope.init();
    };

})();