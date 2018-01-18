using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Examination.DbModels.Models;
using Examination.Services;
using Examination.Web.Models;

namespace Examination.Web.Controllers
{
    public class QuestionController : ApiController
    {
        private QuestionsService questionsService=new QuestionsService(); 
        // GET api/values
        public IEnumerable<QuestionViewModel> Get()
        {
            return questionsService.Where(q => true).ToList()
                .Select(q => 
                    new QuestionViewModel {Unit = q.Lesson.Unit.Name,
                        Lesson = q.Lesson.Name,
                        Question = q.QuestionBody,
                        CorrectAnswer = q.CorrectAnswer.AnswerText
                    });

        }

        // GET api/values/5
        public Question Get(Guid id)
        {
            return questionsService.GetById(id);
        }

        // POST api/values
        public HttpResponseMessage Post(HttpRequestMessage request, [FromBody]Question value)
        {
            if (ModelState.IsValid)
            {
                questionsService.Add(value);
                return new HttpResponseMessage(HttpStatusCode.OK);
            }
            return request.CreateResponse(HttpStatusCode.BadRequest, GetErrorMessages());
        }

        private IEnumerable<string> GetErrorMessages()
        {
            return ModelState.Values.SelectMany(x => x.Errors.Select(e => e.ErrorMessage));
        }
        // PUT api/values/5
        public void Put(int id, [FromBody]Question value)
        {
        }

        // DELETE api/values/5
        public void Delete(int id)
        {
        }
    }
}
