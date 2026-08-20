using CargoFlowAPI.Models;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddOpenApi();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.MapGet("/shipments", () =>
{
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

    return shipments;
});

app.Run();