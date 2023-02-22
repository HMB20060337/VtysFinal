using Microsoft.VisualBasic;
using System;
using System.IO;
using System.Linq;
using System.Text.Json;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Markup;
using WpfApp1.Class;
using WpfApp1.Entity;

namespace WpfApp1.UC.urunler_uc_screens
{
    /// <summary>
    /// stok_giris_uc.xaml etkileşim mantığı
    /// </summary>
    public partial class stok_giris_uc : UserControl
    {
        private Microsoft.Win32.OpenFileDialog ofd = new Microsoft.Win32.OpenFileDialog() { Filter = "Text Files (*.txt)|*.txt" };
        private Context db;
        private Grid x;
        public stok_giris_uc(Context db,Grid x)
        {
            InitializeComponent();
            this.db = db;
            this.x = x;
        }

        private void secim_Click(object sender, RoutedEventArgs e)
        {
            var result = ofd.ShowDialog();
            if (result == false) return;
            secim.Content= Path.GetFileNameWithoutExtension(ofd.FileName)+".txt";
            secim.Width= (Path.GetFileNameWithoutExtension(ofd.FileName).Length+4) * 12;
        }

        private void onay_Click(object sender, RoutedEventArgs e)
        {
            if (ofd.FileName == "") return;
            JsonDocument doc = JsonDocument.Parse(File.ReadAllText(ofd.FileName));
            JsonElement root = doc.RootElement;

            Firmalar firma= new Firmalar();

            string fAdi = root[0].GetProperty("FirmaAdi").ToString();

            var query = from q in db.Firmalar where q.FirmaAdi == fAdi select q;          
            if (query.Any()) {
                var fId = query.First().FirmaId;
                var temp = db.Firmalar.Find(fId);
                int borc = Convert.ToInt32(root[0].GetProperty("Tutar").ToString());
                temp.Borc = temp.Borc + borc;
                firma= temp;
            }
            else { 
                Firmalar temp = new Firmalar
                {
                    FirmaAdi = root[0].GetProperty("FirmaAdi").ToString(),
                    Borc = Convert.ToInt32(root[0].GetProperty("Tutar").ToString())
                };
                db.Firmalar.Add(temp);
                firma = temp;
            }

            Stok_Giris stok_Giris = new Stok_Giris {
                tarih = DateTime.Now,
                tutar = Convert.ToInt32(root[0].GetProperty("Tutar").ToString()),
                FirmaId = firma
           };
            db.Stok_Giris.Add(stok_Giris);

            for(int i = 1; i < root.GetArrayLength(); i++)
            {
                var u = db.Urunler.Find(Convert.ToInt32(root[i].GetProperty("urunkod").ToString()));
                if (u == null ) {
                    string fiyat = Interaction.InputBox(root[i].GetProperty("urunadi").ToString()+"\nAdlı Ürün İçin Yeni Ürün Kaydı Oluşturuluyor.\nLütfen Ürün İçin Bir Satış Fiyatı Giriniz.\nAlış Fiyatı : "+ root[i].GetProperty("alisFiyati").ToString(), "Adınızı Giriniz.", " ", 0, 0);
                    u = new Urunler {
                        UrunAdi = root[i].GetProperty("urunadi").ToString(),
                        AlisFiyati = Convert.ToInt32(root[i].GetProperty("alisFiyati").ToString()),
                        SatisFiyati = double.Parse(fiyat),
                        Barkod = root[i].GetProperty("barkod").ToString(),
                        Stok = 0,                   
                    }; }                
                              
                db.Stok_Giris_Detay
                    .Add(new Stok_Giris_Detay 
                    {
                        UrunId=u,
                        GirisId= stok_Giris,
                        sayi = Convert.ToInt32(root[i].GetProperty("miktar").ToString())               
                    });
                int alisFiyati = Convert.ToInt32(root[i].GetProperty("alisFiyati").ToString());
                u.AlisFiyati = alisFiyati;
                int stok = Convert.ToInt32(root[i].GetProperty("miktar").ToString());
                u.Stok = u.Stok + stok;
            }
            db.SaveChanges();
            MessageBox.Show("Stok Girişi Yapıldı.");
            Class1.uc_ekle(x,new urunler(db,x));
        }  
    }
}
