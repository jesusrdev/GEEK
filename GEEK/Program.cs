using GEEK.AccesoDatos.Data.Repository;
using GEEK.AccesoDatos.Data.Repository.IRepository;
using GEEK.Data;
using GEEK.Models;
using GEEK.Utilidades;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var connectionString = builder.Configuration.GetConnectionString("ConexionSQL");
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(connectionString));
builder.Services.AddDatabaseDeveloperPageExceptionFilter();

builder.Services.AddIdentity<Usuario, IdentityRole>(options => options.SignIn.RequireConfirmedAccount = false)
    .AddEntityFrameworkStores<ApplicationDbContext>()
    .AddDefaultUI();
builder.Services.AddControllersWithViews();


// Agregar contenedor de trabajo al contenedor IoC de inyeccion de dependencias
builder.Services.AddScoped<IContenedorTrabajo, ContenedorTrabajo>();

// Siembra de datos - Paso 1
//builder.Services.AddScoped<IInicializadorBD, InicializadorBD>();



var app = builder.Build();



using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    try
    {
        var context = services.GetRequiredService<ApplicationDbContext>();
        var userManager = services.GetRequiredService<UserManager<Usuario>>();
        var roleManager = services.GetRequiredService<RoleManager<IdentityRole>>();

        // Aquí realizamos la siembra de datos
        await SembrarDatos(context, userManager, roleManager);
    }
    catch (Exception ex)
    {
        var logger = services.GetRequiredService<ILogger<Program>>();
        logger.LogError(ex, "Ocurrió un error durante la siembra de la base de datos.");
    }
}


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


// Metodo que ejecuta la siembra de datos (Seeding)
//SiembraDatos();


app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();





app.MapControllerRoute(
    name: "default",
    pattern: "{area=Cliente}/{controller=Home}/{action=Index}/{id?}");
app.MapRazorPages();

app.Run();



async Task SembrarDatos(ApplicationDbContext context, UserManager<Usuario> userManager, RoleManager<IdentityRole> roleManager)
{
    // Aquí implementa la lógica de siembra de datos

    try
    {
        if (context.Database.GetPendingMigrations().Count() > 0)
        {
            context.Database.Migrate();
        }
    }
    catch (Exception)
    {

    }

    if (!context.Roles.Any())
    {
        // Creacion de roles
        roleManager.CreateAsync(new IdentityRole(CNT.Administrador)).GetAwaiter().GetResult();
        roleManager.CreateAsync(new IdentityRole(CNT.Registrado)).GetAwaiter().GetResult();
        roleManager.CreateAsync(new IdentityRole(CNT.Cliente)).GetAwaiter().GetResult();
    }


    // Datos del usuario administrador
    string adminEmail = "admin@gmail.com";
    string adminUsername = "admin@gmail.com";

    // Verificar si no existe un usuario con el mismo email o username
    var existingUser = await userManager.FindByEmailAsync(adminEmail);
    if (existingUser == null)
    {
        existingUser = await userManager.FindByNameAsync(adminUsername);
    }

    if (existingUser == null)
    {
        var usuario = new Usuario
        {
            UserName = adminUsername,
            Email = adminEmail,
            Nombre = "Admin",
            ApellidoUsuario = "Sistema",
            EmailConfirmed = true
        };

        var result = await userManager.CreateAsync(usuario, "Password123!");
        if (result.Succeeded)
        {
            await userManager.AddToRoleAsync(usuario, CNT.Administrador);
            Console.WriteLine("Usuario administrador creado exitosamente.");
        }
    }
    else
    {
        // El usuario ya existe, asegurémonos de que tiene el rol de Admin
        if (!await userManager.IsInRoleAsync(existingUser, CNT.Administrador))
        {
            await userManager.AddToRoleAsync(existingUser, CNT.Administrador);
            Console.WriteLine("Rol de Admin añadido al usuario existente.");
        }
        else
        {
            Console.WriteLine("El usuario administrador ya existe y tiene el rol de Admin.");
        }
    }

    //if (!context.Users.Any()
    //{
    //    var usuario = new Usuario
    //    {
    //        UserName = "admin@gmail.com",
    //        Email = "admin@gmail.com",
    //        EmailConfirmed = true,
    //        Nombre = "Super",
    //        ApellidoUsuario = "Admin"
    //    };

    //    userManager.CreateAsync(usuario, "Admin-123").GetAwaiter().GetResult();
    //    userManager.AddToRoleAsync(usuario, CNT.Administrador).GetAwaiter().GetResult();
    //}

}


// Implementando el metodo SiembraDatos()
//void SiembraDatos()
//{
//    using (var scope = app.Services.CreateScope())
//    {
//        var inicializadorBD = scope.ServiceProvider.GetRequiredService<IInicializadorBD>();
//        inicializadorBD.Inicializar();
//    }
//}