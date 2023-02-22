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
using WpfApp1.UC.firmalar_screens;

namespace WpfApp1.UC
{
    /// <summary>
    /// firmalar.xaml etkileşim mantığı
    /// </summary>
    public partial class firmalar : UserControl
    {
        private Context db;
        private Grid x;
        borc_ode qqq;
        firma_detay qqa;
        public firmalar(Context db,Grid x)
        {
            InitializeComponent();
            this.db = db;
            this.x = x;
            qqq = new borc_ode(db,x);
            qqq.grd = qqq;
            acilis();
        }

        private ObservableCollection<Firmalar> a = new ObservableCollection<Firmalar>();
        private void acilis()
        {
            var q = from firma in db.Firmalar select new { firma.FirmaId, firma.FirmaAdi, firma.Borc };
            q.ToList().ForEach(x =>
            {
                a.Add(new Firmalar
                {
                    FirmaId = x.FirmaId,
                    FirmaAdi = x.FirmaAdi,
                    Borc = x.Borc
                });
            });
            firmalar_tablo.ItemsSource = a;
        }

        private void borc_Click(object sender, RoutedEventArgs e)
        {
            Class1.uc_ekle(x,qqq);
        }

        private void Detay_Click(object sender, RoutedEventArgs e)
        {
            qqa = new firma_detay(db, x, a[firmalar_tablo.SelectedIndex]);
            qqa.qqq = qqa;
            Class1.uc_ekle(x, qqa);
        }
    }
}