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

        // GET api/Api/ + id
        public QandA Get(int id)
        {
            return db.getSingleQuestion(id);
        }

        // POST api/Api
        public List<QandA> Post(QandA newQuestion)
        {
            if (ModelState.IsValid)
            {
                var id = newQuestion.Id;
                db.savequestion(newQuestion);
                return db.getAllQuestions();
            }
            return null;
            
        }

        // DELETE api/Api/ + id
        public List<QandA> Delete(int id)
        {
            db.deleteQuestion(id);
            return db.getAllQuestions();
        }

        // PUT api/Api
        public List<QandA> Put (QandA newVote)
        {
            db.VoteAnswer(newVote);
            return db.getAllQuestions();
        }
    }
}