using IISDarioDrazenovicXSD.Model;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IISDarioDrazenovicXSD
{
    public class Startup
    {
        //PROMIJENI DECIMAL U DOUBLE

        //internal static EsportsTeamArray EsportsTeamArray;
        private List<EsportsTeamArray> listOfTeams;

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;

            listOfTeams = new List<EsportsTeamArray>
            {
                new EsportsTeamArray
                {
                    Id="1",
                    Type="League",
                    Name="G2",
                    Cost=24120
                },
                new EsportsTeamArray
                {
                    Id="2",
                    Type="League",
                    Name="Fnatic",
                    Cost=1245
                },
                new EsportsTeamArray
                {
                    Id="3",
                    Type="CS:GO",
                    Name="Vitality",
                    Cost=5412
                }
            };
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers().AddXmlDataContractSerializerFormatters();

            services.AddSingleton<List<EsportsTeamArray>>(listOfTeams);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
