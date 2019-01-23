using Common;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using System;
using System.IO;

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
        public ApiResult<string, DBNull> Upload(IFormFileCollection files, IHostingEnvironment hostingEnvironment)
        {
            var result = new ApiResult<string, DBNull>();
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
                    var path = hostingEnvironment.WebRootPath + @"\upload";
                    var fileName = file.FileName;
                    fileName = path + $@"\{fileName}";

                    if (!Directory.Exists(path))
                        Directory.CreateDirectory(path);
                    using (FileStream fileStream = System.IO.File.Create(fileName))
                    {
                        file.CopyTo(fileStream);
                        fileStream.Flush();
                    }

                    result.success = true;
                    result.obj = fileName;
                }
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
