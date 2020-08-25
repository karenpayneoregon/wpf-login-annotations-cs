using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ValidationLibrary.CommonRules;

namespace AnnotationUnitTest.Classes
{
    public class Person
    {
        [Required(ErrorMessage = "{0} is required"), DataType(DataType.Text)]
        [StringLength(20, MinimumLength = 6)]
        public string FirstName { get; set; }
        [Required(ErrorMessage = "{0} is required"), DataType(DataType.Text)]
        [StringLength(10)]
        public string LastName { get; set; }
        [Required(ErrorMessage = "{0} is required"), DataType(DataType.Text)]
        [Phone]
        public string Phone { get; set; }
        [SocialSecurity] public string SSN { get; set; }
    }
}
