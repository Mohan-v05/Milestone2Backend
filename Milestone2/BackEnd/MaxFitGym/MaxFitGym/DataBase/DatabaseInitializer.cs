using Microsoft.Data.Sqlite;

namespace MaxFitGym.DataBase
{
    public class DatabaseInitializer
    {
        private readonly string _ConnectionString;

        public DatabaseInitializer(string connectionString)
        {
            _ConnectionString = connectionString;
        }


        public void Initialize()
        {
            using (var connection = new SqliteConnection(_ConnectionString))
            {
                connection.Open();
                var command = connection.CreateCommand();
                command.CommandText = @"
                  
                    CREATE TABLE IF NOT EXISTS  Programs(
                        Id INT PRIMARY KEY,
                        ProgramName NVARCHAR(25) NOT NULL,
                        Type NVARCHAR(25) NOT NULL,
                        TotalFee INT NOT NULL
                    );   

                    CREATE TABLE IF NOT EXISTS  Students(
                        Nic NVARCHAR(15) PRIMARY KEY,
                        FullName NVARCHAR(25) NOT NULL,
                        Email NVARCHAR(25) NOT NULL,
                        Phone NVARCHAR(15) NOT NULL,
                        Password NVARCHAR(50) NOT NULL,
                        RegistrationFee INT NOT NULL,
                        CourseEnrollId INT NULL,
                        ImagePath NVARCHAR(100) NULL
                    );

                ";
                command.ExecuteNonQuery();
        }

    }
}
}