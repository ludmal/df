
(function() {
    'use strict';

    angular
        .module('core.module')
        .factory('AuthInterceptor', AuthInterceptor);

    AuthInterceptor.$inject = ['$q', '$injector', '$window'];

    function AuthInterceptor($q, $injector, $window) {
        var srv = {};

        srv.request = function(config) {

            config.headers = config.headers || {};
           
            return config;
        }

        srv.responseError = function (rejection) {
            var notify = $injector.get('notify');

            if (rejection.status === 400) {

                if (!angular.isUndefined(rejection.data.error_description)) {
                    console.log('inside');
                    notify({
                        message: rejection.data.error_description,
                        classes: 'model-error'
                    });
                    return $q.reject(rejection);
                }

                var html = '<span>';

                angular.forEach(rejection.data.ModelState, function (value, key) {
                    angular.forEach(rejection.data.ModelState[key], function (item) {
                        html += item + '<br/>';
                    });
                });

                html = html + '</span>';

                notify({
                    messageTemplate: html,
                    classes: 'model-error'
                });
            }

            if (rejection.status === 406 || rejection.status === 500) {
                var messageTemplate = '<span>' + rejection.data.Message + '</span>';
                console.log('message', rejection.data.Message);
                notify({
                    messageTemplate: messageTemplate,
                    classes: 'err'
                });
            }

            return $q.reject(rejection);
        }

        return srv;
    };

})();