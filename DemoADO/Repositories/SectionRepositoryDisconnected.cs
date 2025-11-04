using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoADO.Repositories
{
    public class SectionRepositoryDisconnected
    {
        private SqlConnection _connection;

        public DataTable Section { get; set; } = new DataTable();
        public DateTime? lastReception { get; private set; }

        private SqlDataAdapter _adapter = new SqlDataAdapter();

        public SectionRepositoryDisconnected(SqlConnection connection)
        {
            //Liaison de la connection
            _connection = connection;

            //Définition de la commande de récupération
            SqlCommand selectCommand = _connection.CreateCommand();
            selectCommand.CommandText = "SELECT * FROM [Section]";

            //Définition de la commande de mise à jour
            SqlCommand updateCommand = _connection.CreateCommand();
            updateCommand.CommandText = "UPDATE [Section] "
                + "SET [SectionName] = @sectionName "
                + "WHERE [Id] = @id";
            updateCommand.Parameters.Add(new SqlParameter("sectionName", SqlDbType.VarChar, 50, "SectionName"));
            updateCommand.Parameters.Add(new SqlParameter("id", SqlDbType.Int, 0, "Id"));

            //Définition de la commande d'insertion
            SqlCommand insertCommand = _connection.CreateCommand();
            insertCommand.CommandText = "INSERT INTO [Section] ([Id], [SectionName]) "
                + "VALUES (@id, @sectionName)";
            insertCommand.Parameters.Add(new SqlParameter("sectionName", SqlDbType.VarChar, 50, "SectionName"));
            insertCommand.Parameters.Add(new SqlParameter("id", SqlDbType.Int, 0, "Id"));

            //Définition de la commande de suppression
            SqlCommand deleteCommand = _connection.CreateCommand();
            deleteCommand.CommandText = "DELETE FROM [Section] WHERE [Id] = @id";
            deleteCommand.Parameters.Add(new SqlParameter("id", SqlDbType.Int, 0, "Id"));

            //Affectation des commandes à notre adapteur
            _adapter.SelectCommand = selectCommand;
            _adapter.UpdateCommand = updateCommand;
            _adapter.InsertCommand = insertCommand;
            _adapter.DeleteCommand = deleteCommand;
        }

        public void Get()
        {
            _adapter.Fill(Section);
            lastReception = DateTime.Now;
        }

        public void UpdateDataSet() 
        { 
            _adapter.Update(Section);
        }
    }
}
