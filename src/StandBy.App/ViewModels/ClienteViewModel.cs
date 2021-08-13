using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace StandBy.App.ViewModels
{
    
    public class ClienteViewModel
    {

        [Key]    
        public int CLIENTE_ID { get; set; }

        [Required]
        [DisplayName("Razão Social ")]
        [StringLength(200)]
        public string RAZAO_SOCIAL { get; set; }

        [Required]
        [DisplayName("Data de Fundação")]
        public DateTime DATA_FUNDACAO { get; set; }

        [Required]
        [DisplayName("CNPJ")]
        public string CNPJ { get; set; }

        [Required]
        [DisplayName("Capital R$: ")]
        [DataType(DataType.Currency)]
        public decimal CAPITAL { get; set; }

        [Required]
        public bool QUARENTENA { get; set; }

        [Required]
        [DisplayName("Status do Cliente")]
        public bool STATUS_CLIENTE { get; set; }


        public char CLASSIFICACAO { get; set; }
    }
}
