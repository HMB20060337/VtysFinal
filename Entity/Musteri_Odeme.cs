using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp1.Entity
{
    public class Musteri_Odeme
    {
        [Key]
        public int Id { get; set; }

        public virtual Musteriler MusteriId { get; set; }

        public DateTime Tarih { get; set; }

        public double Odeme { get; set; }
    }
}
