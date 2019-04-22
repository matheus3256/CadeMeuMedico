using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace teste.Models
{
    public class CadastroUsuarioMetaDados
    {

        [MaxLength(100, ErrorMessage = "Pode no Maximo 100 Caracteres")]
        [Required(ErrorMessage = "Informe o Nome")]
        public string Nome { get; set; }

        [Required(ErrorMessage ="Informe o Login")]
        [MaxLength(100,ErrorMessage ="Pode no Maximo 50 Caracteres")]
        public string Login { get; set; }

        [Required(ErrorMessage = "Informe o Senha")]
        [DataType(DataType.Password)]
        [MaxLength(100, ErrorMessage = "Pode no Maximo 100 Caracteres")]
        [MinLength(6, ErrorMessage = "No minimo 6 Caracteres")]
        public string Senha { get; set; }
        

    }
}