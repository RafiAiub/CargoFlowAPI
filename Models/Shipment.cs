namespace CargoFlowAPI.Models;

public class Shipment
{
	public int Id { get; set; }

	public string TrackingNumber { get; set; } = string.Empty;

	public string Origin { get; set; } = string.Empty;

	public string Destination { get; set; } = string.Empty;

	public string Status { get; set; } = string.Empty;

	public DateTime CreatedAt { get; set; }
}