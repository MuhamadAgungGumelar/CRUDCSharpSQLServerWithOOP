using BasicConnectivityWithClass;
using BasicConnectivityWithClass.Models;

namespace BasicConnectivityWithClass.Views;

public class RegionsView : GeneralView
{
    public string InsertInput()
    {
        Console.WriteLine("Insert region name");
        var name = Console.ReadLine();
        return name;
    }

    public Regions UpdateRegion()
    {
        Console.WriteLine("Insert region id");
        var id = Convert.ToInt32(Console.ReadLine());
        Console.WriteLine("Insert region name");
        var name = Console.ReadLine();

        return new Regions
        {
            Id = id,
            Name = name
        };
    }

    public Regions Delete()
    {
        Console.WriteLine("Delete Country id");
        var id = Convert.ToInt32(Console.ReadLine());


        return new Regions
        {
            Id = id
        };
    }
}