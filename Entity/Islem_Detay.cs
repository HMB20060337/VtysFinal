using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp1.Entity
{
    public class Islem_Detay
    {
        [Key] public int ID { get; set; }

        public virtual Islemler IslemId { get; set; }

        public virtual Urunler UrunID { get; set; }

        public int Miktar { get; set; }
    }
}
