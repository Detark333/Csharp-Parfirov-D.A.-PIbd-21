﻿
using AbstractJewerlyStoreBusinessLogic.BindingModels;
using AbstractJewerlyStoreBusinessLogic.BuisnessLogic;
using AbstractJewerlyStoreBusinessLogic.Interfaces;
using AbstractJewerlyStoreBusinessLogic.ViewModels;
using AbstractJewerlyStoreView;
using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Unity;

namespace AbstractJewelryStoreView
{
    public partial class FormMain : Form
    {
        [Dependency]
        public new IUnityContainer Container { get; set; }
        private readonly MainLogic logic;
        private readonly IOrderLogic orderLogic;
        private readonly ReportLogic report;
        public FormMain(MainLogic logic, IOrderLogic orderLogic, ReportLogic report)
        {
            InitializeComponent();
            this.logic = logic;
            this.orderLogic = orderLogic;
            this.report = report;
        }

        private void FormMain_Load(object sender, EventArgs e)
        {
            LoadData();
        }
        private void LoadData()
        {
            try
            {
                List<OrderViewModel> list = orderLogic.Read(null);
                if (list != null)
                {
                    dataGridView.DataSource = list;
                    dataGridView.Columns[0].Visible = false;
                    dataGridView.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void JewerlyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var form = Container.Resolve<FormCountJewerly>();
            form.ShowDialog();
        }

        private void ProductToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var form = Container.Resolve<FormJProduct>();
            form.ShowDialog();
        }

        private void ButtonCreateOrder_Click(object sender, EventArgs e)
        {
           var form = Container.Resolve<FormOrder>();
           form.ShowDialog();
           LoadData();
        }

        private void ButtonToGiveToPerform_Click(object sender, EventArgs e)
        {
            if (dataGridView.SelectedRows.Count == 1)
            {
                int id = Convert.ToInt32(dataGridView.SelectedRows[0].Cells[0].Value);
                try
                {
                    logic.TakeOrderInWork(new ChangeStatusBindingModel { OrderId = id });
                    LoadData();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK,
                   MessageBoxIcon.Error);
                }
            }

        }

        private void ButtonOrderDone_Click(object sender, EventArgs e)
        {
            if (dataGridView.SelectedRows.Count == 1)
            {
                int id = Convert.ToInt32(dataGridView.SelectedRows[0].Cells[0].Value);
                try
                {
                    logic.FinishOrder(new ChangeStatusBindingModel { OrderId = id });
                    LoadData();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK,
                   MessageBoxIcon.Error);
                }
            }

        }

        private void ButtonPayed_Click(object sender, EventArgs e)
        {
            if (dataGridView.SelectedRows.Count == 1)
            {
                int id = Convert.ToInt32(dataGridView.SelectedRows[0].Cells[0].Value);
                try
                {
                    logic.PayOrder(new ChangeStatusBindingModel { OrderId = id });
                    LoadData();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK,
                   MessageBoxIcon.Error);
                }
            }

        }

        private void ButtonRefresh_Click(object sender, EventArgs e)
        {
            LoadData();
        }

        private void OrdersToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var form = Container.Resolve<FormExcel>();
            form.ShowDialog();
        }

        private void JewerliesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (var dialog = new SaveFileDialog { Filter = "docx|*.docx" })
            {
                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    report.SaveJewerliesToWordFile(new ReportBindingModel
                    {
                        FileName = dialog.FileName
                    });
                    MessageBox.Show("Выполнено", "Успех", MessageBoxButtons.OK,
                        MessageBoxIcon.Information);
                }
            }
        }

        private void ProductJewerliesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var form = Container.Resolve<FormPDF>();
            form.ShowDialog();
        }

        private void clientsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var form = Container.Resolve<FormClients>();
            form.ShowDialog();
        }
    }
}
