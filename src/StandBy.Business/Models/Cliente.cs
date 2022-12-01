using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace StandBy.Business.Models
{
    [Table("cliente")]
    public class Cliente
    {
     
        public int CLIENTE_ID { get; set; }
        public string RAZAO_SOCIAL { get; set; }

        public DateTime DATA_FUNDACAO { get; set; }
        public string CNPJ { get; set; }

        public decimal CAPITAL { get; set; }
        public bool QUARENTENA { get; set; }
        public bool STATUS_CLIENTE { get; set; }
        public char CLASSIFICACAO { get; set; }


        public void SetClassificao()
        {
            if (this.CAPITAL <= 10000)
            {
                this.CLASSIFICACAO = 'C';
            }
            else if (this.CAPITAL > 10000 && this.CAPITAL <= 1000000)
            {
                this.CLASSIFICACAO = 'B';
            }
            if (this.CAPITAL > 1000001)
            {
                this.CLASSIFICACAO = 'A';
            }
        }

        public void SetQuarenenta()
        {
            TimeSpan idade = DateTime.Now.Subtract(this.DATA_FUNDACAO);
            if (idade.Days<365)
            {
                this.QUARENTENA = true;
            }
            else
            {
                this.QUARENTENA = false;
            }
        }
    }
}
