using BasicConnectivityWithClass;
using BasicConnectivityWithClass.Models;
using System.Security.Cryptography;

namespace BasicConnectivityWithClass.Views;

public class DepartmentsView : GeneralView
{
    public Departments InsertInput()
    {
        Console.WriteLine("Insert department id");
        int.TryParse(Console.ReadLine(), out int dId);
        Console.WriteLine("Insert first departmen name");
        string departmentName = Console.ReadLine();
        Console.WriteLine("Insert location id");
        int.TryParse(Console.ReadLine(), out int lId);
        Console.WriteLine("Insert manager id");
        int.TryParse(Console.ReadLine(), out int mId);

        return new Departments
        {
            Id = dId,
            Name = departmentName,
            Location_Id = lId,
            Manager_Id = mId
        };
    }

    public Departments Update()
    {
        Console.WriteLine("Insert department id");
        int.TryParse(Console.ReadLine(), out int dId);
        Console.WriteLine("Insert first departmen name");
        string departmentName = Console.ReadLine();
        Console.WriteLine("Insert location id");
        int.TryParse(Console.ReadLine(), out int lId);
        Console.WriteLine("Insert manager id");
        int.TryParse(Console.ReadLine(), out int mId);

        return new Departments
        {
            Id = dId,
            Name = departmentName,
            Location_Id = lId,
            Manager_Id = mId
        };
    }

    public Departments Delete()
    {
        Console.WriteLine("Delete Departments id");
        int.TryParse(Console.ReadLine(), out int id);


        return new Departments
        {
            Id = id
        };
    }
}