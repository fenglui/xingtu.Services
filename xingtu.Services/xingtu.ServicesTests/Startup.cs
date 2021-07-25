using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;

namespace xingtu.ServicesTests
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            var xingtuSection = Configuration.GetSection("xingtu");
            if (null != xingtuSection)
            {
                var xingtuCfg = xingtuSection.Get<xingtu.Services.XingTuConfig>();
                if (null != xingtuCfg)
                {
                    services.AddSingleton(typeof(xingtu.Services.XingTuConfig), xingtuCfg);
                }
            }
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseHsts();
            }

            app.UseHttpsRedirection();

            app.UseRouting();
        }
    }
}
