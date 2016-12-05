using MVCCMS.Models.EntityModels;
using MVCCMS.Models.ViewModels;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace MVCCMS.Controllers
{
    public class FileController : Controller
    {
        // GET: File
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult UploadJson()
        {
            return View();
        }

        [HttpPost]
        public ActionResult UploadJson(FileUploadVM model)
        {
            //if (!ModelState.IsValid)
            //    return View(model);

            byte[] data;

            using (MemoryStream ms = new MemoryStream())
            {
                model.File.InputStream.CopyTo(ms);
                data = ms.ToArray();
            }

            var json = Encoding.Default.GetString(data);

            var entity = JsonConvert.DeserializeObject<Product[]>(json);

            return RedirectToAction("Index", "Home");
        }
    }
}