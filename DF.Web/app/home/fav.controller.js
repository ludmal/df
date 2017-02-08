
(function () {
    "use strict";

    angular
        .module("home.module")
        .controller("FavController", FavController);

    FavController.$inject = ["$scope", "$rootScope", "$window", "$http", "Settings", "$location", "UtilService"];

    function FavController($scope, $rootScope, $window, $http, Settings, $location, UtilService) {

        $scope.list = [];

        $scope.init = function() {
            $http.get(Settings.ApiUrl + 'deals/fav').then(function(response) {
                $scope.list = response.data;
            });
        }

        $scope.init();

    };

})();