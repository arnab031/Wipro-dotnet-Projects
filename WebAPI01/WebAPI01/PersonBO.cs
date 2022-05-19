using System;
namespace WebAPI01
{
	public class PersonBO
	{
		public List<PersonModel> People { get; set; }
		public PersonBO()
		{
			People = new List<PersonModel>()
			{
				new PersonModel{Id=1001,PName="Anil",Gender="Male",Age=22},
				new PersonModel{Id=1002,PName="Akash",Gender="Male",Age=21},
				new PersonModel{Id=1003,PName="Chandu",Gender="Female",Age=23},
				new PersonModel{Id=1004,PName="Davi",Gender="Female",Age=24},
			};
		}
		public List<PersonModel> GetPeople() => People;
		public PersonModel GetPersonById(int id) => People.Single(x => x.Id == id);
		public void AddPerson(PersonModel p) => People.Add(p);
		public void DeletePersonById(int id) => People.RemoveAt(People.FindIndex(x => x.Id == id));
		public void EditPersonById(int id, PersonModel p1) =>
			People[People.FindIndex(x => x.Id == id)] = p1;

	}
}

