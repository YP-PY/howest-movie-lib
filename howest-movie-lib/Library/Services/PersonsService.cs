using howest_movie_lib.Library.Models;
using System.Collections.Generic;
using System.Linq; // linq extension methods
using Microsoft.EntityFrameworkCore;

namespace howest_movie_lib.Library.Services
{
    public class PersonsService
    {
        db_moviesContext db = new db_moviesContext();
        DbSet<Persons> persons;
        public PersonsService()
        {
            this.persons = db.Persons;
        }

        public Persons GetPerson(long personId)
        {
            var results = (persons.Where(c => c.Id == personId));
            if (results.Count() == 0)
                return null;
            return results.First();
        }
        public IEnumerable<Persons> GetPersons(IEnumerable<long> personIds)
        {
            List<Persons> results = new List<Persons>();
            foreach (long id in personIds)
            {
                Persons human = GetPerson(id);
                if (human != null)
                    results.Add(human);
            }
            return results;
        }
        public IEnumerable<Persons> GetAll()
        {
            return persons;
        }
        public void Add(Persons newPersons)
        {
            db.Persons.Add(newPersons);
            db.SaveChanges();
        }

        public void Update(Persons updPersons)
        {
            db.Persons.Update(updPersons);
            db.SaveChanges();
        }

        public void Delete(Persons delPersons)
        {
            if (delPersons != null)
            {
                db.Persons.Remove(delPersons);
                db.SaveChanges();
            }
        }
        public void DeleteMultiple(List<Persons> persons)
        {
            db.Persons.RemoveRange(persons);
            db.SaveChanges();
        }
    }
}