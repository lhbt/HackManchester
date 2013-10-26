heisenbergControllers.controller('TweetsCtrl', ['$scope', 'Tweets', function TweetsCtrl($scope, Tweets) {
    $scope.tweets = Tweets.query();
}]);