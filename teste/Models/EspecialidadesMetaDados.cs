using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace teste.Models
{
    [MetadataType(typeof(EspecialidadesMetaDados))]
    public partial class Especialidades
    { }
        public class EspecialidadesMetaDados
    {
       
            [Required(ErrorMessage = "Obrigatorio informar Especialidade")]
            [StringLength(80, ErrorMessage = "Informe uma Especialidade Valida")]
            public String Especialidade { get; set; }
        }
    }
