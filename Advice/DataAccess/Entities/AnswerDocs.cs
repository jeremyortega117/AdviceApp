using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DataAccess.Entities
{
    class AnswerDocs
    {
        [Key]
        public int ID { get; set; }
        public byte[] AnswerDoc {get; set;}
    }
}
