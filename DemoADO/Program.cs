
using DemoADO.models;
using DemoADO.Repositories;
using Microsoft.Data.SqlClient;

string connectionString = "Data Source=desktop-hk4b100\\dataviz;Initial Catalog=ADO;Integrated Security=True;Trust Server Certificate=True";

SqlConnection connection = new SqlConnection(connectionString);

// Vérifier que la connection est établie
using (SqlConnection connection1 = connection)
{
    connection1.Open();

    Console.WriteLine("Connection réussie");

    connection1.Close();
}

SectionRepository sectionRepository = new SectionRepository(
    new SqlConnection(connectionString));

List<Section> sections = sectionRepository.GetAll();
foreach(Section section in sections)
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
