using System;

namespace MediKlaudAPI.FormQuery
{
  public class GetDashboardDataQuery
  {
	public string CompanyId { get; set; }
	public DateTime StartDate { get; set; }
	public DateTime EndDate { get; set; }
  }
}
