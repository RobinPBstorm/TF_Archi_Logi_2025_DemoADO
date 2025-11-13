using DemoADO.models;
using DemoADO.Repositories;
using Microsoft.Data;
using Microsoft.Data.SqlClient;
using System.Data;
using System.Data.Common;

string connectionString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=ADO;Integrated Security=True";

DbProviderFactories.RegisterFactory("Microsoft.Data.SqlClient", SqlClientFactory.Instance);

string providerName = "Microsoft.Data.SqlClient";

DbProviderFactory factory = DbProviderFactories.GetFactory(providerName);

//DbProviderFactory factory = SqlClientFactory.Instance;

DbConnection connection = factory.CreateConnection()!;
connection.ConnectionString = connectionString;

#region Code Robin

// Vérifier que la connection est établie
//using (DbConnection connection1 = connection)
//{
//    connection1.Open();

//    Console.WriteLine("Connection réussie");

//    connection1.Close();
//}

SectionRepository sectionRepository = new SectionRepository(connection);

List<Section> sections = sectionRepository.GetAll();
foreach (Section section in sections)
{
    Console.WriteLine($"{section.Id}: {section.SectionName}");
}

Section? oneSection = sectionRepository.GetOneById(1010);
if (oneSection is not null)
{
    Console.WriteLine($"Voici la section 1010: {oneSection!.SectionName}");
}
else
{
    Console.WriteLine("Il n'y a pas de section 1010");
}

sections = sectionRepository.GetAllByName("Tourisme");
foreach (Section section in sections)
{
    Console.WriteLine($"{section.Id}: {section.SectionName}");
}
Console.WriteLine("---Avant insertion---");
Console.WriteLine(sectionRepository.Insert(1220, "Gestion du temps libre"));

Console.WriteLine("---Après insertion---");

sections = sectionRepository.GetAll();
foreach (Section section in sections)
{
    Console.WriteLine($"{section.Id}: {section.SectionName}");
}

Console.WriteLine("---Suppression---");
sectionRepository.Delete(1230);

#endregion

SectionRepositoryDisconnected repository = new SectionRepositoryDisconnected(connection, providerName);

repository.Get();

ConsoleKey key;
do
{
    Console.Clear();
    for (int i = 0; i < repository.Section.Rows.Count; i++)
    {
        DataRow row = repository.Section.Rows[i];
        Console.WriteLine($"{i} - {row["Id"]} - {row["SectionName"]}");
    }

    Console.WriteLine("Que voulez-vous faire :");
    Console.WriteLine("[U]pdate - [C]reate - [D]elete - [Esc]ape");
    key = Console.ReadKey(true).Key;

    switch (key)
    {
        case ConsoleKey.U:
            Console.WriteLine("Indiquez le numéro de section :");
            int index_update = int.Parse(Console.ReadLine());
            DataRow section_to_update = repository.Section.Rows[index_update];
            Console.WriteLine($"Veuillez donner le nouveau nom pour la section \"{section_to_update["SectionName"]}\" :");
            section_to_update.BeginEdit();
            section_to_update["SectionName"] = Console.ReadLine();
            section_to_update.EndEdit();
            repository.UpdateDataSet();
            break;
        case ConsoleKey.C:
            DataRow section_to_add = repository.Section.NewRow();
            repository.Section.Rows.Add(section_to_add);
            Console.WriteLine("Veuillez indiquer un code de 4 chiffres pour l'identifiant de section :");
            section_to_add["Id"] = int.Parse(Console.ReadLine());
            Console.WriteLine("Veuillez indiquer un nom pour la section :");
            section_to_add["SectionName"] = Console.ReadLine();
            repository.UpdateDataSet();
            break;
        case ConsoleKey.D:
            Console.WriteLine("Indiquez le numéro de section :");
            int index_delete = int.Parse(Console.ReadLine());
            DataRow section_to_delete = repository.Section.Rows[index_delete];
            section_to_delete.Delete();
            repository.UpdateDataSet();
            break;
    } 
} while (key != ConsoleKey.Escape);