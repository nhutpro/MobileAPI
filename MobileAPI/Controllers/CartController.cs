using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace MobileAPI.Controllers
{
    public class CartController : ApiController

    {
        [Route("cart/delete")]
        [HttpGet]
        public IHttpActionResult Delete(string userID, string procID)
        {
            try
            {
                Database.Database data = new Database.Database();
                data.ExecuteQuery("EXEC DELETECART '" + userID + "', '" + procID + "'");
                return Ok("done");

                    


            }
            catch
            {
                return NotFound();
            }
        }
        [Route("cart/subtract")]
        [HttpGet]
        public IHttpActionResult Subtract(string userID, string procID)
        {
            try
            {
                Database.Database data = new Database.Database();
                data.ExecuteQuery("EXEC SUBTRACT '" + userID + "', '" + procID + "'");
                return Ok("done");




            }
            catch
            {
                return NotFound();
            }
        }
        [Route("cart/plus")]
        [HttpGet]
        public IHttpActionResult Plus(string userID, string procID)
        {
            try
            {
                Database.Database data = new Database.Database();
                data.ExecuteQuery("EXEC PLUS '" + userID + "', '" + procID + "'");
                return Ok("done");




            }
            catch
            {
                return NotFound();
            }
        }
        [Route("cart")]
        [HttpGet]
        public IHttpActionResult Cart(string userID)
        {
            try
            {
                Database.Database data = new Database.Database();
                return Ok(data.ExecuteQuery("EXEC GETCART '" + userID + "'"));
            



            }
            catch
            {
                return NotFound();
            }
        }
    }
}
