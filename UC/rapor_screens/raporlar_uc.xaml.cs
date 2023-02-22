using System;
using System.Collections.Generic;
using System.Linq;
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
using WpfApp1.Entity;
using WpfApp1.UC.rapor_screens;

namespace WpfApp1.UC
{
    /// <summary>
    /// raporlar_uc.xaml etkileşim mantığı
    /// </summary>
    public partial class raporlar_uc : UserControl
    {
        private Context db;
        private Grid x;
        private ıslemler uc;
        private stok_girisler uc2;
        public raporlar_uc(Context db,Grid x)
        {
            InitializeComponent();
            this.db = db;
            this.x = x;              
        }
        private void islemler_Click(object sender, RoutedEventArgs e)
        {
            uc = new ıslemler(db, x);
            uc.qqq = uc;
            Class1.uc_ekle(x, uc);
        }

        private void stok_giris_raporlari_Click(object sender, RoutedEventArgs e)
        {
            uc2 = new stok_girisler(db, x);
            uc2.qqq = uc2;
            Class1.uc_ekle(x,uc2);
        }
    }
}
