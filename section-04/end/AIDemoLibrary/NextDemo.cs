namespace AIDemoLibrary;

public class NextDemo
{  
    public decimal CalculateAverageOrderLinePrice(OrderLine[] orderLines)
    {
        decimal total = 0;
        foreach (var orderLine in orderLines)
        {
            total += orderLine.Price;
        }
        return total / orderLines.Length;
    }

}

