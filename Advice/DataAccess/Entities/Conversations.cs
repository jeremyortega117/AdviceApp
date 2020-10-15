using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DataAccess.Entities
{
    public class Conversations
    {
        //public Conversations()
        //{
        //    Messages = new HashSet<Messages>();
        //}
        [Key]
        public int ID { get; set; }
        public int? ACCOUNT_ID { get; set; }        
        public int CONVERSATION_TYPE { get; set; }
        public int ACCESS_LEVEL { get; set; }

        //public virtual ICollection<Messages> Messages { get; set; }

        public Accounts Accounts { get; set; }

    }
}
