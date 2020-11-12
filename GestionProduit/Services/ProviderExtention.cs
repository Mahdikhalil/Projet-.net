using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public static class ProviderExtention
    {
        public static void UpperName(this Provider p)
        {
            p.UserName = p.UserName.ToUpper();

        }

        public static void UpperString(this String s)
        {
            s = s.ToUpper();
        }

    }
}
