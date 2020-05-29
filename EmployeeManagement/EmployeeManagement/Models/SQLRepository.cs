using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;

namespace EmployeeManagement.Models
{
    public class SQLRepository : IEmployeeRepository
    {
        private readonly AppDbContext context;

        public SQLRepository(AppDbContext context)
        {
            this.context = context;
        }

    

        public Employee Add(Employee emp)
        {
            context.Employees.Add(emp);

            context.SaveChanges();
            return emp;
        }

        public Employee Delete(string mailid)
        {
           var d= context.Employees.FirstOrDefault(x =>x.Email==mailid );
            context.Remove(d);
            context.SaveChanges();
            return d;
        }

        public IEnumerable<Employee> employees()
        {
            throw new NotImplementedException();
        }

        public Employee GetEmployee(int id)
        {
         Employee emp=   context.Employees.FirstOrDefault(x => x.Id==id);
            return emp;
        }

        public Employee Update(Employee empupdate)
        {
          var u=  context.Employees.FirstOrDefault(x => x.Email == empupdate.Email);
            u.Name = empupdate.Name;
            u.Department = empupdate.Department;


            context.SaveChanges();
            return u;
        }
    }
}
