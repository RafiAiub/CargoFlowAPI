namespace CargoFlowAPI.DTOs;

public class CreateShipmentDto
{
    public string TrackingNumber { get; set; } = string.Empty;

    public string Origin { get; set; } = string.Empty;

    public string Destination { get; set; } = string.Empty;

    public string Status { get; set; } = string.Empty;
}