using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using employee_crud_.Models.Validation;

namespace employee_crud_.Models.Entities
{
    public class Employee
    {
        [Key, Column("Id")]
        [DisplayName("Employee ID")]
        public int Id { get; set; }

        [Column("FirstName"), MaxLength(20)]
        [DisplayName("First Name")]
        public String FName { get; set; }

        [Column("LastName"), MaxLength(20)]
        [DisplayName("Last Name")]
        public String LName { get; set; }

        [Column("Email"), MaxLength(30)]
        [DisplayName("Email Address")]
        public String Email { get; set; }

        [Column("DOB")]
        [DisplayName("Date of Birth")]
        public DateTime Dob { get; set; }

        [Column("Salary")]
        [DisplayName("Salary")]
        // Validation Part,
        [GreaterThan(0)]
        public double Salary { get; set; }

        [ForeignKey("Department")]
        [Column("Department_Id")]
        [DisplayName("Department ID")]
        public int DId { get; set; }

        public Department? Department { get; set; }

        internal static object Include(string v)
        {
            throw new NotImplementedException();
        }
    }
}
