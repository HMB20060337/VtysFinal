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

namespace WpfApp1.UC.rapor_screens
{
    /// <summary>
    /// detay.xaml etkileşim mantığı
    /// </summary>
    public partial class detay : UserControl
    {
        private Context db;
        private Islemler ıslem;
        private Grid x;
        private ObservableCollection<Urunler> urunlers= new ObservableCollection<Urunler>();
        public ıslemler uc;
        public detay(Context db,Islemler a,Grid x)
        {
            InitializeComponent();
            this.db = db;
            this.x = x;
            this.ıslem= a;          
            acilis();
        }

        private void acilis()
        {
            kullanici_label.Content = ıslem.KullanıcıId.KullaniciAdi;
            tarih_label.Content = ıslem.tarih.ToString();
            tutar_label.Content = ıslem.Tutar.ToString();
            yontem_label.Content = ıslem.OdemeYontemi;

            var qq = from detay in db.Islem_Detay.Where(x => x.IslemId.IslemId == ıslem.IslemId)
                     select new
                     {
                         detay.UrunID,
                         detay.Miktar
                     };
            
            qq.ToList().ForEach(x =>
            {                              
                urunlers.Add(new Urunler
                {
                    UrunID=x.UrunID.UrunID,
                    UrunAdi=x.UrunID.UrunAdi,
                    Barkod = x.UrunID.Barkod,
                    Stok = x.Miktar,
                    SatisFiyati =x.UrunID.SatisFiyati,
                    AlisFiyati = x.Miktar * x.UrunID.SatisFiyati
                });
            });

            satis_urunler_tablo.ItemsSource= urunlers;
            
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Class1.uc_ekle(x,new dogrulama(db,x,ıslem));
        }

        private void kapat_Click(object sender, RoutedEventArgs e)
        {
            Class1.uc_ekle(x,uc);
        }
    }
}
