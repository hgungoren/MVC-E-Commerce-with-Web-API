using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Web;

namespace COMMON
{
    public class ImageUploader
    {
        /*
         Hata Kodları=>
        0=> "Dosya Boş",
        1=> "Zaten bu isimle kayıtlı bir dosya mevcut",
        2=> "Dosya uzantısı belirtilenlere uymuyor"
         */

        public static string UploadImage(string serverPath,HttpPostedFileBase file)//"~/Contet/IMaGe.png"
        {
            var fileName = "";
            if (file != null)
            {
                var uniqueName = Guid.NewGuid();
                serverPath = serverPath.Replace("~", string.Empty);

                var fileArray = file.FileName.Split('.');

                string extension = fileArray[fileArray.Length - 1].ToLower();

                fileName = uniqueName + "." + extension;

                if (extension == "jpg" || extension == "png" || extension == "jpeg" || extension == "gif")
                {
                    if (File.Exists(HttpContext.Current.Server.MapPath(serverPath + fileName)))
                    {
                        return "1";
                    }
                    else
                    {
                        var filePath = HttpContext.Current.Server.MapPath(serverPath + fileName);
                        file.SaveAs(filePath);
                    }
                }
                else
                {
                    return "2";
                }

            }
            else
            {
                return "0";
            }
            return fileName;
        }
    }
}
