using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeManagement.Models
{
    public class MockEmployeeRepository 
    {
        private List<Employee> _employeeList;

        public MockEmployeeRepository()
        {
            _employeeList = new List<Employee>()
            {

            new Employee() { Id = 1, Name = "Mary", Department = Dept.HR, Email = "mary@pragimtech.com" },
            new Employee() { Id = 2, Name = "John", Department = Dept.IT, Email = "john@pragimtech.com" },
            new Employee() { Id = 3, Name = "Sam", Department = Dept.Payroll, Email = "sam@pragimtech.com" },


            };
        }

        public Employee Add(Employee emp)
        {
            emp.Id = _employeeList.Max(x => x.Id) + 1;
           _employeeList.Add(emp);
            return emp;
        }

        public Employee Delete(string mailid)
        {
          var tobedeleted=  _employeeList.FirstOrDefault(e => e.Email == mailid);
            if(tobedeleted!=null)
            _employeeList.Remove(tobedeleted);

            return tobedeleted;
        }

        public IEnumerable<Employee> employees()
        {
            var emplist = _employeeList;
            return emplist;
        }

        public Employee GetEmployee(int Id)
        {
            return this._employeeList.FirstOrDefault(e => e.Id == Id);
            
        }

        public Employee GetEmployee(string id)
        {
            throw new NotImplementedException();
        }

        public Employee Update(Employee empupdate)
        {
            throw new NotImplementedException();
        }
    }
}
