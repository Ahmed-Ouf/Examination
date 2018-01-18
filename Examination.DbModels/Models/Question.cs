using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Core.Common.CommandTrees;
using System.Linq;

namespace Examination.DbModels.Models
{
    public class Question
    {
        #region Data
        public Guid Id { get; set; }
        [Required(ErrorMessage = "Please enter the Question ")]
        public string QuestionBody { get; set; }
        [Required(ErrorMessage = "Please Selsect Lesson ")]
        public Guid LessonId { get; set; }
        [Required(ErrorMessage = "Please Select Goal of Question  ")]
        public Guid GoalId { get; set; }
        #endregion

        #region Relations
        [ForeignKey("LessonId")]
        public virtual Lesson Lesson { get; set; }

        [ForeignKey("GoalId")]
        public virtual Goal Goal { get; set; }

        public virtual ICollection<Answer> Answers { get; set; }

        public Answer CorrectAnswer {
            get
            {
                if (Answers!=null && Answers.Any())
                {
                    return Answers.FirstOrDefault(q => q.CorrectAnswer==true);
                }
                return null;
            } 
        } 

        #endregion
    }
}