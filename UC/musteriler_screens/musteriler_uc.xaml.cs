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
using WpfApp1.UC.musteriler_screens;
using WpfApp1.UC.musteriler_uc_screens;

namespace WpfApp1.UC
{
    /// <summary>
    /// musteriler_uc.xaml etkileşim mantığı
    /// </summary>
    public partial class musteriler_uc : UserControl
    {
        private Context db;
        private Grid x;
        public musteriler_uc(Context datab,Grid x)
        {
            InitializeComponent();
            this.db = datab;
            this.x = x;
            acilis();
        }

        private ObservableCollection<Musteriler> a = new ObservableCollection<Musteriler>();

        private void acilis()
        {
            var q = from musteri in db.Musteriler select new { musteri.MusteriId, musteri.MusteriSoyadi, musteri.MusteriAdi, musteri.Telefon, musteri.Borc };
            q.ToList().ForEach(x => {
                a.Add(new Musteriler {
                    MusteriId=x.MusteriId,
                    MusteriSoyadi = x.MusteriSoyadi,
                    MusteriAdi = x.MusteriAdi,
                    Telefon = x.Telefon,
                    Borc = x.Borc
                });
            });
            musteriler_tablo.ItemsSource = a;
        }

        private void musteri_ekle_btn_Click(object sender, RoutedEventArgs e)
        {
            Class1.uc_ekle(x, new musteri_ekle(db, x));
        }

        private void delete_Click(object sender, RoutedEventArgs e)
        {
            Class1.uc_ekle(x, new musteri_sil(db, x));
        }

        private void borc_Click(object sender, RoutedEventArgs e)
        {
            Class1.uc_ekle(x, new borc_ode(db, x));
        }

        private void detay_Click(object sender, RoutedEventArgs e)
        {
            musteri_islemler uc = new musteri_islemler(db, x, a[musteriler_tablo.SelectedIndex]);
            uc.qqq = uc;
            Class1.uc_ekle(x, uc);
        }
    }
}
