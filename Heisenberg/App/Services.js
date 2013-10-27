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

heisenbergServices.factory('Commits', ['$commits',
    function($resource) {
        return $resource('api/sourcecontrol/commits', {}, {
           query: { method: 'GET', params: {}, isArray: true } 
        });
    }]);

heisenbergServices.factory('CommitLanguages', ['$languages',
    function ($resource) {
        return $resource('api/sourcecontrol/languagesused', {}, {
            query: { method: 'GET', params: {}, isArray: true }
        });
    }]);

heisenbergServices.factory('BytesOfCode', ['$bytesofcode',
    function ($resource) {
        return $resource('api/sourcecontrol/bytesofcode', {}, {
            query: { method: 'GET', params: {}, isArray: false }
        });
    }]);

heisenbergServices.factory('MinutesSinceCommit', ['$minutesincelastcommit',
    function ($resource) {
        return $resource('api/sourcecontrol/minutessincelastcommit', {}, {
            query: { method: 'GET', params: {}, isArray: false }
        });
    }]);

heisenbergServices.factory('MostRecentBuildResults', ['mostrecentbuildresults',
    function ($resource) {
        return $resource('api/notifications/mostrecentbuildresults', {}, {
            query: { method: 'GET', params: {}, isArray: false }
        });
    }]);