namespace detectVideoAppEF
{
    partial class MonitoringReportForm
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
            this.showVideosCheckBox = new System.Windows.Forms.CheckBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.fromDateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.monitoringReportBtn = new System.Windows.Forms.Button();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.toDateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.extensionsComboBox = new System.Windows.Forms.ComboBox();
            this.mediaFilesgroupBox = new System.Windows.Forms.GroupBox();
            this.showPhotosCheckBox = new System.Windows.Forms.CheckBox();
            this.monitoringReportDataGridView = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.mediaFilesgroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.monitoringReportDataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Location = new System.Drawing.Point(-8, 13);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.showVideosCheckBox);
            this.splitContainer1.Panel1.Controls.Add(this.groupBox2);
            this.splitContainer1.Panel1.Controls.Add(this.monitoringReportBtn);
            this.splitContainer1.Panel1.Controls.Add(this.groupBox3);
            this.splitContainer1.Panel1.Controls.Add(this.groupBox4);
            this.splitContainer1.Panel1.Controls.Add(this.mediaFilesgroupBox);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.monitoringReportDataGridView);
            this.splitContainer1.Size = new System.Drawing.Size(1539, 605);
            this.splitContainer1.SplitterDistance = 246;
            this.splitContainer1.TabIndex = 1;
            // 
            // showVideosCheckBox
            // 
            this.showVideosCheckBox.AutoSize = true;
            this.showVideosCheckBox.Font = new System.Drawing.Font("Verdana", 8.25F);
            this.showVideosCheckBox.Location = new System.Drawing.Point(31, 215);
            this.showVideosCheckBox.Name = "showVideosCheckBox";
            this.showVideosCheckBox.Size = new System.Drawing.Size(77, 21);
            this.showVideosCheckBox.TabIndex = 1;
            this.showVideosCheckBox.Text = "Videos";
            this.showVideosCheckBox.UseVisualStyleBackColor = true;
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
            // monitoringReportBtn
            // 
            this.monitoringReportBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.monitoringReportBtn.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.monitoringReportBtn.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.monitoringReportBtn.Font = new System.Drawing.Font("Verdana", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.monitoringReportBtn.Location = new System.Drawing.Point(1417, 202);
            this.monitoringReportBtn.Name = "monitoringReportBtn";
            this.monitoringReportBtn.Size = new System.Drawing.Size(76, 26);
            this.monitoringReportBtn.TabIndex = 19;
            this.monitoringReportBtn.Text = "view";
            this.monitoringReportBtn.UseVisualStyleBackColor = false;
            this.monitoringReportBtn.Click += new System.EventHandler(this.MonitoringReportBtn_Click);
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
            this.groupBox4.Controls.Add(this.extensionsComboBox);
            this.groupBox4.Location = new System.Drawing.Point(23, 14);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(356, 55);
            this.groupBox4.TabIndex = 21;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Choose Extension";
            // 
            // extensionsComboBox
            // 
            this.extensionsComboBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.extensionsComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.extensionsComboBox.Font = new System.Drawing.Font("Verdana", 8.25F);
            this.extensionsComboBox.FormattingEnabled = true;
            this.extensionsComboBox.Items.AddRange(new object[] {
            "Camera Configuration",
            "Monitoring Report"});
            this.extensionsComboBox.Location = new System.Drawing.Point(25, 21);
            this.extensionsComboBox.Name = "extensionsComboBox";
            this.extensionsComboBox.Size = new System.Drawing.Size(311, 25);
            this.extensionsComboBox.TabIndex = 0;
            this.extensionsComboBox.SelectedIndexChanged += new System.EventHandler(this.ExtensionsComboBox_SelectedIndexChanged);
            // 
            // mediaFilesgroupBox
            // 
            this.mediaFilesgroupBox.Controls.Add(this.showPhotosCheckBox);
            this.mediaFilesgroupBox.Location = new System.Drawing.Point(23, 196);
            this.mediaFilesgroupBox.Name = "mediaFilesgroupBox";
            this.mediaFilesgroupBox.Size = new System.Drawing.Size(205, 44);
            this.mediaFilesgroupBox.TabIndex = 20;
            this.mediaFilesgroupBox.TabStop = false;
            this.mediaFilesgroupBox.Text = "Filter Media Files";
            // 
            // showPhotosCheckBox
            // 
            this.showPhotosCheckBox.AutoSize = true;
            this.showPhotosCheckBox.Font = new System.Drawing.Font("Verdana", 8.25F);
            this.showPhotosCheckBox.Location = new System.Drawing.Point(109, 18);
            this.showPhotosCheckBox.Name = "showPhotosCheckBox";
            this.showPhotosCheckBox.Size = new System.Drawing.Size(79, 21);
            this.showPhotosCheckBox.TabIndex = 2;
            this.showPhotosCheckBox.Text = "Photos";
            this.showPhotosCheckBox.UseVisualStyleBackColor = true;
            // 
            // monitoringReportDataGridView
            // 
            this.monitoringReportDataGridView.AllowUserToAddRows = false;
            this.monitoringReportDataGridView.AllowUserToDeleteRows = false;
            this.monitoringReportDataGridView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.monitoringReportDataGridView.BackgroundColor = System.Drawing.SystemColors.ControlLightLight;
            this.monitoringReportDataGridView.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.monitoringReportDataGridView.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.EnableAlwaysIncludeHeaderText;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Verdana", 8.25F);
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.monitoringReportDataGridView.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.monitoringReportDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Verdana", 8.25F);
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.monitoringReportDataGridView.DefaultCellStyle = dataGridViewCellStyle2;
            this.monitoringReportDataGridView.GridColor = System.Drawing.SystemColors.Control;
            this.monitoringReportDataGridView.Location = new System.Drawing.Point(10, 3);
            this.monitoringReportDataGridView.Name = "monitoringReportDataGridView";
            this.monitoringReportDataGridView.RowHeadersWidth = 51;
            this.monitoringReportDataGridView.RowTemplate.Height = 24;
            this.monitoringReportDataGridView.Size = new System.Drawing.Size(1511, 337);
            this.monitoringReportDataGridView.TabIndex = 0;
            this.monitoringReportDataGridView.VirtualMode = true;
            this.monitoringReportDataGridView.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.MonitoringReportDataGridView_CellContentClick);
            // 
            // MonitoringReportForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1523, 631);
            this.Controls.Add(this.splitContainer1);
            this.Name = "MonitoringReportForm";
            this.Text = "Monitoring Report";
            this.Load += new System.EventHandler(this.MonitoringReportForm_Load);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox4.ResumeLayout(false);
            this.mediaFilesgroupBox.ResumeLayout(false);
            this.mediaFilesgroupBox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.monitoringReportDataGridView)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.CheckBox showVideosCheckBox;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.DateTimePicker fromDateTimePicker;
        private System.Windows.Forms.Button monitoringReportBtn;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.DateTimePicker toDateTimePicker;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.ComboBox extensionsComboBox;
        private System.Windows.Forms.GroupBox mediaFilesgroupBox;
        private System.Windows.Forms.CheckBox showPhotosCheckBox;
        private System.Windows.Forms.DataGridView monitoringReportDataGridView;
    }
}