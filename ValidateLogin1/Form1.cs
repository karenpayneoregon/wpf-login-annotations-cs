using System;
using System.Collections.Generic;
using System.Windows.Forms;
using ValidateLogin1.Classes;
using ValidationLibrary;
using ValidationLibrary.ExtensionMethods;

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

        private void CancelButton_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
