using Employee_Staff.Data;
using Employee_Staff.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Employee_Staff.CRUD
{
    public static class CrudEmployee
    {
        public static EduCenterDB EduCenterDB = new EduCenterDB();
        public static void AddEmployee(string fname, string lname, string email, string password, int staffid)
        {
            EduCenterDB.Employees.Add(new Employee()
            {
                FirstName = fname,
                LastName = lname,
                Email = email,
                Password = password,
                StaffId = staffid,
            });
            EduCenterDB.SaveChanges();
        }
        public static void DeleteEmployee(Employee employee) 
        {
            EduCenterDB.Employees.Remove(employee);
            EduCenterDB.SaveChanges();
        }
        public static void GetEmployee(int staffid)
        {
            var employee=EduCenterDB.Employees.Where(emp=>emp.Id==staffid).FirstOrDefault();
            Console.WriteLine(employee);
        }
        public static void WhichStaff(int empid) 
        {
            using (var dbContext = new EduCenterDB())
            {
                var query = from a in dbContext.Employees
                            join b in dbContext.Staffs on a.StaffId equals b.Id
                            where a.Id==empid
                            select new
                            {
                                EmpFname = a.FirstName,
                                EmpLname = a.LastName,
                                Staff=b.Name,
                            };

                foreach (var result in query)
                {
                    Console.WriteLine($"{result.EmpLname} {result.EmpFname} {result.Staff}da ishlaydi");
                }
            }
        }
    }
}
