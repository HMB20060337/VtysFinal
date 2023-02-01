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
using WpfApp1.Entity;

namespace WpfApp1.UC
{
    /// <summary>
    /// musteriler_uc.xaml etkileşim mantığı
    /// </summary>
    public partial class musteriler_uc : UserControl
    {
        private Context db;
        public musteriler_uc(Context datab)
        {
            InitializeComponent();
            this.db = datab;
        }

        private void acilis()
        {
            var q = from musteri in db.Musteriler select new { musteri.MusteriId, musteri.MusteriSoyadi, musteri.MusteriAdi, musteri.Telefon, musteri.Borc };
            musteriler_tablo.ItemsSource = q.ToList();
        }
    }
}
