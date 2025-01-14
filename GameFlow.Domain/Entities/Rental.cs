namespace GameFlow.Domain.Entities;

public class Rental
{
    public Guid Id { get; set; }
    public Guid GameId { get; set; }
    public Game Game { get; set; }
    public Guid ClientId { get; set; }
    public Client Client { get; set; }
    public DateTime RentalDate { get; set; }
    public DateTime? RentalEndDate { get; set; }
    public string AdditionalInformation { get; set; }
    public string Occurrence { get; set; }
    public bool IsReturned { get; set; }
}
