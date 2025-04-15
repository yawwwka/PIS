using PIS.Models;
using PIS.Services;
using PIS.Models.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PIS.Forms
{
    public partial class CreationForm : Form
    {
        private UserService _userService;

        public CreationForm(UserService userService)
        {
            _userService = userService;
            InitializeComponent();
            InitializeLogic();
            roleBox.DataSource = Enum.GetValues(typeof(UserRole));
        }

        private void btnCreate_Click(object sender, EventArgs e)
        {
            var user = new User
            {
                Name = nameBox.Text,
                Email = emailBox.Text,
                Password = passwordBox.Text,
                Role = (UserRole)Enum.Parse(typeof(UserRole), roleBox.Text)
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
