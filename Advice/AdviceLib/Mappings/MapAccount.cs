using AdviceLib.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace AdviceLib.Mappings
{
    class MapAccount
    {
        public static Accounts1 Map(DataAccess.Entities.Accounts AX)
        {
            return new Accounts1()
            {
                ID = AX.ID,
                Email = AX.Email,
                Username = AX.Username,
                Password = AX.Password
            };
        }

        public static DataAccess.Entities.Accounts Map(Accounts1 AX)
        {
            return new DataAccess.Entities.Accounts()
            {
                ID = AX.ID,
                Email = AX.Email,
                Username = AX.Username,
                Password = AX.Password
            };
        }
    }
}
