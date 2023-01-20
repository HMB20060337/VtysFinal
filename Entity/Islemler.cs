using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp1.Entity
{
    public class Islemler
    {
        [Key] public int IslemId { get; set; }

        public Kullanıcılar KullanıcıId { get; set; }

        public DateTime tarih { get; set; }

        public virtual ICollection<Islem_Detay> Islem_Detay { get; set; }

    }
}
