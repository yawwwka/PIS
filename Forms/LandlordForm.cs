using PIS.Models;
using PIS.Services;
using System;
using System.Windows.Forms;

namespace PIS.Forms
{
    public partial class LandlordForm : Form
    {
        private readonly UserService _userService;
        private readonly ApplicationService _applicationService;
        private readonly User _currentUser;

        private DataGridView dgvApplications;
        private TextBox ownerNameBox;
        private TextBox ownerPassportBox;
        private TextBox ownerAddressBox;
        private TextBox migrantNameBox;
        private TextBox migrantPassportBox;
        private TextBox migrantVisaBox;
        private TextBox migrantCardBox;

        public LandlordForm(UserService userService, ApplicationService applicationService, User currentUser)
        {
            InitializeComponent();
            _userService = userService;
            _applicationService = applicationService;
            _currentUser = currentUser;
            LoadApplications();
        }

        private void LoadApplications()
        {
            dgvApplications.DataSource = _applicationService.GetApplicationsByUser(_currentUser.Email);
        }

        private void btnSubmitApplication_Click(object sender, EventArgs e)
        {
            var application = new UserApplication
            {
                OwnerEmail = _currentUser.Email,
                OwnerName = ownerNameBox.Text,
                OwnerPassport = ownerPassportBox.Text,
                Address = ownerAddressBox.Text,
                MigrantName = migrantNameBox.Text,
                MigrantPassport = migrantPassportBox.Text,
                VisaNumber = migrantVisaBox.Text,
                MigrationCard = migrantCardBox.Text
            };

            _applicationService.SubmitApplication(application);
            MessageBox.Show("Application submitted successfully");
            LoadApplications();
        }
    }
}