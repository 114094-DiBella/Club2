var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.

//DataFirst
//Scaffold-DbContext "YourConnectionString" Microsoft.EntityFrameworkCore.SqlServer -OutputDir Models -Context YourDbContextName
//dotnet ef dbcontext scaffold "Data Source=DESKTOP-72P6KAS\SQLEXPRESS;Initial Catalog=PracticaUsuarios;Integrated Security=True;TrustServerCertificate=True" Microsoft.EntityFrameworkCore.SqlServer --context PracticaUsuariosContext --output-dir Models

//CodeFirst
//Add-Migration Inicial
//Update-Database

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
