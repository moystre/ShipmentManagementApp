using BLL;
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
            DbInitializer.Initialize(new ShipmentContext());
            services.AddDbContext<ShipmentContext>(options => options.UseSqlServer(connectionString));
            */
            services.AddMvc();
            
            services.AddSingleton(Configuration);
            services.AddScoped<IBLLFacade, BLLFacade>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {

            if (env.IsDevelopment())
            {
                app.UseCors("MyPolicy");
                loggerFactory.AddConsole(Configuration.GetSection("Logging"));
                loggerFactory.AddDebug();
                app.UseDeveloperExceptionPage();

                var facade = new BLLFacade(Configuration);
                var product1 = facade.ShipmentService.Create(
                new BLL.BusinessObjects.ShipmentBO()
                {
                    ShipmentName = "#7865",
                    Customer = "CustomerOne",
                    CargoInfo = "CargoInformation",
                    CountryDepature = "Greenland",
                    CountryDelivery = "Germany",
                    ContainerQuantity = 342,
                    HandlingDetail = "Details",
                    FinishedDate = "Not finished",
                    Bill = 45675,
                    Cost = 999
                });
                var product2 = facade.ShipmentService.Create(
                new BLL.BusinessObjects.ShipmentBO()
                {
                    ShipmentName = "#6523",
                    Customer = "CustomerTwo",
                    CargoInfo = "CargoInformation",
                    CountryDepature = "Greenland",
                    CountryDelivery = "Germany",
                    ContainerQuantity = 543,
                    HandlingDetail = "Details",
                    FinishedDate = "Not finished",
                    Bill = 2375,
                    Cost = 995
                });
                var product3 = facade.ShipmentService.Create(
                new BLL.BusinessObjects.ShipmentBO()
                {
                    ShipmentName = "#2865",
                    Customer = "CustomerThree",
                    CargoInfo = "CargoInformation",
                    CountryDepature = "Greenland",
                    CountryDelivery = "Germany",
                    ContainerQuantity = 3242,
                    HandlingDetail = "Details",
                    FinishedDate = "Not finished",
                    Bill = 42315,
                    Cost = 992
                });
                var product4 = facade.ShipmentService.Create(
                new BLL.BusinessObjects.ShipmentBO()
                {
                    ShipmentName = "#7800",
                    Customer = "CustomerFour",
                    CargoInfo = "CargoInformation",
                    CountryDepature = "Greenland",
                    CountryDelivery = "Germany",
                    ContainerQuantity = 42,
                    HandlingDetail = "Details",
                    FinishedDate = "Not finished",
                    Bill = 55675,
                    Cost = 933
                });

            }
            app.UseMvc();
            app.UseCors(builder => builder.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());
            app.UseAuthentication();

        }
    }
}

