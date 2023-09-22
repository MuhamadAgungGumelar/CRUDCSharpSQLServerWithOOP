using BasicConnectivityWithClass;
using BasicConnectivityWithClass.Models;
using System.Security.Cryptography;

namespace BasicConnectivityWithClass.Views;

public class HistoriesView : GeneralView
{
    public Histories InsertInput()
    {
        Console.WriteLine("Insert start date");
        DateTime.TryParse(Console.ReadLine(), out DateTime startDate);
        Console.WriteLine("Insert employee id");
        int.TryParse(Console.ReadLine(), out int eId);
        Console.WriteLine("Insert end time");
        DateTime.TryParse(Console.ReadLine(), out DateTime endTime);
        Console.WriteLine("Insert department id");
        int.TryParse(Console.ReadLine(), out int dId);
        Console.WriteLine("Insert job id");
        string jId = Console.ReadLine();

        return new Histories
        {
            Start_Date = startDate,
            Employee_Id = eId,
            End_Time = endTime,
            Departments_Id = dId,
            Jobs_Id = jId
        };
    }

    public Histories Update()
    {
        Console.WriteLine("Insert start date");
        DateTime.TryParse(Console.ReadLine(), out DateTime startDate);
        Console.WriteLine("Insert employee id");
        int.TryParse(Console.ReadLine(), out int eId);
        Console.WriteLine("Insert end time");
        DateTime.TryParse(Console.ReadLine(), out DateTime endTime);
        Console.WriteLine("Insert department id");
        int.TryParse(Console.ReadLine(), out int dId);
        Console.WriteLine("Insert job id");
        string jId = Console.ReadLine();

        return new Histories
        {
            Start_Date = startDate,
            Employee_Id = eId,
            End_Time = endTime,
            Departments_Id = dId,
            Jobs_Id = jId
        };
    }

    public Histories Delete()
    {
        Console.WriteLine("Delete Country id");
        int.TryParse(Console.ReadLine(), out int dId);


        return new Histories
        {
            Departments_Id = dId
        };
    }
}