using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Examination.DbModels.Models
{
    public class Lesson
    {
        #region Data
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }
        public string Name { get; set; }

        public Guid UnitId { get; set; }
        #endregion
        
        #region Relations
        [ForeignKey("UnitId")]
        public virtual Unit Unit { get; set; }

        public virtual ICollection<Question> Questions { get; set; }
        public virtual ICollection<Goal> Goals { get; set; }
        
        #endregion

        
    }
}