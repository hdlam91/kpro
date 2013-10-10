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
    public class ProspectHasOrder : ApiController
    {
        private BoligEntities1 db = new BoligEntities1();

        // GET api/ProspectHasOrder
        public IEnumerable<ProspektHarBestilling> GetProspektHarBestillings()
        {
            var prospektharbestillings = db.ProspektHarBestillings.Include(p => p.Bruker).Include(p => p.Produkt);
            return prospektharbestillings.AsEnumerable();
        }

        // GET api/ProspectHasOrder/5
        public ProspektHarBestilling GetProspektHarBestilling(long id)
        {
            ProspektHarBestilling prospektharbestilling = db.ProspektHarBestillings.Find(id);
            if (prospektharbestilling == null)
            {
                throw new HttpResponseException(Request.CreateResponse(HttpStatusCode.NotFound));
            }

            return prospektharbestilling;
        }

        // PUT api/ProspectHasOrder/5
        public HttpResponseMessage PutProspektHarBestilling(long id, ProspektHarBestilling prospektharbestilling)
        {
            if (!ModelState.IsValid)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
            }

            if (id != prospektharbestilling.ProspektID)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest);
            }

            db.Entry(prospektharbestilling).State = EntityState.Modified;

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

        // POST api/ProspectHasOrder
        public HttpResponseMessage PostProspektHarBestilling(ProspektHarBestilling prospektharbestilling)
        {
            if (ModelState.IsValid)
            {
                db.ProspektHarBestillings.Add(prospektharbestilling);
                db.SaveChanges();

                HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.Created, prospektharbestilling);
                response.Headers.Location = new Uri(Url.Link("DefaultApi", new { id = prospektharbestilling.ProspektID }));
                return response;
            }
            else
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
            }
        }

        // DELETE api/ProspectHasOrder/5
        public HttpResponseMessage DeleteProspektHarBestilling(long id)
        {
            ProspektHarBestilling prospektharbestilling = db.ProspektHarBestillings.Find(id);
            if (prospektharbestilling == null)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound);
            }

            db.ProspektHarBestillings.Remove(prospektharbestilling);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, ex);
            }

            return Request.CreateResponse(HttpStatusCode.OK, prospektharbestilling);
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}