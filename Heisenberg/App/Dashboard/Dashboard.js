heisenbergControllers.controller('DashboardCtrl', ['$scope', 'TeamMember', 'Tweets', function DashboardCtrl($scope, TeamMember, Tweets) {
    $scope.teamMembers = TeamMember.query();
    $scope.orderProp = 'name';
    $scope.tweets = Tweets.query();

    $scope.update = function() {
        $scope.teamMembers = TeamMember.query();
        $scope.tweets = Tweets.query();
    };
}]);