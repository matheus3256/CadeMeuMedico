using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace teste.Models
{
    public class Medicos
    {
        [Required]
        public int IDMedicos { get; set; }

        [Required]
        [MaxLength(100)]
        public string Nome { get; set; }

        [Required]
        [MaxLength(100)]
        public string CRM { get; set; }

        [Required]
        [MaxLength(100)]
        public string Endereco { get; set; }

        [Required]
        [MaxLength(100)]
        public string Bairro { get; set; }

        [Required]
        [MaxLength(100)]
        public string Email { get; set; }

        [Required]
        [MaxLength(100)]
        public string WebSiteBlog { get; set; }


        public int IDEspecialidade { get; set; } 
        [ForeignKey("IDEspecialidade")]
        public virtual Especialidades Especialidade { get; set; }

       
        public int IDCidade { get; set; }
        [ForeignKey("IDCidade")]
        public virtual Cidades Cidade { get; set; }

    }
}