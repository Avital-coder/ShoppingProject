using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public class Item
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public float Price { get; set; }
        public string ShopName { get; set; }
        public string BranchName { get; set; }
        public string ImagePath { get; set; }

        public override string ToString()
        {
            return Name;
        }
    }
}
