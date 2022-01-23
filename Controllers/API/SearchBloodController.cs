using BloodDoner.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace BloodDoner.Controllers.API
{
    public class SearchBloodController : ApiController
    {
        public IHttpActionResult Get(string g )
        {
            Blood b = new Blood() ;
            b.blood = g;
            DonorDBHandler d = new DonorDBHandler();
            List<Donor> donor = d.displayblood(b);
            //if (donor.Count == 0) return NotFound();
           // else
            //{
                IHttpActionResult data = Ok(donor);
                return data;
            //}
        }
    }
}
