using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using SignalR;

namespace TaxiApp
{
    public class TaxiController : ApiController
    {
        // GET api/<controller>
        public string Get()
        {
            decimal lat = GetFromQueryString<decimal>("lat", (decimal) 54.048354);
            decimal lon = GetFromQueryString<decimal>("lon", (decimal) -2.800784);
            string name  = GetFromQueryString<string>("name", "Not Known");
            string mobileNumber = GetFromQueryString<string>("mobile", "Not Known");

            var hub = SignalR.GlobalHost.ConnectionManager.GetHubContext<TaxiHub>();
            hub.Clients.requestTaxi(new { lat, lon, name, mobileNumber });

            return Guid.NewGuid().ToString();
        }

        private T GetFromQueryString<T>(string queryStringName, T defaultValue)
        {
            T result = defaultValue;

            if (HttpContext.Current != null && !String.IsNullOrEmpty(HttpContext.Current.Request.QueryString[queryStringName]))
            {
                string value =  HttpContext.Current.Request.QueryString[queryStringName];
                try
                {
                    result = (T) Convert.ChangeType(value, typeof(T));
                }
                finally
                {
                    result = defaultValue;
                }

            }
            return result;
        }

        // GET api/<controller>/5
 
        // POST api/<controller>
        public void Post(decimal lat, decimal lon, string name, string mobileNumber)
        {

        }

        // PUT api/<controller>/5
        public void Put(int id, string value)
        {
        }

        // DELETE api/<controller>/5
        public void Delete(int id)
        {
        }
    }
}