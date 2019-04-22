using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Logon.ViewModels
{
    public class LoginViewModel
    {
        [HiddenInput]
        public string UrlRetorno { get; set; }

        [Required(ErrorMessage="Informe o Login")]       
        public string Login { get; set; }

        [Required(ErrorMessage = "Informe a Senha")]
        [DataType(DataType.Password)]
        [MinLength(6,ErrorMessage ="A senha tem que ter no minimo 6 Caracteres")]
        public string Senha { get; set; }


    }
}