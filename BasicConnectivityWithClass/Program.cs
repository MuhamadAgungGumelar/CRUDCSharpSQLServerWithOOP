using BasicConnectivityWithClass;
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
            Console.WriteLine("1. List all regions");
            Console.WriteLine("2. List all countries");
            Console.WriteLine("3. List all locations");
            Console.WriteLine("4. List regions with Where");
            Console.WriteLine("5. Join tables regions and countries and locations");
            Console.WriteLine("6. Join tables emplyees and departments and locations and countries and locations");
            Console.WriteLine("7. Department dan Employee Summary");
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
                var region = new Regions();
                var regions = region.GetAll();
                GeneralMenu.List(regions, "regions");
                break;
            case "2":
                var country = new Countries();
                var countries = country.GetAll();
                GeneralMenu.List(countries, "countries");
                break;
            case "3":
                var location = new Locations();
                var locations = location.GetAll();
                GeneralMenu.List(locations, "locations");
                break;
            case "4":
                var region2 = new Regions();
                string input2 = Console.ReadLine();
                var result = region2.GetAll().Where(r => r.Name.Contains(input2)).ToList();
                GeneralMenu.List(result, "regions");
                break;
            case "5":
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
                GeneralMenu.List(resultJoin2, "regions and countries");
                break;
            case "6":
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
                GeneralMenu.List(resultsJoin, "Employee dan kawan-kawan");
                break;
            case "7":
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

                GeneralMenu.List(resultsJoin2, "Department dan Employee Summary");
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