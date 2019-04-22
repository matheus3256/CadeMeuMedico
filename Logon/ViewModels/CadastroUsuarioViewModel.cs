using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Logon.ViewModels
{
    public class CadastroUsuarioViewModel
    {
        [Required(ErrorMessage="Informe o Nome")]
        [MaxLength(100,ErrorMessage ="Pode no Maximo 100 Caracteres")]
        public string Nome { get; set; }


        [Required(ErrorMessage = "Informe o Login")]
        [MaxLength(100, ErrorMessage = "Pode no Maximo 100 Caracteres")]
        public string Login { get; set; }


        [Required(ErrorMessage = "Informe o Senha")]
        [DataType(DataType.Password)]
        [MaxLength(100, ErrorMessage = "Pode no Maximo 100 Caracteres")]
        [MinLength(6, ErrorMessage = "No minimo 6 Caracteres")]
        public string Senha { get; set; }


        [Required(ErrorMessage = "Informe novamente a Senha")]
        [DataType(DataType.Password)]
        [Display(Name ="Confirme sua senha")]
        [MinLength(6,ErrorMessage ="minimo 6 Caracteres")]
        [Compare(nameof(Senha), ErrorMessage ="a senha e a confirmaçao nao estao iguais")]

      
        public string ConfirmacaoSenha { get; set; }
    }
}