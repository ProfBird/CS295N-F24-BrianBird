using BookReviews2024.Data;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

var userId = builder.Configuration["ConnectionStrings:MySqlUserId"];
var password = builder.Configuration["ConnectionStrings:MySqlPassword"];
var baseConnection = builder.Configuration.GetConnectionString("MySqlConnection");
var fullConnectionString = $"{baseConnection}userid={userId};password={password};";
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseMySql(fullConnectionString, ServerVersion.AutoDetect(fullConnectionString)));
builder.Services.AddTransient<IReviewRepository, ReviewRepository>();

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

// Get a DbContext object -- we will refactor this
using (var scope = app.Services.CreateScope())
{
    var dbContext = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
    SeedData.Seed(dbContext);
}

app.Run();
