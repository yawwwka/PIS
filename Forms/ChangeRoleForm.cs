using System;
using System.Windows.Forms;
using PIS.Models.Enums;
using PIS.Models;
using PIS.Services;

namespace PIS.Forms
{
    public partial class ChangeRoleForm : Form
    {
        private readonly User _user;
        private readonly UserService _userService;

        public ChangeRoleForm(UserService userService, User user)
        {
            InitializeComponent();
            InitializeLogic();

            _user = user;
            _userService = userService;
        }

        private void btnAdmin_Click(object sender, EventArgs e) => 
            _userService.ChangeUserRole(_user, UserRole.Admin, this);
        private void btnSpecialist_Click(object sender, EventArgs e) => 
            _userService.ChangeUserRole(_user, UserRole.Specialist, this);
        private void btnLandlord_Click(object sender, EventArgs e) => 
            _userService.ChangeUserRole(_user, UserRole.Landlord, this);
    }
}
