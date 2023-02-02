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
using WpfApp1.Class;
using WpfApp1.UC.urunler_uc_screens;
using Context = WpfApp1.Entity.Context;

namespace WpfApp1.UC
{
    /// <summary>
    /// urunler.xaml etkileşim mantığı
    /// </summary>
    public partial class urunler : UserControl
    {
        private Context db;
        private Grid x;
        public urunler(Context datab,Grid a)
        {
            InitializeComponent();           
            this.db = datab;
            this.x = a;
            acilis();
        }

        private void acilis (){      
            var q = from urun in db.Urunler select new {urun.UrunID, urun.Barkod, urun.UrunAdi, urun.Stok, urun.AlisFiyati, urun.SatisFiyati };
            satis_urunler_tablo.ItemsSource = q.ToList();
        }

        private void urun_ekle_btn_Click(object sender, RoutedEventArgs e)
        {
            Class1.uc_ekle(x, new urun_ekle(db,x));  
        }
    }

}
