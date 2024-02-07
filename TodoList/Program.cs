using Microsoft.EntityFrameworkCore;
using TodoList.Data;


var builder = WebApplication.CreateBuilder(args);



// Add services to the container.
var connectionString = builder.Configuration.GetConnectionString("MySQLConnection");
builder.Services.AddDbContext<TodoContext>(options => options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString)));
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddControllers();

builder.Services.AddCors(options =>
{
	options.AddPolicy("Localhost",
		policy =>
		{
			policy.WithOrigins("http://localhost:5173/").AllowAnyHeader().AllowAnyHeader().AllowAnyOrigin().AllowAnyMethod();
		});
});


var app = builder.Build();

// Configure the HTTP request pipeline.
app.UseSwaggerUI();
app.UseHttpsRedirection();
app.UseCors();
app.MapControllers();
app.Run();
