﻿using Microsoft.Extensions.Configuration;

namespace KWS.Infrastructure
{
  public class DBConn
  {
	private readonly string _connectionString;
	public DBConn(IConfiguration _configuration)
	{
	  _connectionString = _configuration.GetConnectionString("MediklaudDBConn");
	}

	public string getDBConn()
	{
	  return _connectionString;
	}

  }

  public class DbSettings
  {
	public DbServer DbServer { get; set; }

	public string ConnectionString { get; set; }
  }
}
