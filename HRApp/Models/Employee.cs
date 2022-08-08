using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HRApp.Models
{
    [Table("Employee",Schema ="dbo")]
    public class Employee
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Display(Name="Employee Id")]
        public int EmployeeId { get; set; }

        [Required(ErrorMessage ="Please Enter Employee Number")]
        [Column(TypeName ="varchar(5)")]
        [MaxLength(5)]
        [Display(Name ="Employee No.")]
        public string EmployeeNumber { get; set; }

        [Required(ErrorMessage = "Please Enter Employee Name 2")]
        [Column(TypeName = "varchar(150)")]
        [MaxLength(100)]
        [Display(Name = "Employee Name")]
        public string EmployeeName { get; set; }

        [Required(ErrorMessage = "Please Enter Date Of Birth")]
        [DataType(DataType.Date)]
        [Display(Name ="Date Of Birth")]
        public DateTime DOB { get; set; }

        [Required(ErrorMessage = "Please Enter Hiring Date")]
        [DataType(DataType.Date)]
        [Display(Name = "Hiring Date")]
        public DateTime HiringDate { get; set; }

        [Required(ErrorMessage = "Please Enter Gross Salary")]
        //[Column (TypeName ="decimal(12,2)")]
        [Display (Name ="Gross Salary")]
        public decimal? GrossSalary { get; set; }

        [Required(ErrorMessage = "Please Enter Net Salary")]
        [Column(TypeName = "decimal(12,2)")]
        [Display(Name = "Net Salary")]
        public decimal NetSalary { get; set; }

        [ForeignKey("Department")]
        [Required]
        public int DepartmentId { get; set; }

        [Display(Name ="Department")]
        [NotMapped]
        public string DepartmentName { get; set; }

        public virtual Department Department { get; set; }
    }
}
