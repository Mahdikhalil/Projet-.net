using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Conventions
{
    public class KeyConvetion:Convention
    {
        public KeyConvetion()
        {
            Properties<int>()
                .Where(p => p.Name.EndsWith("key"))
                .Configure(p => p.IsKey());
        }
    }
}
