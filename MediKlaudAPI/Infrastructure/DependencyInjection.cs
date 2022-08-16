
using MediKlaudAPI.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;


namespace KWS.Infrastructure
{
  public static class DependencyInjection
  {
	public static void AddKWSDBConn(this IServiceCollection services, AppSettings appSettings)
	{
	  if (appSettings.DbServer == DbServer.Oracle.ToString())
	  {
		//services.AddDbContext<MediKlaudAPIDBContext>(options =>
		//options.UseSqlServer(
		//	appSettings.ConnectionString,
		//	b => b.MigrationsAssembly(typeof(MediKlaudAPIDBContext).Assembly.FullName))
		//);
	  }
	  else if (appSettings.DbServer == DbServer.MSSQL.ToString())
	  {
		// services.AddDbContext<MediKlaudAPIDBContext>(options =>
		//options.UseMySql(appSettings.ConnectionString, MySqlServerVersion.LatestSupportedServerVersion,
		//b => b.MigrationsAssembly(typeof(SBMDbContext).Assembly.FullName))
		//);
	  }
	  services.AddScoped<IMediKlaudAPIDBContext>(provider => provider.GetService<MediKlaudAPIDBContext>());
	}
  }
}
