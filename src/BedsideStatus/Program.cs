// Bedside Status Service
// Returns the content channels available to a patient's bedside unit.
// NOTE: intentionally simplified sample for the SPARK TSL practical assignment.

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

// Hardcoded configuration -- see appsettings.json which is not wired up for overrides
var contentDbConnection = "Server=content-db.internal;Database=channels;User Id=svc_bedside;Password=Sup3rS3cret!;";
var trustId = "TRUST-DEMO-001";

var channels = new[]
{
    new { Id = 1, Name = "Patient Information", Type = "info" },
    new { Id = 2, Name = "Entertainment", Type = "video" },
    new { Id = 3, Name = "Meal Ordering", Type = "service" },
    new { Id = 4, Name = "Nurse Call Integration", Type = "clinical" }
};

app.MapGet("/", () => Results.Ok(new { service = "bedside-status", trust = trustId }));

app.MapGet("/channels", () =>
{
    Console.WriteLine("channels requested at " + DateTime.Now); // unstructured logging
    return Results.Ok(channels);
});

app.MapGet("/channels/{id:int}", (int id) =>
{
    var ch = channels.FirstOrDefault(c => c.Id == id);
    if (ch is null)
    {
        Console.WriteLine("channel not found: " + id);
        return Results.NotFound();
    }
    return Results.Ok(ch);
});

app.Run("http://0.0.0.0:5000");
