using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Employee_Staff.Models
{
    public class Employee
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public int StaffId { get; set; }
        public Staff Staff { get; set;}
        public override string ToString()
        {
            return $"Id: {Id}, Ismi: {FirstName}, Familiyasi: {LastName}, Email: {Email}, Parol: {Password}, Bo'limID: {StaffId}";
        }
    }
}
