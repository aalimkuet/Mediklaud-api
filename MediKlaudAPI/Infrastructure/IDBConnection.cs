using System.Threading.Tasks;

namespace MediKlaudAPI.Infrastructure
{
  public interface IMediklaudDBConnection
  {
	Task<string> getDBConn();
  }
}
