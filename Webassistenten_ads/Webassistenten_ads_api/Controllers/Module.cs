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
    public class Module : ApiController
    {
        private BoligEntities1 db = new BoligEntities1();

        // GET api/Module
        public IEnumerable<Modul> GetModuls()
        {
            return db.Moduls.AsEnumerable();
        }

        // GET api/Module/5
        public Modul GetModul(int id)
        {
            Modul modul = db.Moduls.Find(id);
            if (modul == null)
            {
                throw new HttpResponseException(Request.CreateResponse(HttpStatusCode.NotFound));
            }

            return modul;
        }

        // PUT api/Module/5
        public HttpResponseMessage PutModul(int id, Modul modul)
        {
            if (!ModelState.IsValid)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
            }

            if (id != modul.ModulID)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest);
            }

            db.Entry(modul).State = EntityState.Modified;

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

        // POST api/Module
        public HttpResponseMessage PostModul(Modul modul)
        {
            if (ModelState.IsValid)
            {
                db.Moduls.Add(modul);
                db.SaveChanges();

                HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.Created, modul);
                response.Headers.Location = new Uri(Url.Link("DefaultApi", new { id = modul.ModulID }));
                return response;
            }
            else
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
            }
        }

        // DELETE api/Module/5
        public HttpResponseMessage DeleteModul(int id)
        {
            Modul modul = db.Moduls.Find(id);
            if (modul == null)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound);
            }

            db.Moduls.Remove(modul);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, ex);
            }

            return Request.CreateResponse(HttpStatusCode.OK, modul);
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}