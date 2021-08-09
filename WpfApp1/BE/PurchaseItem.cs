using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public class PurchaseItem
    {
        public string Id { get; set; }
        public string UserId { get; set; }
        public string ItemId { get; set; }
        public DateTime Date { get; set; }
        public string Count { get; set; }

    }
}
