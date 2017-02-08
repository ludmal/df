
(function () {
    "use strict";

    angular
        .module("home.module")
        .controller("RegisterController", RegisterController);

    RegisterController.$inject = ["$scope", '$state', "$rootScope", "$window", "$http", "Settings", "$location", "UtilService", 'notify'];

    function RegisterController($scope, $state, $rootScope, $window, $http, Settings, $location, UtilService, notify) {

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

        $scope.list = [];

        $scope.add = function (cat) {
            for (var i = $scope.list.length - 1; i >= 0; i--) {
                if ($scope.list[i] === cat) {
                    $scope.list.splice(i, 1);
                    console.log('revmoed', i);
                    return;
                }
            }

            $scope.list.push(cat);
        }

        $scope.check = function (cat) {
            return $scope.list.indexOf(cat) > -1;
        };

        $scope.register = function () {
            var url = Settings.ApiUrl + 'users/register';
            console.log($scope.model);
            $scope.model.AuthCode = $scope.list.join();
            $http.post(url, $scope.model).then(function (response) {
                //done
                console.log('registered!');
                notify({
                    message: 'Thank you for registering and start exploring your personalised deals!',
                    classes: "msg-success"
                });
                $window.location.href = '/';
                //$state.go('HomeMain');
            });
        }
    };

})();