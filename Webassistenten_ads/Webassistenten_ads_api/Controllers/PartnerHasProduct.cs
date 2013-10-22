using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;

namespace Webassistenten_ads_api.Controllers
{
    public class PartnerHasProduct : ApiController
    {
        private BoligEntities1 db = new BoligEntities1();

        // GET api/Default1
        public IEnumerable<PartnerHarProdukt> GetPartnerHarProdukts()
        {
            var partnerharprodukts = db.PartnerHarProdukts.Include(p => p.Partner).Include(p => p.Produkt);
            return partnerharprodukts.AsEnumerable();
        }

        // GET api/Default1/5
        public PartnerHarProdukt GetPartnerHarProdukt(byte id)
        {
            PartnerHarProdukt partnerharprodukt = db.PartnerHarProdukts.Find(id);
            if (partnerharprodukt == null)
            {
                throw new HttpResponseException(Request.CreateResponse(HttpStatusCode.NotFound));
            }

            return partnerharprodukt;
        }

        // PUT api/Default1/5
        public HttpResponseMessage PutPartnerHarProdukt(byte id, PartnerHarProdukt partnerharprodukt)
        {
            if (!ModelState.IsValid)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
            }

            if (id != partnerharprodukt.PartnerID)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest);
            }

            db.Entry(partnerharprodukt).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, ex);
            }

            return Request.CreateResponse(HttpStatusCode.OK);
        }

        // POST api/Default1
        public HttpResponseMessage PostPartnerHarProdukt(PartnerHarProdukt partnerharprodukt)
        {
            if (ModelState.IsValid)
            {
                db.PartnerHarProdukts.Add(partnerharprodukt);
                db.SaveChanges();

                HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.Created, partnerharprodukt);
                response.Headers.Location = new Uri(Url.Link("DefaultApi", new { id = partnerharprodukt.PartnerID }));
                return response;
            }
            else
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
            }
        }

        // DELETE api/Default1/5
        public HttpResponseMessage DeletePartnerHarProdukt(byte id)
        {
            PartnerHarProdukt partnerharprodukt = db.PartnerHarProdukts.Find(id);
            if (partnerharprodukt == null)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound);
            }

            db.PartnerHarProdukts.Remove(partnerharprodukt);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, ex);
            }

            return Request.CreateResponse(HttpStatusCode.OK, partnerharprodukt);
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}