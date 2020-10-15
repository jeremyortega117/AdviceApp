using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DataAccess.Entities
{
    public class Accounts
    {
        /// <summary>
        /// We need to instantiate the HashSets used to represent the "HasOne" "ToMany" relationship.
        /// </summary>
        //public Accounts()
        //{
        //    Conversations = new HashSet<Conversations>();
        //    Messages = new HashSet<Messages>();

        //}

        /// <summary>
        /// Primary Key Annotation
        /// </summary>
        [Key]
        public int ID { get; set; }
        public string FNAME { get; set; }
        public string LNAME { get; set; }
        public string PASSWORD { get; set; }
        public int ACCESS_LEVEL { get; set; }
        public string EMAIL { get; set; }
        public string PHONE { get; set; }
        public string USERNAME { get; set; }
        public int DEPT_ID { get; set; }

        /// <summary>
        /// Represents other table's foreign keys to this table, that also represent a 
        /// "HasOne" (Account)
        /// "ToMany" (Conversations)
        /// relationship
        /// </summary>
        //public virtual ICollection<Conversations> Conversations { get; set; }
        //public virtual ICollection<Messages> Messages { get; set; }

        ///// <summary>
        ///// Represents this table's foreign key to the Department Table's ID. 
        ///// </summary>
        //public virtual Departments Departments { get; set; }
    }
}
