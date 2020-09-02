using AbstractJewerlyStoreBusinessLogic.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace AbstractStoreClientView
{
    public partial class FormMain : Form
    {
        public FormMain()
        {
            InitializeComponent();
            LoadOrderList();
        }
        private void LoadOrderList()
        {
            try
            {
                ordersGridView.DataSource =
                APIClient.GetRequest<List<OrderViewModel>>
                ($"api/main/getorders?clientid={ Program.Client.Id }");
                ordersGridView.Columns[0].Visible = false;
                ordersGridView.Columns[1].Visible = false;
                ordersGridView.Columns[2].Visible = false;
                ordersGridView.Columns[3].Visible = false;
                ordersGridView.Columns[4].AutoSizeMode =
                DataGridViewAutoSizeColumnMode.Fill;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }
        private void UpdateAccountToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var form = new UpdateAccountForm();
            form.ShowDialog();
        }
        private void CreateOrderToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var form = new OrderCreationForm();
            if (form.ShowDialog() == DialogResult.OK)
            {
                LoadOrderList();
            }
        }
        private void UpdateOrdersToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LoadOrderList();
        }
    }
}
