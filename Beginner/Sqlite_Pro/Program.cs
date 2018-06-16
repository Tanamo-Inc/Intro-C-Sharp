using System;
using System.Data.SQLite;

namespace Sqlite_Pro
{

    // Using System.Data.SQLite Approach.

    class Program
    {
        static void Main(string[] args)
        {

            Console.WriteLine("*************   ******* ******   *****WORKING WITH SQLite IN C#.*****  ***** *******  *******************");

            SL();

        }


        // My SQLite Method
        static void SL()
        {

            #region Query

            string query = @"CREATE  TABLE IF NOT EXISTS
                             [Users](
                             [Id] INTEGER NOT NULL PRIMARY KEY AUTOINCREMENT,
                             [Name] NVARCHAR(2048) NULL,
                             [Age]  NVARCHAR(120) NULL,
                             [Gender]  NVARCHAR(2048) NULL)";


            #endregion

            SQLiteConnection.CreateFile("sqlite_pro.db3");

            SQLiteConnection conn = new SQLiteConnection("data source=sqlite_pro.db3");

            SQLiteCommand cmd = new SQLiteCommand(conn);

            conn.Open();

            #region Query Command

            cmd.CommandText = query;
            cmd.ExecuteNonQuery();
            cmd.CommandText = "INSERT INTO Users(Name,Age,Gender) values('Tony','155','Male')";
            cmd.ExecuteNonQuery();
            cmd.CommandText = "INSERT INTO Users(Name,Age,Gender) values('Lucy','100','Female')";
            cmd.ExecuteNonQuery();
            cmd.CommandText = "INSERT INTO Users(Name,Age,Gender) values('Theo','140','Male')";
            cmd.ExecuteNonQuery();
            cmd.CommandText = "INSERT INTO Users(Name,Age,Gender) values('Mary','120','Female')";
            cmd.ExecuteNonQuery();
            cmd.CommandText = "INSERT INTO Users(Name,Age,Gender) values('Clem','130','Male')";
            cmd.ExecuteNonQuery();
            cmd.CommandText = "INSERT INTO Users(Name,Age,Gender) values('Mercy','170','Female')";
            cmd.ExecuteNonQuery();
            cmd.CommandText = "INSERT INTO Users(Name,Age,Gender) values('Flex','115','Male')";
            cmd.ExecuteNonQuery();
            cmd.CommandText = "INSERT INTO Users(Name,Age,Gender) values('Ruth','125','Female')";
            cmd.ExecuteNonQuery();


            #endregion

            cmd.CommandText = "SELECT * FROM Users";

            #region Reader

            SQLiteDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                Console.WriteLine(reader["Name"] + " is a " + "" + reader["Gender"] + " with  age " + reader["Age"] + " Year. ");
                Console.WriteLine("\n");
            }


            conn.Close();


            #endregion

            Console.ReadLine();

        }


    }
}
