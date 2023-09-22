using BasicConnectivityWithClass.Models;
using BasicConnectivityWithClass.Views;

namespace BasicConnectivityWithClass.Controllers;

public class HistoriesController
{
    private Histories _history;
    private HistoriesView _historyeView;

    public HistoriesController(Histories history, HistoriesView _historyView)
    {
        _history = history;
        _historyeView = _historyView;
    }

    public void GetAllController()
    {
        var results = _history.GetAll();
        if (!results.Any())
        {
            Console.WriteLine("No data found");
        }
        else
        {
            HistoriesView.List(results, "histories");
        }
    }

    public void InsertController()
    {
        var history = new Histories();
        var isTrue = true;
        while (isTrue)
        {
            try
            {
                history = _historyeView.InsertInput();
                if (string.IsNullOrEmpty(history.Jobs_Id))
                {
                    Console.WriteLine("History name cannot be empty");
                    continue;
                }
                isTrue = false;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        var result = _history.Insert(history);

        HistoriesView.Transaction(result);
    }

    public void UpdateController()
    {
        var history = new Histories();
        var isTrue = true;
        while (isTrue)
        {
            try
            {
                history = _historyeView.Update();
                if (string.IsNullOrEmpty(history.Jobs_Id))
                {
                    Console.WriteLine("History name cannot be empty");
                    continue;
                }
                isTrue = false;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        var result = _history.Update(history);
        HistoriesView.Transaction(result);
    }

    public void DeleteController()
    {
        var history = new Histories();
        var isTrue = true;
        while (isTrue)
        {
            try
            {
                history = _historyeView.Delete();
                if (history.Departments_Id <= 0)
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

        var result = _history.Delete(history.Departments_Id);
        CountriesView.Transaction(result);
    }
}