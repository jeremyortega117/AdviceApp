using AdviceLib.IRepository;
using AdviceLib.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Advice.Controllers
{
    /// <summary>
    /// 
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class ConversationsController : ControllerBase
    {

        private IRepositoryConversations<Conversations1> CONV;

        /// <summary>
        /// contstructor for Conversations Controller
        /// </summary>
        /// <param name="CONV"></param>
        public ConversationsController(IRepositoryConversations<Conversations1> Conv)
        {
            CONV = Conv;
        }

        // GET: api/ControllerConversations
        /// <summary>
        /// return all elements in Conversation
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IEnumerable<Conversations1> Get()
        {
            return CONV.ReadInConversations().ToList();
        }

        // GET: api/ControllerConversations/5
        /// <summary>
        /// Get Conversation by id
        /// /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public Conversations1 Get(int id)
        {
            return CONV.ReadInConversation(id);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="AccountId"></param>
        /// <param name="ConversationType"></param>
        /// <param name="DeptId"></param>
        /// <param name="AccessLevel"></param>
        // POST: api/ControllerConversations
        [HttpPost]
        public void Post(int AccountId,
                         int ConversationType,
                         int AccessLevel
                        )
        {
            Conversations1 a = new Conversations1();
            a.ACCOUNT_ID = AccountId;
            a.CONVERSATION_TYPE = ConversationType;
            a.ACCESS_LEVEL = AccessLevel;
            CONV.CreateConversation(a);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="AccountId"></param>
        /// <param name="ConversationType"></param>
        /// <param name="DeptId"></param>
        /// <param name="AccessLevel"></param>
        // PUT: api/ControllerConversations/5
        [HttpPut("{id}")]
        public void Put(int AccountId,
                         int ConversationType,
                         int AccessLevel
                        )
        {
            Conversations1 CON = new Conversations1();
            CON.ACCOUNT_ID = AccountId;
            CON.CONVERSATION_TYPE = ConversationType;
            CON.ACCESS_LEVEL = AccessLevel;
            CONV.UpdateConversation(CON);
        }

        // DELETE: api/ApiWithActions/5
        /// <summary>
        /// Delete Conversation by id
        /// </summary>
        /// <param name="id"></param>
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            CONV.DeleteConversation(id);
        }

    }
}
