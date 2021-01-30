using System;
using System.Collections.Generic;
using System.Text;

namespace AdviceLib.IRepository
{
    public interface IRepositoryConversations<T>
    {
        IEnumerable<T> ReadInConversations();
        T ReadInConversationByAccountID(int id);
        T ReadInConversationByDeptID(int id);
        void CreateConversation(T Conversations);
        void UpdateConversation(T Conversations);
        void DeleteConversation(int id);
    }
}
