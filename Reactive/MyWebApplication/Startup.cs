using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyWebApplication
{
    // public class Startup
    // {
    //     public void Configuration(Microsoft.AspNetCore.Builder.IApplicationBuilder app)
    //     {
    //         // Any connection or hub wire up and configuration should go here
    //         app.MapSignalR();
    //     }
    // }


    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            // Add SignalR to the services
            services.AddSignalR();
            // Other services can be added here
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            // Other middleware configurations for development/production environment

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                // Production-specific settings
                // app.UseExceptionHandler("/Home/Error");
                // ...
            }

            // Configure routing and endpoints
            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                // Map SignalR hub(s) to specific endpoint(s)
                endpoints.MapHub<ChatHub>("/chathub"); // Replace ChatHub with your actual hub class
                // Other endpoints can be configured here
            });
        }
    }
}