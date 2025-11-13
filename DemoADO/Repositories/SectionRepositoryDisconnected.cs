using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoADO.Repositories
{
    public class SectionRepositoryDisconnected
    {
        private DbConnection _connection;

        public DataTable Section { get; set; } = new DataTable();
        public DateTime? lastReception { get; private set; }

        private DbDataAdapter _adapter;

        public SectionRepositoryDisconnected(DbConnection connection, string providerName)
		{
			//Liaison de la connection
			_connection = connection;


			DbProviderFactory factory = DbProviderFactories.GetFactory(providerName);

            _adapter = factory.CreateDataAdapter()!;

            //Définition de la commande de récupération
            DbCommand selectCommand = _connection.CreateCommand();
            selectCommand.CommandText = "SELECT * FROM [Section]";

            //Définition de la commande de mise à jour
            DbCommand updateCommand = _connection.CreateCommand();
            updateCommand.CommandText = "UPDATE [Section] "
                + "SET [SectionName] = @sectionName "
                + "WHERE [Id] = @id";
            AddParam(updateCommand,"sectionName", DbType.String, 50, "SectionName");
            AddParam(updateCommand,"id", DbType.Int32, 0, "Id");

            //Définition de la commande d'insertion
            DbCommand insertCommand = _connection.CreateCommand();
            insertCommand.CommandText = "INSERT INTO [Section] ([Id], [SectionName]) "
                + "VALUES (@id, @sectionName)";
            AddParam(insertCommand, "sectionName", DbType.String, 50, "SectionName");
            AddParam(insertCommand,"id", DbType.Int32, 0, "Id");

            //Définition de la commande de suppression
            DbCommand deleteCommand = _connection.CreateCommand();
            deleteCommand.CommandText = "DELETE FROM [Section] WHERE [Id] = @id";
            AddParam(deleteCommand, "id", DbType.Int32, 0, "Id");

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
        private void AddParam(DbCommand command, string paramName, DbType paramType, int paramSize, string columnName)
        {
            DbParameter param = command.CreateParameter();
            param.ParameterName = paramName;
            param.DbType = paramType;
            param.Size = paramSize;
            param.SourceColumn = columnName;
            command.Parameters.Add(param);
        }
    }
}
