using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp1.Entity
{
    public class Firmalar
    {
        [Key] public int FirmaId { get; set; }

        public string FirmaAdi { get; set; }

        public int Borc { get; set; }

        public virtual ICollection<Stok_Giris> Giris { get; set; }

    }
}
