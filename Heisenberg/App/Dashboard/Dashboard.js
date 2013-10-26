var heisenbergApp = angular.module('heisenbergApp', []);

heisenbergApp.controller('DashboardCtrl', function DashboardCtrl($scope, $http) {
    $http.get('App/Dashboard/TeamMembers.json').success(function (data) {
        $scope.teamMembers = data;
    });

    /*$scope.teamMembers = [
      {
          'username': 'MrCochese',
          'name': 'Rick'
      },
      {
          'username': 'GraanJonlo',
          'name': 'Andy'
      },
      {
          'username': 'sichiu',
          'name': 'Si'
      },
      {
          'username': 'lhbt',
          'name': 'Laurent'
      }
    ];*/

    $scope.orderProp = 'name';
});