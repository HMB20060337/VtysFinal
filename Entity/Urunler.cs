using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp1.Entity
{
    public class Urunler
    {
        [Key]
        public int UrunID { get; set; }

        public string Barkod { get; set; }
        public string UrunAdi { get; set; }
        public double AlisFiyati { get; set; }
        public double SatisFiyati { get; set; }
        public int Stok { get; set; }
        public virtual ICollection<Fatura_Detay> Fatura_Detays { get;set; }

        public virtual ICollection<Stok_Giris_Detay> Stok_Giris_Detays { get; set;}

        public virtual ICollection<Islem_Detay> Islem_Detays { get; set; }

    }
}
