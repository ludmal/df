
(function () {
    "use strict";

    angular
        .module("home.module")
        .controller("UserProfileController", UserProfileController);

    UserProfileController.$inject = ["$scope", "$rootScope", "$window", "$http", "Settings", "$location", "UtilService", 'notify'];

    function UserProfileController($scope, $rootScope, $window, $http, Settings, $location, UtilService, notify) {
            
        $scope.model = {
            Username: '',
            Password: '',
            Name: '',
            Mobile: '',
            Title: '',
            AgeGroup: '',
            UserGender: '',
            AuthCode:''
        };

        $scope.init = function() {
            $http.get(Settings.ApiUrl + '/users/profile').then(function(response) {
                $scope.model = response.data;
                $scope.list = $scope.model.AuthCode.split(',');
            });
        }

        $scope.list = [];

        $scope.add = function (cat) {
            for (var i = $scope.list.length - 1; i >= 0; i--) {
                if ($scope.list[i] === cat) {
                    $scope.list.splice(i, 1);
                    return;
                }
            }

            $scope.list.push(cat);
        }

        $scope.check = function (cat) {
            return $scope.list.indexOf(cat) > -1;
        };


        $scope.init();

        $scope.update = function () {
            $scope.model.AuthCode = $scope.list.join();
            $http.post(Settings.ApiUrl + '/users/profile', $scope.model).then(function (response) {
                notify({
                    message: 'User profile successfully updated!',
                    classes: "msg-success"
                });
            });
        }
    };

})();