using BasicConnectivityWithClass.Models;
using BasicConnectivityWithClass.Views;

namespace BasicConnectivityWithClass.Controllers;

public class CountriesController
{
    private Countries _country;
    private CountriesView _countryView;

    public CountriesController(Countries countryView, CountriesView countryViewView)
    {
        _country = countryView;
        _countryView = countryViewView;
    }

    public void GetAllController()
    {
        var results = _country.GetAll();
        if (!results.Any())
        {
            Console.WriteLine("No data found");
        }
        else
        {
            CountriesView.List(results, "country");
        }
    }

    public void InsertController()
    {
        var country = new Countries();
        var isTrue = true;
        while (isTrue)
        {
            try
            {
                country = _countryView.InsertInput();
                if (string.IsNullOrEmpty(country.Name))
                {
                    Console.WriteLine("Country name cannot be empty");
                    continue;
                }
                isTrue = false;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        var result = _country.Insert(country);

        CountriesView.Transaction(result);
    }

    public void UpdateController()
    {
        var country = new Countries();
        var isTrue = true;
        while (isTrue)
        {
            try
            {
                country = _countryView.Update();
                if (string.IsNullOrEmpty(country.Name))
                {
                    Console.WriteLine("Country name cannot be empty");
                    continue;
                }
                isTrue = false;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        var result = _country.Update(country);
        CountriesView.Transaction(result);
    }

    public void DeleteController()
    {
        var country = new Countries();
        var isTrue = true;
        while (isTrue)
        {
            try
            {
                country = _countryView.Delete();
                if (string.IsNullOrEmpty(country.Id))
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

        var result = _country.Delete(country.Id);
        CountriesView.Transaction(result);
    }
}