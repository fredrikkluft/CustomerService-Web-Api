using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using CustomerService_Web_Api.Models;

namespace CustomerService_Web_Api.Controllers
{
    public class PersonController : ApiController
    {
        DB db = new DB();

        // GET api/Person
        public List<QandA> Get()
        {
            return db.getAllQuestions();
        }

        //// GET api/Person
        //public List<Person> Get()
        //{
        //    return db.hentAllePersoner();
        //}

        // GET api/Person/5
        public Person Get(int id)
        {
            return db.hentEnPerson(id);
        }

        // POST api/Person
        public List<Person> Post(Person personInn)
        {
            db.lagrePerson(personInn);
            return db.hentAllePersoner();
        }

        // PUT api/Person/5
        public List<Person> Put(int id, Person personInn)
        {
            // dette api er ikke impelmentert på klient!
            db.endrePerson(id, personInn);
            return db.hentAllePersoner();
        }

        // DELETE api/Person/5
        public List<Person> Delete(int id)
        {
            db.slettPerson(id);
            return db.hentAllePersoner();
        }
    }
}