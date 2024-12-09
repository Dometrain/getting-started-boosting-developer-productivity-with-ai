namespace AIDemoLibrary;


/// <summary>
/// Provides accounting services.
/// </summary>
public class AccountingService
{

    /// <summary>
    /// Calculates the total price of the given orders.
    /// </summary>
    /// <param name="orders">The list of orders.</param>
    /// <returns>The total price of the orders.</returns>
    public decimal CalculateTotalPrice(List<Order> orders)
    {
        decimal totalPrice = 0;

        foreach (var order in orders)
        {
            foreach (var orderLine in order.OrderLines)
            {
                totalPrice += orderLine.Amount * orderLine.Price;
            }
        }

        return totalPrice;
    }

}
