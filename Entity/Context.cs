using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfApp1.UC;

namespace WpfApp1.Entity
{
    public class Context : DbContext
    {
        public Context() : base("MarketDB")
        { }
    public DbSet<Urunler> Urunler { get; set; }
        public DbSet<Kullanıcılar> Kullanıcılar { get; set; }
        public DbSet<Fatura> Fatura { get; set; }
        public DbSet<Musteriler> Musteriler { get; set; }
        public DbSet<Fatura_Detay> Fatura_Detay { get; set; }
        public DbSet<Stok_Giris> Stok_Giris { get; set; }
        public DbSet<Firmalar> Firmalar { get; set; }
        public DbSet<Stok_Giris_Detay> Stok_Giris_Detay { get; set; }

        public DbSet<Islemler> Islemler { get; set; }

        public DbSet<Islem_Detay> Islem_Detay { get; set; }

        public DbSet<Musteri_Odeme> Musteri_Odemes { get; set; }

        public DbSet<Firma_Odeme> Firma_Odemes { get; set; }

    }
}