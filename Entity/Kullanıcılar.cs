using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp1.Entity
{
    public class Kullanıcılar
    {
        [Key]
        public int KullaniciId { get; set; }

        public string KullaniciAdi { get; set; }
        public string pass { get; set; }
        public virtual ICollection<Islemler> Islemlers { get; set; }

    }
}