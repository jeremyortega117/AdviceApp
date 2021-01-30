using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace AdviceLib.Models
{
    public class Accounts1
    {
        [Key]
        public int ID { get; set; }
        public string FNAME { get; set; }
        public string LNAME { get; set; }
        public string PASSWORD { get; set; }
        public int ACCESS_LEVEL { get; set; }
        public string EMAIL { get; set; }
        public string PHONE { get; set; }
        public string USERNAME { get; set; }
        public int? DEPT_ID { get; set; }
    }
}
  