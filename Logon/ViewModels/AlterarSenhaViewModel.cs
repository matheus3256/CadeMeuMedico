using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Logon.ViewModels
{
    public class AlterarSenhaViewModel
    {
        [Required(ErrorMessage="Informe a senha atual")]
        [DataType(DataType.Password)]
        [Display(Name="Senha Atual")]
        public string SenhaAtual { get; set; }

        [Required(ErrorMessage = "Informe a Nova Senha")]
        [DataType(DataType.Password)]
        [Display(Name = "Nova Senha")]
        public string NovaSenha { get; set; }

        [Required(ErrorMessage = "Repita a Senha")]
        [DataType(DataType.Password)]
        [Display(Name = "Confirme a Senha")]
        [Compare(nameof(NovaSenha),ErrorMessage="As senhas nao correspondem")]
        public string ConfirmarSenha { get; set; }
    }
}