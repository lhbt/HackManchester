﻿heisenbergControllers.controller('DashboardCtrl', ['$scope', 'TeamMember', 'Tweets', 'Commits', 'CommitLanguages', 'BytesOfCode', 'MinutesSinceCommit', 'MostRecentBuildResults', function DashboardCtrl($scope, TeamMember, Tweets, commits, CommitLanguages, bytesofCode, minutesSinceCommit, mostRecentBuildResults) {
    $scope.teamMembers = TeamMember.query();
    $scope.orderProp = 'name';

    $scope.commits = commits.query();

    $scope.commitlanguages = CommitLanguages.query;
    $scope.bytesofcode = bytesofCode.query;
    $scope.minutessincecommit = minutesSinceCommit.query;
    $scope.mostrecentbuildresults = mostRecentBuildResults.query;

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