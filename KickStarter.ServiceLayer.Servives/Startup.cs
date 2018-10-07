using Microsoft.AspNetCore.Hosting;

namespace KickStarter.ServiceLayer.Services
{
    public class Startup
    {
        public Startup(IHostingEnvironment env)
        {
            //var builder = new ConfigurationBuilder()
            //    .SetBasePath(env.ContentRootPath)
            //    .AddJsonFile("appsettings.json", false, true)
            //    .AddJsonFile($"appsettings.{env.EnvironmentName}.json", true)
            //    .AddEnvironmentVariables();
            //Configuration = builder.Build();
        }

//        public IConfigurationRoot Configuration { get; }

//        // This method gets called by the runtime. Use this method to add services to the container.
//        public IServiceProvider ConfigureServices(IServiceCollection services)
//        {
//            // Add our Config object so it can be injected
//            services.Configure<Appsettings>(Configuration);

//            // Add framework services.
//            services.AddMvcCore(properties => { properties.ModelBinderProviders.Insert(0, new JsonModelBinderProvider()); })
//                .AddJsonOptions(options =>
//                {
//                    options.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();
//                    options.SerializerSettings.NullValueHandling = NullValueHandling.Ignore;
//                });

//            // Register the Swagger generator, defining one or more Swagger documents
//            services.AddSwaggerGen(option => { option.SwaggerDoc("v1", new Info { Title = "My API", Version = "v1" }); });

//            services.AddAutoMapper();

//#if DEBUG
//            Mapper.AssertConfigurationIsValid();
//#endif

//            services.ConfigureBusinessLayerServices(Configuration);

//            // Autofac
//            var builder = new ContainerBuilder();
//            builder.Populate(services);
//            builder.RegisterModule(new AutoFacModule());

//            var applicationContainer = builder.Build();
//            return new AutofacServiceProvider(applicationContainer);
//        }

//        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
//        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
//        {
//            // Enable middleware to serve generated Swagger as a JSON endpoint.
//            app.UseSwagger();

//            // Enable middleware to serve swagger-ui (HTML, JS, CSS etc.), specifying the Swagger JSON endpoint.
//            app.UseSwaggerUI(c => { c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1"); });

//            if (env.IsDevelopment())
//            {
//                app.UseDeveloperExceptionPage();
//                app.UseBrowserLink();
//            }

//            app.UseStaticFiles();

//            var backendRoutes = new[]
//            {
//                "/api/"
//            };

//            // Route all angular routes back to the root
//            app.Use(async (context, next) =>
//            {
//                if (context.Request.Path.HasValue && !backendRoutes.Any(br =>
//                        context.Request.Path.Value.StartsWith(br, StringComparison.OrdinalIgnoreCase)))
//                    context.Request.Path = new PathString("/");

//                await next();
//            });

//            app.UseMvc();

//            app.UseDefaultFiles();
//            app.UseStaticFiles();

//            app.UseStatusCodePagesWithReExecute("/httpstatus/{0}");
//        }
    }
}