using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.Http;
using CustomerService_Web_Api.Models;

namespace CustomerService_Web_Api.Controllers
{
    public class ApiController : System.Web.Http.ApiController
    {
        DB db = new DB();

        // GET api/Api
        public List<QandA> Get()
        {
            return db.getAllQuestions();
        }

        // GET api/Api/questionId
        public QandA Get(int id)
        {
            return db.getSingleQuestion(id);
        }

        // POST api/Api
        
        public List<QandA> Post(QandA newQuestion)
        {
            
                
            db.savequestion(newQuestion);
            return db.getAllQuestions();
        }

        //public List<QandA> Post(QandA newquestion)
        //{



        //    Debug.WriteLine(newquestion);
        //    db.savequestion(newquestion);
        //    return db.getAllQuestions();
        //}















        //// GET api/Api
        //public List<Person> Get()
        //{
        //    return db.hentAllePersoner();
        //}

        // GET api/Person/5
        //public Person Get(int id)
        //{
        //    return db.hentEnPerson(id);
        //}



        //// PUT api/Person/5
        //public List<Person> Put(int id, Person personInn)
        //{
        //    // dette api er ikke impelmentert på klient!
        //    db.endrePerson(id, personInn);
        //    return db.hentAllePersoner();
        //}

        //// DELETE api/Person/5
        //public List<Person> Delete(int id)
        //{
        //    db.slettPerson(id);
        //    return db.hentAllePersoner();
        //}
    }
}