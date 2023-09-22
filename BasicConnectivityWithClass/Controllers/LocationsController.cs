using BasicConnectivityWithClass.Models;
using BasicConnectivityWithClass.Views;

namespace BasicConnectivityWithClass.Controllers;

public class LocationsController
{
    private Locations _location;
    private LocationsView _locationView;

    public LocationsController(Locations location, LocationsView locationView)
    {
        _location = location;
        _locationView = locationView;
    }

    public void GetAllController()
    {
        var results = _location.GetAll();
        if (!results.Any())
        {
            Console.WriteLine("No data found");
        }
        else
        {
            LocationsView.List(results, "locations");
        }
    }

    public void InsertController()
    {
        var location = new Locations();
        var isTrue = true;
        while (isTrue)
        {
            try
            {
                location = _locationView.InsertInput();
                if (string.IsNullOrEmpty(_location.City))
                {
                    Console.WriteLine("Locations name cannot be empty");
                    continue;
                }
                isTrue = false;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        var result = _location.Insert(location);

        LocationsView.Transaction(result);
    }

    public void UpdateController()
    {
        var location = new Locations();
        var isTrue = true;
        while (isTrue)
        {
            try
            {
                location = _locationView.Update();
                if (string.IsNullOrEmpty(location.City))
                {
                    Console.WriteLine("Locations name cannot be empty");
                    continue;
                }
                isTrue = false;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        var result = _location.Update(location);
        LocationsView.Transaction(result);
    }

    public void DeleteController()
    {
        var location = new Locations();
        var isTrue = true;
        while (isTrue)
        {
            try
            {
                location = _locationView.Delete();
                if (location.Id <=0 )
                {
                    Console.WriteLine("Country Id cannot be empty");
                    continue;
                }
                isTrue = false;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        var result = _location.Delete(location.Id);
        CountriesView.Transaction(result);
    }
}