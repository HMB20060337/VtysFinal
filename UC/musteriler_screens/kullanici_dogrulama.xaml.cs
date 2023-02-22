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

namespace WpfApp1.UC.musteriler_screens
{
    /// <summary>
    /// kullanici_dogrulama.xaml etkileşim mantığı
    /// </summary>
    public partial class kullanici_dogrulama : UserControl
    {
        private Context db;
        private Grid x;
        private Fatura ıslem;
        private musteri_islemler uc;
        public kullanici_dogrulama(Context datab, Grid x, Fatura ıslem, musteri_islemler uc)
        {
            InitializeComponent();
            db = datab;
            this.x = x;
            this.ıslem = ıslem;
            this.uc = uc;
        }
        private void satisuc_login_username_tb_GotKeyboardFocus(object sender, KeyboardFocusChangedEventArgs e)
        {
            login_page_user.Text = "";
            login_page_user.Foreground = new SolidColorBrush(Colors.Black);
            login_page_user.TextAlignment = TextAlignment.Left;
            login_page_user.FontSize = 18;
            login_page_user.Height = 35;
        }

        private void satisuc_login_username_tb_LostKeyboardFocus(object sender, KeyboardFocusChangedEventArgs e)
        {
            if (login_page_user.Text == "" || login_page_user.Text == "Kullanıcı Adı Veya Parola Hatalı")

            {
                login_page_user.Text = "Kullanıcı Adı...";
                login_page_user.Foreground = new SolidColorBrush(Colors.LightGray);
                login_page_user.TextAlignment = TextAlignment.Center;
                login_page_user.FontSize = 18;
            }
        }
        private void satisuc_login_pass_tb_GotKeyboardFocus(object sender, KeyboardFocusChangedEventArgs e)
        {
            login_page_pass.Text = "";
            login_page_pass.Foreground = new SolidColorBrush(Colors.Black);
            login_page_pass.TextAlignment = TextAlignment.Left;
            login_page_pass.FontSize = 18;
            login_page_pass.Height = 35;
        }
        private void satisuc_login_pass_tb_LostKeyboardFocus(object sender, KeyboardFocusChangedEventArgs e)
        {
            if (login_page_pass.Text == "" || login_page_pass.Text == "Kullanıcı Adı Veya Parola Hatalı")
            {
                login_page_pass.Text = "Şifre...";
                login_page_pass.Foreground = new SolidColorBrush(Colors.LightGray);
                login_page_pass.TextAlignment = TextAlignment.Center;
                login_page_pass.FontSize = 18;

            }
        }
        private void login_btn_Click(object sender, RoutedEventArgs e)
        {
            var q = from p in db.Kullanıcılar where p.KullaniciAdi == login_page_user.Text && p.pass == login_page_pass.Text select p;
            if (q.Any())
            {
                var qqq = from fatura in db.Islemler.Where(x => x.tarih.CompareTo(ıslem.Tarih) == 0) select fatura;
                var qq = db.Islemler.Find(qqq.First().IslemId);
                var m = db.Musteriler.Find(ıslem.MusteriId.MusteriId);
                m.Borc = m.Borc - ıslem.Tutar;
                ıslem = db.Fatura.Find(ıslem.FaturaId);
                db.Fatura.Remove(ıslem);
                var qs = from detay in db.Fatura_Detay.Where(x => x.FaturaId.FaturaId == ıslem.FaturaId)
                         select new
                         {
                             detay.FaturaDetayID,
                             detay.miktar,
                             detay.FaturaId,
                             detay.UrunlerId,
                         };
                qs.ToList().ForEach(x =>
                {
                    var temp = db.Fatura_Detay.Find(x.FaturaId.FaturaId);
                    db.Fatura_Detay.Remove(temp);
                });
                db.Islemler.Remove(qq);
                var qw = from detay in db.Islem_Detay.Where(x => x.IslemId.IslemId == qq.IslemId)
                         select new
                         {
                             detay.ID,
                             detay.IslemId,
                             detay.Miktar,
                             detay.UrunID
                         };
                qw.ToList().ForEach(x =>
                {
                    var temp = db.Islem_Detay.Find(x.ID);

                    var temp1 = db.Urunler.Find(x.UrunID.UrunID);

                    temp1.Stok += x.Miktar;

                    db.Islem_Detay.Remove(temp);

                });

                db.SaveChanges();
                MessageBox.Show("İşlem Kaydı Silindi");
                uc.acilis();
                Class1.uc_ekle(x, uc);
            }
            else
            {

                login_page_user.Text = "Kullanıcı Adı Veya Parola Hatalı";
                login_page_user.Foreground = new SolidColorBrush(Colors.Red);
                login_page_user.FontSize = 14;
                login_page_user.Height = 50;

                login_page_pass.Text = "Kullanıcı Adı Veya Parola Hatalı";
                login_page_pass.Foreground = new SolidColorBrush(Colors.Red);
                login_page_pass.FontSize = 14;
                login_page_pass.Height = 50;
            }
        }
    }
}