using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clinics
{
    class msgShow
    {
        public void Alert(string msg, Form_Alert.enumType type)
        {
            Form_Alert frm = new Form_Alert();
            frm.showAlert(msg, type);

        }
    }
}
