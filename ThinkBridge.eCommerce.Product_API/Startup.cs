using CoreNLogText;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ThinkBridge.eCommerce.Entity;

namespace ThinkBridge.eCommerce.Product_API
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
            services.AddControllers();

            var connectionstring = Configuration.GetConnectionString("ProductDB");

            services.AddDbContext<DBProductContext>(option

                =>
            option.UseSqlServer(connectionstring, sqlServerOptionsAction: sqloptions =>
             {
                 sqloptions.EnableRetryOnFailure(
                     maxRetryCount: 10,
                     maxRetryDelay: TimeSpan.FromMinutes(1),
                     errorNumbersToAdd: null
 );
             }
                ));
            services.AddSingleton<ILog, LogNLog>();
        }

        public static string GetEntityConnectionString(string connectionString)
        {
            SqlConnectionStringBuilder entityBuilder = new SqlConnectionStringBuilder();
            entityBuilder.ConnectionString = connectionString;
            return entityBuilder.ToString();

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });


        }
    }
}
