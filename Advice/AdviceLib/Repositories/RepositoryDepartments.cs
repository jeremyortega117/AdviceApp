using AdviceLib.IRepository;
using System;
using System.Collections.Generic;
using System.Text;
using AdviceLib.Models;
using DataAccess;
using System.Linq;
using AdviceLib.Mappings;

namespace AdviceLib.Repositories
{
    public class RepositoryDepartments : IRepositoryDepartments<Departments1>
    {
        AdviceDbContext ADC;

        public RepositoryDepartments()
        {
            ADC = new AdviceDbContext();
        }
        public RepositoryDepartments(AdviceDbContext AD)
        {
            ADC = AD ?? throw new ArgumentNullException(nameof(AD));
        }

        /// <summary>
        /// Create new Department
        /// </summary>
        /// <param name="Departments"></param>
        public void CreateDepartment(Departments1 Departments)
        {
            if (ADC.Departments.Any(d => d.DEPT_NAME == Departments.DEPT_NAME))
            {
                Console.WriteLine($"This Department {Departments.DEPT_NAME} already exists and cannot be added");
                return;
            }
            else
                ADC.Departments.Add(MapDepartments.Map(Departments));// this will generate insertMapper.Map(Departments)
            ADC.SaveChanges();// this will execute the above generate insert query
        }

        /// <summary>
        ///  delete apartment by id
        /// </summary>
        /// <param name="id"></param>
        public void DeleteDepartment(int id)
        {
            var Cus = ADC.Departments.FirstOrDefault(Cx => Cx.ID == id);
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
        /// Read in all apartments
        /// </summary>
        /// <returns></returns>
        public IEnumerable<Departments1> ReadInDepartments()
        {
            var getCx = from cx in ADC.Departments
                        select MapDepartments.Map(cx);
            return getCx;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Departments1 ReadInDepartment(int id)
        {
            var getCx = ADC.Departments.FirstOrDefault(e => e.ID == id);                       
            return MapDepartments.Map(getCx);
        }

        /// <summary>
        /// Update apartment
        /// </summary>
        /// <param name="Departments"></param>
        public void UpdateDepartment(Departments1 Departments)
        {
            if (ADC.Departments.Any(Cx => Cx.ID == Departments.ID))
            {
                var Cus = ADC.Departments.FirstOrDefault(Cx => Cx.ID == Departments.ID);
                ADC.Departments.Update(Cus);
                ADC.SaveChanges();
            }
        }
    }
}
