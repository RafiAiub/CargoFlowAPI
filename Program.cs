using CargoFlowAPI.DTOs;
using CargoFlowAPI.Models;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddOpenApi();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

var shipments = new List<Shipment>
{
    new Shipment
    {
        Id = 1,
        TrackingNumber = "CF-2026-0001",
        Origin = "São Paulo",
        Destination = "Curitiba",
        Status = "In Transit",
        CreatedAt = DateTime.Now
    },
    new Shipment
    {
        Id = 2,
        TrackingNumber = "CF-2026-0002",
        Origin = "Rio de Janeiro",
        Destination = "Belo Horizonte",
        Status = "Delivered",
        CreatedAt = DateTime.Now
    }
};

var nextId = 3;

app.MapGet("/shipments", () =>
{
    return shipments;
});

app.MapGet("/shipments/{id}", (int id) =>
{
    var shipment = shipments.FirstOrDefault(s => s.Id == id);

    if (shipment is null)
    {
        return Results.NotFound();
    }

    return Results.Ok(shipment);
});

app.MapPost("/shipments", (CreateShipmentDto dto) =>
{
    var shipment = new Shipment
    {
        Id = nextId++,
        TrackingNumber = dto.TrackingNumber,
        Origin = dto.Origin,
        Destination = dto.Destination,
        Status = dto.Status,
        CreatedAt = DateTime.Now
    };

    shipments.Add(shipment);

    return shipment;
});

app.MapPut("/shipments/{id}", (int id, Shipment updatedShipment) =>
{
    var shipment = shipments.FirstOrDefault(s => s.Id == id);

    if (shipment is null)
    {
        return Results.NotFound();
    }

    shipment.TrackingNumber = updatedShipment.TrackingNumber;
    shipment.Origin = updatedShipment.Origin;
    shipment.Destination = updatedShipment.Destination;
    shipment.Status = updatedShipment.Status;

    return Results.Ok(shipment);
});

app.MapDelete("/shipments/{id}", (int id) =>
{
    var shipment = shipments.FirstOrDefault(s => s.Id == id);

    if (shipment is null)
    {
        return Results.NotFound();
    }

    shipments.Remove(shipment);

    return Results.NoContent();
});

app.Run();