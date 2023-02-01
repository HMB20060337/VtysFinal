using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Context = WpfApp1.Entity.Context;

namespace WpfApp1.UC
{
    /// <summary>
    /// urunler.xaml etkileşim mantığı
    /// </summary>
    public partial class urunler : UserControl
    {
        private Context db;
        public urunler(Context datab)
        {
            InitializeComponent();
            acilis();
            this.db = datab;
        }

        private void acilis (){      
            var q = from urun in db.Urunler select new {urun.UrunID, urun.Barkod, urun.UrunAdi, urun.Stok, urun.AlisFiyati, urun.SatisFiyati };
            satis_urunler_tablo.ItemsSource = q.ToList();

        }
        
    }

}
