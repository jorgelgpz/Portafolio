using Portafolio.Servicios;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
//Me permite instanciar la clase cada vez que se pida, tiempo de vida de servicio corto
//AddTransient no necesita compartir datos entre instancias del servicio
//AddSingleton comparte datos entre otras instancias de otras peticiones http
//AddScoped comparte datos ente la misma instancia http
builder.Services.AddTransient<IRepositorioProyectos, RepositorioProyectos>();


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
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
