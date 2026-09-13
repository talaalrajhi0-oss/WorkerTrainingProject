using Microsoft.EntityFrameworkCore;

class Program
{
    // Display all workers
    static void DisplayWorkers(AppDbContext db)
    {
        Console.WriteLine("\nWorkers:");

        foreach (var worker in db.Workers.ToList())
        {
            worker.Display();
            Console.WriteLine("----------------");
        }
    }

    // Find worker by ID
    static void FindWorker(AppDbContext db)
    {
        Console.Write("Enter Worker ID: ");
        int id = Convert.ToInt32(Console.ReadLine());

        var worker = db.Workers.FirstOrDefault(w => w.WorkerId == id);

        if (worker != null)
        {
            worker.Display();
        }
        else
        {
            Console.WriteLine("Worker not found.");
        }
    }

    // Add new worker
    static void AddWorker(AppDbContext db)
    {
        Console.Write("Enter Worker ID: ");
        int id = Convert.ToInt32(Console.ReadLine());

        Console.Write("Enter Name: ");
        string name = Console.ReadLine() ?? "";

        if (string.IsNullOrWhiteSpace(name))
        {
            throw new ArgumentException("Name cannot be empty.");
        }

        Console.Write("Enter Phone Number: ");
        string phonenum = Console.ReadLine() ?? "";

        Console.Write("Enter Salary: ");
        double salary = Convert.ToDouble(Console.ReadLine());

        var newWorker = new Worker(id, name, phonenum, salary);

        db.Workers.Add(newWorker);
        db.SaveChanges();

        Console.WriteLine("Worker added successfully!");
    }

    // Delete worker by ID
    static void DeleteWorker(AppDbContext db)
    {
        Console.Write("Enter Worker ID to delete: ");
        int id = Convert.ToInt32(Console.ReadLine());

        var worker = db.Workers.FirstOrDefault(w => w.WorkerId == id);

        if (worker == null)
        {
            Console.WriteLine("Worker not found.");
            return;
        }

        db.Workers.Remove(worker);
        db.SaveChanges();

        Console.WriteLine("Worker deleted successfully!");
    }

    static void Main(string[] args)
    {
        using var db = new AppDbContext();

        bool running = true;

        while (running)
        {
            Console.WriteLine("\nWorker System");
            Console.WriteLine("1. Display Worker");
            Console.WriteLine("2. Find Worker");
            Console.WriteLine("3. Add Worker");
            Console.WriteLine("4. Delete Worker");
            Console.WriteLine("5. Exit");
            Console.Write("Choose an option: ");

            string? choice = Console.ReadLine();

            try
            {
                if (choice == "1")
                {
                    DisplayWorkers(db);
                }
                else if (choice == "2")
                {
                    FindWorker(db);
                }
                else if (choice == "3")
                {
                    AddWorker(db);
                }
                else if (choice == "4")
                {
                    DeleteWorker(db);
                }
                else if (choice == "5")
                {
                    running = false;
                    Console.WriteLine("Bye!");
                }
                else
                {
                    Console.WriteLine("Invalid option.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }
    }
}