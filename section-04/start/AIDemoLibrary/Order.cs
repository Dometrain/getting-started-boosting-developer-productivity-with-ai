namespace AIDemoLibrary;

public class Order
{   
    public int Id { get; set; }
    public List<OrderLine> OrderLines { get; set; } = new List<OrderLine>();

}
