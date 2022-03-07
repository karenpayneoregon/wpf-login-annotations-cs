using System;
using System.Collections.Generic;
using System.Windows.Forms;
using ValidateLogin.Classes;
using ValidationLibrary;
using ValidationLibrary.ExtensionMethods;
using CustomerLogin = ValidateLogin1.Classes.CustomerLogin;

namespace ValidateLogin1
{
    public partial class Form1 : Form
    {
        private int _retryCount = 0;
        private readonly BindingSource _bindingSource = new BindingSource();

        public Form1()
        {
            InitializeComponent();

            _bindingSource.DataSource = new List<CustomerLogin>() {new CustomerLogin()};

            UserNameTextBox.DataBindings.Add("Text", _bindingSource, "UserName", 
                false, DataSourceUpdateMode.OnPropertyChanged);

            PasswordTextBox.DataBindings.Add("Text", _bindingSource, "Password", 
                false, DataSourceUpdateMode.OnPropertyChanged);

            ConfirmPasswordTextBox.DataBindings.Add("Text", _bindingSource, "PasswordConfirmation",
                false, DataSourceUpdateMode.OnPropertyChanged);
            
        }

        private void ProcessLogin()
        {
            var customerLogin = (CustomerLogin) _bindingSource.Current;

            EntityValidationResult validationResult = ValidationHelper.ValidateEntity(customerLogin);

            if (validationResult.HasError)
            {
                _retryCount += 1;

                if (_retryCount >= 3)
                {
                    MessageBox.Show("Too many attempts");
                    Application.Exit();
                }
                else
                {
                    MessageBox.Show(validationResult.ErrorMessageList());
                }
            }
            else
            {
                if (DataOperations.UserExists(customerLogin.UserName))
                {
                    Console.WriteLine("User exists");
                }
                else
                {
                    /*
                     * This method is not implemented
                     * For a real app, you should not pass around a password
                     *
                     * See the following for one way to word with passwords
                     * https://stackoverflow.com/questions/17837862/encrypt-in-sql-decrypt-in-net-how-i-made-it
                     */
                    DataOperations.AddUser(customerLogin.UserName, customerLogin.Password);
                }
                Hide();

                var workForm = new WorkForm();
                workForm.ShowDialog();

                Close();
            }

        }

        private void ContinueButton_Click(object sender, EventArgs e)
        {
            ProcessLogin();
        }
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData != (Keys.Enter)) return base.ProcessCmdKey(ref msg, keyData);
            ProcessLogin();

            return true;

        }

        private void CancellationButton_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
