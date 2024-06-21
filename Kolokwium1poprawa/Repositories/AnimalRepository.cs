using System.Data.SqlClient;
using Kolokwium1poprawa.Models;

namespace Kolokwium1poprawa.Repositories;


public class AnimalRepository : IAnimalRepository
{
    private readonly IConfiguration _configuration;

    public AnimalRepository(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    public async Task<bool> DoesAnimalExist(int Id)
    {
        var query = "SELECT 1 FROM Animal  WHERE ID = @ID";
        await using SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("Default"));
        await using SqlCommand command = new SqlCommand();

        command.Connection = connection;
        command.CommandText = query;
        command.Parameters.AddWithValue("@ID", Id);

        await connection.OpenAsync();

        var res = await command.ExecuteScalarAsync();
        return res is not null;
    }
    
    public async Task<bool> DoesOwnerExist(int Id)
    {
        var query = "SELECT 1 FROM Owner WHERE ID = @ID";
        await using SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("Default"));
        await using SqlCommand command = new SqlCommand();

        command.Connection = connection;
        command.CommandText = query;
        command.Parameters.AddWithValue("@ID", Id);

        await connection.OpenAsync();

        var res = await command.ExecuteScalarAsync();
        return res is not null;
    }
    
    public async Task<bool> DoesProcedureExist(int Id)
    {
        var query = "SELECT 1 FROM [Procedure] WHERE ID = @ID";
        await using SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("Default"));
        await using SqlCommand command = new SqlCommand();

        command.Connection = connection;
        command.CommandText = query;
        command.Parameters.AddWithValue("@ID", Id);

        await connection.OpenAsync();

        var res = await command.ExecuteScalarAsync();
        return res is not null;
    }

    public async Task<Animal> GetAnimal(int Id)
    {
        var query = @"SELECT 
							Animal.ID AS AnimalID,
							Animal.Name AS AnimalName,
							AnimalClassName,
							AdmissionDate,
							Owner.ID as OwnerID,
							FirstName,
							LastName,
							Date,
							[Procedure].Name AS ProcedureName,
							Description
						FROM Animal
						JOIN Animal_Class ON Animal_Class.ID = Animal.Animal_Class_ID
						JOIN Owner ON Owner.ID = Animal.Owner_ID
						JOIN Procedure_Animal ON Procedure_Animal.Animal_ID = Animal.ID
						JOIN [Procedure] ON [Procedure].ID = Procedure_Animal.Procedure_ID
						WHERE Animal.ID = @ID";
        
        await using SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("Default"));
        await using SqlCommand command = new SqlCommand();

        command.Connection = connection;
        command.CommandText = query;
        command.Parameters.AddWithValue("@ID", Id);

        await connection.OpenAsync();

        var reader = await command.ExecuteReaderAsync();

        var animalIDOrdinal = reader.GetOrdinal("AnimalID");
        var animalNameOrdinal = reader.GetOrdinal("AnimalName");
        var animalClassIDOrdinal = reader.GetOrdinal("AnimalClassID");
        var animalClassNameOrdinal = reader.GetOrdinal("AnimalClassName");
        var admissionDateOrdinal = reader.GetOrdinal("AdmissionDate");
        var ownerIDOrdinal = reader.GetOrdinal("OwnerID");
        var firstNameOrdinal = reader.GetOrdinal("FirstName");
        var lastNameOrdinal = reader.GetOrdinal("LastName");
        var dateOrdinal = reader.GetOrdinal("Date");
        var procedureNameOrdinal = reader.GetOrdinal("ProcedureName");
        var procedureDescriptionOrdinal = reader.GetOrdinal("Description");

        Animal animal = null;

        while (await reader.ReadAsync())
        {
	        if (animal is not null)
	        {
		        animal.Procedures.Add(new Procedure()
		        {
			        Date = reader.GetDateTime(dateOrdinal),
			        Name = reader.GetString(procedureNameOrdinal),
			        Describtion = reader.GetString(procedureDescriptionOrdinal)

		        });
	        }
	        else
	        {
		        animal = new Animal()
		        {
			        ID = reader.GetInt32(animalIDOrdinal),
			        Name = reader.GetString(animalNameOrdinal),
			        AnimalClass = new AnimalClass()
			        {
				        ID = reader.GetInt32(animalClassIDOrdinal),
				        Name = reader.GetString(animalClassNameOrdinal)
			        },
			        AdmissionDate = reader.GetDateTime(admissionDateOrdinal),
			        Owner = new Owner()
			        {
				        Id = reader.GetInt32(ownerIdOrdinal),
				        FirstName = reader.GetString(firstNameOrdinal),
				        LastName = reader.GetString(lastNameOrdinal),
			        }
		        }
	        }
        }
    }
    
}