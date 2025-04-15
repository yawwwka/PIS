using PIS.Models.Enums;
using PIS.Models;
using PIS.Services;
using System;
using System.Windows.Forms;

namespace PIS.Forms
{
    public partial class RegistrationForm : Form
    {
        private readonly UserService _userService;

        public RegistrationForm(UserService userService)
        {
            InitializeComponent();
            _userService = userService;
        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            var user = new User
            {
                Name = nameBox.Text,
                Email = emailBox.Text,
                Password = passwordBox.Text
            };

            string message;
            if (_userService.RegisterUser(user, out message))
            {
                MessageBox.Show(message);
                this.Close();
            }
            else 
            {
                MessageBox.Show(message);
            }
        }
    }
}