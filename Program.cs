var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var connectionsStringMySql = builder.Configuration.GetConnectionString("ConnectionMySQL");
builder.Services.AddDbContext<ApiDbContext>(x => x.useMySql(
    connectionsStringMySql,
    Microsoft.EntityFrameworkCore.ServerVersion.Parse("10.4.22-MariaDB")
    )
);

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
