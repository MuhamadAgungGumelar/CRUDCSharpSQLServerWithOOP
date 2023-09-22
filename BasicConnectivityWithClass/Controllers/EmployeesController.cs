using BasicConnectivityWithClass.Models;
using BasicConnectivityWithClass.Views;

namespace BasicConnectivityWithClass.Controllers;

public class EmployeesController
{
    private Employees _employee;
    private EmployeesView _employeeView;

    public EmployeesController(Employees employee, EmployeesView employeeView)
    {
        _employee = employee;
        _employeeView = employeeView;
    }

    public void GetAllController()
    {
        var results = _employee.GetAll();
        if (!results.Any())
        {
            Console.WriteLine("No data found");
        }
        else
        {
            EmployeesView.List(results, "employees");
        }
    }

    public void InsertController()
    {
        var employee = new Employees();
        var isTrue = true;
        while (isTrue)
        {
            try
            {
                employee = _employeeView.InsertInput();
                if (string.IsNullOrEmpty(employee.First_name))
                {
                    Console.WriteLine("Employee name cannot be empty");
                    continue;
                }
                isTrue = false;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        var result = _employee.Insert(employee);

        EmployeesView.Transaction(result);
    }

    public void UpdateController()
    {
        var employee = new Employees();
        var isTrue = true;
        while (isTrue)
        {
            try
            {
                employee = _employeeView.UpdateRegion();
                if (string.IsNullOrEmpty(employee.First_name))
                {
                    Console.WriteLine("Employee name cannot be empty");
                    continue;
                }
                isTrue = false;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        var result = _employee.Update(employee);
        EmployeesView.Transaction(result);
    }

    public void DeleteController()
    {
        var employee = new Employees();
        var isTrue = true;
        while (isTrue)
        {
            try
            {
                employee = _employeeView.Delete();
                if (employee.Id <= 0)
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

        var result = _employee.Delete(employee.Id);
        CountriesView.Transaction(result);
    }
}