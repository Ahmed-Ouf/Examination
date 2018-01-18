examinationModule.factory('createQuestionService', function($resource) {
    return {
        save: function(entiy) {
           return  $resource('/api/Question').save(entiy);
        },
        getUnits: function() {
            return $resource('api/Units').query();
        }
    }
})