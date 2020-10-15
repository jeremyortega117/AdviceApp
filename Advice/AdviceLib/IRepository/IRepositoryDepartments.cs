using System;
using System.Collections.Generic;
using System.Text;
using DataAccess.Entities;

namespace AdviceLib.IRepository
{
    public interface IRepositoryDepartments<T>
    {
        IEnumerable<T> ReadInDepartments();
        T ReadInDepartment(int id);
        void CreateDepartment(T Departments);
        void UpdateDepartment(T Departments);
        void DeleteDepartment(int id);
    }
}
