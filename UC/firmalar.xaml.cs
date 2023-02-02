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
    /// firmalar.xaml etkileşim mantığı
    /// </summary>
    public partial class firmalar : UserControl
    {
        private Context db;
        private Grid x;
        public firmalar(Context db, Grid x)
        {
            InitializeComponent();
            this.db = db;
            this.x = x;
        }
        private void acilis()
        {
            var q = from firma in db.Firmalar select new { firma.FirmaId, firma.FirmaAdi, firma.Borc };
            firmalar_tablo.ItemsSource = q.ToList();
        }
    }
}