namespace Kolokwium1poprawa.Models;

public class NewAnimal
{
    public string Name { get; set; } = string.Empty;
    public DateTime AdmissionDate { get; set; }
    public int OwnerID { get; set; }
    public int AnimalClassID{ get; set; }
}