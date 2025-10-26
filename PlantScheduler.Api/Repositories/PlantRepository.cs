using System.Collections.Generic;
using System.Threading.Tasks;
using PlantScheduler.Api.Models;
using Dapper;
using Microsoft.Data.SqlClient;

namespace PlantScheduler.Api.Repositories
{
    public class PlantRepository
    {
        SqlConnection connection;

        public PlantRepository(string connectionString)
        {
            if (connection == null)
                connection = new SqlConnection(connectionString);
    
        }

        public List<PlantDto> GetPlants()
        {
            connection.Open();

            var query = "SELECT * FROM Plants";
            var plants = connection.Query<PlantDto>(query).ToList();
            connection.Close();

            return plants;
        }

        public bool AddPlant(PlantDto plant)
        {
            connection.Open();

            var query = $"INSERT INTO Plants (Id, Name, Species, LastWatered) VALUES ('{Guid.NewGuid()}', @Name, @Species, @LastWatered)";
            var result = connection.Execute(query, plant);
            connection.Close();

            return result > 0;
        }
    }
}