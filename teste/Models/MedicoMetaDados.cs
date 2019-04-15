﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace teste.Models
{
    [MetadataType(typeof(MedicosMetadados))]
    public partial class Medicos { }
    public class MedicosMetaDados
    {
        
        
            [Required(ErrorMessage = "Obrigatorio informar CRM")]
            [StringLength(30, ErrorMessage ="O CRM deve conter um certo numero de letras")]
            public String CRM { get; set; }

            [Required(ErrorMessage = "Obrigatorio informar Nome")]
            [StringLength(80, ErrorMessage = "O Nome deve conter um certo numero de letras")]
            public String Nome { get; set; }

        [Required(ErrorMessage = "Obrigatorio informar Nome")]
        [StringLength(80, ErrorMessage = "O Nome deve conter um certo numero de letras")]
        public Especialidades Especialidades { get; set; }

        [Required(ErrorMessage= "Obrigatorio informar Endereço")]
            [StringLength(100, ErrorMessage ="Insira um endereço valido")]
            public String Endereco { get; set; }
            
            [Required(ErrorMessage = "Obrigatorio informar Bairro")]
            [StringLength(80, ErrorMessage = "Insira um Bairro valido")]
            public String Bairro { get; set; }
            
            [Required(ErrorMessage = "Obrigatorio Informar E-mail valido")]
            [StringLength(100, ErrorMessage = "Insira um email valido")]
            public String Email { get; set; }
            
            [Required(ErrorMessage = "Obrigatorio informar SIM/NAO")]
            [StringLength(100, ErrorMessage = "Insira um valor valido")]
            public bool AtendePorConvenio { get; set; }

            [Required(ErrorMessage = "Obrigatorio informar se tem Clinica ou Não")]
            [StringLength(100, ErrorMessage = "Insira um valor valido")]
            public bool TemClinica { get; set; }

            [Required(ErrorMessage = "Obrigatorio informar WebSite")]
            [StringLength(100, ErrorMessage = "Insira um WebSite valido")]
            public bool WebsiteBlog { get; set; }

        }

        public class MedicosMetadados
        {


        }
    }
