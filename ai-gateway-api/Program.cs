using CommerceAIAgents.Models;

using CommerceAIAgents.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSwaggerGen();

builder.Services.AddControllers();

builder.Services.AddScoped<RecommendationService>();

builder.Services.AddScoped<CatalogService>();

builder.Services.AddScoped<ICommerceService,
    MockCommerceService>();

builder.Services
    .AddSingleton<
        IRetailServerClient,
        RetailServerClient>();

builder.Services
    .AddSingleton<
        IAuthService,
        MockAuthService>();
        
builder.Services.AddHttpClient<CommerceHttpClient>();

builder.Services.AddScoped<IAIService, OpenAIService>();

builder.Services.Configure<OpenAISettings>(
    builder.Configuration.GetSection("OpenAI"));

builder.Services.Configure<CommerceSettings>(
    builder.Configuration
    .GetSection("Commerce"));

builder.Services.Configure<AuthSettings>(
    builder.Configuration
    .GetSection("Auth"));

var app = builder.Build();

app.UseSwagger();

app.UseSwaggerUI();

app.MapGet("/", () =>
{
    return "D365 Commerce AI API Running";
});

app.MapGet("/weatherforecast", () =>
{
    return new[]
    {
        "Working"
    };
});

app.MapControllers();

app.Run();