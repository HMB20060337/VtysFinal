using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.Entity.Migrations;
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

namespace WpfApp1.UC.satis_screens
{
    /// <summary>
    /// musteri_satis.xaml etkileşim mantığı
    /// </summary>
    public partial class musteri_satis : UserControl
    {
        private Context db;
        private Grid x;
        private ObservableCollection<Urunler> a;
        Kullanıcılar k;
        List<Musteriler> b = new List<Musteriler>();
        double toplam;
        public musteri_satis(Context datab, Grid x, ObservableCollection<Urunler> a, Kullanıcılar k, double toplam)
        {
            InitializeComponent();
            this.db = datab;
            this.x = x;
            this.a = a;
            this.k = k;
            acilis();
            this.toplam = toplam;
        }

        private void acilis()
        {
            var q = from musteri in db.Musteriler select new {musteri.MusteriId, musteri.MusteriAdi, musteri.MusteriSoyadi,};
            combo.ItemsSource = q.ToList();
            q.ToList().ForEach(x =>
            {
                Musteriler a = new Musteriler {
                    MusteriId= x.MusteriId,
                    MusteriAdi= x.MusteriAdi,
                    MusteriSoyadi= x.MusteriSoyadi,
                };
                b.Add(a);
            });
        }

        private void musteri_sec_btn_Click(object sender, RoutedEventArgs e)
        {
            DateTime t = DateTime.Now;
            Islemler ıslem = new Islemler
            {
                KullanıcıId = k,
                tarih = t,
                Tutar = toplam,
                OdemeYontemi = "Müşteriye Satış"
            };
            Fatura fatura = new Fatura
            {
                KullaniciId = k,
                Tarih = t,
                Tutar = toplam,
                MusteriId = db.Musteriler.Find(b[combo.SelectedIndex].MusteriId)
            };
            db.Fatura.Add(fatura);
            db.Islemler.Add(ıslem);
            db.SaveChanges();
            a.ToList().ForEach(x => {
                Islem_Detay ıslem_Detay = new Islem_Detay
                {
                    IslemId = ıslem,
                    UrunID = db.Urunler.Find(x.UrunID),
                    Miktar = x.Stok
                };
                var qw = db.Urunler.Find(x.UrunID);
                qw.Stok = qw.Stok - x.Stok;
                db.Islem_Detay.Add(ıslem_Detay);
            });
            a.ToList().ForEach(x => {
                Fatura_Detay fatura_Detay = new Fatura_Detay
                {
                    FaturaId = fatura,
                    UrunlerId = db.Urunler.Find(x.UrunID),
                    miktar = x.Stok
                };
                db.Fatura_Detay.Add(fatura_Detay);
            });
            db.SaveChanges();
            var qq = db.Musteriler.Find(b[combo.SelectedIndex].MusteriId);
            qq.Borc = qq.Borc + toplam;
            db.SaveChanges();
            Class1.uc_ekle(x, new satis(k,db, x));
        }
    }
}
