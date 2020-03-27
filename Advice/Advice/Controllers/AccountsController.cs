using System;
using System.Collections.Generic;
using System.Linq;
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

        private readonly IRepositoryAccounts<Accounts1> ACC;

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
            var acc = ACC.ReadInAccounts().ToList();
            List<Accounts1> lAcc = new List<Accounts1>();
            foreach (var a in acc)
            {
                //Accounts1 newAcc = new Accounts1();
                //newAcc.Email = a.Email;
                //newAcc.ID = a.ID;
                //newAcc.Username = a.Username;
                //newAcc.Password = a.Password;
                //lAcc.Add(newAcc);
                lAcc.Add(a);
            }
            return lAcc;
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
            return ACC.ReadInAccounts(id);
        }

        /// <summary>
        /// Create Account
        /// </summary>
        /// <param name="email"></param>
        /// <param name="username"></param>
        /// <param name="password"></param>
        // POST: api/ControllerAccounts
        [HttpPost]
        public void Post(string email, string username, string password)
        {
            Accounts1 a = new Accounts1();
            a.Email = email;
            a.Username = username;
            a.Password = password;
            ACC.CreateAccounts(a);
        }

        /// <summary>
        /// Update and account email and username
        /// </summary>
        /// <param name="id"></param>
        /// <param name="email"></param>
        /// <param name="username"></param>
        // PUT: api/ControllerAccounts/5
        [HttpPut("{id}")]
        public void Put(int id, string email, string username)
        {
            Accounts1 acc = new Accounts1();
            acc.ID = id;
            acc.Username = username;
            acc.Email = email;
            ACC.UpdateAccounts(acc);
        }

        // DELETE: api/ApiWithActions/5
        /// <summary>
        /// Delete account by id
        /// </summary>
        /// <param name="id"></param>
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            ACC.DeleteAccounts(id);
        }
    }
}
