using System;
using System.Collections.Generic;
using System.Text;
using AdviceLib.Models;

namespace AdviceLib.Mappings
{
    public class MapMessages
    {
        public static Messages1 Map(DataAccess.Entities.Messages AX)
        {
            return new Messages1()
            {
                ID = AX.ID,
                CONVERSATION_ID = AX.CONVERSATION_ID,
                DEPT_ID = AX.DEPT_ID,
                ACCOUNT_ID = AX.ACCOUNT_ID,
                DATE_MADE = AX.DATE_MADE,
                MESSAGE = AX.MESSAGE,
                MESSAGE_TYPE = AX.MESSAGE_TYPE,
                TYPE = AX.TYPE,
                FILE_LOCATION = AX.FILE_LOCATION,
                KEYWORDS = AX.KEYWORDS,
                UPVOTES = AX.UPVOTES,
                VIEWS = AX.VIEWS,
                READ_ACCESS = AX.READ_ACCESS,
                WRITE_ACCESS = AX.WRITE_ACCESS
            };
        }

        public static DataAccess.Entities.Messages Map(Messages1 AX)
        {
            return new DataAccess.Entities.Messages()
            {
                ID = AX.ID,
                CONVERSATION_ID = AX.CONVERSATION_ID,
                DEPT_ID = AX.DEPT_ID,
                ACCOUNT_ID = AX.ACCOUNT_ID,
                DATE_MADE = AX.DATE_MADE,
                MESSAGE = AX.MESSAGE,
                MESSAGE_TYPE = AX.MESSAGE_TYPE,
                TYPE = AX.TYPE,
                FILE_LOCATION = AX.FILE_LOCATION,
                KEYWORDS = AX.KEYWORDS,
                UPVOTES = AX.UPVOTES,
                VIEWS = AX.VIEWS,
                READ_ACCESS = AX.READ_ACCESS,
                WRITE_ACCESS = AX.WRITE_ACCESS
            };
        }
    }
}
