using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using DataAccess;
using AdviceLib.IRepository;
using AdviceLib.Models;

using Microsoft.OpenApi.Models;
using System.Reflection;
using System.IO;
using AdviceLib.Repositories;

namespace Advice
{
    /// <summary>
    /// 
    /// </summary>
    public class Startup
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="configuration"></param>
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        // ----------------------------- Cors -----------------------------
        readonly string MyAllowSpecificationOrigins = "_myAllowSpecificOrigins";
        // ----------------------------------------------------------------

        /// <summary>
        /// 
        /// </summary>
        public IConfiguration Configuration;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="services"></param>
        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            //- CORS-------------------------------------------------------------------
            services.AddCors(options =>
            {
                options.AddPolicy(MyAllowSpecificationOrigins,
                builder =>
                {
                    builder.AllowAnyOrigin().
                    AllowAnyHeader().
                    AllowAnyMethod();
                });
            });
            //---------------------------------------------------------------------------

            // --------------------- Swagger ------------------------
            services.AddSwaggerGen(options =>
            {
                options.SwaggerDoc("v1", new OpenApiInfo
                {
                    Version = "v1",
                    Title = "Advice API",
                    Description = "API for Question and Answers forum",
                    TermsOfService = new Uri("localhost:4200/api/issue"),
                    Contact = new OpenApiContact
                    {
                        Name = "Jeremy",
                    },
                    License = new OpenApiLicense
                    {
                        Name = "License",
                    }
                });
                var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
                options.IncludeXmlComments(xmlPath);
            });
            // -----------------------------------------------------

            string connectionString = Configuration.GetConnectionString("AdviceDbConnection");

            services.AddDbContext<AdviceDbContext>(options => options.UseSqlServer(connectionString));

            // needed in order to use EF Core using a connection string.  Creates a Database Context to allow for code first migrations.
            ///services.AddDbContext<AdviceDbContext>( //AdviceDbContext
               /// options => options.UseSqlServer(Configuration.GetConnectionString("AdviceDbConnection"), b => b.MigrationsAssembly("Advice")));

            services.AddTransient<IRepositoryAccounts<Accounts1>, RepositoryAccounts>();
            services.AddTransient<IRepositoryConversations<Conversations1>, RepositoryConversations>();
            services.AddTransient<IRepositoryDepartments<Departments1>, RepositoryDepartments>();
            services.AddTransient<IRepositoryMessages<Messages1>, RepositoryMessages>();
            services.AddControllers();
        }



        /// <summary>
        /// 
        /// </summary>
        /// <param name="app"></param>
        /// <param name="env"></param>
        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            // --------------------- Swagger ------------------------
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
                c.RoutePrefix = string.Empty;
            });
            // ------------------------------------------------------


            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            // CORS ---------------------------------
            app.UseCors(MyAllowSpecificationOrigins);
            //---------------------------------------

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
                //endpoints.MapControllerRoute(
                //    name: "default",
                //    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
