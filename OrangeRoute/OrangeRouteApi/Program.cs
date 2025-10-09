using Microsoft.EntityFrameworkCore;
using OrangeRouteBusiness;
using OrangeRouteData;
using OrangeRouteModel;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddOpenApi();

builder.Services.AddScoped<ICrudOrangeRoute<TipoUsuarioModel>, TipoUsuarioService>();
builder.Services.AddScoped<ICrudOrangeRoute<UsuarioModel>, UsuarioService>();
builder.Services.AddScoped<ICrudOrangeRoute<TrilhaCarreiraModel>, TrilhaCarreiraService>();
builder.Services.AddScoped<ICrudOrangeRoute<TagModel>, TagService>();
builder.Services.AddScoped<ICrudOrangeRoute<TagPostModel>, TagPostService>();
builder.Services.AddScoped<ICrudOrangeRoute<FavoritosModel>, FavoritosService>();
builder.Services.AddScoped<ICrudOrangeRoute<ComentarioModel>, ComentarioService>();


builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseOracle(builder.Configuration.GetConnectionString("DefaultConnection")));

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

await app.RunAsync();
