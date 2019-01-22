using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Common;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebCore.Controllers
{
    [Route("api/[controller]/[action]")]
    public class IndexController : Controller
    {
        // POST api/values
        [HttpPost]
        public void Upload()
        {
            var file = Request.Form.Files;
        }
    }
}