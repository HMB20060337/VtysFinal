using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Core.Objects;
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
    /// dogrulama.xaml etkileşim mantığı
    /// </summary>
    public partial class dogrulama : UserControl
    {
        private Context db;
        private Grid x;
        private Islemler ıslem;
        public dogrulama(Context datab, Grid x, Islemler ıslem)
        {
            InitializeComponent();
            db = datab;
            this.x = x;
            this.ıslem = ıslem;
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

        [Obsolete]
        private void login_btn_Click(object sender, RoutedEventArgs e)
        {
            var q = from p in db.Kullanıcılar where p.KullaniciAdi == login_page_user.Text && p.pass == login_page_pass.Text select p;
            if (q.Any())
            {
                ıslem = db.Islemler.Find(ıslem.IslemId); 


               if(ıslem.OdemeYontemi=="Müşteriye Satış")
                {           
                    var qqq = from fatura in db.Fatura.Where(x=> x.Tarih.CompareTo(ıslem.tarih)==0) select fatura;
                    var qq = db.Fatura.Find(qqq.First().FaturaId);
                    var m = db.Musteriler.Find(qq.MusteriId.MusteriId);
                    m.Borc = m.Borc - qq.Tutar;
                    db.Fatura.Remove(qq);
                    var qs = from detay in db.Fatura_Detay.Where(x => x.FaturaId.FaturaId == qq.FaturaId)
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

                    db.Islemler.Remove(ıslem);
                    var qw = from detay in db.Islem_Detay.Where(x => x.IslemId.IslemId == ıslem.IslemId)
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
                }
                else
                {
                    db.Islemler.Remove(ıslem);
                    var qw = from detay in db.Islem_Detay.Where(x => x.IslemId.IslemId == ıslem.IslemId)
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
                }
                db.SaveChanges();
                MessageBox.Show("İşlem Kaydı Silindi");
                Class1.uc_ekle(x, new ıslemler(db, x));
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
