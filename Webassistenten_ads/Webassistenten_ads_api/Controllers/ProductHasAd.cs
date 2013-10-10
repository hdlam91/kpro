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
    public class ProductHasAd : ApiController
    {
        private BoligEntities1 db = new BoligEntities1();

        // GET api/ProductHasAd
        public IEnumerable<ProduktHarAnnonse> GetProduktHarAnnonses()
        {
            var produktharannonses = db.ProduktHarAnnonses.Include(p => p.Produkt);
            return produktharannonses.AsEnumerable();
        }

        // GET api/ProductHasAd/5
        public ProduktHarAnnonse GetProduktHarAnnonse(int id)
        {
            ProduktHarAnnonse produktharannonse = db.ProduktHarAnnonses.Find(id);
            if (produktharannonse == null)
            {
                throw new HttpResponseException(Request.CreateResponse(HttpStatusCode.NotFound));
            }

            return produktharannonse;
        }

        // PUT api/ProductHasAd/5
        public HttpResponseMessage PutProduktHarAnnonse(int id, ProduktHarAnnonse produktharannonse)
        {
            if (!ModelState.IsValid)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
            }

            if (id != produktharannonse.AnnonseID)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest);
            }

            db.Entry(produktharannonse).State = EntityState.Modified;

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

        // POST api/ProductHasAd
        public HttpResponseMessage PostProduktHarAnnonse(ProduktHarAnnonse produktharannonse)
        {
            if (ModelState.IsValid)
            {
                db.ProduktHarAnnonses.Add(produktharannonse);
                db.SaveChanges();

                HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.Created, produktharannonse);
                response.Headers.Location = new Uri(Url.Link("DefaultApi", new { id = produktharannonse.AnnonseID }));
                return response;
            }
            else
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
            }
        }

        // DELETE api/ProductHasAd/5
        public HttpResponseMessage DeleteProduktHarAnnonse(int id)
        {
            ProduktHarAnnonse produktharannonse = db.ProduktHarAnnonses.Find(id);
            if (produktharannonse == null)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound);
            }

            db.ProduktHarAnnonses.Remove(produktharannonse);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, ex);
            }

            return Request.CreateResponse(HttpStatusCode.OK, produktharannonse);
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}