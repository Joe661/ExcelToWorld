using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using BLL;
using Common;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebCore.Controllers
{
    [Route("api/[controller]/[action]")]
    public class IndexController : Controller
    {
        private IHostingEnvironment hostingEnvironment;
        FileBll fileBll = new FileBll();

        public IndexController(IHostingEnvironment hostingEnvironment)
        {
            this.hostingEnvironment = hostingEnvironment;
        }

        // POST api/index/upload
        [HttpPost]
        public ApiResult<string,DBNull> Upload()
        {
            var files = Request.Form.Files;
            return fileBll.Upload(files, hostingEnvironment);
        }

        // POST api/index/upload
        [HttpPost]
        public ApiResult<string, DBNull> Transform()
        {
            var result = new ApiResult<string, DBNull>();
            try
            {

            }
            catch (Exception ex)
            {
                result.success = false;
                result.message = ex.Message;
            }

            return result;
        }
    }
}