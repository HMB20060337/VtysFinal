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

namespace WpfApp1.UC.musteriler_uc_screens
{
    /// <summary>
    /// borc_ode.xaml etkileşim mantığı
    /// </summary>
    public partial class borc_ode : UserControl
    {

        private Context db;
        private Grid x;
        List<Musteriler> b = new List<Musteriler>();
        public borc_ode(Context db,Grid x)
        {
            InitializeComponent();
            this.x = x;
            this.db = db;
            acilis();
        }
        private void acilis()
        {
            var q = from musteri in db.Musteriler where musteri.Borc>0 select new { musteri.MusteriId, musteri.MusteriAdi, musteri.MusteriSoyadi, };
            combo.ItemsSource = q.ToList();
            q.ToList().ForEach(x =>
            {
                Musteriler a = new Musteriler
                {
                    MusteriId = x.MusteriId,
                    MusteriAdi = x.MusteriAdi,
                    MusteriSoyadi = x.MusteriSoyadi,
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
            if (odeme.Text == "" || odeme.Text == "Bu Alan Boş Bırakılamaz"|| odeme.Text == "Ödeme Borçtan Büyük Olamaz")

            {
                odeme.Text = "Ödeme Miktarı...";
                odeme.Foreground = new SolidColorBrush(Colors.LightGray);
                odeme.TextAlignment = TextAlignment.Center;
                odeme.FontSize = 18;
            }

        }

        private void musteri_sec_btn_Click(object sender, RoutedEventArgs e)
        {
            var qq = db.Musteriler.Find(b[combo.SelectedIndex].MusteriId);
            if (odeme.Text == "" || odeme.Text == "Ödeme Miktarı..." || odeme.Text == "Bu Alan Boş Bırakılamaz"|| odeme.Text == "Ödeme Borçtan Büyük Olamaz")
            {
                odeme.Text = "Bu Alan Boş Bırakılamaz";
                odeme.Height = 55;
                odeme.Foreground= new SolidColorBrush(Colors.Red);
            }
            else if (qq.Borc< Convert.ToDouble(odeme.Text))
            {

                odeme.Text = "Ödeme Borçtan Büyük Olamaz";
                odeme.Height = 55;
                odeme.Foreground = new SolidColorBrush(Colors.Red);

            }
            else
            {
                Musteri_Odeme b_odeme = new Musteri_Odeme
                {
                    MusteriId = qq,
                    Tarih = DateTime.Now,
                    Odeme = Convert.ToDouble(odeme.Text),
                };
                db.Musteri_Odemes.Add(b_odeme);
                qq.Borc = qq.Borc - Convert.ToDouble(odeme.Text);
                db.SaveChanges();
                MessageBox.Show(qq.MusteriAdi+" "+"adlı müsterinin" +" "+ Convert.ToDouble(odeme.Text) +" " + "TL borcu ödendi.");
                Class1.uc_ekle(x, new musteriler_uc(db, x));
            }
        }

        private void combo_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

            List<Fatura> a = new List<Fatura>();
            List<Musteri_Odeme> p = new List<Musteri_Odeme>();

            var kk = db.Musteriler.Find(b[combo.SelectedIndex].MusteriId);

            var q = from fatura in db.Fatura.Where(x => x.MusteriId.MusteriId == kk.MusteriId)
                    select new
                    {
                        fatura.Tarih,
                        fatura.Tutar,
                    };
            q.ToList().ForEach(x => 
            {
                Fatura f = new Fatura
                {
                    Tarih = x.Tarih,
                    Tutar = x.Tutar,
                };
                a.Add(f);
            });
            faturalar.ItemsSource = a;
            faturalar.Items.Refresh();
            
            var k = from odeme in db.Musteri_Odemes.Where(x => x.MusteriId.MusteriId == kk.MusteriId) 
                    select new 
                    { 
                        odeme.Tarih,odeme.Odeme,
                        odeme.MusteriId
                    };
            k.ToList().ForEach(x =>
            {                   
                    Musteri_Odeme f = new Musteri_Odeme
                    {
                        Tarih = x.Tarih,
                        Odeme = x.Odeme,
                    };
                    p.Add(f);
                          
            });
            odemeler.ItemsSource = p;
            label.Content = "Mevcut Borç: "+kk.Borc.ToString();
        }
    }
}
