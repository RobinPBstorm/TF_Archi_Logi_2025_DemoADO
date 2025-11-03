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
        public int Insert(int id, string name)
        {
            int idInsert = -1;

            using (SqlCommand command = _connection.CreateCommand())
            {
                command.CommandText = "INSERT INTO Section (Id, SectionName) " +
                    "OUTPUT inserted.Id " +
                    "VALUES (@id, @name)";
                command.Parameters.AddWithValue("id", id);
                command.Parameters.AddWithValue("name", name);

                _connection.Open();
                try
                {
                    idInsert = (int)command.ExecuteScalar();
                }
                catch(Exception exception)
                {
                    // gestion de l'erreur
                }

                _connection.Close();

            }

            return idInsert;
        }


        // Read
        public Section? GetOneById(int id)
        {
            Section? section = null;

            using (SqlCommand command = _connection.CreateCommand())
            {
                command.CommandText = "SELECT * FROM Section WHERE Id = @id";
                command.Parameters.AddWithValue("id", id);
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
        public List<Section> GetAllByName(string name)
        {
            List<Section> sections = new List<Section>();

            using (SqlCommand command = _connection.CreateCommand())
            {
                command.CommandText = "SELECT * FROM Section WHERE SectionName LIKE @name";
                command.Parameters.AddWithValue("name", name);

                _connection.Open();

                using (SqlDataReader reader = command.ExecuteReader())
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
        public void Delete(int id)
        {
            using (SqlCommand command = _connection.CreateCommand())
            {
                command.CommandText = "DELETE FROM Section WHERE Id = @id";
                command.Parameters.AddWithValue("id", id);

                _connection.Open();

                int nbLineDeleted = command.ExecuteNonQuery();

                _connection.Close();

                if (nbLineDeleted > 0)
                {
                    Console.WriteLine($"{nbLineDeleted} section(s) supprimée(s)");
                }
                else
                {
                    Console.WriteLine("Aucune section n'a été supprimé");
                }
            }
        }
    }
}
