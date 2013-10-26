var heisenbergServices = angular.module('heisenbergServices', ['ngResource']);

heisenbergServices.factory('TeamMember', ['$resource',
  function ($resource) {
      return $resource('api/teammembers/GetAll', {}, {
          query: { method: 'GET', params: {}, isArray: true }
      });
  }]);

heisenbergServices.factory('Tweets', ['$resource',
  function ($resource) {
      return $resource('api/twitterhashtag/get', {}, {
          query: { method: 'GET', params: {}, isArray: true }
      });
  }]);