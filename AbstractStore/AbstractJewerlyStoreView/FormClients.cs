using AbstractJewerlyStoreBusinessLogic.BindingModels;
using AbstractJewerlyStoreBusinessLogic.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Unity;

namespace AbstractJewerlyStoreView
{
    public partial class FormClients : Form
    {
        [Dependency]
        public new IUnityContainer Container { get; set; }

        private readonly IClientLogic logic;
        public FormClients(IClientLogic logic)
        {
            InitializeComponent();
            this.logic = logic;
        }

        private void LoadData()
        {
            try
            {
                var list = logic.Read(null);
                if (list != null)
                {
                    ClientsGridView.DataSource = list;
                    ClientsGridView.Columns[0].Visible = false;
                    ClientsGridView.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                    ClientsGridView.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                    ClientsGridView.Columns[3].Visible = false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void DeleteButton_Click(object sender, EventArgs e)
        {
            if (ClientsGridView.SelectedRows.Count == 1)
            {
                if (MessageBox.Show("Удалить запись", "Вопрос", MessageBoxButtons.YesNo,
               MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    int id = Convert.ToInt32(ClientsGridView.SelectedRows[0].Cells[0].Value);
                    try
                    {
                        logic.Delete(new ClientBindingModel { Id = id });
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK,
                       MessageBoxIcon.Error);
                    }
                    LoadData();
                }
            }
        }

        private void UpdateButton_Click(object sender, EventArgs e)
        {
            LoadData();
        }

        private void ClientsForm_Load(object sender, EventArgs e)
        {
            LoadData();
        }
    }
}
