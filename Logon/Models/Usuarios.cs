using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Logon.Models
{
    [Table("Usuarios")]
    public class Usuarios
    {
        [Required]
        public int ID { get; set; }

        [Required]
        [MaxLength(100)]
        public string Nome { get; set; }
        [Required]
        [MaxLength(50)]
        public string Login { get; set; }
        [Required]
        [MaxLength(100)]
        public string Senha { get; set; }
    }


}
