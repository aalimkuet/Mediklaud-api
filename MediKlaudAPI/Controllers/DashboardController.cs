using MediKlaudAPI.FormQuery;
using MediKlaudAPI.Interface;
using MediKlaudAPI.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MediKlaudAPI.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class DashboardController : ControllerBase
  {

	private readonly IDashboardService dashboard;
	public DashboardController(IDashboardService dashboard)
	{
	  this.dashboard = dashboard;
	}

	[HttpGet]
	public async Task<IEnumerable<Dashboard>> GetDashboardData([FromQuery] GetDashboardDataQuery getDashboardDataQuery)
	{
	  return await dashboard.getDashboard(getDashboardDataQuery);
	}
  }
}
