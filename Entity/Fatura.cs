using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp1.Entity
{
    public class Fatura
    {
        [Key] public int FaturaId { get; set; }

        public DateTime Tarih { get; set; }

        public double Tutar { get; set; }

        public virtual Musteriler MusteriId { get; set; }

        public virtual Kullanıcılar KullaniciId { get; set; }

    }
}
