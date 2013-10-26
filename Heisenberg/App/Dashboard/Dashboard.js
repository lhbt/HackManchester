heisenbergControllers.controller('DashboardCtrl', function DashboardCtrl($scope, $http) {
    $http.get('App/Dashboard/TeamMembers.json').success(function (data) {
        $scope.teamMembers = data;
    });

    $scope.orderProp = 'name';
});