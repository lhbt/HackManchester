heisenbergControllers.controller('BuildCtrl', ['$scope', 'Build', function BuildCtrl($scope, Build) {
    $scope.mostrecentbuildresults = Build.query();
}]);