using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Examination.DbModels.Models
{
    public class Goal
    {
        #region Data
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }
        public string GoalText { get; set; }
        public Guid LessonId { get; set; }

        #endregion

        #region Relations
        [ForeignKey("LessonId")]
        public virtual Lesson Lesson { get; set; }

        public virtual ICollection<Question> Questions { get; set; }

        #endregion
    }
}