using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace AdviceLib.Models
{
    public class Departments1
    {
        [Key]
        public int ID { get; set; }
        public string DEPT_NAME { get; set; }
        public int DEPT_ACCESS { get; set; }
    }
}
