using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitnessFoods.Core.ViewModel
{
    public class ProductList
    {
        public int Page_Size { get; set; }
        public int Page_Number { get; set; }
        public List<ProductDataBase> Items { get; set; }
    }
}
