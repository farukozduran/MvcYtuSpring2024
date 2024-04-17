using System.ComponentModel.DataAnnotations;

namespace W3.Models
{
	public class Student
	{
		
		public int Id { get; set; }

		[Required(ErrorMessage = "Name is required!")]
		[MaxLength(30)]
		public string? Name { get; set; }

		[Required(ErrorMessage = "Email is required!")]
		[EmailAddress(ErrorMessage ="Invalid email address!")]
		public string? Email { get; set; }

		[Required(ErrorMessage = "Age is required!")]
		[Range(18,38,ErrorMessage ="Age must be between 18 and 38.")]
		public int Age { get; set; }
	}
}
