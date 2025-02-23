﻿using BLL;
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
using System.Collections.Generic;

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
            //DbInitializer.Initialize(new ShipmentContext());
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
                    CustomerName = "First Customer",
                    Address = "Downing Street 817 68-211 Las Potatos",
                    ContactPerson = "First Customer Contact Person",
                    Email = "emam32a@asre.com",
                    PhoneNumber = "+34 42342123",
                    WarehouseAddress = "WarHome C554 65234 Fizzo"
                });
                facade.CustomerService.Create(
                new CustomerBO()
                {
                    CustomerName = "Second Customer",
                    Address = "Downing Street 817 68-211 Las Potatos",
                    ContactPerson = "Second Customer Contact Person",
                    Email = "231ama@asre.com",
                    PhoneNumber = "+22 42342123",
                    WarehouseAddress = "WarHome C44 65234 Fizzo"
                });
                facade.CustomerService.Create(
                new CustomerBO()
                {
                    CustomerName = "Third Customer",
                    Address = "Gulerooods Street 817 68-211 Las Potatos",
                    ContactPerson = "Third Customer Contact Person",
                    Email = "dddeef@asre.com",
                    PhoneNumber = "+34 4232341123",
                    WarehouseAddress = "WarHome C52 65234 Fizzo"
                });
                var container1 = facade.ContainerService.Create(
                new ContainerBO()
                {
                    ContainerNumber = "#2386 ship 1",
                    Dangerous = "Yes",
                    Frozen = "Yes",
                    Size = "23 x 57 x 98",
                    ShipmentId = 1
                });
                var container2 = facade.ContainerService.Create(
                new ContainerBO()
                {
                    ContainerNumber = "#7648 ship 2",
                    Dangerous = "No",
                    Frozen = "No",
                    Size = "25 x 3 x 5",
                    ShipmentId = 1
                });
                var container3 = facade.ContainerService.Create(
                new ContainerBO()
                {
                    ContainerNumber = "#3132 ship 3",
                    Dangerous = "No",
                    Frozen = "No",
                    Size = "20 x 36 x 51",
                    ShipmentId = 2
                });


                facade.ShipmentService.Create(
                new ShipmentBO()
                {
                    ShipmentName = "#1111",
                    CargoInfo = "CargoInformation",
                    CountryDeparture = "Greenland",
                    CountryDelivery = "Germany",
                    ContainerQuantity = 342,
                    HandlingDetail = "Details",
                    FinishedDate = "Not finished",
                    Bill = 45675,
                    Cost = 999,
                    CustomerId = 1
                });
                facade.ShipmentService.Create(
                new ShipmentBO()
                {
                    ShipmentName = "#2222",
                    CargoInfo = "CargoInformation",
                    CountryDeparture = "Greenland",
                    CountryDelivery = "Germany",
                    ContainerQuantity = 543,
                    HandlingDetail = "Details",
                    FinishedDate = "Not finished",
                    Bill = 2375,
                    Cost = 995,
                    CustomerId = 2
                });
                facade.ShipmentService.Create(
                new ShipmentBO()
                {
                    ShipmentName = "#3333",
                    CargoInfo = "CargoInformation",
                    CountryDeparture = "Greenland",
                    CountryDelivery = "Germany",
                    ContainerQuantity = 3242,
                    HandlingDetail = "Details",
                    FinishedDate = "Not finished",
                    Bill = 42315,
                    Cost = 992,
                    CustomerId = 3
                });
                facade.ShipmentService.Create(
                new ShipmentBO()
                {
                    ShipmentName = "#4444",
                    CargoInfo = "CargoInformation",
                    CountryDeparture = "Greenland",
                    CountryDelivery = "Germany",
                    ContainerQuantity = 42,
                    HandlingDetail = "Details",
                    FinishedDate = "Not finished",
                    Bill = 55675,
                    Cost = 933,
                    CustomerId = 2
                });
                

                string password = "1234";
                byte[] passwordHashJoe, passwordSaltJoe;
                CreatePasswordHash(password, out passwordHashJoe, out passwordSaltJoe);

                facade.UserService.Create(
                    new UserBO()
                    {
                        Username = "UserJoe",
                        PasswordHash = passwordHashJoe,
                        PasswordSalt = passwordSaltJoe
                    });
            }
            app.UseMvc();
            app.UseCors(builder => builder.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());
            app.UseAuthentication();
        }

        private static void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt)
        {
            using (var hmac = new System.Security.Cryptography.HMACSHA512())
            {
                passwordSalt = hmac.Key;
                passwordHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
            }
        }
    }
}

