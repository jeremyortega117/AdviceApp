using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace DataAccess.Entities
{
    public class Answers
    {
        [Key]
        public int ID { get; set; }
        public string Answers_ { get; set; }
        public int? Question_ID { get; set; }
        public int? Account_ID { get; set; }
        public int Upvotes { get; set; }
        public int Visited { get; set; }

        public virtual Questions Questions { get; set; }
        public virtual Accounts Accounts{ get; set; }
    }
}
