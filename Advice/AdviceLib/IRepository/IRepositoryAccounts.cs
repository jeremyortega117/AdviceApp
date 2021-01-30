using System;
using System.Collections.Generic;
using System.Text;
using DataAccess.Entities;

namespace AdviceLib.IRepository
{
    public interface IRepositoryAccounts<T>
    {
        IEnumerable<T> ReadInAccounts();
        T ReadInAccount(int id);
        T ReadInAccountsByDepartments(int id);
        void CreateAccount(T Accounts);
        void UpdateAccount(T Accounts);
        void DeleteAccount(int id);
    }
}
