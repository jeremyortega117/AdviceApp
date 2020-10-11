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

        public void CreateDepartments(Departments1 Departments)
        {
            ADC.Departments.Add(Mappings.MapDepartments.Map(Departments));// this will generate insertMapper.Map(Departments)
            ADC.SaveChanges();// this will execute the above generate insert query
        }

        public void DeleteDepartments(int id)
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

        public IEnumerable<Departments1> ReadInDepartments()
        {
            var getCx = from cx in ADC.Departments
                        select Mappings.MapDepartments.Map(cx);
            return getCx;
        }

        public Departments1 ReadInDepartment(int id)
        {
            var getCx = ADC.Departments.FirstOrDefault(e => e.ID == id);
                        
            return MapDepartments.Map(getCx);
        }

        public void UpdateDepartments(Departments1 Departments)
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
