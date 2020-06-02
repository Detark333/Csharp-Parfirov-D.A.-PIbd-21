namespace AbstractJewelryStoreView
{
    partial class FormMain
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.manualToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.jewerlyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.productToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.reportsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.jewerliesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ordersToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.productJewerliesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dataGridView = new System.Windows.Forms.DataGridView();
            this.buttonCreateOrder = new System.Windows.Forms.Button();
            this.buttonToGiveToPerform = new System.Windows.Forms.Button();
            this.buttonOrderDone = new System.Windows.Forms.Button();
            this.buttonPayed = new System.Windows.Forms.Button();
            this.buttonRefresh = new System.Windows.Forms.Button();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.manualToolStripMenuItem,
            this.reportsToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(800, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // manualToolStripMenuItem
            // 
            this.manualToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.jewerlyToolStripMenuItem,
            this.productToolStripMenuItem});
            this.manualToolStripMenuItem.Name = "manualToolStripMenuItem";
            this.manualToolStripMenuItem.Size = new System.Drawing.Size(59, 20);
            this.manualToolStripMenuItem.Text = "Manual";
            // 
            // jewerlyToolStripMenuItem
            // 
            this.jewerlyToolStripMenuItem.Name = "jewerlyToolStripMenuItem";
            this.jewerlyToolStripMenuItem.Size = new System.Drawing.Size(116, 22);
            this.jewerlyToolStripMenuItem.Text = "Jewerly";
            this.jewerlyToolStripMenuItem.Click += new System.EventHandler(this.JewerlyToolStripMenuItem_Click);
            // 
            // productToolStripMenuItem
            // 
            this.productToolStripMenuItem.Name = "productToolStripMenuItem";
            this.productToolStripMenuItem.Size = new System.Drawing.Size(116, 22);
            this.productToolStripMenuItem.Text = "Product";
            this.productToolStripMenuItem.Click += new System.EventHandler(this.ProductToolStripMenuItem_Click);
            // 
            // reportsToolStripMenuItem
            // 
            this.reportsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.jewerliesToolStripMenuItem,
            this.ordersToolStripMenuItem,
            this.productJewerliesToolStripMenuItem});
            this.reportsToolStripMenuItem.Name = "reportsToolStripMenuItem";
            this.reportsToolStripMenuItem.Size = new System.Drawing.Size(59, 20);
            this.reportsToolStripMenuItem.Text = "Reports";
            // 
            // jewerliesToolStripMenuItem
            // 
            this.jewerliesToolStripMenuItem.Name = "jewerliesToolStripMenuItem";
            this.jewerliesToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.jewerliesToolStripMenuItem.Text = "Jewerlies";
            this.jewerliesToolStripMenuItem.Click += new System.EventHandler(this.JewerliesToolStripMenuItem_Click);
            // 
            // ordersToolStripMenuItem
            // 
            this.ordersToolStripMenuItem.Name = "ordersToolStripMenuItem";
            this.ordersToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.ordersToolStripMenuItem.Text = "Orders";
            this.ordersToolStripMenuItem.Click += new System.EventHandler(this.OrdersToolStripMenuItem_Click);
            // 
            // productJewerliesToolStripMenuItem
            // 
            this.productJewerliesToolStripMenuItem.Name = "productJewerliesToolStripMenuItem";
            this.productJewerliesToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.productJewerliesToolStripMenuItem.Text = "Product Jewerlies";
            this.productJewerliesToolStripMenuItem.Click += new System.EventHandler(this.ProductJewerliesToolStripMenuItem_Click);
            // 
            // dataGridView
            // 
            this.dataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView.Location = new System.Drawing.Point(12, 27);
            this.dataGridView.Name = "dataGridView";
            this.dataGridView.Size = new System.Drawing.Size(643, 335);
            this.dataGridView.TabIndex = 1;
            // 
            // buttonCreateOrder
            // 
            this.buttonCreateOrder.Location = new System.Drawing.Point(682, 54);
            this.buttonCreateOrder.Name = "buttonCreateOrder";
            this.buttonCreateOrder.Size = new System.Drawing.Size(93, 23);
            this.buttonCreateOrder.TabIndex = 2;
            this.buttonCreateOrder.Text = "Create order";
            this.buttonCreateOrder.UseVisualStyleBackColor = true;
            this.buttonCreateOrder.Click += new System.EventHandler(this.ButtonCreateOrder_Click);
            // 
            // buttonToGiveToPerform
            // 
            this.buttonToGiveToPerform.Location = new System.Drawing.Point(682, 83);
            this.buttonToGiveToPerform.Name = "buttonToGiveToPerform";
            this.buttonToGiveToPerform.Size = new System.Drawing.Size(93, 23);
            this.buttonToGiveToPerform.TabIndex = 3;
            this.buttonToGiveToPerform.Text = "ToGiveToPerform";
            this.buttonToGiveToPerform.UseVisualStyleBackColor = true;
            this.buttonToGiveToPerform.Click += new System.EventHandler(this.ButtonToGiveToPerform_Click);
            // 
            // buttonOrderDone
            // 
            this.buttonOrderDone.Location = new System.Drawing.Point(682, 112);
            this.buttonOrderDone.Name = "buttonOrderDone";
            this.buttonOrderDone.Size = new System.Drawing.Size(93, 23);
            this.buttonOrderDone.TabIndex = 4;
            this.buttonOrderDone.Text = "Order has done";
            this.buttonOrderDone.UseVisualStyleBackColor = true;
            this.buttonOrderDone.Click += new System.EventHandler(this.ButtonOrderDone_Click);
            // 
            // buttonPayed
            // 
            this.buttonPayed.Location = new System.Drawing.Point(682, 141);
            this.buttonPayed.Name = "buttonPayed";
            this.buttonPayed.Size = new System.Drawing.Size(93, 23);
            this.buttonPayed.TabIndex = 5;
            this.buttonPayed.Text = "Order has payed";
            this.buttonPayed.UseVisualStyleBackColor = true;
            this.buttonPayed.Click += new System.EventHandler(this.ButtonPayed_Click);
            // 
            // buttonRefresh
            // 
            this.buttonRefresh.Location = new System.Drawing.Point(682, 170);
            this.buttonRefresh.Name = "buttonRefresh";
            this.buttonRefresh.Size = new System.Drawing.Size(93, 23);
            this.buttonRefresh.TabIndex = 6;
            this.buttonRefresh.Text = "Refresh";
            this.buttonRefresh.UseVisualStyleBackColor = true;
            this.buttonRefresh.Click += new System.EventHandler(this.ButtonRefresh_Click);
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.buttonRefresh);
            this.Controls.Add(this.buttonPayed);
            this.Controls.Add(this.buttonOrderDone);
            this.Controls.Add(this.buttonToGiveToPerform);
            this.Controls.Add(this.buttonCreateOrder);
            this.Controls.Add(this.dataGridView);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "FormMain";
            this.Text = "Main";
            this.Load += new System.EventHandler(this.FormMain_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem manualToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem jewerlyToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem productToolStripMenuItem;
        private System.Windows.Forms.DataGridView dataGridView;
        private System.Windows.Forms.Button buttonCreateOrder;
        private System.Windows.Forms.Button buttonToGiveToPerform;
        private System.Windows.Forms.Button buttonOrderDone;
        private System.Windows.Forms.Button buttonPayed;
        private System.Windows.Forms.Button buttonRefresh;
        private System.Windows.Forms.ToolStripMenuItem reportsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem jewerliesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ordersToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem productJewerliesToolStripMenuItem;
    }
}