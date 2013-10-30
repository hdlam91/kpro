using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;

using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Webassistenten_ads_api.Controllers
{
    public class FileHandler : ApiController
    {
        // GET api/filehandler
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/filehandler/5
        public string Get(int id)
        {
            return "value";
        }

        // POST api/filehandler
		/// <summary>
		/// Will post one, and exactly one 
		/// </summary>
		public HttpResponseMessage Post()
		{

			HttpResponseMessage result = null;
            var httpRequest = System.Web.HttpContext.Current.Request;

			// Verify that this is an HTML Form file upload request
			if (!Request.Content.IsMimeMultipartContent ("form-data")) {
				result = Request.CreateResponse (HttpStatusCode.UnsupportedMediaType);
			} else {
				if (httpRequest.Files.Count == 1) {
					var docfiles = new List<string> ();
                    string file = httpRequest.Files[0].ToString();
					//foreach (string file in httpRequest.Files) {
						var postedFile = httpRequest.Files [file];
                        var filePath = System.Web.HttpContext.Current.Server.MapPath("~/" + postedFile.FileName);
					
						postedFile.SaveAs (filePath);
						docfiles.Add (filePath);
					
                    FileInfo fileInfo = new FileInfo(filePath);

					if (fileInfo.Extension != ".pdf")
					{
						result = Request.CreateResponse(HttpStatusCode.BadRequest);
					}
					else
					{
					result = Request.CreateResponse(HttpStatusCode.Created, docfiles);
					}
				} else {
					result = Request.CreateResponse(HttpStatusCode.BadRequest);
				}
			}
			
			return result;
			
		}

        // PUT api/filehandler/5
        public void Put(int id, [FromBody]string value)
        {
            //System.IO.File.WriteAllLines(@"C:\Users\Public\TestFolder\WriteLines.txt", lines);

        }

        // DELETE api/filehandler/5
        public void Delete(int id)
        {
        }
    }
}
