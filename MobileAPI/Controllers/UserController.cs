using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace MobileAPI.Controllers
{
    public class UserController : ApiController
    {
       
        [Route("api/ServiceController/GetUser")]
        [HttpGet]
        public IHttpActionResult GetUser()
        {
            DataTable users = Database.Database.ReadTable("GETUSER");
            return Ok(users);
        } 
        /*
        public IHttpActionResult GetUserByID(int id)
        {
        try
        {
        Dictionary<string, object> param = new Dictionary<string, object>();
        param.Add("ID", id); DataTable result = Database.Database.ReadTable("GETUSERBYID", param); return Ok(result);
        }
        catch
        {
        return NotFound();
        } } */
        [Route("api/ServiceController/AddUser")]
        [HttpGet]
        public IHttpActionResult AddUser(string username, string password, string fullname, string email, string phone, string gender, string birthday, string role)
        {
            try
            {
                Database.Database data = new Database.Database();
                data.ExecuteQuery("EXEC ADDUSER '" + username + "', '" + password + "', '" + fullname + "', '" + email + "', '" + phone + "', '" + gender + "', '" + birthday + "', '" + role + "'");
                return Ok("done");
            }
            catch
            {
                return NotFound();
            }
        }
        [Route("api/ServiceController/ChangeUserInfo")]
        [HttpGet]
        public IHttpActionResult ChangeUserInfo(int userid, string fullname, string email, string phone, string gender, string birthday, string address)
        {
            try
            {
                Database.Database data = new Database.Database();
                data.ExecuteQuery("EXEC CHANGEUSERINFO " + userid + ", '" + fullname + "', '" + email + "', '" + phone + "', '" + gender + "', '" + birthday + "','" + address + "'");
                return Ok("done");
            }
            catch
            {
                return NotFound();
            }
        }
        [Route("user/getbyid")]
        [HttpGet]
        public IHttpActionResult UserID(string UserID)
        {
            try
            {
               
         
                Database.Database data = new Database.Database();
                return Ok(data.ExecuteQuery($"SELECT * FROM USERS WHERE USERID = {UserID}"));

            }
            catch
            {
                return NotFound();
            }
        }


    }
}
