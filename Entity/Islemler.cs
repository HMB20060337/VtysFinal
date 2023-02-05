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
    public class Islemler
    {
        [Key] public int IslemId { get; set; }

        public virtual Kullanıcılar KullanıcıId { get; set; }

        [Column(TypeName = "datetime2")]
        public DateTime tarih { get; set; }

        public double Tutar { get; set; }

        public string OdemeYontemi { get; set; }

    }
}
