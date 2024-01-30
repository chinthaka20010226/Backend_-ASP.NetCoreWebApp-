using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace employee_crud_.Models.Entities
{
    public class Employee
    {
        [Key, Column("Id")]
        [DisplayName("Employee ID")]
        public int Id { get; set; }


        public String FNAme { get; set; }
        public String LName { get; set; }
        public String Email { get; set; }
        public DateOnly Dob { get; set; }
        public double Salary { get; set; }
    }
}
