using System;
using System.Collections.Generic;
using System.Text;
using DataAccess.Entities;

namespace AdviceLib.IRepository
{
    public interface IRepositoryAccounts<T>
    {
        void CreateAccount(T Accounts);
        IEnumerable<T> ReadInAccounts();
        T ReadInAccountByID(int id);
        IEnumerable<T> ReadInAccountsByDEPTID(int id);
        void UpdateAccount(T Accounts);
        void DeleteAccountByID(int id);
    }
}
