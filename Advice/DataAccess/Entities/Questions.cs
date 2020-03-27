using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataAccess.Entities
{
    public class Questions
    {
        public Questions()
        {
            Answers = new HashSet<Answers>();
        }

        [Key]
        public int ID { get; set; }
        public string Question { get; set; }
        public string QuestionType { get; set; }
        public int? Account_ID { get; set; }
        public int Upvotes { get; set; }
        public int Visited { get; set; }

        public virtual Accounts Accounts { get; set; }
        public virtual ICollection<Answers> Answers { get; set; }
    }
}