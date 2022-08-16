using MediKlaudAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace MediKlaudAPI.Models
{
  public interface IMediKlaudAPIDBContext
  {
	DbSet<MemberMaster> MemberMasters { get; set; }
	DbSet<UserAuthen> UserAuthens { get; set; }
  }
}
