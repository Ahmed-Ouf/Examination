using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Examination.DbModels.Models
{
    public class Unit
    {
        #region Data
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }

        public string Name { get; set; }

        #endregion
        #region Relation
        public virtual ICollection<Lesson> Lessons { get; set; }
        
        #endregion        
    }
}