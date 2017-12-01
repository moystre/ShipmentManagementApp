using BLL;
using BLL.BusinessObjects;
using DAL;
using DAL.Context;
using DAL.Entities;
using DAL.Repositories;
using DemoBLL;
using DemoBLL.Facade;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using RestAPI.Helpers;
using System;

namespace RestAPI
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
            //Console.WriteLine("wrong config");
        }

        public Startup(IHostingEnvironment env)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true)
                .AddEnvironmentVariables();
            Configuration = builder.Build();
            JwtSecurityKey.SetSecret("a secret that needs to be at least 16 characters long");
            //Console.WriteLine("right config");
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(options =>
            {
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateAudience = false,
                    //ValidAudience = "TodoApiClient",
                    ValidateIssuer = false,
                    //ValidIssuer = "TodoApi",
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = JwtSecurityKey.Key,
                    ValidateLifetime = true, //validate the expiration and not before values in the token
                    ClockSkew = TimeSpan.FromMinutes(5) //5 minute tolerance for the expiration date
                };
            });

            services.AddCors(o => o.AddPolicy("MyPolicy", builder =>
            {
                builder.AllowAnyOrigin()
                .AllowAnyMethod()
            .AllowAnyHeader();
            }));
            /*
            var connectionString = @"Server=tcp:shipmentmanagement-server.database.windows.net,1433;Initial Catalog=ShipmentManagementDB;Persist Security Info=False;User ID=shipmentmanagementlogin;Password=MakeThisWork!;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";
            services.AddDbContext<ShipmentContext>(options => options.UseSqlServer(connectionString));
            */
            services.AddMvc();
            DbInitializer.Initialize(new ShipmentContext());
            services.AddSingleton(Configuration);
            services.AddScoped<IBLLFacade, BLLFacade>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory, IBLLFacade facade, IConfiguration config)
        {

            if (env.IsDevelopment())
            {
                app.UseCors("MyPolicy");
                loggerFactory.AddConsole(Configuration.GetSection("Logging"));
                loggerFactory.AddDebug();
                app.UseDeveloperExceptionPage();

                

                facade.CustomerService.Create(
                new CustomerBO()
                {
                    CustomerName = "Jeff Jiff",
                    Address = "Downing Street 817 68-211 Las Potatos",
                    ContactPerson = "Contact Persona",
                    Email = "emam32a@asre.com",
                    PhoneNumber = "+34 42342123",
                    WarehouseAddress = "WarHome C554 65234 Fizzo"
                });
                facade.CustomerService.Create(
                new CustomerBO()
                {
                    CustomerName = "Dominika Deraosasa",
                    Address = "Downing Street 817 68-211 Las Potatos",
                    ContactPerson = "Contact Persona",
                    Email = "231ama@asre.com",
                    PhoneNumber = "+22 42342123",
                    WarehouseAddress = "WarHome C44 65234 Fizzo"
                });
                facade.CustomerService.Create(
                new CustomerBO()
                {
                    CustomerName = "Tarta de Nassad",
                    Address = "Gulerooods Street 817 68-211 Las Potatos",
                    ContactPerson = "Contact Persona",
                    Email = "dddeef@asre.com",
                    PhoneNumber = "+34 4232341123",
                    WarehouseAddress = "WarHome C52 65234 Fizzo"
                });


                facade.ShipmentService.Create(
                new ShipmentBO()
                {
                    ShipmentName = "#7865",
                    CargoInfo = "CargoInformation",
                    CountryDeparture = "Greenland",
                    CountryDelivery = "Germany",
                    ContainerQuantity = 342,
                    HandlingDetail = "Details",
                    FinishedDate = "Not finished",
                    Bill = 45675,
                    Cost = 999,
                    CustomerId = 2
                });
                facade.ShipmentService.Create(
                new ShipmentBO()
                {
                    ShipmentName = "#6523",
                    CargoInfo = "CargoInformation",
                    CountryDeparture = "Greenland",
                    CountryDelivery = "Germany",
                    ContainerQuantity = 543,
                    HandlingDetail = "Details",
                    FinishedDate = "Not finished",
                    Bill = 2375,
                    Cost = 995,
                    CustomerId = 1
                });
                facade.ShipmentService.Create(
                new ShipmentBO()
                {
                    ShipmentName = "#2865",
                    CargoInfo = "CargoInformation",
                    CountryDeparture = "Greenland",
                    CountryDelivery = "Germany",
                    ContainerQuantity = 3242,
                    HandlingDetail = "Details",
                    FinishedDate = "Not finished",
                    Bill = 42315,
                    Cost = 992,
                    CustomerId = 1
                });
                facade.ShipmentService.Create(
                new ShipmentBO()
                {
                    ShipmentName = "#7800",
                    CargoInfo = "CargoInformation",
                    CountryDeparture = "Greenland",
                    CountryDelivery = "Germany",
                    ContainerQuantity = 42,
                    HandlingDetail = "Details",
                    FinishedDate = "Not finished",
                    Bill = 55675,
                    Cost = 933,
                    CustomerId = 3
                });
                facade.ContainerService.Create(
                new ContainerBO()
                {
                    ContainerNumber = "#2357",
                    Dangerous = "No",
                    Frozen = "No",
                    Size = "235",
                    ShipmentId = 1
                });
                facade.ContainerService.Create(
                new ContainerBO()
                {
                    ContainerNumber = "#2357",
                    Dangerous = "No",
                    Frozen = "No",
                    Size = "235",
                    ShipmentId = 1
                });
                facade.ContainerService.Create(
                new ContainerBO()
                {
                    ContainerNumber = "#2357",
                    Dangerous = "No",
                    Frozen = "No",
                    Size = "235",
                    ShipmentId = 1
                });
            }
            app.UseMvc();
            app.UseCors(builder => builder.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());
            app.UseAuthentication();
        }
    }
}

