using EDuBee.Application.Account;
using EDuBee.Application.Address;
using EDuBee.Application.Categories;
using EDuBee.Application.Common;
using EDuBee.Application.Documents;
using EDuBee.Application.SendMail;
using EDuBee.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EDuBee
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
            //setting email
            services.Configure<MailSetting>(Configuration.GetSection("MailSetting"));

            var connectionString = Configuration.GetConnectionString("MyConnection");
            services.AddDbContext<EDUBEE1Context>(item => item.UseSqlServer(connectionString));

            //DI
            services.AddTransient<IManageAccount, ManageAccount>();
            services.AddTransient<IMailService, MailService>();
            services.AddTransient<IManageDocument, ManageDocument>();
            services.AddTransient<IStorageService, StorageService>();
            services.AddTransient<IManageAddress, ManageAddress>();
            services.AddTransient<IManageCategory, ManageCategory>();
            services.AddHttpClient();
            //swagger
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "swagger EDUBEE", Version = "v1" });
            });

            services.AddControllers();
            //Cors
            services.AddCors(option => option.AddDefaultPolicy(
                builder => builder.AllowAnyOrigin()));
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

            //use swagger
            app.UseSwagger();

            //Cors
            app.UseCors();
            //cấu hình swagger ui
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Swagger EDUBEE version1");
            });

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
