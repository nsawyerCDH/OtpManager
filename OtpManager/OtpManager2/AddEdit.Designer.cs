namespace OtpManager2
{
    partial class AddEdit
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
            this.label1 = new System.Windows.Forms.Label();
            this.nameTextBox = new System.Windows.Forms.TextBox();
            this.hotKeyKeyTextBox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.valueTextBox = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.valueTypeOTPRadioButton = new System.Windows.Forms.RadioButton();
            this.label4 = new System.Windows.Forms.Label();
            this.valueTypeStringRadioButton = new System.Windows.Forms.RadioButton();
            this.saveChangesButton = new System.Windows.Forms.Button();
            this.hotKeyModifierComboBox = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(22, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(38, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Name:";
            // 
            // nameTextBox
            // 
            this.nameTextBox.Location = new System.Drawing.Point(25, 35);
            this.nameTextBox.Name = "nameTextBox";
            this.nameTextBox.Size = new System.Drawing.Size(277, 20);
            this.nameTextBox.TabIndex = 1;
            // 
            // hotKeyKeyTextBox
            // 
            this.hotKeyKeyTextBox.Location = new System.Drawing.Point(167, 84);
            this.hotKeyKeyTextBox.Name = "hotKeyKeyTextBox";
            this.hotKeyKeyTextBox.Size = new System.Drawing.Size(135, 20);
            this.hotKeyKeyTextBox.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(22, 68);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(45, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Hot Key";
            // 
            // valueTextBox
            // 
            this.valueTextBox.Location = new System.Drawing.Point(25, 133);
            this.valueTextBox.Name = "valueTextBox";
            this.valueTextBox.Size = new System.Drawing.Size(277, 20);
            this.valueTextBox.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(22, 117);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(34, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Value";
            // 
            // valueTypeOTPRadioButton
            // 
            this.valueTypeOTPRadioButton.AutoSize = true;
            this.valueTypeOTPRadioButton.Location = new System.Drawing.Point(95, 182);
            this.valueTypeOTPRadioButton.Name = "valueTypeOTPRadioButton";
            this.valueTypeOTPRadioButton.Size = new System.Drawing.Size(47, 17);
            this.valueTypeOTPRadioButton.TabIndex = 6;
            this.valueTypeOTPRadioButton.TabStop = true;
            this.valueTypeOTPRadioButton.Text = "OTP";
            this.valueTypeOTPRadioButton.UseVisualStyleBackColor = true;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(22, 166);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(64, 13);
            this.label4.TabIndex = 7;
            this.label4.Text = "Value Type:";
            // 
            // valueTypeStringRadioButton
            // 
            this.valueTypeStringRadioButton.AutoSize = true;
            this.valueTypeStringRadioButton.Location = new System.Drawing.Point(167, 182);
            this.valueTypeStringRadioButton.Name = "valueTypeStringRadioButton";
            this.valueTypeStringRadioButton.Size = new System.Drawing.Size(52, 17);
            this.valueTypeStringRadioButton.TabIndex = 8;
            this.valueTypeStringRadioButton.TabStop = true;
            this.valueTypeStringRadioButton.Text = "String";
            this.valueTypeStringRadioButton.UseVisualStyleBackColor = true;
            // 
            // saveChangesButton
            // 
            this.saveChangesButton.AutoSize = true;
            this.saveChangesButton.Location = new System.Drawing.Point(215, 217);
            this.saveChangesButton.Name = "saveChangesButton";
            this.saveChangesButton.Size = new System.Drawing.Size(87, 23);
            this.saveChangesButton.TabIndex = 9;
            this.saveChangesButton.Text = "Save Changes";
            this.saveChangesButton.UseVisualStyleBackColor = true;
            this.saveChangesButton.Click += new System.EventHandler(this.saveChangesButton_Click);
            // 
            // hotKeyModifierComboBox
            // 
            this.hotKeyModifierComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.hotKeyModifierComboBox.FormattingEnabled = true;
            this.hotKeyModifierComboBox.Location = new System.Drawing.Point(25, 84);
            this.hotKeyModifierComboBox.Name = "hotKeyModifierComboBox";
            this.hotKeyModifierComboBox.Size = new System.Drawing.Size(121, 21);
            this.hotKeyModifierComboBox.TabIndex = 10;
            // 
            // AddEdit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(330, 256);
            this.Controls.Add(this.hotKeyModifierComboBox);
            this.Controls.Add(this.saveChangesButton);
            this.Controls.Add(this.valueTypeStringRadioButton);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.valueTypeOTPRadioButton);
            this.Controls.Add(this.valueTextBox);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.hotKeyKeyTextBox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.nameTextBox);
            this.Controls.Add(this.label1);
            this.Name = "AddEdit";
            this.Text = "Add/Edit Item";
            this.Load += new System.EventHandler(this.AddEdit_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox nameTextBox;
        private System.Windows.Forms.TextBox hotKeyKeyTextBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox valueTextBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.RadioButton valueTypeOTPRadioButton;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.RadioButton valueTypeStringRadioButton;
        private System.Windows.Forms.Button saveChangesButton;
        private System.Windows.Forms.ComboBox hotKeyModifierComboBox;
    }
}