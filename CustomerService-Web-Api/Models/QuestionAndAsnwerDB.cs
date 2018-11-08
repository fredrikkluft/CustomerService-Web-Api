using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Web;

namespace CustomerService_Web_Api.Models
{
    
        public class PersonDb
        {
            [Key]
            public int Id { get; set; }
            public string Fornavn { get; set; }
            public string Etternavn { get; set; }
            public string Adresse { get; set; }
            public string Epost { get; set; }
            public string Telefonnr { get; set; }
            public string Postnr { get; set; }

            public virtual PostSted Poststed { get; set; }

        }
        public class PostSted
        {
            [Key]
            public string Postnr { get; set; }
            public string Poststed { get; set; }
        }

        public class QA
        {
            [Key]
            public int Id { get; set; }
            public string Question { get; set; }
            public string Answer { get; set; }
            public string Category { get; set; }
        }

        public class QAContext : DbContext
        {
            public QAContext()
                : base("name=DatabaseService")
            {

                Database.CreateIfNotExists();
                
            }

            public DbSet<PersonDb> Personer { get; set; }
            public DbSet<PostSted> Poststeder { get; set; }
            public DbSet<QA> QandAs { get; set; }

            protected override void OnModelCreating(DbModelBuilder modelBuilder)
            {
                modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            }
        }
    
}