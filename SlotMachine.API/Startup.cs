using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Microsoft.OpenApi.Models;
using SlotMachine.API.BLs;
using SlotMachine.API.BLs.Interfaces;
using SlotMachine.API.Clients;
using SlotMachine.API.Data;
using SlotMachine.API.Data.Interfaces;
using SlotMachine.API.Middlewares;
using SlotMachine.API.Repositories;
using SlotMachine.API.Repositories.Interfaces;
using SlotMachine.API.Settings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SlotMachine.API
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
            services.Configure<DatabaseSettings>(Configuration.GetSection(nameof(DatabaseSettings)));

            services.AddSingleton<IDatabaseSettings>(sp =>
                sp.GetRequiredService<IOptions<DatabaseSettings>>().Value);

            services.AddTransient<IGameContext, GameContext>();
            services.AddTransient<IPlayerRepository, PlayerRepository>();
            services.AddTransient<IGameConfigurationRepository, GameConfigurationRepository>();
            services.AddTransient<ISpinRepository, SpinRepository>();
            services.AddTransient<ISpinBL, SpinBL>();
            services.AddTransient<IBalanceBL, BalanceBL>();
            services.AddTransient<IGameConfigurationBL, GameConfigurationBL>();
            services.AddTransient<ILockerClient, LockerClient>();

            services.AddHttpClient("Locker", httpClient =>
            {
                httpClient.BaseAddress = new Uri("http://localhost:5001/api/v1/");
            });


            services.AddCors(options =>
            {
                options.AddPolicy("CorsPolicy", policy =>
                {
                    policy.AllowAnyMethod().AllowAnyHeader().WithOrigins("http://localhost:5000");
                });
            });

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Slot Machine API", Version = "v1" });
            });


        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Slot Machine API V1"));
            }

            app.UseRouting();
            app.UseCors("CorsPolicy");
            app.UseMiddleware<ExceptionMiddleware>();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
