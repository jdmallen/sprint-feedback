using System;
using System.Text;
using JDMallen.Toolbox.Factories;
using JDMallen.Toolbox.Options;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Server.IISIntegration;
using Microsoft.Data.Sqlite;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using SprintFeedback.DataAccess;
using SprintFeedback.DataAccess.Config;

namespace SprintFeedback.Web
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
			var settings = Configuration.GetSection("Settings").Get<Settings>();
			services.AddSingleton(settings);

			var signingKey =
				new SymmetricSecurityKey(Encoding.UTF8.GetBytes(settings.JwtSecretKey));

			services.Configure<JwtOptions>(
				options =>
				{
					options.Audience = settings.JwtAudience;
					options.Issuer = settings.JwtIssuer;
					options.ValidForSpan = TimeSpan.FromMinutes(settings.JwtExpireMinutes);
					options.SigningCredentials = new SigningCredentials(
						signingKey,
						SecurityAlgorithms.HmacSha256);
				});

			var connStr = new SqliteConnectionStringBuilder
			{
				DataSource = settings.DbFilePath
			}.ConnectionString;

			services.AddDataAccessServices(connStr);

			services.AddScoped<IJwtTokenFactory, JwtTokenFactory>();

			services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
			
			services.AddAntiforgery(
				options =>
				{
					options.Cookie.Name = "_af";
					options.Cookie.HttpOnly = true;
					options.Cookie.SecurePolicy = CookieSecurePolicy.Always;
					options.HeaderName = "X-XSRF-TOKEN";
				}
			);
			services.Configure<IISOptions>(options =>
			{
				options.AutomaticAuthentication = true;
			});

			services.AddAuthentication(IISDefaults.AuthenticationScheme);

			services.AddAuthentication(
					options =>
					{
						options.DefaultAuthenticateScheme =
							JwtBearerDefaults.AuthenticationScheme;
						options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
						options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
					})
				.AddJwtBearer(
					config =>
					{
						config.RequireHttpsMetadata = true;
						config.SaveToken = true;
						config.TokenValidationParameters = new TokenValidationParameters
						{
							ValidIssuer = settings.JwtIssuer,
							ValidAudience = settings.JwtIssuer,
							ValidateIssuerSigningKey = true,
							IssuerSigningKey = signingKey,
							RequireExpirationTime = true,
							ClockSkew = TimeSpan.Zero
						};
					});

			services.AddMvc(
				options =>
				{
					options.Filters.Add(new RequireHttpsAttribute());
				});
		}

		// This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
		public void Configure(
			IApplicationBuilder app,
			IHostingEnvironment env,
			ILoggerFactory loggerFactory,
			SfContext dbContext)
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

			app.UseAuthentication();

			app.UseStaticFiles("");

			app.UseStatusCodePagesWithRedirects("/");
			
			app.UseMvc(
				routes =>
				{
					routes.MapRoute(
						name: "default",
						template: "{controller=BaseView}/{action=Index}/{id?}");
					routes.MapSpaFallbackRoute(
						name: "spa-fallback",
						defaults: new
						{
							controller = "BaseView",
							action = "Index"
						});
				});
		}
	}
}
