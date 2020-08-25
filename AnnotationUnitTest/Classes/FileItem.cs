using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnnotationUnitTest.Classes
{
    public class FileItem
    {
        [FileExtensions(ErrorMessage = "Please specify a valid image file (.jpg, .jpeg, .gif or .png)")]
        public string Name { get; set; }
    }
}
