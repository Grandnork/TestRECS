using Backend.Data;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddControllers();


// Register Entity Framework Core
// The database will be stored locally as expenses.db
builder.Services.AddDbContext<AppDbContext>(options =>
{
    options.UseSqlite("Data Source=expenses.db");
});


// Enable Swagger for API testing
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


// Allow React frontend to communicate with the API
builder.Services.AddCors(options =>
{
    options.AddPolicy("Frontend",
        policy =>
        {
            policy.AllowAnyOrigin()
                  .AllowAnyMethod()
                  .AllowAnyHeader();
        });
});


var app = builder.Build();


if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}


app.UseCors("Frontend");

app.MapControllers();

app.Run();