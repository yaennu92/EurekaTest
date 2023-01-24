using Microsoft.EntityFrameworkCore;
using Profil.DBContext;
using Steeltoe.Discovery.Client;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<PersonContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("default")));
builder.Services.AddDiscoveryClient(builder.Configuration);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;

    var context = services.GetRequiredService<PersonContext>();
    if (context.Database.GetPendingMigrations().Any()) context.Database.Migrate();

    Console.WriteLine(@"Done");
}
app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
