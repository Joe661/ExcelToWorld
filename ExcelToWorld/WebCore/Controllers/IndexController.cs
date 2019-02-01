using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using BLL;
using Common;
using EntityModel;
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
        private ISession session;
        private int percent = 0;
        FileBll fileBll = new FileBll();

        public IndexController(IHostingEnvironment hostingEnvironment)
        {
            this.hostingEnvironment = hostingEnvironment;
        }

        // POST api/index/upload
        [HttpPost]
        public ApiResult<string, PercentModel> Upload()
        {
            var files = Request.Form.Files;
            string guid = DateTime.Now.ToString("HHmmssffffff").Trim();
            var result = fileBll.Upload(files, hostingEnvironment);
            HttpContext.Session.SetString(guid, "10");
            var percent = new PercentModel() { guid = guid, percent = "10" };
            var list = new List<PercentModel>() { percent };
            result.rows = list;

            //var task = new Task(() => { fileBll.Transform(guid, "", session); });
            //task.Start();

            return result;
        }

        [HttpPost]
        public ApiResult<string, DBNull> QueryPercent()
        {
            var result = new ApiResult<string, DBNull>();

            try
            {
                var guid = Request.Query["guid"].ToString();
                if (!string.IsNullOrEmpty(guid) && HttpContext.Session.Keys.Contains(guid))
                {
                    result.obj = HttpContext.Session.GetString(guid);
                    result.success = true;
                }
                else
                {
                    result.success = false;
                    result.message = "guid不存在";
                }
            }
            catch (Exception ex)
            {
                result.success = false;
                result.message = ex.Message;
            }

            return result;
        }

        // POST api/index/upload
        //[HttpPost]
        //public ApiResult<string, DBNull> Transform()
        //{
        //    var result = new ApiResult<string, DBNull>();
        //    try
        //    {

        //    }
        //    catch (Exception ex)
        //    {
        //        result.success = false;
        //        result.message = ex.Message;
        //    }

        //    return result;
        //}
    }
}