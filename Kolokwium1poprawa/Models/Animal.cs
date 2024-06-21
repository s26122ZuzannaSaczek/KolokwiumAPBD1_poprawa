namespace Kolokwium1poprawa.Models;

public class Animal
{
    public int ID { get; set; }
    public string Name { get; set; } = string.Empty;
    public DateTime AdmissionDate { get; set; }
    public Owner OwnerID { get; set; } = null!;
    public AnimalClass AnimalClassID { get; set; }
    public List<Procedure> Procedures { get; set; } = null!;
}

public class Owner
{
    public int ID { get; set; }
    public string FnirstName { get; set; } = string.Empty;
    public string LastName { get; set; } = string.Empty;
}

public class Procedure
{
    public string Name { get; set; } = string.Empty;
    public string Describtion { get; set; } = string.Empty;
    public DateTime Date { get; set; }
}

public class AnimalClass
{
    public int ID { get; set; }
    public string Name { get; set; } = string.Empty;
}