using System.ComponentModel.DataAnnotations;
using ValidationCoreLibrary.CommonRules;

namespace AnnotationCoreUnitTest.Classes
{
    public class Person
    {
        /// <summary>
        /// First name
        /// </summary>
        [Required(ErrorMessage = "{0} is required"), DataType(DataType.Text)]
        [StringLength(20, MinimumLength = 6)]
        public string FirstName { get; set; }
        
        /// <summary>
        /// Last name
        /// </summary>
        [Required(ErrorMessage = "{0} is required"), DataType(DataType.Text)]
        [StringLength(10)]
        public string LastName { get; set; }
        
        /// <summary>
        /// Phone number
        /// </summary>
        [Required(ErrorMessage = "{0} is required"), DataType(DataType.Text)]
        [Phone]
        public string Phone { get; set; }
        
        /// <summary>
        /// Social Security number
        /// </summary>
        [SocialSecurity] public string SSN { get; set; }

        public override string ToString() => $"{FirstName} {LastName} {SSN}";

    }
}
