using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace WpfApp1.Entity
{
    public class Fatura
    {
        [Key] public int FaturaId { get; set; }

        [Column(TypeName = "datetime2")]
        public DateTime Tarih { get; set; }

        public double Tutar { get; set; }

        public virtual Musteriler MusteriId { get; set; }

        public virtual Kullanıcılar KullaniciId { get; set; }

    }
}
