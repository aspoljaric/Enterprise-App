var app = angular.module('studentModule', []);

app.controller('studentCtrl', function ($scope, $http, StudentService) {

    $scope.studentData = null;
    StudentService.GetAllRecords().then(function (d) {
        $scope.studentData = d.data;
    }, function () {
    });

    $scope.Student = {
        Id: '',
        FirstName: '',
        LastName: '',
        DateOfBirth: '',
        Email: '',
        Telephone: '',
        MobilePhone: ''
    };

    $scope.clear = function () {
        $scope.Student.Id = '';
        $scope.Student.FirstName = '';
        $scope.Student.LastName = '';
        $scope.Student.DateOfBirth = '';
        $scope.Student.Email = '';
        $scope.Student.Telephone = '';
        $scope.Student.MobilePhone = '';
    }

    $scope.save = function () {
     
            $http({
                method: 'POST',
                url: 'api/Student/Post/',
                data: $scope.Student
            }).then(function successCallback(response) {
                $scope.studentData.push(response.data);
                $scope.clear();
            }, function errorCallback(response) {
                alert("Error : " + response.data.ExceptionMessage);
            });
     
    };

    // Edit
    $scope.edit = function (data) {
        $scope.Student = { Id: data.Id, FirstName: data.FirstName, LastName: data.LastName, DateOfBirth: data.DateOfBirth, Email: data.Email, Telephone: data.Telephone, MobilePhone: data.MobilePhone };
    }

    // Cancel
    $scope.cancel = function () {
        $scope.clear();
    }

    // Update
    $scope.update = function () {
       
            $http({
                method: 'PUT',
                url: 'api/Student/Put/' + $scope.Student.Id,
                data: $scope.Student
            }).then(function successCallback(response) {
                $scope.studentData = response.data;
                $scope.clear();
            }, function errorCallback(response) {
                alert("Error : " + response.data.ExceptionMessage);
            });
      
    };

    // Delete
    $scope.delete = function (index) {
        $http({
            method: 'DELETE',
            url: 'api/student/Delete/' + $scope.studentData[index].Id,
        }).then(function successCallback(response) {
            $scope.studentData.splice(index, 1);
        }, function errorCallback(response) {
            alert("Error : " + response.data.ExceptionMessage);
        });
    };

});


app.factory('StudentService', function ($http) {
    var fac = {};
    fac.GetAllRecords = function () {
        return $http.get('api/Student/Get');
    }
    return fac;
});