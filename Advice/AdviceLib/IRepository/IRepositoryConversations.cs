using System;
using System.Collections.Generic;
using System.Text;

namespace AdviceLib.IRepository
{
    public interface IRepositoryConversations<T>
    {
        void CreateConversation(T Conversation);
        IEnumerable<T> ReadInConversations();
        IEnumerable<T> ReadInConversationsByAccountID(int id);
        IEnumerable<T> ReadInConversationByConversationID(int id);
        void UpdateConversation(T Conversation);
        void DeleteConversationByID(int id);
    }
}
