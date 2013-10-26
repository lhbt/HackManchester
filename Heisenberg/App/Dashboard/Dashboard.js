var heisenbergApp = angular.module('heisenbergApp', []);

heisenbergApp.controller('DashboardCtrl', function DashboardCtrl($scope) {
    $scope.teamMembers = [
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
    ];

    $scope.orderProp = 'name';
});