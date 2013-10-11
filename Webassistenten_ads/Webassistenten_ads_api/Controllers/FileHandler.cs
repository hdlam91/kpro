using System;
using System.Collections.Generic;
using System.Linq;
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
        public void Post([FromBody]string value)
        {

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
