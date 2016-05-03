using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Builder;
using Microsoft.AspNet.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json.Serialization;
using Microsoft.AspNet.SpaServices.Webpack;

namespace Openhouse
{
    public class Startup
    {

        // This method gets called before the Configure method by the runtime to load configuration  
        // from environment variables and add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            //loading the configuration only from environment variables see: http://12factor.net/config
            //regradless of what environment the app is running in, the application settings are controlled by individual configuration settings
            //using env.IsDevelopment() is bad practice mkay! see: http://eng.joingrouper.com/blog/2014/09/02/configuring-rails-environments/
            IConfiguration configuration = new ConfigurationBuilder().AddEnvironmentVariables().Build();

            services.AddSingleton(config => configuration);

            services.AddSingleton<Settings>();

            services.AddLogging();

            services.AddMvcCore()
                    .AddRazorViewEngine()
                    .AddJsonFormatters(settings => {
                        settings.ContractResolver = new CamelCasePropertyNamesContractResolver();
                    }).AddApiExplorer();

            services.AddSwaggerGen();
        }

        // This method gets called after ConfigureServices by the runtime to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app
                               , ILoggerFactory loggerFactory
                               , Settings settings)
        {
        
            app.UseIISPlatformHandler();

            if (settings.DebugMode)
            {
                loggerFactory.AddDebug(LogLevel.Debug);
                loggerFactory.AddConsole(LogLevel.Warning);

                app.UseBrowserLink();
                app.UseDeveloperExceptionPage();
                app.UseRuntimeInfoPage("/runtime");
                app.UseStatusCodePages();

                //TODO: use this in conjunction with the Microsoft.AspNet.ReactServices package
                //to enable universal\isomorphic ReactJS applications
                //app.UseWebpackDevMiddleware(new WebpackDevMiddlewareOptions
                //{
                //    HotModuleReplacement = true,
                //    ReactHotModuleReplacement = true
                //});
            }
            else
            {
                //TODO: Replace with custom toplevel global error handler middleware 
                //that logs error and returns a json error response for API call errors
                app.UseExceptionHandler("/Error/General");
            }

            if (settings.ServeDefaultFile)
                app.UseFileServer();
            else
                app.UseStaticFiles();

            app.UseMvc(Routes.ConfigureRoutes);

            app.UseSwaggerGen();
            app.UseSwaggerUi();
        }


        public static void Main(string[] args) => WebApplication.Run<Startup>(args);
    }
}
