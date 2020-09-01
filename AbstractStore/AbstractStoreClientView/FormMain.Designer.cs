namespace AbstractStoreClientView
{
    partial class FormMain
    {

        private System.ComponentModel.IContainer components = null;


        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }
        #region Windows Form Designer generated code
        private void InitializeComponent()
        {
            this.mainMenuStrip = new System.Windows.Forms.MenuStrip();
            this.createOrderToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.UpdateOrderListToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.UpdateAccountStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.messagesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ordersGridView = new System.Windows.Forms.DataGridView();
            this.mainMenuStrip.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ordersGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // mainMenuStrip
            // 
            this.mainMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.createOrderToolStripMenuItem,
            this.UpdateOrderListToolStripMenuItem,
            this.UpdateAccountStripMenuItem,
            this.messagesToolStripMenuItem});
            this.mainMenuStrip.Location = new System.Drawing.Point(0, 0);
            this.mainMenuStrip.Name = "mainMenuStrip";
            this.mainMenuStrip.Padding = new System.Windows.Forms.Padding(7, 2, 0, 2);
            this.mainMenuStrip.Size = new System.Drawing.Size(939, 24);
            this.mainMenuStrip.TabIndex = 0;
            this.mainMenuStrip.Text = "menuStrip1";
            // 
            // createOrderToolStripMenuItem
            // 
            this.createOrderToolStripMenuItem.Name = "createOrderToolStripMenuItem";
            this.createOrderToolStripMenuItem.Size = new System.Drawing.Size(93, 20);
            this.createOrderToolStripMenuItem.Text = "Создать заказ";
            this.createOrderToolStripMenuItem.Click += new System.EventHandler(this.CreateOrderToolStripMenuItem_Click);
            // 
            // UpdateOrderListToolStripMenuItem
            // 
            this.UpdateOrderListToolStripMenuItem.Name = "UpdateOrderListToolStripMenuItem";
            this.UpdateOrderListToolStripMenuItem.Size = new System.Drawing.Size(159, 20);
            this.UpdateOrderListToolStripMenuItem.Text = "Обновить список заказов";
            this.UpdateOrderListToolStripMenuItem.Click += new System.EventHandler(this.UpdateOrdersToolStripMenuItem_Click);
            // 
            // UpdateAccountStripMenuItem
            // 
            this.UpdateAccountStripMenuItem.Name = "UpdateAccountStripMenuItem";
            this.UpdateAccountStripMenuItem.Size = new System.Drawing.Size(117, 20);
            this.UpdateAccountStripMenuItem.Text = "Изменить данные";
            this.UpdateAccountStripMenuItem.Click += new System.EventHandler(this.UpdateAccountToolStripMenuItem_Click);
            // 
            // messagesToolStripMenuItem
            // 
            this.messagesToolStripMenuItem.Name = "messagesToolStripMenuItem";
            this.messagesToolStripMenuItem.Size = new System.Drawing.Size(62, 20);
            this.messagesToolStripMenuItem.Text = "Письма";
            this.messagesToolStripMenuItem.Click += new System.EventHandler(this.MessagesToolStripMenuItem_Click);
            // 
            // ordersGridView
            // 
            this.ordersGridView.AllowUserToAddRows = false;
            this.ordersGridView.AllowUserToDeleteRows = false;
            this.ordersGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.ordersGridView.Location = new System.Drawing.Point(14, 31);
            this.ordersGridView.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.ordersGridView.Name = "ordersGridView";
            this.ordersGridView.ReadOnly = true;
            this.ordersGridView.Size = new System.Drawing.Size(911, 410);
            this.ordersGridView.TabIndex = 1;
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(939, 455);
            this.Controls.Add(this.ordersGridView);
            this.Controls.Add(this.mainMenuStrip);
            this.MainMenuStrip = this.mainMenuStrip;
            this.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.Name = "FormMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Главная форма";
            this.mainMenuStrip.ResumeLayout(false);
            this.mainMenuStrip.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ordersGridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

            #endregion

        private System.Windows.Forms.MenuStrip mainMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem createOrderToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem UpdateOrderListToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem UpdateAccountStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem messagesToolStripMenuItem;
        private System.Windows.Forms.DataGridView ordersGridView;
    }
}
