
(function() {
    'use strict';

    angular.module('app', [
        'ngResource',
        'ngSanitize',
        'ngCookies',
        'ui.router',
        'ui.bootstrap',
        'angular-loading-bar',
        'core.module',
        'home.module',
        'category.module',
        'partners.module',
        'deals.module'
    ]);
})();