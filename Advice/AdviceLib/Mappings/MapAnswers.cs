using System;
using System.Collections.Generic;
using System.Text;
using AdviceLib.Models;

namespace AdviceLib.Mappings
{
    class MapAnswers
    {
        public static Answers1 Map(DataAccess.Entities.Answers AX)
        {
            return new Answers1()
            {
                ID = AX.ID,
                Answers = AX.Answers_,
                Question_ID = AX.Question_ID,
                Account_ID = AX.Account_ID,
                Upvotes = AX.Upvotes,
                Visited = AX.Visited
            };
        }

        public static DataAccess.Entities.Answers Map(Answers1 AX)
        {
            return new DataAccess.Entities.Answers()
            {
                ID = AX.ID,
                Answers_ = AX.Answers,
                Question_ID = AX.Question_ID,
                Account_ID = AX.Account_ID,
                Upvotes = AX.Upvotes,
                Visited = AX.Visited
            };
        }
    }
}
