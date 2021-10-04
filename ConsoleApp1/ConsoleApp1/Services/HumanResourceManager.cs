using ConsoleApp1.Model;
using System;

namespace ConsoleApp1.Services
{
    class HumanResourceManager : IHumanResourceManager
    {
        private Department[] _department;
        public Department[] Department => _department;
        public HumanResourceManager()
        {
            _department = new Department[0]; // for creating department array
        }

        public void AddDepartment(string name, int workerlimit, int salarylimit)
        {
            Department department = new Department(name, workerlimit, salarylimit);
            
            Array.Resize(ref _department, _department.Length + 1);
            _department[_department.Length - 1] = department; // for adding items to department array
        }

        public void AddEmployee(string fullname, int salary, string departmentName, string position)
        {
           Department department = FinddepartmentByName(departmentName);
            
           
                if (department == null)
                {
                    Console.WriteLine($"{departmentName} adli department movcud deyil ");
                    return;
                }
            foreach (Department item in Department)
            {
                if (departmentName == item.Name)
                {
                    Console.WriteLine($"{fullname} adli Emploe {item.Name} adli departamente uqurla Add olundu");


                }
                
            }
            if (department.Employes.Length >= department.WorkerLimit)
            {
                Console.WriteLine($"{departmentName} adli  Employe yeardila bilmez");
                return;
            }
            Employee emplos = new Employee(fullname, salary, departmentName, position);
             
            Array.Resize(ref department.Employes,  department.Employes.Length + 1);
            department.Employes[department.Employes.Length - 1] = emplos;
            




        }

        public void EditDepartaments(string oldname, string newname)
        {
            Department editdepartment = FinddepartmentByName(oldname);
            if (editdepartment == null)
            {
                Console.WriteLine("bele department yoxdu");
                return;
            }
            else
            {
                Console.WriteLine("Adi uqurla deyiwildi");
            }
            editdepartment.Name = newname;
        }

        public void EditEmploye(string no,  int salary, string position)
        {
            foreach (Department item in Department)
            {
                foreach (Employee item2 in item.Employes)
                {
                    if (no == item2.No)
                    {
                        item2.Salary = salary;

                        item2.Position = position;
                    }
                    else
                    {
                        Console.WriteLine("yalniw daxil etdiz");
                    }
                }
            }
        }

        public void GetDepartments()
        {

            foreach (Department item in Department)
            {
                Console.WriteLine($"{item.Name} {item.WorkerLimit}");
            }
        }

        public void RemoveEmployee(string departmentname, string no)
        {
            Department department = null;
            foreach (Department item in Department)
            {
                if (item.Name.ToLower() == departmentname.ToLower())
                {
                    department = item;
                    break;
                }
                
            }
            Employee noedit = null;
            if (department != null)
            {
                foreach (Employee item in department.Employes)
                {
                    if (item.No.ToLower() == no.ToLower())
                    {
                        noedit = item;
                    }
                }
            }
            int index = Array.IndexOf(department.Employes,noedit);
            Array.Clear(department.Employes, index, 1);
        }
        public Department FinddepartmentByName(string name)
        {
            foreach (var item in _department)
            {
                if (item.Name == name)
                {
                    return item;
                }
            }
            return null;
        }

       
    }
}
