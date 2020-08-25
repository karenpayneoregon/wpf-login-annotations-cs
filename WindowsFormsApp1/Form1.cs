using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void ContinueButton_Click(object sender, EventArgs e)
        {

            var errorList = new List<string>();

            if (!Controls.OfType<TextBox>().Any(textBox => string.IsNullOrWhiteSpace(textBox.Text)))
            {

                if (UserNameTextBox.Text.Length < 6)
                {
                    errorList.Add("User name is to short");
                }

                if (PasswordTextBox.Text.Length < 6)
                {
                    errorList.Add("Password is to short");
                }

                if (ConfirmPasswordTextBox.Text.Length < 6)
                {
                    errorList.Add("Confirm password is to short");
                }

                if (!PasswordTextBox.Text.Equals(ConfirmPasswordTextBox.Text))
                {
                    errorList.Add("Passwords are not a match");
                }

                if (errorList.Count >0)
                {
                    errorList.Insert(0,"Validation issues");
                    var results = string.Join("\n",errorList.ToArray());

                    MessageBox.Show(results);
                }
                else
                {
                    MessageBox.Show(@"Open main form");
                }

            }
            else
            {
                MessageBox.Show(@"All fields are required");
            }
        }

        private void CancelButton_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
