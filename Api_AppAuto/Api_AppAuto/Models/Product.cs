using System;
using System.Collections.Generic;

#nullable disable

namespace Api_AppAuto.Models
{
    public partial class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Img { get; set; }
        public string Content { get; set; }
        public int Price { get; set; }
        public int Quantity { get; set; }
        public int id_categories { get; set; }
        public int id_brand { get; set; }
    }
}
