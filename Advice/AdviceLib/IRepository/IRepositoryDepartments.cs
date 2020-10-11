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
        void CreateDepartments(T Departments);
        void UpdateDepartments(T Departments);
        void DeleteDepartments(int id);
    }
}
