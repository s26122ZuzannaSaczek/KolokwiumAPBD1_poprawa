namespace Kolokwium1poprawa.Models;

public class NewProcedureAnimal
{
    public string Name { get; set; } = string.Empty;
    public DateTime AdmissionDate { get; set; } 
    public int OwnerID { get; set; }
    public int AnimalClassID{ get; set; }
    public IEnumerable<ProcedureDate> Precedures { get; set; } = new List<ProcedureDate>();
}

public class ProcedureDate
{
    public int ProcedureID { get; set; }
    public DateTime Date { get; set; }
}