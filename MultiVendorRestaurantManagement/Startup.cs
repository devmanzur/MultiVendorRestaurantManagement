using System;
using System.Collections.Generic;
using FluentValidation;
using Hangfire;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using MultiVendorRestaurantManagement.Application.Deals.AddFoodToDeal;
using MultiVendorRestaurantManagement.Infrastructure;
using MultiVendorRestaurantManagement.PipelineBehaviour;

namespace MultiVendorRestaurantManagement
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.SetupInfrastructure(Configuration.GetConnectionString("SqlDatabase"));
            SwaggerSetup(services);
            services.AddControllers();
            services.AddMediatR(typeof(Startup)); //command query handlers
            services.AddValidatorsFromAssembly(typeof(Startup).Assembly); //validators
            services.AddTransient(typeof(IPipelineBehavior<,>),
                typeof(RequestValidationBehaviour<,>)); //converting validation errors to formatted response
            HangFireSetup(services);
            AddBackgroundJobs(services);
        }

        private void HangFireSetup(IServiceCollection services)
        {
            services.AddHangfire(x => x.UseSqlServerStorage(Configuration.GetConnectionString("SqlDatabase")));
            services.AddHangfireServer();
        }

        private void AddBackgroundJobs(IServiceCollection services)
        {
            services.AddScoped<IAddFoodToDealBackgroundJob, AddFoodToDealBackgroundJob>();
        }


        private static void SwaggerSetup(IServiceCollection services)
        {
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Version = "v1",

                    Title = "Restaurant API",
                    Description = "Restaurant API",
                    TermsOfService = new Uri("https://example.com/terms"),
                    Contact = new OpenApiContact
                    {
                        Name = "Noushad Hasan",
                        Email = "levirgon@gmail.com",
                        Url = new Uri("https://twitter.com/devmanzur")
                    },
                    License = new OpenApiLicense
                    {
                        Name = "Use under LICX",
                        Url = new Uri("https://example.com/license")
                    }
                });
                c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    Description = @"JWT Authorization header using the Bearer scheme. \r\n\r\n 
                      Enter 'Bearer' [space] and then your token in the text input below.
                      \r\n\r\nExample: 'Bearer 12345abcdef'",
                    Name = "Authorization",
                    In = ParameterLocation.Header,
                    Type = SecuritySchemeType.ApiKey,
                    Scheme = "Bearer"
                });
                c.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                    {
                        new OpenApiSecurityScheme
                        {
                            Reference = new OpenApiReference
                            {
                                Type = ReferenceType.SecurityScheme,
                                Id = "Bearer"
                            },
                            Scheme = "oauth2",
                            Name = "Bearer",
                            In = ParameterLocation.Header
                        },
                        new List<string>()
                    }
                });
            });
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment()) app.UseDeveloperExceptionPage();

            app.UseHttpsRedirection();
            
            app.UseHangfireServer();
            app.UseHangfireDashboard();
            
            app.UseRouting();
            app.UseMiddleware<RequestValidationExceptionHandlerMiddleware>();

            app.UseSwagger();

            app.UseSwaggerUI(c => { c.SwaggerEndpoint("/swagger/v1/swagger.json", "Restaurant API V1"); });
            app.UseAuthorization();

            app.UseEndpoints(endpoints => { endpoints.MapControllers(); });
        }
    }
}