using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;

namespace Examination.DbModels.Models
{
    public class Answer
    {
        #region Data

        public Guid Id { get; set; }
        public string AnswerText { get; set; }

        public Guid QuestionId { get; set; }
        [DefaultValue(false)]
        public bool? CorrectAnswer { get; set; }
        #endregion

        #region Relations

        [ForeignKey("QuestionId")]
        public virtual Question Question { get; set; }
        #endregion
    }
}