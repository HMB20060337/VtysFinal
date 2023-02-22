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
    public class Stok_Giris
    {
        [Key] public int Id { get; set; }
        
        
        [Column(TypeName = "datetime2")]
        public DateTime tarih { get; set; }

        public int tutar { get; set; }

        public virtual Firmalar FirmaId { get; set; }
    }
}
