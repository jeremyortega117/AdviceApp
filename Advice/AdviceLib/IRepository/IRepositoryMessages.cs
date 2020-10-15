using System;
using System.Collections.Generic;
using System.Text;

namespace AdviceLib.IRepository
{
    public interface IRepositoryMessages<T>
    {
        IEnumerable<T> ReadInMessages();
        T ReadInMessage(int id);
        void CreateMessage(T Messages);
        void UpdateMessage(T Messages);
        void DeleteMessage(int id);
    }
}
