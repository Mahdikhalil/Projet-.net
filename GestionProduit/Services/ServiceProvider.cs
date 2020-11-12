using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class ServiceProvider
    {
        List<Provider> lstp = new List<Provider>();
        public IEnumerable<string> GetProviderByName(string name)
        {
            return from pr in lstp
                   where pr.UserName.Contains(name)
                   select pr.Password;   
        }

        public IEnumerable<string> GetProviderByNameLambda(string name)
        {
            return lstp.Where(p => p.UserName.Contains(name)).Select(p => p.Password);
        }

        public Provider GetFirstProviderByName(string name)
        {
            var p = from pr in lstp
                    where pr.UserName.Contains(name)
                    select pr;
            return p.FirstOrDefault();
        }

        public Provider GetFirstProviderByNameLambda(string name)
        {
            return lstp.Where(p => p.UserName.Contains(name)).FirstOrDefault();
        }


        public Provider GetProviderById(int id)
        {
            
            return (from pr in lstp
                   where pr.id ==id
                   select pr).First();
        }
        public Provider GetProviderByIdLambda(int id)
        {
            return lstp.Where(p => p.id == id).First();
        }




    }
}
