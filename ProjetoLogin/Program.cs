using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.BlazorIdentity.Pages;
using ProjetoLogin.Libraries.Sessao;
using ProjetoLogin.Models.Repository;
using ProjetoLogin.Models.Repository.Contract;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddHttpContextAccessor();

// Add services to the container.
builder.Services.AddControllersWithViews();

//adicionar a interface como um servço
builder.Services.AddScoped<IClienteRepository, ClienteRepository>();
builder.Services.AddScoped<IColaboradorRepository, ColaboradorRepository>();
builder.Services.AddScoped<ProjetoLogin.Libraries.Sessao.Sessao>();
builder.Services.AddScoped<ProjetoLogin.Libraries.Login.LoginCliente>();

// Corrigir problema com TEMPDATA
builder.Services.AddDistributedMemoryCache();
builder.Services.AddSession(options =>
{
  // Definir um tempo para duração. 
  options.IdleTimeout = TimeSpan.FromSeconds(900);
  options.Cookie.HttpOnly = true;
  // Mostrar para o navegador que o cookie e essencial   
  options.Cookie.IsEssential = true;
});
builder.Services.AddMvc().AddSessionStateTempDataProvider();



var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseStaticFiles();
app.UseRouting();
app.UseAuthorization();
app.Run();
app.UseCookiePolicy();
app.UseSession();
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");


