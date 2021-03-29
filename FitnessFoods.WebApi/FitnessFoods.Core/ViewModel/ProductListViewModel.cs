using FitnessFoods.Core.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitnessFoods.Core.ViewModel
{
    public class ProductListViewModel
    {
        public int Page_Size { get; set; }
        public int Page_Number { get; set; }
        public List<Product> Items { get; set; }
    }
}
