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
using System.Windows.Forms;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using WpfApp1.Class;
using WpfApp1.Entity;
using WpfApp1.UC.satis_screens;
using MessageBox = System.Windows.Forms.MessageBox;
using UserControl = System.Windows.Controls.UserControl;

namespace WpfApp1.UC
{
    /// <summary>
    /// satis.xaml etkileşim mantığı
    /// </summary>
    public partial class satis : UserControl
    {
        public Kullanıcılar kullanici;
        private Context db;
        private Grid x;
        public satis uc;
        public satis(Context datab,Grid x)
        {
            InitializeComponent();
            this.db = datab;
            this.x = x;
        }
        
        public ObservableCollection<Urunler> sepet = new ObservableCollection<Urunler>();
        public static ObservableCollection<Urunler> tmpsepet = new ObservableCollection<Urunler>();
        public double toplam=Convert.ToDouble(0);
        
        public void ekle_btn_Click(object sender, RoutedEventArgs e)
        {
            int temp = 0;
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
                        y.AlisFiyati = y.AlisFiyati + y.SatisFiyati;
                        toplam = toplam + y.SatisFiyati;        
                        
                    }
                    else if(y==sepet.Last() && temp==0)
                    {
                        sepet.Add(x);
                        toplam = toplam + x.SatisFiyati;
                    }
                });
                }
                else
                {
                    sepet.Add(x);
                    toplam = toplam + x.SatisFiyati;
                }

                if (sepet.Count > 0)
                {
                    tmpsepet.ToList().ForEach(y => {
                        if (y.UrunID == x.UrunID)
                        {
                            temp++;
                            y.Stok += 1;

                        }
                        else if (y == sepet.Last() && temp == 0)
                        {
                            tmpsepet.Add(x);
                        }
                    });
                }
                else
                {
                    sepet.Add(x);
                    toplam = toplam + x.SatisFiyati;
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
                var eklenecek = from urun in db.Urunler.Where(x => x.Barkod == str) select new { urun.UrunID, urun.Barkod, urun.UrunAdi, urun.SatisFiyati,urun.Stok};
                eklenecek.ToList().ForEach(x =>
                {
                    if (x.Stok != 0)
                    {
                        this.Add(new Urunler()
                        {
                            UrunID = x.UrunID,
                            Barkod = x.Barkod,
                            UrunAdi = x.UrunAdi,
                            Stok = 1,
                            SatisFiyati = x.SatisFiyati,
                            AlisFiyati = x.SatisFiyati,
                        });
                        var qq = db.Urunler.Find(x.UrunID);
                        qq.Stok = qq.Stok - 1;
                        if(qq.Stok==0) MessageBox.Show(x.UrunAdi + " " + "adlı ürün tükenmiştir.");
                        db.SaveChanges();
                    }
                    else
                    {
                        MessageBox.Show(x.UrunAdi + " " + "adlı ürün tükenmiştir.");
                    }
                                          
                });
            }
        }
        private void nakit_Click(object sender, RoutedEventArgs e)
        {
            if (toplam > 0)
            {
                Islemler ıslem = new Islemler
                {
                    KullanıcıId = kullanici,
                    tarih = DateTime.Now,
                    Tutar = toplam,
                    OdemeYontemi = "Nakit"
                };
                db.Islemler.Add(ıslem);
                db.SaveChanges();
                sepet.ToList().ForEach(x => {
                    Islem_Detay ıslem_Detay = new Islem_Detay
                    {
                        IslemId = ıslem,
                        UrunID = db.Urunler.Find(x.UrunID),
                        Miktar = x.Stok

                    };
                    db.Islem_Detay.Add(ıslem_Detay);
                });
                sepet.Clear();
                toplam= 0;
                toplamlabel.Text = 0.ToString();
                db.SaveChanges();
            }
        }      

        private void Button_Click(object sender, RoutedEventArgs e)
        {               
            sepet.ToList().ForEach(x =>
            {
                var qq = db.Urunler.Find(x.UrunID);
                qq.Stok = qq.Stok + x.Stok;
                db.SaveChanges();
            });
            toplam = toplam - sepet[satis_urunler_tablo.SelectedIndex].AlisFiyati;
            sepet.RemoveAt(satis_urunler_tablo.SelectedIndex);
            toplamlabel.Text=toplam.ToString();
        }

        private void pesin_satis_btn_Click(object sender, RoutedEventArgs e)
        {
            if (toplam > 0) {
                Islemler ıslem = new Islemler
                {
                    KullanıcıId = kullanici,
                    tarih = DateTime.Now,
                    Tutar = toplam,
                    OdemeYontemi = "Kart"
                };
                db.Islemler.Add(ıslem);
                db.SaveChanges();
                sepet.ToList().ForEach(x => {
                    Islem_Detay ıslem_Detay = new Islem_Detay
                    {
                        IslemId = ıslem,
                        UrunID = db.Urunler.Find(x.UrunID),
                        Miktar = x.Stok

                    };
                    db.Islem_Detay.Add(ıslem_Detay);
                });
                sepet.Clear();
                toplam = Convert.ToDouble(0);
                toplamlabel.Text = toplam.ToString();
                db.SaveChanges();
            }          
        }

        private void mus_satis_btn_Click(object sender, RoutedEventArgs e)
        {
            if (toplam > 0)
            {
                Class1.uc_ekle(x, new musteri_satis(db, x, sepet, kullanici,toplam,uc));
            }
        }
    }
}
