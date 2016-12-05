using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MVCCMS.Models.ViewModels
{
    public class FileUploadVM
    {
        [Required, FileExtensions(Extensions = "json", ErrorMessage = "Add json file")]
        public HttpPostedFileBase File { get; set; }
    }
}