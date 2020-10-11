using AdviceLib.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace AdviceLib.Mappings
{
    public class MapAccount
    {
        public static Accounts1 Map(DataAccess.Entities.Accounts AX)
        {
            return new Accounts1()
            {
                ID = AX.ID,
                FNAME = AX.FNAME,
                LNAME = AX.LNAME,
                PASSWORD = AX.PASSWORD,
                ACCESS_LEVEL = AX.ACCESS_LEVEL,
                EMAIL = AX.EMAIL,
                PHONE = AX.PHONE,
                USERNAME = AX.USERNAME,
                DEPT_ID = AX.DEPT_ID
            };
        }

        public static DataAccess.Entities.Accounts Map(Accounts1 AX)
        {
            return new DataAccess.Entities.Accounts()
            {
                ID = AX.ID,
                FNAME = AX.FNAME,
                LNAME = AX.LNAME,
                PASSWORD = AX.PASSWORD,
                ACCESS_LEVEL = AX.ACCESS_LEVEL,
                EMAIL = AX.EMAIL,
                PHONE = AX.PHONE,
                USERNAME = AX.USERNAME,
                DEPT_ID = AX.DEPT_ID
            };
        }
    }
}
