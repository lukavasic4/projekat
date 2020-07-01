using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;
using Projekat.Api.Core;
using Projekat.Application;
using Projekat.Application.Commands;
using Projekat.Application.Email;
using Projekat.Application.Queries;
using Projekat.EfDataAccess;
using Projekat.EfDataAccess.Configuration;
using Projekat.Implementation.Commands;
using Projekat.Implementation.Email;
using Projekat.Implementation.Logging;
using Projekat.Implementation.Queries;
using Projekat.Implementation.Validation;

namespace Projekat.Api
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
            services.AddTransient<ProjekatContext>();
            services.AddTransient<CreateCategoryValidation>();
            services.AddTransient<ModifyCategoryValidation>();
            services.AddTransient<CreatePostValidation>();
            services.AddTransient<ModifyPostValidation>();
            services.AddTransient<CreateUserValidation>();
            services.AddTransient<ModifyUserValidation>();
            services.AddTransient<RegisterUserValidator>();
            services.AddTransient<UseCaseExecutor>();
            services.AddTransient<JwtManager>();
            services.AddTransient<IUseCaseLogger, DatabaseUseCaseLogger>();
            services.AddTransient<CategoryConfiguration>();
            services.AddTransient<PostConfiguration>();
            services.AddTransient<ICreateCategoryCommand, EfCreateCategoryCommand>();
            services.AddTransient<IDeleteCategoryCommand, EfDeleteCategoryCommand>();
            services.AddTransient<IModifyCategoryCommand, EfModifyCategoryCommand>();
            services.AddTransient<IGetCategoryQuery, EfGetCategoryQuery>();
            services.AddTransient<ICreatePostCommand, EfCreatePostCommand>();
            services.AddTransient<IDeletePostCommand, EfDeletePostCommand>();
            services.AddTransient<IModifyPostCommand, EfModifyPostCommand>();
            services.AddTransient<IGetPostsQuery, EfGetPostsQuery>();
            services.AddTransient<IGetPostQuery, EfGetPostQuery>();
            services.AddTransient<ICreateUserCommand, EfCreateUserCommand>();
            services.AddTransient<IDeleteUserCommand, EfDeleteUserCommand>();
            services.AddTransient<IModifyUserCommand, EfModifyUserCommand>();
            services.AddTransient<IGetUserQuery, EfGetUserQuery>();
            services.AddTransient<ICreatePictureCommand, EfCreatePictureCommand>();
            services.AddTransient<IRegisterUserCommand, EfRegisterUserCommand>();

            services.AddTransient<IEmailSender, SmtpEmailSender>();

            services.AddHttpContextAccessor();
            services.AddTransient<IApplicationActor>(x =>
            {
                var accessor = x.GetService<IHttpContextAccessor>();
                var user = accessor.HttpContext.User;
                if(user.FindFirst("ActorData") == null)
                {
                    return new AnonymousActor();
                }
                var actorString = user.FindFirst("ActorData").Value;
                var actor = JsonConvert.DeserializeObject<JwtActor>(actorString);
                return actor;
            });

            services.AddAuthentication(options =>
            {
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultSignInScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(cfg =>
            {
                cfg.RequireHttpsMetadata = false;
                cfg.SaveToken = true;
                cfg.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidIssuer = "asp_api",
                    ValidateIssuer = true,
                    ValidAudience = "Any",
                    ValidateAudience = true,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("ThisIsMyVerySecretKey")),
                    ValidateIssuerSigningKey = true,
                    ValidateLifetime = true,
                    ClockSkew = TimeSpan.Zero
                };
            });
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
            app.UseMiddleware<GlobalExceptionHandler>();
            app.UseAuthentication();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
