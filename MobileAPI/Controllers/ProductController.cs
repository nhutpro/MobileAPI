using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace MobileAPI.Controllers
{
    public class ProductController : ApiController
    {
        [Route("hello")]
        [HttpGet]
        public IHttpActionResult HelloApi()
        {
            try
            {
                Database.Database data = new Database.Database();
                return Ok(data.ExecuteQuery("select * from PRODUCTS"));



            }
            catch
            {
                return NotFound();
            }
        }

        [Route("product/addcart")]
        [HttpGet]
        public IHttpActionResult AddCart(string UserID, string ProID)
        {
            try
            {
                Database.Database data = new Database.Database();
                data.ExecuteQuery("EXEC ADDCART '" + UserID + "', '" + ProID + "'");
                return Ok("done");



            }
            catch
            {
                return NotFound();
            }
        }

   
    }
}
