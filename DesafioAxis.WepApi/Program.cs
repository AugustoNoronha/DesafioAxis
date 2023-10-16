using DesafioAxis.Domain.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "APIAxisDesafio", Description = "Desafio da empresa Axis", Version = "v1" });
});

string connectionString = builder.Configuration.GetConnectionString("PostgresConnection");

// Configura o contexto do Entity Framework para usar PostgreSQL
builder.Services.AddDbContext<DesafioAxisContext>(options =>
    options.UseNpgsql(connectionString));

var app = builder.Build();



if (!app.Environment.IsDevelopment())
{ 
    app.UseDeveloperExceptionPage();
}

app.UseSwagger();
app.UseSwaggerUI(c =>
{
    c.SwaggerEndpoint("/swagger/v1/swagger.json", "APIDesafioAxis v1");
});


app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();


app.Run();
