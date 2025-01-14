namespace GameFlow.Domain.Entities;

public class Client
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string Email { get; set; }
    public DateTime DateOfBirth { get; set; }
    public bool IsSubscriber { get; set; }
    public DateTime? SubscriptionExpiryDate { get; set; }
    public List<Rental> Rentals { get; set; } = new List<Rental>(); 
}
