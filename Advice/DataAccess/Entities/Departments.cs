using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DataAccess.Entities
{
    public class Departments
    {

        public Departments()
        {
            Accounts = new HashSet<Accounts>();
            //Messages = new HashSet<Messages>();
        }
        [Key]
        public int ID { get; set; }
        public string DEPT_NAME { get; set; }
        public int DEPT_ACCESS { get; set; }

        public virtual ICollection<Accounts> Accounts { get; set; }
        //public virtual ICollection<Messages> Messages { get; set; }
    }
}

