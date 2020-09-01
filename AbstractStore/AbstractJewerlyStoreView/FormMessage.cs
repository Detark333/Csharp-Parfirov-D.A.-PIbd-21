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
    public partial class FormMessage : Form
    {
        [Dependency]
        public new IUnityContainer Container { get; set; }

        private readonly IMessageInfoLogic messageLogic;

        public FormMessage(IMessageInfoLogic messageLogic)
        {
            InitializeComponent();
            this.messageLogic = messageLogic;
        }

        private void LoadData()
        {
            try
            {
                var list = messageLogic.Read(null);
                if (list != null)
                {
                    messagesGridView.DataSource = list;
                    messagesGridView.Columns[0].Visible = false;
                    messagesGridView.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                    messagesGridView.Columns[3].Visible = false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void FormMessage_Load(object sender, EventArgs e)
        {
            LoadData();
        }
    }
}
