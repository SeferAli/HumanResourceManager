using ConsoleApp1.Model;
using ConsoleApp1.Services;
using System;


namespace ConsoleApp1
{
    class Program
    {
        public static object Editname { get; private set; }

        static void Main(string[] args)

        {
          

            HumanResourceManager humanResourceManager = new HumanResourceManager();

            do
            {
                Console.WriteLine("--------------------------");
                Console.WriteLine("1. Departmentler uzerinde emeliyyatlar");
                Console.WriteLine("2. Employe emeliyyatlari");
                Console.WriteLine("--------------------------");


                string ans = Console.ReadLine();
                int chooose;
                while (!int.TryParse(ans, out chooose))
                {
                    Console.WriteLine("--------------------------");
                    Console.WriteLine("1-2 araliqinda reqem daxil et");
                    Console.WriteLine("--------------------------");
                    ans = Console.ReadLine();
                   
                    int.TryParse(ans, out chooose);

                }


                switch (chooose)
                {
                    case 1:
                        Departamentuzreemeliyyatlar(humanResourceManager);
                        break;
                    case 2:
                        Employeeuzremeliyyatlari(humanResourceManager);
                        break;
                    default:
                        break;
                }


            } while (true);



            static void Departamentuzreemeliyyatlar(HumanResourceManager humanResourceManager)
            {
                Console.WriteLine("--------------------------");
                Console.WriteLine("1.Department Add etmek");
                Console.WriteLine("2.Departmentde deyiwklik");
                Console.WriteLine("3. Siyahi");
                Console.WriteLine("--------------------------");
                string cavab = Console.ReadLine();
               
                int choose;
                while (!int.TryParse(cavab, out choose))
                { 
                    Console.WriteLine("duzgun daxil et");
                    Console.WriteLine("--------------------------");
                    cavab = Console.ReadLine();
                }
                int.TryParse(cavab, out choose);
                switch (choose)
                {
                    case 1:
                        DepartamentElaveetmek(humanResourceManager);
                        break;
                    case 2:
                        Departmentdedeyiwiklik(humanResourceManager);
                        break;
                    case 3:
                        DepartmentList(humanResourceManager);
                        break;

                    default:
                        break;
                }

            }
            static void DepartamentElaveetmek(HumanResourceManager humanResourceManager)
            {
                Console.WriteLine("--------------------------");
                Console.WriteLine("Name elave et");
                Console.WriteLine("--------------------------");
                string enteringname = Console.ReadLine();
                string name = enteringname.ToUpper();
                
                Console.WriteLine("--------------------------");
                Console.WriteLine("Worker Count daxil et");
                Console.WriteLine("--------------------------");
                string limit = Console.ReadLine();
                Console.WriteLine("--------------------------");
                int workerlimit;
                int.TryParse(limit, out workerlimit);
                while (!int.TryParse(limit, out workerlimit))
                {
                    Console.WriteLine("duzgun daxil et");
                    Console.WriteLine("--------------------------");
                    limit = Console.ReadLine();
                    int.TryParse(limit, out workerlimit);
                }
                if (workerlimit >= 1) //workerlimit must be minimum 1;
                {

                }
                else
                {
                    Console.WriteLine("worker limiti minimum 1 ola biler.");
                }
                Console.WriteLine("Umumi maawi Add et");
                Console.WriteLine("--------------------------");
                string Slimit = Console.ReadLine();
                int salarylimit;
                int.TryParse(Slimit, out salarylimit);
                while (!int.TryParse(Slimit, out salarylimit))
                {
                    Console.WriteLine("--------------------------");
                    Console.WriteLine("duzgun daxil et");
                    Slimit = Console.ReadLine();
                    int.TryParse(Slimit, out salarylimit);
                }
                if (salarylimit >= 250) // salarylimit must be minimum 250
                {

                }
                else
                {
                    Console.WriteLine("salarylimiti 250 den az ola bilmez");
                    return;
                }
                humanResourceManager.AddDepartment(name, workerlimit, salarylimit);


            }
            static Department Departmentdedeyiwiklik(HumanResourceManager humanResourceManager) // Edit department (change name)
            {

                Console.WriteLine("Yeni departamentin adini elave et");
                string name = Console.ReadLine();



                foreach (var item in humanResourceManager.Department)
                {
                    if (item.Name == name)
                    {
                        Console.WriteLine("Yeni departamentin adini elave et");
                        string editname = Console.ReadLine();
                        string Editname = editname.Substring(0, 2).ToUpper();


                    }
                    else
                    {
                        Console.WriteLine("Bu adda department yoxdu");
                    }
                }

                return (Department)Editname;
            }
            static void DepartmentList(HumanResourceManager humanResourceManager) // get all  departments
            {

                humanResourceManager.GetDepartments();
            }
            
            static void Employeeuzremeliyyatlari(HumanResourceManager humanResourceManager) // Emploe 
            {
                Console.WriteLine("----------------------");
                Console.WriteLine("1.Emploe Add etmek");
                Console.WriteLine("2.Emploede deyiwklik");
                Console.WriteLine("3.Employe Siyahilari");
                Console.WriteLine("4.Employeni silmek");
                Console.WriteLine("----------------------");
                string cavab = Console.ReadLine();
                int choose;
                while (!int.TryParse(cavab, out choose))
                {
                    Console.WriteLine("----------------------");
                    Console.WriteLine("duzgun daxil et");

                    cavab = Console.ReadLine();


                }
                int.TryParse(cavab, out choose);
                switch (choose)
                {
                    case 1:
                        AddEmploe(humanResourceManager);

                        break;
                    case 2:
                        EditEmploye(humanResourceManager);
                        break;
                    case 3:
                        GetEmployes(humanResourceManager);
                            break;
                    case 4:
                        Removeemploye(humanResourceManager);
                        break;
                    default:

                        break;
                }

            }
            static void AddEmploe(HumanResourceManager humanResourceManager) // Add Emploe(name,salary,position)
            {
                Console.WriteLine(" Employenin adini daxil edin");
                string fullname = Console.ReadLine();
                Console.WriteLine("Salaryini daxil et");
                string ssalary = Console.ReadLine();
                int salary;
                int.TryParse(ssalary, out salary);
                while (!int.TryParse(ssalary, out salary))
                {
                    Console.WriteLine("Reqem daxil et");
                    ssalary = Console.ReadLine();
                    int.TryParse(ssalary, out salary);
                }
                if (salary > 250) // salary must be minimum 250
                {

                }
                else
                {
                    Console.WriteLine("salary 250 den awaqi ola bilmez");
                }
                foreach (Department item in humanResourceManager.Department)
                {
                    if (item.SalaryLimit>=salary) // salary must be little than salarylimit
                    {
                       
                    }
                    else
                    {
                        Console.WriteLine("awa bilmnez");
                        break;
                    }
                }
                
                Console.WriteLine("position elave edin");
                string position = Console.ReadLine();
                if (position.Length >= 2) // posiyion must be minimum 2 
                {

                }
                else
                {
                    Console.WriteLine("minimum 2 herden ibaret olmalidir");
                    return;
                }

                Console.WriteLine("----------------------");
                Console.WriteLine("Zehmet olmazsa daxil olduqu department adini secin");
                Console.WriteLine("----------------------");
                foreach (Department item in humanResourceManager.Department)
                {
                    Console.WriteLine(item.Name);
                }
                Console.WriteLine("----------------------");
                string departmentname = Console.ReadLine();

                humanResourceManager.AddEmployee(fullname, salary, departmentname, position);

            }
            static void EditEmploye(HumanResourceManager humanResourceManager) // Edit emploe ( salary, position)
            {
                foreach (Department item in humanResourceManager.Department)
                {
                    foreach (Employee item2 in item.Employes)
                    {
                        Console.WriteLine($"{item2.Fullname} {item2.Position} {item2.Salary}");
                    }

                }
                Console.WriteLine("Iscinin nomresini daxil edin");
                string result = Console.ReadLine();
                Console.WriteLine("yeni salary");
                string salary = Console.ReadLine();
                int newsalary;
                int.TryParse(salary, out newsalary);
                Console.WriteLine("Yeni pozisya daxil et");
                string newposition = Console.ReadLine();
                humanResourceManager.EditEmploye(result, newsalary, newposition);
            }
            static void GetEmployes(HumanResourceManager humanResourceManager)
            {
                foreach (Department item in humanResourceManager.Department)
                {
                    foreach (Employee item2 in item.Employes)
                    {
                        Console.WriteLine($"{item2.Fullname} {item2.Position} {item2.Salary}  {item2.No}");
                    }

                }
            }
            static void Removeemploye(HumanResourceManager humanResourceManager) // remove emploe in department
            {
                Console.WriteLine("yerlewdiyi department name secin");
                string name = Console.ReadLine();
                Console.WriteLine("silmek istediyiniz employeni secin");
                string no = Console.ReadLine();
                humanResourceManager.RemoveEmployee(name, no);
            }
                
            }
        }
    }

