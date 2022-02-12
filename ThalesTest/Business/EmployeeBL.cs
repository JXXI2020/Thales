using ThalesTest.Models;

namespace ThalesTest.Business
{
    public class EmployeeBL : IEmployeeBL
    {
        public Employee SalaryRule(Employee employee)
        {
            Employee employee1 = employee;
            employee.employee_anual_salary = employee.employee_salary * 12;
            return employee1;
        }
    }
}
