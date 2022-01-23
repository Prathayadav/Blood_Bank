using BloodDoner.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace BloodDoner.Controllers
{
    public class RecieverAPIController : ApiController
    {
        // GET: api/RecieverAPI
        public IHttpActionResult Get()
        {
           List<Receiver> listReciever= new ReceiverDBHandler().ViewReceivers();
            if (listReciever.Count == 0) return NotFound();
            IHttpActionResult data = Ok(listReciever);
            return data;
        }

        // GET: api/RecieverAPI/5
        public IHttpActionResult Get(int id)
        {
           Receiver  listReciever = new ReceiverDBHandler().ViewReceiverbyId(id);
            if (listReciever==null) return NotFound();
            IHttpActionResult data = Ok(listReciever);
            return data;

        }

        // POST: api/RecieverAPI
        public IHttpActionResult Post(Receiver r)
        {
           bool check= new ReceiverDBHandler().createReceiver(r);
            if (check == false) return NotFound();
            else
              return Ok();

        }

        // PUT: api/RecieverAPI/5
        public IHttpActionResult Put(Receiver r)
        {
            bool check = new ReceiverDBHandler().editreceiver(r);
            if (check == false) return NotFound();
            else
                return Ok();
        }

        // DELETE: api/RecieverAPI/5
        public IHttpActionResult Delete(int id)
        {
            bool check = new ReceiverDBHandler().DeleteReceiverbyId2(id);
            if (check == false) return NotFound();
            else
            return Ok();
        }
    }
}
