using Microsoft.EntityFrameworkCore;
using PreeceTechnology.Data;

var builder = WebApplication.CreateBuilder(args);

// Add the services to the container with the AddControllersWithViews().
builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<InventoryContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("InventoryContext")));
var app = builder.Build();

// Configure the HTTP request pipeline with Environment.IsDevelopment.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    
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
