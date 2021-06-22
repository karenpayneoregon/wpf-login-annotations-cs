using System;
using System.Collections.Generic;
using System.ComponentModel;
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
//using ValidationLibrary.ExtensionMethods;
using static ValidateLoginCore.Classes.CommonDialogs;

namespace ValidateLoginCore
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private int _retryCount = 0;

        public static RoutedCommand ContinueRoutedCommand = new RoutedCommand();
        public static RoutedCommand ExitRoutedCommand = new RoutedCommand();

        private readonly CustomerLogin _customerLogin = new CustomerLogin();
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
                    MessageBox.Show("Too many attempts");
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
            e.CanExecute = _retryCount < 3;

        private void ExitApplicationCommandOnExecute(object sender, ExecutedRoutedEventArgs e)
        {
            if (Question("Cancel login?"))
            {
                Application.Current.Shutdown();
            }
        }

        private void ApplicationExitCanExecute(object sender, CanExecuteRoutedEventArgs e) =>
            e.CanExecute = true;

        private void MainWindow_OnClosing(object sender, CancelEventArgs e)
        {

            if (Environment.UserName == "PayneK")
            {
                Application.Current.Shutdown();
            }
            else
            {
                if (Question("Cancel login?"))
                {
                    Application.Current.Shutdown();
                }
                else
                {
                    e.Cancel = true;
                }

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
