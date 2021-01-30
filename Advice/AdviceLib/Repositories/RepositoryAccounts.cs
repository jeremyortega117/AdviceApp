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
    /// <summary>
    /// This Repository Handles the Business Rules and error handling of data before sending to and retriving data
    /// from the database.
    /// </summary>
    public class RepositoryAccounts : IRepositoryAccounts<Accounts1>
    {
        public AdviceDbContext ADC;

        public RepositoryAccounts()
        {
            ADC = new AdviceDbContext();
        }
        public RepositoryAccounts(AdviceDbContext AD)
        {
            ADC = AD;
        }

        /// <summary>
        /// Create new account
        /// </summary>
        /// <param name="accounts"></param>
        public void CreateAccount(Accounts1 accounts)
        {
            if (!ChecksAndBalances(accounts))
            {
                Console.WriteLine($"An Error occured trying to add a new account information.");
                return;
            }
            // Add the account records.
            ADC.Accounts.Add(Mappings.MapAccount.Map(accounts));
            ADC.SaveChanges();
        }

        /// <summary>
        /// delete account by id
        /// </summary>
        /// <param name="id"></param>
        public void DeleteAccount(int id)
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
        /// return all accounts from by Department ID.
        /// </summary>
        /// <returns></returns>
        public IEnumerable<Accounts1> ReadInAccountsByDepartments(int DEPTID)
        {
            var getAx = from ax in ADC.Accounts 
                        where ax.DEPT_ID == DEPTID
                        select Mappings.MapAccount.Map(ax);

            if(getAx == null)
            {
                Console.WriteLine($"No Department exists with this ID.");
                return null;
            }
            return getAx;
        }


        /// <summary>
        /// return single account from repostory with matching id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Accounts1 ReadInAccount(int id)
        {
            var a = ADC.Accounts.FirstOrDefault(a => a.ID == id);
            if (a != null)
            {
                return Mappings.MapAccount.Map(a);
            }
            return null;
        }

        /// <summary>
        /// Update accounts.
        /// </summary>
        /// <param name="Accounts"></param>
        public void UpdateAccount(Accounts1 Accounts)
        {
            if (!ChecksAndBalances(Accounts))
            {
                Console.WriteLine($"An Error occured trying to add a new account information.");
                return;
            }
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

        /// <summary>
        /// Check that [department] already exists.
        /// Check that [email], [fname, lname, username], [phone] doesn't exist.
        /// </summary>
        /// <param name="accounts"></param>
        /// <returns></returns>
        public bool ChecksAndBalances(Accounts1 accounts)
        {
            // check if an email already exists.  If so don't allow another account to be made using that email.
            if (ADC.Accounts.Any(a => a.EMAIL == accounts.EMAIL))
            {
                Console.WriteLine($"This account with email {accounts.EMAIL} already exists and cannot be added");
                return false;
            }
            // check if an phone already exists.  If so don't allow another account to be made using that phone.
            else if (ADC.Accounts.Any(a => a.PHONE == accounts.PHONE))
            {
                Console.WriteLine($"An account with phone number {accounts.PHONE} already exists.");
                return false;
            }
            // check if a fname, lname, username combination already exists.  If so don't allow another account to be made that combination.
            else if (ADC.Accounts.Any(a => a.FNAME == accounts.FNAME &&
                                           a.LNAME == accounts.LNAME &&
                                           a.USERNAME == accounts.USERNAME))
            {
                Console.WriteLine($"This firstname, lastname and username combination already exists and cannot be added.");
                return false;
            }
            // If that department doesn't exist then don't try and add.
            else if (!ADC.Departments.Any(d => d.ID == accounts.DEPT_ID))
            {
                Console.WriteLine($"No Departments Exist matching {accounts.DEPT_ID}");
                return false;
            }
            return true;
        }
    }
}
