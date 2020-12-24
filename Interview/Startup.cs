using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autofac;
using Autofac.Extensions.DependencyInjection;
using AutoMapper;
using Interview.Core.Authentication;
using Interview.Core.Context;
using Interview.Core.Intefaces;
using Interview.Core.Intefaces.AutoMaper_interface;
using Interview.Core.Intefaces.Repo_Interfaces;
using Interview.Core.Repos;
using Interview.Core.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;

namespace Interview
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = (IConfigurationRoot)configuration;
        }
        public ILifetimeScope AutofacContainer { get; private set; }
        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
            services.AddAuthentication(x =>
            {
                x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(x =>
            {
                x.RequireHttpsMetadata = false;
                x.SaveToken = true;
                x.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(Configuration["Jwt:Key"])),
                    ValidateIssuer = false,
                    ValidateAudience = false

                };
            });

            services.AddSingleton<IJwtAuthenticationManager>(new JwtAuthenticationManager(Configuration["Jwt:Key"]));


        }
        public void ConfigureContainer(ContainerBuilder builder)
        {
            builder.RegisterType<Interview.Core.AutoMapper.Mapper>()
               .As<IAutoMapper>()
               .SingleInstance();
            builder.RegisterType<SongRepo>()
              .As<ISongRepo>()
              .SingleInstance();
            builder.RegisterType<UserRepo>()
             .As<IUserRepo>()
             .SingleInstance();
            builder.RegisterType<DatabaseContext>()
                .SingleInstance();
            builder.RegisterType<UserService>()
                .As<IUserService>()
                .UsingConstructor(typeof(IAutoMapper), typeof(IUserRepo))
                .SingleInstance();
            builder.RegisterType<SongService>()
               .As<ISongService>()
               .UsingConstructor(typeof(IAutoMapper), typeof(ISongRepo))
               .SingleInstance();


        }
        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            this.AutofacContainer = app.ApplicationServices.GetAutofacRoot();

            app.UseHttpsRedirection();

            app.UseRouting();
            app.UseAuthentication();

            app.UseCors(builder =>
               builder
                 .WithOrigins("http://localhost:3000")
                 .AllowAnyHeader()
                 .AllowAnyMethod()
                 .AllowCredentials()
             );
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
