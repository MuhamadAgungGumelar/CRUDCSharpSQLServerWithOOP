using BasicConnectivityWithClass;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasicConnectivityWithClass
{
    internal class BackUpProgram
    {


        /* 
            var region = new Regions(); 
        
            var getAllRegion = region.GetAll();

             if (getAllRegion.Count > 0)
             {
                 foreach (var region1 in getAllRegion)
                 {
                     Console.WriteLine($"Id: {region1.Id}, Name: {region1.Name}");
                 }
             }
             else
             {
                 Console.WriteLine("No data found");
             }
        */

        /*
            var region = new Region();

            var getAllRegion = region.GetById(3);

            if (getAllRegion.Id > 0) // Memeriksa apakah objek memiliki data dengan ID yang ditemukan
            {
                Console.WriteLine(getAllRegion.Id);
                Console.WriteLine(getAllRegion.Name);
            }
            else
            {
                Console.WriteLine("Data not found");
            }
        */

        /*
             var insertResult = region.Insert("Wkwkwkwland");
             int.TryParse(insertResult, out int result);
             if (result > 0)
             {
                 Console.WriteLine("Insert Success");
             }
             else 
             {
                 Console.WriteLine("Insert Failed");
                 Console.WriteLine(insertResult);
             }
        */

        /*
             var updateResult = region.Update(13, "Wakanda");
             int.TryParse(updateResult, out int result);
             if (result > 0)
             {
                 Console.WriteLine("Update Success");
             }
             else 
             {
                 Console.WriteLine("Update Failed");
                 Console.WriteLine(updateResult);
             }
        */

        /*
             var deleteResult = region.Delete(13);
             int.TryParse(deleteResult, out int result);
             if (result > 0)
             {
                 Console.WriteLine("Delete Success");
             }
             else 
             {
                 Console.WriteLine("Delete Failed");
                 Console.WriteLine(deleteResult);
             }
        */



        /*
            var country = new Countries(); 
        
            var getAllCountry = country.GetAll();

             if (getAllCountry.Count > 0)
             {
                 foreach (var country1 in getAllCountry)
                 {
                     Console.WriteLine($"Id: {country1.Id}, Name: {country1.Name}, Region_Id: {country1.RegionId}");
                 }
             }
             else
             {
                 Console.WriteLine("No data found");
             }
        */

        /*
            var getAllCountry = country.GetById(3);

            if (getAllCountry.RegionId > 0) // Memeriksa apakah objek memiliki data dengan ID yang ditemukan
            {
                Console.WriteLine(getAllCountry.Id);
                Console.WriteLine(getAllCountry.Name);
                Console.WriteLine(getAllCountry.RegionId);
            }
            else
            {
                Console.WriteLine("Data not found");
            }
        */

        /*
             var insertResult = country.Insert("0", "+62land", 4);
             int.TryParse(insertResult, out int result);
             if (result > 0)
             {
                 Console.WriteLine("Insert Success");
             }
             else 
             {
                 Console.WriteLine("Insert Failed");
                 Console.WriteLine(insertResult);
             }
        */

        /*
             var updateResult = country.Update("0", "Konoha", 7);
             int.TryParse(updateResult, out int result);
             if (result > 0)
             {
                 Console.WriteLine("Update Success");
             }
             else 
             {
                 Console.WriteLine("Update Failed");
                 Console.WriteLine(updateResult);
             }
        */

        /*
             var deleteResult = country.Delete("1");
             int.TryParse(deleteResult, out int result);
             if (result > 0)
             {
                 Console.WriteLine("Delete Success");
             }
             else 
             {
                 Console.WriteLine("Delete Failed");
                 Console.WriteLine(deleteResult);
             }
        */



        /*
            var location = new Locations(); 
        
            var getAllLocation = location.GetAll();

             if (getAllLocation.Count > 0)
             {
                 foreach (var location1 in getAllLocation)
                 {
                     Console.WriteLine($"Id: {location1.Id}, Street_Address: {location1.Street_Address}, Postal_Code: {location1.Postal_Code}, City: {location1.City}, State_Province: {location1.State_Province}, Country_Id: {location1.Country_Id}");
                 }
             }
             else
             {
                 Console.WriteLine("No data found");
             }
        */

        /*
            var getAllLocation = location.GetById(3);

            if (getAllLocation.Id > 0) // Memeriksa apakah objek memiliki data dengan ID yang ditemukan
            {
                Console.WriteLine(getAllLocation.Id);
                Console.WriteLine(getAllLocation.Street_Address);
                Console.WriteLine(getAllLocation.Postal_Code);
                Console.WriteLine(getAllLocation.City);
                Console.WriteLine(getAllLocation.State_Province);
                Console.WriteLine(getAllLocation.Country_Id);

            }
            else
            {
                Console.WriteLine("Data not found");
            }
        */

        /*
             var insertResult = location.Insert(11,"Lembang", "40391", "Bandung", "Jawa Barat", "1");
             int.TryParse(insertResult, out int result);
             if (result > 0)
             {
                 Console.WriteLine("Insert Success");
             }
             else 
             {
                 Console.WriteLine("Insert Failed");
                 Console.WriteLine(insertResult);
             }
        */

        /*
             var updateResult = location.Update(6, "Jl. gerlong", "35424", "Wakanda", "wkwkland", "1");
             int.TryParse(updateResult, out int result);
             if (result > 0)
             {
                 Console.WriteLine("Update Success");
             }
             else 
             {
                 Console.WriteLine("Update Failed");
                 Console.WriteLine(updateResult);
             }
        */

        /*
            var deleteResult = location.Delete(1);
                int.TryParse(deleteResult, out int result);
                if (result > 0)
                {
                    Console.WriteLine("Delete Success");
                }
                else
                {
                    Console.WriteLine("Delete Failed");
                    Console.WriteLine(deleteResult);
                }
        */



        /*
            var department = new Departments();    
        
            var getAllDepartment = department.GetAll();

             if (getAllDepartment.Count > 0)
             {
                 foreach (var department1 in getAllDepartment)
                 {
                     Console.WriteLine($"Id: {department1.Id}, Name: {department1.Name}, Location_Id: {department1.Location_Id}, Manager_Id: {department1.Manager_Id}");
                 }
             }
             else
             {
                 Console.WriteLine("No data found");
             }
        */

        /*
                var getAllDepartment = department.GetById(5);

                    if (getAllDepartment.Id > 0) // Memeriksa apakah objek memiliki data dengan ID yang ditemukan
                    {
                        Console.WriteLine(getAllDepartment.Id);
                        Console.WriteLine(getAllDepartment.Name);
                        Console.WriteLine(getAllDepartment.Location_Id);
                        Console.WriteLine(getAllDepartment.Manager_Id);

                    }
                    else
                    {
                        Console.WriteLine("Data not found");
                    }
        */

        /*
             var insertResult = department.Insert(11,"Agoenggg", 11, 2);
             int.TryParse(insertResult, out int result);
             if (result > 0)
             {
                 Console.WriteLine("Insert Success");
             }
             else 
             {
                 Console.WriteLine("Insert Failed");
                 Console.WriteLine(insertResult);
             }
        */

        /*
             var updateResult = department.Update(5, "KULI", 7, 5);
             int.TryParse(updateResult, out int result);
             if (result > 0)
             {
                 Console.WriteLine("Update Success");
             }
             else 
             {
                 Console.WriteLine("Update Failed");
                 Console.WriteLine(updateResult);
             }
        */

        /*
            var deleteResult = department.Delete(1);
                int.TryParse(deleteResult, out int result);
                if (result > 0)
                {
                    Console.WriteLine("Delete Success");
                }
                else
                {
                    Console.WriteLine("Delete Failed");
                    Console.WriteLine(deleteResult);
                }
        */



        /*
            var jobs = new Jobs(); 

            var getAllJob = jobs.GetAll();

             if (getAllJob.Count > 0)
             {
                 foreach (var jobs1 in getAllJob)
                 {
                     Console.WriteLine($"Id: {jobs1.Id}, Title: {jobs1.Title}, Min_Salary: {jobs1.Min_Salary}, Max_Salary: {jobs1.Max_Salary}");
                 }
             }
             else
             {
                 Console.WriteLine("No data found");
             }
        */

        /*
            var getAllJobs = jobs.GetById("C");

            if (getAllJobs.Id == "C") // Memeriksa apakah objek memiliki data dengan ID yang ditemukan
            {
                Console.WriteLine(getAllJobs.Id);
                Console.WriteLine(getAllJobs.Title);
                Console.WriteLine(getAllJobs.Min_Salary);
                Console.WriteLine(getAllJobs.Max_Salary);

            }
            else
            {
                Console.WriteLine("Data not found");
            }
        */

        /*
             var insertResult = jobs.Insert("Z","Ngaduk Semen", 400000, 9999999);
             int.TryParse(insertResult, out int result);
             if (result > 0)
             {
                 Console.WriteLine("Insert Success");
             }
             else 
             {
                 Console.WriteLine("Insert Failed");
                 Console.WriteLine(insertResult);
             }
        */

        /*
             var updateResult = jobs.Update("C", "Nguli Kuyyy", 696969, 999990000);
             int.TryParse(updateResult, out int result);
             if (result > 0)
             {
                 Console.WriteLine("Update Success");
             }
             else 
             {
                 Console.WriteLine("Update Failed");
                 Console.WriteLine(updateResult);
             }
        */

        /*
            var deleteResult = jobs.Delete(1);
                int.TryParse(deleteResult, out int result);
                if (result > 0)
                {
                    Console.WriteLine("Delete Success");
                }
                else
                {
                    Console.WriteLine("Delete Failed");
                    Console.WriteLine(deleteResult);
                }
        */



        /*  
            var history = new Histories();    

            var getAllHistory = history.GetAll();

             if (getAllHistory.Count > 0)
             {
                 foreach (var history1 in getAllHistory)
                 {
                     Console.WriteLine($"Start_Date: {history1.Start_Date}, Employees_Id: {history1.Employee_Id}, End_Time: {history1.End_Time}, Department_Id: {history1.Departments_Id}, Job_Id: {history1.Jobs_Id}");
                 }
             }
             else
             {
                 Console.WriteLine("No data found");
             }
        */

        /*
            var getAllHistory = history.GetById(3);

            if (getAllHistory.Departments_Id > 0) // Memeriksa apakah objek memiliki data dengan ID yang ditemukan
            {
                Console.WriteLine(getAllHistory.Start_Date);
                Console.WriteLine(getAllHistory.Employee_Id);
                Console.WriteLine(getAllHistory.End_Time);
                Console.WriteLine(getAllHistory.Departments_Id);
                Console.WriteLine(getAllHistory.Jobs_Id);
            }
            else
            {
                Console.WriteLine("Data not found");
            }
        */

        /*
             var insertResult = history.Insert("02/03/2015", 30, "02/03/2018", 2, "CC");
             int.TryParse(insertResult, out int result);
             if (result > 0)
             {
                 Console.WriteLine("Insert Success");
             }
             else 
             {
                 Console.WriteLine("Insert Failed");
                 Console.WriteLine(insertResult);
             }
        */

        /*
             var updateResult = history.Update("07/04/2011", 29, "01/05/2025", 2, "DD");
             int.TryParse(updateResult, out int result);
             if (result > 0)
             {
                 Console.WriteLine("Update Success");
             }
             else 
             {
                 Console.WriteLine("Update Failed");
                 Console.WriteLine(updateResult);
             }
         */

        /*
            var deleteResult = history.Delete(1);
                int.TryParse(deleteResult, out int result);
                if (result > 0)
                {
                    Console.WriteLine("Delete Success");
                }
                else
                {
                    Console.WriteLine("Delete Failed");
                    Console.WriteLine(deleteResult);
                }
        */



        /*
             var employee = new Employees();
            
             var getAllEmployee = employee.GetAll();

             if (getAllEmployee.Count > 0)
             {
                 foreach (var employee1 in getAllEmployee)
                 {
                     Console.WriteLine($"Id: {employee1.Id}, First_Name: {employee1.First_name}, Last_Name: {employee1.Last_Name}, Email: {employee1.Email}, Phone_Number: {employee1.Phone_Number}, Hire_Date: {employee1.Hire_Date}, Salary: {employee1.Salary}, Comission_Pct: {employee1.Comission_Pct}, Manager_Id: {employee1.Manager_Id}, Job_Id: {employee1.Jobs_Id}, Department_Id: {employee1.Department_Id}");
                 }
             }
             else
             {
                 Console.WriteLine("No data found");
             }
        */

        /*
            var getAllEmployee = employee.GetById(30);

            if (getAllEmployee.Id > 0) // Memeriksa apakah objek memiliki data dengan ID yang ditemukan
            {
                Console.WriteLine(getAllEmployee.Id);
                Console.WriteLine(getAllEmployee.First_name);
                Console.WriteLine(getAllEmployee.Last_Name);
                Console.WriteLine(getAllEmployee.Email);
                Console.WriteLine(getAllEmployee.Phone_Number);
                Console.WriteLine(getAllEmployee.Hire_Date);
                Console.WriteLine(getAllEmployee.Salary);
                Console.WriteLine(getAllEmployee.Comission_Pct);
                Console.WriteLine(getAllEmployee.Manager_Id);
                Console.WriteLine(getAllEmployee.Jobs_Id);
                Console.WriteLine(getAllEmployee.Department_Id);
            }
            else
            {
                Console.WriteLine("Data not found");
            }
        */

        /*
             var insertResult = employee.Insert(31,"Muhamad", "Agung", "muhamadagung@gmail.com", "0215751", "01/11/2023", 1000000, 99999, 4, "5", 2);
             int.TryParse(insertResult, out int result);
             if (result > 0)
             {
                 Console.WriteLine("Insert Success");
             }
             else 
             {
                 Console.WriteLine("Insert Failed");
                 Console.WriteLine(insertResult);
             }
        */

        /*
             var updateResult = employee.Update(30,"Otong", "Markotong", "sotong@gmail.com", "12244652", "01/11/2023", 1000000, 99999, 7, "DD", 10);
             int.TryParse(updateResult, out int result);
             if (result > 0)
             {
                 Console.WriteLine("Update Success");
             }
             else 
             {
                 Console.WriteLine("Update Failed");
                 Console.WriteLine(updateResult);
             }
        */

        /*
            var deleteResult = employee.Delete(1);
                int.TryParse(deleteResult, out int result);
                if (result > 0)
                {
                    Console.WriteLine("Delete Success");
                }
                else
                {
                    Console.WriteLine("Delete Failed");
                    Console.WriteLine(deleteResult);
                }
        */
    }
}
