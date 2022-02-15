using AutoMapper;
using ContactsWebAPI.EfStuff;
using ContactsWebAPI.EfStuff.DbModel;
using ContactsWebAPI.EfStuff.Repository;
using ContactsWebAPI.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ContactsWebAPI
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
            string connectString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=WebContacts;Integrated Security=True;";
            services.AddDbContext<WebContext>(x => x.UseSqlServer(connectString));
            var provider = new MapperConfigurationExpression();
            provider.CreateMap<Author, AuthorViewModel>();
            provider.CreateMap<Text, TextViewModel>()
                .ForMember(vw => vw.AutrhorId, db => db.MapFrom(model => model.Author.Id));
            provider.CreateMap<Photo, PhotoViewModel>()
                .ForMember(vw => vw.AutrhorId, db => db.MapFrom(model => model.Author.Id));
            var mapperConfiguration = new MapperConfiguration(provider);
            var mapper = new Mapper(mapperConfiguration);
            services.AddScoped<IMapper>(x => mapper);

            services.AddScoped<AuthorRepository>();
            services.AddScoped<TextRepository>();
            services.AddScoped<PhotoRepository>();

            services.AddControllersWithViews();
            services.AddMvc();

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, ILoggerFactory loggerFactory)
        {
            loggerFactory.AddFile("Logs/Info-{Date}.txt",
                outputTemplate: "[{Level}] Smile {Timestamp:o} {Message} {NewLine}{Exception}");
            loggerFactory.AddFile("Logs/ERROR-{Date}.txt", LogLevel.Error);

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
            }

            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller}/{action}/{id?}");
            });
        }
    }
}
