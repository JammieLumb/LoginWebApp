var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Login/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "login",
    pattern: "login",
    defaults: new { controller = "Login", action = "Index" });

app.MapControllerRoute(
    name: "studentDashboard",
    pattern: "dashboard/student/{id}",
    defaults: new { controller = "Dashboard", action = "StudentDashboard" });

app.MapControllerRoute(
    name: "supervisorDashboard",
    pattern: "dashboard/supervisor",
    defaults: new { controller = "Dashboard", action = "SupervisorDashboard" });

app.MapControllerRoute(
    name: "lecturerDashboard",
    pattern: "dashboard/lecturer",
    defaults: new { controller = "Dashboard", action = "LecturerDashboard" });

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Login}/{action=Index}/{id?}");

app.Run();
