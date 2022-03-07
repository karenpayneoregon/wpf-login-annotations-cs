using System.ComponentModel.DataAnnotations;
using System.Text;
using System.Text.RegularExpressions;

namespace ValidationCoreLibrary.ExtensionMethods
{
    public static class ValidatorExtensions
    {
        /// <summary>
        /// Remove extra whitespace and split strings with upper cased characters
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

            StringBuilder builder = new ();
            builder.AppendLine("Validation issues\n");

            foreach (ValidationResult errorItem in sender.Errors)
            {
                builder.AppendLine(errorItem.SanitizedErrorMessage() + "\n");
            }

            return builder.ToString();

        }

    }
}