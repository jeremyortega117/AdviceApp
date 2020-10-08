using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace DataAccess.Entities
{
    public class Answers
    {
        /// <summary>
        /// An Answer should be aware of the answer including any supporting documents.
        /// It would be nice to have upvotes and visited columns for statistical analysis.
        /// </summary>
        [Key]
        public int ID { get; set; }
        public string Answer { get; set; }
        public int? AnswerDocID { get; set; }
        public int Upvotes { get; set; }
        public int Visited { get; set; }
        public int AnswerDocs { get; set; }
    }
}
