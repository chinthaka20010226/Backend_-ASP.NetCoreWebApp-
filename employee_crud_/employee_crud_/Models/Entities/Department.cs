using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace employee_crud_.Models.Entities
{
    public class Department
    {
        [Key, Column("Id")]
        [DisplayName("Department Id")]
        public int Id { get; set; }

        [Column("Name"), MaxLength(50)]
        [DisplayName("Department Name")]
        public String Name { get; set; }
    }
}
