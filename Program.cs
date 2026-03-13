var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

// 1. GET / isteği: {"msg":"BC4M"} döner
app.MapGet("/", () => new { msg = "BC4M" });

// 2. GET /health isteği: Uygulamanın sağlık durumunu kontrol eder
app.MapGet("/health", () => Results.Ok(new { status = "Healthy" }));

// 3. POST / isteği: Body'de gelen verileri geri döner
app.MapPost("/", (object body) => Results.Ok(body));

// Docker içinde 5000 portundan dinlemesi için
app.Run("http://0.0.0.0:5000");