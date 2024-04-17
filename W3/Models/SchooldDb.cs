using Bogus;

namespace W3.Models
{
	public static class SchooldDb
	{
		public static List<Student> Students = new List<Student>();

		public static void InitializeDb(int number)
		{
			if(Students.Count == 0)
			{
				for (int i = 1; i <= number; i++)
				{
					var student = new Faker<Student>()

						.RuleFor(s => s.Id, f => i)
						.RuleFor(s => s.Name, f => f.Name.FullName())
						.RuleFor(s => s.Email, (f, s) => f.Internet.Email())
						.RuleFor(s => s.Age, f => f.Random.Int(18, 38));

					Students.Add(student);
				}
			}
			
		}
	}
}
