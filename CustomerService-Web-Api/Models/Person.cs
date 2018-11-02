using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CustomerService_Web_Api.Models
{
    public class Person
    {
        public int Id { get; set; }
        public string Fornavn { get; set; }
        public string Etternavn { get; set; }
        public string Adresse { get; set; }
        public string Postnr { get; set; }
        public string Poststed { get; set; }
        public string Telefonnr { get; set; }
        public string Epost { get; set; }
    }
}