// A model representing a customers order at the cash register
public class CustomerOrder
{
    // If the customer is buying a movie ticket
    public bool MovieTicket { get; set; }

    // Name of drink along with the size cup
    public string Drink { get; set; } = string.Empty;

    // Popcorn and the size of the bag
    public string Popcorn { get; set; } = string.Empty;
}
