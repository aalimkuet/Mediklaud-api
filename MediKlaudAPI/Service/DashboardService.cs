using MediKlaudAPI.FormQuery;
using MediKlaudAPI.Infrastructure;
using MediKlaudAPI.Interface;
using MediKlaudAPI.Models;
using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;

namespace MediKlaudAPI.Service
{
  public class DashboardService : IDashboardService
  {
	private readonly IMediklaudDBConnection _dbConnection;
	public DashboardService(IMediklaudDBConnection dbConn)
	{
	  _dbConnection = dbConn;
	}
	public async Task<IEnumerable<Dashboard>> getDashboard(GetDashboardDataQuery dataQuery)
	{

	  try
	  {
		OracleConnection oracleConnection = new OracleConnection(await _dbConnection.getDBConn());

		OracleCommand cmd = new OracleCommand();
		cmd.Connection = oracleConnection;
		cmd.CommandType = CommandType.StoredProcedure;
		cmd.BindByName = true;
		cmd.CommandText = "sp_mis_dashboard_data_app";
		cmd.Parameters.Add("p_gid", OracleDbType.Int32, 30);
		cmd.Parameters.Add("p_cid", OracleDbType.Int32, 30);
		cmd.Parameters.Add("p_start_date", OracleDbType.Date, 30);
		cmd.Parameters.Add("p_end_date", OracleDbType.Date, 30);
		cmd.Parameters.Add("p_data", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
		cmd.Parameters["p_gid"].Value = 1;
		cmd.Parameters["p_cid"].Value = dataQuery.CompanyId;
		cmd.Parameters["p_start_date"].Value = dataQuery.StartDate.Date;
		cmd.Parameters["p_end_date"].Value = dataQuery.EndDate.Date;

		OracleDataAdapter da = new OracleDataAdapter(cmd);
		DataSet ds = new DataSet();
		da.Fill(ds);
		DataTable dt;
		dt = ds.Tables[0];
		int statusCount = 1;

		List<Dashboard> dashboards = new List<Dashboard>();
		List<Child> child = new List<Child>();
		var Head = true;
		string titleD = "", title = "";
		string valD = "", val = "";

		for (int i = 0; i < dt.Rows.Count; i++)
		{

		  if (int.Parse(dt.Rows[i]["TAB"].ToString()) == statusCount)
		  {
			if (Head == true)
			{
			  titleD = dt.Rows[i]["HEAD"].ToString();
			  valD = dt.Rows[i]["VAL"].ToString();
			}
			else
			{
			  title = dt.Rows[i]["HEAD"].ToString();
			  val = dt.Rows[i]["VAL"].ToString();
			  child.Add(new Child(title, val));
			}
			Head = false;

		  }
		  else
		  {
			dashboards.Add(new Dashboard(titleD, valD, child));
			child = new List<Child>();
			statusCount++;
			Head = true;
			i--;
		  }
		}
		dashboards.Add(new Dashboard(titleD, valD, child));

		return dashboards;
	  }
	  catch (Exception ex)
	  {
		throw ex;
	  }
	}
  }
}
