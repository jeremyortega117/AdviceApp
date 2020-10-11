using System;
using System.Collections.Generic;
using System.Text;

namespace AdviceLib.IRepository
{
    interface IRepositoryConversations<T>
    {
        IEnumerable<T> ReadInConversations();
        T ReadInConversations(int id);
        void CreateConversations(T Conversations);
        void UpdateConversations(T Conversations);
        void DeleteConversations(int id);
    }
}
