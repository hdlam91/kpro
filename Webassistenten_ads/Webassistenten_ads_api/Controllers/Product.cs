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
    public class Product : ApiController
    {
        private BoligEntities1 db = new BoligEntities1();

        // GET api/Product
        public IEnumerable<Produkt> GetProdukts()
        {
            return db.Produkts.AsEnumerable();
        }

        // GET api/Product/5
        public Produkt GetProdukt(byte id)
        {
            Produkt produkt = db.Produkts.Find(id);
            if (produkt == null)
            {
                throw new HttpResponseException(Request.CreateResponse(HttpStatusCode.NotFound));
            }

            return produkt;
        }

        // PUT api/Product/5
        public HttpResponseMessage PutProdukt(byte id, Produkt produkt)
        {
            if (!ModelState.IsValid)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
            }

            if (id != produkt.ProduktID)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest);
            }

            db.Entry(produkt).State = EntityState.Modified;

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

        // POST api/Product
        public HttpResponseMessage PostProdukt(Produkt produkt)
        {
            if (ModelState.IsValid)
            {
                db.Produkts.Add(produkt);
                db.SaveChanges();

                HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.Created, produkt);
                response.Headers.Location = new Uri(Url.Link("DefaultApi", new { id = produkt.ProduktID }));
                return response;
            }
            else
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
            }
        }

        // DELETE api/Product/5
        public HttpResponseMessage DeleteProdukt(byte id)
        {
            Produkt produkt = db.Produkts.Find(id);
            if (produkt == null)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound);
            }

            db.Produkts.Remove(produkt);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, ex);
            }

            return Request.CreateResponse(HttpStatusCode.OK, produkt);
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}