using System.Text.Json.Serialization;

public class Clientes
{
  public int ClienteID { get; set; }
  public string? Nombre { get; set; }
  public string? Ciudad { get; set; }
  public string? CorreoElectronico { get; set; }

  [JsonIgnore]
  public virtual ICollection<Pedidos>? Pedidos { get; set; }
  
}