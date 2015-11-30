using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using DAL.Facade.Abstraction;
using DAL.Facade.Implementation;
using DAL.Models;
using DAL.Repositories.Abstraction;

namespace CustomerAPI.Controllers
{
    public class LogController : ApiController
    {
        private IFacade facade;
        private IRepository<Log> repository;
         
        /// <summary>
        /// Constructor:
        /// </summary>
        public LogController()
        {
            facade = new Facade();
            repository = facade.GetLogRepository();
        }

        /// <summary>
        /// Get all logs
        /// </summary>
        /// <returns>a list of all the logs</returns>
        public HttpResponseMessage GetAll()
        {
            var response = Request.CreateResponse(HttpStatusCode.OK, repository.GetAll());
            return response;
        }

        /// <summary>
        /// Get a specific log
        /// </summary>
        /// <param name="id">the id of the log</param>
        /// <returns>the specific</returns>
        public HttpResponseMessage Get(int id)
        {
            var response = Request.CreateResponse(HttpStatusCode.OK, repository.Get(id));
            return response;
        }

        /// <summary>
        /// Add a log to the database
        /// </summary>
        /// <param name="log">the log to be added</param>
        /// <returns>the log with the correct </returns>
        public HttpResponseMessage Add(Log log)
        {
            var response = Request.CreateResponse(HttpStatusCode.Created, repository.Add(log));
            return response;
        }

        /// <summary>
        /// Updates a log.
        /// </summary>
        /// <param name="log">the log to updated</param>
        /// <returns>true if the log was updated</returns>
        public HttpResponseMessage Update(Log log)
        {
            HttpResponseMessage response;

            if (repository.Update(log))
            {
                response = Request.CreateResponse(HttpStatusCode.OK);
            }
            else
            {
                response = Request.CreateResponse(HttpStatusCode.Conflict);
            }

            return response;
        }
    }
}
