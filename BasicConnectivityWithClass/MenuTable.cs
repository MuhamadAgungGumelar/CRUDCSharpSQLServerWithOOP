using BasicConnectivityWithClass.Controllers;
using BasicConnectivityWithClass.Models;
using BasicConnectivityWithClass.ViewModels;
using BasicConnectivityWithClass.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasicConnectivityWithClass
{
    public class MenuTable
    {
        public static void RegionMenu()
        {
            var region = new Regions();
            var regionView = new RegionsView();

            var regionController = new RegionController(region, regionView);

            var isLoop = true;
            while (isLoop)
            {
                Console.WriteLine("1. List all regions");
                Console.WriteLine("2. Insert new region");
                Console.WriteLine("3. Update region");
                Console.WriteLine("4. Delete region");
                Console.WriteLine("10. Back");
                Console.Write("Enter your choice: ");
                var input2 = Console.ReadLine();
                switch (input2)
                {
                    case "1":
                        regionController.GetAllController();
                        break;
                    case "2":
                        regionController.InsertController();
                        break;
                    case "3":
                        regionController.UpdateController();
                        break;
                    case "4":
                        regionController.DeleteController();
                        break;
                    case "10":
                        isLoop = false;
                        break;
                    default:
                        Console.WriteLine("Invalid choice");
                        break;
                }
            }
        }

        public static void EmployeeMenu()
        {
            var employee = new Employees();
            var employeeView = new EmployeesView();

            var employeeController = new EmployeesController(employee, employeeView);

            var isLoop = true;
            while (isLoop)
            {
                Console.WriteLine("1. List all employees");
                Console.WriteLine("2. Insert new employee");
                Console.WriteLine("3. Update employee");
                Console.WriteLine("4. Delete employee");
                Console.WriteLine("10. Back");
                Console.Write("Enter your choice: ");
                var input2 = Console.ReadLine();
                switch (input2)
                {
                    case "1":
                        employeeController.GetAllController();
                        break;
                    case "2":
                        employeeController.InsertController();
                        break;
                    case "3":
                        employeeController.UpdateController();
                        break;
                    case "4":
                        employeeController.DeleteController();
                        break;
                    case "10":
                        isLoop = false;
                        break;
                    default:
                        Console.WriteLine("Invalid choice");
                        break;
                }
            }
        }

        public static void JobsMenu()
        {
            var job = new Jobs();
            var jobView = new JobsView();

            var jobController = new JobsController(job, jobView);

            var isLoop = true;
            while (isLoop)
            {
                Console.WriteLine("1. List all job");
                Console.WriteLine("2. Insert new job");
                Console.WriteLine("3. Update job");
                Console.WriteLine("4. Delete job");
                Console.WriteLine("10. Back");
                Console.Write("Enter your choice: ");
                var input2 = Console.ReadLine();
                switch (input2)
                {
                    case "1":
                        jobController.GetAllController();
                        break;
                    case "2":
                        jobController.InsertController();
                        break;
                    case "3":
                        jobController.UpdateController();
                        break;
                    case "4":
                        jobController.DeleteController();
                        break;
                    case "10":
                        isLoop = false;
                        break;
                    default:
                        Console.WriteLine("Invalid choice");
                        break;
                }
            }
        }

        public static void LocationsMenu()
        {
            var location = new Locations();
            var locationView = new LocationsView();

            var locationController = new LocationsController(location, locationView);

            var isLoop = true;
            while (isLoop)
            {
                Console.WriteLine("1. List all location");
                Console.WriteLine("2. Insert new location");
                Console.WriteLine("3. Update location");
                Console.WriteLine("4. Delete location");
                Console.WriteLine("10. Back");
                Console.Write("Enter your choice: ");
                var input2 = Console.ReadLine();
                switch (input2)
                {
                    case "1":
                        locationController.GetAllController();
                        break;
                    case "2":
                        locationController.InsertController();
                        break;
                    case "3":
                        locationController.UpdateController();
                        break;
                    case "4":
                        locationController.DeleteController();
                        break;
                    case "10":
                        isLoop = false;
                        break;
                    default:
                        Console.WriteLine("Invalid choice");
                        break;
                }
            }
        }

        public static void HistoriesMenu()
        {
            var history = new Histories();
            var historyView = new HistoriesView();

            var historyController = new HistoriesController(history, historyView);

            var isLoop = true;
            while (isLoop)
            {
                Console.WriteLine("1. List all history");
                Console.WriteLine("2. Insert new history");
                Console.WriteLine("3. Update history");
                Console.WriteLine("4. Delete history");
                Console.WriteLine("10. Back");
                Console.Write("Enter your choice: ");
                var input2 = Console.ReadLine();
                switch (input2)
                {
                    case "1":
                        historyController.GetAllController();
                        break;
                    case "2":
                        historyController.InsertController();
                        break;
                    case "3":
                        historyController.UpdateController();
                        break;
                    case "4":
                        historyController.DeleteController();
                        break;
                    case "10":
                        isLoop = false;
                        break;
                    default:
                        Console.WriteLine("Invalid choice");
                        break;
                }
            }
        }

        public static void DepartmentsMenu()
        {
            var department = new Departments();
            var departmentView = new DepartmentsView();

            var departmentController = new DepartmentsController(department, departmentView);

            var isLoop = true;
            while (isLoop)
            {
                Console.WriteLine("1. List all department");
                Console.WriteLine("2. Insert new department");
                Console.WriteLine("3. Update department");
                Console.WriteLine("4. Delete department");
                Console.WriteLine("10. Back");
                Console.Write("Enter your choice: ");
                var input2 = Console.ReadLine();
                switch (input2)
                {
                    case "1":
                        departmentController.GetAllController();
                        break;
                    case "2":
                        departmentController.InsertController();
                        break;
                    case "3":
                        departmentController.UpdateController();
                        break;
                    case "4":
                        departmentController.DeleteController();
                        break;
                    case "10":
                        isLoop = false;
                        break;
                    default:
                        Console.WriteLine("Invalid choice");
                        break;
                }
            }
        }

        public static void CountriesMenu()
        {
            var country = new Countries();
            var countryView = new CountriesView();

            var countryController = new CountriesController(country, countryView);

            var isLoop = true;
            while (isLoop)
            {
                Console.WriteLine("1. List all country");
                Console.WriteLine("2. Insert new country");
                Console.WriteLine("3. Update country");
                Console.WriteLine("4. Delete country");
                Console.WriteLine("10. Back");
                Console.Write("Enter your choice: ");
                var input2 = Console.ReadLine();
                switch (input2)
                {
                    case "1":
                        countryController.GetAllController();
                        break;
                    case "2":
                        countryController.InsertController();
                        break;
                    case "3":
                        countryController.UpdateController();
                        break;
                    case "4":
                        countryController.DeleteController();
                        break;
                    case "10":
                        isLoop = false;
                        break;
                    default:
                        Console.WriteLine("Invalid choice");
                        break;
                }
            }
        }

        public static void JoinRegionsCountriesLocations()
        {
            var country3 = new Countries();
            var region3 = new Regions();
            var location3 = new Locations();

            var getCountry = country3.GetAll();
            var getRegion = region3.GetAll();
            var getLocation = location3.GetAll();

            var resultJoin = (from r in getRegion
                              join c in getCountry on r.Id equals c.RegionId
                              join l in getLocation on c.Id equals l.Country_Id
                              select new RegionAndCountryVM
                              {
                                  CountryId = c.Id,
                                  CountryName = c.Name,
                                  RegionId = r.Id,
                                  RegionName = r.Name,
                                  City = l.City
                              }).ToList();

            var resultJoin2 = getRegion.Join(getCountry,
                                             r => r.Id,
                                             c => c.RegionId,
                                             (r, c) => new { r, c })
                                       .Join(getLocation,
                                             rc => rc.c.Id,
                                             l => l.Country_Id,
                                             (rc, l) => new RegionAndCountryVM
                                             {
                                                 CountryId = rc.c.Id,
                                                 CountryName = rc.c.Name,
                                                 RegionId = rc.r.Id,
                                                 RegionName = rc.r.Name,
                                                 City = l.City
                                             }).ToList();
            GeneralView.List(resultJoin2, "regions and countries");
        }

        public static void JoinEmployeesDepartmentsLocationsCountries()
        {
            var employee = new Employees();
            var department = new Departments();
            var location4 = new Locations();
            var country4 = new Countries();
            var region4 = new Regions();


            var getEmployee = employee.GetAll();
            var getDepartment = department.GetAll();
            var getLocation2 = location4.GetAll();
            var getCountry2 = country4.GetAll();
            var getRegion2 = region4.GetAll();

            var resultsJoin = getRegion2.Join(getCountry2,
                                             r => r.Id,
                                             c => c.RegionId,
                                             (r, c) => new { r, c })
                                       .Join(getLocation2,
                                             rc => rc.c.Id,
                                             l => l.Country_Id,
                                             (rc, l) => new { rc.r, rc.c, l })
                                       .Join(getDepartment,
                                             rcl => rcl.l.Id,
                                             d => d.Id,
                                             (rcl, d) => new { rcl.r, rcl.c, rcl.l, d })
                                       .Join(getEmployee,
                                              rcld => rcld.d.Id,
                                              e => e.Id,
                                              (rcld, e) => new EmployeesDepartmentsLocationsCountryRegionsVM
                                              {
                                                  Id = e.Id,
                                                  FirstName = e.First_name,
                                                  LastName = e.Last_Name,
                                                  Email = e.Email,
                                                  Phone = e.Phone_Number,
                                                  Salary = e.Salary,
                                                  DepartementName = rcld.d.Name,
                                                  StreetAddress = rcld.l.Street_Address,
                                                  CountryName = rcld.c.Name,
                                                  RegionsName = rcld.r.Name
                                              }).ToList();
            GeneralView.List(resultsJoin, "Employee dan kawan-kawan");
        }

        public static void DepartmentsAndEmployeesSummary()
        {
            var employee5 = new Employees();
            var department5 = new Departments();

            var getEmployee5 = employee5.GetAll();
            var getDepartment5 = department5.GetAll();

            var resultsJoin2 = getEmployee5.Join(getDepartment5,
                e => e.Department_Id,
                d => d.Id,
                (e, d) => new { e, d })
                .GroupBy(ed => new { ed.d.Name })
                .Where(group => group.Count() > 3)
                .Select(group => new
                {
                    DepartmentName = group.Key.Name,
                    TotalEmployee = group.Count(),
                    MinSalary = group.Min(ed => ed.e.Salary),
                    MaxSalary = group.Max(ed => ed.e.Salary),
                    AverageSalary = group.Average(ed => ed.e.Salary)
                })
                .ToList();

            GeneralView.List(resultsJoin2, "Department dan Employee Summary");
        }

        public static void RegionsWithWhereStatement()
        {
            var region2 = new Regions();
            string input2 = Console.ReadLine();
            var result = region2.GetAll().Where(r => r.Name.Contains(input2)).ToList();
            GeneralView.List(result, "regions");
        }

    }
}
