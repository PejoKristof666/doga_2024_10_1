using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace doga_2024_10_1
{
    public class bakery
    {
        public static List<bakery> bakerys = new List<bakery>();
        public int id { get; set; }
        public string name { get; set; }
        public int amount { get; set; }
        public int price { get; set; }
    }
}
