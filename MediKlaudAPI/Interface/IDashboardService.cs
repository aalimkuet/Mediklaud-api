using MediKlaudAPI.FormQuery;
using MediKlaudAPI.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MediKlaudAPI.Interface
{
  public interface IDashboardService
  {
	Task<IEnumerable<Dashboard>> getDashboard(GetDashboardDataQuery getDashboardDataQuery);
  }
}
