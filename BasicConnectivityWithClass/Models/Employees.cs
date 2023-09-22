using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Security.Cryptography;
using BasicConnectivity;
using System.Xml.Linq;

namespace BasicConnectivityWithClass.Models;

public class Employees
{
    public int Id { get; set; }
    public string First_name { get; set; }
    public string Last_Name { get; set; }
    public string Email { get; set; }
    public string Phone_Number { get; set; }
    public DateTime Hire_Date { get; set; }
    public int Salary { get; set; }
    public decimal Comission_Pct { get; set; }
    public int Manager_Id { get; set; }
    public string Jobs_Id { get; set; }
    public int Department_Id { get; set; }

    public override string ToString()
    {
        return $"{Id} - {First_name} - {Last_Name} - {Email} - {Phone_Number} - {Hire_Date} - {Salary} - {Comission_Pct} - {Manager_Id} - {Jobs_Id} - {Department_Id}";
    }


    // GET ALL: Employee
    public List<Employees> GetAll()
    {
        var locations = new List<Employees>();

        using var connection = Provider.GetConnection(); // Instansiasi untuk connect ke database dengan argument data autentikasi yang sudah di define sebelumnya
        using var command = Provider.GetCommand(); // Instansiasi untuk menjalankan manipulation atau query database

        command.Connection = connection; // menghubungkan query dengan tabel database yg ada
        command.CommandText = "SELECT * FROM employees"; // melakukan query yaitu select semua baris dan kolom pada tabel regions

        try
        {
            connection.Open(); // membuka koneksi database

            using var reader = command.ExecuteReader(); // menjalankan method untuk membaca data pada tabel

            // Pengondisian apabila data pada databel tersedia tampilkan, apabila tidak data pada tabel kosong
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    locations.Add(new Employees
                    {
                        Id = reader.GetInt32(0),
                        First_name = reader.GetString(1),
                        Last_Name = reader.GetString(2),
                        Email = reader.GetString(3),
                        Phone_Number = reader.GetString(4),
                        Hire_Date = reader.GetDateTime(5),
                        Salary = reader.GetInt32(6),
                        Comission_Pct = reader.GetDecimal(7),
                        Manager_Id = reader.GetInt32(8),
                        Jobs_Id = reader.GetString(9),
                        Department_Id = reader.GetInt32(10),

                    });
                }
                reader.Close(); // menutup sesi membaca data pada tabel
                connection.Close(); // menutup sesi koneksi ke database

                return locations;
            }
            reader.Close(); // menutup sesi membaca data pada tabel
            connection.Close(); // menutup sesi koneksi ke database

            return new List<Employees>();
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}"); // Pesan Error apabila koneksi ke database gagal
        }
        return new List<Employees>();
    }

    // GET BY ID: EmployeeById
    public Employees GetById(int id)
    {
        var employee = new Employees();
        using var connection = Provider.GetConnection(); // Instansiasi untuk connect ke database dengan argument data autentikasi yang sudah di define sebelumnya
        using var command = Provider.GetCommand(); // Instansiasi untuk menjalankan manipulation atau query database

        command.Connection = connection; // menghubungkan query dengan tabel database yg ada
        command.CommandText = "SELECT * FROM employees WHERE id = @id"; // melakukan query yaitu select pada kolom dan baris berdasarkan id yang dipilih

        try
        {
            //mendefine atau menentukan paramater masukan yaitu Id untuk menjadi argument pada query yang dilakukan
            var pId = new SqlParameter();
            pId.ParameterName = "@id";
            pId.Value = id;
            pId.SqlDbType = SqlDbType.Int;
            command.Parameters.Add(pId);


            connection.Open(); // membuka koneksi database

            using var reader = command.ExecuteReader(); // menjalankan method untuk membaca data pada tabel

            // Pengondisian apabila data pada databel tersedia tampilkan, apabila tidak data pada tabel kosong
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    employee.Id = reader.GetInt32(0);
                    employee.First_name = reader.GetString(1);
                    employee.Last_Name = reader.GetString(2);
                    employee.Email = reader.GetString(3);
                    employee.Phone_Number = reader.GetString(4);
                    employee.Hire_Date = reader.GetDateTime(5);
                    employee.Salary = reader.GetInt32(6);
                    employee.Comission_Pct = reader.GetDecimal(7);
                    employee.Manager_Id = reader.GetInt32(8);
                    employee.Jobs_Id = reader.GetString(9);
                    employee.Department_Id = reader.GetInt32(10);
                }
                reader.Close(); // menutup sesi membaca data pada tabel
                connection.Close(); // menutup sesi koneksi ke database

                return employee;
            }
            reader.Close(); // menutup sesi membaca data pada tabel
            connection.Close(); // menutup sesi koneksi ke database

            return new Employees();
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}"); // Pesan Error apabila koneksi ke database gagal
        }
        return new Employees();
    }

    // INSERT: Employee
    public string Insert(Employees employee)
    {
        using var connection = Provider.GetConnection(); // Instansiasi untuk connect ke database dengan argument data autentikasi yang sudah di define sebelumnya
        using var command = Provider.GetCommand(); // Instansiasi untuk menjalankan manipulation atau query database

        command.Connection = connection; // menghubungkan perintah manipulasi dengan tabel database yg ada
        command.CommandText = "INSERT INTO employees VALUES (@id, @first_name, @last_name, @email, @phone_number, @hire_date, @salary, @comission_pct, @manager_id, @job_id, @departments_id);"; // melakukan manipulasi yaitu insert dengan menambahkan data region yang baru

        try
        {
            //mendefine atau menentukan paramater masukan yaitu Name untuk menjadi argument pada manipulasi yang dilakukan
            var pId = new SqlParameter();
            pId.ParameterName = "@id";
            pId.Value = employee.Id;
            pId.SqlDbType = SqlDbType.Int;
            command.Parameters.Add(pId);

            var pFirstName = new SqlParameter();
            pFirstName.ParameterName = "@first_name";
            pFirstName.Value = employee.First_name;
            pFirstName.SqlDbType = SqlDbType.VarChar;
            command.Parameters.Add(pFirstName);

            var pLastName = new SqlParameter();
            pLastName.ParameterName = "@last_name";
            pLastName.Value = employee.Last_Name;
            pLastName.SqlDbType = SqlDbType.VarChar;
            command.Parameters.Add(pLastName);

            var pEmail = new SqlParameter();
            pEmail.ParameterName = "@email";
            pEmail.Value = employee.Email;
            pEmail.SqlDbType = SqlDbType.VarChar;
            command.Parameters.Add(pEmail);

            var pPhoneNumber = new SqlParameter();
            pPhoneNumber.ParameterName = "@phone_number";
            pPhoneNumber.Value = employee.Phone_Number;
            pPhoneNumber.SqlDbType = SqlDbType.VarChar;
            command.Parameters.Add(pPhoneNumber);

            var pHireDate = new SqlParameter();
            pHireDate.ParameterName = "@hire_date";
            pHireDate.Value = employee.Hire_Date;
            pHireDate.SqlDbType = SqlDbType.DateTime;
            command.Parameters.Add(pHireDate);

            var pSalary = new SqlParameter();
            pSalary.ParameterName = "@salary";
            pSalary.Value = employee.Salary;
            pSalary.SqlDbType = SqlDbType.Int;
            command.Parameters.Add(pSalary);

            var pComissionPct = new SqlParameter();
            pComissionPct.ParameterName = "@comission_pct";
            pComissionPct.Value = employee.Comission_Pct;
            pComissionPct.SqlDbType = SqlDbType.Float;
            command.Parameters.Add(pComissionPct);

            var pManagerId = new SqlParameter();
            pManagerId.ParameterName = "@manager_id";
            pManagerId.Value = employee.Manager_Id;
            pManagerId.SqlDbType = SqlDbType.Int;
            command.Parameters.Add(pManagerId);

            var pJobsId = new SqlParameter();
            pJobsId.ParameterName = "@job_id";
            pJobsId.Value = employee.Jobs_Id;
            pJobsId.SqlDbType = SqlDbType.VarChar;
            command.Parameters.Add(pJobsId);

            var pDepartmentsId = new SqlParameter();
            pDepartmentsId.ParameterName = "@departments_id";
            pDepartmentsId.Value = employee.Department_Id;
            pDepartmentsId.SqlDbType = SqlDbType.Int;
            command.Parameters.Add(pDepartmentsId);

            connection.Open(); // membuka koneksi database
            using var transaction = connection.BeginTransaction(); // menjalankan method transaksi, bertujuan untuk merecord manipulasi data yang dilakukan. 
            try
            {
                command.Transaction = transaction; // menghubungkan transaksi dengan perintah manipulasi data sebelumnya

                var result = command.ExecuteNonQuery(); // menjalankan method untuk mengeksekusi perintah manipulasi data

                transaction.Commit(); // menjalankan transaksi yang dilakukan
                connection.Close(); // menutup sesi koneksi ke database

                return result.ToString();
            }
            catch (Exception ex)
            {
                transaction.Rollback(); // Apabila manipulasi data gagal, maka keadaan tabel akan dikembalikan ke keadaan sebelumnya
                return $"Error Transaction: {ex.Message}"; // Pesan Error apabila transaksi gagal
            }
        }
        catch (Exception ex)
        {
            return $"Error Transaction: {ex.Message}"; // Pesan Error apabila koneksi ke database gagal
        }
    }

    // UPDATE: Employee
    public string Update(Employees employee)
    {
        using var connection = Provider.GetConnection(); // Instansiasi untuk connect ke database dengan argument data autentikasi yang sudah di define sebelumnya
        using var command = Provider.GetCommand(); // Instansiasi untuk menjalankan manipulation atau query database

        command.Connection = connection; // menghubungkan query dengan tabel database yg ada
        command.CommandText = "UPDATE employees SET first_name = @first_name, last_name = @last_name, email = @email, phone_number = @phone_number, hire_date = @hire_date, salary = @salary, comission_pct = @comission_pct, manager_id = @manager_id, job_id = @job_id, department_id = @departments_id  WHERE id = @id;"; // melakukan manipulasi yaitu update dengan memperbaharui data berdasarkan id dan nama yang dipilih

        try
        {
            //mendefine atau menentukan paramater masukan yaitu Name untuk menjadi argument pada manipulasi yang dilakukan
            var pId = new SqlParameter();
            pId.ParameterName = "@id";
            pId.Value = employee.Id;
            pId.SqlDbType = SqlDbType.Int;
            command.Parameters.Add(pId);

            var pFirstName = new SqlParameter();
            pFirstName.ParameterName = "@first_name";
            pFirstName.Value = employee.First_name;
            pFirstName.SqlDbType = SqlDbType.VarChar;
            command.Parameters.Add(pFirstName);

            var pLastName = new SqlParameter();
            pLastName.ParameterName = "@last_name";
            pLastName.Value = employee.Last_Name;
            pLastName.SqlDbType = SqlDbType.VarChar;
            command.Parameters.Add(pLastName);

            var pEmail = new SqlParameter();
            pEmail.ParameterName = "@email";
            pEmail.Value = employee.Email;
            pEmail.SqlDbType = SqlDbType.VarChar;
            command.Parameters.Add(pEmail);

            var pPhoneNumber = new SqlParameter();
            pPhoneNumber.ParameterName = "@phone_number";
            pPhoneNumber.Value = employee.Phone_Number;
            pPhoneNumber.SqlDbType = SqlDbType.VarChar;
            command.Parameters.Add(pPhoneNumber);

            var pHireDate = new SqlParameter();
            pHireDate.ParameterName = "@hire_date";
            pHireDate.Value = employee.Hire_Date;
            pHireDate.SqlDbType = SqlDbType.DateTime;
            command.Parameters.Add(pHireDate);

            var pSalary = new SqlParameter();
            pSalary.ParameterName = "@salary";
            pSalary.Value = employee.Salary;
            pSalary.SqlDbType = SqlDbType.Int;
            command.Parameters.Add(pSalary);

            var pComissionPct = new SqlParameter();
            pComissionPct.ParameterName = "@comission_pct";
            pComissionPct.Value = employee.Comission_Pct;
            pComissionPct.SqlDbType = SqlDbType.Float;
            command.Parameters.Add(pComissionPct);

            var pManagerId = new SqlParameter();
            pManagerId.ParameterName = "@manager_id";
            pManagerId.Value = employee.Manager_Id;
            pManagerId.SqlDbType = SqlDbType.Int;
            command.Parameters.Add(pManagerId);

            var pJobsId = new SqlParameter();
            pJobsId.ParameterName = "@job_id";
            pJobsId.Value = employee.Jobs_Id;
            pJobsId.SqlDbType = SqlDbType.VarChar;
            command.Parameters.Add(pJobsId);

            var pDepartmentsId = new SqlParameter();
            pDepartmentsId.ParameterName = "@departments_id";
            pDepartmentsId.Value = employee.Department_Id;
            pDepartmentsId.SqlDbType = SqlDbType.Int;
            command.Parameters.Add(pDepartmentsId);

            connection.Open(); // membuka koneksi database
            using var transaction = connection.BeginTransaction(); // menjalankan method transaksi, bertujuan untuk merecord manipulasi data yang dilakukan. 
            try
            {
                command.Transaction = transaction; // menghubungkan transaksi dengan perintah manipulasi data sebelumnya

                var result = command.ExecuteNonQuery(); // menjalankan method untuk mengeksekusi perintah manipulasi data

                transaction.Commit(); // menjalankan transaksi yang dilakukan
                connection.Close(); // menutup sesi koneksi ke database

                return result.ToString();
            }
            catch (Exception ex)
            {
                transaction.Rollback(); // Apabila manipulasi data gagal, maka keadaan tabel akan dikembalikan ke keadaan sebelumnya
                return $"Error Transaction: {ex.Message}"; // Pesan Error apabila transaksi gagal
            }
        }
        catch (Exception ex)
        {
            return $"Error Transaction: {ex.Message}"; // Pesan Error apabila koneksi ke database gagal
        }

    }

    // DELETE: Employee
    public string Delete(int id)
    {
        using var connection = Provider.GetConnection(); // Instansiasi untuk connect ke database dengan argument data autentikasi yang sudah di define sebelumnya
        using var command = Provider.GetCommand(); // Instansiasi untuk menjalankan manipulation atau query database

        command.Connection = connection; // menghubungkan query dengan tabel database yg ada
        command.CommandText = "DELETE FROM employees WHERE id = @id;"; // melakukan manipulasi yaitu delete dengan menghapus data berdasarkan id  yang dipilih

        try
        {
            //mendefine atau menentukan paramater masukan yaitu Name untuk menjadi argument pada manipulasi yang dilakukan
            var pId = new SqlParameter();
            pId.ParameterName = "@id";
            pId.Value = id;
            pId.SqlDbType = SqlDbType.Int;
            command.Parameters.Add(pId);

            connection.Open(); // membuka koneksi database
            using var transaction = connection.BeginTransaction(); // menjalankan method transaksi, bertujuan untuk merecord manipulasi data yang dilakukan. 
            try
            {
                command.Transaction = transaction; // menghubungkan transaksi dengan perintah manipulasi data sebelumnya

                var result = command.ExecuteNonQuery(); // menjalankan method untuk mengeksekusi perintah manipulasi data

                transaction.Commit(); // menjalankan transaksi yang dilakukan
                connection.Close(); // menutup sesi koneksi ke database

                return result.ToString();
            }
            catch (Exception ex)
            {
                transaction.Rollback(); // Apabila manipulasi data gagal, maka keadaan tabel akan dikembalikan ke keadaan sebelumnya
                return $"Error Transaction: {ex.Message}"; // Pesan Error apabila transaksi gagal
            }
        }
        catch (Exception ex)
        {
            return $"Error: {ex.Message}"; // Pesan Error apabila koneksi ke database gagal
        }
    }
}