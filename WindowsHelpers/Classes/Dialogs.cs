
using System;
using System.Drawing;
using System.Windows.Forms;

namespace WindowsHelpers.Classes
{
    public class Dialogs
    {
        /// <summary>
        /// WPF dialog to ask a question
        /// </summary>
        /// <param name="owner">window</param>
        /// <param name="heading">text for dialog heading</param>
        /// <param name="icon">Icon to display</param>
        /// <param name="defaultButton">Button to focus</param>
        /// <returns>true for yes button, false for no button</returns>
        public static bool Question(IntPtr owner, string heading, Icon icon, DialogResult defaultButton = DialogResult.Yes)
        {

            TaskDialogButton yesButton = new("Yes") { Tag = DialogResult.Yes };
            TaskDialogButton noButton = new("No") { Tag = DialogResult.No };

            var buttons = new TaskDialogButtonCollection();

            if (defaultButton == DialogResult.Yes)
            {
                buttons.Add(yesButton);
                buttons.Add(noButton);
            }
            else
            {
                buttons.Add(noButton);
                buttons.Add(yesButton);
            }

            TaskDialogPage page = new()
            {
                Caption = "Question",
                SizeToContent = true,
                Heading = heading,
                Icon = new TaskDialogIcon(icon),
                Footnote = new TaskDialogFootnote() { Text = "Copyright: Some company" },
                Buttons = buttons
            };

            var result = TaskDialog.ShowDialog(owner, page, TaskDialogStartupLocation.CenterOwner);

            return (DialogResult)result.Tag == DialogResult.Yes;
        }
        public static void Information(IntPtr owner, string heading, string buttonText = "Ok")
        {

            TaskDialogButton okayButton = new(buttonText);

            TaskDialogPage page = new()
            {
                Caption = "Information",
                SizeToContent = true,
                Heading = heading,
                Buttons = new TaskDialogButtonCollection() { okayButton }
            };

            TaskDialog.ShowDialog(owner, page);

        }
        /// <summary>
        /// Used for too many login attempts
        /// </summary>
        /// <param name="owner">Calling window</param>
        /// <param name="icon">Icon to show</param>
        public static void BadAttempt(IntPtr owner, Icon icon)
        {

            TaskDialogButton okayButton = new("Contact service desk");

            TaskDialogPage page = new()
            {
                Caption = "Error",
                SizeToContent = true,
                Heading = "Too many attempts",
                Icon = new TaskDialogIcon(icon),
                Buttons = new TaskDialogButtonCollection() { okayButton }
            };

            TaskDialog.ShowDialog(owner, page);

        }
    }
}
