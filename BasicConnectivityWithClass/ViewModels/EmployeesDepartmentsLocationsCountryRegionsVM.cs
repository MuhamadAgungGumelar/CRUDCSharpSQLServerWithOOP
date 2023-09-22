namespace BasicConnectivityWithClass.ViewModels;

public class EmployeesDepartmentsLocationsCountryRegionsVM
{
    public int Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }
    public string Phone { get; set; }
    public int Salary { get; set; }
    public string DepartementName { get; set; }
    public string StreetAddress { get; set; }
    public string CountryName { get; set; }
    public string RegionsName { get; set; }


    public override string ToString()
    {
        return $"{Id} - {FirstName} - {LastName} - {Email} - {Phone} - {Salary} - {DepartementName} - {StreetAddress} - {CountryName} - {RegionsName}";
    }
}