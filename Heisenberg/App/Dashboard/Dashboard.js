heisenbergControllers.controller('DashboardCtrl', ['$scope', 'TeamMember', function DashboardCtrl($scope, TeamMember) {
    $scope.teamMembers = TeamMember.query();
    $scope.orderProp = 'name';

    $scope.update = function() {
        $scope.teamMembers = TeamMember.query();
    };
}]);