using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KellysBookStore.Model
{
    public class MonthlySales
    {
        public string BookTitle { get; set; }
        public int Month { get; set; }
        public int QuantitySold { get; set; }

        public MonthlySales(string bookTitle, int month, int quantitySold)
        {
            BookTitle = bookTitle;
            Month = month;
            QuantitySold = quantitySold;
        }
    }
}
