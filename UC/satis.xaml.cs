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
        private Kullanıcılar kullanici;
        private Context db;
        public satis(Kullanıcılar a,Context datab)
        {
            InitializeComponent();
            kullanici = a;
            db = datab;
        }
        
        public static ObservableCollection<Urunler> sepet = new ObservableCollection<Urunler>();
        public double toplam=0;
        private int temp = 0;
        public void ekle_btn_Click(object sender, RoutedEventArgs e)
        {
            SepetList list = new SepetList(barkod_text.Text,db);
            satis_urunler_tablo.ItemsSource = sepet;

            list.ForEach(x =>
            {
                if(sepet.Count> 0) { 
                sepet.ToList().ForEach(y => {
                    if(y.UrunID==x.UrunID)
                    {
                        temp++;
                        y.Stok += 1;

                        
                    }
                    else if(y==sepet.Last() && temp==0)
                    {
                        sepet.Add(x);
                    }
                });
                }
                else
                {
                    sepet.Add(x);
                }

            });

            toplamlabel.Text = toplam.ToString();
                          
            barkod_text.Text = "";           
            satis_urunler_tablo.Items.Refresh();
        }

        class SepetList : List<Urunler>
        {
            public  SepetList(string str,Context db)
            {   
                var eklenecek = from urun in db.Urunler.Where(x => x.Barkod == str) select new { urun.UrunID, urun.Barkod, urun.UrunAdi, urun.SatisFiyati };
                eklenecek.ToList().ForEach(x =>
                {
                    if (this.Count == 0)
                    {
                        this.Add(new Urunler()
                        {
                            UrunID = x.UrunID,
                            Barkod = x.Barkod,
                            UrunAdi = x.UrunAdi,
                            Stok = 1,
                            SatisFiyati = x.SatisFiyati,
                        });
                    }
                });
            }
        }
        private void pesin_satis_btn_Click(object sender, RoutedEventArgs e)
        {
            Islemler ıslem = new Islemler
            {
                KullanıcıId = kullanici,
                tarih = DateTime.Now,
            };
            db.Islemler.Add(ıslem);
            sepet.ToList().ForEach(x => {
                Islem_Detay ıslem_Detay = new Islem_Detay
                {
                    Islemler = ıslem,
                    Urunler = x
                };
                db.Islem_Detay.Add(ıslem_Detay);
            });
            sepet.Clear();
            toplamlabel.Text = 0.ToString();
            db.SaveChanges();
        }      

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            sepet.RemoveAt(satis_urunler_tablo.SelectedIndex);
        }
    }
}
