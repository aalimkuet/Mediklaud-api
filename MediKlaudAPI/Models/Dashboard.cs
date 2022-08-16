using System.Collections.Generic;

namespace MediKlaudAPI.Models
{
  public class Dashboard
  {

	public Dashboard(string title, string value, List<Child> child)
	{
	  Title = title;
	  Value = value;
	  this.child = child;
	}

	public string Title { get; set; }
	public string Value { get; set; }

	public List<Child> child { get; set; }
  }


  public class Child
  {
	public Child(string title, string value)
	{
	  Value = value;
	  this.title = title;
	}
	public string title { get; set; }
	public string Value { get; set; }
  }
}
