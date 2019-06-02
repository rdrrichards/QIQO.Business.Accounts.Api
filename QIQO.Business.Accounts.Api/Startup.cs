using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
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
            services.AddCors(options =>
            {
                options.AddPolicy("AnyOrigin", builder =>
                {
                    builder
                        .AllowAnyOrigin()
                        .AllowAnyHeader()
                        .AllowAnyMethod();
                });
            });

            services.AddScoped<IMainDBContext, MainDBContext>();
            RegisterMaps(services);
            RegisterRepositories(services);
            RegisterEntityServices(services);
            RegisterClientProxies(services);

            services.AddMvc();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app)
        {
            app.UseCors("AnyOrigin");
            app.UseMvc();
        }

        private static void RegisterMaps(IServiceCollection services)
        {
            services.AddTransient<IAccountMap, AccountMap>();
            services.AddTransient<IAddressMap, AddressMap>();
            services.AddTransient<IAttributeMap, AttributeMap>();
            services.AddTransient<ICommentMap, CommentMap>();
            services.AddTransient<ICompanyMap, CompanyMap>();
            services.AddTransient<IContactMap, ContactMap>();
            services.AddTransient<IFeeScheduleMap, FeeScheduleMap>();
            services.AddTransient<IPersonMap, PersonMap>();
        }

        private static void RegisterRepositories(IServiceCollection services)
        {
            services.AddTransient<IAccountRepository, AccountRepository>();
            services.AddTransient<IAddressRepository, AddressRepository>();
            services.AddTransient<IAttributeRepository, AttributeRepository>();
            services.AddTransient<ICommentRepository, CommentRepository>();
            services.AddTransient<ICompanyRepository, CompanyRepository>();
            services.AddTransient<IContactRepository, ContactRepository>();
            services.AddTransient<IFeeScheduleRepository, FeeScheduleRepository>();
            services.AddTransient<IPersonRepository, PersonRepository>();
        }

        private static void RegisterEntityServices(IServiceCollection services)
        {
            services.AddTransient<IAccountEntityService, AccountEntityService>();
            services.AddTransient<IAddressEntityService, AddressEntityService>();
            services.AddTransient<IAttributeEntityService, AttributeEntityService>();
            services.AddTransient<ICommentEntityService, CommentEntityService>();
            services.AddTransient<ICompanyEntityService, CompanyEntityService>();
            services.AddTransient<IContactEntityService, ContactEntityService>();
            services.AddTransient<IFeeScheduleEntityService, FeeScheduleEntityService>();
            services.AddTransient<IEmployeeEntityService, EmployeeEntityService>();
            services.AddTransient<IAccountPersonEntityService, AccountPersonEntityService>();
        }

        private static void RegisterClientProxies(IServiceCollection services)
        {
            services.AddTransient<IAccountService, AccountClient>();
            services.AddTransient<IAddressService, AddressClient>();
            services.AddTransient<ICompanyService, CompanyClient>();
            services.AddTransient<IFeeScheduleService, FeeScheduleClient>();
            services.AddTransient<IEmployeeService, EmployeeClient>();
        }
    }
}
