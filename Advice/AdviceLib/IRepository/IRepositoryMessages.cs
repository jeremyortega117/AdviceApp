using System;
using System.Collections.Generic;
using System.Text;

namespace AdviceLib.IRepository
{
    public interface IRepositoryMessages<T>
    {
        IEnumerable<T> ReadInMessages();
        T ReadInMessages(int id);
        void CreateMessages(T Messages);
        void UpdateMessages(T Messages);
        void DeleteMessages(int id);
    }
}
