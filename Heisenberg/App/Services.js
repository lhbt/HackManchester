var heisenbergServices = angular.module('heisenbergServices', ['ngResource']);

heisenbergServices.factory('TeamMember', ['$resource',
  function ($resource) {
      return $resource('api/teammembers/GetAll', {}, {
          query: { method: 'GET', params: {}, isArray: true }
      });
  }]);