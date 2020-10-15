using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DataAccess.Entities
{
    public class Messages
    {

        //public Messages()
        //{
        //}

        [Key]
        public int ID { get; set; }
        public int CONVERSATION_ID { get; set; }
        public int DEPT_ID { get; set; }
        public int ACCOUNT_ID { get; set; }
        public DateTime DATE_MADE{ get; set; }
        public byte[] MESSAGE { get; set; }
        public string MESSAGE_TYPE { get; set; }
        public string TYPE { get; set; }
        public string FILE_LOCATION { get; set; }
        public string KEYWORDS { get; set; }
        public int UPVOTES { get; set; }
        public int VIEWS { get; set; }
        public int READ_ACCESS { get; set; }
        public int WRITE_ACCESS { get; set; }

        public Conversations Conversations { get; set; }
        public Departments Departments { get; set; }
        public Accounts Accounts { get; set; }

    }
}
