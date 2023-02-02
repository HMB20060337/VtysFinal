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
    /// musteri_sil.xaml etkileşim mantığı
    /// </summary>
    public partial class musteri_sil : UserControl
    {

        List<Musteriler> b = new List<Musteriler>();
        private Context db;
        private Grid x;
        public musteri_sil(Context db, Grid x)
        {
            InitializeComponent();
            this.db = db;
            this.x = x;
            acilis();
        }

        private void acilis()
        {
            var q = from musteri in db.Musteriler select new { musteri.MusteriId, musteri.MusteriAdi, musteri.MusteriSoyadi, };
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

        private void musteri_sil_btn_Click(object sender, RoutedEventArgs e)
        {
            var silinecek = db.Musteriler.Find(b[combo.SelectedIndex].MusteriId);
            db.Musteriler.Remove(silinecek);
            db.SaveChanges();
            MessageBox.Show("Kayıt Silindi");
            Class1.uc_ekle(x, new musteriler_uc(db,x));
        }
    }
}
