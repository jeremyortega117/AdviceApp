using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Versioning;
using System.Threading.Tasks;
using AdviceLib.IRepository;
using AdviceLib.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Advice.Controllers
{
    /// <summary>
    /// Controller class for Accounts
    /// This can be found on localhost:<12356>/api/Accounts
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class AccountsController : ControllerBase
    {

        private IRepositoryAccounts<Accounts1> ACC;

        /// <summary>
        /// contstructor for Accounts Controller
        /// </summary>
        /// <param name="Acc"></param>
        public AccountsController(IRepositoryAccounts<Accounts1> Acc)
        {
            ACC = Acc;
        }

        // GET: api/ControllerAccounts
        /// <summary>
        /// return all elements in Account
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IEnumerable<Accounts1> Get()
        {
            return ACC.ReadInAccounts().ToList();
        }

        // GET: api/ControllerAccounts/5
        /// <summary>
        /// Get account by id
        /// /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public Accounts1 Get(int id)
        {
            return ACC.ReadInAccount(id);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="FNAME"></param>
        /// <param name="LNAME"></param>
        /// <param name="PASSWORD"></param>
        /// <param name="ACCESS_LEVEL"></param>
        /// <param name="EMAIL"></param>
        /// <param name="PHONE"></param>
        /// <param name="USERNAME"></param>
        /// <param name="DEPT_ID"></param>
        // POST: api/ControllerAccounts
        [HttpPost]
        public void Post( 
                        string FNAME,
                        string LNAME,
                        string PASSWORD,
                        int ACCESS_LEVEL,
                        string EMAIL,
                        string PHONE,
                        string USERNAME, 
                        int DEPT_ID)
        {
            Accounts1 a = new Accounts1();
            a.FNAME = FNAME;
            a.LNAME = LNAME;
            a.PASSWORD = PASSWORD;
            a.ACCESS_LEVEL = ACCESS_LEVEL;
            a.EMAIL = EMAIL;
            a.PHONE = PHONE;
            a.USERNAME = USERNAME;
            a.DEPT_ID = DEPT_ID;
            ACC.CreateAccount(a);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <param name="fname"></param>
        /// <param name="lname"></param>
        /// <param name="password"></param>
        /// <param name="access_level"></param>
        /// <param name="email"></param>
        /// <param name="phone"></param>
        /// <param name="username"></param>
        /// <param name="dept_id"></param>
        // PUT: api/ControllerAccounts/5
        [HttpPut("{id}")]
        public void Put(int id,
                        string fname,
                        string lname,
                        string password,
                        int access_level,
                        string email,
                        string phone,
                        string username,
                        int dept_id
                        )
        {
            Accounts1 acc = new Accounts1();
            acc.ID = id;
            acc.FNAME = fname;
            acc.LNAME = lname;
            acc.PASSWORD = password;
            acc.ACCESS_LEVEL = access_level;
            acc.EMAIL = email;
            acc.PHONE = phone;
            acc.USERNAME = username;
            acc.DEPT_ID = dept_id;
            ACC.UpdateAccount(acc);
        }

        // DELETE: api/ApiWithActions/5
        /// <summary>
        /// Delete account by id
        /// </summary>
        /// <param name="id"></param>
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            ACC.DeleteAccount(id);
        }
    }
}
