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
                return Ok(data.ExecuteQuery("select * from PRODUCTS where TYPE = N'sữa rửa mặt'"));



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
                return Ok(data.ExecuteQuery("select * from PRODUCTS where TYPE = N'kem chống nắng'"));



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
        [Route("product/update")]
        [HttpGet]
        public IHttpActionResult updateProduct(string ProID, string name, string brand, float price, string desciption, int stock, string type)
        {
            try
            {
                Database.Database data = new Database.Database();

                data.ExecuteQuery($"EXEC UPDATEPRODUCT '{ProID}',N'{name}', N'{brand}',{price}, N'{desciption}',{stock}, N'{type}' ");
                return Ok("done");
            }
            catch
            {
                return NotFound();
            }
        }
        [Route("product/create")]
        [HttpGet]
        public IHttpActionResult createProduct( string name, string image, string brand, float price, string desciption, int stock, string type)
        {
            try
            {
                Database.Database data = new Database.Database();

                data.ExecuteQuery($"EXEC CREATEPRODUCT N'{name}', '{image}', N'{brand}',{price}, N'{desciption}',{stock}, N'{type}'");
                return Ok("done");
            }
            catch
            {
                return NotFound();
            }
        }

        [Route("product/get")]
        [HttpGet]
        public IHttpActionResult getProduct(string ProID)
        {
            try
            {
                Database.Database data = new Database.Database();
                return Ok(data.ExecuteQuery($"select * from PRODUCTS where PRODUCTID = '{ProID}'"));



            }
            catch
            {
                return NotFound();
            }
        }




    }
}
