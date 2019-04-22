using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Logon.Models
{
    [Table("Cidades")]
    public class Cidades
    {
        [Required]
        public int ID { get; set; }
        [Required]
        [MaxLength(50)]
        public string Cidade { get; set; }

        public int EstadoID { get; set; }
        [ForeignKey("EstadoID")]
        public virtual Estados Estado { get; set; }
    }
    }