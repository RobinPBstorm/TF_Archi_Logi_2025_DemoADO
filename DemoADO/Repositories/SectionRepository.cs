using DemoADO.models;
using System.Data;
using System.Data.Common;

namespace DemoADO.Repositories
{
    public class SectionRepository
    {
        private readonly DbConnection _connection;

        public SectionRepository(DbConnection sqlConnection)
        {
            _connection = sqlConnection;
        }

        private Section Mapper(IDataRecord record)
        {
            return new Section((int)record["Id"], (string)record["SectionName"]);
        }

        // CRUD
        // Create
        public int Insert(Section section)
        {
            return Insert(section.Id, section.SectionName);
        }

        public int Insert(int id, string name)
        {
            int idInsert = -1;

            using (DbCommand command = _connection.CreateCommand())
            {
                command.CommandText = "INSERT INTO Section (Id, SectionName) " +
                    "OUTPUT inserted.Id " +
                    "VALUES (@id, @name)";
                //DbParameter id_param = command.CreateParameter();
                //id_param.ParameterName = "id";
                //id_param.Value = id;
                //command.Parameters.Add(id_param);
                AddParam(command, "id", id);
                AddParam(command, "name", name);

                try
                {
                    _connection.Open();
                    idInsert = (int)command.ExecuteScalar();
                    _connection.Close();
                }
                catch(Exception exception)
                {
                    // gestion de l'erreur
                    throw exception;
                }


            }

            return idInsert;
        }


        // Read
        public Section? GetOneById(int id)
        {
            Section? section = null;

            using (DbCommand command = _connection.CreateCommand())
            {
                command.CommandText = "SELECT * FROM Section WHERE Id = @id";
                AddParam(command,"id", id);
                _connection.Open();

                using (DbDataReader reader = command.ExecuteReader())
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

            using (DbCommand command = _connection.CreateCommand())
            {
                command.CommandText = "SELECT * FROM Section WHERE SectionName LIKE @name";
                AddParam(command, "name", name);

                _connection.Open();

                using (DbDataReader reader = command.ExecuteReader())
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

            using (DbCommand command = _connection.CreateCommand())
            {
                command.CommandText = "SELECT * FROM Section";

                _connection.Open();

                using(DbDataReader reader = command.ExecuteReader())
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
        /// <summary>
        /// Mise à jour de la table Section
        /// </summary>
        /// <param name="id">Identifiant de la section</param>
        /// <param name="section">Objet représentant les nouvelles valeurs de la section</param>
        /// <exception cref="ArgumentNullException"></exception>
        /// <exception cref="NullReferenceException"></exception>
        /// <exception cref="InvalidOperationException"></exception>
        public void Update(int id, Section section) {
            if (section is null) throw new ArgumentNullException(nameof(section), "La section ne peut être null");
            if (section.SectionName is null) throw new NullReferenceException("Le nom de la section ne peut être null");
            using (DbCommand command = _connection.CreateCommand())
            {
                command.CommandText = "UPDATE [Section] "
                    + "SET [SectionName] = @name "
                    + "WHERE [Id] = @id";
                AddParam(command,"name",section.SectionName);
                AddParam(command,"id",id);
                try
                {
                    _connection.Open();
                    if(command.ExecuteNonQuery() == 0) throw new InvalidOperationException("Opération de mise à jour invalide");
                    _connection.Close();
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }

        // Delete
        public void Delete(int id)
        {
            using (DbCommand command = _connection.CreateCommand())
            {
                command.CommandText = "DELETE FROM Section WHERE Id = @id";
                AddParam(command, "id", id);

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

        private void AddParam(DbCommand command, string paramName, object? value)
        {
            DbParameter param = command.CreateParameter();
            param.ParameterName = paramName;
            param.Value = value ?? DBNull.Value;
            command.Parameters.Add(param);
        }
    }
}
