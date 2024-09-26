namespace OtpManager2
{
    partial class Startup
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
            if (disposing)
            {
                // Clean up any components being used.
                if (trayIcon != null)
                {
                    trayIcon.Dispose();
                }
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
            this.components = new System.ComponentModel.Container();
            this.configViewerGridView = new System.Windows.Forms.DataGridView();
            this.idColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nameColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.hotKeyColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.valueColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.isOTPColumn = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.editColumn = new System.Windows.Forms.DataGridViewImageColumn();
            this.deleteColumn = new System.Windows.Forms.DataGridViewImageColumn();
            this.addNewItemButton = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label5 = new System.Windows.Forms.Label();
            this.filePathTextBox = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.numRegisteredItemsTextBox = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.typeCharDelayMsTextBox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.typeBeforeDelayMsTextBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.fileVersionTextBox = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.contextMenuStrip2 = new System.Windows.Forms.ContextMenuStrip(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.configViewerGridView)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // configViewerGridView
            // 
            this.configViewerGridView.AllowUserToAddRows = false;
            this.configViewerGridView.AllowUserToDeleteRows = false;
            this.configViewerGridView.AllowUserToResizeColumns = false;
            this.configViewerGridView.AllowUserToResizeRows = false;
            this.configViewerGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.configViewerGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.idColumn,
            this.nameColumn,
            this.hotKeyColumn,
            this.valueColumn,
            this.isOTPColumn,
            this.editColumn,
            this.deleteColumn});
            this.configViewerGridView.Location = new System.Drawing.Point(31, 213);
            this.configViewerGridView.Name = "configViewerGridView";
            this.configViewerGridView.RowHeadersVisible = false;
            this.configViewerGridView.Size = new System.Drawing.Size(560, 291);
            this.configViewerGridView.TabIndex = 0;
            this.configViewerGridView.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.configViewerGridView_CellClick);
            // 
            // idColumn
            // 
            this.idColumn.Frozen = true;
            this.idColumn.HeaderText = "idColumn";
            this.idColumn.Name = "idColumn";
            this.idColumn.ReadOnly = true;
            this.idColumn.Visible = false;
            // 
            // nameColumn
            // 
            this.nameColumn.Frozen = true;
            this.nameColumn.HeaderText = "Name";
            this.nameColumn.Name = "nameColumn";
            this.nameColumn.ReadOnly = true;
            this.nameColumn.Width = 125;
            // 
            // hotKeyColumn
            // 
            this.hotKeyColumn.Frozen = true;
            this.hotKeyColumn.HeaderText = "Hot Key";
            this.hotKeyColumn.Name = "hotKeyColumn";
            this.hotKeyColumn.ReadOnly = true;
            this.hotKeyColumn.Width = 110;
            // 
            // valueColumn
            // 
            this.valueColumn.Frozen = true;
            this.valueColumn.HeaderText = "Value";
            this.valueColumn.Name = "valueColumn";
            this.valueColumn.ReadOnly = true;
            this.valueColumn.Width = 185;
            // 
            // isOTPColumn
            // 
            this.isOTPColumn.Frozen = true;
            this.isOTPColumn.HeaderText = "Is OTP";
            this.isOTPColumn.Name = "isOTPColumn";
            this.isOTPColumn.ReadOnly = true;
            this.isOTPColumn.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.isOTPColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.isOTPColumn.Width = 50;
            // 
            // editColumn
            // 
            this.editColumn.Frozen = true;
            this.editColumn.HeaderText = "";
            this.editColumn.Image = global::OtpManager2.Properties.Resources.edit;
            this.editColumn.ImageLayout = System.Windows.Forms.DataGridViewImageCellLayout.Zoom;
            this.editColumn.Name = "editColumn";
            this.editColumn.ReadOnly = true;
            this.editColumn.Width = 30;
            // 
            // deleteColumn
            // 
            this.deleteColumn.Frozen = true;
            this.deleteColumn.HeaderText = "";
            this.deleteColumn.Image = global::OtpManager2.Properties.Resources.delete;
            this.deleteColumn.ImageLayout = System.Windows.Forms.DataGridViewImageCellLayout.Zoom;
            this.deleteColumn.Name = "deleteColumn";
            this.deleteColumn.ReadOnly = true;
            this.deleteColumn.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.deleteColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.deleteColumn.Width = 30;
            // 
            // addNewItemButton
            // 
            this.addNewItemButton.AutoSize = true;
            this.addNewItemButton.Location = new System.Drawing.Point(509, 184);
            this.addNewItemButton.Name = "addNewItemButton";
            this.addNewItemButton.Size = new System.Drawing.Size(82, 23);
            this.addNewItemButton.TabIndex = 1;
            this.addNewItemButton.Text = "Add new Item";
            this.addNewItemButton.UseVisualStyleBackColor = true;
            this.addNewItemButton.Click += new System.EventHandler(this.addNewItemButton_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.filePathTextBox);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.numRegisteredItemsTextBox);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.typeCharDelayMsTextBox);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.typeBeforeDelayMsTextBox);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.fileVersionTextBox);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(598, 166);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Configuration File Properties";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(16, 16);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(51, 13);
            this.label5.TabIndex = 9;
            this.label5.Text = "File Path:";
            // 
            // filePathTextBox
            // 
            this.filePathTextBox.Location = new System.Drawing.Point(19, 32);
            this.filePathTextBox.Name = "filePathTextBox";
            this.filePathTextBox.Size = new System.Drawing.Size(560, 20);
            this.filePathTextBox.TabIndex = 8;
            this.filePathTextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TextBox_KeyPress);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(299, 63);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(99, 13);
            this.label4.TabIndex = 7;
            this.label4.Text = "# Registered Items:";
            // 
            // numRegisteredItemsTextBox
            // 
            this.numRegisteredItemsTextBox.Location = new System.Drawing.Point(302, 79);
            this.numRegisteredItemsTextBox.Name = "numRegisteredItemsTextBox";
            this.numRegisteredItemsTextBox.Size = new System.Drawing.Size(277, 20);
            this.numRegisteredItemsTextBox.TabIndex = 6;
            this.numRegisteredItemsTextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TextBox_KeyPress);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(299, 112);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(136, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Type Character Delay (Ms):";
            // 
            // typeCharDelayMsTextBox
            // 
            this.typeCharDelayMsTextBox.Location = new System.Drawing.Point(302, 128);
            this.typeCharDelayMsTextBox.Name = "typeCharDelayMsTextBox";
            this.typeCharDelayMsTextBox.Size = new System.Drawing.Size(277, 20);
            this.typeCharDelayMsTextBox.TabIndex = 4;
            this.typeCharDelayMsTextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TextBox_KeyPress);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(16, 112);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(121, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Type Before Delay (Ms):";
            // 
            // typeBeforeDelayMsTextBox
            // 
            this.typeBeforeDelayMsTextBox.Location = new System.Drawing.Point(19, 128);
            this.typeBeforeDelayMsTextBox.Name = "typeBeforeDelayMsTextBox";
            this.typeBeforeDelayMsTextBox.Size = new System.Drawing.Size(277, 20);
            this.typeBeforeDelayMsTextBox.TabIndex = 2;
            this.typeBeforeDelayMsTextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TextBox_KeyPress);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(16, 63);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(64, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "File Version:";
            // 
            // fileVersionTextBox
            // 
            this.fileVersionTextBox.Location = new System.Drawing.Point(19, 79);
            this.fileVersionTextBox.Name = "fileVersionTextBox";
            this.fileVersionTextBox.Size = new System.Drawing.Size(277, 20);
            this.fileVersionTextBox.TabIndex = 0;
            this.fileVersionTextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TextBox_KeyPress);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(28, 194);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(100, 13);
            this.label6.TabIndex = 10;
            this.label6.Text = "Configuration Items:";
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(61, 4);
            // 
            // contextMenuStrip2
            // 
            this.contextMenuStrip2.Name = "contextMenuStrip2";
            this.contextMenuStrip2.Size = new System.Drawing.Size(61, 4);
            // 
            // Startup
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(623, 527);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.addNewItemButton);
            this.Controls.Add(this.configViewerGridView);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(639, 566);
            this.MinimumSize = new System.Drawing.Size(639, 566);
            this.Name = "Startup";
            this.Text = "Startup";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Startup_FormClosing);
            this.Load += new System.EventHandler(this.Startup_Load);
            ((System.ComponentModel.ISupportInitialize)(this.configViewerGridView)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView configViewerGridView;
        private System.Windows.Forms.Button addNewItemButton;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox typeBeforeDelayMsTextBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox fileVersionTextBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox typeCharDelayMsTextBox;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox numRegisteredItemsTextBox;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox filePathTextBox;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.DataGridViewTextBoxColumn idColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn nameColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn hotKeyColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn valueColumn;
        private System.Windows.Forms.DataGridViewCheckBoxColumn isOTPColumn;
        private System.Windows.Forms.DataGridViewImageColumn editColumn;
        private System.Windows.Forms.DataGridViewImageColumn deleteColumn;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip2;
    }
}

