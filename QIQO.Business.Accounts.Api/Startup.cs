using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using QIQO.Business.Accounts.Proxies;
using QIQO.Business.Accounts.Proxies.Clients;
using QIQO.Business.Accounts.Data;
using QIQO.Business.Core.Contracts;
using QIQO.Business.Accounts.Proxies.Services;
using QIQO.Business.Accounts.Data.Interfaces;
using QIQO.Business.Accounts.Data.Repositories;
using QIQO.Business.Accounts.Data.Mappers;

namespace QIQO.Business.Accounts.Api
{
    public class Startup
    {
        public Startup(IHostingEnvironment env)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true)
                .AddEnvironmentVariables();
            Configuration = builder.Build();
        }

        public IConfigurationRoot Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddScoped<IMainDBContext, MainDBContext>();

            services.AddTransient<IAccountMap, AccountMap>();
            services.AddTransient<IAccountRepository, AccountRepository>();

            services.AddTransient<IAccountEntityService, AccountEntityService>();
            services.AddTransient<IAccountService, AccountClient>();

            services.AddMvc();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            loggerFactory.AddConsole(Configuration.GetSection("Logging"));
            loggerFactory.AddDebug();

            app.UseMvc();
        }
    }
}
