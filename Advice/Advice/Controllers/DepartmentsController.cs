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
    /// Departments controller Class   /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class DepartmentsController : ControllerBase
    {

        private IRepositoryDepartments<Departments1> Dept;

        /// <summary>
        /// contstructor for Department Controller
        /// </summary>
        /// <param name="DEPT"></param>
        public DepartmentsController(IRepositoryDepartments<Departments1> DEPT)
        {
            Dept = DEPT;
        }

        /// <summary>
        /// get all Departments
        /// </summary>
        /// <returns></returns>
        // GET: api/ControllerDepartments
        [HttpGet]
        public IEnumerable<Departments1> Get()
        {
            return Dept.ReadInDepartments().ToList();
        }

        /// <summary>
        /// get Departments by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        // GET: api/ControllerDepartments/5
        [HttpGet("{id}")]
        public Departments1 Get(int id)
        {
            return Dept.ReadInDepartment(id);
        }

        /// <summary>
        /// get Departments by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        // GET: api/ControllerDepartments/5
        [HttpGet("{id}")]
        public Departments1 Get(int id)
        {
            return Dept.ReadInDepartment(id);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="DepName"></param>
        /// <param name="DepAccess"></param>
        // POST: api/ControllerDepartments
        [HttpPost]
        public void Post(string DepName,
                         int DepAccess)
        {
            Departments1 a = new Departments1();
            a.DEPT_ACCESS = DepAccess;
            a.DEPT_NAME = DepName;
            Dept.CreateDepartment(a);
        }        
        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <param name="depName"></param>
        /// <param name="depAccess"></param>
        // PUT: api/ControllerDepartments/5
        [HttpPut("{id}")]
        public void Put(int id, string depName, int depAccess)
        {
            Departments1 a = new Departments1();
            a.ID = id;
            a.DEPT_NAME = depName;
            a.DEPT_ACCESS = depAccess;
            Dept.UpdateDepartment(a);
        }

        /// <summary>
        /// delete Departments by id
        /// </summary>
        /// <param name="id"></param>
        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            Dept.DeleteDepartment(id);
        }
    }
}
