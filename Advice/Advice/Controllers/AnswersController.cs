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
    /// Answers controller Class   /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class AnswersController : ControllerBase
    {

        private readonly IRepositoryAnswers<Answers1> ANS;

        /// <summary>
        /// contstructor for Accounts Controller
        /// </summary>
        /// <param name="Acc"></param>
        public AnswersController(IRepositoryAnswers<Answers1> Ans)
        {
            ANS = Ans;
        }

        /// <summary>
        /// get all answers
        /// </summary>
        /// <returns></returns>
        // GET: api/ControllerAnswers
        [HttpGet]
        public IEnumerable<Answers1> Get()
        {
            var ans = ANS.ReadInAnswers().ToList();
            List<Answers1> lAns = new List<Answers1>();
            foreach (var a in ans)
            {
                lAns.Add(a);
            }
            return lAns;
        }

        /// <summary>
        /// get answers by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        // GET: api/ControllerAnswers/5
        [HttpGet("{id}")]
        public IEnumerable<Answers1> Get(int id)
        {
            var ans = ANS.ReadInAnswers(id).ToList();
            List<Answers1> lAns = new List<Answers1>();
            foreach (var a in ans) {
                lAns.Add(a);
            }
            return lAns;
        }

        /// <summary>
        /// Create answers based on id.
        /// </summary>
        /// <param name="answer"></param>
        /// <param name="id"></param>
        // POST: api/ControllerAnswers
        [HttpPost]
        public void Post(string answer, int id)
        {
            Answers1 a = new Answers1();
            a.ID = id;
            a.Upvotes = 0;
            a.Visited = 0;
            a.Answers = answer;
            ANS.CreateAnswers(a);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <param name="upvotes"></param>
        /// <param name="visited"></param>
        // PUT: api/ControllerAnswers/5
        [HttpPut("{id}")]
        public void Put(int id, int upvotes, int visited)
        {
            Answers1 a = new Answers1();
            a.ID = id;
            a.Upvotes = upvotes;
            a.Visited = visited;
            ANS.UpdateAnswers(a);
        }

        /// <summary>
        /// delete answer by id
        /// </summary>
        /// <param name="id"></param>
        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            ANS.DeleteAnswers(id);
        }
    }
}
