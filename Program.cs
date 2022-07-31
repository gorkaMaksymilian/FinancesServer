using FinancesServer.Controllers;
using FinancesServer.Data;
using FinancesServer.Services;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using MudBlazor.Services;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();

// Register Mudblazor service
builder.Services.AddMudServices();

// Build SQL connection using connection string and user-sercrets
var sqlConBuilder = new SqlConnectionStringBuilder();
sqlConBuilder.ConnectionString = "Server=localhost,1433;Initial Catalog=FinancesDB";
sqlConBuilder.UserID = builder.Configuration["UserId"];
sqlConBuilder.Password = builder.Configuration["UserPassword"];

// Register custom DataAccess service with specified connection string
builder.Services.AddDbContext<FinancesDbContext>(opt => opt.UseSqlServer(sqlConBuilder.ConnectionString));

// Register repository for Income objects with dependency injection
builder.Services.AddScoped<IIncomeRepo, IncomeRepo>();
// Register repository for Expense objects with dependency injection
builder.Services.AddScoped<IExpenseRepo, ExpenseRepo>();

// Register AutoMapper
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

// Register HttpClient
builder.Services.AddHttpClient();

// Register Service that will reload selected component from another component
builder.Services.AddScoped<IReloadOtherComponentService, ReloadOtherComponentService>();


var app = builder.Build();

// Mapping custom controllers
app.MapControllers();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseRouting();

app.MapBlazorHub();
app.MapFallbackToPage("/_Host");

app.Run();
