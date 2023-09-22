using BasicConnectivityWithClass;
using BasicConnectivityWithClass.Models;
using System.Security.Cryptography;

namespace BasicConnectivityWithClass.Views;

public class EmployeesView : GeneralView
{
    public Employees InsertInput()
    {
        Console.WriteLine("Insert employee id");
        int.TryParse(Console.ReadLine(), out int id);
        Console.WriteLine("Insert first name");
        string firstName = Console.ReadLine();
        Console.WriteLine("Insert last name");
        string lastName = Console.ReadLine();
        Console.WriteLine("Insert email");
        string email = Console.ReadLine();
        Console.WriteLine("Insert phone number");
        string phone = Console.ReadLine();
        Console.WriteLine("Insert hire date");
        DateTime.TryParse(Console.ReadLine(), out DateTime hire_date);
        Console.WriteLine("Insert salary");
        int.TryParse(Console.ReadLine(), out int salary);
        Console.WriteLine("Insert comission pct");
        decimal.TryParse(Console.ReadLine(), out decimal comission);
        Console.WriteLine("Insert manager id");
        int.TryParse(Console.ReadLine(), out int mId);
        Console.WriteLine("Insert job id");
        string jId = Console.ReadLine();
        Console.WriteLine("Insert department id");
        int.TryParse(Console.ReadLine(), out int dId);

        return new Employees
        {
            Id = id,
            First_name = firstName,
            Last_Name = lastName,
            Email = email,
            Phone_Number = phone,
            Hire_Date = hire_date,
            Salary = salary,
            Comission_Pct = comission,
            Manager_Id = mId,
            Jobs_Id = jId,
            Department_Id = dId
        };
    }

    public Employees UpdateRegion()
    {
        Console.WriteLine("Insert employee id");
        int.TryParse(Console.ReadLine(), out int id);
        Console.WriteLine("Insert first name");
        string firstName = Console.ReadLine();
        Console.WriteLine("Insert last name");
        string lastName = Console.ReadLine();
        Console.WriteLine("Insert email");
        string email = Console.ReadLine();
        Console.WriteLine("Insert phone number");
        string phone = Console.ReadLine();
        Console.WriteLine("Insert hire date");
        DateTime.TryParse(Console.ReadLine(), out DateTime hire_date);
        Console.WriteLine("Insert salary");
        int.TryParse(Console.ReadLine(), out int salary);
        Console.WriteLine("Insert comission pct");
        decimal.TryParse(Console.ReadLine(), out decimal comission);
        Console.WriteLine("Insert manager id");
        int.TryParse(Console.ReadLine(), out int mId);
        Console.WriteLine("Insert job id");
        string jId = Console.ReadLine();
        Console.WriteLine("Insert department id");
        int.TryParse(Console.ReadLine(), out int dId);

        return new Employees
        {
            Id = id,
            First_name = firstName,
            Last_Name = lastName,
            Email = email,
            Phone_Number = phone,
            Hire_Date = hire_date,
            Salary = salary,
            Comission_Pct = comission,
            Manager_Id = mId,
            Jobs_Id = jId,
            Department_Id = dId
        };
    }

    public Employees Delete()
    {
        Console.WriteLine("Delete Departments id");
        int.TryParse(Console.ReadLine(), out int id);


        return new Employees
        {
            Id = id
        };
    }
}