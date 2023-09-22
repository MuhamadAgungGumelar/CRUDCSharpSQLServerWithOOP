using BasicConnectivityWithClass;
using BasicConnectivityWithClass.Controllers;
using BasicConnectivityWithClass.Views;
using BasicConnectivityWithClass.Models;
using BasicConnectivityWithClass.ViewModels;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics.Metrics;

namespace BasicConnectivity;

public class Program
{
    private static void Main()
    {
        var choice = true;
        while (choice)
        {
            Console.WriteLine("1. Region CRUD");
            Console.WriteLine("2. Employee CRUD");
            Console.WriteLine("3. Job CRUD");
            Console.WriteLine("4. Location CRUD");
            Console.WriteLine("5. History CRUD");
            Console.WriteLine("6. Department CRUD");
            Console.WriteLine("7. Country CRUD");
            Console.WriteLine("8. List regions with Where");
            Console.WriteLine("9. Join tables regions and countries and locations");
            Console.WriteLine("10. Join tables employees and departments and locations and countries");
            Console.WriteLine("11. Department dan Employee Summary");
            Console.WriteLine("0. Exit");
            Console.Write("Enter your choice: ");
            var input = Console.ReadLine();
            choice = Menu(input);
        }
    }

    public static bool Menu(string input)
    {
        switch (input)
        {
            case "1":
                MenuTable.RegionMenu();
                break;
            case "2":
                MenuTable.EmployeeMenu();
                break;
            case "3":
                MenuTable.JobsMenu();
                break;
            case "4":
                MenuTable.LocationsMenu();
                break;
            case "5":
                MenuTable.HistoriesMenu();
                break;
            case "6":
                MenuTable.DepartmentsMenu();
                break;
            case "7":
                MenuTable.CountriesMenu();
                break;
            case "8":
                MenuTable.RegionsWithWhereStatement();
                break;
            case "9":
                MenuTable.JoinRegionsCountriesLocations();
                break;
            case "10":
                MenuTable.JoinEmployeesDepartmentsLocationsCountries();
                break;
            case "11":
                MenuTable.DepartmentsAndEmployeesSummary();
                break;
            case "0":
                return false;
            default:
                Console.WriteLine("Invalid choice");
                break;
        }
        return true;
    }
}

