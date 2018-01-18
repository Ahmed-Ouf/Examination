/// <reference path="../angular-1.6.6/angular.js" />
var examinationModule = angular.module("ExaminationModule", ['ngRoute', 'ngResource', 'ckeditor'])
    .config(function ($routeProvider, $locationProvider) {
        $routeProvider
            .when('/Examination/Questions', {
                templateUrl: 'Templates/questions.html',
                controller: 'QuestionsController'
            })
            .when('/Examination/CreateQuestion', {
                templateUrl: 'Templates/create-question.html',
                controller: 'CreateQuestionController'
            })
            .otherwise({
                redirectTo: '/Examination'
            });
    $locationProvider.html5Mode(true);
});
