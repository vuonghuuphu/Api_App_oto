using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api_AppAuto.Models
{
    public class Cart
    {
        public int Id { set; get; }
        public int Id_product { set; get; }
        public int Id_user { set; get; }
        public string Nameproduct { set; get; }
        public string Imgproduct { set; get; }
        public int Price { set; get; }
        public int Quantity { set; get; }
    }
}
