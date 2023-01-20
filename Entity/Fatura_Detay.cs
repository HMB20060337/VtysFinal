using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp1.Entity
{
    public class Fatura_Detay
    {

        [Key] public int FaturaDetayID { get; set; }
        public virtual Fatura Fatura { get; set; }

        public virtual Urunler Urunler { get; set; }

    }
}