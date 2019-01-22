var app = angular.module('MyApp', ['ngRoute']);

app.controller('IndexController', function ($scope, $route) { $scope.$route = $route; })

app.config(function ($routeProvider) {
    $routeProvider.
        when('/index', {
        templateUrl: 'index.html',
        controller: 'IndexController'
        }).
        otherwise({
            redirectTo: '/index'
        });
})