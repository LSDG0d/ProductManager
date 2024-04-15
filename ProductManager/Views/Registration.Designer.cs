namespace ProductManager.Views
{
    partial class Registration
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
            this.labelRegistrationName = new System.Windows.Forms.Label();
            this.labelRegistrationPassword = new System.Windows.Forms.Label();
            this.textBoxLoginRegistration = new System.Windows.Forms.TextBox();
            this.textBoxPasswordRegistration = new System.Windows.Forms.TextBox();
            this.buttonRegistration = new System.Windows.Forms.Button();
            this.linkLabelAuthorization = new System.Windows.Forms.LinkLabel();
            this.SuspendLayout();
            // 
            // labelRegistrationName
            // 
            this.labelRegistrationName.AutoSize = true;
            this.labelRegistrationName.Location = new System.Drawing.Point(32, 15);
            this.labelRegistrationName.Name = "labelRegistrationName";
            this.labelRegistrationName.Size = new System.Drawing.Size(36, 13);
            this.labelRegistrationName.TabIndex = 0;
            this.labelRegistrationName.Text = "Login:";
            // 
            // labelRegistrationPassword
            // 
            this.labelRegistrationPassword.AutoSize = true;
            this.labelRegistrationPassword.Location = new System.Drawing.Point(12, 41);
            this.labelRegistrationPassword.Name = "labelRegistrationPassword";
            this.labelRegistrationPassword.Size = new System.Drawing.Size(56, 13);
            this.labelRegistrationPassword.TabIndex = 1;
            this.labelRegistrationPassword.Text = "Password:";
            // 
            // textBoxLoginRegistration
            // 
            this.textBoxLoginRegistration.Location = new System.Drawing.Point(74, 12);
            this.textBoxLoginRegistration.Name = "textBoxLoginRegistration";
            this.textBoxLoginRegistration.Size = new System.Drawing.Size(198, 20);
            this.textBoxLoginRegistration.TabIndex = 2;
            // 
            // textBoxPasswordRegistration
            // 
            this.textBoxPasswordRegistration.Location = new System.Drawing.Point(74, 38);
            this.textBoxPasswordRegistration.Name = "textBoxPasswordRegistration";
            this.textBoxPasswordRegistration.Size = new System.Drawing.Size(198, 20);
            this.textBoxPasswordRegistration.TabIndex = 3;
            // 
            // buttonRegistration
            // 
            this.buttonRegistration.Location = new System.Drawing.Point(197, 64);
            this.buttonRegistration.Name = "buttonRegistration";
            this.buttonRegistration.Size = new System.Drawing.Size(75, 23);
            this.buttonRegistration.TabIndex = 4;
            this.buttonRegistration.Text = "Registration";
            this.buttonRegistration.UseVisualStyleBackColor = true;
            this.buttonRegistration.Click += new System.EventHandler(this.buttonRegistration_Click);
            // 
            // linkLabelAuthorization
            // 
            this.linkLabelAuthorization.AutoSize = true;
            this.linkLabelAuthorization.Location = new System.Drawing.Point(12, 69);
            this.linkLabelAuthorization.Name = "linkLabelAuthorization";
            this.linkLabelAuthorization.Size = new System.Drawing.Size(68, 13);
            this.linkLabelAuthorization.TabIndex = 5;
            this.linkLabelAuthorization.TabStop = true;
            this.linkLabelAuthorization.Text = "Authorization";
            this.linkLabelAuthorization.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabelAuthorization_LinkClicked);
            // 
            // Registration
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 101);
            this.Controls.Add(this.linkLabelAuthorization);
            this.Controls.Add(this.buttonRegistration);
            this.Controls.Add(this.textBoxPasswordRegistration);
            this.Controls.Add(this.textBoxLoginRegistration);
            this.Controls.Add(this.labelRegistrationPassword);
            this.Controls.Add(this.labelRegistrationName);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "Registration";
            this.Text = "Registration";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelRegistrationName;
        private System.Windows.Forms.Label labelRegistrationPassword;
        private System.Windows.Forms.TextBox textBoxLoginRegistration;
        private System.Windows.Forms.TextBox textBoxPasswordRegistration;
        private System.Windows.Forms.Button buttonRegistration;
        private System.Windows.Forms.LinkLabel linkLabelAuthorization;
    }
}