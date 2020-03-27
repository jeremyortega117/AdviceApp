using System;
using System.Collections.Generic;
using System.Text;
using DataAccess.Entities;

namespace AdviceLib.IRepository
{
    public interface IRepositoryAnswers<T>
    {
        IEnumerable<T> ReadInAnswers();
        IEnumerable<T> ReadInAnswers(int id);
        void CreateAnswers(T Answers);
        void UpdateAnswers(T Answers);
        void DeleteAnswers(int id);
    }
}
