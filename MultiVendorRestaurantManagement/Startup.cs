using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
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
            services.AddDbContext<RestaurantContext>(options =>
            {
                // Configure the context to use Microsoft SQL Server.
                options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection"));
            });


            services.AddControllers();
            services.AddMediatR(typeof(Startup)); //command query handlers
            services.AddValidatorsFromAssembly(typeof(Startup).Assembly); //validators
            services.AddTransient(typeof(IPipelineBehavior<,>),
                typeof(RequestValidationBehaviour<,>)); //converting validation errors to formatted response
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();
            app.UseMiddleware<RequestValidationExceptionHandlerMiddleware>();

            app.UseAuthorization();

            app.UseEndpoints(endpoints => { endpoints.MapControllers(); });
        }
    }
}