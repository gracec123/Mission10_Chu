using Microsoft.EntityFrameworkCore;
using Mission10_Chu_API.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddCors();

// Configure the DbContext for BowlingLeagueContext using SQLite
builder.Services.AddDbContext<BowlingLeagueContext>(options =>
{
    options.UseSqlite(builder.Configuration["ConnectionStrings:BowlingConnection"]);
});

// Register the Bowling Repository and its implementation
builder.Services.AddScoped<IBowlingRepo, EFBowlingRepo>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors(p => p.WithOrigins("http://localhost:3000"));

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();