using System;
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

    private double salary;

    [Column("Salary")]
    public double Salary
    {
        get { return salary; }
        set
        {
            if (value >= 0)
                salary = value;
            else
                throw new ArgumentException("Salary cannot be negative.");
        }
    }

    public Worker() { }

    public Worker(int id, string name, string phonenum, double salary)
    {
        WorkerId = id;
        Name = name;
        PhoneNum = phonenum;
        Salary = salary;
    }

    public void Display()
    {
        Console.WriteLine($"ID: {WorkerId}");
        Console.WriteLine($"Name: {Name}");
        Console.WriteLine($"Phone: {PhoneNum}");
        Console.WriteLine($"Salary: {Salary}");
    }
}
