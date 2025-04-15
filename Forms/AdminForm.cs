using PIS.Models;
using PIS.Services;
using System;
using System.Diagnostics;
using System.Linq;
using System.Windows.Forms;

namespace PIS.Forms
{
    public partial class AdminForm : Form
    {
        private readonly UserService _userService;
        private User currentUser;

        public AdminForm(UserService userService, ApplicationService applicationService, User currentUser)
        {
            InitializeComponent();
            InitializeLogic();
            _userService = userService;
            LoadUsers();
            this.currentUser = currentUser;
        }

        private void LoadUsers()
        {
            dgvUsers.DataSource = null;
            dgvUsers.DataSource = _userService.GetAllUsers();
            dgvUsers.AutoGenerateColumns = false;
        }

        private void btnCreate_Click(object sender, EventArgs e)
        {
            var creationForm = new CreationForm(_userService);
            creationForm.ShowDialog();
            LoadUsers();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            var userToDelete = (User)dgvUsers.CurrentRow.DataBoundItem;

            try
            {
                var confirmResult = MessageBox.Show(
                    $"Вы уверены, что хотите удалить пользователя {userToDelete.Name}?",
                    "Подтверждение удаления",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question);

                if (confirmResult == DialogResult.Yes)
                {
                    _userService.DeleteUser(userToDelete);
                    LoadUsers();

                    MessageBox.Show("Пользователь успешно удален", "Успех",
                                  MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при удалении пользователя: {ex.Message}", "Ошибка",
                               MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnChangeRole_Click(object sender, EventArgs e)
        {
            var userToChangeRole = (User)dgvUsers.CurrentRow.DataBoundItem;
            var confirmResult = new ChangeRoleForm(_userService, userToChangeRole);
            confirmResult.ShowDialog();
            LoadUsers();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            LoadUsers();
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            if (currentUser != null)
            {
                _userService.SetUserOnlineStatus(currentUser, false);

                _userService.UpdateLastActivity(currentUser);
            }     

            base.OnFormClosing(e);
        }
    }
}
