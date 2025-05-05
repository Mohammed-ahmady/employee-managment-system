using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EmpApp.Models;

[Table("Department", Schema = "dbo") ]

public class Department
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    [Display(Name = "Department ID")]
    public int DepartmentId { get; set; }    
    
    
    [Display(Name = "Department Name")]
    [Required]
    [Column(TypeName = "varchar(150)")]
    public string DepartmentName { get; set; } = string.Empty;

    
    [Column(TypeName = "varchar(5)")]
    [Display(Name = "Department Abbreviation")]
    public string DepartmentAbbr { get; set; }
}