using System;
using System.Collections.Generic;
using System.Text;
using DataAccess.Entities;

namespace AdviceLib.IRepository
{
    public interface IRepositoryAccounts<T>
    {
        IEnumerable<T> ReadInAccounts();
        T ReadInAccounts(int id);
        void CreateAccounts(T Accounts);
        void UpdateAccounts(T Accounts);
        void DeleteAccounts(int id);
    }
}
