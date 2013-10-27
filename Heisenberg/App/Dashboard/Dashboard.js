heisenbergControllers.controller('DashboardCtrl', ['$scope', 'TeamMember', 'Tweets', function DashboardCtrl($scope, TeamMember, Tweets) {
    $scope.teamMembers = TeamMember.query();
    $scope.orderProp = 'name';
    $scope.tweets = Tweets.query();

    //$scope.onTimeout = function() {
        //$scope.teamMembers = TeamMember.query();
        //$scope.tweets = Tweets.query();
        //mytimeout = $timeout($scope.onTimeout, 20000);
    //};
    //var mytimeout = $timeout($scope.onTimeout, 20000);

    $scope.update = function() {
        $scope.teamMembers = TeamMember.query();
        $scope.tweets = Tweets.query();
    };
}]);