﻿using System;
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
    public class AdHasOrder : ApiController
    {
        private BoligEntities1 db = new BoligEntities1();

        // GET api/AdHasOrder
        public IEnumerable<AnnonseHarBestilling> GetAnnonseHarBestillings()
        {
            return db.AnnonseHarBestillings.AsEnumerable();
        }

        // GET api/AdHasOrder/5
        public AnnonseHarBestilling GetAnnonseHarBestilling(long id)
        {
            AnnonseHarBestilling annonseharbestilling = db.AnnonseHarBestillings.Find(id);
            if (annonseharbestilling == null)
            {
                throw new HttpResponseException(Request.CreateResponse(HttpStatusCode.NotFound));
            }

            return annonseharbestilling;
        }

        // PUT api/AdHasOrder/5
        public HttpResponseMessage PutAnnonseHarBestilling(long id, AnnonseHarBestilling annonseharbestilling)
        {
            if (!ModelState.IsValid)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
            }

            if (id != annonseharbestilling.AnnonseID)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest);
            }

            db.Entry(annonseharbestilling).State = EntityState.Modified;

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

        // POST api/AdHasOrder
        public HttpResponseMessage PostAnnonseHarBestilling(AnnonseHarBestilling annonseharbestilling)
        {
            if (ModelState.IsValid)
            {
                db.AnnonseHarBestillings.Add(annonseharbestilling);
                db.SaveChanges();

                HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.Created, annonseharbestilling);
                response.Headers.Location = new Uri(Url.Link("DefaultApi", new { id = annonseharbestilling.AnnonseID }));
                return response;
            }
            else
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
            }
        }

        // DELETE api/AdHasOrder/5
        public HttpResponseMessage DeleteAnnonseHarBestilling(long id)
        {
            AnnonseHarBestilling annonseharbestilling = db.AnnonseHarBestillings.Find(id);
            if (annonseharbestilling == null)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound);
            }

            db.AnnonseHarBestillings.Remove(annonseharbestilling);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, ex);
            }

            return Request.CreateResponse(HttpStatusCode.OK, annonseharbestilling);
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}