using AdviceLib.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace AdviceLib.Mappings
{
    public class MapDepartments
    {
        public static Departments1 Map(DataAccess.Entities.Departments AX)
        {
            return new Departments1()
            {
                ID = AX.ID,
                DEPT_NAME = AX.DEPT_NAME,
                DEPT_ACCESS = AX.DEPT_ACCESS
            };
        }

        public static DataAccess.Entities.Departments Map(Departments1 AX)
        {
            return new DataAccess.Entities.Departments()
            {
                ID = AX.ID,
                DEPT_NAME = AX.DEPT_NAME,
                DEPT_ACCESS = AX.DEPT_ACCESS
            };
        }
    }
}
