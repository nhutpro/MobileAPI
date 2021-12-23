﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace MobileAPI.Controllers
{
    public class OrderController : ApiController
    {
        [Route("order/all")]
        [HttpGet]
        public IHttpActionResult allorder(string UserID)
        {
            try
            {
                Database.Database data = new Database.Database();

                return Ok(data.ExecuteQuery("EXEC GETALLORDERS '" + UserID + "'"));



            }
            catch
            {
                return NotFound();
            }
        }
        [Route("order/running")]
        [HttpGet]
        public IHttpActionResult shipedorder(string UserID)
        {
            try
            {
                Database.Database data = new Database.Database();

                return Ok(data.ExecuteQuery("EXEC GETORDERS '"+UserID+"', N'Đang giao hàng'"));



            }
            catch
            {
                return NotFound();
            }
        }
        [Route("order/success")]
        [HttpGet]
        public IHttpActionResult successorder(string UserID)
        {
            try
            {
                Database.Database data = new Database.Database();

                return Ok(data.ExecuteQuery("EXEC GETORDERS '" + UserID + "', N'Giao hàng thành công'"));



            }
            catch
            {
                return NotFound();
            }
        }
        [Route("order/fail")]
        [HttpGet]
        public IHttpActionResult failorder(string UserID)
        {
            try
            {
                Database.Database data = new Database.Database();

                return Ok(data.ExecuteQuery("EXEC GETORDERS '" + UserID + "', N'Giao hàng không thành công'"));



            }
            catch
            {
                return NotFound();
            }
        }
        [Route("order/add")]
        [HttpGet]
        public IHttpActionResult addorder(string UserID, string ProID, string number)
        {
            try
            {
                Database.Database data = new Database.Database();

                data.ExecuteQuery($"EXEC ADDORDERS {UserID},{ProID}, {number}");
                return Ok("Done");



            }
            catch
            {
                return NotFound();
            }
        }
        [Route("order/failstatus")]
        [HttpGet]
        public IHttpActionResult failstatus(string UserID, string OrderID)
        {
            try
            {
                Database.Database data = new Database.Database();

                data.ExecuteQuery($"EXEC FAILSTATUS '{UserID}','{OrderID}'");
                return Ok("Done");



            }
            catch
            {
                return NotFound();
            }
        }
        [Route("order/successstatus")]
        [HttpGet]
        public IHttpActionResult successstatus(string UserID, string OrderID)
        {
            try
            {
                Database.Database data = new Database.Database();

                data.ExecuteQuery($"EXEC SUCCESSSTATUS '{UserID}','{OrderID}'");
                return Ok("Done");



            }
            catch
            {
                return NotFound();
            }
        }
    }
}
