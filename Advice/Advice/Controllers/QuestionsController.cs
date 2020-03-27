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
    /// Question Controller Class  /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class QuestionsController : ControllerBase
    {

        private readonly IRepositoryQuestions<Questions1> QUS;

        /// <summary>
        /// contstructor for Accounts Controller
        /// </summary>
        /// <param name="Acc"></param>
        public QuestionsController(IRepositoryQuestions<Questions1> Qus)
        {
            QUS = Qus;
        }

        /// <summary>
        /// return all questions        /// </summary>
        /// <returns></returns>
        // GET: api/ControllerQuestions
        [HttpGet]
        public IEnumerable<Questions1> Get()
        {
            var qus = QUS.ReadInQuestion().ToList();
            List<Questions1> lQus = new List<Questions1>();
            foreach (var q in qus)
            {
                lQus.Add(q);
            }
            return lQus;
        }

        /// <summary>
        /// return question by id        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        // GET: api/ControllerQuestions/5
        [HttpGet("{id}")]
        public IEnumerable<Questions1> Get(int id)
        {
            var qus = QUS.ReadInQuestion(id).ToList();
            List<Questions1> lQus = new List<Questions1>();
            foreach (var q in qus)
            {
                lQus.Add(q);
            }
            return lQus;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="Questions"></param>
        /// <param name="id"></param>
        // POST: api/ControllerQuestions
        [HttpPost]
        public void Post(string Questions, int id)
        {
            Questions1 a = new Questions1();
            a.ID = id;
            a.Upvotes = 0;
            a.Visited = 0;
            a.Question = Questions;
            QUS.CreateQuestion(a);
        }

        /// <summary>
        /// update upvotes and visited status
        /// </summary>
        /// <param name="id"></param>
        /// <param name="upvotes"></param>s
        /// <param name="visited"></param>
        // PUT: api/ControllerQuestions/5
        [HttpPut("{id}")]
        public void Put(int id, int upvotes, int visited)
        {
            Questions1 a = new Questions1();
            a.ID = id;
            a.Upvotes = upvotes;
            a.Visited = visited;
            QUS.UpdateQuestion(a);
        }

        /// <summary>
        /// delete answer by id
        /// </summary>
        /// <param name="id"></param>
        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            QUS.DeleteQuestion(id);
        }
    }
}
