using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CustomerService_Web_Api.Models
{
    public class QandA
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [RegularExpression("^[a-zøæåA-ZØÆÅ.0-9\\?\\!\\@\\/\\*\\(\\)\\&\\%\\$ \\-]{2,400}$")]
        public string Question { get; set; }
        [RegularExpression("^[a-zøæåA-ZØÆÅ.0-9\\?\\!\\@\\/\\*\\(\\)\\&\\%\\$ \\-]{0,400}$")]
        public string Answer { get; set; }
        [RegularExpression("^[a-zøæåA-ZØÆÅ. \\-]{2,20}$")]
        public string Category { get; set; }
        [RegularExpression("^[0-1]{1}$")]
        public int Votetype {get; set;}
        public int Votecounter { get; set; }
      
    }
}