using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using BasicConnectivity;

namespace BasicConnectivityWithClass;

public class Locations
{
    static string connectionString = "Data Source=DESKTOP-HM2DN7T; Integrated Security=True;Database=db_hr_dts;Connect Timeout=30;";

    public int Id { get; set; }
    public string Street_Address { get; set; }
    public string Postal_Code { get; set; }
    public string City { get; set; }
    public string State_Province { get; set; }
    public string Country_Id { get; set; }

    public override string ToString()
    {
        return $"{Id} - {Street_Address} - {Postal_Code} - {City} - {State_Province} - {Country_Id}";
    }


    // GET ALL: Location
    public List<Locations> GetAll()
    {
        var locations = new List<Locations>();

        using var connection = Provider.GetConnection(); // Instansiasi untuk connect ke database dengan argument data autentikasi yang sudah di define sebelumnya
        using var command = Provider.GetCommand(); // Instansiasi untuk menjalankan manipulation atau query database

        command.Connection = connection; // menghubungkan query dengan tabel database yg ada
        command.CommandText = "SELECT * FROM locations"; // melakukan query yaitu select semua baris dan kolom pada tabel regions

        try
        {
            connection.Open(); // membuka koneksi database

            using var reader = command.ExecuteReader(); // menjalankan method untuk membaca data pada tabel

            // Pengondisian apabila data pada databel tersedia tampilkan, apabila tidak data pada tabel kosong
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    locations.Add(new Locations
                    {
                        Id = reader.GetInt32(0),
                        Street_Address = reader.GetString(1),
                        Postal_Code = reader.GetString(2),
                        City = reader.GetString(3),
                        State_Province = reader.GetString(4),
                        Country_Id = reader.GetString(5),
                    });
                }
                reader.Close(); // menutup sesi membaca data pada tabel
                connection.Close(); // menutup sesi koneksi ke database

                return locations;
            }
            reader.Close(); // menutup sesi membaca data pada tabel
            connection.Close(); // menutup sesi koneksi ke database

            return new List<Locations>();
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}"); // Pesan Error apabila koneksi ke database gagal
        }
        return new List<Locations>();
    }

    // GET BY ID: LocationById
    public Locations GetById(int id)
    {
        var locations = new Locations();
        using var connection = Provider.GetConnection(); // Instansiasi untuk connect ke database dengan argument data autentikasi yang sudah di define sebelumnya
        using var command = Provider.GetCommand(); // Instansiasi untuk menjalankan manipulation atau query database

        command.Connection = connection; // menghubungkan query dengan tabel database yg ada
        command.CommandText = "SELECT * FROM locations WHERE id = @id"; // melakukan query yaitu select pada kolom dan baris berdasarkan id yang dipilih

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
                    locations.Id = reader.GetInt32(0);
                    locations.Street_Address = reader.GetString(1);
                    locations.Postal_Code = reader.GetString(2);
                    locations.City = reader.GetString(3);
                    locations.State_Province = reader.GetString(4);
                    locations.Country_Id = reader.GetString(5);
                }
                reader.Close(); // menutup sesi membaca data pada tabel
                connection.Close(); // menutup sesi koneksi ke database

                return locations;
            }
            reader.Close(); // menutup sesi membaca data pada tabel
            connection.Close(); // menutup sesi koneksi ke database

            return new Locations();
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}"); // Pesan Error apabila koneksi ke database gagal
        }
        return new Locations();
    }

    // INSERT: Location
    public string Insert(int id, string street_address, string postal_code, string city, string state_province, string country_id)
    {
        using var connection = Provider.GetConnection(); // Instansiasi untuk connect ke database dengan argument data autentikasi yang sudah di define sebelumnya
        using var command = Provider.GetCommand(); // Instansiasi untuk menjalankan manipulation atau query database

        command.Connection = connection; // menghubungkan perintah manipulasi dengan tabel database yg ada
        command.CommandText = "INSERT INTO locations (id, street_address, postal_code, city, state_province, country_id) VALUES (@id, @street_address, @postal_code, @city, @state_province, @country_id);"; // melakukan manipulasi yaitu insert dengan menambahkan data region yang baru

        try
        {
            //mendefine atau menentukan paramater masukan yaitu Name untuk menjadi argument pada manipulasi yang dilakukan
            var pId = new SqlParameter();
            pId.ParameterName = "@id";
            pId.Value = id;
            pId.SqlDbType = SqlDbType.Int;
            command.Parameters.Add(pId);

            var pStreetAddress = new SqlParameter();
            pStreetAddress.ParameterName = "@street_address";
            pStreetAddress.Value = street_address;
            pStreetAddress.SqlDbType = SqlDbType.VarChar;
            command.Parameters.Add(pStreetAddress);

            var pPostalCode = new SqlParameter();
            pPostalCode.ParameterName = "@postal_code";
            pPostalCode.Value = postal_code;
            pPostalCode.SqlDbType = SqlDbType.VarChar;
            command.Parameters.Add(pPostalCode);

            var pCity = new SqlParameter();
            pCity.ParameterName = "@city";
            pCity.Value = city;
            pCity.SqlDbType = SqlDbType.VarChar;
            command.Parameters.Add(pCity);

            var pStateProvince = new SqlParameter();
            pStateProvince.ParameterName = "@state_province";
            pStateProvince.Value = state_province;
            pStateProvince.SqlDbType = SqlDbType.VarChar;
            command.Parameters.Add(pStateProvince);

            var pCountryId = new SqlParameter();
            pCountryId.ParameterName = "@country_id";
            pCountryId.Value = country_id;
            pCountryId.SqlDbType = SqlDbType.VarChar;
            command.Parameters.Add(pCountryId);

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

    // UPDATE: Location
    public string Update(int id, string street_address, string postal_code, string city, string state_province, string country_id)
    {
        using var connection = Provider.GetConnection(); // Instansiasi untuk connect ke database dengan argument data autentikasi yang sudah di define sebelumnya
        using var command = Provider.GetCommand(); // Instansiasi untuk menjalankan manipulation atau query database

        command.Connection = connection; // menghubungkan query dengan tabel database yg ada
        command.CommandText = "UPDATE locations SET street_address = @street_address, postal_code = @postal_code, city = @city, state_province = @state_province, country_id = @country_id WHERE id = @id;"; // melakukan manipulasi yaitu update dengan memperbaharui data berdasarkan id dan nama yang dipilih

        try
        {
            //mendefine atau menentukan paramater masukan yaitu Name untuk menjadi argument pada manipulasi yang dilakukan
            var pId = new SqlParameter();
            pId.ParameterName = "@id";
            pId.Value = id;
            pId.SqlDbType = SqlDbType.Int;
            command.Parameters.Add(pId);

            var pStreetAddress = new SqlParameter();
            pStreetAddress.ParameterName = "@street_address";
            pStreetAddress.Value = street_address;
            pStreetAddress.SqlDbType = SqlDbType.VarChar;
            command.Parameters.Add(pStreetAddress);

            var pPostalCode = new SqlParameter();
            pPostalCode.ParameterName = "@postal_code";
            pPostalCode.Value = postal_code;
            pPostalCode.SqlDbType = SqlDbType.VarChar;
            command.Parameters.Add(pPostalCode);

            var pCity = new SqlParameter();
            pCity.ParameterName = "@city";
            pCity.Value = city;
            pCity.SqlDbType = SqlDbType.VarChar;
            command.Parameters.Add(pCity);

            var pStateProvince = new SqlParameter();
            pStateProvince.ParameterName = "@state_province";
            pStateProvince.Value = state_province;
            pStateProvince.SqlDbType = SqlDbType.VarChar;
            command.Parameters.Add(pStateProvince);

            var pCountryId = new SqlParameter();
            pCountryId.ParameterName = "@country_id";
            pCountryId.Value = country_id;
            pCountryId.SqlDbType = SqlDbType.VarChar;
            command.Parameters.Add(pCountryId);

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

    // DELETE: Location
    public string Delete(int id)
    {
        using var connection = Provider.GetConnection(); // Instansiasi untuk connect ke database dengan argument data autentikasi yang sudah di define sebelumnya
        using var command = Provider.GetCommand(); // Instansiasi untuk menjalankan manipulation atau query database

        command.Connection = connection; // menghubungkan query dengan tabel database yg ada
        command.CommandText = "DELETE FROM locations WHERE id = @id;"; // melakukan manipulasi yaitu delete dengan menghapus data berdasarkan id  yang dipilih

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