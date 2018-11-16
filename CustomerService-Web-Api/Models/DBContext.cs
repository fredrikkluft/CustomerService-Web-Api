using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Web;

namespace CustomerService_Web_Api.Models
{
        public class QA
        {
            [Key]
            public int Id { get; set; }
            public string Question { get; set; }
            public string Answer { get; set; }
            public string Category { get; set; }
            public int Votetype { get; set; }
            public int Votecounter { get; set; }
        }

        public class DBContext : DbContext
        {
            public DBContext()
                : base("name=DatabaseService")
            {
            //Ved første gangs kjøring på ny maskin skal denne være kommentert ut for å inialisere databasen med spørsmål og svar.
            //Etter web applikasjonen har kjørt en gang kan denne kommenteres ut og man kan lagre ting i databasen.

            Database.SetInitializer(new DBinit());    

            //Oppretter databasen 
            //Database.CreateIfNotExists();

        }
        public DbSet<QA> QandAs { get; set; }

            protected override void OnModelCreating(DbModelBuilder modelBuilder)
            {
                modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            }
        }

    public class DBinit : DropCreateDatabaseAlways<DBContext>
    {
        //DB initializing legger inn spørsmål til databasen
        protected override void Seed(DBContext context)
        {
            var QandA = new QandA();

            var q1 = new List<QA>
            {
                new QA
                {
                    Id = 1,
                    Question = "Hvordan kan jeg kjøpe en film?",
                    Answer = "Du kan kjøpe en film ved å trykke på hvilken som helst film og trykke kjøp",
                    Category = "Movies",
                    Votecounter = 2

                },

                new QA
                {
                    Id = 2,
                    Question = "Hvor lenge er filmen jeg har kjøpt tilgjengelig for meg?",
                    Answer = "Filmen vil være tilgjengelig så lenge du har en bruker hos oss.",
                    Category = "Movies",
                    Votecounter = 4

                },

                new QA
                {
                    Id = 3,
                    Question = "Kan jeg kjøpe en film uten å registrere meg som bruker?",
                    Answer = "Nei, du må være en registrert bruker for å kunne kjøpe film hos oss.",
                    Category = "Movies",
                    Votecounter = 4

                },

                new QA
                {
                    Id = 4,
                    Question = "Jeg finner ikke filmen jeg ønsker å kjøpe.",
                    Answer = "Finner du ikke filmen du ønsker å kjøpe er det fordi vi ikke har rettigheter til å selge den filmen videre. Er filmen veldig ny kan du ta kontakt å sende oss et spørsmål med navn på filmen du ønsker, og vi kan gi deg beskjed på mail når den vil komme i vår nettbutikk.",
                    Category = "Movies",
                    Votecounter = 7

                },

                new QA
                {
                    Id = 5,
                    Question = "Hvordan oppretter jeg en bruker hos dere?",
                    Answer = "Du registrerer ny bruker ved å trykke på 'Registrer' knappen i menyen på toppen",
                    Category = "Account",
                    Votecounter = 7

                },

                new QA
                {
                    Id = 6,
                    Question = "Jeg har glemt passordet mitt.",
                    Answer = "Ved glemt passord kan du bruke skjemaet for å sende inn en melding om dette og du vil i retur få en link for å tilbakestille passordet ditt.",
                    Category = "Account",
                    Votecounter = 2
                },

                new QA
                {
                    Id = 7,
                    Question = "Jeg vil slette min konto hos dere.",
                    Answer = "Ønsker du ikke lenger å være bruker hos oss, kan du gå inn på 'Min Side' på menyen. Du kan der velge å trykke 'Slett konto' og din konto vil automatisk bli slettet og du vil bli logget ut.",
                    Category = "Account",
                    Votecounter = 0
                },

                new QA
                {
                    Id = 8,
                    Question = "Kan jeg angre en ordre av film?",
                    Answer = "Nei, du kan ikke angre et filmkjøp.",
                    Category = "Order",
                    Votecounter = 2
                },

                new QA
                {
                    Id = 9,
                    Question = "Hvor kan jeg finne min ordrehistorikk?",
                    Answer = "Du finner din ordrehistorikk ved å klikke på knappen 'Mine Filmer' i menyen, der vil du få en oversikt over alle filmer du har kjøpt og som er tilgjengelig for deg.",
                    Category = "Order",
                    Votecounter = 3
                },

                new QA
                {
                    Id = 10,
                    Question = "Nettsiden fryser når jeg forsøker å kjøpe film?",
                    Answer = "Sjekk om du har internetttilkobling, eller forsøk å restart nettleseren din.",
                    Category = "Other",
                    Votecounter = 2
                },

                new QA
                {
                    Id = 11,
                    Question = "Får feilmelding når jeg skal logge ut.",
                    Answer = "Du vil bli logget ut automatisk ved inaktivitet, så bare lukke nettlesern eller fanen så blir du automatisk logget ut.",
                    Category = "Other",
                    Votecounter = 1
                }
            };
            q1.ForEach(a => context.QandAs.Add(a));
        }
    }
    
}