using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using 

namespace employee_crud_.Models.Entities
{
    public class Employee
    {
        [Key, Column("Id")]
        [DisplayName("Employee ID")]
        public int Id { get; set; }

        [Column("FirstName"), MaxLength(20)]
        [DisplayName("First Name")]
        public String FNAme { get; set; }

        [Column("LastName"), MaxLength(20)]
        [DisplayName("Last Name")]
        public String LName { get; set; }

        [Column("Email"), MaxLength(30)]
        [DisplayName("Email Address")]
        public String Email { get; set; }

        [Column("DOB")]
        [DisplayName("Date of Birth")]
        public DateOnly Dob { get; set; }

        [Column("Salary")]
        [DisplayName("Salary")]
        public double Salary { get; set; }
    }
}
