using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace WpfApp1.Class
{
    internal class Class1
    {
        public static void uc_ekle(Grid grd, UserControl uc)
        {
            if (grd.Children.Count > 0)
                grd.Children.Clear();

            grd.Children.Add(uc);
        }
    }
}
