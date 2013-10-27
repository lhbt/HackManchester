heisenbergControllers.controller('DashboardCtrl',
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