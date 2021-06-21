using System.ComponentModel.DataAnnotations;
using System.Text;
using System.Text.RegularExpressions;
using ValidationCoreLibrary;
using ValidationCoreLibrary.ExtensionMethods;

namespace ValidationLibrary.ExtensionMethods
{
    public static class ValidatorExtensions
    {
        /// <summary>
        /// Remove extra whitespace
        /// </summary>
        /// <param name="sender"></param>
        /// <returns></returns>
        public static string SanitizedErrorMessage(this ValidationResult sender) => 
            Regex.Replace(sender.ErrorMessage.SplitCamelCase(), " {2,}", " ");

        /// <summary>
        /// Combine error validation text for display, in this case a MessageBox.
        /// </summary>
        /// <param name="sender"></param>
        /// <returns>Current validation issue</returns>
        public static string ErrorMessageList(this EntityValidationResult sender)
        {

            var sb = new StringBuilder();
            sb.AppendLine("Validation issues\n");

            foreach (var errorItem in sender.Errors)
            {
                sb.AppendLine(errorItem.SanitizedErrorMessage() + "\n");
            }

            return sb.ToString();

        }

    }
}