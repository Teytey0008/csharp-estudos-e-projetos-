using System;
using System.Globalization;
using PrimeiroProjeto.Entities;
using PrimeiroProjeto.Entities.Enums;

namespace PrimeiroProjeto { 

    class Program {

        static void Main(string[] args) {

            Console.Write("Ente department's name: ");
            string deptName = Console.ReadLine();
            Console.WriteLine("Enter worker data: ");
            Console.Write(" name: ");
            string name = Console.ReadLine();
            Console.Write("Level (Junior/MidLevel/Senior): ");
            WorkerLevel level = Enum.Parse<WorkerLevel>(Console.ReadLine());
            Console.Write("Base salary;");
            double baseSalary = double.Parse(Console.ReadLine(),CultureInfo.InvariantCulture);

            Department dept = new Department(deptName);

            Worker worker = new Worker( name,  level, baseSalary, dept);

            Console.Write("How Many conctracts to this worker ?");
            int n = int.Parse(Console.ReadLine());

            for (int i = 1; i <= n; i++)
            {
                Console.WriteLine($"Enter #{i} contract data:");
                Console.Write("DATE (DD/MM/YYYY): ");
                DateTime date = DateTime.Parse(Console.ReadLine());
                Console.Write("Value per Hours : ");
                double valuePerHour = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);
                Console.Write("Duration (hours): ");
                int hours = int.Parse(Console.ReadLine());
                HourContract contract = new HourContract(date, valuePerHour, hours);

                worker.AddContract(contract);


            }

            Console.Write("Enter month and year to calculate income (MM/YYYY) :");
            string monthAndYear = Console.ReadLine();
            int month = int.Parse(monthAndYear.Substring(0, 2));
            int year = int.Parse(monthAndYear.Substring(3));

            Console.WriteLine("NAME" + worker.Name);
            Console.WriteLine("DEPARTMENT: " + worker.Department.Name);



            Console.WriteLine("Income for :" + monthAndYear + ":" + worker.Income(year, month));


        }
using System;
using System.Collections.Generic;
using System.Text;
using PrimeiroProjeto.Entities.Enums;
using PrimeiroProjeto.Entities;



namespace PrimeiroProjeto.Entities { 
    
    class Worker
    {
        public string Name { get; set; }
        public WorkerLevel Level { get; set; }
        public double BaseSalary { get; set; }
        public Department Department { get; set; }

        public List<HourContract> Contracts { get; set; } = new List<HourContract>();

        public Worker() 
        { 

        }

        public Worker(string name, WorkerLevel level, double baseSalary, Department department)
        
        {
            Name = name;
            Level = level;
            BaseSalary = baseSalary;
            Department = department;

           
        }

        public void AddContract(HourContract contract)
        {
            Contracts.Add(contract);
        }

        public void RemoveContract(HourContract contract)
        {
            Contracts.Remove(contract);
        }

        public double Income(int year, int month)

        {
            double sum = BaseSalary;
            foreach (HourContract contract in Contracts)
            {
                if (contract.Date.Year == year && contract.Date.Month == month)
                {
                    sum += contract.TotalValue();
                }
            }
            return sum;
        }


    }







}






















    }


















}
using System;
using System.Collections.Generic;
using System.Text;

namespace PrimeiroProjeto.Entities
{
    class HourContract
    {

        public DateTime Date{ get; set; }
        public double ValuePerHour{ get; set; }
        public int Hours{ get; set; }

        public HourContract (DateTime date, double valueperhour, int hours)
        {
            Date = date;
            ValuePerHour = valueperhour;
            Hours = hours;

        }
        public HourContract()
        {
            
        }

        public double TotalValue() 
        {
            return Hours * ValuePerHour;


        }


    }


}
using System;
using System.Collections.Generic;
using System.Text;

namespace PrimeiroProjeto.Entities
{
    class Department
    {
     
        public string Name { get; set; }

        public Department()
        {

        }
        public Department(string name)
        {
            Name = name;
        }

    }




}
using System;
using System.Collections.Generic;
using System.Text;
using PrimeiroProjeto;

namespace PrimeiroProjeto.Entities.Enums
{
    enum WorkerLevel : int
    {
        Junior = 0,
        MidLevel = 1,
        Senior = 2
    }
}

