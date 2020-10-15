using System;
using System.Collections.Generic;
using System.Text;
using AdviceLib.Models;

namespace AdviceLib.Mappings
{
    public class MapConversations
    {
        public static Conversations1 Map(DataAccess.Entities.Conversations AX)
        {
            return new Conversations1()
            {
                ID = AX.ID,
                ACCOUNT_ID = AX.ACCOUNT_ID,
                CONVERSATION_TYPE = AX.CONVERSATION_TYPE,
                DEPT_ID = AX.DEPT_ID,
                ACCESS_LEVEL = AX.ACCESS_LEVEL
            };
        }

        public static DataAccess.Entities.Conversations Map(Conversations1 AX)
        {
            return new DataAccess.Entities.Conversations()
            {
                ID = AX.ID,
                ACCOUNT_ID = AX.ACCOUNT_ID,
                CONVERSATION_TYPE = AX.CONVERSATION_TYPE,
                DEPT_ID = AX.DEPT_ID,
                ACCESS_LEVEL = AX.ACCESS_LEVEL
            };
        }
    }
}
