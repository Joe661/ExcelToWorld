app.controller('IndexController', function ($scope, $http) {
    $scope.btnDown = false;
    $scope.uploadFilePath = "";
    $scope.percents = 0;//文件上传转换总进度百分比
    $scope.guid = "";//百分比session key
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
                console.log(data);
                if (data.success == true) {
                    $scope.uploadFilePath = data.obj;
                    $scope.percents = data.rows[0].percent;
                    $scope.guid = data.rows[0].guid;
                    $scope.btnDown = true;//显示下载按钮
                    $scope.percentProccess();
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

    $scope.percentProccess = function () {
        var fd = new FormData();
        fd.append('guid', $scope.guid);
        $http({
            method: 'POST',
            url: '/api/index/querypercent',
            data: $scope.guid,
            params: { guid: $scope.guid },
            transformRequest: angular.identity
        }).then(function (response) {
            if (response.status == 200) {
                var data = response.data;
                if (data.success == true) {

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

    $scope.download = function () {
        location.href = $scope.uploadFilePath;
    }

    //$scope.transform = function () {
    //    var fd = new FormData();
    //    fd.append('url', $scope.uploadFilePath);
    //    $http({
    //        method: 'POST',
    //        url: '/api/index/transform',
    //        data: fd,
    //        headers: { 'Content-Type': undefined},
    //        transformRequest: angular.identity
    //    }).then(function (response) {
    //        if (response.status == 200) {
    //            layer.msg("请求失败，错误代码:" + response.status + ";" + response.statusText);
    //        }
    //        else {
    //            layer.msg("请求失败，错误代码:" + response.status + ";" + response.statusText);
    //        }
    //    }, function errorCallback(response) {
    //        layer.msg("系统异常");
    //    })
    //}
})