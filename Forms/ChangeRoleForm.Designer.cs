namespace PIS.Forms
{
    partial class ChangeRoleForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.changeLabel = new System.Windows.Forms.Label();
            this.btnAdmin = new System.Windows.Forms.Button();
            this.btnSpecialist = new System.Windows.Forms.Button();
            this.btnLandlord = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.changeLabel.AutoSize = true;
            this.changeLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.changeLabel.Location = new System.Drawing.Point(51, 9);
            this.changeLabel.Name = "changeLabel";
            this.changeLabel.Size = new System.Drawing.Size(160, 25);
            this.changeLabel.TabIndex = 0;
            this.changeLabel.Text = "Выберите роль:";
            // 
            // btnAdmin
            // 
            this.btnAdmin.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnAdmin.Location = new System.Drawing.Point(12, 37);
            this.btnAdmin.Name = "btnAdmin";
            this.btnAdmin.Size = new System.Drawing.Size(75, 39);
            this.btnAdmin.TabIndex = 1;
            this.btnAdmin.Text = "Admin";
            this.btnAdmin.UseVisualStyleBackColor = true;
            // 
            // btnSpecialist
            // 
            this.btnSpecialist.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnSpecialist.Location = new System.Drawing.Point(93, 37);
            this.btnSpecialist.Name = "btnSpecialist";
            this.btnSpecialist.Size = new System.Drawing.Size(75, 39);
            this.btnSpecialist.TabIndex = 2;
            this.btnSpecialist.Text = "Specialist";
            this.btnSpecialist.UseVisualStyleBackColor = true;
            // 
            // button3
            // 
            this.btnLandlord.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnLandlord.Location = new System.Drawing.Point(174, 37);
            this.btnLandlord.Name = "btnLandlord";
            this.btnLandlord.Size = new System.Drawing.Size(75, 39);
            this.btnLandlord.TabIndex = 3;
            this.btnLandlord.Text = "Landlord";
            this.btnLandlord.UseVisualStyleBackColor = true;
            // 
            // ChangeRoleForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(258, 88);
            this.Controls.Add(this.btnLandlord);
            this.Controls.Add(this.btnSpecialist);
            this.Controls.Add(this.btnAdmin);
            this.Controls.Add(this.changeLabel);
            this.Name = "Смена роли";
            this.Text = "Смена роли";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label changeLabel;
        private System.Windows.Forms.Button btnAdmin;
        private System.Windows.Forms.Button btnSpecialist;
        private System.Windows.Forms.Button btnLandlord;

        private void InitializeLogic()
        {
            btnAdmin.Click += btnAdmin_Click;
            btnSpecialist.Click += btnSpecialist_Click;
            btnLandlord.Click += btnLandlord_Click;
        }
    }
}