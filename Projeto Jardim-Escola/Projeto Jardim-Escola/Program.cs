
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Projeto_Jardim_Escola.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

/**
 * Declarar a existência da base de dados.
 */
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection") ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(connectionString));
builder.Services.AddDatabaseDeveloperPageExceptionFilter();

/**
 * Declarar a existência do serviço de Autenticação
 *  e declaração da classe com os dados do utilizador registado.
 */
builder.Services.AddDefaultIdentity<IdentityUser>(
    options => options.SignIn.RequireConfirmedAccount = false)
    .AddRoles<IdentityRole>() // Adiciona a capacidade da app de identificar 'perfis' de utilizador.
    .AddEntityFrameworkStores<ApplicationDbContext>();

/**
 * Declarar o serviço das variáveis de sessão.
 */
builder.Services.AddDistributedMemoryCache();
builder.Services.AddSession(options => {
    options.IdleTimeout = TimeSpan.FromSeconds(120);
    options.Cookie.HttpOnly = true;
    options.Cookie.IsEssential = true;
});

/**
 * Configurar os cookies para poderem ser utilizados pela aplicação React.
 */
builder.Services.ConfigureApplicationCookie(options => { 
    options.Cookie.SameSite = SameSiteMode.None;
});

builder.Services.AddControllersWithViews();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseMigrationsEndPoint();
}
else
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

// Usar o serviço das variáveis de sessão.
app.UseSession();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");
app.MapRazorPages();

app.Run();
