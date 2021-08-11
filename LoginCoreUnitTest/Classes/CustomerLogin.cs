using System;
using System.ComponentModel.DataAnnotations;

namespace LoginCoreUnitTest.Classes
{
    class CustomerLogin
    {
        [Required(ErrorMessage = "{0} is required"), DataType(DataType.Text)]
        [StringLength(10, MinimumLength = 6)]
        public string UserName { get; set; }
        [Required(ErrorMessage = "{0} is required"), DataType(DataType.Text)]
        [StringLength(20, MinimumLength = 6)]
        [PasswordCheck(ErrorMessage = "Must include a number and symbol in {0}")]
        public string Password { get; internal set; }
        [Compare("Password", ErrorMessage = "Passwords do not match, please try again"), DataType(DataType.Text)]
        [StringLength(20, MinimumLength = 6)]
        public string PasswordConfirmation { get; internal set; }
        public override string ToString() => UserName;
    }
}