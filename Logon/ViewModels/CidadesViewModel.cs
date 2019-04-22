using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Logon.ViewModels
{
    public class CidadesViewModel
    {

        [Required(ErrorMessage = "Obrigatorio informar Nome")]
        [StringLength(100, ErrorMessage = "O nome deve conter um numero minimo de letras")]
        public string Cidade { get; set; }
    }
}