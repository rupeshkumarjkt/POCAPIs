using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using DataAccessLibrary.Models;

namespace Student_WebAPI.Controllers
{
    [Produces("application/json")]
    [Route("api/Login")]
    public class LoginController : Controller
    {
        [HttpPost]
        public bool ValidateUser(string userName, string pwd)
        {
            using (var context = new KPCollegeContext())
            {
                var user = context.User.Where(x => x.Name.Equals(userName) && x.Password.Equals(pwd)).FirstOrDefault();
                if (user != null)
                    return true;
            }
            return false;
        }

    }
}