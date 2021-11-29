using Api.BussinesLogical.Interfaces;
using Api.BussinesLogical;

using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using System;
using System.IO;
using System.Reflection;
using Api.LogicalBussines.Interfaces;
using Api.LogicalBussines;
using API.Services;
using Microsoft.AspNetCore.Authentication;
using API.Auth;

namespace API
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
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    
                });

                // Set the comments path for the Swagger JSON and UI.
                var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
                c.IncludeXmlComments(xmlPath);



                c.AddSecurityDefinition("basic", new OpenApiSecurityScheme
                {
                    Name = "Authorization",
                    Type = SecuritySchemeType.Http,
                    Scheme = "basic",
                    In = ParameterLocation.Header,
                    Description = "Basic Authorization header using the Bearer scheme."
                });
                c.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                    {
                          new OpenApiSecurityScheme
                            {
                                Reference = new OpenApiReference
                                {
                                    Type = ReferenceType.SecurityScheme,
                                    Id = "basic"
                                }
                            },
                            new string[] {}
                    }
                });


            });
            services.AddApiVersioning(config =>
            {
                config.DefaultApiVersion =  new ApiVersion(1, 0);
                config.AssumeDefaultVersionWhenUnspecified= true;
                config.AssumeDefaultVersionWhenUnspecified= true;
                config.ReportApiVersions =true;

            });

            services.AddAuthentication("BasicAuthentication")
              .AddScheme<AuthenticationSchemeOptions, BasicAuthenticationHandler>("BasicAuthentication", null);

            services.AddSingleton<IBookValidationRules, BookValidationRules>();


            services.AddSingleton<ISummaryBook, SummaryBook>();
            services.AddSingleton<IProduct, Product>();
            services.AddSingleton<IBook, Book>();
            services.AddSingleton<ILoginService, LoginService>();
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

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseSwagger();

            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Azure DashBoard API");

            });

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
