using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp1.Entity
{
    public class Stok_Giris_Detay
    {

        [Key]  public int Id { get; set; }

        public Stok_Giris girisId { get; set; }

        public Urunler urunler { get; set; }

        public int sayi { get; set; }
    }
}
