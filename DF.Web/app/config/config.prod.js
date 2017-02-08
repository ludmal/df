(function () {
    angular.module('app')
        .config([
            'cfpLoadingBarProvider', '$httpProvider', '$provide', function (cfpLoadingBarProvider, $httpProvider, $provide) {
                cfpLoadingBarProvider.includeSpinner = false;
                $httpProvider.defaults.cache = false;
                $httpProvider.interceptors.push('HttpInterceptor');

            }
        ])
        .run([
            '$rootScope', function ($rootScope) {
            }
        ]);
})();