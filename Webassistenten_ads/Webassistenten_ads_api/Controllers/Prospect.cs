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
    public class Prospect : ApiController
    {
        private BoligEntities1 db = new BoligEntities1();

        // GET api/Prospect
        public IEnumerable<Prospekt> GetProspekts()
        {
            return db.Prospekts.AsEnumerable();
        }

        // GET api/Prospect/5
        public Prospekt GetProspekt(long id)
        {
            Prospekt prospekt = db.Prospekts.Find(id);
            if (prospekt == null)
            {
                throw new HttpResponseException(Request.CreateResponse(HttpStatusCode.NotFound));
            }

            return prospekt;
        }

        // PUT api/Prospect/5
        public HttpResponseMessage PutProspekt(long id, Prospekt prospekt)
        {
            if (!ModelState.IsValid)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
            }

            if (id != prospekt.ProspektID)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest);
            }

            db.Entry(prospekt).State = EntityState.Modified;

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

        // POST api/Prospect
        public HttpResponseMessage PostProspekt(Prospekt prospekt)
        {
            if (ModelState.IsValid)
            {
                db.Prospekts.Add(prospekt);
                db.SaveChanges();

                HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.Created, prospekt);
                response.Headers.Location = new Uri(Url.Link("DefaultApi", new { id = prospekt.ProspektID }));
                return response;
            }
            else
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
            }
        }

        // DELETE api/Prospect/5
        public HttpResponseMessage DeleteProspekt(long id)
        {
            Prospekt prospekt = db.Prospekts.Find(id);
            if (prospekt == null)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound);
            }

            db.Prospekts.Remove(prospekt);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, ex);
            }

            return Request.CreateResponse(HttpStatusCode.OK, prospekt);
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}