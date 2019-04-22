using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Logon.ViewModels
{
    public class EstadosViewModel
    {
        [Required(ErrorMessage = "Obrigatorio informar um Estado")]
        [StringLength(100, ErrorMessage = "Informe um Estado Valido")]
        public string Estado { get; set; }

        [Required(ErrorMessage = "Obrigatorio informar uma Sigla para o Estado")]
        [StringLength(2, ErrorMessage = "Informe uma Sigla Valida")]
        public string Sigla { get; set; }

    }
}