
using DemoADO.models;
using DemoADO.Repositories;
using Microsoft.Data.SqlClient;
using System.Data;

string connectionString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=ADO;Integrated Security=True";

SqlConnection connection = new SqlConnection(connectionString);

#region Code Robin
//// Vérifier que la connection est établie
//using (SqlConnection connection1 = connection)
//{
//    connection1.Open();

//    Console.WriteLine("Connection réussie");

//    connection1.Close();
//}

//SectionRepository sectionRepository = new SectionRepository(
//    new SqlConnection(connectionString));

//List<Section> sections = sectionRepository.GetAll();
//foreach(Section section in sections)
//{
//    Console.WriteLine($"{section.Id}: {section.SectionName}");
//}

//Section? oneSection = sectionRepository.GetOneById(1010);
//if (oneSection is not null)
//{
//    Console.WriteLine($"Voici la section 1010: {oneSection!.SectionName}");
//}
//else
//{
//    Console.WriteLine("Il n'y a pas de section 1010");
//}

//sections = sectionRepository.GetAllByName("Tourisme");
//foreach (Section section in sections)
//{
//    Console.WriteLine($"{section.Id}: {section.SectionName}");
//}
//Console.WriteLine("---Avant insertion---");
//Console.WriteLine(sectionRepository.Insert(1220, "Gestion du temps libre"));

//Console.WriteLine("---Après insertion---");

//sections = sectionRepository.GetAll();
//foreach (Section section in sections)
//{
//    Console.WriteLine($"{section.Id}: {section.SectionName}");
//}

//Console.WriteLine("---Suppression---");
//sectionRepository.Delete(1230); 
#endregion

SectionRepositoryDisconnected repository = new SectionRepositoryDisconnected(connection);

repository.Get();

foreach (DataRow row in repository.Section.Rows)
{
    Console.WriteLine($"{row["Id"]} - {row["SectionName"]} - {row["ReceptionDate"]}");
    if ((int)row["Id"] == 1010) {
        row.BeginEdit();
        row["SectionName"] = "ADO .net";
        row.EndEdit();
    }
}

repository.Update();
