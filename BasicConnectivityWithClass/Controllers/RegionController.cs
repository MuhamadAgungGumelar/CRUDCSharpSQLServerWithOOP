using BasicConnectivityWithClass.Models;
using BasicConnectivityWithClass.Views;

namespace BasicConnectivityWithClass.Controllers;

public class RegionController
{
    private Regions _region;
    private RegionsView _regionsView;

    public RegionController(Regions region, RegionsView regionView)
    {
        _region = region;
        _regionsView = regionView;
    }

    public void GetAllController()
    {
        var results = _region.GetAll();
        if (!results.Any())
        {
            Console.WriteLine("No data found");
        }
        else
        {
            GeneralView.List(results, "regions");
        }
    }

    public void InsertController()
    {
        string input = "";
        var isTrue = true;
        while (isTrue)
        {
            try
            {
                input = _regionsView.InsertInput();
                if (string.IsNullOrEmpty(input))
                {
                    Console.WriteLine("Region name cannot be empty");
                    continue;
                }
                isTrue = false;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        var result = _region.Insert(new Regions
        {
            Name = input
        });

        GeneralView.Transaction(result);
    }

    public void UpdateController()
    {
        var region = new Regions();
        var isTrue = true;
        while (isTrue)
        {
            try
            {
                region = _regionsView.UpdateRegion();
                if (string.IsNullOrEmpty(region.Name))
                {
                    Console.WriteLine("Region name cannot be empty");
                    continue;
                }
                isTrue = false;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        var result = _region.Update(region);
        GeneralView.Transaction(result);
    }

    public void DeleteController()
    {
        var region = new Regions();
        var isTrue = true;
        while (isTrue)
        {
            try
            {
                region = _regionsView.Delete();
                if (region.Id <= 0)
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

        var result = _region.Delete(region.Id);
        CountriesView.Transaction(result);
    }
}