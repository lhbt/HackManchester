var heisenbergControllers = angular.module('heisenbergControllers', ['heisenbergServices']);

heisenbergControllers.controller('PhoneDetailCtrl', ['$scope', '$routeParams',
  function ($scope, $routeParams) {
      $scope.phoneId = $routeParams.phoneId;
  }]);

var heisenbergApp = angular.module('heisenbergApp', [
  'ngRoute',
  'twitterFilters',
  'heisenbergControllers'
]);

heisenbergApp.config(['$routeProvider',
  function ($routeProvider) {
      $routeProvider.
        when('/dashboard', {
            templateUrl: 'App/Partials/Dashboard.html',
            controller: 'DashboardCtrl'
        }).
          when('/twitter', {
              templateUrl: 'App/Partials/Tweets.html',
              controller: 'TweetsCtrl'
          })
        .otherwise({
            redirectTo: '/dashboard'
        });
  }]);