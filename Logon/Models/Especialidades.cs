using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Logon.Models
{
    [Table("Especialidades")]
    public class Especialidades
    {
        [Required]
        public int ID { get; set; }
        

        [Required]
        [MaxLength(60)]
        public string Especialidade { get; set; }
    }
}