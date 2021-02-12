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
    /// <summary>
    /// This Repository Handles the Business Rules and error handling of data before sending to and retriving data
    /// from the database.
    /// </summary>
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

        /// <summary>
        /// Read In all conversations.  This may primarily be useful for auditing purposes.
        /// </summary>
        /// <returns></returns>
        public IEnumerable<Conversations1> ReadInConversations()
        {
            var getCx = from cx in ADC.Conversations
                        select MapConversations.Map(cx);
            return getCx;
        }


        /// <summary>
        /// Read in all conversations associated with that user id.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public IEnumerable<Conversations1> ReadInConversationsByAccountID(int id)
        {
            var getCx = from cx in ADC.Conversations
                        where cx.ACCOUNT_ID == id
                        select MapConversations.Map(cx);
            return getCx;
        }

        /// <summary>
        /// Read in all conversations associated with that DEPTID.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public IEnumerable<Conversations1> ReadInConversationByConversationID(int id)
        {
            var getCx = from cx in ADC.Conversations
                        where cx.ID == id
                        select MapConversations.Map(cx);
            return getCx;
        }

        /// <summary>
        /// Check Access level of user and allow that user to only see messages with that level of access.
        /// </summary>
        /// <param name="ConvType"></param>
        /// <param name="username"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        public IEnumerable<Conversations1> ReadInConversationByConversationType(
            int ConvType,
            string username,
            string password
            )
        {
            var user = ADC.Accounts.FirstOrDefault(e => e.USERNAME == username && e.PASSWORD == password);

            if(user == null)
            {
                Console.WriteLine($"Cx with username and password combination doesn't exist");
                return null;
            }

            var getCx = from cx in ADC.Conversations
                        where cx.CONVERSATION_TYPE == ConvType
                        where cx.ACCESS_LEVEL <= user.ACCESS_LEVEL
                        select MapConversations.Map(cx);
            return getCx;
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="Conversation"></param>
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

        public void DeleteConversationByID(int id)
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
    }
}
