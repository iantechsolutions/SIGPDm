using BlazorApp1.Server.Context;
using BlazorApp1.Server.Repositorio.Contrato;
using BlazorApp1.Server.Repositorio.Implementacion;
using BlazorApp1.Server.Utilidades;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.FileProviders;
using Microsoft.IdentityModel.Tokens;
using System.Text;


var builder = WebApplication.CreateBuilder(args);
IConfiguration Configuration = builder.Configuration;
var MyCors = "_MyCors";

builder.Services.AddCors(options =>
{
    options.AddPolicy(name: MyCors,
        builder =>
        {
            builder.WithOrigins("*")
                                    .AllowAnyHeader()
                                    .AllowAnyMethod()
                                    .AllowAnyOrigin();
        });
});
builder.Services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(Configuration.GetConnectionString("DiMetalloConnection")));


/*AUTORIZACIÓN*/
builder.Services.AddIdentity<IdentityUser, IdentityRole>(options =>
{
    options.SignIn.RequireConfirmedAccount = true;
    options.Password.RequireDigit = false;
    options.Password.RequireLowercase = false;
    options.Password.RequireUppercase = false;
    options.Password.RequireNonAlphanumeric = false;
})
                .AddEntityFrameworkStores<ApplicationDbContext>()
                .AddDefaultTokenProviders();

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuer = false,
        ValidateAudience = false,
        ValidateLifetime = true,
        ValidateIssuerSigningKey = true,
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Configuration["jwt:key"])),
        ClockSkew = System.TimeSpan.Zero
    });
/*FIN*/
// Add services to the container.


builder.Services.AddControllersWithViews();
builder.Services.AddRazorPages();
builder.Services.AddHttpClient();


//activate interfaces
builder.Services.AddDbContext<DiMetalloContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DiMetalloConnection"));
});
builder.Services.AddAutoMapper(typeof(AutoMapperProfile));
builder.Services.AddScoped<IOCRepositorio, OCRepositorio>();
builder.Services.AddScoped<IInsumoRepositorio, InsumoRepositorio>();
builder.Services.AddScoped<IClienteRepositorio, ClienteRepositorio>();
builder.Services.AddScoped<IProveedoreRepositorio, ProveedoreRepositorio>();
builder.Services.AddScoped<ICotizacionesRepositorio, CotizacionesRepositorio>();
builder.Services.AddScoped<IPersonalRepositorio, PersonalRepositorio>();
builder.Services.AddScoped<IRepuestoRepositorio, RepuestoRepositorio>();
builder.Services.AddScoped<IOTRepositorio, OTRepositorio>();
builder.Services.AddScoped<IMateriaPrimaRepositorio, MateriaPrimaRepositorio>();
builder.Services.AddScoped<IPedidosPañolRepositorio,PedidosPañolRepositorio>();
builder.Services.AddScoped<IEventosProduccionRepositorio, EventosProduccionRepositorio>();
builder.Services.AddScoped<IMaquinasRepositorio, MaquinasRepositorio>();

builder.Services.AddControllersWithViews()
    .AddNewtonsoftJson(options =>
    options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore
);
var app = builder.Build();
if (app.Environment.IsDevelopment())
{
    app.UseWebAssemblyDebugging();
}
else
{
    app.UseExceptionHandler("/Error");
}
app.UseStaticFiles(new StaticFileOptions
{
    ServeUnknownFileTypes = true
});

string path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/planos");
if (!Directory.Exists(path))
{
    Directory.CreateDirectory(path);
}
app.UseStaticFiles(new StaticFileOptions()
{

    FileProvider = new PhysicalFileProvider(
        path),
    RequestPath = new PathString("/planos")
});
app.UseBlazorFrameworkFiles();
app.UseStaticFiles();


app.UseRouting();



app.UseAuthentication();
app.UseAuthorization();
app.UseEndpoints(endpoints =>
{
    endpoints.MapRazorPages();
    endpoints.MapControllers();
    endpoints.MapFallbackToFile("index.html");
});




app.Run();
