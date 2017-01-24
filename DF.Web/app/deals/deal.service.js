
(function () {
    'use strict';

    angular
        .module('deals.module')
        .factory('DealService', DealService);

    DealService.$inject = ['$resource', '$http', 'Settings'];

    function DealService($resource, $http, Settings) {
        var srv = {};

        srv.dealsByCategory = function (category) {
            var url = Settings.ApiUrl + 'deals/category/' + category;
            return $http.get(url);
        };

        srv.dealsBySlug = function (slug) {
            var url = Settings.ApiUrl + 'deals/' + slug;
            return $http.get(url);
        };

        srv.dealsByPartner = function (partner) {
            var url = Settings.ApiUrl + 'deals/partners/' + partner;
            return $http.get(url);
        };


        

        return srv;
    };

})();

