using CustomerService_Web_Api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using static CustomerService_Web_Api.Models.PersonDB;

namespace CustomerService_Web_Api.Models
{
    public class DB
    {
        PersonContext db = new PersonContext();


        public List<QandA> getAllQuestions()
        {
            List<QandA> questionAndAnswer = (from p in db.QandAs
                                     select
                                         new QandA()
                                         {
                                             Id = p.Id,
                                             Question = p.Question,
                                             Answer = p.Answer
                                             
                                         }).ToList();
            return questionAndAnswer;
        }


        public List<Person> hentAllePersoner()
        {
            List<Person> personer = (from p in db.Personer
                                     select
                                         new Person()
                                         {
                                             Id = p.Id,
                                             Fornavn = p.Fornavn,
                                             Etternavn = p.Etternavn,
                                             Adresse = p.Adresse,
                                             Epost = p.Epost,
                                             Telefonnr = p.Telefonnr,
                                             Postnr = p.Postnr,
                                             Poststed = db.Poststeder.FirstOrDefault(q => q.Postnr == p.Postnr).Poststed
                                         }).ToList();
            return personer;
        }
        public Person hentEnPerson(int id)
        {
            bool funnetPerson = db.Personer.Any(p => p.Id == id);
            if (funnetPerson)
            {
                Person detaljPerson = (from p in db.Personer
                                       where p.Id == id
                                       select
                                           new Person()
                                           {
                                               Id = p.Id,
                                               Fornavn = p.Fornavn,
                                               Etternavn = p.Etternavn,
                                               Adresse = p.Adresse,
                                               Epost = p.Epost,
                                               Telefonnr = p.Telefonnr,
                                               Postnr = p.Postnr,
                                               Poststed = db.Poststeder.FirstOrDefault(q => q.Postnr == p.Postnr).Poststed
                                           }).First();
                return detaljPerson;
            }
            var tomPerson = new Person();
            tomPerson.Id = 0;
            tomPerson.Fornavn = "Fant ikke personen";
            return tomPerson;
        }

        public void lagrePerson(Person personInn)
        {
            try
            {
                // sjekk om postnr ligger i poststedstabellen
                bool funnet = db.Poststeder.Any(p => p.Postnr == personInn.Postnr);
                if (!funnet)
                { // hvis ikke poststedet som det er endret til ligger i poststedstabellen legg det inn!
                    var nyttPoststed = new PostSted()
                    {
                        Postnr = personInn.Postnr,
                        Poststed = personInn.Poststed
                    };
                    db.Poststeder.Add(nyttPoststed);
                    db.SaveChanges();
                }
                var nyPerson = new PersonDb();
                // oppdater personen fra databasen
                nyPerson.Fornavn = personInn.Fornavn;
                nyPerson.Etternavn = personInn.Etternavn;
                nyPerson.Adresse = personInn.Adresse;
                nyPerson.Epost = personInn.Epost;
                nyPerson.Telefonnr = personInn.Telefonnr;
                nyPerson.Postnr = personInn.Postnr;

                // NB kan ikke legge inn poststedet her, må finne hele det nye/gamle poststedet og legge det inn i personen.
                nyPerson.Poststed = db.Poststeder.FirstOrDefault(p => p.Postnr == personInn.Postnr);
                db.Personer.Add(nyPerson);
                db.SaveChanges();
            }
            catch (Exception feil)
            {

            }
        }
        public void endrePerson(int id, Person personInn)
        {
            try
            {
                // finn personen i databasen
                PersonDb endrePerson = db.Personer.FirstOrDefault(p => p.Id == id);
                // sjekk om den nye postnr ligger i poststedstabellen
                bool funnet = db.Poststeder.Any(p => p.Postnr == personInn.Postnr);
                if (!funnet)
                { // hvis ikke poststedet som det er endret til ligger i poststedstabellen legg det inn!
                    var nyttPoststed = new PostSted()
                    {
                        Postnr = personInn.Postnr,
                        Poststed = personInn.Poststed
                    };
                    db.Poststeder.Add(nyttPoststed);
                    db.SaveChanges();
                }
                // oppdater personen fra databasen
                endrePerson.Fornavn = personInn.Fornavn;
                endrePerson.Etternavn = personInn.Etternavn;
                endrePerson.Adresse = personInn.Adresse;
                endrePerson.Epost = personInn.Epost;
                endrePerson.Telefonnr = personInn.Telefonnr;

                // NB kan ikke endre postnr her, må finne hele det nye/gamle poststedet og legge det inn i personen.
                endrePerson.Poststed = db.Poststeder.FirstOrDefault(p => p.Postnr == personInn.Postnr);

                db.SaveChanges();
            }
            catch (Exception feil)
            {

            }
        }
        public void slettPerson(int id)
        {
            try
            {
                PersonDb slettPerson = db.Personer.FirstOrDefault(p => p.Id == id);
                db.Personer.Remove(slettPerson);
                db.SaveChanges();
            }
            catch (Exception feil)
            {

            }
        }
    }
}