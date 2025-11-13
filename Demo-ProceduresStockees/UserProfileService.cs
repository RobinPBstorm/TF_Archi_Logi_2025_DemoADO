using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo_ProceduresStockees
{
	internal class UserProfileService
	{

		private DbConnection _connection;

		public UserProfileService(string connectionString, string providerName)
		{
			DbProviderFactory factory = DbProviderFactories.GetFactory(providerName);
			_connection = factory.CreateConnection();
			_connection.ConnectionString = connectionString;
		}

		public void Register(string email, string password)
		{
			using (DbCommand cmd = _connection.CreateCommand())
			{
				cmd.CommandText = "SP_UserProfile_Insert";
				cmd.CommandType = CommandType.StoredProcedure;
				DbParameter param_email = cmd.CreateParameter();
				param_email.ParameterName = nameof(email);
				param_email.Value = email;
				DbParameter param_pwd = cmd.CreateParameter();
				param_pwd.ParameterName = nameof(password);
				param_pwd.Value = password;
				cmd.Parameters.Add(param_email);
				cmd.Parameters.Add(param_pwd);
				_connection.Open();
				cmd.ExecuteNonQuery();
				_connection.Close();
			}

		}

		public Guid Login(string email, string password)
		{
			using (DbCommand cmd = _connection.CreateCommand())
			{
				cmd.CommandText = "SP_UserProfile_CheckPassword";
				cmd.CommandType = CommandType.StoredProcedure;
				DbParameter param_email = cmd.CreateParameter();
				param_email.ParameterName = nameof(email);
				param_email.Value = email;
				DbParameter param_pwd = cmd.CreateParameter();
				param_pwd.ParameterName = nameof(password);
				param_pwd.Value = password;
				cmd.Parameters.Add(param_email);
				cmd.Parameters.Add(param_pwd);
				_connection.Open();
				using (DbDataReader reader = cmd.ExecuteReader())
				{
					if (reader.Read())
					{
						return (Guid)reader["UserId"];
					}
					throw new InvalidOperationException();
				}
				_connection.Close();
			}

		}
	}
}
