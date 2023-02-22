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
using WpfApp1.UC.musteriler_uc_screens;

namespace WpfApp1.UC.firmalar_screens
{
    /// <summary>
    /// borc_ode.xaml etkileşim mantığı
    /// </summary>
    public partial class borc_ode : UserControl
    {
        private Context db;
        private Grid x;
        List<Firmalar> b = new List<Firmalar>();
        public borc_ode grd;

        public borc_ode(Context db, Grid x)
        {
            InitializeComponent();
            this.x = x;
            this.db = db;
            acilis();
        }
        private void acilis()
        {
            var q = from firma in db.Firmalar where firma.Borc > 0 select new { firma.FirmaId, firma.FirmaAdi};
            combo.ItemsSource = q.ToList();
            q.ToList().ForEach(x =>
            {
                Firmalar a = new Firmalar
                {
                    FirmaId = x.FirmaId,
                    FirmaAdi = x.FirmaAdi,                   
                };
                b.Add(a);
            });
        }

        private void odeme_GotKeyboardFocus(object sender, KeyboardFocusChangedEventArgs e)
        {
            odeme.Text = "";
            odeme.Foreground = new SolidColorBrush(Colors.Black);
            odeme.TextAlignment = TextAlignment.Left;
            odeme.FontSize = 18;
            odeme.Height = 35;

        }

        private void odeme_LostKeyboardFocus(object sender, KeyboardFocusChangedEventArgs e)
        {
            if (odeme.Text == "" || odeme.Text == "Bu Alan Boş Bırakılamaz" || odeme.Text == "Ödeme Borçtan Büyük Olamaz")

            {
                odeme.Text = "Ödeme Miktarı...";
                odeme.Foreground = new SolidColorBrush(Colors.LightGray);
                odeme.TextAlignment = TextAlignment.Center;
                odeme.FontSize = 18;
            }

        }

        private void musteri_sec_btn_Click(object sender, RoutedEventArgs e)
        {
            var qq = db.Firmalar.Find(b[combo.SelectedIndex].FirmaId);
            if (odeme.Text == "" || odeme.Text == "Ödeme Miktarı..." || odeme.Text == "Bu Alan Boş Bırakılamaz" || odeme.Text == "Ödeme Borçtan Büyük Olamaz")
            {
                odeme.Text = "Bu Alan Boş Bırakılamaz";
                odeme.Height = 55;
                odeme.Foreground = new SolidColorBrush(Colors.Red);
            }
            else if (qq.Borc < Convert.ToDouble(odeme.Text))
            {

                odeme.Text = "Ödeme Borçtan Büyük Olamaz";
                odeme.Height = 55;
                odeme.Foreground = new SolidColorBrush(Colors.Red);

            }
            else
            {
                Firma_Odeme b_odeme = new Firma_Odeme
                {
                    FirmaId = qq,
                    Tarih = DateTime.Now,
                    Odeme = Convert.ToDouble(odeme.Text),
                };
                db.Firma_Odemes.Add(b_odeme);
                qq.Borc = qq.Borc - Convert.ToDouble(odeme.Text);
                db.SaveChanges();
                MessageBox.Show(qq.FirmaAdi + " " + "adlı Firmaya" + " " + Convert.ToDouble(odeme.Text) + " " + "TL ödeme yapıldı.");
                Class1.uc_ekle(x, new firmalar(db, x));
            }
        }

        private List<Stok_Giris> a;
        private List<Firma_Odeme> p;
        private void combo_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

            a = new List<Stok_Giris>();
            p = new List<Firma_Odeme>();

            var kk = db.Firmalar.Find(b[combo.SelectedIndex].FirmaId);

            var q = from stokGiris in db.Stok_Giris.Where(x => x.FirmaId.FirmaId == kk.FirmaId)
                    select new
                    {
                        stokGiris.Id,
                        stokGiris.FirmaId,
                        stokGiris.tarih,
                        stokGiris.tutar,
                    };
            q.ToList().ForEach(x =>
            {
                Stok_Giris f = new Stok_Giris
                {
                    Id = x.Id,
                    FirmaId= x.FirmaId,
                    tarih = x.tarih,
                    tutar = x.tutar,
                };
                a.Add(f);
            });
            faturalar.ItemsSource = a;
            faturalar.Items.Refresh();

            var k = from odeme in db.Firma_Odemes.Where(x => x.FirmaId.FirmaId == kk.FirmaId)
                    select new
                    {
                        odeme.Tarih,
                        odeme.Odeme,
                        odeme.FirmaId
                    };
            k.ToList().ForEach(x =>
            {
                Firma_Odeme f = new Firma_Odeme
                {
                    Tarih = x.Tarih,
                    Odeme = x.Odeme,
                };
                p.Add(f);

            });
            odemeler.ItemsSource = p;
            label.Content = "Mevcut Borç: " + kk.Borc.ToString();
        }

        private void Detay_Click(object sender, RoutedEventArgs e)
        {
            Class1.uc_ekle(x, new detay(db,a[faturalar.SelectedIndex],x,grd));
        }
    }
}