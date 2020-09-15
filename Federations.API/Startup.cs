using Federations.API.Filters;
using Federations.Application.Notifications;
using Federations.Application.Services;
using Federations.Data.Contexts;
using Federations.Data.Repositories;
using Federations.Domain.Repositories;
using Federations.Domain.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace Federations.API
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers(options => options.Filters.Add<NotificationFilter>());

            services.AddDbContextPool<InMemoryDatabaseContext>(options => options.UseInMemoryDatabase("federationsdb"));

            services.AddScoped<IFederationRepository, FederationRepository>();
            services.AddScoped<IFederationService, FederationService>();
            services.AddScoped<NotificationContext>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
