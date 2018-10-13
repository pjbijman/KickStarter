using Autofac;
using Autofac.Extensions.DependencyInjection;
using AutoMapper;
using Kickstarter.BusinessLayer.DI;
using KickStarter.ServiceLayer.Helpers;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using Swashbuckle.AspNetCore.Swagger;
using System;
using System.Linq;

namespace KickStarter.ServiceLayer
{
    public class Startup
    {
        public Startup(IHostingEnvironment env)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("AppSettings.json", false, true)
                .AddJsonFile($"AppSettings.{env.EnvironmentName}.json", true)
                .AddEnvironmentVariables();
            Configuration = builder.Build();
        }

        public IConfigurationRoot Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public IServiceProvider ConfigureServices(IServiceCollection services)
        {
            // Add our Config object so it can be injected
            services.Configure<Appsettings>(Configuration);

            // services.AddDbContext<DataContext>(options => options.UseInMemoryDatabase());

            // Add framework services.
            services.AddMvcCore(properties => { properties.ModelBinderProviders.Insert(0, new JsonModelBinderProvider()); })
                .AddJsonOptions(options =>
                {
                    options.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();
                    options.SerializerSettings.NullValueHandling = NullValueHandling.Ignore;
                });

            // Register the Swagger generator, defining one or more Swagger documents
            services.AddSwaggerGen(option => { option.SwaggerDoc("v1", new Info { Title = "KickStarter API", Version = "v1" }); });

            services.AddAutoMapper();

            AutoMapperConfiguration.Configure();

            Mapper.AssertConfigurationIsValid();

            services.ConfigureBusinessLayerServices(Configuration);

            // Autofac
            var builder = new ContainerBuilder();
            builder.Populate(services);
            builder.RegisterModule(new AutoFacModule());

            var applicationContainer = builder.Build();
            return new AutofacServiceProvider(applicationContainer);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            // Enable middleware to serve generated Swagger as a JSON endpoint.
            app.UseSwagger();

            // Enable middleware to serve swagger-ui (HTML, JS, CSS etc.), specifying the Swagger JSON endpoint.
            var xmlPath = System.AppDomain.CurrentDomain.BaseDirectory + @"\KickStarter.Swagger.xml";

            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "KickStarter API V1");
                //c.IncludeXmlComments(xmlPath);
            });

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseBrowserLink();
            }

            app.UseStaticFiles();

            var backendRoutes = new[] { "/api/" };

            // Route all angular routes back to the root
            app.Use(async (context, next) =>
            {
                if (context.Request.Path.HasValue && !backendRoutes.Any(br =>
                        context.Request.Path.Value.StartsWith(br, StringComparison.OrdinalIgnoreCase)))
                    context.Request.Path = new PathString("/");

                await next();
            });

            app.UseMvc();

            app.UseDefaultFiles();
            app.UseStaticFiles();

            app.UseStatusCodePagesWithReExecute("/httpstatus/{0}");
        }
    }
}