
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;

using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

using Microsoft.OpenApi.Models;

using MediKlaudAPI.Interface;
using MediKlaudAPI.Service;
using MediKlaudAPI.Infrastructure;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace MediKlaudAPI
{
  public class Startup
  {
	public Startup(IConfiguration configuration)
	{
	  Configuration = configuration;
	}
	readonly string MyAllowSpecificOrigins = "_myAllowSpecificOrigins";
	public IConfiguration Configuration { get; }

	// This method gets called by the runtime. Use this method to add services to the container.
	public void ConfigureServices(IServiceCollection services)
	{
	  //services.AddDbContext<MediKlaudAPIDBContext>(item => item.UseSqlServer
	  //					 (Configuration.GetConnectionString("MediklaudDBConn")));
	  services.AddTransient<IDashboardService, DashboardService>();
	  services.AddSingleton<IMediklaudDBConnection, MediklaudDBConnection>();
	  services.AddControllers();
	  services.AddSwaggerGen(c =>
	  {
		c.SwaggerDoc("v1", new OpenApiInfo { Title = "MediKlaudAPI", Version = "v1" });
	  });
	  services.AddCors(options =>
	  {
		options.AddPolicy(name: MyAllowSpecificOrigins,
						  policy =>
						  {
							policy.WithOrigins()
									.AllowAnyHeader()
									.AllowAnyMethod();

						  });
	  });
	  // services.AddCors(options =>
	  // {
	  //options.AddDefaultPolicy(
	  //	policy =>
	  //	{
	  //	  policy.WithOrigins("http://example.com",
	  //							  "http://www.contoso.com");
	  //	});
	  // });

	  // services.AddAuthentication(opt =>
	  // {
	  //opt.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
	  //opt.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
	  // })
	  //.AddJwtBearer(Options =>
	  //{
	  //  Options.TokenValidationParameters = new TokenValidationParameters
	  //  {
	  //	ValidateIssuer = true,
	  //	ValidateAudience = true,
	  //	ValidateLifetime = true,
	  //	ValidateIssuerSigningKey = true,

	  //	ValidIssuer = "http://localhost:7061",
	  //	ValidAudience = "http://localhost:7061",
	  //	IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("superSecretKey@345"))
	  //  };

	  //});


	}

	// This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
	public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
	{
	  if (env.IsDevelopment() || env.IsProduction())
	  {
		app.UseDeveloperExceptionPage();
		app.UseSwagger();
		app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "MediKlaudAPI v1"));
	  }

	  app.UseCors(MyAllowSpecificOrigins);
	  app.UseHttpsRedirection();

	  app.UseRouting();

	  app.UseAuthorization();

	  app.UseEndpoints(endpoints =>
	  {
		endpoints.MapControllers();
	  });
	}
  }
}
