using  Kolokwium1poprawa.Models;

namespace Kolokwium1poprawa.Repositories;

public interface IAnimalRepository
{
    Task<bool> DoesAnimalExist(int Id);
    Task<bool> DoesOwnerExist(int Id);
    Task<bool> DoesProcedureExist(int Id);
    Task<Animal> GetAnimal(int Id);

    Task AddNewProcedureAnimal(NewProcedureAnimal newProcedureAnimal);
}