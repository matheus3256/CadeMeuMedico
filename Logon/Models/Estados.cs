using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Logon.Models
{
    [Table("Estados")]
    public class Estados
    {
        [Required]
        public int ID { get; set; }
        [Required]
        [MaxLength(50)]
        public string Estado { get; set; }
        [Required]
        [MaxLength(2)]
        public string Sigla { get; set; }

    }
}