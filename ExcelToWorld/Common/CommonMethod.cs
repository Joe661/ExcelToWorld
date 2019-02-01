using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Common
{
    public class CommonMethod
    {
        /// <summary>
        /// 创建文件夹
        /// </summary>
        /// <param name="rootPath">文件夹路径</param>
        public static void CreateDirectory(string rootPath)
        {
            if (!Directory.Exists(rootPath))
                Directory.CreateDirectory(rootPath);
        }

        /// <summary>
        /// 进度处理
        /// </summary>
        /// <param name="guid"></param>
        public void PercentProccess()
        {
           
        }
    }
}
