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
    /// musteri_ekle.xaml etkileşim mantığı
    /// </summary>
    public partial class musteri_ekle : UserControl
    {
        private Context db;
        private Grid x;
        public musteri_ekle(Context datab, Grid x)
        {
            InitializeComponent();
            this.db = datab;
            this.x = x;
        }

        private void name_GotKeyboardFocus(object sender, KeyboardFocusChangedEventArgs e)
        {
            name.Text = "";
            name.Foreground = new SolidColorBrush(Colors.Black);
            name.TextAlignment = TextAlignment.Left;
            name.FontSize = 18;
            name.Height = 35;

        }

        private void name_LostKeyboardFocus(object sender, KeyboardFocusChangedEventArgs e)
        {
            if (name.Text == "" || name.Text == "Bu Alan Boş Bırakılamaz")
            {
                name.Text = "İsim...";
                name.Foreground = new SolidColorBrush(Colors.LightGray);
                name.TextAlignment = TextAlignment.Center;
                name.FontSize = 18;
            }

        }

        private void surname_GotKeyboardFocus(object sender, KeyboardFocusChangedEventArgs e)
        {
            surname.Text = "";
            surname.Foreground = new SolidColorBrush(Colors.Black);
            surname.TextAlignment = TextAlignment.Left;
            surname.FontSize = 18;
            surname.Height = 35;
        }

        private void surname_LostKeyboardFocus(object sender, KeyboardFocusChangedEventArgs e)
        {
            if (surname.Text == "" || surname.Text == "Bu Alan Boş Bırakılamaz")
            {
                surname.Text = "Soy İsim...";
                surname.Foreground = new SolidColorBrush(Colors.LightGray);
                surname.TextAlignment = TextAlignment.Center;
                surname.FontSize = 18;
            }
        }

        private void phone_GotKeyboardFocus(object sender, KeyboardFocusChangedEventArgs e)
        {
            phone.Text = "";
            phone.Foreground = new SolidColorBrush(Colors.Black);
            phone.TextAlignment = TextAlignment.Left;
            phone.FontSize = 18;
            phone.Height = 35;
        }

        private void phone_LostKeyboardFocus(object sender, KeyboardFocusChangedEventArgs e)
        {
            if (phone.Text == "" || phone.Text == "Bu Alan Boş Bırakılamaz")
            {
                phone.Text = "Telefon Numarası...";
                phone.Foreground = new SolidColorBrush(Colors.LightGray);
                phone.TextAlignment = TextAlignment.Center;
                phone.FontSize = 18;
            }
        }
        private void add_urun_btn_Click(object sender, RoutedEventArgs e)
        {
            if (name.Text == "İsim..." || name.Text == "" || name.Text == "Bu Alan Boş Bırakılamaz" || surname.Text == "Soy İsim..." || surname.Text == ""|| surname.Text == "Bu Alan Boş Bırakılamaz" || phone.Text == "Telefon Numarası..." || phone.Text == ""|| phone.Text == "Bu Alan Boş Bırakılamaz")
            {
                if (phone.Text == "Telefon Numarası..." || phone.Text == "") {phone.Height=55; phone.Text = "Bu Alan Boş Bırakılamaz"; phone.Foreground = new SolidColorBrush(Colors.Red); }
                if (surname.Text == "Soy İsim..." || surname.Text == "") {surname.Height = 55; surname.Text = "Bu Alan Boş Bırakılamaz"; surname.Foreground = new SolidColorBrush(Colors.Red);}
                if (name.Text == "İsim..." || name.Text == "") {name.Height = 55; name.Text = "Bu Alan Boş Bırakılamaz"; name.Foreground = new SolidColorBrush(Colors.Red);}

            }
            else
            {
                Musteriler temp = new Musteriler { 
                    MusteriAdi=name.Text,
                    MusteriSoyadi=surname.Text,
                    Telefon=phone.Text,
                };
                db.Musteriler.Add(temp);
                db.SaveChanges();
                MessageBox.Show("Müşteri Kaydı Oluşturuldu");
                Class1.uc_ekle(x, new musteriler_uc(db, x));
            }

        }
    }
}