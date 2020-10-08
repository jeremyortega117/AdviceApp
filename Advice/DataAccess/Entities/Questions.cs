using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataAccess.Entities
{
    public class Questions
    {
        /// <summary>
        /// Questions should know their type of question as well as the answer. 
        /// It would be nice to have some statistics of how many times the question was viewed and the number of upvotes it has.
        /// </summary>
        [Key]
        public int ID { get; set; }
        public string Question { get; set; }
        public string QuestionType { get; set; }
        public int Answer_ID { get; set; }
        public int Upvotes { get; set; }
        public int Visited { get; set; }
    }
}