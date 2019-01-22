app.controller('IndexController', function ($scope, $http) {
    $scope.upload = function () {
        var fd = new FormData();
        var file = document.querySelector('input[type=file]').files[0];
        fd.append('logo', file);
        $http({
            method: 'POST',
            url: '/api/index/upload',
            data: fd,
            headers: { 'Content-Type': undefined },
            transformRequest: angular.identity 
        }, function (data) {
            });
    }
    //$scope.fileChange = function () {
    //    $scope.uploadfile = document.querySelector('input[type=file]').files[0];
    //}
})