using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace teste.Models
{
    public class Especialidades
    {
        [Required]
        public int IDEspecialidade { get; set; }

        [Required]
        [MaxLength(60)]
        public string Especialidade { get; set; }
    }
}