namespace CargoFlowAPI.DTOs;

public record ShipmentDto(string? TrackingNumber, string? Origin, string? Destination, string? Status);

public record StatusDto(string? Status);
