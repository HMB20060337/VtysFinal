﻿using System;
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

namespace WpfApp1.UC.rapor_screens
{
    /// <summary>
    /// stok_giris_detay.xaml etkileşim mantığı
    /// </summary>
    public partial class stok_giris_detay : UserControl
    {
        private Context db;
        private Stok_Giris sGiris;
        private Grid x;
        private ObservableCollection<Urunler> urunlers = new ObservableCollection<Urunler>();
        stok_girisler qqq;
        public stok_giris_detay(Context db, Stok_Giris stok_Giris, Grid x,stok_girisler qqq)
        {
            InitializeComponent();
            this.db = db;
            this.x = x;
            this.sGiris = stok_Giris;
            this.qqq = qqq;
            acilis();
        }
        private void acilis()
        {
            kullanici_label.Content = sGiris.FirmaId.FirmaAdi;
            tarih_label.Content = sGiris.tarih.ToString();
            toplam_tutar.Content = sGiris.tutar.ToString();

            var qq = from detay in db.Stok_Giris_Detay.Where(x => x.GirisId.Id == sGiris.Id)
                     select new
                     {
                         detay.UrunId,
                         detay.sayi
                     };

            qq.ToList().ForEach(x =>
            {

                urunlers.Add(new Urunler
                {
                    UrunID = x.UrunId.UrunID,
                    UrunAdi = x.UrunId.UrunAdi,
                    Barkod = x.UrunId.Barkod,
                    Stok = x.sayi,
                    SatisFiyati = x.UrunId.AlisFiyati,
                    AlisFiyati = x.sayi * x.UrunId.AlisFiyati
                });
            });
            satis_urunler_tablo.ItemsSource = urunlers;
        }

        private void kapat_Click(object sender, RoutedEventArgs e)
        {
            Class1.uc_ekle(x, qqq);
        }
    }
}