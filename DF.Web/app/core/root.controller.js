
(function() {
    "use strict";

    angular
        .module("core.module")
        .controller("RootController", RootController);

    RootController.$inject = ["$scope", "$rootScope", "$window", "$http",'DealService', "Settings", "$location",'notify', "UtilService"];

    function RootController($scope, $rootScope, $window, $http, DealService, Settings, $location, notify, UtilService) {

        $scope.loggedIn = false;

        $scope.favDeals = [];

        $scope.checkFav = function (dealId) {
            console.log('check fa', $scope.favDeals.indexOf(dealId) > -1);

            return $scope.favDeals.indexOf(dealId) > -1;
        };

        $scope.addFav = function (dealId) {
            console.log(dealId);
            DealService.addFav(dealId);
            $scope.favDeals.push(dealId);
            console.log('fav deals', $scope.favDeals);

            notify({
                message: 'Deal added to your favourites!',
                classes: "msg-success"
            });
        }

        $rootScope.$on('cfpLoadingBar:loading', function (event, data) {
            $('#load-div').show();
        });

        $rootScope.$on('cfpLoadingBar:completed', function (event, data) {
            $('#load-div').hide();
        });

    };

})();