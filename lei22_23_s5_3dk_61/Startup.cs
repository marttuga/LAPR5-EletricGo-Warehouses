
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using DDDSample1.Infrastructure;

using DDDSample1.Infrastructure.Shared;
using DDDSample1.Infrastructure.Deliveries;
using DDDSample1.Infrastructure.Warehouses;
using DDDSample1.Domain.Shared;
using DDDSample1.Domain.Deliveries;
using DDDSample1.Domain.Warehouses;

namespace DDDSample1
{
    public class Startup
    {
        public readonly string LocalHostsAllowed = "_allowedLocalHosts";
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        /*public void ConfigureServices(IServiceCollection services)
        {
            /*services.AddDbContext<DDDSample1DbContext>(opt =>
                opt.UseSqlServer(Configuration["ConnectionStrings:DefaultConnection"]));#1#

            services.AddDbContext<DDDSample1DbContext>(opt =>
                opt.UseInMemoryDatabase("DDDSample1DB")
                    .ReplaceService<IValueConverterSelector, StronglyEntityIdValueConverterSelector>());
            
            ConfigureMyServices(services);
            

            services.AddControllers().AddNewtonsoftJson();
        }*/
        
        public void ConfigureServices(IServiceCollection services)
        {

            services.AddControllers().AddNewtonsoftJson();
            services.AddCors(options => { options.AddPolicy("AllowAll", builder => { builder.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader(); }); });

            services.AddDbContext<DDDSample1DbContext>(opt =>
                opt.UseMySql(Configuration.GetConnectionString("DefaultConnection"),
                        new MySqlServerVersion(new System.Version(10, 4, 17)))
                    .ReplaceService<IValueConverterSelector, StronglyEntityIdValueConverterSelector>()
            );
            ConfigureMyServices(services);
            //services.AddDbContext<DDDSample1DbContext>(opt =>
            //  opt.UseInMemoryDatabase("DDDSample1DB")
            // .ReplaceService<IValueConverterSelector, StronglyEntityIdValueConverterSelector>());
            ConfigureMyServices(services);



            services.AddControllers().AddNewtonsoftJson();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseCors(LocalHostsAllowed);

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }

        public void ConfigureMyServices(IServiceCollection services)
        {
            services.AddCors(opt =>
            {
                opt.AddPolicy(LocalHostsAllowed, b =>
                {
                    b.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod();
                });
            });
            
            services.AddTransient<IUnitOfWork,UnitOfWork>();

            

            services.AddTransient<IDeliveryRepository,DeliveryRepository>();
            services.AddTransient<IDeliveryService, DeliveryService>();

            services.AddTransient<IWarehouseRepository,WarehouseRepository>();
            services.AddTransient<IWarehouseService, WarehouseService>();
        }
    }
}
