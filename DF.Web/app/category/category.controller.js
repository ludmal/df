
(function () {
    "use strict";

    angular
        .module("category.module")
        .controller("CategoryController", CategoryController);

    CategoryController.$inject = ["$scope", "$rootScope", "$window", "$http",'$stateParams', "Settings", "$location", "UtilService", 'DealService'];

    function CategoryController($scope, $rootScope, $window, $http, $stateParams,Settings, $location, UtilService, DealService) {

       
    };

})();