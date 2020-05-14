using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clinics.Class
{
    class ConvertDate
    {
        public string TODate(string Date)
        {

            string yyyy = Date.Substring(6, 4);
            string dd = Date.Substring(0, 2);
            string MM = Date.Substring(3, 2);

            DateTime d2 = Convert.ToDateTime(yyyy + "-" + MM + "-" + dd);
            return d2.ToString("yyyy-MM-dd");
        }
    }
}
