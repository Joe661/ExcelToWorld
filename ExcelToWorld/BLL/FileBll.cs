using Common;
using EntityModel;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using System;
using System.IO;
using System.Threading;
using System.Threading.Tasks;

namespace BLL
{
    public class FileBll
    {
        /// <summary>
        /// 上传文件
        /// </summary>
        /// <param name="files"></param>
        /// <param name="hostingEnvironment"></param>
        /// <returns></returns>
        public ApiResult<string, PercentModel> Upload(IFormFileCollection files, IHostingEnvironment hostingEnvironment)
        {
            var result = new ApiResult<string, PercentModel>();
            try
            {
                if (files.Count == 0)
                {
                    result.message = "请选择上传文件";
                    result.success = false;
                }
                else
                {
                    var file = files[0];//只允许上传一个文件
                    var rootPath = hostingEnvironment.WebRootPath + @"\upload";
                    var ex = file.FileName.Split('.');
                    if (ex[ex.Length - 1] == "xlsx")
                    {
                        var fileName = DateTime.Now.ToString("yyyyMMddhhmmss") + "." + ex[ex.Length - 1];
                        var  path= rootPath + $@"\{fileName}";

                        Common.CommonMethod.CreateDirectory(rootPath);
                        using (FileStream fileStream = System.IO.File.Create(path))
                        {
                            file.CopyTo(fileStream);
                            fileStream.Flush();
                        }
                        result.success = true;
                        result.obj = "/upload/"+fileName;
                    }
                    else
                    {
                        result.message = "请选择上传后缀为.xlsx的文件";
                        result.success = false;
                    }
                }
            }
            catch (Exception ex)
            {
                result.success = false;
                result.message = ex.Message;
            }

            return result;
        }

        public void Transform(string guid,string path, ISession session)
        {
            var task1 = new Task(()=> {
                for (int i = 0; i < 999999999; i++) { }
                SessionHelper.Set(session, guid, "30");
            });
            var task2 = new Task(() => {
                for (int i = 0; i < 999999999; i++) { }
                SessionHelper.Set(session, guid, "60");
            });
            var task3 = new Task(() => {
                for (int i = 0; i < 999999999; i++) { }
                SessionHelper.Set(session, guid, "100");
            });

            task1.Start();
            task2.Start();
            task3.Start();
        }
    }
}
