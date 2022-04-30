using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using ValidateLoginCore.Classes;
using ValidateLoginCore.Classes.ValidationRules;
using ValidationCoreLibrary;
using ValidationCoreLibrary.ExtensionMethods;
using System.Windows.Interop;
using WindowsHelpers.Classes;

namespace ValidateLoginCore
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private Icon _ExplainationIcon;
        private Icon _QuestionIcon;
        private IntPtr _intPtr;

        private bool _shown;

        private int _retryCount = 0;

        public static RoutedCommand ContinueRoutedCommand = new();
        public static RoutedCommand ExitRoutedCommand = new();

        private readonly CustomerLogin _customerLogin = new();

        protected override void OnContentRendered(EventArgs e)
        {

            base.OnContentRendered(e);

            if (_shown)
            {
                return;
            }

            _shown = true;

            Window window = GetWindow(this);
            var windowInterop = new WindowInteropHelper(window ?? throw new InvalidOperationException());
            _intPtr = windowInterop.Handle;

            _ExplainationIcon = ImageHelpers.BitmapImageToIcon("Resources\\Explaination.ico");
            _QuestionIcon = ImageHelpers.BitmapImageToIcon("Resources\\QuestionBlue.ico");

        }

        public MainWindow()
        {
            InitializeComponent();


            CommandBindings.Add(new CommandBinding(
                ContinueRoutedCommand,
                PasswordCheckCommandOnExecute,
                PasswordCheckCanExecuteCommand));

            CommandBindings.Add(new CommandBinding(
                ExitRoutedCommand,
                ExitApplicationCommandOnExecute,
                ApplicationExitCanExecute));

            DataContext = _customerLogin;
        }
        /// <summary>
        /// Validate user name and password logic for up to three failed attempts
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void PasswordCheckCommandOnExecute(object sender, ExecutedRoutedEventArgs e)
        {
            ProcessLogin();
        }
        /// <summary>
        /// Determine if rules for a resetting a password are met using property data
        /// annotation in the class CustomerLogin. Rules for a password are done
        /// in <see cref="PasswordCheck"/> class.
        /// </summary>
        private void ProcessLogin()
        {
            EntityValidationResult validationResult = ValidationHelper.ValidateEntity(_customerLogin);

            if (validationResult.HasError)
            {
                _retryCount += 1;

                if (_retryCount >= 3)
                {
                    Dialogs.BadAttempt(_intPtr, _ExplainationIcon);
                    Application.Current.Shutdown();
                }
                else
                {
                    MessageBox.Show(validationResult.ErrorMessageList());
                }
            }
            else
            {
                Hide();

                var workWindow = new Window1();
                Application.Current.MainWindow = workWindow;
                workWindow.ShowDialog();

                Close();
            }
        }

        private void PasswordCheckCanExecuteCommand(object sender, CanExecuteRoutedEventArgs e) =>
            e.CanExecute = _retryCount < 4;

        private bool _allowExit;
        private void ExitApplicationCommandOnExecute(object sender, ExecutedRoutedEventArgs e)
        {
            if (Dialogs.Question(_intPtr, "Cancel login?", _QuestionIcon))
            {
                _allowExit = true;
                Application.Current.Shutdown();
            }
        }

        private void ApplicationExitCanExecute(object sender, CanExecuteRoutedEventArgs e) =>
            e.CanExecute = true;

        private void MainWindow_OnClosing(object sender, CancelEventArgs e)
        {
            if (_allowExit)
            {
                Application.Current.Shutdown();
            }
            else
            {
                e.Cancel = true;
            }
        }
        /// <summary>
        /// Set confirm password to the logon object
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void PasswordConfirmTextBox_OnPasswordChanged(object sender, RoutedEventArgs e) =>
            _customerLogin.PasswordConfirmation = ((PasswordBox)sender).Password;

        /// <summary>
        /// Set password to the logon object
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void PasswordTextBox_OnPasswordChanged(object sender, RoutedEventArgs e)
        {
            _customerLogin.Password = ((PasswordBox)sender).Password;
        }

        private void Window_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Return)
            {
                ProcessLogin();
            }
        }
    }
}
