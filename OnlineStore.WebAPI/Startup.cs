using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http.Features;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using OnlineStore.Data;
using OnlineStore.Data.Repositories;
using OnlineStore.SharedClasses;
using OnlineStore.WebAPI.Services;
using Hangfire;

namespace OnlineStore.WebAPI
{
    public class Startup
    {
        public static IConfiguration Configuration { get; private set; }
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddCors(options =>
            {
                options.AddPolicy("AllowAllOrigins",
                    builder =>
                    {
                        builder
                        .AllowAnyOrigin()
                        .AllowAnyMethod()
                        .AllowAnyHeader()
                        .AllowCredentials();
                    });
            });

            services.Configure<FormOptions>(options =>
            {
                options.KeyLengthLimit = 10;
                //options.ValueLengthLimit = int.MaxValue;
                //options.MultipartBodyLengthLimit = long.MaxValue;
            });

            ConfigureDI(services);
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1); ;
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseCors("AllowAllOrigins");
            app.UseMiddleware(typeof(ErrorHandlingMiddleware));
            app.UseMvc();
            app.UseHangfireDashboard();
        }

        private static void ConfigureDI(IServiceCollection services)
        {
            services.AddScoped<IStoreRepository, StoreRepository>();
            services.AddScoped<IStoreService, StoreService>();
            services.AddDbContext<StoreDBContext>(options => options.UseSqlServer(Configuration.GetConnectionString("DbConnection")));
            services.AddHangfire(x => x.UseSqlServerStorage(Configuration.GetConnectionString("HangFireDB")));
            services.AddHangfireServer();
        }
    }
}
