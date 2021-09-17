using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using Neighlink.Entity;
using Neighlink.Repository;
using Neighlink.Repository.Context;
using Neighlink.Repository.implementation;
using Neighlink.Service;
using Neighlink.Service.implementation;
using Neighlink.Service.Implementation;

namespace Neighlink.Api
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
            services.AddCors();
            services.AddDbContext<ApplicationDbContext>(options =>
            options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));

            //services.AddSwaggerGen( config =>
            // config.SwaggerDoc( "v1", new Swashbuckle.AspNetCore.SwaggerGen.PropertyInfoExtensions.AspNetCore.Swagger.Info() {Title = "Ejemplo del swagger" } ) );

            var secretsSection = Configuration.GetSection("PrivateSettings");
            services.Configure<PrivateSettings>(secretsSection);
            //Configurar JWT
            var appSettings = secretsSection.Get<PrivateSettings>();
            var key = Encoding.ASCII.GetBytes(appSettings.AuthenticationSecret);
            services.AddAuthentication(x =>
            {
                x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddJwtBearer(x =>
            {
                x.RequireHttpsMetadata = false;
                x.SaveToken = true;
                x.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(key),
                    ValidateIssuer = false,
                    ValidateAudience = false
                };
            });

            services.AddTransient<IBillRepository,BillRepository>();
            services.AddTransient<IBillService,BillService>();
            
            services.AddTransient<IBuildingRepository,BuildingRepository>();
            services.AddTransient<IBuildingService,BuildingService>();

            services.AddTransient<ICondominiumRepository,CondominiumRepository>();
            services.AddTransient<ICondominiumService,CondominiumService>();

            services.AddTransient<INewRepository,NewRepository>();
            services.AddTransient<INewService,NewService>();

            services.AddTransient<IOptionRepository,OptionRepository>();
            services.AddTransient<IOptionService,OptionService>();

            services.AddTransient<IPaymentCategoryRepository,PaymentCategoryRepository>();
            services.AddTransient<IPaymentCategoryService,PaymentCategoryService>();

            services.AddTransient<IPlanRepository,PlanRepository>();
            services.AddTransient<IPlanService,PlanService>();

            services.AddTransient<IPollRepository,PollRepository>();
            services.AddTransient<IPollService,PollService>();

            services.AddTransient<IUserRepository, UserRepository>();
            services.AddTransient<IUserService, UserService>();

            services.AddTransient<IPaymentRepository, PaymentRepository>();
            services.AddTransient<IPaymentService, PaymentService>();

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            //Lo use para crear la base de datos. No se si es necesario
            using (var serviceScope = app.ApplicationServices.GetService<IServiceScopeFactory>().CreateScope())
            {
                var context = serviceScope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
                context.Database.EnsureCreated();
            }

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }else
            {
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseCors(x => x
                .AllowAnyOrigin()
                .AllowAnyMethod()
                .AllowAnyHeader());

            app.UseAuthentication();

            app.UseHttpsRedirection();
            app.UseMvc();
        }
    }
}
