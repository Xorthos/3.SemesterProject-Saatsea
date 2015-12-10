using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Proxy.Models.AuthorizationModels;

namespace Proxy.ServiceGateway.Abstraction
{
    public abstract class ServiceGateway<T>
    {
        // this is here, because every class that now inheirits this class will have access to the endpoint.
        //protected static readonly string END_POINT = "http://movieshopapi.azurewebsites.net/api/";
        public static readonly string END_POINT = "http://localhost:2687/api/";
        protected LoggedInModel _loggedInModel;

        public ServiceGateway(LoggedInModel model)
        {
            _loggedInModel = model;
        }
        public abstract T Add(T item);
        public abstract IEnumerable<T> GetAll();
        public abstract T Get(int id);
        public abstract bool Update(T item);

        public abstract bool ChangeState(int id);

    }
}
