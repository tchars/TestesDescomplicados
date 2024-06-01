using Microsoft.EntityFrameworkCore;
using TestesDescomplicados.Infra.Contexts;
using TestesDescomplicados.Infra.Repositories;
using TestesDescomplicados.UseCases.Usuarios.CriarUsuario;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddMediatR(cfg =>
{
    cfg.RegisterServicesFromAssemblyContaining<Program>();
    cfg.Lifetime = ServiceLifetime.Scoped;

    cfg.RegisterServicesFromAssemblyContaining(typeof(CriarUsuarioRequest));
});

builder.Services.AddDbContext<InMemoryContext>(opt => opt.UseInMemoryDatabase("Usuarios"));

builder.Services.AddScoped<IUsuarioRepository, UsuarioRepository>();
builder.Services.AddScoped<ISoftwareRepository, SoftwareRepository>();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

app.Run();
