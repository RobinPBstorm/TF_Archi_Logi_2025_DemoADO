using Microsoft.Data.SqlClient;
using System.Data.Common;

namespace Demo_ProceduresStockees
{
	internal class Program
	{
		static void Main(string[] args)
		{
			string connectionString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=UserSecurity;Integrated Security=True";

			DbProviderFactories.RegisterFactory("Microsoft.Data.SqlClient", SqlClientFactory.Instance);

			string providerName = "Microsoft.Data.SqlClient";

			UserProfileService service = new UserProfileService(connectionString, providerName);

			service.Register("sam@fait.rire", "Password");
			Console.WriteLine( service.Login("sam@fait.rire", "Password") );
		}
	}
}
