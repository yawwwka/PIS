using PIS.Services;
using System;
using System.Windows.Forms;

namespace PIS.Forms
{
    public partial class ChangeStatusForm : Form
    {
        private readonly ApplicationService _applicationService;
        private readonly int _applicationIndex;

        private ComboBox cmbStatus;

        public ChangeStatusForm(ApplicationService applicationService, int applicationIndex)
        {
            InitializeComponent();
            _applicationService = applicationService;
            _applicationIndex = applicationIndex;
            cmbStatus.Items.AddRange(new[] { "Pending", "Approved", "Rejected" });
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            var applications = _applicationService.GetAllApplications();
            if (_applicationIndex < applications.Count)
            {
                //applications[_applicationIndex].Status = cmbStatus.SelectedItem.ToString();
                DialogResult = DialogResult.OK;
                this.Close();
            }
        }
    }
}