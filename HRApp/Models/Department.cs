using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HRApp.Models
{
    [Table("Department",Schema="dbo")]
    public class Department
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Display(Name="Department Id")]
        public int DepartmentId { get; set; }

        [Required(ErrorMessage = "Please Enter Department Name")]
        [Column(TypeName = "varchar(150)")]
        [Display(Name = "Department Name")]
        public string DepartmentName { get; set; }

        [Column(TypeName = "varchar(5)")]
        [Display(Name = "Department Abbreviation")]
        public string DepartmentAbbr { get; set; }
    }
}
