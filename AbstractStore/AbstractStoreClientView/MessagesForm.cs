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
    public partial class MessagesForm : Form
    {
        public MessagesForm()
        {
            InitializeComponent();
            LoadData();
        }
        private void LoadData()
        {
            try
            {
                messagesGridView.DataSource =
                APIClient.GetRequest<List<MessageInfoViewModel>>
                ($"api/main/getmessages?clientid={ Program.Client.Id }");
                messagesGridView.Columns[0].Visible = false;
                messagesGridView.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                messagesGridView.Columns[3].Visible = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
