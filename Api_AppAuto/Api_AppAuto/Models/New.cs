using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api_AppAuto.Models
{
    public class New
    {
        public int id { set; get; }
        public string Img { set; get; }
        public string Name { set; get;}
        public string Title { set; get; }
        public string Body { set; get; }
        public DateTime Created_at { set; get; }

    }
}
