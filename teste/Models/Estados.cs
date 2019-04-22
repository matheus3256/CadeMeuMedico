using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;


namespace teste.Models
{
    public class Estados
    {

        [Required]
        public int IDEstado { get; set; }
        [Required]
        [MaxLength(50)]
        public string Estado { get; set; }
        [Required]
        [MaxLength(2)]
        public string Sigla { get; set; }
    }
}