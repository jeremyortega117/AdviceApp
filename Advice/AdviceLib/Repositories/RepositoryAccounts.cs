using AdviceLib.IRepository;
using AdviceLib.Models;
using DataAccess;
using DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AdviceLib.Repositories
{
    public class RepositoryAccounts : IRepositoryAccounts<Accounts1>
    {
        private AdviceDbContext ADC;

        public RepositoryAccounts()
        {
            ADC = new AdviceDbContext();
        }
        public RepositoryAccounts(AdviceDbContext AD)
        {
            ADC = AD ?? throw new ArgumentNullException(nameof(AD));
        }

        public void CreateAccounts(Accounts1 accounts)
        {
            if (ADC.Accounts.Any((System.Linq.Expressions.Expression<Func<DataAccess.Entities.Accounts, bool>>)(c => c.Email == accounts.Email)) || accounts.Email == null)
            {
                Console.WriteLine($"This account with email {accounts.Email} already exists and cannot be added");
                return;
            }
            else
                ADC.Accounts.Add(Mappings.MapAccount.Map(accounts));
            ADC.SaveChanges();
        }

        public void DeleteAccounts(int id)
        {
            var Cus = ADC.Accounts.FirstOrDefault(Cx => Cx.ID == id);
            if (Cus.ID == id)
            {
                ADC.Remove(Cus);
                ADC.SaveChanges();
            }
            else
            {
                Console.WriteLine($"Cx with id {id} doesn't exist");
                return;
            }
        }

        /// <summary>
        /// return all accounts from repository call.
        /// </summary>
        /// <returns></returns>
        public IEnumerable<Accounts1> ReadInAccounts()
        {
            var getAx = from ax in ADC.Accounts
                        select Mappings.MapAccount.Map(ax);

            return getAx;
        }

        /// <summary>
        /// return single account from repostory with matching id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Accounts1 ReadInAccounts(int id)
        {
            var a = ADC.Accounts.FirstOrDefault(a => a.ID == id);
            if (a != null)
            {
                return Mappings.MapAccount.Map(a);
            }
            return null;
        }


        public void UpdateAccounts(Accounts1 Accounts)
        {
            if (ADC.Accounts.Any(Cx => Cx.ID == Accounts.ID))
            {
                var Cus = ADC.Accounts.FirstOrDefault((Cx => Cx.ID == Accounts.ID));
                Cus.USERNAME = Accounts.USERNAME;
                Cus.EMAIL = Accounts.EMAIL;
                Cus.FNAME = Accounts.FNAME;
                Cus.LNAME = Accounts.LNAME;
                Cus.PHONE = Accounts.PHONE;
                Cus.DEPT_ID = Accounts.DEPT_ID;
                Cus.ACCESS_LEVEL = Accounts.ACCESS_LEVEL;
                Cus.PASSWORD = Accounts.PASSWORD;
                ADC.Accounts.Update(Cus);
                ADC.SaveChanges();
            }
        }
    }
}
