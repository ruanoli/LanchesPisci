using LanchesPisci.Context;
using LanchesPisci.Models;
using LanchesPisci.Repositories;
using LanchesPisci.Repositories.Interface;
using LanchesPisci.Repository;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddDbContext<AppDbContext>(options => 
options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddTransient<ICategoriaRepository, CategoriaRepository>();
builder.Services.AddTransient<ILancheRepository, LancheRepository>();
builder.Services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>(); //vale por todo tempo de vida da minha aplicação.
builder.Services.AddScoped(x => CarrinhoCompra.GetCarrinho(x)); //cria uma instancia a cada request

builder.Services.AddDistributedMemoryCache();
builder.Services.AddSession();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "categoriaFiltro",
    pattern:"Lanche/{action}/{categoria?}",
    defaults: new {controller ="Lanche", action ="List"});

app.MapControllerRoute(
    name:"admin",
    pattern:"admin/{action=Index}/{id?}",
    defaults: new { controller = "Admin", Action = "Index" });


app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.UseSession();

app.Run();
