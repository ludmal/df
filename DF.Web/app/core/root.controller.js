
(function() {
    "use strict";

    angular
        .module("core.module")
        .controller("RootController", RootController);

    RootController.$inject = ["$scope", "$rootScope", "$window", "$http", "Settings", "$location", "UtilService"];

    function RootController($scope, $rootScope, $window, $http, Settings, $location, UtilService) {

        $rootScope.$on('cfpLoadingBar:loading', function (event, data) {
            $('#load-div').show();
        });

        $rootScope.$on('cfpLoadingBar:completed', function (event, data) {
            $('#load-div').hide();
        });

    };

})();