using AdviceLib.IRepository;
using AdviceLib.Mappings;
using AdviceLib.Models;
using DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AdviceLib.Repositories
{
    public class RepositoryConversations : IRepositoryConversations<Conversations1>
    {
        AdviceDbContext ADC;

        public RepositoryConversations()
        {
            ADC = new AdviceDbContext();
        }
        public RepositoryConversations(AdviceDbContext AD)
        {
            ADC = AD ?? throw new ArgumentNullException(nameof(AD));
        }

        public void CreateConversation(Conversations1 Conversation)
        {
            ADC.Conversations.Add(MapConversations.Map(Conversation));// this will generate insertMapper.Map(Conversations)
            ADC.SaveChanges();// this will execute the above generate insert query
        }

        public void DeleteConversation(int id)
        {
            var Cus = ADC.Conversations.FirstOrDefault(Cx => Cx.ID == id);
            if (Cus.ID == id)
            {
                ADC.Remove(Cus);
                ADC.SaveChanges();
            }
            else
            {
                Console.WriteLine($"Cx with id {id} doesn't exist");
                return;
            }
        }

        public IEnumerable<Conversations1> ReadInConversations()
        {
            var getCx = from cx in ADC.Conversations
                        select MapConversations.Map(cx);
            return getCx;
        }

        public Conversations1 ReadInConversation(int id)
        {
            var getCx = ADC.Conversations.FirstOrDefault(e => e.ID == id);
            return MapConversations.Map(getCx);
        }

        public void UpdateConversation(Conversations1 Conversation)
        {
            if (ADC.Conversations.Any(Cx => Cx.ID == Conversation.ID))
            {
                var Conv = ADC.Conversations.FirstOrDefault(Cx => Cx.ID == Conversation.ID);
                Conv.CONVERSATION_TYPE = Conversation.CONVERSATION_TYPE;
                Conv.ACCESS_LEVEL = Conversation.ACCESS_LEVEL;
                ADC.Conversations.Update(Conv);
                ADC.SaveChanges();
            }
        }
    }
}
