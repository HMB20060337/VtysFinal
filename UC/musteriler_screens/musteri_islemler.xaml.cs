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
using WpfApp1.UC.rapor_screens;

namespace WpfApp1.UC.musteriler_screens
{
    /// <summary>
    /// musteri_islemler.xaml etkileşim mantığı
    /// </summary>
    public partial class musteri_islemler : UserControl
    {
        private Context db;
        private Grid x;
        private Musteriler musteri;
        private ObservableCollection<Fatura> a = new ObservableCollection<Fatura>();
        public musteri_islemler qqq;
        public musteri_islemler(Context db, Grid x,Musteriler musteri)
        {
            InitializeComponent();
            this.db = db;
            this.x = x;
            this.musteri = musteri;
            acilis();
        }
        public void acilis()
        {
            a.Clear();
            baslik.Content = musteri.MusteriAdi + " " + musteri.MusteriSoyadi + " Yapılan Alışverişler";
            var q = from fatura in db.Fatura.Where(x=> x.MusteriId.MusteriId==musteri.MusteriId) select new { fatura.FaturaId,fatura.KullaniciId,fatura.MusteriId,fatura.Tarih,fatura.Tutar };
            q.ToList().ForEach(x =>
            {
                a.Add(new Fatura
                {
                    FaturaId = x.FaturaId,
                    KullaniciId = x.KullaniciId,
                    MusteriId = x.MusteriId,
                    Tarih = x.Tarih,
                    Tutar = x.Tutar
                });
            });
            islemlertablo.ItemsSource = a;
        }

        private void detay_Click(object sender, RoutedEventArgs e)
        {
            Class1.uc_ekle(x, new musteri_islem_detay(db, a[islemlertablo.SelectedIndex],x,qqq));
        }

        private void sil_Click(object sender, RoutedEventArgs e)
        {
            Class1.uc_ekle(x, new kullanici_dogrulama(db, x, a[islemlertablo.SelectedIndex], qqq));
        }
    }
}
