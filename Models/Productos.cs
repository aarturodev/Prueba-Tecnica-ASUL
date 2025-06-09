using System.Text.Json.Serialization;

public class Productos
{
  public int ProductoID { get; set; }
  public string? Nombre { get; set; }
  public double? Precio { get; set; }

  [JsonIgnore]
  public virtual ICollection<Pedidos>? Pedidos { get; set; }
}