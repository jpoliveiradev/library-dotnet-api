using AutoMapper;
using FluentValidation.AspNetCore;
using Library.API.Data;
using Library.API.Services;
using Library.API.Services.Interfaces;
using Library.API.Validators.AdminValidations;
using Library.API.Validators.AluguelValidations;
using Library.API.Validators.ClienteValidations;
using Library.API.Validators.EditoraCreateValidator;
using Library.API.Validators.EditoraValidations;
using Library.API.Validators.LivroValidations;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ApiExplorer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.IO;
using System.Reflection;

namespace Library.API {
    public class Startup {
        public Startup(IConfiguration configuration) {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }
        public void ConfigureServices(IServiceCollection services) {

            services.AddDbContext<DataContext>(
                context => context.UseMySql(Configuration.GetConnectionString("MysqlConnection"))


            );


            services.AddControllers()
                .AddFluentValidation(config => config.RegisterValidatorsFromAssemblyContaining<ClienteValidator>())
                .AddFluentValidation(config => config.RegisterValidatorsFromAssemblyContaining<ClienteCreateValidator>())
                .AddFluentValidation(config => config.RegisterValidatorsFromAssemblyContaining<EditoraValidator>())
                .AddFluentValidation(config => config.RegisterValidatorsFromAssemblyContaining<EditoraCreateValidator>())
                .AddFluentValidation(config => config.RegisterValidatorsFromAssemblyContaining<LivroValidator>())
                .AddFluentValidation(config => config.RegisterValidatorsFromAssemblyContaining<LivroCreateValidator>())
                .AddFluentValidation(config => config.RegisterValidatorsFromAssemblyContaining<AluguelValidator>())
                .AddFluentValidation(config => config.RegisterValidatorsFromAssemblyContaining<AluguelUpdateValidator>())
                .AddFluentValidation(config => config.RegisterValidatorsFromAssemblyContaining<AdminValidator>())
                .AddFluentValidation(config => config.RegisterValidatorsFromAssemblyContaining<AdminCreateValidator>())
                .AddNewtonsoftJson(
                    opt => opt.SerializerSettings.ReferenceLoopHandling =
                            Newtonsoft.Json.ReferenceLoopHandling.Ignore);

            
            services.AddCors(options => {
                options.AddPolicy("AllowSpecificOrigin",
                    builder => builder.WithOrigins("http://localhost:8080/",
                "http://192.168.15.8:8080/"));
            });


            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

            services.AddScoped<IRepository, Repository>();
            services.AddScoped<IClienteService, ClienteService>();
            services.AddScoped<IEditoraService, EditoraService>();
            services.AddScoped<ILivroService, LivroService>();
            services.AddScoped<IAluguelService, AluguelService>();
            services.AddScoped<IAdminService, AdminService>();

            services.AddVersionedApiExplorer(options => {
                options.GroupNameFormat = "'v'VVV";
                options.SubstituteApiVersionInUrl = true;

            })
                .AddApiVersioning(options => {
                    options.AssumeDefaultVersionWhenUnspecified = true;
                    options.DefaultApiVersion = new ApiVersion(1, 0);
                    options.ReportApiVersions = true;
                });

            var apiProviderDescription = services.BuildServiceProvider()
                                                 .GetService<IApiVersionDescriptionProvider>();

            services.AddSwaggerGen(options => {
                foreach (var description in apiProviderDescription.ApiVersionDescriptions) {
                    options.SwaggerDoc(
                        description.GroupName,
                         new Microsoft.OpenApi.Models.OpenApiInfo() {
                             Title = "Library API",
                             Version = description.ApiVersion.ToString()
                         });
                }

                var xmlCommentsFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                var xmlCommentsFullPath = Path.Combine(AppContext.BaseDirectory, xmlCommentsFile);

                options.IncludeXmlComments(xmlCommentsFullPath);
            });

        }

     
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env,
                                IApiVersionDescriptionProvider apiProviderDescription) {
            if (env.IsDevelopment()) {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseCors(
                x => x.AllowAnyOrigin()
                      .AllowAnyMethod()
                      .AllowAnyHeader()

            );
            app.UseSwagger()
                .UseSwaggerUI(options => {
                    foreach (var description in apiProviderDescription.ApiVersionDescriptions) {

                        options.SwaggerEndpoint(
                            $"/swagger/{description.GroupName}/swagger.json",
                            description.GroupName.ToUpperInvariant());
                        options.RoutePrefix = "";
                    }


                });


            app.UseEndpoints(endpoints => {
                endpoints.MapControllers();
            });
        }
    }
}
