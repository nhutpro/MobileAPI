using System;
using System.Collections.Generic;
using System.Data;
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
        public IHttpActionResult AddCart(int UserID, string ProID)
        {
            try
            {
                Database.Database data = new Database.Database();
                data.ExecuteQuery("EXEC ADDCART " + UserID + ", '" + ProID + "'");
                return Ok("done");



            }
            catch
            {
                return NotFound();
            }
        }
        [Route("product/serum")]
        [HttpGet]
        public IHttpActionResult getSerum()
        {
            try
            {
                Database.Database data = new Database.Database();
                return Ok(data.ExecuteQuery("select * from PRODUCTS where TYPE = 'serum'"));



            }
            catch
            {
                return NotFound();
            }
        }

        [Route("product/toner")]
        [HttpGet]
        public IHttpActionResult getToner()
        {
            try
            {
                Database.Database data = new Database.Database();
                return Ok(data.ExecuteQuery("select * from PRODUCTS where TYPE = 'toner'"));



            }
            catch
            {
                return NotFound();
            }
        }

        [Route("product/suaruamat")]
        [HttpGet]
        public IHttpActionResult getSuaRuaMat()
        {
            try
            {
                Database.Database data = new Database.Database();
                return Ok(data.ExecuteQuery("select * from PRODUCTS where TYPE = 'sua rua mat'"));



            }
            catch
            {
                return NotFound();
            }
        }
        [Route("product/kemchongnang")]
        [HttpGet]
        public IHttpActionResult getKemChongNang()
        {
            try
            {
                Database.Database data = new Database.Database();
                return Ok(data.ExecuteQuery("select * from PRODUCTS where TYPE = 'kem chong nang'"));



            }
            catch
            {
                return NotFound();
            }
        }
        
        [Route("product/GetProductsByPriceDesc")]
        [HttpGet] public IHttpActionResult GetProductsByPriceDesc()
            {
                try
                {
                    DataTable result = Database.Database.ReadTable("GetProductsByPriceDesc");
                    return Ok(result);
                }
                catch
                {
                    return NotFound();
                }
            }

        
        [Route("product/GetProductsByPriceAsc")]
        [HttpGet]
        public IHttpActionResult GetProductsByPriceAsc()
        {
            try
            {
                DataTable result = Database.Database.ReadTable("GetProductsByPriceAsc");
                return Ok(result);
            }
            catch
            {
                return NotFound();
            }
        }
        [Route("product/delete")]
        [HttpGet]
        public IHttpActionResult DeleteProduct(string ProID)
        {
            try
            {
                Database.Database data = new Database.Database();
                
                data.ExecuteQuery($"EXEC DELETEPRODUCT '{ProID}'");
                return Ok("done");
            }
            catch
            {
                return NotFound();
            }
        }




    }
}
