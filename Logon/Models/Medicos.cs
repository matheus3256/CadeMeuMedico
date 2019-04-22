using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Logon.Models
{
    [Table("Medicos")]
    public class Medicos
    {

        [Required]
        public int ID { get; set; }

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


        public int EspecialidadeID { get; set; }
        [ForeignKey("EspecialidadeID")]
        public virtual Especialidades Especialidade { get; set; }


        public int CidadeID { get; set; }
        [ForeignKey("CidadeID")]
        public virtual Cidades Cidade { get; set; }

    }
}