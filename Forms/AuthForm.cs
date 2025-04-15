using PIS.Forms;
using PIS.Services;
using System;
using System.Diagnostics;
using System.Windows.Forms;

namespace PIS
{
    public partial class AuthForm : Form
    {
        private readonly UserService _userService;
        private readonly App _app;

        public AuthForm(UserService userService, App app)
        {
            InitializeComponent();
            InitializeLogic();
            _userService = userService;
            _app = app;
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            var user = _userService.Authenticate(emailLoginBox.Text, passwordLoginBox.Text);
            if (user == null)
            {
                MessageBox.Show("Invalid credentials");
                return;
            }

            this.Hide();

            switch (user.Role)
            {
                case Models.Enums.UserRole.Admin:
                    _app.ShowAdminMenu(user);
                    break;
                case Models.Enums.UserRole.Landlord:
                    _app.ShowLandlordMenu(user);
                    break;
                case Models.Enums.UserRole.Specialist:
                    _app.ShowSpecialistMenu(user);
                    break;
            }
        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            var registrationForm = new RegistrationForm(_userService);
            registrationForm.ShowDialog();
        }
    }
}