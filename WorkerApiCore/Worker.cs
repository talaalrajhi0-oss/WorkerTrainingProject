using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

public class Worker
{
    [Key]
    public int WorkerId { get; set; }

    [Required]
    [MaxLength(10)]
    public string Name { get; set; }

    [MaxLength(20)]
    public string PhoneNum { get; set; }

    [Column("Salary")]
    public double Salary { get; set; }
}