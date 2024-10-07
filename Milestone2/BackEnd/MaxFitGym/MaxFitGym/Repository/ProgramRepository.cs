﻿using MaxFitGym.IRepository;
using MaxFitGym.Models;
using Microsoft.Data.Sqlite;
using SQLitePCL;

namespace MaxFitGym.Repository
{
    public class ProgramRepository: IProgramRepository
    {
        private readonly string _connectionString;

        public ProgramRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        public ProgramDTO AddProgram(ProgramDTO programDto)
        {
            using (var connection = new SqliteConnection(_connectionString))
            {
                connection.Open();
                var command = connection.CreateCommand();
                command = connection.CreateCommand();
                command.CommandText = "INSERT INTO Programs (Id,ProgramName,Type,TotalFee) VALUES (@id,@programName,@type,@totalFee);";
                command.Parameters.AddWithValue("@id", programDto.Id);
                command.Parameters.AddWithValue("@programName", programDto.ProgramName);
                command.Parameters.AddWithValue("@type", programDto.Type);
                command.Parameters.AddWithValue("@totalFee", programDto.TotalFee);
                command.ExecuteNonQuery();
            }
           
            return programDto;
        }
         public ICollection<ProgramDTO> GetAllPrograms()
        {
            var ProgramList = new List<ProgramDTO>();
            using (var connection = new SqliteConnection(_connectionString))
            {
                connection.Open();
                var command = connection.CreateCommand();
                command.CommandText = "SELECT * FROM Programs";
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        ProgramList.Add(new ProgramDTO()
                        {
                            Id = reader.GetInt32(0),
                            ProgramName = reader.GetString(1),
                            Type = reader.GetString(2),
                            TotalFee = reader.GetInt32(3)
                        });
                    }
                }
            }
            return ProgramList;

        }

        public ProgramDTO GetProgramById(int ProgramId)
        {
            using (var connection = new SqliteConnection(_connectionString))
            {
                connection.Open();
                var command = connection.CreateCommand();
                command.CommandText = "SELECT * FROM Programs WHERE Id == @id";
                command.Parameters.AddWithValue("@id", ProgramId);
                using (var reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        return new ProgramDTO()
                        {
                            Id = reader.GetInt32(0),
                            ProgramName = reader.GetString(1),
                            Type = reader.GetString(2),
                            TotalFee = reader.GetInt32(3)
                        };
                    }
                    else
                    {
                        throw new Exception("Program Not Found!");
                    }
                };
            };
            return null;
        }

        public void UpdateProgram(int ProgramID, int TotalFee)
        {

            if (TotalFee >= 0)
            {
                using (var connection = new SqliteConnection(_connectionString))
                {
                    connection.Open();
                    var command = connection.CreateCommand();
                    command.CommandText = "UPDATE Programs SET TotalFee = @totalFee  WHERE Id == @id";
                    command.Parameters.AddWithValue("@id", ProgramID);
                    command.Parameters.AddWithValue("@totalFee", TotalFee);
                    command.ExecuteNonQuery();
                }
            }
            else
            {
                throw new Exception("Fee is shoud be Positive Number.");
            }

        }


        public void DeleteProgram(int ProgramId)
        {
            var course = GetProgramById(ProgramId);
            if (course != null)
            {
                using (var connection = new SqliteConnection(_connectionString))
                {
                    connection.Open();
                    var command = connection.CreateCommand();
                    command.CommandText = "DELETE FROM Programs WHERE Id = @id";
                    command.Parameters.AddWithValue("@id", ProgramId);
                    command.ExecuteNonQuery();
                }
            }
            else
            {
                throw new Exception("Program Not Found");
            }

        }

    }
}
