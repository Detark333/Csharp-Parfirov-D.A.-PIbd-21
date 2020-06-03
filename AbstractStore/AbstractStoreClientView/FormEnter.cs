using AbstractJewerlyStoreBusinessLogic.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace AbstractStoreClientView
{
    public partial class FormEnter : Form
    {
        public FormEnter()
        {
            InitializeComponent();
            Program.Client = null;
        }

        private void buttonEnter_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(textBoxLogin.Text) &&
                !string.IsNullOrEmpty(textBoxLogin.Text))
            {
                try
                {
                    Program.Client = APIClient.GetRequest<ClientViewModel>
                        ($"api/client/login?login={ textBoxLogin.Text }" +
                        $"&password={ textBoxPassword.Text }");
                    Close();
                }
                catch (AggregateException ex)
                {
                    foreach (var errInner in ex.InnerExceptions)
                    {
                        Debug.WriteLine(errInner);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Введите логин и пароль", "Ошибка", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private void buttonRegistr_Click(object sender, EventArgs e)
        {
            RegisterForm form = new RegisterForm();
            form.ShowDialog();
        }
    }
}
