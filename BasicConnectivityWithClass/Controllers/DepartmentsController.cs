using BasicConnectivityWithClass.Models;
using BasicConnectivityWithClass.Views;

namespace BasicConnectivityWithClass.Controllers;

public class DepartmentsController
{
    private Departments _department;
    private DepartmentsView _departmentView;

    public DepartmentsController(Departments department, DepartmentsView departmentView)
    {
        _department = department;
        _departmentView = departmentView;
    }

    public void GetAllController()
    {
        var results = _department.GetAll();
        if (!results.Any())
        {
            Console.WriteLine("No data found");
        }
        else
        {
            DepartmentsView.List(results, "department");
        }
    }

    public void InsertController()
    {
        var department = new Departments();
        var isTrue = true;
        while (isTrue)
        {
            try
            {
                department = _departmentView.InsertInput();
                if (string.IsNullOrEmpty(department.Name))
                {
                    Console.WriteLine("Department name cannot be empty");
                    continue;
                }
                isTrue = false;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        var result = _department.Insert(department);

        DepartmentsView.Transaction(result);
    }

    public void UpdateController()
    {
        var department = new Departments();
        var isTrue = true;
        while (isTrue)
        {
            try
            {
                department = _departmentView.Update();
                if (string.IsNullOrEmpty(department.Name))
                {
                    Console.WriteLine("Department name cannot be empty");
                    continue;
                }
                isTrue = false;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        var result = _department.Update(department);
        EmployeesView.Transaction(result);
    }

    public void DeleteController()
    {
        var department = new Departments();
        var isTrue = true;
        while (isTrue)
        {
            try
            {
                department = _departmentView.Delete();
                if (department.Id <= 0)
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

        var result = _department.Delete(department.Id);
        CountriesView.Transaction(result);
    }
}