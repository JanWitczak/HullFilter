
namespace HullFilter
{
    partial class HullSettings
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
            this.ButtonCancel = new System.Windows.Forms.Button();
            this.ButtonAccept = new System.Windows.Forms.Button();
            this.HullView = new System.Windows.Forms.DataGridView();
            this.ButtonDeselect = new System.Windows.Forms.Button();
            this.ButtonSelect = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.HullView)).BeginInit();
            this.SuspendLayout();
            // 
            // ButtonCancel
            // 
            this.ButtonCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.ButtonCancel.Location = new System.Drawing.Point(12, 426);
            this.ButtonCancel.Name = "ButtonCancel";
            this.ButtonCancel.Size = new System.Drawing.Size(75, 23);
            this.ButtonCancel.TabIndex = 2;
            this.ButtonCancel.Text = "Cancel";
            this.ButtonCancel.UseVisualStyleBackColor = true;
            // 
            // ButtonAccept
            // 
            this.ButtonAccept.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.ButtonAccept.Location = new System.Drawing.Point(336, 427);
            this.ButtonAccept.Name = "ButtonAccept";
            this.ButtonAccept.Size = new System.Drawing.Size(75, 22);
            this.ButtonAccept.TabIndex = 3;
            this.ButtonAccept.Text = "Accept";
            this.ButtonAccept.UseVisualStyleBackColor = true;
            // 
            // HullView
            // 
            this.HullView.AllowUserToAddRows = false;
            this.HullView.AllowUserToDeleteRows = false;
            this.HullView.AllowUserToResizeColumns = false;
            this.HullView.AllowUserToResizeRows = false;
            this.HullView.BackgroundColor = System.Drawing.Color.White;
            this.HullView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.HullView.ColumnHeadersVisible = false;
            this.HullView.Location = new System.Drawing.Point(12, 12);
            this.HullView.MultiSelect = false;
            this.HullView.Name = "HullView";
            this.HullView.RowHeadersVisible = false;
            this.HullView.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.HullView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.HullView.Size = new System.Drawing.Size(399, 409);
            this.HullView.TabIndex = 4;
            // 
            // ButtonDeselect
            // 
            this.ButtonDeselect.Location = new System.Drawing.Point(93, 426);
            this.ButtonDeselect.Name = "ButtonDeselect";
            this.ButtonDeselect.Size = new System.Drawing.Size(75, 23);
            this.ButtonDeselect.TabIndex = 5;
            this.ButtonDeselect.Text = "Deselect All";
            this.ButtonDeselect.UseVisualStyleBackColor = true;
            this.ButtonDeselect.Click += new System.EventHandler(this.ButtonDeselect_Click);
            // 
            // ButtonSelect
            // 
            this.ButtonSelect.Location = new System.Drawing.Point(174, 426);
            this.ButtonSelect.Name = "ButtonSelect";
            this.ButtonSelect.Size = new System.Drawing.Size(75, 23);
            this.ButtonSelect.TabIndex = 6;
            this.ButtonSelect.Text = "Select All";
            this.ButtonSelect.UseVisualStyleBackColor = true;
            this.ButtonSelect.Click += new System.EventHandler(this.ButtonSelect_Click);
            // 
            // HullSettings
            // 
            this.AcceptButton = this.ButtonAccept;
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.CancelButton = this.ButtonCancel;
            this.ClientSize = new System.Drawing.Size(423, 461);
            this.Controls.Add(this.ButtonSelect);
            this.Controls.Add(this.ButtonDeselect);
            this.Controls.Add(this.HullView);
            this.Controls.Add(this.ButtonAccept);
            this.Controls.Add(this.ButtonCancel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "HullSettings";
            this.ShowIcon = false;
            this.Text = "Hull Filter";
            this.TopMost = true;
            ((System.ComponentModel.ISupportInitialize)(this.HullView)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button ButtonCancel;
        private System.Windows.Forms.Button ButtonAccept;
        public System.Windows.Forms.DataGridView HullView;
        private System.Windows.Forms.Button ButtonDeselect;
        private System.Windows.Forms.Button ButtonSelect;
    }
}