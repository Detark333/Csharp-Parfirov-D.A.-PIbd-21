namespace AbstractJewelryStoreView
{
    partial class FormProductJewerly
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
            this.comboBoxJewerly = new System.Windows.Forms.ComboBox();
            this.labelJewerly = new System.Windows.Forms.Label();
            this.textBoxCount = new System.Windows.Forms.TextBox();
            this.labelCount = new System.Windows.Forms.Label();
            this.buttonSave = new System.Windows.Forms.Button();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // comboBoxJewerly
            // 
            this.comboBoxJewerly.FormattingEnabled = true;
            this.comboBoxJewerly.Location = new System.Drawing.Point(104, 12);
            this.comboBoxJewerly.Name = "comboBoxJewerly";
            this.comboBoxJewerly.Size = new System.Drawing.Size(201, 21);
            this.comboBoxJewerly.TabIndex = 0;
            // 
            // labelJewerly
            // 
            this.labelJewerly.AutoSize = true;
            this.labelJewerly.Location = new System.Drawing.Point(22, 15);
            this.labelJewerly.Name = "labelJewerly";
            this.labelJewerly.Size = new System.Drawing.Size(45, 13);
            this.labelJewerly.TabIndex = 1;
            this.labelJewerly.Text = "Jewerly:";
            // 
            // textBoxCount
            // 
            this.textBoxCount.Location = new System.Drawing.Point(104, 49);
            this.textBoxCount.Name = "textBoxCount";
            this.textBoxCount.Size = new System.Drawing.Size(201, 20);
            this.textBoxCount.TabIndex = 2;
            // 
            // labelCount
            // 
            this.labelCount.AutoSize = true;
            this.labelCount.Location = new System.Drawing.Point(22, 52);
            this.labelCount.Name = "labelCount";
            this.labelCount.Size = new System.Drawing.Size(38, 13);
            this.labelCount.TabIndex = 3;
            this.labelCount.Text = "Count:";
            // 
            // buttonSave
            // 
            this.buttonSave.Location = new System.Drawing.Point(135, 91);
            this.buttonSave.Name = "buttonSave";
            this.buttonSave.Size = new System.Drawing.Size(75, 23);
            this.buttonSave.TabIndex = 4;
            this.buttonSave.Text = "Save";
            this.buttonSave.UseVisualStyleBackColor = true;
            this.buttonSave.Click += new System.EventHandler(this.ButtonSave_Click);
            // 
            // buttonCancel
            // 
            this.buttonCancel.Location = new System.Drawing.Point(216, 91);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(75, 23);
            this.buttonCancel.TabIndex = 5;
            this.buttonCancel.Text = "Cancel";
            this.buttonCancel.UseVisualStyleBackColor = true;
            this.buttonCancel.Click += new System.EventHandler(this.ButtonCancel_Click);
            // 
            // FormProductJewerly
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(371, 126);
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.buttonSave);
            this.Controls.Add(this.labelCount);
            this.Controls.Add(this.textBoxCount);
            this.Controls.Add(this.labelJewerly);
            this.Controls.Add(this.comboBoxJewerly);
            this.Name = "FormProductJewerly";
            this.Text = "ProductCount";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox comboBoxJewerly;
        private System.Windows.Forms.Label labelJewerly;
        private System.Windows.Forms.TextBox textBoxCount;
        private System.Windows.Forms.Label labelCount;
        private System.Windows.Forms.Button buttonSave;
        private System.Windows.Forms.Button buttonCancel;
    }
}