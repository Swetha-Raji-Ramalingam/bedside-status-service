// Bedside Status Service
// Returns the content channels available to a patient's bedside unit.
// NOTE: intentionally simplified sample for the SPARK TSL practical assignment.

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddHealthChecks();

var app = builder.Build();

// Hardcoded configuration -- see appsettings.json which is not wired up for overrides
var contentDbConnection =
    builder.Configuration.GetConnectionString("ContentDb");

var trustId =
    builder.Configuration["TrustId"];

var channels = new[]
{
    new { Id = 1, Name = "Patient Information", Type = "info" },
    new { Id = 2, Name = "Entertainment", Type = "video" },
    new { Id = 3, Name = "Meal Ordering", Type = "service" },
    new { Id = 4, Name = "Nurse Call Integration", Type = "clinical" }
};

app.MapGet("/", () => Results.Ok(new { service = "bedside-status", trust = trustId }));

app.MapHealthChecks("/health/live");
app.MapHealthChecks("/health/ready");

app.MapGet("/channels", (ILogger<Program> logger) =>
{
    logger.LogInformation("Channels requested");
    return Results.Ok(channels);
});
app.MapGet("/channels/{id:int}", (int id, ILogger<Program> logger) =>
{
    var ch = channels.FirstOrDefault(c => c.Id == id);
    if (ch is null)
    {
        logger.LogWarning("Channel not found for id {ChannelId}", id);
        return Results.NotFound();
    }
    return Results.Ok(ch);
});

app.Run("http://0.0.0.0:5000");
