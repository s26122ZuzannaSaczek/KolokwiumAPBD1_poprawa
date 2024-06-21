namespace Kolokwium1poprawa.Models;

public class Animal
{
    public int ID { get; set; }
    public string Name { get; set; }
    public DateTime AdmissionDate { get; set; }
    public _OwnerID OwnerID { get; set; }
    public _AnimalClassID AnimalClassID { get; set; }
    public List<Procedure> Procedures { get; set; }
}

public class _OwnerID
{
    public int ID { get; set; }
    public string FnirstName { get; set; }
    public string LastName { get; set; }
}

public class Procedure
{
    public string Name { get; set; }
    public string Describtion { get; set; }
    public DateTime Date { get; set; }
}

public class _AnimalClassID
{
    public int ID { get; set; }
    public string Name { get; set; }
}