examinationModule.controller('QuestionsController', function ($scope,questionsService) {
    $scope.questionList = questionsService.get();
    console.log($scope.questionList);
});