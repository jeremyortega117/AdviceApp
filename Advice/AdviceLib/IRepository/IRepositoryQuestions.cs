using System;
using System.Collections.Generic;
using System.Text;

namespace AdviceLib.IRepository
{
    public interface IRepositoryQuestions<T>
    {
        IEnumerable<T> ReadInQuestion();
        IEnumerable<T> ReadInQuestion(int id);
        void CreateQuestion(T Question);
        void UpdateQuestion(T Question);
        void DeleteQuestion(int id);
    }
}
