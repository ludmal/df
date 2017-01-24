(function () {
    angular.module('app')
        .config([
            'cfpLoadingBarProvider', '$httpProvider', '$provide', function (cfpLoadingBarProvider, $httpProvider, $provide) {
                cfpLoadingBarProvider.includeSpinner = false;
                $httpProvider.defaults.cache = true;
            }
        ])
        .run([
            '$rootScope', function ($rootScope) {
            }
        ]);
})();