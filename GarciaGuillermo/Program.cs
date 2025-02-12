using GarciaGuillermo.Context;
using GarciaGuillermo.Services.IServices;
using GarciaGuillermo.Services.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Configurar el DbContext antes de construir la aplicación
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("UserApiDb")));

// Agregar controladores con vistas
builder.Services.AddControllersWithViews();
builder.Services.AddTransient<IUsuarioServices, UsuarioServices>();

var app = builder.Build();

// Configurar el middleware de la aplicación
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts(); // Habilitar HSTS para entornos que no sean de desarrollo
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Usuario}/{action=Index}/{id?}");

app.Run();
