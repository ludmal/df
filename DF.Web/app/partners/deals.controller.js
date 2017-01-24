
(function () {
    "use strict";

    angular
        .module("partners.module")
        .controller("DealsPartnersController", DealsPartnersController);

    DealsPartnersController.$inject = ["$scope", "$rootScope", "$window", "$http", "Settings", "$location", "UtilService", 'DealService', '$stateParams'];

    function DealsPartnersController($scope, $rootScope, $window, $http, Settings, $location, UtilService, DealService, $stateParams) {
        $scope.partner = $stateParams.slug;
        $scope.list = [];

        $scope.init = function () {
            DealService.dealsByPartner($scope.partner).then(function (response) {
                console.log(response);
                $scope.list = response.data;
            });
        };

        $scope.init();

    };

})();