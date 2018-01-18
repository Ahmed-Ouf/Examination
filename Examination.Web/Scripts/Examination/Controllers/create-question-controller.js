examinationModule.controller('CreateQuestionController', function ($scope, createQuestionService,$location) {
    //read 
    $scope.units = createQuestionService.getUnits();
    console.log($scope.units);
    $scope.lessonChane = function (lessonPram) {
        var lesson= JSON.parse(lessonPram);
        $scope.goals = lesson.goals;
        $scope.question.lessonId = lesson.id;
    }
    $scope.options = {
        language: 'en',
        allowedContent: true,
        entities: false
    };
    $scope.onReady = function () {
        // ...
    };
    $scope.question = {};
    $scope.question.answers = [];
    $scope.addPosibleAnswer = function (posibleAnswer) {
        if (posibleAnswer !== '') {
            $scope.question.answers.push({ answerText: posibleAnswer, correctAnswer: false });
            $scope.posibleAnswer = '';
        }
    };

    $scope.updateSelection = function (position, entities) {
        angular.forEach(entities, function(answer, index) {
            if (position !== index)
                answer.correctAnswer = false;
        });
        console.log(entities);
    };
    //save
    $scope.errors = [];
    $scope.saveQuestion = function (question) {
        question.lesson = null;
        $scope.errors.length = 0;
        debugger;
        if (question.lessonId == '' || question.lessonId ==undefined) {
            $scope.errors.push('Please select lesson ');
        }
        if (question.goalId == '' || question.goalId == undefined) {
            $scope.errors.push('Please select Goal ');
        }
        if (question.questionBody == '' || question.questionBody == undefined) {
            $scope.errors.push('Please enter question ');
        }
        if (question.answers.length==0) {
            $scope.errors.push('Please enter Answers ');
        } else {
            var isCorrectAnswer = question.answers.some(function(answer) {
                return answer.correctAnswer == true;
            });
            if (!isCorrectAnswer) {
                $scope.errors.push('Please Check correct answer');
            }
        }

        if (!$scope.errors.length) {
            createQuestionService.save(question).$promise.then(
                function () {
                    $location.url('Examination/Questions');
                },
                function (response) {
                    $scope.errors = response.data;
                }
                );
        }
        
    }
});

