using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VendaPlena.Domain.v1.Extensions
{
    public class Date
    {
        public static bool ValidadeDate(string date)
        {
            DateTime temp;
            if (DateTime.TryParse(date, out temp))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
