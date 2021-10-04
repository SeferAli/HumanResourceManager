using ConsoleApp1.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp1
{
    interface IHumanResourceManager
    {
        public Department[] Department { get; }
        public void AddDepartment(string name, int workerlimit, int salarylimit);
        public void AddEmployee( string fullname, int salary, string departmentName, string position);
        public void GetDepartments();
        public void EditDepartaments(string oldname, string newname);
        public void RemoveEmployee(string departmentname, string no);
        public void EditEmploye(string no, int salary, string position);

      


    }
}
