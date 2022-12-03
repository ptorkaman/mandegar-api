using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Mandegar.Utilities.HttpRequest;
using Mandegar.Utilities.Interfaces;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;

namespace Mandegar.CoreBase.Controller
{
    public class ApiBaseController : ControllerBase
    {


        private int _userId;

        public int UserId
        {
            get
            {

                var identity = (ClaimsIdentity)User.Identity;
                IEnumerable<Claim> claims = identity.Claims;
                _userId = int.Parse(claims.FirstOrDefault(c => c.Type == "Id").Value.ToString());
                return _userId;
            }
            set { _userId = value; }
        }
    }

}
