﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp1.Entity
{
    public class Musteriler
    {
        [Key] public int MusteriId { get; set; }

        public string MusteriAdi { get; set; }
        public string MusteriSoyadi { get; set; }

        public string Telefon { get; set; }

        public double Borc { get; set; }
        
    }
}
