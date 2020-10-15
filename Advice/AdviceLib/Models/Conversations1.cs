using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace AdviceLib.Models
{
    public class Conversations1
    {
        [Key]
        public int ID { get; set; }
        public int? ACCOUNT_ID { get; set; }
        public int CONVERSATION_TYPE { get; set; }
        public int ACCESS_LEVEL { get; set; }
    }
}
