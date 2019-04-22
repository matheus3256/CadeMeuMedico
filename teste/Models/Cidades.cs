using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace teste.Models
{
    public class Cidades
    {
          
        [Required]       
        public int IDCidade { get; set; }

        [Required]
        [MaxLength(50)]
        public string Cidade { get; set; }
               
        

        public int IDEstado { get; set; }
        [ForeignKey("IDEstado")]
        public virtual Estados Estado { get; set; }


    

        

    }


}
