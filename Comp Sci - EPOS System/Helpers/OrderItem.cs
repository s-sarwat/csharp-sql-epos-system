using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Comp_Sci___EPOS_System.Helpers
{
    public class OrderItem
    {
        public string Name { get; set; }
        public int Qty { get; set; }        
        public decimal Price { get; set; }

        public bool IsSelectedForDeletion { get; set; }

        public override string ToString()
        {
            return Qty + " " + Name + " @ " + Price;
        }
    }
}