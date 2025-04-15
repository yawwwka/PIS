using PIS.Services;
using System;
using System.Windows.Forms;

namespace PIS.Forms
{
    public partial class SpecialistForm : Form
    {
        private readonly ApplicationService _applicationService;

        private DataGridView dgvApplications;

        public SpecialistForm(ApplicationService applicationService)
        {
            InitializeComponent();
            _applicationService = applicationService;
            LoadApplications();
        }

        private void LoadApplications()
        {
            dgvApplications.DataSource = _applicationService.GetAllApplications();
        }

        private void dgvApplications_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                var statusForm = new ChangeStatusForm(_applicationService, e.RowIndex);
                if (statusForm.ShowDialog() == DialogResult.OK)
                {
                    LoadApplications();
                }
            }
        }
    }
}