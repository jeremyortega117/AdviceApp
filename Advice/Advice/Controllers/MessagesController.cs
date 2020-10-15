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
    /// Message Controller Class  /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class MessagesController : ControllerBase
    {

        private IRepositoryMessages<Messages1> MSG;

        /// <summary>
        /// contstructor for Accounts Controller
        /// </summary>
        /// <param name="Acc"></param>
        public MessagesController(IRepositoryMessages<Messages1> MSG)
        {
            this.MSG = MSG;
        }

        /// <summary>
        /// return all Messages        /// </summary>
        /// <returns></returns>
        // GET: api/ControllerMessages
        [HttpGet]
        public IEnumerable<Messages1> Get()
        {
            return MSG.ReadInMessages().ToList();
        }

        /// <summary>
        /// return Message by id        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        // GET: api/ControllerMessages/5
        [HttpGet("{id}")]
        public Messages1 Get(int id)
        {
            return MSG.ReadInMessage(id);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <param name="Conversation_ID"></param>
        /// <param name="DeptID"></param>
        /// <param name="AccountID"></param>
        /// <param name="DateMade"></param>
        /// <param name="Message"></param>
        /// <param name="Type"></param>
        /// <param name="FileLocation"></param>
        /// <param name="keyWords"></param>
        /// <param name="Upvotes"></param>
        /// <param name="Views"></param>
        /// <param name="ReadAccess"></param>
        /// <param name="WriteAccess"></param>
        // POST: api/ControllerMessages
        [HttpPost]
        public void Post(int id,
                         int Conversation_ID,
                         int DeptID,
                         int AccountID,
                         DateTime DateMade,
                         byte[] Message,
                         string Type,
                         string FileLocation,
                         string keyWords,
                         int Upvotes,
                         int Views,
                         int ReadAccess,
                         int WriteAccess)
        {
            Messages1 m = new Messages1();
            m.ID = id;
            m.CONVERSATION_ID = Conversation_ID;
            m.DEPT_ID = DeptID;
            m.ACCOUNT_ID = AccountID;
            m.DATE_MADE = DateMade;
            m.MESSAGE = Message;
            m.TYPE = Type;
            m.FILE_LOCATION = FileLocation;
            m.KEYWORDS = keyWords;
            m.UPVOTES = Upvotes;
            m.VIEWS = Views;
            m.READ_ACCESS = ReadAccess;
            m.WRITE_ACCESS = WriteAccess;
            MSG.CreateMessage(m);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <param name="Conversation_ID"></param>
        /// <param name="DeptID"></param>
        /// <param name="AccountID"></param>
        /// <param name="DateMade"></param>
        /// <param name="Message"></param>
        /// <param name="Type"></param>
        /// <param name="FileLocation"></param>
        /// <param name="keyWords"></param>
        /// <param name="Upvotes"></param>
        /// <param name="Views"></param>
        /// <param name="ReadAccess"></param>
        /// <param name="WriteAccess"></param>
        // PUT: api/ControllerMessages/5
        [HttpPut("{id}")]
        public void Put(int id,
                         int Conversation_ID,
                         int DeptID,
                         int AccountID,
                         DateTime DateMade,
                         byte[] Message,
                         string Type,
                         string FileLocation,
                         string keyWords,
                         int Upvotes,
                         int Views,
                         int ReadAccess,
                         int WriteAccess)
        {
            Messages1 m = new Messages1();
            m.ID = id;
            m.CONVERSATION_ID = Conversation_ID;
            m.DEPT_ID = DeptID;
            m.ACCOUNT_ID = AccountID;
            m.DATE_MADE = DateMade;
            m.MESSAGE = Message;
            m.TYPE = Type;
            m.FILE_LOCATION = FileLocation;
            m.KEYWORDS = keyWords;
            m.UPVOTES = Upvotes;
            m.VIEWS = Views;
            m.READ_ACCESS = ReadAccess;
            m.WRITE_ACCESS = WriteAccess;
            MSG.UpdateMessage(m);
        }

        /// <summary>
        /// delete answer by id
        /// </summary>
        /// <param name="id"></param>
        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            MSG.DeleteMessage(id);
        }
    }
}
