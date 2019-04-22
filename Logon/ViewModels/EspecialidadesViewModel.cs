using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Logon.ViewModels
{
    public class EspecialidadesViewModel
    {
        [Required(ErrorMessage = "Obrigatorio informar Especialidade")]
        [StringLength(100, ErrorMessage = "Informe uma Especialidade Valida")]
        public String Especialidade { get; set; }

    }
}