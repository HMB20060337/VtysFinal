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
using WpfApp1.Entity;

namespace WpfApp1.UC
{
    /// <summary>
    /// satis.xaml etkileşim mantığı
    /// </summary>
    public partial class satis : UserControl
    {
        public satis()
        {
            InitializeComponent();
            
        }
        public static ObservableCollection<Urunler> sepet = new ObservableCollection<Urunler>();
        public double toplam=0;
        public void ekle_btn_Click(object sender, RoutedEventArgs e)
        {
            SepetList list = new SepetList(barkod_text.Text);

            list.ForEach(x =>
            {
                if (sepet.Contains(x) == false ) {
                    sepet.Add(x); }
                else
                {
                    sepet[sepet.IndexOf(x)].Stok = sepet[sepet.IndexOf(x)].Stok + 1;
                }
                toplam = toplam + x.SatisFiyati;
               

            });
            toplamlabel.Text = toplam.ToString();
            satis_urunler_tablo.ItemsSource = sepet;
        }

        class SepetList : List<Urunler>
        {
            public  SepetList(string str)
            {   

                int a = Convert.ToInt32(str);

                Context db = new Context();
                var eklenecek = from urun in db.Urunler.Where(x => x.Barkod == a) select new { urun.UrunID, urun.Barkod, urun.UrunAdi, urun.SatisFiyati };
                eklenecek.ToList().ForEach(x =>
                {
                    this.Add(new Urunler()
                    {
                        UrunID = x.UrunID,
                        Barkod = x.Barkod,
                        UrunAdi = x.UrunAdi,
                        Stok = 1,
                        SatisFiyati = x.SatisFiyati,
                    });
                });
            }
        }
    }
}
