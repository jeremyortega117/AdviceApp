using System;
using System.Collections.Generic;
using System.Text;

namespace AdviceLib.Models
{
    public class Answers1
    {
        public int ID { get; set; }
        public string Answers { get; set; }
        public int? Question_ID { get; set; }
        public int? Account_ID { get; set; }
        public int Upvotes { get; set; }
        public int Visited { get; set; }
    }
}
