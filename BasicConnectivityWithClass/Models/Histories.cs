using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using BasicConnectivity;

namespace BasicConnectivityWithClass;

public class Histories
{
    static string connectionString = "Data Source=DESKTOP-HM2DN7T; Integrated Security=True;Database=db_hr_dts;Connect Timeout=30;";

    public DateTime Start_Date { get; set; }
    public int Employee_Id { get; set; }
    public DateTime End_Time { get; set; }
    public int Departments_Id { get; set; }
    public string Jobs_Id { get; set; }

    public override string ToString()
    {
        return $"{Start_Date} - {Employee_Id} - {End_Time} - {Departments_Id} - {Jobs_Id}";
    }

    // GET ALL: History
    public List<Histories> GetAll()
    {
        var locations = new List<Histories>();

        using var connection = Provider.GetConnection(); // Instansiasi untuk connect ke database dengan argument data autentikasi yang sudah di define sebelumnya
        using var command = Provider.GetCommand(); // Instansiasi untuk menjalankan manipulation atau query database

        command.Connection = connection; // menghubungkan query dengan tabel database yg ada
        command.CommandText = "SELECT * FROM histories"; // melakukan query yaitu select semua baris dan kolom pada tabel regions

        try
        {
            connection.Open(); // membuka koneksi database

            using var reader = command.ExecuteReader(); // menjalankan method untuk membaca data pada tabel

            // Pengondisian apabila data pada databel tersedia tampilkan, apabila tidak data pada tabel kosong
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    locations.Add(new Histories
                    {
                        Start_Date = reader.GetDateTime(0),
                        Employee_Id = reader.GetInt32(1),
                        End_Time = reader.GetDateTime(2),
                        Departments_Id = reader.GetInt32(3),
                        Jobs_Id = reader.GetString(4),
                    });
                }
                reader.Close(); // menutup sesi membaca data pada tabel
                connection.Close(); // menutup sesi koneksi ke database

                return locations;
            }
            reader.Close(); // menutup sesi membaca data pada tabel
            connection.Close(); // menutup sesi koneksi ke database

            return new List<Histories>();
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}"); // Pesan Error apabila koneksi ke database gagal
        }
        return new List<Histories>();
    }

    // GET BY ID: HistoryById
    public Histories GetById(int department_id)
    {
        var history = new Histories();
        using var connection = Provider.GetConnection(); // Instansiasi untuk connect ke database dengan argument data autentikasi yang sudah di define sebelumnya
        using var command = Provider.GetCommand(); // Instansiasi untuk menjalankan manipulation atau query database

        command.Connection = connection; // menghubungkan query dengan tabel database yg ada
        command.CommandText = "SELECT * FROM histories WHERE departement_id = @department_id"; // melakukan query yaitu select pada kolom dan baris berdasarkan id yang dipilih

        try
        {
            //mendefine atau menentukan paramater masukan yaitu Id untuk menjadi argument pada query yang dilakukan
            var pDepartmentsId = new SqlParameter();
            pDepartmentsId.ParameterName = "@department_id";
            pDepartmentsId.Value = department_id;
            pDepartmentsId.SqlDbType = SqlDbType.Int;
            command.Parameters.Add(pDepartmentsId);


            connection.Open(); // membuka koneksi database

            using var reader = command.ExecuteReader(); // menjalankan method untuk membaca data pada tabel

            // Pengondisian apabila data pada databel tersedia tampilkan, apabila tidak data pada tabel kosong
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    history.Start_Date = reader.GetDateTime(0);
                    history.Employee_Id = reader.GetInt32(1);
                    history.End_Time = reader.GetDateTime(2);
                    history.Departments_Id = reader.GetInt32(3);
                    history.Jobs_Id = reader.GetString(4);
                }
                reader.Close(); // menutup sesi membaca data pada tabel
                connection.Close(); // menutup sesi koneksi ke database

                return history;
            }
            reader.Close(); // menutup sesi membaca data pada tabel
            connection.Close(); // menutup sesi koneksi ke database

            return new Histories();
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}"); // Pesan Error apabila koneksi ke database gagal
        }
        return new Histories();
    }

    // INSERT: History
    public string Insert(Histories history)
    {
        using var connection = Provider.GetConnection(); // Instansiasi untuk connect ke database dengan argument data autentikasi yang sudah di define sebelumnya
        using var command = Provider.GetCommand(); // Instansiasi untuk menjalankan manipulation atau query database

        command.Connection = connection; // menghubungkan perintah manipulasi dengan tabel database yg ada
        command.CommandText = "INSERT INTO histories  VALUES (@start_date, @employee_id, @end_time, @departments_id, @job_id);"; // melakukan manipulasi yaitu insert dengan menambahkan data region yang baru

        try
        {
            //mendefine atau menentukan paramater masukan yaitu Name untuk menjadi argument pada manipulasi yang dilakukan
            var pStartDate = new SqlParameter();
            pStartDate.ParameterName = "@start_date";
            pStartDate.Value = history.Start_Date;
            pStartDate.SqlDbType = SqlDbType.DateTime;
            command.Parameters.Add(pStartDate);

            var pEmployeeId = new SqlParameter();
            pEmployeeId.ParameterName = "@employee_id";
            pEmployeeId.Value = history.Employee_Id;
            pEmployeeId.SqlDbType = SqlDbType.Int;
            command.Parameters.Add(pEmployeeId);

            var pEndTime = new SqlParameter();
            pEndTime.ParameterName = "@end_time";
            pEndTime.Value = history.End_Time;
            pEndTime.SqlDbType = SqlDbType.DateTime;
            command.Parameters.Add(pEndTime);

            var pDepartmentsId = new SqlParameter();
            pDepartmentsId.ParameterName = "@departments_id";
            pDepartmentsId.Value = history.Departments_Id;
            pDepartmentsId.SqlDbType = SqlDbType.Int;
            command.Parameters.Add(pDepartmentsId);

            var pJobsId = new SqlParameter();
            pJobsId.ParameterName = "@job_id";
            pJobsId.Value = history.Jobs_Id;
            pJobsId.SqlDbType = SqlDbType.VarChar;
            command.Parameters.Add(pJobsId);

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

    // UPDATE: History
    public string Update(Histories history)
    {
        using var connection = Provider.GetConnection(); // Instansiasi untuk connect ke database dengan argument data autentikasi yang sudah di define sebelumnya
        using var command = Provider.GetCommand(); // Instansiasi untuk menjalankan manipulation atau query database

        command.Connection = connection; // menghubungkan query dengan tabel database yg ada
        command.CommandText = "UPDATE histories SET start_date = @start_date, employee_id = @employee_id, end_time = @end_time, job_id = @job_id WHERE departement_id = @departments_id;"; // melakukan manipulasi yaitu update dengan memperbaharui data berdasarkan id dan nama yang dipilih

        try
        {
            //mendefine atau menentukan paramater masukan yaitu Name untuk menjadi argument pada manipulasi yang dilakukan
            var pStartDate = new SqlParameter();
            pStartDate.ParameterName = "@start_date";
            pStartDate.Value = history.Start_Date;
            pStartDate.SqlDbType = SqlDbType.DateTime;
            command.Parameters.Add(pStartDate);

            var pEmployeeId = new SqlParameter();
            pEmployeeId.ParameterName = "@employee_id";
            pEmployeeId.Value = history.Employee_Id;
            pEmployeeId.SqlDbType = SqlDbType.Int;
            command.Parameters.Add(pEmployeeId);

            var pEndTime = new SqlParameter();
            pEndTime.ParameterName = "@end_time";
            pEndTime.Value = history.End_Time;
            pEndTime.SqlDbType = SqlDbType.DateTime;
            command.Parameters.Add(pEndTime);

            var pDepartmentsId = new SqlParameter();
            pDepartmentsId.ParameterName = "@departments_id";
            pDepartmentsId.Value = history.Departments_Id;
            pDepartmentsId.SqlDbType = SqlDbType.Int;
            command.Parameters.Add(pDepartmentsId);

            var pJobsId = new SqlParameter();
            pJobsId.ParameterName = "@job_id";
            pJobsId.Value = history.Jobs_Id;
            pJobsId.SqlDbType = SqlDbType.VarChar;
            command.Parameters.Add(pJobsId);

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

    // DELETE: History
    public string Delete(int departments_id)
    {
        using var connection = Provider.GetConnection(); // Instansiasi untuk connect ke database dengan argument data autentikasi yang sudah di define sebelumnya
        using var command = Provider.GetCommand(); // Instansiasi untuk menjalankan manipulation atau query database

        command.Connection = connection; // menghubungkan query dengan tabel database yg ada
        command.CommandText = "DELETE FROM histories WHERE departments_id = @departments_id;"; // melakukan manipulasi yaitu delete dengan menghapus data berdasarkan id  yang dipilih

        try
        {
            //mendefine atau menentukan paramater masukan yaitu Name untuk menjadi argument pada manipulasi yang dilakukan
            var pDepartmentsId = new SqlParameter();
            pDepartmentsId.ParameterName = "@departments_id";
            pDepartmentsId.Value = departments_id;
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
            return $"Error: {ex.Message}"; // Pesan Error apabila koneksi ke database gagal
        }
    }
}