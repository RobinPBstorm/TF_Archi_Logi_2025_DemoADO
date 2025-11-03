using DemoADO.models;
using Microsoft.Data.SqlClient;
using System.Data;

namespace DemoADO.Repositories
{
    public class SectionRepository
    {
        private readonly SqlConnection _connection;

        public SectionRepository(SqlConnection sqlConnection)
        {
            _connection = sqlConnection;
        }

        private Section Mapper(IDataRecord record)
        {
            return new Section((int)record["Id"], (string)record["SectionName"]);
        }

        // CRUD
        // Create


        // Read
        public Section? GetOneById(int id)
        {
            Section? section = null;

            using (SqlCommand command = _connection.CreateCommand())
            {
                command.CommandText = $"SELECT * FROM Section WHERE Id = {id}";
                _connection.Open();

                using (SqlDataReader reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        section = Mapper(reader);
                    }
                }

                _connection.Close();

            }

            return section;
        }

        public List<Section> GetAll()
        {
            List<Section> sections = new List<Section>();

            using (SqlCommand command = _connection.CreateCommand())
            {
                command.CommandText = "SELECT * FROM Section";

                _connection.Open();

                using(SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        sections.Add(Mapper(reader));
                    }
                }

                _connection.Close();
            }

            return sections;
        }

        // Update

        // Delete
    }
}
