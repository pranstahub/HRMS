using HRMS.Entity.Models;
using HRMS.Services.Repository.Interface;
using HRMS.Services.Repository.Implementation;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using HRMS.Entity.Security;
using NToastNotify;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews().AddRazorRuntimeCompilation().AddNewtonsoftJson(
    options => options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore).AddNToastNotifyToastr(
    new NToastNotify.ToastrOptions
    {
        TimeOut = 5000,
        NewestOnTop = true,
        CloseButton = true,
        CloseDuration = true,
        ProgressBar = true,
        PositionClass = ToastPositions.TopRight
    });
;


builder.Services.AddDbContext<ApplicationDbContext>(option =>
    option.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddScoped<iLeaveRepository, LeaveRepository>();
builder.Services.AddScoped<iOrganisationRepository, OrganisationRepository>();
builder.Services.AddScoped<iEmployeeRepository, EmployeeRepository>();

//builder.Services.AddScoped<ICategoryRepository, CategoryRepository>();
//builder.Services.AddScoped<IMenuRepository, MenuRepository>();



builder.Services.AddIdentity<ApplicationUser, IdentityRole>().AddEntityFrameworkStores<ApplicationDbContext>();

builder.Services.AddAuthorization(options =>
    options.AddPolicy("DeletePolicy", policy => policy.RequireClaim("Delete")));
builder.Services.AddAuthorization(options =>
    options.AddPolicy("EditPolicy", policy => policy.RequireClaim("Edit")));
builder.Services.AddAuthorization(options =>
    options.AddPolicy("CreatePolicy", policy => policy.RequireClaim("Create")));

//var logger = new LoggerConfiguration().ReadFrom.Configuration(builder.Configuration).CreateLogger();
//Log.Logger = logger;
//builder.Services.AddLogging(loggingBuilder => loggingBuilder.AddSerilog(dispose: true));

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
app.UseNToastNotify();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Account}/{action=Login}/{id?}");

app.Run();
