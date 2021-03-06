using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
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
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using WebApi.Business.Repositories;
using WebApi.Configurations;
using WebApi.Infraestruture.Data;
using WebApi.Infraestruture.Data.Repositories;

namespace WebApi
{
   /// <summary>
   /// Class Startup
   /// </summary>
   /// <param ></param>
   /// <returns></returns>

   public class Startup
   {

      /// <summary>
      ///  Startup
      /// </summary>
      /// <param ></param>
      /// <returns></returns>

      public Startup(IConfiguration configuration)
      {
         Configuration = configuration;
      }

      /// <summary>
      ///  Configuration
      /// </summary>
      /// <param ></param>
      /// <returns></returns>

      public IConfiguration Configuration { get; }


      /// <summary>
      ///  This method gets called by the runtime. Use this method to add services to the container.
      /// </summary>
      /// <param ></param>
      /// <returns></returns>
      public void ConfigureServices(IServiceCollection services)
      {

         services.AddControllers()
             .ConfigureApiBehaviorOptions(options =>
             {
                options.SuppressModelStateInvalidFilter = true;
             });

         services.AddSwaggerGen(c =>
         {
            c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
            {
               Description = "JWT Autorization header using the Bearer scheme(Example: Bearer 12345sdfdf)",
               Name = "Authorization",
               In = ParameterLocation.Header,
               Type = SecuritySchemeType.ApiKey,
               Scheme = "Bearer"
            });
            c.AddSecurityRequirement(new OpenApiSecurityRequirement{
                    {
                        new OpenApiSecurityScheme{
                            Reference = new OpenApiReference{
                                Type = ReferenceType.SecurityScheme,
                                Id = "Bearer"
                            }
                        },
                        Array.Empty<String>()
                    }
             });

            var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
            var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);

            //c.SwaggerDoc("v1", new OpenApiInfo { Title = "WebApi", Version = "v1" });
            c.IncludeXmlComments(xmlPath);
         });


         // var optionsBuilder = new DbContextOptionsBuilder<CursoDbContext>();
         // optionsBuilder.UseSqlServer("Server=localhost; database=CURSO;User Id=sa;Password=Tt53poisa@ ");
         // CursoDbContext context = new CursoDbContext(optionsBuilder.Options);

         var secret = Encoding.ASCII.GetBytes(Configuration.GetSection("JwtConfigurations:Secret").Value);
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
               IssuerSigningKey = new SymmetricSecurityKey(secret),
               ValidateIssuer = false,
               ValidateAudience = false
            };

         });


         services.AddDbContext<CursoDbContext>(options =>
        {
           options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection"));
        });
         services.AddScoped<IUsuarioRepository, UsuarioRepository>();
         services.AddScoped<ICursoRepository, CursoRepository>();
         services.AddScoped<IAuthenticationService, JwtService>();



      }

      /// <summary>
      /// This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
      /// </summary>
      /// <param ></param>
      /// <returns></returns>

      public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
      {
         if (env.IsDevelopment())
         {
            app.UseDeveloperExceptionPage();
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
               c.SwaggerEndpoint("/swagger/v1/swagger.json", "WebApi v1");
               c.RoutePrefix = string.Empty;

            });

         }

         app.UseHttpsRedirection();

         app.UseRouting();

         app.UseAuthentication();
         app.UseAuthorization();

         app.UseEndpoints(endpoints =>
         {
            endpoints.MapControllers();
         });
      }
   }
}
