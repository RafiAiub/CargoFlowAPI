namespace CargoFlowAPI.Models;

public class Shipment
{
    public static readonly string[] ValidStatuses =
        { "Pending", "In Transit", "Delivered", "Cancelled" };

    public int Id { get; set; }
    public string TrackingNumber { get; set; } = string.Empty;
    public string Origin { get; set; } = string.Empty;
    public string Destination { get; set; } = string.Empty;
    public string Status { get; set; } = "Pending";
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
}
