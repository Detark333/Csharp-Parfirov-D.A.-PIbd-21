namespace AbstractStoreClientView
{
    partial class RegisterForm
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
            this.labelLogin = new System.Windows.Forms.Label();
            this.textBoxLogin = new System.Windows.Forms.TextBox();
            this.labelFirstPassword = new System.Windows.Forms.Label();
            this.labelFIO = new System.Windows.Forms.Label();
            this.textBoxPassword = new System.Windows.Forms.TextBox();
            this.textBoxFIO = new System.Windows.Forms.TextBox();
            this.buttonRegistr = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // labelLogin
            // 
            this.labelLogin.AutoSize = true;
            this.labelLogin.Location = new System.Drawing.Point(32, 23);
            this.labelLogin.Name = "labelLogin";
            this.labelLogin.Size = new System.Drawing.Size(74, 15);
            this.labelLogin.TabIndex = 0;
            this.labelLogin.Text = "Login(Email)";
            // 
            // textBoxLogin
            // 
            this.textBoxLogin.Location = new System.Drawing.Point(32, 57);
            this.textBoxLogin.Name = "textBoxLogin";
            this.textBoxLogin.Size = new System.Drawing.Size(218, 23);
            this.textBoxLogin.TabIndex = 1;
            // 
            // labelFirstPassword
            // 
            this.labelFirstPassword.AutoSize = true;
            this.labelFirstPassword.Location = new System.Drawing.Point(32, 102);
            this.labelFirstPassword.Name = "labelFirstPassword";
            this.labelFirstPassword.Size = new System.Drawing.Size(82, 15);
            this.labelFirstPassword.TabIndex = 0;
            this.labelFirstPassword.Text = "First Password";
            // 
            // labelFIO
            // 
            this.labelFIO.AutoSize = true;
            this.labelFIO.Location = new System.Drawing.Point(32, 188);
            this.labelFIO.Name = "labelFIO";
            this.labelFIO.Size = new System.Drawing.Size(25, 15);
            this.labelFIO.TabIndex = 2;
            this.labelFIO.Text = "FIO";
            // 
            // textBoxPassword
            // 
            this.textBoxPassword.Location = new System.Drawing.Point(32, 136);
            this.textBoxPassword.Name = "textBoxPassword";
            this.textBoxPassword.Size = new System.Drawing.Size(218, 23);
            this.textBoxPassword.TabIndex = 3;
            // 
            // textBoxFIO
            // 
            this.textBoxFIO.Location = new System.Drawing.Point(32, 224);
            this.textBoxFIO.Name = "textBoxFIO";
            this.textBoxFIO.Size = new System.Drawing.Size(218, 23);
            this.textBoxFIO.TabIndex = 4;
            // 
            // buttonRegistr
            // 
            this.buttonRegistr.Location = new System.Drawing.Point(32, 282);
            this.buttonRegistr.Name = "buttonRegistr";
            this.buttonRegistr.Size = new System.Drawing.Size(218, 23);
            this.buttonRegistr.TabIndex = 5;
            this.buttonRegistr.Text = "Regisration";
            this.buttonRegistr.UseVisualStyleBackColor = true;
            this.buttonRegistr.Click += new System.EventHandler(this.buttonRegistr_Click);
            // 
            // RegisterForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(294, 346);
            this.Controls.Add(this.buttonRegistr);
            this.Controls.Add(this.textBoxFIO);
            this.Controls.Add(this.textBoxPassword);
            this.Controls.Add(this.labelFIO);
            this.Controls.Add(this.labelFirstPassword);
            this.Controls.Add(this.textBoxLogin);
            this.Controls.Add(this.labelLogin);
            this.Name = "RegisterForm";
            this.Text = "Register";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelLogin;
        private System.Windows.Forms.TextBox textBoxLogin;
        private System.Windows.Forms.Label labelFirstPassword;
        private System.Windows.Forms.Label labelFIO;
        private System.Windows.Forms.TextBox textBoxPassword;
        private System.Windows.Forms.TextBox textBoxFIO;
        private System.Windows.Forms.Button buttonRegistr;
    }
}
