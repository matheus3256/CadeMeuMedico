using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace teste.Models
{
    [MetadataType(typeof(PaisesMetaDados))]
    public partial class Paises { }
    
    
    public class PaisesMetaDados
    {
        [Required(ErrorMessage = "Obrigatorio informar um Pais")]
        [StringLength(80, ErrorMessage = "Informe um Pais Valido")]
        public string Pais { get; set; }

        [Required(ErrorMessage = "Obrigatorio informar uma Sigla para o Pais")]
        [StringLength(2, ErrorMessage = "Informe uma Sigla Valida")]
        public string Sigla { get; set; }
        
    }
}