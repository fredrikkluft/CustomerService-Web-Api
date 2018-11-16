using CustomerService_Web_Api.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;


namespace CustomerService_Web_Api.Models
{
    public class DB
    {
        DBContext db = new DBContext();

        //Metode som henter all dataen fra databasen 
        public List<QandA> getAllQuestions()
        {
            List<QandA> questionAndAnswer = (from p in db.QandAs
                                     select
                                         new QandA()
                                         {
                                             Id = p.Id,
                                             Question = p.Question,
                                             Answer = p.Answer,
                                             Category = p.Category,
                                             Votecounter = p.Votecounter
                                             
                                         }).ToList();
            return questionAndAnswer;
        }

        //Metode som lagrer spørsmål fra kunden gjort fra QuestionPage.html og lagrer det i databasen.
        public void savequestion(QandA innQuestion)
        {
            var id = innQuestion.Id;

            try
            {
                bool foundQuestion = db.QandAs.Any(p => p.Id == id);
                if (foundQuestion)
                {
                    QA updatequestion = db.QandAs.Find(id);

                    updatequestion.Question = innQuestion.Question;
                    updatequestion.Answer = innQuestion.Answer;
                    updatequestion.Category = innQuestion.Category;
                    updatequestion.Votecounter = innQuestion.Votecounter + 1;

                    db.SaveChanges();
                }
                else
                {
                    QA newQuestion = new QA();
                    // spørsmål til  databasen
                    newQuestion.Question = innQuestion.Question;
                    newQuestion.Answer = "Spørsmål venter på svar fra administrator.";
                    newQuestion.Category = innQuestion.Category;

                    db.QandAs.Add(newQuestion);
                    db.SaveChanges();
                } 
            }
            catch (Exception ex)
            {
                //Exception handling
            }
        }

        //Metode som gjør at avstemming på spørsmål/svar blir lagret i databasen basert på om kunden var fornøyd med svaret eller ikke.
        public void VoteAnswer(QandA innVote)
        {
            var id = innVote.Id;

            try
            {
                bool foundQuestion = db.QandAs.Any(p => p.Id == id);
                if (foundQuestion && innVote.Votetype == 1)
                {
                    QA updatequestion = db.QandAs.Find(id);

                    updatequestion.Votecounter = updatequestion.Votecounter + 1;

                    db.SaveChanges();
                }
                else  
                {
                    QA updatequestion = db.QandAs.Find(id);

                    updatequestion.Question = updatequestion.Question;
                    updatequestion.Answer = updatequestion.Answer;
                    updatequestion.Category = updatequestion.Category;
                    updatequestion.Votecounter = updatequestion.Votecounter - 1;

                    db.SaveChanges();
                }
            }
            catch(Exception ex)
            {
                //Feilhåndtering her
            }

        }

        //Henter et spørsmål og svar fra databasen for å vises i Administration.html og laster inn dataene i textarea feltene som gir tilgang til å redigere. 
        public QandA getSingleQuestion(int id)
        {
            bool foundQuestion = db.QandAs.Any(p => p.Id == id);
            if (foundQuestion)
            {
                QandA question = (from p in db.QandAs
                                  where p.Id == id
                                  select
                                      new QandA()
                                      {
                                          Id = p.Id,
                                          Question = p.Question,
                                          Answer = p.Answer,
                                          Category = p.Category,
                                          
                                           }).First();
                return question;
            }
            var emptyquestion = new QandA();
            emptyquestion.Id = 0;
            emptyquestion.Question = "Ingen spørsmål funnet med denne Id";
            emptyquestion.Answer = "Ingen spørsmål funnet med denne Id";
            return emptyquestion;
        }


        
        //Sletter spørsål og svar fra databasen basert på valgt id
        public void deleteQuestion(int id)
        {
            try
            {
                QA questionToDelete = db.QandAs.FirstOrDefault(p => p.Id == id);

                db.QandAs.Remove(questionToDelete);
                db.SaveChanges();
            }
            catch (Exception ex)
            {

            }
        }
    }
}