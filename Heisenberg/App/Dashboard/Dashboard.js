<<<<<<< HEAD
﻿heisenbergControllers.controller('DashboardCtrl',
    ['$scope', 'Commits', 'CommitLanguages', 'BytesOfCode', 'MinutesSinceCommit', 'MostRecentBuildResults',
        function DashboardCtrl($scope, commits, commitLanguages, bytesofCode, minutesSinceCommit, mostRecentBuildResults)
        {
            $scope.commits = commits.query();
            $scope.commitlanguages = commitLanguages.query();
            $scope.bytesofcode = bytesofCode.query();
            $scope.minutessincecommit = minutesSinceCommit.query();
        }
    ]
);
=======
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
>>>>>>> a910fe75f918e79ce9d4e3f11f7f1eac9ab2cf9d
