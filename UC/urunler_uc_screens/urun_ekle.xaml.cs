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

namespace WpfApp1.UC.urunler_uc_screens
{
    /// <summary>
    /// urun_ekle.xaml etkileşim mantığı
    /// </summary>
    public partial class urun_ekle : UserControl
    {
        private Context db;
        private Grid x;
        public urun_ekle(Context datab, Grid x)
        {
            InitializeComponent();
            this.db = datab;
            this.x = x;
        }

        private void barkod_text_GotKeyboardFocus(object sender, KeyboardFocusChangedEventArgs e)
        {
            barkod_text.Text = "";
            barkod_text.Foreground = new SolidColorBrush(Colors.Black);
            barkod_text.TextAlignment = TextAlignment.Left;
            barkod_text.FontSize = 18;
            barkod_text.Height = 35;
        }

        private void barkod_text_LostKeyboardFocus(object sender, KeyboardFocusChangedEventArgs e)
        {
            if (barkod_text.Text == "" || barkod_text.Text == "Bu Alan Boş Bırakılamaz")
            {
                barkod_text.Text = "Barkod...";
                barkod_text.Foreground = new SolidColorBrush(Colors.LightGray);
                barkod_text.TextAlignment = TextAlignment.Center;
                barkod_text.FontSize = 18;
            }
        }
        private void urun_adi_text_GotKeyboardFocus(object sender, KeyboardFocusChangedEventArgs e)
        {
            urun_adi_text.Text = "";
            urun_adi_text.Foreground = new SolidColorBrush(Colors.Black);
            urun_adi_text.TextAlignment = TextAlignment.Left;
            urun_adi_text.FontSize = 18;
            urun_adi_text.Height = 35;
        }
        private void urun_adi_text_LostKeyboardFocus(object sender, KeyboardFocusChangedEventArgs e)
        {
            if (urun_adi_text.Text == "" || urun_adi_text.Text == "Bu Alan Boş Bırakılamaz")

            {
                urun_adi_text.Text = "Ürün Adı...";
                urun_adi_text.Foreground = new SolidColorBrush(Colors.LightGray);
                urun_adi_text.TextAlignment = TextAlignment.Center;
                urun_adi_text.FontSize = 18;
            }

        }
        private void alis_text_GotKeyboardFocus(object sender, KeyboardFocusChangedEventArgs e)
        {
            alis_text.Text = "";
            alis_text.Foreground = new SolidColorBrush(Colors.Black);
            alis_text.TextAlignment = TextAlignment.Left;
            alis_text.FontSize = 18;
            alis_text.Height = 35;
        }

        private void alis_text_LostKeyboardFocus(object sender, KeyboardFocusChangedEventArgs e)
        {
            if (alis_text.Text == "" || alis_text.Text == "Bu Alan Boş Bırakılamaz")
            {
                alis_text.Text = "Alış Fiyatı...";
                alis_text.Foreground = new SolidColorBrush(Colors.LightGray);
                alis_text.TextAlignment = TextAlignment.Center;
                alis_text.FontSize = 18;
            }
        }

        private void satis_text_GotKeyboardFocus(object sender, KeyboardFocusChangedEventArgs e)
        {
            satis_text.Text = "";
            satis_text.Foreground = new SolidColorBrush(Colors.Black);
            satis_text.TextAlignment = TextAlignment.Left;
            satis_text.FontSize = 18;
            satis_text.Height = 35;
        }

        private void satis_text_LostKeyboardFocus(object sender, KeyboardFocusChangedEventArgs e)
        {
            if (satis_text.Text == "" || satis_text.Text == "Bu Alan Boş Bırakılamaz")
            {
                satis_text.Text = "Satış Fiyatı...";
                satis_text.Foreground = new SolidColorBrush(Colors.LightGray);
                satis_text.TextAlignment = TextAlignment.Center;
                satis_text.FontSize = 18;
            }
        }
        private void add_urun_btn_Click(object sender, RoutedEventArgs e)
        {
            if (satis_text.Text == "Satış Fiyatı..." || satis_text.Text == "" || satis_text.Text == "Bu Alan Boş Bırakılamaz" || alis_text.Text == "Alış Fiyatı..." || alis_text.Text == "" || alis_text.Text == "Bu Alan Boş Bırakılamaz" || urun_adi_text.Text == "Ürün Adı..." || urun_adi_text.Text == ""|| urun_adi_text.Text == "Bu Alan Boş Bırakılamaz" || barkod_text.Text == "Barkod..." || barkod_text.Text == "" || barkod_text.Text == "Bu Alan Boş Bırakılamaz")
            {
                if (satis_text.Text == "Satış Fiyatı..." || satis_text.Text == "") { satis_text.Height=55; satis_text.Text = "Bu Alan Boş Bırakılamaz"; satis_text.Foreground = new SolidColorBrush(Colors.Red); }
                if (alis_text.Text == "Alış Fiyatı..." || alis_text.Text == "") { alis_text.Height = 55; alis_text.Text = "Bu Alan Boş Bırakılamaz"; alis_text.Foreground = new SolidColorBrush(Colors.Red); }
                if (urun_adi_text.Text == "Ürün Adı..." || urun_adi_text.Text == "") {urun_adi_text.Height = 55; urun_adi_text.Text = "Bu Alan Boş Bırakılamaz"; urun_adi_text.Foreground = new SolidColorBrush(Colors.Red); }
                if (barkod_text.Text == "Barkod..." || barkod_text.Text == "") { barkod_text.Height = 55; barkod_text.Text = "Bu Alan Boş Bırakılamaz"; barkod_text.Foreground = new SolidColorBrush(Colors.Red); }
            }
            else
            {
                Urunler temp = new Urunler
                {
                    Barkod = barkod_text.Text,
                    UrunAdi = urun_adi_text.Text,
                    AlisFiyati = float.Parse(alis_text.Text, System.Globalization.CultureInfo.InvariantCulture),
                    SatisFiyati = float.Parse(satis_text.Text, System.Globalization.CultureInfo.InvariantCulture),
                };
                db.Urunler.Add(temp);
                db.SaveChanges();
                MessageBox.Show("Ürün Kaydı Oluşturuldu");
                Class1.uc_ekle(a, new urunler(db,x));
            }

        }     
    }
}