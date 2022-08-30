using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Newtonsoft.Json.Serialization;
using Visa.BL.Interface;
using Visa.BL.Mapper;
using Visa.BL.Repository;
using Visa.DAL.Database;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews().AddNewtonsoftJson(opt => {
    opt.SerializerSettings.ContractResolver = new DefaultContractResolver();
});


#region  Connection String Configuration

var connectionString = builder.Configuration.GetConnectionString("ApplicationConnection");

builder.Services.AddDbContext<ApplicationContext>(options =>
options.UseSqlServer(connectionString));

#endregion

#region Auto Mapper

builder.Services.AddAutoMapper(x => x.AddProfile(new DomainProfile()));

#endregion

#region Generic Repository Configuration

builder.Services.AddScoped(typeof(IGenericRep<>), typeof(GenericRep<>));

#endregion

#region Unit of work Configuration

builder.Services.AddTransient<IUnitOfWork, UnitOfWork>();

#endregion


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
