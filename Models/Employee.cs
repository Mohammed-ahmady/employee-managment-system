using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EmpApp.Models;
[Table("Employee", Schema = "dbo")]

public class Employee
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    [Display(Name = "Employee ID")]   
    public int EmployeeId { get; set; }
    
    [Display(Name = "Employee No.")]
    [Required]
    [Column(TypeName = "varchar(15)")]
    public string EmployeeNumber { get; set; } = string.Empty;
    
    [Display(Name = "Employee Name")]
    [Required]
    [Column(TypeName = "varchar(150)")]
    public string EmployeeName { get; set; } = string.Empty;
    
    [Display(Name = "Hiring Date")]
    [Required]   
    [DataType(DataType.Date)]
    [DisplayFormat(DataFormatString = "{0:dd-MMM-yyyy}")]
    public DateTime HiringDate { get; set; }
    
    [Display(Name = "Date of Birth")]
    [Required]
    [DataType(DataType.Date)]
    [DisplayFormat(DataFormatString = "{0:dd-MMM-yyyy}")]
    public DateTime DOB { get; set; }

    [Required]
    [Column(TypeName = "decimal(12,2)")]
    [Display(Name = "Gross Salary")]
    public decimal GrossSalary { get; set; }
    
    [Required]
    [Column(TypeName = "decimal(12,2)")]
    [Display(Name = "Net Salary")]
    public decimal NetSalary { get; set; }
    
    [ForeignKey("Department")]
    [Required]
    public int DepartmentId { get; set; }
    
    [Display(Name = "Department")]
    [NotMapped]
    public string DepartmentName { get; set; }
    public virtual Department Department { get; set; }

    
}