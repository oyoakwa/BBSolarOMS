using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BBSolarOMS.Entities;
using BBSolarOMS.Model.InstallerModels;
using BBSolarOMS.Model.DistributorModels;
using BBSolarOMS.Services.InstallerRepo;
using BBSolarOMS.Services.DistributorRepo;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Formatters;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using BBSolarOMS.Helpers;
using BBSolarOMS.Services.ProductRepo;
using BBSolarOMS.Model.ProductModels;

namespace BBSolarOMS
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
            services.AddMvc(setupAction=> 
            {
                setupAction.ReturnHttpNotAcceptable = true;
                setupAction.OutputFormatters.Add(new XmlDataContractSerializerOutputFormatter());
            });
            services.AddDbContext<BBSolarOMSContext>(o => o.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));

            services.AddScoped<I_InstallerRepository, InstallerRepository>();
            services.AddScoped<IDistributorRepository, DistributorRepository>();
            services.AddScoped<IProductRepo, ProductRepo>();

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseBrowserLink();
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler(appBuilder =>
                {
                    appBuilder.Run(async context =>
                    {
                        context.Response.StatusCode = 500;
                        await context.Response.WriteAsync("An unexpected error occured, Please try agsin later");
                    });
                });
            }
            AutoMapper.Mapper.Initialize(cfg =>
            {
                cfg.CreateMap<Installers, InstallerDto>()
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src =>
                    $"{src.FirstName} {src.LastName}"))
                .ForMember(dest => dest.Age, opt => opt.MapFrom(src => src.DOB.GetCurrentAge()));
       
                cfg.CreateMap<InstallerForCreationDto, Installers>();
                cfg.CreateMap<InstallerForUpdateDto, Installers>();

                cfg.CreateMap<Distributor, DistributorDto>()
                .ForMember(dest=>dest.Name, opt=>opt.MapFrom(src=>
                $"{src.FirstName} {src.LastName}"));
                cfg.CreateMap<DistributorForCreationDto, Distributor>();
                cfg.CreateMap<Distributor, DistributorForUpdateDto>();
                cfg.CreateMap<Installers, InstallerForUpdateDto>();
                cfg.CreateMap<Products, ProductDto>();
                cfg.CreateMap<ProductForCreationDto, Products>();
                
            });
            //app.UseStaticFiles();

            app.UseMvc();
        }
    }
}
