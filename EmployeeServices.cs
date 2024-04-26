using EmployeesAPI.Models;
namespace EmployeesAPI.Services
{
    public class EmployeeServices
    {
        static List<Employee> EmployeeList { get; }
        static int nextEmployeeID = 3;

        static EmployeeServices()
        {
            EmployeeList = new List<Employee>
            { new Employee{EmployeeID = 1, EmployeeName = "Mohamed",salary = 2500},
              new Employee{ EmployeeID = 2,EmployeeName = "Hassan", salary = 1800} };
        }

        public static List<Employee> GetAll() => EmployeeList;

        public static Employee GetEmployee(int id) => EmployeeList.FirstOrDefault(x => x.EmployeeID == id);

        public static void Add(Employee employee)
        {
            employee.EmployeeID = nextEmployeeID++;
            EmployeeList.Add(employee);
        }

        public static void Update(Employee employee)
        {
            var index = EmployeeList.FindIndex(x => x.EmployeeID == employee.EmployeeID);
            if (index == -1)
                return;
            else
                EmployeeList[index] = employee;
        }

        public static void Delete(int id)
        {
            if(GetEmployee(id) != null) 
                EmployeeList.Remove(GetEmployee(id));
        }

    }
}
