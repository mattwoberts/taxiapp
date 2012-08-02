﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace TaxiApp
{
    public class TaxiRequest : ApiController
    {
        // GET api/<controller>
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<controller>/5
        public string Get(decimal lat, decimal lon, string name, string mobileNumber)
        {
            SignalR.GlobalHost.ConnectionManager.GetHubContext<TaxiHub>().Clients
                .requestTaxi(new { lat, lon, name, mobileNumber });

            return Guid.NewGuid().ToString();
        }

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