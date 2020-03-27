using System;
using System.Collections.Generic;
using System.Text;
using AdviceLib.Models;

namespace AdviceLib.Mappings
{
    class MapQuestions
    {
        public static Questions1 Map(DataAccess.Entities.Questions AX)
        {
            return new Questions1()
            {
                ID = AX.ID,
                QuestionType = AX.QuestionType,
                Question = AX.Question,
                Account_ID = AX.Account_ID,
                Upvotes = AX.Upvotes,
                Visited = AX.Visited
            };
        }

        public static DataAccess.Entities.Questions Map(Questions1 AX)
        {
            return new DataAccess.Entities.Questions()
            {
                ID = AX.ID,
                QuestionType = AX.QuestionType,
                Question = AX.Question,
                Account_ID = AX.Account_ID,
                Upvotes = AX.Upvotes,
                Visited = AX.Visited
            };
        }
    }
}
