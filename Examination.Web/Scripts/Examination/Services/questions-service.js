examinationModule.factory('questionsService', function ($resource) {
    return {
        get: function () {
            return $resource('/api/Question').query();
        }
    }
});