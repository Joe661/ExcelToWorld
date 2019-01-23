app.controller('IndexController', function ($scope, $http) {
    $scope.btnUpload = true;
    $scope.uploadFilePath = "";
    $scope.upload = function () {
        var fd = new FormData();
        var file = document.querySelector('input[type=file]').files[0];
        $scope.uploadfile = file.name;
        fd.append('logo', file);
        $http({
            method: 'POST',
            url: '/api/index/upload',
            data: fd,
            headers: { 'Content-Type': undefined },
            transformRequest: angular.identity
        }).then(function (response) {
            if (response.status == 200) {
                var data = response.data;
                if (data.success == true) {
                    $scope.uploadFilePath = data.obj;
                    $scope.btnUpload = false;//显示转换按钮
                }
                else {
                    layer.msg(data.message);
                }
            }
            else {
                layer.msg("请求失败，错误代码:" + response.status + ";" + response.statusText);
            }
        });
    }

    $scope.transform = function () {
        $http({
            method: 'POST',
            url: '/api/index/transform',
            data: $scope.uploadFilePath
        }).then(function (response) {
            if (response.status == 200) {
                layer.msg("请求失败，错误代码:" + response.status + ";" + response.statusText);
            }
            else {
                layer.msg("请求失败，错误代码:" + response.status + ";" + response.statusText);
            }
        }, function errorCallback(response) {
            layer.msg("系统异常");
        })
    }
})