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
    /// ıslemler.xaml etkileşim mantığı
    /// </summary>
    public partial class ıslemler : UserControl
    {
        private Context db;
        private Grid x;
        private ObservableCollection<Islemler> a = new ObservableCollection<Islemler>();
        public ıslemler qqq;
        public ıslemler(Context db,Grid x)
        {
            InitializeComponent();
            this.db = db;
            this.x = x;
            acilis();
        }

        private void acilis()
        {

            var q = from ıslem in db.Islemler select new { ıslem.IslemId,ıslem.tarih,ıslem.Tutar,ıslem.OdemeYontemi,ıslem.KullanıcıId};
            q.ToList().ForEach(x => 
            {
                a.Add(new Islemler
                {IslemId= x.IslemId,
                tarih= x.tarih,
                Tutar= x.Tutar,
                OdemeYontemi= x.OdemeYontemi,
                KullanıcıId = x.KullanıcıId
                });
            });
            islemlertablo.ItemsSource = a;
        }

        private void detay_Click(object sender, RoutedEventArgs e)
        {
            detay uc = new detay(db, a[islemlertablo.SelectedIndex], x);
            uc.uc = qqq;
            Class1.uc_ekle(x, uc);

        }

        private void sil_Click(object sender, RoutedEventArgs e)
        {
            Class1.uc_ekle(x, new dogrulama(db, x, a[islemlertablo.SelectedIndex]));
        }
    }
}
