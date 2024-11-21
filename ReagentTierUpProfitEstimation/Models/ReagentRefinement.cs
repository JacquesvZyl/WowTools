using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReagentTierUpProfitEstimation.Models
{
    public class ItemGroups
    {
        public List<Items>? AllItems { get; set; }
    }

    public class Items
    {
        public List<Item>? ItemList { get; set; }
    }
    public class Item
    {
        public double Price { get; set; }
        public string Name { get; set; }
        public string Tier { get; set; }

        public static implicit operator int(Item? v)
        {
            throw new NotImplementedException();
        }
    }
}
