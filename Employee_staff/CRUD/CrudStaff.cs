using Employee_Staff.Data;
using Employee_Staff.Models;
using Microsoft.EntityFrameworkCore;

namespace Employee_Staff.CRUD
{
    public static class CRUDStaff
    {

        public static EduCenterDB EduCenterDB = new EduCenterDB();
        public static void AddStaff(string name, string desc)
        {
            EduCenterDB.Staffs.Add(new Staff()
            {
                Name = name,
                Description = desc,
            }
            );
            EduCenterDB.SaveChanges();
        }
        public static void DeleteStaff(Staff staff)
        {
            EduCenterDB.Staffs.Remove(staff);
            EduCenterDB.SaveChanges();
        }
        public static void GetStaff(int staffid)
        {
            var employee = EduCenterDB.Staffs.Where(emp => emp.Id == staffid).FirstOrDefault();
            Console.WriteLine(employee);
        }
        public static void GetAllEmployeeById(int staffid)
        {
            using (var dbContext = new EduCenterDB())
            {
                var query = from st in dbContext.Staffs
                            join emp in dbContext.Employees on st.Id equals emp.StaffId
                            where st.Id==staffid
                            select new
                            {
                                EmpFname = emp.FirstName,
                                EmpLname = emp.LastName,
                                stname=st.Name
                            };
                foreach (var javob in query)
                {
                    Console.WriteLine(javob.stname + " bo'limi");
                    break;
                }
                foreach (var result in query)
                {
                    Console.WriteLine($"Firstname: {result.EmpFname}, Lastname: {result.EmpLname}");
                }
            }
        }


        //experiment with include 
        public static void FindEmp(int id)
        {
            using (EduCenterDB db = new EduCenterDB())
            {
                var users = db.Employees.Include(u => u.Staff) 
                            .ToList();
                foreach (var user in users)
                    if (user.StaffId == id)
                        Console.WriteLine($"{user.FirstName} - {user.LastName}");
            }
        }
    }
}
