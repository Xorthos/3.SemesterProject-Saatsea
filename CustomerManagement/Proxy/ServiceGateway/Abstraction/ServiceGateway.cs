using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proxy.ServiceGateway.Abstraction
{
    public abstract class ServiceGateway<T>
    {
        // this is here, because every class that now inheirits this class will have access to the endpoint.
        //protected static readonly string END_POINT = "http://movieshopapi.azurewebsites.net/api/";
        protected static readonly string END_POINT = "http://localhost:21748/api/";

        public abstract T Add(T item);
        public abstract IEnumerable<T> GetAll();
        public abstract T Get(int id);
        public abstract bool Update(T item);
    }
}
