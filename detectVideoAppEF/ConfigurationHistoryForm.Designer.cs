namespace detectVideoAppEF
{
    partial class ConfigurationHistoryForm
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.fromDateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.getConfigurationsHistoryBtn = new System.Windows.Forms.Button();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.toDateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.searchCameraConfigurationTxtBox = new System.Windows.Forms.TextBox();
            this.configurationsHistoryDataGridView = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.configurationsHistoryDataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Location = new System.Drawing.Point(8, 4);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.groupBox2);
            this.splitContainer1.Panel1.Controls.Add(this.getConfigurationsHistoryBtn);
            this.splitContainer1.Panel1.Controls.Add(this.groupBox3);
            this.splitContainer1.Panel1.Controls.Add(this.groupBox4);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.configurationsHistoryDataGridView);
            this.splitContainer1.Size = new System.Drawing.Size(1539, 605);
            this.splitContainer1.SplitterDistance = 246;
            this.splitContainer1.TabIndex = 1;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.fromDateTimePicker);
            this.groupBox2.Location = new System.Drawing.Point(23, 75);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(356, 57);
            this.groupBox2.TabIndex = 21;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "From";
            // 
            // fromDateTimePicker
            // 
            this.fromDateTimePicker.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.fromDateTimePicker.CustomFormat = "dd/MM/yyyy HH:mm:ss tt";
            this.fromDateTimePicker.Font = new System.Drawing.Font("Verdana", 8.25F);
            this.fromDateTimePicker.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.fromDateTimePicker.Location = new System.Drawing.Point(25, 21);
            this.fromDateTimePicker.Name = "fromDateTimePicker";
            this.fromDateTimePicker.Size = new System.Drawing.Size(311, 24);
            this.fromDateTimePicker.TabIndex = 12;
            // 
            // getConfigurationsHistoryBtn
            // 
            this.getConfigurationsHistoryBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.getConfigurationsHistoryBtn.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.getConfigurationsHistoryBtn.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.getConfigurationsHistoryBtn.Font = new System.Drawing.Font("Verdana", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.getConfigurationsHistoryBtn.Location = new System.Drawing.Point(1417, 202);
            this.getConfigurationsHistoryBtn.Name = "getConfigurationsHistoryBtn";
            this.getConfigurationsHistoryBtn.Size = new System.Drawing.Size(76, 26);
            this.getConfigurationsHistoryBtn.TabIndex = 19;
            this.getConfigurationsHistoryBtn.Text = "view";
            this.getConfigurationsHistoryBtn.UseVisualStyleBackColor = false;
            this.getConfigurationsHistoryBtn.Click += new System.EventHandler(this.GetConfigurationsHistoryBtn_Click);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.toDateTimePicker);
            this.groupBox3.Location = new System.Drawing.Point(23, 138);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(356, 52);
            this.groupBox3.TabIndex = 22;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "To";
            // 
            // toDateTimePicker
            // 
            this.toDateTimePicker.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.toDateTimePicker.CustomFormat = "dd/MM/yyyy HH:mm:ss tt";
            this.toDateTimePicker.Font = new System.Drawing.Font("Verdana", 8.25F);
            this.toDateTimePicker.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.toDateTimePicker.Location = new System.Drawing.Point(25, 17);
            this.toDateTimePicker.Name = "toDateTimePicker";
            this.toDateTimePicker.Size = new System.Drawing.Size(311, 24);
            this.toDateTimePicker.TabIndex = 13;
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.searchCameraConfigurationTxtBox);
            this.groupBox4.Location = new System.Drawing.Point(23, 14);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(356, 55);
            this.groupBox4.TabIndex = 21;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Camera Name";
            // 
            // searchCameraConfigurationTxtBox
            // 
            this.searchCameraConfigurationTxtBox.Location = new System.Drawing.Point(25, 18);
            this.searchCameraConfigurationTxtBox.Name = "searchCameraConfigurationTxtBox";
            this.searchCameraConfigurationTxtBox.Size = new System.Drawing.Size(311, 22);
            this.searchCameraConfigurationTxtBox.TabIndex = 0;
            // 
            // configurationsHistoryDataGridView
            // 
            this.configurationsHistoryDataGridView.AllowUserToAddRows = false;
            this.configurationsHistoryDataGridView.AllowUserToDeleteRows = false;
            this.configurationsHistoryDataGridView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.configurationsHistoryDataGridView.BackgroundColor = System.Drawing.SystemColors.ControlLightLight;
            this.configurationsHistoryDataGridView.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.configurationsHistoryDataGridView.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.EnableAlwaysIncludeHeaderText;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Verdana", 8.25F);
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.configurationsHistoryDataGridView.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.configurationsHistoryDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Verdana", 8.25F);
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.configurationsHistoryDataGridView.DefaultCellStyle = dataGridViewCellStyle2;
            this.configurationsHistoryDataGridView.GridColor = System.Drawing.SystemColors.Control;
            this.configurationsHistoryDataGridView.Location = new System.Drawing.Point(10, 3);
            this.configurationsHistoryDataGridView.Name = "configurationsHistoryDataGridView";
            this.configurationsHistoryDataGridView.RowHeadersWidth = 51;
            this.configurationsHistoryDataGridView.RowTemplate.Height = 24;
            this.configurationsHistoryDataGridView.Size = new System.Drawing.Size(1511, 337);
            this.configurationsHistoryDataGridView.TabIndex = 0;
            this.configurationsHistoryDataGridView.VirtualMode = true;
            // 
            // ConfigurationHistoryForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1560, 603);
            this.Controls.Add(this.splitContainer1);
            this.Name = "ConfigurationHistoryForm";
            this.Text = "Configurations History";
            this.Load += new System.EventHandler(this.ConfigurationHistoryForm_Load);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.configurationsHistoryDataGridView)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.DateTimePicker fromDateTimePicker;
        private System.Windows.Forms.Button getConfigurationsHistoryBtn;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.DateTimePicker toDateTimePicker;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.DataGridView configurationsHistoryDataGridView;
        private System.Windows.Forms.TextBox searchCameraConfigurationTxtBox;
    }
}