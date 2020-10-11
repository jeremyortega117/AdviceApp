﻿using System;
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
            Conversations = new HashSet<Conversations>();
            Messages = new HashSet<Messages>();
        }
        [Key]
        public int ID { get; set; }
        public int DEPT_NAME { get; set; }
        public int DEPT_ACCESS { get; set; }

        public virtual ICollection<Accounts> Accounts { get; set; }
        public virtual ICollection<Conversations> Conversations { get; set; }
        public virtual ICollection<Messages> Messages { get; set; }
    }
}
