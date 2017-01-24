(function () {
    'use strict';
    angular
        .module('core.module')
        .directive('dealRow', [
            function () {
                var controller = [
                    '$scope', '$http', function ($scope, $http) {

                        function init() {
                        }

                        init();
                    }
                ];
                return {
                    restrict: 'E',
                    scope: {
                        "data": "="
                    },
                    replace: false,
                    controller: controller,
                    templateUrl: '../app/directives/deal-row.html'
                };
            }
        ]);
})();