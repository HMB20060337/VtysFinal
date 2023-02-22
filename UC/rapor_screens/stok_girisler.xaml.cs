using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
using WpfApp1.UC.firmalar_screens;

namespace WpfApp1.UC.rapor_screens
{
    /// <summary>
    /// stok_girisler.xaml etkileşim mantığı
    /// </summary>
    public partial class stok_girisler : UserControl
    {
        private Context db;
        private Grid x;
        private ObservableCollection<Stok_Giris> a = new ObservableCollection<Stok_Giris>();
        public stok_girisler qqq;
        public stok_girisler(Context db, Grid x)
        {
            InitializeComponent();
            this.db = db;
            this.x = x;
            acilis();
        }
        private void acilis()
        {
            var q = from sGiris in db.Stok_Giris select new { sGiris.FirmaId, sGiris.Id, sGiris.tarih, sGiris.tutar };
            q.ToList().ForEach(x =>
            {
                a.Add(new Stok_Giris
                {
                    FirmaId = x.FirmaId,
                    Id = x.Id,
                    tarih = x.tarih,
                    tutar = x.tutar
                });
            });
            islemlertablo.ItemsSource = a;
        }

        private void detay_Click(object sender, RoutedEventArgs e)
        {
            Class1.uc_ekle(x, new stok_giris_detay(db, a[islemlertablo.SelectedIndex], x, qqq));
        }
    }
}
