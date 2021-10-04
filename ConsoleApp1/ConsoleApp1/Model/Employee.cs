using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp1.Model
{
    class Employee
    {
        public static int count = 1000;
        public string No;
        public string Fullname;
        private static int _salary;
        public int Salary //salary must be minimum 250
        {
            get { return _salary; }
            set
            {
                if (value <= 250)
                {
                    Console.WriteLine("Salary minumum 250  ola biler");
                }
                else
                {
                    _salary = value;
                }
            }
        }
        public string DepartmentName;
        private string _position;
        public string Position //position must be mimimum 2 letter
        {
            get { return _position; }
            set
            {
                if (value.Length < 2)
                {
                    Console.WriteLine("Position minumum 2 herfden ibaret ola biler");
                }
                else
                {
                    _position = value;
                }
            }
        }
        public Employee(string fullname,  int salary,string departmentName,string position)
        {
            count++;
            No = departmentName.Substring(0, 2).ToUpper() + count;
            Fullname = fullname;
            Salary = salary;
            DepartmentName = departmentName;
            Position = position;
            
        }
    }
    
}
