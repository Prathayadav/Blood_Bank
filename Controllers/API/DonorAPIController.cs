using BloodDoner.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace BloodDoner.Controllers.API
{
    public class DonorAPIController : ApiController
    {
        // GET: api/DonorAPI
        public IHttpActionResult Get()
        {
            DonorDBHandler d = new DonorDBHandler();
            List<Donor> donors=d.getlistofdonor();
            if (donors.Count == 0) return NotFound();
            IHttpActionResult data = Ok(donors);
            return data;
        }

        // GET: api/DonorAPI/5
        public IHttpActionResult Get(int id)
        {

            DonorDBHandler d = new DonorDBHandler();
            Donor donor = d.viewEdit(id);
            if (donor==null) return NotFound();
            IHttpActionResult data = Ok(donor);
            return data;
        }
        

        // POST: api/DonorAPI
        public IHttpActionResult Post(Donor d)
        {
            DonorDBHandler obj = new DonorDBHandler();
           bool check = obj.createDonor(d);
            if (check== false) return NotFound();
           IHttpActionResult data = Ok();
            return data;

        }

        // PUT: api/DonorAPI/5
        public IHttpActionResult Put(Donor d)
        {
            DonorDBHandler obj = new DonorDBHandler();
            bool check = obj.editpost(d);
            if (check == false) return NotFound();
            IHttpActionResult data = Ok();
            return data;
        }

        // DELETE: api/DonorAPI/5
        public IHttpActionResult Delete(int id)
        {
            DonorDBHandler obj = new DonorDBHandler();
            bool check = obj.deletedonor(id);
            if (check == false) return NotFound();
            IHttpActionResult data = Ok();
            return data;
        }
        
    }
}
