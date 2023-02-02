using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp1.Entity
{
    public class Firma_Odeme
    {
        [Key]
        public int Id { get; set; }

        public DateTime Tarih { get; set; }

        public virtual Firmalar FirmaId { get; set; }

        public double Odeme { get; set; }
    }
}
