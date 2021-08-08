using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using GraphQLSampleAuthenticationAPI.Data;
using GraphQLSampleAuthenticationAPI.GraphQL.Resolvers;
using GraphQLSampleAuthenticationAPI.Logics;
using GraphQLSampleAuthenticationAPI.Models;
using HotChocolate;
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
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;

namespace GraphQLSampleAuthenticationAPI
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
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "GraphQLSampleAuthenticationAPI", Version = "v1" });
            });

            services.AddGraphQLServer()
                         .AddQueryType<QueryResolver>()
                         .AddMutationType<MutationResolver>()
                         .AddFiltering()
                         .AddSorting()
                         .AddAuthorization();
            //.AddMutationType<MutationObjectType>()
            //.AddQueryType<QueryObjectType>();

            services.AddDbContextPool<AuthContext>(options => options.UseSqlServer(Configuration.GetConnectionString("AuthContext")));

            services.AddScoped<IAuthLogic, AuthLogic>();
            services.Configure<TokenSettings>(Configuration.GetSection("TokenSettings"));

            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                    .AddJwtBearer(options =>
                    {
                        var tokenSettings = Configuration.GetSection("TokenSettings").Get<TokenSettings>();
                        options.TokenValidationParameters = new TokenValidationParameters
                        {
                            ValidIssuer = tokenSettings.Issuer,
                            ValidateIssuer = true,
                            ValidAudience = tokenSettings.Audience,
                            ValidateAudience = true,
                            ValidateIssuerSigningKey = true,
                            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(tokenSettings.Key))
                        };
                    });

            services.AddAuthorization(options =>
            {
                options.AddPolicy("roles-policy", policy =>
                {
                    policy.RequireRole(new string[] { "super-admin", "admin" });
                });
                options.AddPolicy("claims-policy", policy =>
                {
                    policy.RequireClaim("LastName"); //Checks lastname exists or not in token
                });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "GraphQLSampleAuthenticationAPI v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapGraphQL();
                endpoints.MapControllers();
            });
        }
    }
}
