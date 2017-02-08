(function () {
    'use strict';
    angular
        .module('core.module')
        .directive('dealRow', [
            function () {
                var controller = [
                    '$scope', '$http', 'DealService','notify', function ($scope, $http, DealService, notify) {

                        function init() {
                        }

                        init();
                        
                        
                    }
                ];
                return {
                    restrict: 'E',
                    scope: {
                        "data": "=",
                        "fav": "="
                    },
                    replace: false,
                    controller: controller,
                    templateUrl: '../app/directives/deal-row.html'
                };
            }
        ]);
})();