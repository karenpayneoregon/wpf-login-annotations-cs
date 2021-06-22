using System;
using System.Windows;
using static System.Windows.MessageBox;

namespace ValidateLoginCore.Classes
{
    public static class CommonDialogs
    {
        /// <summary>
        /// Ask a question with No as the default button
        /// </summary>
        /// <param name="pMessage"></param>
        /// <param name="pTitle">Title which defaults to 'Question'</param>
        /// <returns></returns>
        public static bool Question(string pMessage, string pTitle = "Question") => (Show(pMessage, pTitle, MessageBoxButton.YesNo, MessageBoxImage.Question, MessageBoxResult.No) == MessageBoxResult.Yes);
        /// <summary>
        /// Ask a question with OK and Cancel where the default button is Cancel
        /// </summary>
        /// <param name="text"></param>
        /// <param name="title">Title for message box</param>
        /// <param name="defaultButton"></param>
        /// <returns></returns>
        public static bool QuestionWithCancel(string text, string title, MessageBoxResult defaultButton = MessageBoxResult.Cancel) => Show(text, title, MessageBoxButton.OKCancel, MessageBoxImage.Question, defaultButton) == MessageBoxResult.OK;
    }
}