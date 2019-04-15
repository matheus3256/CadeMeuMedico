using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace teste.Models
{
    [MetadataType(typeof(UsuarioMetaDados))]
    public partial class Usuarios
    { }
    public class UsuarioMetaDados
    {
        [Required(ErrorMessage = "Obrigatorio informar um Nome")]
        [StringLength(80, ErrorMessage = "Informe um Nome Valido")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "Obrigatorio informar uma Usuario")]
        [StringLength(30, ErrorMessage = "Informe uma Usuario Valido")]
        public string Usuario { get; set; }

        [Required(ErrorMessage = "Obrigatorio informar uma Senha para o Login")]
        [StringLength(50, ErrorMessage = "Informe uma Senha Valida")]
        public string Senha { get; set; }

        [Required(ErrorMessage = "Obrigatorio informar um Email para o Login")]
        [StringLength(100, ErrorMessage = "Informe um Email Valido")]
        public string Email { get; set; }


      
    }
}