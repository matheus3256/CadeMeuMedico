using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace teste.Models
{
    [MetadataType(typeof(CidadesMetaDados))]
    public partial class Cidades { }
    public class CidadesMetaDados
    {

        
        
            [Required(ErrorMessage = "Obrigatorio informar Nome")]
            [StringLength(100, ErrorMessage = "O nome deve conter um numero minimo de letras")]
            public String Nome { get; set; }



        }
    }
    