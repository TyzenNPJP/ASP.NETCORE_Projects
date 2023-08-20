angular.module('AttendanceModule', [])
    .controller('AttendancesController', function ($scope, $http) {

        $scope.courseList = [];
        $scope.LevelList = [];
        $scope.GroupList = [];
        $scope.StudentList = [];
        $scope.StatusList = [];

        $scope.init = function (AttendanceDataList) {
            $scope.Date = new Date();
            $scope.courseList = AttendanceDataList.CourseData;
            $scope.levelList = AttendanceDataList.LevelData;
            $scope.groupList = AttendanceDataList.GroupData;
            var data = [
                { Id: 1, Name: 'Present' },
                { Id: 0, Name: 'Absent' }
            ];
            $scope.StatusList = data;
        }

        $scope.onClickSearchBtn = function () {
            debugger;
            var data = {
                Date: $scope.Date,
                courseId: $scope.CourseId,
                levelId: $scope.LevelId,
                groupId: $scope.GroupId
            }
            $http.post('/attendance/getStudentData', data)
                .then(function (response) {
                    debugger;
                    var data = response.data;
                    $scope.StudentList = [];

                    angular.forEach(data, function (value, key) {
                        var dataObj = {
                            Id: value.id,
                            Name: value.name,
                            CourseId: value.courseId,
                            GroupId: value.groupId,
                            LevelId: value.levelId,
                            Status: $scope.StatusList.filter( x => x.Id == 1)[0],
                            Sn: ++key,
                            StudentId: value.studentId
                        };
                        $scope.StudentList.push(dataObj);
                    });
                    // Handle the response from the server
                })
                .catch(function (error) {
                    // Handle any errors
                });
        }

        $scope.onClickSaveBtn = function () {
            var StudentList = [];

            angular.forEach($scope.StudentList, function (values, key) {
                var data = {
                    StudentId: values.StudentId,
                    Status: valuse.Status.Id
                }
                StudentListObj.push(data);
            });

            var data = {
                Date: $scope.Date,
                CourseId: $scope.CourseId,
                LevelId: $scope.LevelId,
                GroupId: $scope.GroupId,
                StudentDetailData: StudentListObj
            }

            $http.post('/attendance/saveAttendanceData', data)
                .then(function (response) {
                    debugger;
                    var data = response.data;
                    if (data.Status) {
                        alert(data.Message);
                    }
                    // Handle the response from the server
                })
                .catch(function (error) {
                    // Handle any errors
                });
        }
    });