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
    public class ProductHasModule : ApiController
    {
        private BoligEntities1 db = new BoligEntities1();

        // GET api/ProductHasModule
        public IEnumerable<ProduktHarModul> GetProduktHarModuls()
        {
            return db.ProduktHarModuls.AsEnumerable();
        }

        // GET api/ProductHasModule/5
        public ProduktHarModul GetProduktHarModul(byte id)
        {
            ProduktHarModul produktharmodul = db.ProduktHarModuls.Find(id);
            if (produktharmodul == null)
            {
                throw new HttpResponseException(Request.CreateResponse(HttpStatusCode.NotFound));
            }

            return produktharmodul;
        }

        // PUT api/ProductHasModule/5
        public HttpResponseMessage PutProduktHarModul(byte id, ProduktHarModul produktharmodul)
        {
            if (!ModelState.IsValid)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
            }

            if (id != produktharmodul.PartnerID)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest);
            }

            db.Entry(produktharmodul).State = EntityState.Modified;

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

        // POST api/ProductHasModule
        public HttpResponseMessage PostProduktHarModul(ProduktHarModul produktharmodul)
        {
            if (ModelState.IsValid)
            {
                db.ProduktHarModuls.Add(produktharmodul);
                db.SaveChanges();

                HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.Created, produktharmodul);
                response.Headers.Location = new Uri(Url.Link("DefaultApi", new { id = produktharmodul.PartnerID }));
                return response;
            }
            else
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
            }
        }

        // DELETE api/ProductHasModule/5
        public HttpResponseMessage DeleteProduktHarModul(byte id)
        {
            ProduktHarModul produktharmodul = db.ProduktHarModuls.Find(id);
            if (produktharmodul == null)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound);
            }

            db.ProduktHarModuls.Remove(produktharmodul);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, ex);
            }

            return Request.CreateResponse(HttpStatusCode.OK, produktharmodul);
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}