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
    /// musteri_islem_detay.xaml etkileşim mantığı
    /// </summary>
    public partial class musteri_islem_detay : UserControl
    {
        private Context db;
        private Fatura fatura;
        private Grid x;
        private ObservableCollection<Urunler> urunlers = new ObservableCollection<Urunler>();
        public musteri_islemler uc;
        public musteri_islem_detay(Context db, Fatura a, Grid x,musteri_islemler qqq)
        {
            InitializeComponent();
            this.db = db;
            this.x = x;
            this.fatura = a;
            this.uc = qqq;
            acilis();
        }
        private void acilis()
        {
            kullanici_label.Content = fatura.KullaniciId.KullaniciAdi;
            tarih_label.Content = fatura.Tarih.ToString();
            tutar_label.Content = fatura.Tutar.ToString();

            var qq = from detay in db.Fatura_Detay.Where(x => x.FaturaId.FaturaId == fatura.FaturaId)
                     select new
                     {
                         detay.UrunlerId,
                         detay.miktar
                     };

            qq.ToList().ForEach(x =>
            {
                urunlers.Add(new Urunler
                {
                    UrunID = x.UrunlerId.UrunID,
                    UrunAdi = x.UrunlerId.UrunAdi,
                    Barkod = x.UrunlerId.Barkod,
                    Stok = x.miktar,
                    SatisFiyati = x.UrunlerId.SatisFiyati,
                    AlisFiyati = x.miktar * x.UrunlerId.SatisFiyati
                });
            });      
            satis_urunler_tablo.ItemsSource = urunlers;
        }

        private void kapat_Click(object sender, RoutedEventArgs e)
        {
            Class1.uc_ekle(x, uc);
        }

        private void Sil_Click(object sender, RoutedEventArgs e)
        {
            Class1.uc_ekle(x, new kullanici_dogrulama(db,x,fatura,uc));
        }
    }
}
