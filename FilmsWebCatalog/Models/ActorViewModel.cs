using System.ComponentModel.DataAnnotations;

namespace FilmsWebCatalog.Models
{
	public class ActorViewModel
	{
		public string FirstName { get; set; }
		public string LastName { get; set; }
		public int Years { get; set; }
		public string DateOfBirth { get; set; }
	}
}
