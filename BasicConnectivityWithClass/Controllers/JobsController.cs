using BasicConnectivityWithClass.Models;
using BasicConnectivityWithClass.Views;

namespace BasicConnectivityWithClass.Controllers;

public class JobsController
{
    private Jobs _job;
    private JobsView _jobView;

    public JobsController(Jobs job, JobsView jobView)
    {
        _job = job;
        _jobView = jobView;
    }

    public void GetAllController()
    {
        var results = _job.GetAll();
        if (!results.Any())
        {
            Console.WriteLine("No data found");
        }
        else
        {
            JobsView.List(results, "Jobs");
        }
    }

    public void InsertController()
    {
        var job = new Jobs();
        var isTrue = true;
        while (isTrue)
        {
            try
            {
                job = _jobView.InsertInput();
                if (string.IsNullOrEmpty(job.Title))
                {
                    Console.WriteLine("Job Title cannot be empty");
                    continue;
                }
                isTrue = false;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        var result = _job.Insert(job);

        JobsView.Transaction(result);
    }

    public void UpdateController()
    {
        var job = new Jobs();
        var isTrue = true;
        while (isTrue)
        {
            try
            {
                job = _jobView.Update();
                if (string.IsNullOrEmpty(job.Title))
                {
                    Console.WriteLine("Job name cannot be empty");
                    continue;
                }
                isTrue = false;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        var result = _job.Update(job);
        JobsView.Transaction(result);
    }

    public void DeleteController()
    {
        var job = new Jobs();
        var isTrue = true;
        while (isTrue)
        {
            try
            {
                job = _jobView.Delete();
                if (string.IsNullOrEmpty(job.Id))
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

        var result = _job.Delete(job.Id);
        CountriesView.Transaction(result);
    }
}