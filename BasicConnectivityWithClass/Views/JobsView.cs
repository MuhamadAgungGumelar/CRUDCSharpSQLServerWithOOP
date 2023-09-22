using BasicConnectivityWithClass;
using BasicConnectivityWithClass.Models;
using System.Security.Cryptography;

namespace BasicConnectivityWithClass.Views;

public class JobsView : GeneralView
{
    public Jobs InsertInput()
    {
        Console.WriteLine("Insert job id");
        string id = Console.ReadLine();
        Console.WriteLine("Insert title");
        string title = Console.ReadLine();
        Console.WriteLine("Insert min_salary");
        int.TryParse(Console.ReadLine(), out int min_salary);
        Console.WriteLine("Insert max_salary");
        int.TryParse(Console.ReadLine(), out int max_salary);


        return new Jobs
        {
            Id = id,
            Title = title,
            Min_Salary = min_salary,
            Max_Salary = max_salary,
        };
    }

    public Jobs Update()
    {
        Console.WriteLine("Insert job id");
        string id = Console.ReadLine();
        Console.WriteLine("Insert title");
        string title = Console.ReadLine();
        Console.WriteLine("Insert min_salary");
        int.TryParse(Console.ReadLine(), out int min_salary);
        Console.WriteLine("Insert max_salary");
        int.TryParse(Console.ReadLine(), out int max_salary);


        return new Jobs
        {
            Id = id,
            Title = title,
            Min_Salary = min_salary,
            Max_Salary = max_salary,
        };
    }

    public Jobs Delete()
    {
        Console.WriteLine("Delete Country id");
        string id = Console.ReadLine();


        return new Jobs
        {
            Id = id
        };
    }
}