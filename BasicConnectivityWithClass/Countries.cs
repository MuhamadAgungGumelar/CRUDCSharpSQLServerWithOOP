using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using BasicConnectivity;

namespace BasicConnectivityWithClass;

public class Countries
{
    public string Id { get; set; }
    public string Name { get; set; }
    public int RegionId { get; set; }

    public override string ToString()
    {
        return $"{Id} - {Name} - {RegionId}";
    }

    // GET ALL: Countries
    public List<Countries> GetAll()
    {
        var regions = new List<Countries>();

        using var connection = Provider.GetConnection(); // Instansiasi untuk connect ke database dengan argument data autentikasi yang sudah di define sebelumnya
        using var command = Provider.GetCommand(); // Instansiasi untuk menjalankan manipulation atau query database

        command.Connection = connection; // menghubungkan query dengan tabel database yg ada
        command.CommandText = "SELECT * FROM countries"; // melakukan query yaitu select semua baris dan kolom pada tabel regions

        try
        {
            connection.Open(); // membuka koneksi database

            using var reader = command.ExecuteReader(); // menjalankan method untuk membaca data pada tabel

            // Pengondisian apabila data pada databel tersedia tampilkan, apabila tidak data pada tabel kosong
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    regions.Add(new Countries
                    {
                        Id = reader.GetString(0),
                        Name = reader.GetString(1),
                        RegionId = reader.GetInt32(2)
                    });
                }
                reader.Close(); // menutup sesi membaca data pada tabel
                connection.Close(); // menutup sesi koneksi ke database

                return regions;
            }
            reader.Close(); // menutup sesi membaca data pada tabel
            connection.Close(); // menutup sesi koneksi ke database

            return new List<Countries>();
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}"); // Pesan Error apabila koneksi ke database gagal
        }
        return new List<Countries>();
    }

    // GET BY ID: CountriesnById
    public Countries GetById(int regionId)
    {
        var regions = new Countries();
        using var connection = Provider.GetConnection(); // Instansiasi untuk connect ke database dengan argument data autentikasi yang sudah di define sebelumnya
        using var command = Provider.GetCommand(); // Instansiasi untuk menjalankan manipulation atau query database

        command.Connection = connection; // menghubungkan query dengan tabel database yg ada
        command.CommandText = "SELECT * FROM countries WHERE region_id = @region_id"; // melakukan query yaitu select pada kolom dan baris berdasarkan id yang dipilih

        try
        {
            //mendefine atau menentukan paramater masukan yaitu Id untuk menjadi argument pada query yang dilakukan
            var pRegionId = new SqlParameter();
            pRegionId.ParameterName = "@region_id";
            pRegionId.Value = regionId;
            pRegionId.SqlDbType = SqlDbType.Int;
            command.Parameters.Add(pRegionId);


            connection.Open(); // membuka koneksi database

            using var reader = command.ExecuteReader(); // menjalankan method untuk membaca data pada tabel

            // Pengondisian apabila data pada databel tersedia tampilkan, apabila tidak data pada tabel kosong
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    regions.Id = reader.GetString(0);
                    regions.Name = reader.GetString(1);
                    regions.RegionId = reader.GetInt32(2);
                }
                reader.Close(); // menutup sesi membaca data pada tabel
                connection.Close(); // menutup sesi koneksi ke database

                return regions;
            }
            reader.Close(); // menutup sesi membaca data pada tabel
            connection.Close(); // menutup sesi koneksi ke database

            return new Countries();
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}"); // Pesan Error apabila koneksi ke database gagal
        }
        return new Countries();
    }

    // INSERT: Countries
    public string Insert(string id, string name, int regionId)
    {
        using var connection = Provider.GetConnection(); // Instansiasi untuk connect ke database dengan argument data autentikasi yang sudah di define sebelumnya
        using var command = Provider.GetCommand(); // Instansiasi untuk menjalankan manipulation atau query database

        command.Connection = connection; // menghubungkan perintah manipulasi dengan tabel database yg ada
        command.CommandText = "INSERT INTO countries VALUES (@id, @name, @region_id);"; // melakukan manipulasi yaitu insert dengan menambahkan data region yang baru

        try
        {
            //mendefine atau menentukan paramater masukan yaitu Name untuk menjadi argument pada manipulasi yang dilakukan
            var pId = new SqlParameter();
            pId.ParameterName = "@id";
            pId.Value = id;
            pId.SqlDbType = SqlDbType.VarChar;
            command.Parameters.Add(pId);

            var pName = new SqlParameter();
            pName.ParameterName = "@name";
            pName.Value = name;
            pName.SqlDbType = SqlDbType.VarChar;
            command.Parameters.Add(pName);

            var pRegionId = new SqlParameter();
            pRegionId.ParameterName = "@region_id";
            pRegionId.Value = regionId;
            pRegionId.SqlDbType = SqlDbType.Int;
            command.Parameters.Add(pRegionId);

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

    // UPDATE: Countries
    public string Update(string id, string name, int regionId)
    {
        using var connection = Provider.GetConnection(); // Instansiasi untuk connect ke database dengan argument data autentikasi yang sudah di define sebelumnya
        using var command = Provider.GetCommand(); // Instansiasi untuk menjalankan manipulation atau query database

        command.Connection = connection; // menghubungkan query dengan tabel database yg ada
        command.CommandText = "UPDATE countries SET name = @name, region_id = @region_id WHERE id = @id;"; // melakukan manipulasi yaitu update dengan memperbaharui data berdasarkan id dan nama yang dipilih

        try
        {
            //mendefine atau menentukan paramater masukan yaitu Name untuk menjadi argument pada manipulasi yang dilakukan
            var pId = new SqlParameter();
            pId.ParameterName = "@id";
            pId.Value = id;
            pId.SqlDbType = SqlDbType.VarChar;
            command.Parameters.Add(pId);

            var pName = new SqlParameter();
            pName.ParameterName = "@name";
            pName.Value = name;
            pName.SqlDbType = SqlDbType.VarChar;
            command.Parameters.Add(pName);

            var pRegionId = new SqlParameter();
            pRegionId.ParameterName = "@region_id";
            pRegionId.Value = regionId;
            pRegionId.SqlDbType = SqlDbType.Int;
            command.Parameters.Add(pRegionId);

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

    // DELETE: Countries
    public string Delete(string id)
    {
        using var connection = Provider.GetConnection(); // Instansiasi untuk connect ke database dengan argument data autentikasi yang sudah di define sebelumnya
        using var command = Provider.GetCommand(); // Instansiasi untuk menjalankan manipulation atau query database

        command.Connection = connection; // menghubungkan query dengan tabel database yg ada
        command.CommandText = "DELETE FROM countries WHERE id = @id;"; // melakukan manipulasi yaitu delete dengan menghapus data berdasarkan id  yang dipilih

        try
        {
            //mendefine atau menentukan paramater masukan yaitu Name untuk menjadi argument pada manipulasi yang dilakukan
            var pId = new SqlParameter();
            pId.ParameterName = "@id";
            pId.Value = id;
            pId.SqlDbType = SqlDbType.VarChar;
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