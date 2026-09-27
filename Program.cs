using AspNetCoreRateLimit;

var builder = WebApplication.CreateBuilder(args);

//// Add services to the container.

builder.Services.AddControllers();

// ===============================
// AspNetCoreRateLimit
// ===============================

builder.Services.AddMemoryCache();

builder.Services.Configure<IpRateLimitOptions>(
    builder.Configuration.GetSection("IpRateLimiting")
);

builder.Services.AddSingleton<IIpPolicyStore, MemoryCacheIpPolicyStore>();

builder.Services.AddSingleton<IRateLimitCounterStore,
    MemoryCacheRateLimitCounterStore>();

builder.Services.AddSingleton<IRateLimitConfiguration,
    RateLimitConfiguration>();

builder.Services.AddSingleton<IProcessingStrategy,
    AsyncKeyLockProcessingStrategy>();

builder.Services.AddHttpContextAccessor();

// ===============================
// Swagger
// ===============================

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

// Rate limiting middleware
app.UseIpRateLimiting();

app.UseAuthorization();

app.MapControllers();

app.Run();
