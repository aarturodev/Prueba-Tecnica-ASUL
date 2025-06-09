using System.Text.Json.Serialization;

public class Pedidos
{
  public int PedidosID { get; set; }
  public int ClienteID { get; set; }
  public int ProductoID { get; set; }
  public int Cantidad { get; set; }
  public DateTime Fecha { get; set; }


  public virtual Clientes? Cliente { get; set; } 
  public virtual Productos? Producto { get; set; } 
}