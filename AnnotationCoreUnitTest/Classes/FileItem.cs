using System.ComponentModel.DataAnnotations;

namespace AnnotationCoreUnitTest.Classes
{
    public class FileItem
    {
        [FileExtensions(ErrorMessage = "Please specify a valid image file (.jpg, .jpeg, .gif or .png)")]
        public string Name { get; set; }
    }
}
