using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp1.Entity
{
    public class Stok_Giris
    {
        [Key] public int Id { get; set; }

        public DateTime tarih { get; set; }

        public int tutar { get; set; }

        public virtual Firmalar FirmaId { get; set; }
                   
    }
}
